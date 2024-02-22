using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.TERMINAL.Models
{
    public class InventoryTransferList
    {
        public int DocEntry { get; set; }

        public string CardCode { get; set; }

        public string CardName { get; set; }

        public string DocDate { get; set; }

        public string DocDueDate { get; set; }

        public string fromwhscode { get; set; }

        public string towhscode { get; set; }
    }
}
