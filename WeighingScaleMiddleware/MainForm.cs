using System.IO.Ports;
using WeighingScaleMiddleware.Helpers;
using WeighingScaleMiddleware.Models;
using WeighingScaleMiddleware.Services;
using System.Linq;

namespace WeighingScaleMiddleware
{
    public partial class MainForm : Form
    {
        private readonly List<Scale> _scales = new();



        private ComboBox[] _cmbComPorts;
        private ComboBox[] _cmbBaudrates;
        private ComboBox[] _cmbDataBits;
        private ComboBox[] _cmbParity;
        private ComboBox[] _cmbStopBits;

        private Button[] _btnConnects;
        private Button[] _btnDisconnects;

        private TextBox[] _txtWeights;

        private Label[] _lblStatus;

        private Panel[] _pnlStatus;

        private readonly Form2 _dashboard;

        private readonly ScaleSettingsService _scaleSettingsService = new();
        private List<ScaleSetting> _savedScaleSettings = new();

        public MainForm(Form2 dashboard)
        {
            InitializeComponent();
            

            _dashboard = dashboard;

            this.FormClosing += MainForm_FormClosing;

            InitializeScales();
            InitializeControls();

            

        }

        private void InitializeControls()
        {
            _cmbComPorts =
            [
                cmbComPort1,
                cmbComPort2,
                cmbComPort3,
                cmbComPort4
            ];

            _cmbBaudrates =
            [
                cmbBaudrate1,
                cmbBaudrate2,
                cmbBaudrate3,
                cmbBaudrate4
            ];

            _cmbDataBits =
            [
                cmbDataBits1,
                cmbDataBits2,
                cmbDataBits3,
                cmbDataBits4
            ];

            _cmbParity =
            [
                cmbParity1,
                cmbParity2,
                cmbParity3,
                cmbParity4
            ];

            _cmbStopBits =
            [
                cmbStopBits1,
                cmbStopBits2,
                cmbStopBits3,
                cmbStopBits4
            ];

            _txtWeights =
            [
                txtWeight1,
                txtWeight2,
                txtWeight3,
                txtWeight4
            ];

            _lblStatus =
            [
                lblStatus1,
                lblStatus2,
                lblStatus3,
                lblStatus4
            ];

            _pnlStatus =
            [
                pnlStatus1,
                pnlStatus2,
                pnlStatus3,
                pnlStatus4
            ];


        }



        private void InitializeScales()
        {
            for (int i = 1; i <= 4; i++)
            {
                Scale scale = new Scale();

                scale.Id = i;

               

                scale.SerialService.DataReceived += SerialService_DataReceived;

                _scales.Add(scale);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSerialSettings();
            LoadSavedScaleSettings();

        }

        private void LoadSerialSettings()
        {
            string[] ports = SerialPort.GetPortNames();

            for (int i = 0; i < 4; i++)
            {
                _cmbComPorts[i].Items.Clear();
                _cmbComPorts[i].Items.AddRange(ports);

                _cmbBaudrates[i].Items.Clear();
                _cmbBaudrates[i].Items.AddRange(
                [
                    "600",
                    "1200",
                    "2400",
                    "4800",
                    "9600",
                    "19200",
                    "38400"
                ]);
                _cmbDataBits[i].Items.Clear();
                _cmbDataBits[i].Items.AddRange(
                [
                    "7","8"
                ]);

                _cmbParity[i].Items.Clear();
                _cmbParity[i].Items.AddRange(

                [
                Parity.None,
                    Parity.Even,
                    Parity.Odd
                    ]);

                _cmbStopBits[i].Items.Clear();
                _cmbStopBits[i].Items.AddRange(
                [
                StopBits.One,
                    StopBits.Two
                ]);

                _cmbBaudrates[i].SelectedItem = "9600";
                _cmbDataBits[i].SelectedItem = "7";
                _cmbParity[i].SelectedItem = Parity.Even;
                _cmbStopBits[i].SelectedItem = StopBits.One;
            }
        }

        private void LoadSavedScaleSettings()
        {
            _savedScaleSettings = _scaleSettingsService.Load();

            for (int i = 0; i < _savedScaleSettings.Count && i < 4; i++)
            {
                ScaleSetting setting = _savedScaleSettings[i];

                if (!string.IsNullOrWhiteSpace(setting.PortName))
                {
                    _cmbComPorts[i].SelectedItem = setting.PortName;
                }

                _cmbBaudrates[i].SelectedItem = setting.BaudRate.ToString();
                _cmbDataBits[i].SelectedItem = setting.DataBits.ToString();
                _cmbParity[i].SelectedItem = setting.Parity;
                _cmbStopBits[i].SelectedItem = setting.StopBits;

                // Auto-connect hanya jika COM Port tersedia
                if (setting.IsConnected &&
                    _cmbComPorts[i].SelectedIndex != -1)
                {
                    ConnectScale(i);
                }
                else
                {
                    _pnlStatus[i].BackColor = Color.Red;
                    _lblStatus[i].Text = "Disconnected";
                }
            }
        }

        private void ConnectScale(int index)
        {
            Scale scale = _scales[index];

            // Kalau memang sudah connect
            if (scale.SerialService.IsConnected)
            {
                _pnlStatus[index].BackColor = Color.LimeGreen;
                _lblStatus[index].Text = "Connected";

                MessageBox.Show(
                    $"Scale {index + 1} sudah terhubung.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            // Cek COM Port
            if (_cmbComPorts[index].SelectedIndex == -1)
            {
                MessageBox.Show(
                    $"Please select COM Port for Scale {index + 1}",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                SerialConfig config = new SerialConfig
                {
                    PortName = _cmbComPorts[index].Text,
                    BaudRate = Convert.ToInt32(_cmbBaudrates[index].Text),
                    DataBits = Convert.ToInt32(_cmbDataBits[index].Text),
                    Parity = (Parity)_cmbParity[index].SelectedItem!,
                    StopBits = (StopBits)_cmbStopBits[index].SelectedItem!
                };

                bool success = scale.SerialService.Connect(config);

                if (success && scale.SerialService.IsConnected)
                {
                    _pnlStatus[index].BackColor = Color.LimeGreen;
                    _lblStatus[index].Text = "Connected";

                    SaveScaleSetting(index, true);
                }
                else
                {
                    _pnlStatus[index].BackColor = Color.Red;
                    _lblStatus[index].Text = "Disconnected";

                    MessageBox.Show(
                        $"Gagal connect Scale {index + 1}.",
                        "Connection Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                _pnlStatus[index].BackColor = Color.Red;
                _lblStatus[index].Text = "Disconnected";

                MessageBox.Show(
                    $"Error saat connect Scale {index + 1}:\n{ex.Message}",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SaveScaleSetting(int index, bool isConnected)
        {
            while (_savedScaleSettings.Count <= index)
            {
                _savedScaleSettings.Add(new ScaleSetting());
            }

            _savedScaleSettings[index] = new ScaleSetting
            {
                PortName = _cmbComPorts[index].Text,
                BaudRate = Convert.ToInt32(_cmbBaudrates[index].Text),
                DataBits = Convert.ToInt32(_cmbDataBits[index].Text),
                Parity = (Parity)_cmbParity[index].SelectedItem!,
                StopBits = (StopBits)_cmbStopBits[index].SelectedItem!,
                IsConnected = isConnected
            };

            _scaleSettingsService.Save(_savedScaleSettings);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectScale(0);
        }

        private void SerialService_DataReceived(SerialService serialService, string data)
        {
            if (InvokeRequired)
            {
                Invoke(() => ProcessReceivedData(serialService, data));
            }
            else
            {
                ProcessReceivedData(serialService, data);
            }
        }

        private void ProcessReceivedData(SerialService serialService, string data)
        {
            txtReceive.AppendText(data + Environment.NewLine);

            Scale? scale = _scales.FirstOrDefault(x => x.SerialService == serialService);

            if (scale == null)
                return;

            decimal weight = WeightParser.ParseWeight(data);

            scale.Weight = weight;


            _txtWeights[scale.Id - 1].Text = weight.ToString("0000.00");

            _dashboard.UpdateActualScale(scale.Id, weight);

            this.Text = $"Scale {scale.Id} : {weight}";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect2_Click(object sender, EventArgs e)
        {
            ConnectScale(1);

        }

        private void btnConnect3_Click(object sender, EventArgs e)
        {
            ConnectScale(2);
        }

        private void btnConnect4_Click(object sender, EventArgs e)
        {
            ConnectScale(3);
        }

        private void DisconnectScale(int index)
        {
            Scale scale = _scales[index];

            try
            {
                scale.SerialService.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error saat disconnect Scale {index + 1}:\n{ex.Message}",
                    "Disconnect Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                _pnlStatus[index].BackColor = Color.Red;
                _lblStatus[index].Text = "Disconnected";

                SaveScaleSetting(index, false);
            }
        }

        private void btnDisconnect1_Click(object sender, EventArgs e)
        {
            DisconnectScale(0);
        }

        private void btnDisconnect2_Click(object sender, EventArgs e)
        {
            DisconnectScale(1);
        }

        private void btnDisconnect3_Click(object sender, EventArgs e)
        {
            DisconnectScale(2);
        }

        private void btnDisconnect4_Click(object sender, EventArgs e)
        {
            DisconnectScale(3);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Jangan disconnect scale ketika window setting ditutup.
            // Hanya sembunyikan window.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

    }
}
