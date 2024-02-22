using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AIF.TERMINAL.Helper;
using System.Runtime.InteropServices;
using System.Globalization;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace AIF.TERMINAL.Forms
{
    public partial class Giris : form_Base
    {
        //font start.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        public static string exeVersion = "1.0.0.47";
        public static string mKodValue = System.Configuration.ConfigurationManager.AppSettings["MusteriKodu"];
        public static string value = "";

        public Giris()
        {
            #region update

            //string url = "";
            //WebClient request = new WebClient();

            ////mKodValue = "10TRMN";
            ////mKodValue = "30TRMN";
            //if (mKodValue != "")
            //{
            //    if (mKodValue == "10TRMN")
            //    {
            //        url = "ftp://ftp.aifteam.click/httpdocs/Projects/TERMINAL_OTAT/" + "version.xml";

            //        //url = "ftp://ftp.tanas.com.tr/TERMINAL_OTAT/" + "version.xml";
            //    }
            //    else if (mKodValue == "30TRMN")
            //    {
            //        url = "ftp://ftp.aifteam.click/httpdocs/Projects/TERMINAL_ANATOLYA_x64/" + "version.xml";

            //        //url = "ftp://ftp.tanas.com.tr/TERMINAL_ANATOLYA/" + "version.xml";
            //    }

            //    try
            //    {
            //        var _assembly = System.Reflection.Assembly
            //            .GetExecutingAssembly().GetName().CodeBase;

            //        var _path = System.IO.Path.GetDirectoryName(_assembly) + "\\";

            //        string configFile = System.IO.Path.Combine(_path, "AIF.TERMINAL_AutoUpdate.exe.config");
            //        ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            //        configFile = configFile.Replace("file:\\", "");
            //        configFileMap.ExeConfigFilename = configFile;
            //        System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            //        config.AppSettings.Settings["MusteriKodu"].Value = mKodValue;
            //        config.Save();
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //    request.Credentials = new NetworkCredential("paifP37le", "Aif2021!");

            //    //request.Credentials = new NetworkCredential("aif@aifteam.com", "SJ^FB5TAKDGq");

            //    try
            //    {
            //        byte[] newFileData = request.DownloadData(url);
            //        string fileString = System.Text.Encoding.UTF8.GetString(newFileData);

            //        XmlDocument xmlDoc = new XmlDocument();
            //        xmlDoc.LoadXml(fileString);
            //        XmlNodeList parentNode = xmlDoc.GetElementsByTagName("version");

            //        var aaa = parentNode[0].InnerText;

            //        if (exeVersion != aaa)
            //        {
            //            DialogResult dialog = CustomMsgBtn.Show("UYGULAMANIN GÜNCEL VERSİYONU YAYINLANMIŞTIR, YÜKLEMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

            //            if (dialog == DialogResult.No)
            //            {
            //            }
            //            else
            //            {
            //                this.Close();
            //                Dispose();
            //                Application.Exit();
            //                var c = Application.StartupPath + "\\AIF.TERMINAL_AutoUpdate.exe";
            //                System.Diagnostics.Process.Start(Application.StartupPath + "\\AIF.TERMINAL_AutoUpdate.exe");
            //            }
            //            //    System.Threading.Thread t = new System.Threading.Thread(
            //            //new System.Threading.ThreadStart(updatexe)

            //            //);
            //            //    t.Start();
            //        }
            //    }
            //    catch (WebException exx)
            //    {
            //        // Do something such as log error, but this is based on OP's original code
            //        // so for now we do nothing.
            //    }
            //}

            #endregion update

            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;
            //initialWidth = 1024;
            //initialHeight = 768;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = label3.Font.Size;
            label3.Resize += Form_Resize;

            initialFontSize = label4.Font.Size;
            label4.Resize += Form_Resize;

            //initialFontSize = cmbCompany.Font.Size;
            //cmbCompany.Resize += Form_Resize;

            //initialFontSize = txtUserName.Font.Size;
            //txtUserName.Resize += Form_Resize;

            //initialFontSize = txtPassword.Font.Size;
            //txtPassword.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = btnHakkinda.Font.Size;
            btnHakkinda.Resize += Form_Resize;

            //font end
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label3.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label4.Font.Style);

            cmbCompany.Font = new Font(cmbCompany.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbCompany.Font.Style);

            txtUserName.Font = new Font(txtUserName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUserName.Font.Style);

            txtPassword.Font = new Font(txtPassword.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPassword.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button1.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button2.Font.Style);

            btnHakkinda.Font = new Font(btnHakkinda.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnHakkinda.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtUserName.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
            txtPassword.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
            cmbCompany.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
            //end yükseklik-genislik
            ////font end
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ClassStyle |= 0x20000;

                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }

        public static string _dbName = "";
        public static string _userCode = "";

        private void Giris_Load(object sender, EventArgs e)
        {
            #region güncelleme

            //string url = "";
            //WebClient request = new WebClient();
            ////mKodValue = "30TRMN";
            //if (mKodValue == "10TRMN")
            //{
            //    url = "ftp://ftp.aifteam.click/httpdocs/Projects/TERMINAL_OTAT/" + "version.xml";

            //    //url = "ftp://ftp.tanas.com.tr/TERMINAL_OTAT/" + "version.xml";
            //}
            //else if (mKodValue == "30TRMN")
            //{
            //    url = "ftp://ftp.aifteam.click/httpdocs/Projects/TERMINAL_ANATOLYA_x64/" + "version.xml";

            //    //url = "ftp://ftp.tanas.com.tr/TERMINAL_ANATOLYA/" + "version.xml";
            //}

            //try
            //{
            //    var _assembly = System.Reflection.Assembly
            //        .GetExecutingAssembly().GetName().CodeBase;

            //    var _path = System.IO.Path.GetDirectoryName(_assembly) + "\\";

            //    string configFile = System.IO.Path.Combine(_path, "AIF.TERMINAL_AutoUpdate.exe.config");
            //    ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            //    configFile = configFile.Replace("file:\\", "");
            //    configFileMap.ExeConfigFilename = configFile;
            //    System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            //    config.AppSettings.Settings["MusteriKodu"].Value = mKodValue;
            //    config.Save();
            //}
            //catch (Exception)
            //{
            //}

            ////request.Credentials = new NetworkCredential("aif@aifteam.com", "SJ^FB5TAKDGq");
            //request.Credentials = new NetworkCredential("paifP37le", "Aif2021!");

            //try
            //{
            //    byte[] newFileData = request.DownloadData(url);
            //    string fileString = System.Text.Encoding.UTF8.GetString(newFileData);

            //    XmlDocument xmlDoc = new XmlDocument();
            //    xmlDoc.LoadXml(fileString);
            //    XmlNodeList parentNode = xmlDoc.GetElementsByTagName("version");

            //    var aaa = parentNode[0].InnerText;
            //    //url = "ftp://ftp.tanas.com.tr/DMS/" + "AIF.PM_V3.exe";
            //    //request.DownloadFile(url, @"C:\KargoLog\" + "AIF.PM_V3.exe");

            //    if (exeVersion != aaa)
            //    {
            //        DialogResult dialog = CustomMsgBtn.Show("UYGULAMANIN GÜNCEL VERSİYONU YAYINLANMIŞTIR, YÜKLEMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

            //        if (dialog == DialogResult.No)
            //        {
            //        }
            //        else
            //        {
            //            this.Close();
            //            Dispose();
            //            Application.Exit();
            //            var c = Application.StartupPath + "\\AIF.TERMINAL_AutoUpdate.exe";
            //            System.Diagnostics.Process.Start(Application.StartupPath + "\\AIF.TERMINAL_AutoUpdate.exe");
            //        }
            //        //    System.Threading.Thread t = new System.Threading.Thread(
            //        //new System.Threading.ThreadStart(updatexe)

            //        //);
            //        //    t.Start();
            //    }
            //}
            //catch (WebException exx)
            //{
            //    // Do something such as log error, but this is based on OP's original code
            //    // so for now we do nothing.
            //}
            #endregion güncelleme

            lblVersion.Text = "V" + exeVersion;

            //mKodValue = "10TRMN";
            mKodValue = "20TRMN";
            //mKodValue = "70TRMN";
            if (mKodValue == "10TRMN")
            {
                //lblGirisBaslik.Text = "TUNÇMATİK BAYİ YÖNETİM SİSTEMİ";
                //pictureEdit1.Image = Properties.Resources.tuncmatik_logo;

                this.BackgroundImage = Properties.Resources.OTAT_UVT_ArkaPlanV3;
            }
            else if (mKodValue == "30TRMN")
            {
                btnHakkinda.Visible = false;
                //lblGirisBaslik.Text = "AIFTEAM";
                //pictureEdit1.Image = Properties.Resources.AIFTeam2;

                this.BackgroundImage = Properties.Resources.ANATOLYA_ARKAPLAN_jpeg;
            }
            else if (mKodValue == "20TRMN")
            {
                btnHakkinda.Visible = false;
                //lblGirisBaslik.Text = "AIFTEAM";
                //pictureEdit1.Image = Properties.Resources.AIFTeam2;

                this.BackgroundImage = Properties.Resources.YORUK_UVT_ArkaPlanv2;
            }

            txtUserName.Focus();

            GetURL getURL = new GetURL();

            value = getURL.getURL(mKodValue);

            if (value == "")
            {
                CustomMsgBox.Show("URL HATASI OLUŞTU", "Uyarı", "Tamam", "");
                return;
            }

            try
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response response = new Response();
                response = aIFTerminalServiceSoapClient.GetcompanyList("", mKodValue);
                if (response._list.Rows.Count > 0)
                {
                    cmbCompany.DataSource = response._list;
                    cmbCompany.DisplayMember = "cmpName";
                    cmbCompany.ValueMember = "dbName";
                    cmbCompany.Enabled = true;
                }

                //txtUserName.Text = "manager";
                //txtPassword.Text = "1234";
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("Hata:" + ex.Message, "Uyarı", "TAMAM", "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static GenelParametreler genelParametreler = new GenelParametreler();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region cc

                try
                {
                    #region config

                    IFirebaseConfig config = new FirebaseConfig
                    {
                        BasePath = "https://mfhcdc-e278f-default-rtdb.firebaseio.com/",
                    };

                    IFirebaseClient client;

                    #endregion config

                    client = new FireSharp.FirebaseClient(config);

                    if (client == null)
                    {
                        //MessageBox.Show("Base Bağlantı hatasi.");
                    }
                    else
                    {
                        if (mKodValue == "")
                        {
                            CustomMsgBox.Show("Müşteri kodu bulunamadı.", "UYARI", "TAMAM", "");
                            System.Windows.Forms.Application.Exit();
                            return;
                        }
                        FirebaseResponse responsefire = client.Get(mKodValue);

                        if (responsefire != null)
                        {
                            Veri result = responsefire.ResultAs<Veri>();

                            if (result != null)
                            {
                                if (!string.IsNullOrEmpty(result.val.ToString()))
                                {
                                    DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                                    DateTime dt3 = DateTime.ParseExact(result.val, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                                    //dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day);
                                    DateTime date = GetTime().Date;

                                    int d = Convert.ToInt32((dt3 - date).TotalDays);

                                    if (d <= 0)
                                    {
                                        //if (date == result.val)
                                        //{
                                        CustomMsgBox.Show("Program kullanım süresi dolmuştur. Kullanıma devam edebilmek için AIFTEAM ile irtibata geçiniz.", "UYARI", "TAMAM", "");

                                        #region menu remove

                                        try
                                        {
                                            //if (muhatapmutabakat == "Y")
                                            //{
                                            //    Handler.SAPApplication.Menus.RemoveEx("mhtpMtbkt");
                                            //}
                                        }
                                        catch (Exception)
                                        {
                                        }

                                        #endregion menu remove

                                        System.Windows.Forms.Application.Exit();
                                        //System.Windows.Forms.Application.ExitThread();
                                        return;
                                        //Close();
                                        //}
                                    }

                                    if (d > 0)
                                    {
                                        if (!string.IsNullOrEmpty(result.inf.ToString()))
                                        {
                                            if (Convert.ToInt32(result.inf) != 0)
                                            {
                                                if (d <= Convert.ToInt32(result.inf))
                                                {
                                                    CustomMsgBox.Show("Program kullanım süresinin bitimine " + d + " gün kalmıştır. Kullanıma devam edebilmek için AIFTEAM ile irtibata geçiniz.", "UYARI", "TAMAM", "");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMsgBox.Show("Base hatası oluştu.", "UYARI", "TAMAM", "");
                    return;
                }

                #endregion cc

                string dbName = cmbCompany.SelectedValue.ToString();
                string userName = txtUserName.Text;
                string password = txtPassword.Text;

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response response = new Response();
                response = aIFTerminalServiceSoapClient.Login(userName, password, dbName, mKodValue);

                if (cmbCompany.SelectedValue.ToString() == "")
                {
                    CustomMsgBox.Show("LÜTFEN ŞİRKET SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                }
                else if (txtUserName.Text == "")
                {
                    CustomMsgBox.Show("LÜTFEN KULLANICI ADI GİRİNİZ.", "Uyarı", "Tamam", "");
                }
                else if (txtPassword.Text == "")
                {
                    CustomMsgBox.Show("LÜTFEN ŞİFRE GİRİNİZ.", "Uyarı", "Tamam", "");
                }
                else
                {
                    if (response.Val == 0)
                    {
                        if (response._list.Rows.Count > 0)
                        {
                            //Hide();
                            Forms.Menu menu = new Menu(userName, dbName);
                            Forms.SubeSecim subeSecim = new SubeSecim("ŞUBE SEÇİMİ");
                            _dbName = dbName;
                            _userCode = userName;
                            whsCodes = new List<string>();
                            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                            Response respWhs = null;
                            //if (Giris.genelParametreler.DepoCalismaTipi == "1")
                            //{
                            respWhs = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
                            //}
                            //else if (Giris.genelParametreler.DepoCalismaTipi == "2")
                            //{
                            //    respWhs = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
                            //}

                            //Response respWhs = aIFTerminalServiceSoapClient1.GetWareHouseByUserCode(_dbName, _userCode, Giris.mKodValue);

                            if (respWhs.Val == 0)
                            {
                                foreach (DataRow item in respWhs._list.Rows)
                                {
                                    if (item["WhsCode"].ToString() != "")
                                    {
                                        whsCodes.Add(item["WhsCode"].ToString());
                                    }
                                }
                            }

                            #region Genel Parametre verileri alınır.

                            aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                            Response respGenelParametreler = aIFTerminalServiceSoapClient1.getGenelParametreler(_dbName, mKodValue);
                            //genelParametreler.DepoYeriCalisir = "Y";
                            if (respGenelParametreler != null && respGenelParametreler._list.Rows.Count > 0)
                            {
                                genelParametreler.DepoYeriCalisir = respGenelParametreler._list.Rows[0]["U_DepoYeriCalisir"].ToString();
                                genelParametreler.TalebeBaglidaOrjinalOlustur = respGenelParametreler._list.Rows[0]["U_TlpBglOrj"].ToString();
                                genelParametreler.TalepsizDepoNaklindeTaslakBelgeOlustur = respGenelParametreler._list.Rows[0]["U_TlpszTslk"].ToString();
                                genelParametreler.TurkceArama = respGenelParametreler._list.Rows[0]["U_TurkceArama"].ToString();
                                genelParametreler.CrystalKullan = respGenelParametreler._list.Rows[0]["U_CrystalKullan"].ToString();
                                genelParametreler.CekmeListesiFazlaMiktarGirer = respGenelParametreler._list.Rows[0]["U_CkmFzlMktr"].ToString();
                                genelParametreler.CekmeListesiKalemleriniGrupla = respGenelParametreler._list.Rows[0]["U_CkmGrpla"].ToString();
                                genelParametreler.SayimMiktariOtomatikOlarakAcilsin = respGenelParametreler._list.Rows[0]["U_SayimMikOto"].ToString();
                                genelParametreler.SayimButonuOtomatikOlarakBasilsin = respGenelParametreler._list.Rows[0]["U_SayimBtnOto"].ToString();
                                genelParametreler.DepoCalismaTipi = respGenelParametreler._list.Rows[0]["U_DepoCalismaTipi"].ToString();
                                genelParametreler.BarkodKalemBirlesikOku = respGenelParametreler._list.Rows[0]["U_BarkodKalemOku"].ToString();
                                genelParametreler.TarihBazliPartiOlustur = respGenelParametreler._list.Rows[0]["U_TarihBazParti"].ToString();
                                genelParametreler.UygulamaYetkiSifresi = respGenelParametreler._list.Rows[0]["U_YetkiSifre"].ToString(); 

                                if (respGenelParametreler._list.Rows[0]["U_OndalikMiktar"] == DBNull.Value || Convert.ToInt32(respGenelParametreler._list.Rows[0]["U_OndalikMiktar"]) == 0)
                                {
                                    CustomMsgBox.Show("GENEL PARAMETRE ONDALIKLI MİKTAR GİRİŞİ YAPILMADIĞINDAN DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                                    return;
                                }

                                genelParametreler.OndalikMiktar = Convert.ToInt32(respGenelParametreler._list.Rows[0]["U_OndalikMiktar"]);

                                if (respGenelParametreler._list.Rows[0]["U_UrnSrguFiyat"] != DBNull.Value && respGenelParametreler._list.Rows[0]["U_UrnSrguFytList"] != DBNull.Value)
                                {
                                    genelParametreler.UrunSorguFiyat = respGenelParametreler._list.Rows[0]["U_UrnSrguFiyat"].ToString();
                                    genelParametreler.UrunSorguFiyatList = respGenelParametreler._list.Rows[0]["U_UrnSrguFytList"].ToString();
                                }
                                genelParametreler.SubeSecimiYapilsin = respGenelParametreler._list.Rows[0]["U_SubeSecimi"].ToString();
                                genelParametreler.PaletYapmadaDepoSecilsin = respGenelParametreler._list.Rows[0]["U_PltYapDepSec"].ToString();
                            }
                            else
                            {
                                genelParametreler = new GenelParametreler();
                                genelParametreler.DepoYeriCalisir = "N";
                                genelParametreler.TalebeBaglidaOrjinalOlustur = "N";
                                genelParametreler.TurkceArama = "N";
                                genelParametreler.CrystalKullan = "";
                                genelParametreler.CekmeListesiFazlaMiktarGirer = "";
                                genelParametreler.TalepsizDepoNaklindeTaslakBelgeOlustur = "N";
                                genelParametreler.CekmeListesiKalemleriniGrupla = "N";
                                genelParametreler.SayimMiktariOtomatikOlarakAcilsin = "N";
                                genelParametreler.SayimButonuOtomatikOlarakBasilsin = "N";
                                genelParametreler.DepoCalismaTipi = "";
                                genelParametreler.BarkodKalemBirlesikOku = "N";
                                genelParametreler.TarihBazliPartiOlustur = "N";
                                genelParametreler.UygulamaYetkiSifresi = "";

                                if (respGenelParametreler._list.Rows[0]["U_OndalikMiktar"] == DBNull.Value || Convert.ToInt32(respGenelParametreler._list.Rows[0]["U_OndalikMiktar"]) == 0)
                                {
                                    CustomMsgBox.Show("GENEL PARAMETRE ONDALIKLI MİKTAR GİRİŞİ YAPILMADIĞINDAN DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                                    return;
                                }

                                if (respGenelParametreler._list.Rows[0]["U_UrnSrguFiyat"] == DBNull.Value || respGenelParametreler._list.Rows[0]["U_UrnSrguFytList"] == DBNull.Value)
                                {
                                    genelParametreler.UrunSorguFiyat = "";
                                    genelParametreler.UrunSorguFiyatList = "";
                                }

                                genelParametreler.SubeSecimiYapilsin = "";
                                genelParametreler.PaletYapmadaDepoSecilsin = "";
                            }

                            //genelParametreler.DepoYeriCalisir = "N";

                            #endregion Genel Parametre verileri alınır.

                            if (Giris.genelParametreler.SubeSecimiYapilsin == "Y")
                            {
                                subeSecim.ShowDialog();
                                subeSecim.Dispose();
                                GC.Collect();
                            }
                            else
                            { 
                                menu.ShowDialog();
                                menu.Dispose();

                                #region ram temizleme
                                MemoryManagement.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1); 
                                #endregion 
                            } 
                        }
                        else
                        {
                            CustomMsgBox.Show("GİRİŞ BAŞARISIZ.", "Uyarı", "Tamam", "");
                        }
                    }
                    else
                    {
                        CustomMsgBox.Show("GİRİŞ BAŞARISIZ: " + response.Desc, "Uyarı", "Tamam", "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu : " + ex.Message);
            }
        }

        public static List<string> whsCodes = new List<string>();

        private void cmbCompany_Click(object sender, EventArgs e)
        {
            cmbCompany.DroppedDown = true;
        }

        private void btnHakkinda_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg += "Bu yazılım şununla lisanslı OTAT GIDA SAN. VE TİC. LTD. ŞTİ. (168 1451) - Canlı sistemi süre sonu 01/09/2030.";
            msg += Environment.NewLine;
            msg += Environment.NewLine;
            msg += "Yükleme Adı: AIFTEAM Depo Yönetim Sistemi";
            msg += Environment.NewLine;
            msg += "Lisans Başlangıç Tarihi: 01/09/2020";
            msg += Environment.NewLine;
            msg += "Kurulum Tarihi: 01/09/2020";
            msg += Environment.NewLine;
            msg += "Yükleme Versiyonu: 1.0.(...)";
            msg += Environment.NewLine;
            msg += "Yükleme Numarası: U1557263832";
            msg += Environment.NewLine;
            msg += "Lisans Server Versiyonu: 9.30.150";
            msg += Environment.NewLine;
            msg += "Kullanıcı Bilgileri: 20 Tekil Tam Yetkili Kullanıcı(Lokalizasyon Türkiye)";
            msg += Environment.NewLine;
            msg += Environment.NewLine;
            msg += "Dikkat şirketiniz AIFTEAM Depo Yönetim Sistemi lisansı değilse, bu yazılımı kullanma yetkiniz yoktur.";
            msg += Environment.NewLine;
            msg += Environment.NewLine;
            msg += "Bu programın veya herhangi bir bölümünün izin alınmadan çoğaltılması veya dağıtılması, ciddi hukuki ve cezai yaptırımlarla karşılaşılmasına neden olabilir ve yasaların izin verdiği azami ölçüde yasal takibata tabi olacaktır.";

            MessageBox.Show(msg);
        }

        private void cmbCompany_DropDownClosed(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void Giris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
            Environment.Exit(1);
        }

        public static DateTime GetTime()
        {
            try
            {
                using (var response =
                  WebRequest.Create("http://www.google.com").GetResponse())
                    //string todaysDates =  response.Headers["date"];
                    return DateTime.ParseExact(response.Headers["date"],
                        "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                        CultureInfo.InvariantCulture.DateTimeFormat,
                        DateTimeStyles.AssumeUniversal);
            }
            catch (WebException)
            {
                return DateTime.Now; //In case something goes wrong.
            }
        }

        public class Veri
        {
            public string val { get; set; }
            public string inf { get; set; }
        }

        public static string UrunKoduBarkod(string _deger, string _type)
        {
            string val = "";
            try
            {
                if (genelParametreler.BarkodKalemBirlesikOku == "Y")
                {
                    if (_type == "Barkod")
                    {
                        var deger = _deger.Split('-');
                        val = deger[0].ToString();
                    }

                    if (_type == "Parti")
                    {
                        var deger = _deger.Split('-');

                        if (deger.Count() > 0)
                        {
                            for (int i = 1; i < deger.Count(); i++)
                            {
                                val += deger[i] + "-";
                            }
                            val = val.Remove(val.Length - 1, 1);
                        }
                    }
                }
                else
                {
                    val = _deger;
                }
                return val;
            }
            catch (Exception ex)
            {
            }
            return val;
        }

    }
}