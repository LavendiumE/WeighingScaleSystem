using System;
using System.Collections.Generic;
using System.Text;

namespace WeighingScaleMiddleware.Models
{
    public class Recipe
    {
        public string Mutu { get; set; } = "";

        public decimal Bin1 { get; set; }
        public decimal Bin2 { get; set; }
        public decimal Bin3 { get; set; }
        public decimal Bin4 { get; set; }

        public decimal Semen { get; set; }
        public decimal FlyAsh { get; set; }
        public decimal Air { get; set; }
        public decimal Aditif { get; set; }
    }
}
