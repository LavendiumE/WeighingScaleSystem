using System.IO.Ports;
using NModbus;
using NModbus.Data;
using NModbus.Serial;
using NModbus.Logging;

namespace WeighingScaleMiddleware.Services
{
    public class ModbusService
    {
        private SerialPort? _serialPort;
        private SerialPortAdapter? _adapter;
        private IModbusSlaveNetwork? _slaveNetwork;
        private IModbusSlave? _slave;
        private ISlaveDataStore? _dataStore;

        private CancellationTokenSource? _cancellationTokenSource;

        public bool IsRunning
        {
            get
            {
                return _serialPort != null && _serialPort.IsOpen;
            }
        }

        public bool Start(
            string portName,
            int baudRate,
            int dataBits,
            Parity parity,
            StopBits stopBits,
            byte slaveId)
        {
            try
            {
                _serialPort = new SerialPort
                {
                    PortName = portName,
                    BaudRate = baudRate,
                    DataBits = dataBits,
                    Parity = parity,
                    StopBits = stopBits,
                    ReadTimeout = 50,
                    WriteTimeout = 500
                };

                _serialPort.Open();

                System.Diagnostics.Debug.WriteLine(
                    $"[MODBUS] Serial port opened: {portName}, " +
                    $"BaudRate={baudRate}, DataBits={dataBits}, " +
                    $"Parity={parity}, StopBits={stopBits}, SlaveID={slaveId}"
                );

                _adapter = new SerialPortAdapter(_serialPort);

                var factory = new ModbusFactory(
                    logger: new DebugModbusLogger(LoggingLevel.Debug)
                );

                _slaveNetwork = factory.CreateRtuSlaveNetwork(_adapter);

                _dataStore = new SlaveDataStore();

                _slave = factory.CreateSlave(slaveId, _dataStore);

                _slaveNetwork.AddSlave(_slave);

                _cancellationTokenSource = new CancellationTokenSource();

                _ = Task.Run(async () =>
                {
                    try
                    {
                        await _slaveNetwork.ListenAsync(
                            _cancellationTokenSource.Token);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"Modbus error: {ex.Message}");
                    }
                });

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Modbus Start Error: {ex.Message}");

                Stop();

                return false;
            }
        }

        public void SetHoldingRegister(int address, ushort value)
        {
            if (_dataStore == null)
                return;

            if (address < 40001)
                return;

            ushort registerAddress = (ushort)(address - 40001);

            _dataStore.HoldingRegisters.WritePoints(
                registerAddress,
                new ushort[] { value }
            );

            System.Diagnostics.Debug.WriteLine(
                $"[MODBUS] Register updated | " +
                $"Address={address} | " +
                $"InternalAddress={registerAddress} | " +
                $"Value={value}"
            );
        }

        public void Stop()
        {
            try
            {
                _cancellationTokenSource?.Cancel();

                _slaveNetwork = null;
                _slave = null;
                _dataStore = null;

                _adapter?.Dispose();
                _adapter = null;

                if (_serialPort != null)
                {
                    if (_serialPort.IsOpen)
                    {
                        _serialPort.Close();
                    }

                    _serialPort.Dispose();
                    _serialPort = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Modbus Stop Error: {ex.Message}");
            }
        }
    }
}