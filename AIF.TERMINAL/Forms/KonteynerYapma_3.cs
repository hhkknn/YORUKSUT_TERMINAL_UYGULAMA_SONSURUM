using AIF.TERMINAL.AIFTerminalService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class KonteynerYapma_3 : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public KonteynerYapma_3(List<string> _list, string _urunKodu, string _konteynerNo, DataTable _dtGirilenler, string _formName)
        {
            InitializeComponent();

            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = lblArama.Font.Size;
            lblArama.Resize += Form_Resize;

            list = _list;
            formName = _formName;

            urunKodu = _urunKodu;
            konteynerno = _konteynerNo;
            dtGirilenler = _dtGirilenler;

            if (list != null)
            {
                txtPaletNo.Text = list[0].ToString();

                if (txtPaletNo.Text != "")
                {
                    paletnoVarmiydi = true;
                }

                txtUrunKodu.Text = list[1].ToString();
                txtUrunTanim.Text = list[2].ToString();
                txtQty.Text = list[3].ToString();
                txtKonteyner.Text = list[4].ToString();
                txtSiparisNo.Text = list[5].ToString();
                txtSiparisSatirNo.Text = list[6].ToString();
                txtCekmeListesiNo.Text = list[7].ToString();
                nmrcKoliMiktari.Value = Convert.ToDecimal(list[8]);
                nmrcNetKilo.Value = Convert.ToDecimal(list[9]);
                nmrcBrutKilo.Value = Convert.ToDecimal(list[10]);

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = aIFTerminalServiceSoapClient.getCekmeListesiDetaylari(Giris._dbName, txtCekmeListesiNo.Text, Giris.mKodValue, Giris.genelParametreler.CekmeListesiKalemleriniGrupla);

                if (resp._list != null)
                {
                    var siparisKarsilamaMiktari = resp._list.AsEnumerable().Where(x => x.Field<int>("SipSatirNo") == Convert.ToInt32(txtSiparisSatirNo.Text) && x.Field<int>("SiparisNumarasi") == Convert.ToInt32(txtSiparisNo.Text)).Sum(y => y.Field<decimal>("PlanlananSiparisMiktari"));

                    var paletolmayaneklenmisler = dtGirilenler.AsEnumerable().Where(x => x.Field<string>("Palet No") == "" && x.Field<int>("CekmeListesiNo") > 0).Sum(y => y.Field<decimal>("Miktar"));

                    var final = Convert.ToInt32(siparisKarsilamaMiktari) - Convert.ToInt32(paletolmayaneklenmisler);

                    final = final + Convert.ToInt32(txtQty.Value);

                    txtGirilebilecekMaxMiktar.Text = final.ToString();

                    aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    resp = aIFTerminalServiceSoapClient.getCekmeListesi(Giris._dbName, "", "", Giris.mKodValue);

                    if (resp._list != null)
                    {
                        var aciklama = resp._list.AsEnumerable().Where(x => x.Field<int>("DocEntry") == Convert.ToInt32(txtCekmeListesiNo.Text)).Select(y => y.Field<string>("U_Aciklama")).FirstOrDefault();

                        txtCekmeListesiAciklamasi.Text = aciklama;
                    }
                }
            }
            else
            {
                txtUrunKodu.Text = urunKodu;
                if (dtGirilenler.Rows.Count > 0)
                {
                    urunKodu = dtGirilenler.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtUrunKodu.Text).Select(c => c.Field<string>("Kalem Kodu")).FirstOrDefault();

                    if (urunKodu != null && urunKodu != "")
                    {
                        txtUrunKodu.Text = urunKodu;
                    }
                }
                txtKonteyner.Text = konteynerno;
            }
        }

        private List<string> list = new List<string>();
        public static string dialogresult = "";
        public static string paletsilindi = "";
        public static double quantity = 0;
        public static int siparisNo = -1;
        public static int siparisSatirNo = -1;
        public static int cekmeNo = -1;
        public static int koliMiktari = 0;
        public static double brutKilo = 0;
        public static double netKilo = 0;
        private bool paletnoVarmiydi = false;
        private string urunKodu = "";
        private string konteynerno = "";
        private string formName = "";
        public static DataTable dtGirilenler = new DataTable();

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            lblArama.Font = new Font(lblArama.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblArama.Font.Style);

            label1.Font = new Font(lblArama.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label3.Font.Style);

            lblForm.Font = new Font(lblForm.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblForm.Font.Style);

            lblUrunKodu.Font = new Font(lblUrunKodu.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               lblUrunKodu.Font.Style);

            lblTanim.Font = new Font(lblTanim.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               lblTanim.Font.Style);

            lblKoliMik.Font = new Font(lblKoliMik.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               lblKoliMik.Font.Style);

            lblNetKilo.Font = new Font(lblNetKilo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               lblNetKilo.Font.Style);

            lblBrutKilo.Font = new Font(lblBrutKilo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               lblBrutKilo.Font.Style);

            txtUrunKodu.Font = new Font(txtUrunKodu.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUrunKodu.Font.Style);

            btnKapat.Font = new Font(btnKapat.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnKapat.Font.Style);

            txtPaletNo.Font = new Font(txtPaletNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPaletNo.Font.Style);

            txtUrunTanim.Font = new Font(txtUrunTanim.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUrunTanim.Font.Style);

            txtQty.Font = new Font(txtQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtQty.Font.Style);

            txtKonteyner.Font = new Font(txtKonteyner.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtKonteyner.Font.Style);

            txtCekmeListesiAciklamasi.Font = new Font(txtCekmeListesiAciklamasi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCekmeListesiAciklamasi.Font.Style);

            txtSiparisNo.Font = new Font(txtSiparisNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSiparisNo.Font.Style);

            txtSiparisSatirNo.Font = new Font(txtSiparisSatirNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSiparisSatirNo.Font.Style);

            btnSil.Font = new Font(btnSil.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSil.Font.Style);

            btnSec.Font = new Font(btnSec.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSec.Font.Style);

            nmrcKoliMiktari.Font = new Font(nmrcKoliMiktari.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                nmrcKoliMiktari.Font.Style);

            nmrcNetKilo.Font = new Font(nmrcNetKilo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                nmrcNetKilo.Font.Style);

            nmrcBrutKilo.Font = new Font(nmrcBrutKilo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                nmrcBrutKilo.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtKonteyner.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtUrunKodu.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtPaletNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtUrunTanim.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
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

        private void KonteynerYapma_3_Load(object sender, EventArgs e)
        {
            lblForm.Text = formName;

            txtQty.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            nmrcBrutKilo.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            nmrcKoliMiktari.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            nmrcNetKilo.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "" || txtQty.Value == 0)
            {
                CustomMsgBox.Show("Miktar girişi yapılmadan işleme devam edilemez.", "Uyarı", "Tamam", "");
                txtQty.Focus();
                return;
            }

            if (Convert.ToInt32(txtQty.Value) > Convert.ToInt32(txtGirilebilecekMaxMiktar.Text))
            {
                CustomMsgBox.Show("GİRİLEBİLECEK EN YÜKSEK MİKTARI AŞAMAZSINIZ. EN YÜKSEK MİKTAR OTOMATİK GETİRİLDİ.", "Uyarı", "Tamam", "");
                txtQty.Value = Convert.ToDecimal(txtGirilebilecekMaxMiktar.Text);
                txtQty.Focus();
                return;
            }

            dialogresult = "Ok";
            quantity = txtQty.Text == "" ? 0 : Convert.ToDouble(txtQty.Value);
            siparisNo = txtSiparisNo.Text == "" ? -1 : Convert.ToInt32(txtSiparisNo.Text);
            siparisSatirNo = txtSiparisSatirNo.Text == "" ? -1 : Convert.ToInt32(txtSiparisSatirNo.Text);
            cekmeNo = txtCekmeListesiNo.Text == "" ? -1 : Convert.ToInt32(txtCekmeListesiNo.Text);
            if (paletnoVarmiydi)
            {
                if (txtPaletNo.Text == "")
                {
                    paletsilindi = "Evet";
                }
            }

            koliMiktari = nmrcKoliMiktari.Text == "" ? 0 : Convert.ToInt32(nmrcKoliMiktari.Value);
            netKilo = nmrcNetKilo.Text == "" ? 0 : Convert.ToDouble(nmrcNetKilo.Value);
            brutKilo = nmrcBrutKilo.Text == "" ? 0 : Convert.ToDouble(nmrcBrutKilo.Value);

            Close();
        }

        private void txtQty_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtQty, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtPaletNo.Text = "";
        }

        public static string secilenUrunKodu = "";
        public static string secilenUrunTanimi = "";
        public static string secilenSiparisNumarasi = "";
        public static string secilenSiparisSatirNo = "";
        public static string secilenAciklama = "";
        public static string secilensatirKaynagi = "";
        public static int secilenKoliMiktari = 0;
        public static double secilenNetKilo = 0;
        public static double secilenBrutKilo = 0;
        public static int secilenCekiListesiNo = -1;
        public static int girilebilecekMaxMiktar = -1;

        public static string MusteriKod;

        private void btnSec_Click(object sender, EventArgs e)
        {
            try
            {
                SelectList nesne = new SelectList("ÜRÜN ARAMA", "CekmeListesiMusteriUrunuSecme", "ÜRÜN ARAMA", txtUrunKodu, null);
                nesne.ShowDialog();
                nesne.Dispose();
                GC.Collect();

                if (SelectList.dialogResult == "Ok")
                {
                    SelectList.dialogResult = "";

                    txtUrunKodu.Text = secilenUrunKodu;
                    txtUrunTanim.Text = secilenUrunTanimi;
                    txtSiparisNo.Text = secilenSiparisNumarasi;
                    txtSiparisSatirNo.Text = secilenSiparisSatirNo;
                    txtCekmeListesiAciklamasi.Text = secilenAciklama;
                    txtCekmeListesiNo.Text = secilenCekiListesiNo.ToString();
                    txtGirilebilecekMaxMiktar.Text = girilebilecekMaxMiktar.ToString();
                    txtSatirKaynagi.Text = secilensatirKaynagi.ToString();

                    KonteynerYapma_2.secilenUrunKodu = secilenUrunKodu;
                    KonteynerYapma_2.secilenUrunTanimi = secilenUrunTanimi;
                    KonteynerYapma_2.secilenSiparisNumarasi = secilenSiparisNumarasi;
                    KonteynerYapma_2.secilenSiparisSatirNo = secilenSiparisSatirNo;
                    KonteynerYapma_2.secilenAciklama = secilenAciklama;
                    KonteynerYapma_2.secilenSatirKaynagi = secilensatirKaynagi;
                    KonteynerYapma_2.secilenCekiListesiNo = secilenCekiListesiNo;
                    KonteynerYapma_2.secilenKoliMiktari = Convert.ToInt32(nmrcKoliMiktari.Value);
                    KonteynerYapma_2.secilenNetKilo = Convert.ToDouble(nmrcNetKilo.Value);
                    KonteynerYapma_2.secilenBrutKilo = Convert.ToDouble(nmrcBrutKilo.Value);
                }
            }
            catch (Exception)
            {
            }
        }

        private void nmrcKoliMiktari_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(nmrcKoliMiktari, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }

        private void nmrcNetKilo_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(nmrcNetKilo, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }

        private void nmrcBrutKilo_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(nmrcBrutKilo, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }
    }
}