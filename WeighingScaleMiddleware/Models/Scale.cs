using WeighingScaleMiddleware.Services;

namespace WeighingScaleMiddleware.Models
{
    public class Scale
    {
        public int Id { get; set; }

        public decimal Weight { get; set; }

        public SerialService SerialService { get; }

        public Scale()
        {
            SerialService = new SerialService();
        }
    }
}