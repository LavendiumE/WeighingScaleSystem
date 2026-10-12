using System.IO.Ports;

namespace WeighingScaleMiddleware.Models
{
    public class SerialConfig
    {
        public string PortName { get; set; } = string.Empty;

        public int BaudRate { get; set; }

        public int DataBits { get; set; }

        public Parity Parity { get; set; }

        public StopBits StopBits { get; set; }
    }
}