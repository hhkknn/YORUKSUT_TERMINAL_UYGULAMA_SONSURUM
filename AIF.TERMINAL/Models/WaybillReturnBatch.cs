﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.TERMINAL.Models
{
    public class WaybillReturnBatch
    {
        public int DocEntry { get; set; }

        public string BatchNumber { get; set; }

        public double BatchQuantity { get; set; }

        public string ItemCode { get; set; }

        public int LineNumber { get; set; }

        public int SAPLineNum { get; set; }

        public string DepoYeriId { get; set; }

        public string DepoYeriAdi { get; set; }
    }
}