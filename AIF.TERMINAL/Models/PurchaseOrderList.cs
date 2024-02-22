using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.TERMINAL.Models
{
    public class PurchaseOrderList
    {
        public int DocEntry { get; set; }

        public string VendorCardCode { get; set; }

        public string VendorName { get; set; }

        public string TaxDate { get; set; }

        public string DocDueDate { get; set; }

        public string WayBillNo { get; set; }
    }
}
