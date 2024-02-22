using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.TERMINAL.Models
{
    public class IadeTalepleri
    {
        public int DocEntry { get; set; }

        public string CardCode { get; set; }

        public string CardName { get; set; }
        public string SevkAdresi { get; set; }

        public string DocDate { get; set; }
        public string DocDueDate { get; set; }

        public string TaxDate { get; set; } 
    }
}
