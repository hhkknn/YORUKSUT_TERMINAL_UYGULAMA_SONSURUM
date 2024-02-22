using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace AIF.TERMINAL
{
    public class parseNumber_Seperator
    {
        public static double ConvertToDouble(string val)
        {
            string decimalSembol = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string digitGrouping = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator;

            if (val.Contains(decimalSembol) && val.Contains(digitGrouping))
            {
                val = val.Replace(decimalSembol, "");
            }

            val = val.Replace(digitGrouping, decimalSembol);

            double ret = Convert.ToDouble(val);

            return ret;
        }

        //public static string setDoubleVal(string val)
        //{
        //    string decimalSembol = Program.decimalSeperator;
        //    string digitGrouping = Program.thousandsSeperator;

        //    val = val.Replace(decimalSembol, digitGrouping);

        //    return val;
        //}
    }
}