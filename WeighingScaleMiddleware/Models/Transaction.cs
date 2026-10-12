using System;
using System.Collections.Generic;
using System.Text;

namespace WeighingScaleMiddleware.Models
{
    public class Transaction
    {
        public string TransId { get; set; } = "";

        public DateTime Tanggal { get; set; } = DateTime.Now;

        public string Supir { get; set; } = "";

        public string Pembeli { get; set; } = "";

        public string Proyek { get; set; } = "";

        public string NoTruck { get; set; } = "";

        public string Mutu { get; set; } = "";

        public string Alamat { get; set; } = "";

        public decimal Volume { get; set; }

        public decimal Ritase { get; set; }

        public string Keterangan { get; set; } = "";

        public decimal Total { get; set; }

        public string Petugas { get; set; } = "";

        public decimal Slump { get; set; }

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
