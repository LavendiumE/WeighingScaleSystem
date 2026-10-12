using System;
using System.Collections.Generic;
using System.Text;

namespace WeighingScaleMiddleware.Models
{
    namespace WeighingScaleMiddleware.Models
    {
        public class BatchingResult
        {
            public decimal Bin1 { get; set; }
            public decimal Bin2 { get; set; }
            public decimal Bin3 { get; set; }
            public decimal Bin4 { get; set; }

            public decimal CumulativeBin1 { get; set; }
            public decimal CumulativeBin2 { get; set; }
            public decimal CumulativeBin3 { get; set; }
            public decimal CumulativeBin4 { get; set; }

            public decimal Semen { get; set; }
            public decimal CumulativeSemen { get; set; }

            public decimal FlyAsh { get; set; }
            public decimal CumulativeFlyAsh { get; set; }
            
            public decimal Air { get; set; }
            public decimal Aditif { get; set; }
        }
    }
}
