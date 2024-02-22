using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.TERMINAL.Models
{
    public class PurchaseOrderBatch
    {
        public string BatchNumber { get; set; }

        public double BatchQuantity { get; set; }

        public string ItemCode { get; set; }

        public int LineNumber { get; set; }
    }
}
