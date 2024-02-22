using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.TERMINAL.Models
{
    public class OrderList
    {
        public int DocEntry { get; set; }

        public string CardCode { get; set; }

        public string CardName { get; set; }

        public string TaxDate { get; set; }

        public string DocDueDate { get; set; }

        public string WayBillNo { get; set; }

        public string Address { get; set; }
    }
}
