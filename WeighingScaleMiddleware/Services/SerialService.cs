using System.IO.Ports;
using System.Text;
using WeighingScaleMiddleware.Models;

namespace WeighingScaleMiddleware.Services
{
    public class SerialService
    {
        public event Action<SerialService, string>? DataReceived;

        private SerialPort? _serialPort;

        private readonly StringBuilder _buffer = new();

        public bool IsConnected =>
            _serialPort != null && _serialPort.IsOpen;

        public bool Connect(SerialConfig config)
        {
            try
            {
                // Kalau sudah connected, jangan connect lagi
                if (IsConnected)
                    return true;

                // Bersihkan object lama kalau ada
                if (_serialPort != null)
                {
                    _serialPort.DataReceived -= SerialPort_DataReceived;

                    if (_serialPort.IsOpen)
                        _serialPort.Close();

                    _serialPort.Dispose();
                    _serialPort = null;
                }

                _buffer.Clear();

                var serialPort = new SerialPort
                {
                    PortName = config.PortName,
                    BaudRate = config.BaudRate,
                    DataBits = config.DataBits,
                    Parity = config.Parity,
                    StopBits = config.StopBits,
                    Encoding = Encoding.ASCII
                };

                serialPort.DataReceived += SerialPort_DataReceived;

                serialPort.Open();

                _serialPort = serialPort;

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Connect Error: {ex.Message}"
                );

                _serialPort = null;

                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (_serialPort == null)
                    return;

                // Lepaskan event dulu
                _serialPort.DataReceived -= SerialPort_DataReceived;

                // Tutup COM port
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }

                // Dispose object
                _serialPort.Dispose();

                _serialPort = null;

                // Bersihkan data sisa
                _buffer.Clear();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Disconnect Error: {ex.Message}"
                );

                // Pastikan state internal tetap dianggap disconnected
                _serialPort = null;
                _buffer.Clear();
            }
        }

        private void SerialPort_DataReceived(
            object sender,
            SerialDataReceivedEventArgs e)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
                return;

            try
            {
                string data = _serialPort.ReadExisting();

                if (string.IsNullOrEmpty(data))
                    return;

                _buffer.Append(data);

                string bufferedData = _buffer.ToString();

                int newlineIndex =
                    bufferedData.IndexOf('\n');

                while (newlineIndex >= 0)
                {
                    string completeData =
                        bufferedData
                            .Substring(0, newlineIndex)
                            .Trim();

                    bufferedData =
                        bufferedData.Substring(
                            newlineIndex + 1
                        );

                    if (!string.IsNullOrWhiteSpace(completeData))
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"COMPLETE DATA: [{completeData}]"
                        );

                        DataReceived?.Invoke(
                            this,
                            completeData
                        );
                    }

                    newlineIndex =
                        bufferedData.IndexOf('\n');
                }

                _buffer.Clear();
                _buffer.Append(bufferedData);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Read Error: {ex.Message}"
                );
            }
        }
    }
}