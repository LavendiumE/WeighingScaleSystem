using System.IO.Ports;
using System.Text.Json;
using WeighingScaleMiddleware.Models;

namespace WeighingScaleMiddleware.Services
{
    public class ScaleSetting
    {
        public string PortName { get; set; } = "";
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public bool IsConnected { get; set; }
    }

    public class ScaleSettingsService
    {
        private readonly string _filePath;

        public ScaleSettingsService()
        {
            _filePath = Path.Combine(
                AppContext.BaseDirectory,
                "scale-settings.json"
            );
        }

        public List<ScaleSetting> Load()
        {
            if (!File.Exists(_filePath))
                return new List<ScaleSetting>();

            try
            {
                string json = File.ReadAllText(_filePath);

                return JsonSerializer.Deserialize<List<ScaleSetting>>(json)
                    ?? new List<ScaleSetting>();
            }
            catch
            {
                return new List<ScaleSetting>();
            }
        }

        public void Save(List<ScaleSetting> settings)
        {
            string json = JsonSerializer.Serialize(
                settings,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            File.WriteAllText(_filePath, json);
        }
    }
}