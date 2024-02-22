using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL_AutoUpdate
{
    public partial class frmAutoUpdate : Form
    {
        public frmAutoUpdate()
        {
            InitializeComponent();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += _worker_DoWork;
            _worker.ProgressChanged += WorkerProgressChanged;
            _worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private readonly BackgroundWorker _worker = new BackgroundWorker();
        private int prgresssize = 0;
        public static string mKodValue = System.Configuration.ConfigurationManager.AppSettings["MusteriKodu"];

        private void frmAutoUpdate_Load(object sender, EventArgs e)
        {
            if (mKodValue == "10TRMN")
            {
                ftpAdress = "ftp://ftp.aifteam.click/httpdocs/Projects/TERMINAL_OTAT/";
                //ftpAdress = "ftp://ftp.tanas.com.tr/TERMINAL_OTAT/";
            }
            else if (mKodValue == "30TRMN")
            {
                ftpAdress = "ftp://ftp.aifteam.click/httpdocs/Projects/TERMINAL_ANATOLYA_x64/";
                //ftpAdress = "ftp://ftp.tanas.com.tr/TERMINAL_ANATOLYA/";
            }

            var dosyalar = ListFiles();
            progressBar1.Maximum = dosyalar.Count;
            _worker.RunWorkerAsync();
        }

        private string ftpAdress = "";

        private List<string> ListFiles()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAdress);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                request.Credentials = new NetworkCredential("paifP37le", "Aif2021!");

                //request.Credentials = new NetworkCredential("aif@aifteam.com", "SJ^FB5TAKDGq");
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\UpdateLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //MessageBox.Show("Test");
            var worker = sender as BackgroundWorker;
            WriteToFile(DateTime.Now + "--> Exe update etme işlemi başladı.");
            var _assembly = System.Reflection.Assembly
             .GetExecutingAssembly().GetName().CodeBase;

            var _path = System.IO.Path.GetDirectoryName(_assembly) + "\\";
            _path = _path.Replace("file:\\", "");
            //MessageBox.Show("Test1");

            WriteToFile(DateTime.Now + " Exe dosyasının çalıştığı ana klasör yolu --> " + _path);

            var dosyalar = ListFiles();
            int i = 1;
            prgresssize = dosyalar.Count;
            WriteToFile(DateTime.Now + " Yüklenecek dosya sayısı --> " + dosyalar.Count);
            WebClient request = new WebClient();
            string url = ftpAdress;
            request.Credentials = new NetworkCredential("paifP37le", "Aif2021!");

            //request.Credentials = new NetworkCredential("aif@aifteam.com", "SJ^FB5TAKDGq");
            try
            {
                foreach (var item in dosyalar)
                {
                    try
                    {
                        WriteToFile(DateTime.Now + " Yüklenecek dosya adı --> " + item);
                        if (item == ".")
                        {
                            continue;
                        }

                        url = ftpAdress + item;
                        
                        request.DownloadFile(url, _path + item);

                        if (item == "AIF.TERMINAL.exe.config")
                        {
                            try
                            {
                                var _assembly2 = System.Reflection.Assembly
                                    .GetExecutingAssembly().GetName().CodeBase;

                                var _path2 = System.IO.Path.GetDirectoryName(_assembly2) + "\\";

                                string configFile = System.IO.Path.Combine(_path2, "AIF.TERMINAL.exe.config");
                                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                                configFile = configFile.Replace("file:\\", "");
                                configFileMap.ExeConfigFilename = configFile;
                                System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

                                config.AppSettings.Settings["MusteriKodu"].Value = mKodValue;
                                config.Save();

                                WriteToFile(DateTime.Now + " Mkod kaydedildi --> " + mKodValue);
                            }
                            catch (Exception ex)
                            {
                                WriteToFile(DateTime.Now + " Mkod kaydedilirken hata verdi --> " + ex.Message);
                            }
                        }

                        WriteToFile(DateTime.Now + " Dosya yüklendi --> " + _path + item);
                    }
                    catch (Exception ex)
                    {
                        WriteToFile(DateTime.Now + " " + item + " Dosyası yüklenirken hata oluştu. --> " + ex.Message + " " + ex.InnerException);
                    }
                    finally
                    {
                        worker.ReportProgress(i);
                        i++;
                    }
                }

                //MessageBox.Show("Güncelleme Tamamlandı");

                this.Close();
                Dispose();
                Application.Exit();
                System.Diagnostics.Process.Start(Application.StartupPath + "\\AIF.TERMINAL.exe");
            }
            catch (Exception ex)
            {
                WriteToFile(DateTime.Now + " Genel Hata. --> " + ex.Message);
            }
        }

        private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //progressBarControl1.EditValue = 0;
        }

        private void frmAutoUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
            Environment.Exit(1);
        }
    }
}