using AIF.TERMINAL.Forms;
using AIF.TERMINAL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL
{
    internal static class Program
    {
        /// <summary>
        //// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            int exeSayisi = 0;
            string processName = "AIF.TERMINAL.exe";

            string query = "Select * from Win32_Process Where Name = \"" + processName + "\"";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    string owner = argList[1] + "\\" + argList[0];

                    if (argList[0].ToString() == System.Windows.Forms.SystemInformation.UserName.ToString() && exeSayisi >= 1)
                    {
                        MessageBox.Show("Bu uygulama şu an açık durumdadır. Tekrar açılamaz.", "Uyarı");
                        Application.Exit();
                        return;
                    }
                    else if (argList[0].ToString() == System.Windows.Forms.SystemInformation.UserName.ToString())
                    {
                        exeSayisi++;
                    }

                }
            }

            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
       (se, cert, chain, sslerror) =>
       {
           return true;
       };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Forms.SiparissizMalGirisi());

            WinController.LaunchFormGiris();
            Application.Run(WinController.GetFormGiris());


        }

    }
}