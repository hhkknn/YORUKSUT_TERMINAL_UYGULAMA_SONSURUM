using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.TERMINAL.Models
{
    public class Parties
    {
        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public string BarCode { get; set; }

        public string BatchNumber { get; set; }

        public int DocEntry { get; set; }

        public double PaletIciKoliAD { get; set; }
        public double KoliIciAD { get; set; }
        public double PaletIciAD { get; set; }
        public double TopMik { get; set; }

        public string MusteriSipNo { get; set; }
        public string SevkiyatAdresi { get; set; }

    }
}
