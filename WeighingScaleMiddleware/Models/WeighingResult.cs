using System;
using System.Collections.Generic;
using System.Text;

namespace WeighingScaleMiddleware.Models
{
    public class WeighingResult
    {
        public decimal Bin1 { get; set; }

        public decimal Bin2 { get; set; }

        public decimal Bin3 { get; set; }

        public decimal Bin4 { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}