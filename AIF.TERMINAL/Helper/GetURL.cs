using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.TERMINAL.Helper
{
    public class GetURL
    {
        public string getURL(string mKod)
        {
            if (mKod == "10TRMN")
            {
                //return "http://10.34.1.150:3090";
                //return "https://localhost:44379/";
                return "http://10.34.1.150:3091";
            }
            else if (mKod == "30TRMN")
            {
                ////return "http://192.168.1.239:3091/";
                return "http://10.10.227.15:3092";
            }
            else if (mKod == "70TRMN")
            {
                ////return "http://192.168.1.239:3091/";
                return "http://10.100.24.6:3092";
            }
            else if (mKod == "20TRMN")
            {
                //return "http://192.168.2.51:3092/"; //canlı
                return "http://192.168.2.51:3093/";
            }
            else
            {
                return "";
            }
        }
    }
}