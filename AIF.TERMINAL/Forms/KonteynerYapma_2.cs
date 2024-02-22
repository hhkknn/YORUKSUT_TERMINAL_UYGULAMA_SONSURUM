using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class KonteynerYapma_2 : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public KonteynerYapma_2(string _formName, string _konteynerNo)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            //initialFontSize = frmName.Font.Size;
            //frmName.Resize += Form_Resize;

            //initialFontSize = dtpStartDate.Font.Size;
            //dtpStartDate.Resize += Form_Resize;

            //initialFontSize = dtpEndDate.Font.Size;
            //dtpEndDate.Resize += Form_Resize;

            //initialFontSize = txtSearch.Font.Size;
            //txtSearch.Resize += Form_Resize;

            //initialFontSize = dtgPaletListesiDetay.Font.Size;
            //dtgPaletListesiDetay.Resize += Form_Resize;
            //end font

            formName = _formName;
            konteynerNo = _konteynerNo;
            txtKonteynerNo.Text = konteynerNo;

            KonteynerYapmaListesiDetay();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
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

            label5.Font = new Font(label5.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label5.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            dtgKonteynerListesiDetay.Font = new Font(dtgKonteynerListesiDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgKonteynerListesiDetay.Font.Style);

            btnDetay.Font = new Font(btnDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDetay.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnOnayla.Font.Style);

            btnSec.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSec.Font.Style);

            btnSatirSil.Font = new Font(btnSatirSil.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSatirSil.Font.Style);

            txtBarkod.Font = new Font(txtBarkod.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarkod.Font.Style);

            txtKonteynerNo.Font = new Font(txtKonteynerNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtKonteynerNo.Font.Style);

            txtMusteriKodu.Font = new Font(txtMusteriKodu.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtMusteriKodu.Font.Style);

            txtMusteriAdi.Font = new Font(txtMusteriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtMusteriAdi.Font.Style);

            txtPaletNo.Font = new Font(txtMusteriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtMusteriAdi.Font.Style);

            label6.Font = new Font(label6.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label6.Font.Style);

            cmbPrinter.Font = new Font(cmbPrinter.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbPrinter.Font.Style);

            btnYazdir.Font = new Font(btnYazdir.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnYazdir.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtPaletNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBarkod.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtKonteynerNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtMusteriAdi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtMusteriKodu.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbPrinter.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
        }

        //declares
        [DllImport("user32.dll")]
        private static extern bool PostMessage(
        IntPtr hWnd, // handle to destination window
        Int32 msg, // message
        Int32 wParam, // first message parameter
        Int32 lParam // second message parameter
        );

        private const Int32 WM_LBUTTONDOWN = 0x0201;

        //
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

        private string formName = "";
        private string konteynerNo = "";
        public static bool kayitYapildi = false;
        private DataTable dtKonteynerYapmaListesiDetay = new DataTable();
        private List<KonteynerIcindenSilinenler> konteynerIcindenSilinenlers = new List<KonteynerIcindenSilinenler>();

        private void PaletYapma2_Load(object sender, EventArgs e)
        {
        }

        private void KonteynerYapmaListesiDetay()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.getKonteynerYapmaListesiDetaylari(Giris._dbName, konteynerNo, Giris.mKodValue);

            if (resp._list != null)
            {
                dtKonteynerYapmaListesiDetay = resp._list;

                dtgKonteynerListesiDetay.DataSource = null;

                dtgKonteynerListesiDetay.DataSource = dtKonteynerYapmaListesiDetay;

                dtgKonteynerListesiDetay.RowTemplate.Height = 55;
                dtgKonteynerListesiDetay.ColumnHeadersHeight = 60;

                dtgKonteynerListesiDetay.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                dtKonteynerYapmaListesiDetay.Columns.Add("dtgSira", typeof(int));

                for (int i = 0; i <= dtgKonteynerListesiDetay.Rows.Count - 1; i++)
                {
                    dtgKonteynerListesiDetay.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                }
                dtgKonteynerListesiDetay.Columns["dtgSira"].Visible = false;

                vScrollBar1.Maximum = dtgKonteynerListesiDetay.RowCount + 5;

                dtgKonteynerListesiDetay.Columns["SiparisNumarasi"].Visible = false;
                dtgKonteynerListesiDetay.Columns["SiparisSatirNo"].Visible = false;
                dtgKonteynerListesiDetay.Columns["UrunKonteynereDahaOnceEklendi"].Visible = false;
                dtgKonteynerListesiDetay.Columns["CekmeListesiNo"].Visible = false;
                dtgKonteynerListesiDetay.Columns["koliMiktari"].Visible = false;
                dtgKonteynerListesiDetay.Columns["netKilo"].Visible = false;
                dtgKonteynerListesiDetay.Columns["brutKilo"].Visible = false;
                //dtgKonteynerListesiDetay.Columns["Kaynak"].Visible = false;

                dtgKonteynerListesiDetay.Columns["Kalem Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                dtgKonteynerListesiDetay.DataSource = null;
            }
        }

        private bool doubleclick = false;

        private void btnDetay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMusteriAdi.Text == "")
                {
                    CustomMsgBox.Show("Muhatap seçimi yapılmadan işleme devam edilemez.", "Uyarı", "Tamam", "");
                    return;
                }

                if (txtBarkod.Text == "")
                {
                    CustomMsgBox.Show("Barkod girilmeden işleme devam edilemez.", "Uyarı", "Tamam", "");
                    txtBarkod.Focus();
                    return;
                }

                //if (txtPaletNo.Text == "")
                //{
                //    CustomMsgBox.Show("Palet Numarası girilmeden işleme devam edilemez.", "Uyarı", "Tamam", "");
                //    txtPaletNo.Focus();
                //    return;
                //}
                //if (dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text).Count() == 0 && dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text).Count() == 0 && dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Kalem Kodu") == txtBarkod.Text).Count() == 0)
                //{
                //    #region Esk işlem
                //    //bool urunBulundu = false;
                //    //AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                //    //Response resp = new Response();

                //    //if (txtBarkod.Text != "TANIMSIZ")
                //    //{
                //    //    resp = aIFTerminalServiceSoapClient.GetProductByBarCode(Giris._dbName, txtBarkod.Text, Giris.mKodValue);
                //    //}

                //    //if (resp._list == null)
                //    //{
                //    //    resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, txtBarkod.Text, "", "", Giris.mKodValue);
                //    //}
                //    //else
                //    //{
                //    //    urunBulundu = true;
                //    //}

                //    //if (resp._list == null)
                //    //{
                //    //    resp = aIFTerminalServiceSoapClient.GetProductByItemCode(Giris._dbName, txtBarkod.Text, Giris.mKodValue);
                //    //}

                //    //if (resp._list != null)
                //    //{
                //    //    urunBulundu = true;
                //    //}

                //    //if (urunBulundu)
                //    //{
                //    //    DataRow dr = dtKonteynerYapmaListesiDetay.NewRow();
                //    //    dr["Konteyner No"] = txtKonteynerNo.Text;
                //    //    dr["Palet No"] = txtPaletNo.Text;
                //    //    dr["Kalem Kodu"] = resp._list.Rows[0]["Kalem Kodu"].ToString();
                //    //    dr["Kalem Tanimi"] = resp._list.Rows[0]["Kalem Tanımı"].ToString();
                //    //    dr["Miktar"] = "0";

                //    //    resp = aIFTerminalServiceSoapClient.getKalemKoduMuhatapKatalogNoBarkod(Giris._dbName, resp._list.Rows[0]["Kalem Kodu"].ToString(), "", Giris.mKodValue);

                //    //    if (resp._list != null)
                //    //    {
                //    //        dr["MuhatapKatalogNo"] = resp._list.Rows[0]["MuhatapKatalogNo"].ToString();
                //    //        dr["Barkod"] = resp._list.Rows[0]["Barkod"].ToString();
                //    //    }

                //    //    dtKonteynerYapmaListesiDetay.Rows.Add(dr);

                //    //    dtgKonteynerListesiDetay.DataSource = dtKonteynerYapmaListesiDetay;

                //    //    for (int i = 0; i <= dtgKonteynerListesiDetay.Rows.Count - 1; i++)
                //    //    {
                //    //        dtgKonteynerListesiDetay.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                //    //    }

                //    //    currentRow = dtgKonteynerListesiDetay.Rows.Count - 1;
                //    //    kalemKodu = dtKonteynerYapmaListesiDetay.Rows[dtKonteynerYapmaListesiDetay.Rows.Count - 1]["Kalem Kodu"].ToString();
                //    //    kalemTanimi = dtKonteynerYapmaListesiDetay.Rows[dtKonteynerYapmaListesiDetay.Rows.Count - 1]["Kalem Tanimi"].ToString();
                //    //    miktar = dtgKonteynerListesiDetay.Rows[dtKonteynerYapmaListesiDetay.Rows.Count - 1].Cells["Miktar"].Value == DBNull.Value || dtgKonteynerListesiDetay.Rows[dtKonteynerYapmaListesiDetay.Rows.Count - 1].Cells["Miktar"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgKonteynerListesiDetay.Rows[dtKonteynerYapmaListesiDetay.Rows.Count - 1].Cells["Miktar"].Value);

                //    //    List<string> s = new List<string>();
                //    //    s.Add(paletNo);
                //    //    s.Add(kalemKodu);
                //    //    s.Add(kalemTanimi);
                //    //    s.Add(miktar.ToString());
                //    //    s.Add(txtKonteynerNo.Text.ToString());

                //    //    KonteynerYapma_3 konteynerYapma_3 = new KonteynerYapma_3("KONTEYNER LİSTESİ MİKTAR", s);
                //    //    konteynerYapma_3.ShowDialog();

                //    //    if (KonteynerYapma_3.dialogresult == "Ok")
                //    //    {
                //    //        if (KonteynerYapma_3.paletsilindi == "")
                //    //        {
                //    //            dtKonteynerYapmaListesiDetay.Rows[currentRow]["Miktar"] = KonteynerYapma_3.quantity;
                //    //        }
                //    //        else
                //    //        {
                //    //            var query = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text);

                //    //            if (query.ToList().Count > 0)
                //    //            {
                //    //                foreach (var row in query.ToList())
                //    //                {
                //    //                    row.SetField("Miktar", row.Field<double>("Miktar") + KonteynerYapma_3.quantity);
                //    //                }
                //    //            }
                //    //            else
                //    //            {
                //    //                query = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text);

                //    //                if (query.ToList().Count > 0)
                //    //                {
                //    //                    foreach (var row in query.ToList())
                //    //                    {
                //    //                        row.SetField("Miktar", row.Field<double>("Miktar") + KonteynerYapma_3.quantity);
                //    //                    }
                //    //                }
                //    //                else
                //    //                {
                //    //                    query = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text);

                //    //                    if (query.ToList().Count > 0)
                //    //                    {
                //    //                        foreach (var row in query.ToList())
                //    //                        {
                //    //                            row.SetField("Miktar", row.Field<double>("Miktar") + KonteynerYapma_3.quantity);
                //    //                        }
                //    //                    }
                //    //                }

                //    //            }

                //    //            dtKonteynerYapmaListesiDetay.AcceptChanges();
                //    //        }

                //    //        KonteynerYapma_3.dialogresult = "";

                //    //    }
                //    //    if (KonteynerYapma_3.quantity == 0)
                //    //    {
                //    //        dtKonteynerYapmaListesiDetay.Rows.RemoveAt(currentRow);

                //    //    }

                //    //    dtgKonteynerListesiDetay.Rows[currentRow].Selected = false;

                //    //    KonteynerYapma_3.quantity = 0;
                //    //    kalemKodu = "";
                //    //    kalemTanimi = "";
                //    //    miktar = 0;
                //    //}
                //    #endregion
                //}
                //else
                //{
                if (!doubleclick)
                {
                    KonteynerYapma_3 konteynerYapma_3 = new KonteynerYapma_3(null, txtBarkod.Text, txtKonteynerNo.Text, dtKonteynerYapmaListesiDetay, "ÜRÜN MİKTAR GİRİŞİ");
                    konteynerYapma_3.ShowDialog();
                    konteynerYapma_3.Dispose();
                    GC.Collect();

                    if (KonteynerYapma_3.dialogresult == "Ok")
                    {
                        if (KonteynerYapma_3.paletsilindi == "")
                        {
                            //dtKonteynerYapmaListesiDetay.Rows[currentRow]["Miktar"] = KonteynerYapma_3.quantity;

                            DataRow dr = dtKonteynerYapmaListesiDetay.NewRow();
                            dr["Konteyner No"] = txtKonteynerNo.Text;
                            dr["Palet No"] = "";
                            dr["Kalem Kodu"] = secilenUrunKodu;
                            dr["Kalem Tanimi"] = secilenUrunTanimi;
                            dr["Miktar"] = KonteynerYapma_3.quantity;
                            dr["SiparisNumarasi"] = secilenSiparisNumarasi;
                            dr["SiparisSatirNo"] = secilenSiparisSatirNo;
                            dr["dtgSira"] = dtgKonteynerListesiDetay.RowCount;
                            dr["CekmeListesiNo"] = secilenCekiListesiNo;
                            dr["koliMiktari"] = KonteynerYapma_3.koliMiktari;
                            dr["netKilo"] = KonteynerYapma_3.netKilo;
                            dr["brutKilo"] = KonteynerYapma_3.brutKilo;
                            dr["Kaynak"] = KonteynerYapma_3.secilensatirKaynagi;

                            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                            Response resp = new Response();

                            resp = aIFTerminalServiceSoapClient.getKalemKoduMuhatapKatalogNoBarkod(Giris._dbName, secilenUrunKodu, txtMusteriKodu.Text, Giris.mKodValue);

                            if (resp._list != null)
                            {
                                dr["MuhatapKatalogNo"] = resp._list.Rows[0]["MuhatapKatalogNo"].ToString();
                                dr["Barkod"] = resp._list.Rows[0]["Barkod"].ToString();
                            }

                            dtKonteynerYapmaListesiDetay.Rows.Add(dr);

                            vScrollBar1.Maximum = dtgKonteynerListesiDetay.RowCount;
                        }
                        else
                        {
                        }

                        KonteynerYapma_3.dialogresult = "";
                    }
                    else
                    {
                        //KonteynerYapma_3 konteynerYapma_3 = new KonteynerYapma_3(s, "");
                        //konteynerYapma_3.ShowDialog();

                        //if (KonteynerYapma_3.dialogresult == "Ok")
                        //{
                        //    if (KonteynerYapma_3.paletsilindi == "")
                        //    {
                        //        dtKonteynerYapmaListesiDetay.Rows[currentRow]["Miktar"] = KonteynerYapma_3.quantity;
                        //    }
                        //    else
                        //    {
                        //        var query = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text && x.Field<string>("Palet No") == "");

                        //        if (query.ToList().Count > 0)
                        //        {
                        //            foreach (var row in query.ToList())
                        //            {
                        //                row.SetField("Miktar", row.Field<decimal>("Miktar") + Convert.ToDecimal(KonteynerYapma_3.quantity));
                        //            }
                        //        }
                        //        else
                        //        {
                        //            query = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text && x.Field<string>("Palet No") == "");

                        //            if (query.ToList().Count > 0)
                        //            {
                        //                foreach (var row in query.ToList())
                        //                {
                        //                    row.SetField("Miktar", row.Field<decimal>("Miktar") + Convert.ToDecimal(KonteynerYapma_3.quantity));
                        //                }
                        //            }
                        //            else
                        //            {
                        //                query = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text && x.Field<string>("Palet No") == "");

                        //                if (query.ToList().Count > 0)
                        //                {
                        //                    foreach (var row in query.ToList())
                        //                    {
                        //                        row.SetField("Miktar", row.Field<decimal>("Miktar") + Convert.ToDecimal(KonteynerYapma_3.quantity));
                        //                    }
                        //                }
                        //                else
                        //                {
                        //                    bool urunBulundu = false;
                        //                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                        //                    Response resp = new Response();

                        //                    if (txtBarkod.Text != "TANIMSIZ")
                        //                    {
                        //                        resp = aIFTerminalServiceSoapClient.GetProductByBarCode(Giris._dbName, txtBarkod.Text, Giris.mKodValue);
                        //                    }

                        //                    if (resp._list == null)
                        //                    {
                        //                        resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, txtBarkod.Text, "", "", Giris.mKodValue);
                        //                    }
                        //                    else
                        //                    {
                        //                        urunBulundu = true;
                        //                    }

                        //                    if (resp._list == null)
                        //                    {
                        //                        resp = aIFTerminalServiceSoapClient.GetProductByItemCode(Giris._dbName, txtBarkod.Text, Giris.mKodValue);
                        //                    }

                        //                    if (resp._list != null)
                        //                    {
                        //                        DataRow dr = dtKonteynerYapmaListesiDetay.NewRow();
                        //                        dr["Konteyner No"] = txtKonteynerNo.Text;
                        //                        dr["Palet No"] = "";
                        //                        dr["Kalem Kodu"] = resp._list.Rows[0]["Kalem Kodu"].ToString();
                        //                        dr["Kalem Tanimi"] = resp._list.Rows[0]["Kalem Tanımı"].ToString();
                        //                        dr["Miktar"] = KonteynerYapma_3.quantity;

                        //                        resp = aIFTerminalServiceSoapClient.getKalemKoduMuhatapKatalogNoBarkod(Giris._dbName, resp._list.Rows[0]["Kalem Kodu"].ToString(), "", Giris.mKodValue);

                        //                        if (resp._list != null)
                        //                        {
                        //                            dr["MuhatapKatalogNo"] = resp._list.Rows[0]["MuhatapKatalogNo"].ToString();
                        //                            dr["Barkod"] = resp._list.Rows[0]["Barkod"].ToString();
                        //                        }

                        //                        dtKonteynerYapmaListesiDetay.Rows.Add(dr);
                        //                    }

                        //                    for (int i = 0; i <= dtgKonteynerListesiDetay.Rows.Count - 1; i++)
                        //                    {
                        //                        dtgKonteynerListesiDetay.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                        //                    }

                        //                }
                        //            }

                        //        }

                        //        dtKonteynerYapmaListesiDetay.AcceptChanges();
                        //    }

                        //    KonteynerYapma_3.dialogresult = "";
                        //    KonteynerYapma_3.paletsilindi = "";
                        //    if (KonteynerYapma_3.quantity == 0)
                        //    {
                        //        dtKonteynerYapmaListesiDetay.Rows.RemoveAt(currentRow);
                        //    }
                        //    KonteynerYapma_3.quantity = 0;

                        //}
                    }

                    dtgKonteynerListesiDetay.Rows[currentRow].Selected = false;
                }
                else
                {
                    //int sira = -1;
                    //if (dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text).Count() > 0)
                    //{
                    //    sira = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text).Select(c => c.Field<int>("dtgSira")).FirstOrDefault();
                    //    var arg = new DataGridViewCellEventArgs(dtKonteynerYapmaListesiDetay.Rows.Count, sira);
                    //    dtgKonteynerListesiDetay_CellClick(dtgKonteynerListesiDetay, arg);
                    //}
                    //else if (dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text).Count() > 0)
                    //{
                    //    sira = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text).Select(c => c.Field<int>("dtgSira")).FirstOrDefault();
                    //    var arg = new DataGridViewCellEventArgs(dtKonteynerYapmaListesiDetay.Rows.Count, sira);
                    //    dtgKonteynerListesiDetay_CellClick(dtgKonteynerListesiDetay, arg);
                    //}
                    //else if (dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == txtBarkod.Text).Count() > 0)
                    //{
                    //    sira = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == txtBarkod.Text).Select(c => c.Field<int>("dtgSira")).FirstOrDefault();
                    //    var arg = new DataGridViewCellEventArgs(dtgKonteynerListesiDetay.Rows.Count, sira);
                    //    dtgKonteynerListesiDetay_CellClick(dtgKonteynerListesiDetay, arg);
                    //}

                    //if (sira == -1)
                    //{
                    //    return;
                    //}
                    //}

                    List<string> s = new List<string>();
                    s.Add(paletNo);
                    s.Add(kalemKodu);
                    s.Add(kalemTanimi);
                    s.Add(miktar.ToString());
                    s.Add(konteynerNo.ToString());
                    s.Add(siparisNumarasi.ToString());
                    s.Add(siparisSatirNo.ToString());
                    s.Add(cekmeListesiNo.ToString());
                    s.Add(koliMiktari.ToString());
                    s.Add(netKilo.ToString());
                    s.Add(brutKilo.ToString());
                    s.Add(satirKaynagi.ToString());

                    KonteynerYapma_3 konteynerYapma = new KonteynerYapma_3(s, "", "", dtKonteynerYapmaListesiDetay, "ÜRÜN MİKTAR GİRİŞİ");
                    konteynerYapma.ShowDialog();
                    konteynerYapma.Dispose();
                    GC.Collect();

                    if (KonteynerYapma_3.dialogresult == "Ok")
                    {
                        dtKonteynerYapmaListesiDetay.Rows[currentRow]["Miktar"] = KonteynerYapma_3.quantity;
                        dtKonteynerYapmaListesiDetay.Rows[currentRow]["koliMiktari"] = KonteynerYapma_3.koliMiktari;
                        dtKonteynerYapmaListesiDetay.Rows[currentRow]["netKilo"] = KonteynerYapma_3.netKilo;
                        dtKonteynerYapmaListesiDetay.Rows[currentRow]["brutKilo"] = KonteynerYapma_3.brutKilo;
                        dtKonteynerYapmaListesiDetay.Rows[currentRow]["Kaynak"] = KonteynerYapma_3.secilensatirKaynagi;
                        KonteynerYapma_3.dialogresult = "";
                    }
                }
                txtBarkod.Text = "";
                txtPaletNo.Text = "";
                doubleclick = false;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSatirSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgKonteynerListesiDetay.DataSource == null)
                {
                    return;
                }
                if (currentRow > -1)
                {
                    if (dtgKonteynerListesiDetay.CurrentCell != null)
                    {
                        DialogResult resp = CustomMsgBtn.Show("SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ?", "Uyarı", "EVET", "HAYIR");

                        if (CustomMsgBtn.result == DialogResult.Yes)
                        {
                            string dtgSira = dtgKonteynerListesiDetay.Rows[currentRow].Cells["dtgSira"].Value.ToString();

                            bool rowsilindi = false;
                            //var siparisNo = dtgKonteynerListesiDetay.Rows[currentRow].Cells["SiparisNumarasi"].Value.ToString()
                            if (dtgSira != "")
                            {
                                var query = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<int>("dtgSira") == Convert.ToInt32(dtgSira));

                                foreach (var row in query.ToList())
                                {
                                    konteynerIcindenSilinenlers.Add(new KonteynerIcindenSilinenler
                                    {
                                        cekmeNo = dtgKonteynerListesiDetay.Rows[currentRow].Cells["CekmeListesiNo"].Value == DBNull.Value ? -1 : Convert.ToInt32(dtgKonteynerListesiDetay.Rows[currentRow].Cells["CekmeListesiNo"].Value),
                                        siparisNo = dtgKonteynerListesiDetay.Rows[currentRow].Cells["SiparisNumarasi"].Value == DBNull.Value ? -1 : Convert.ToInt32(dtgKonteynerListesiDetay.Rows[currentRow].Cells["SiparisNumarasi"].Value),
                                        siparisSatirNo = dtgKonteynerListesiDetay.Rows[currentRow].Cells["SiparisSatirNo"].Value == DBNull.Value ? -1 : Convert.ToInt32(dtgKonteynerListesiDetay.Rows[currentRow].Cells["SiparisSatirNo"].Value),
                                        miktar = dtgKonteynerListesiDetay.Rows[currentRow].Cells["Miktar"].Value == DBNull.Value ? -1 : Convert.ToInt32(dtgKonteynerListesiDetay.Rows[currentRow].Cells["Miktar"].Value),
                                        kaynak = dtgKonteynerListesiDetay.Rows[currentRow].Cells["Kaynak"].Value == DBNull.Value ? "" : dtgKonteynerListesiDetay.Rows[currentRow].Cells["Kaynak"].Value.ToString(),
                                        paletNo = dtgKonteynerListesiDetay.Rows[currentRow].Cells["Palet No"].Value == DBNull.Value ? "" : dtgKonteynerListesiDetay.Rows[currentRow].Cells["Palet No"].Value.ToString(),
                                    });
                                    row.Delete();
                                    rowsilindi = true;
                                }

                                dtKonteynerYapmaListesiDetay.AcceptChanges();
                            }

                            //dtgPaletListesiDetay.Rows.RemoveAt(currentRow);
                            //dtgPaletListesiDetay.Refresh();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static string secilenUrunKodu = "";
        public static string secilenUrunTanimi = "";
        public static string secilenSiparisNumarasi = "";
        public static string secilenSiparisSatirNo = "";
        public static string secilenAciklama = "";
        public static string secilenSatirKaynagi = "";
        public static int secilenCekiListesiNo = -1;
        public static int secilenKoliMiktari = 0;
        public static double secilenNetKilo = 0;
        public static double secilenBrutKilo = 0;
        public static int currentRow;
        private string barcode = "";
        private string muhatapkatalogno = "";
        private string kalemKodu = "";
        private string kalemTanimi = "";
        private string paletNo = "";
        private string siparisNumarasi = "";
        private string satirKaynagi = "";
        private string siparisSatirNo = "";
        private int cekmeListesiNo = 0;
        private int koliMiktari = 0;
        private double netKilo = 0;
        private double brutKilo = 0;
        private double miktar = 0;

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtMusteriKodu.Text == "")
                    {
                        txtBarkod.Text = "";
                        txtBarkod.Focus();
                        CustomMsgBox.Show("MUHATAP SEÇİMİ YAPILMADAN ÜRÜN EKLENEMEZ.", "Uyarı", "Tamam", "");
                        return;
                    }

                    //AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                    //Response resp = null;

                    //resp = aIFTerminalServiceSoapClient.getCekmeListesiMusteriyeGoreUrunListesi(Giris._dbName, txtBarkod.Text, Giris.mKodValue);

                    //if (resp._list != null)
                    //{
                    //}
                    //txtBarkod.Focus();

                    //if (txtBarkod.Text != "")
                    //{
                    //    bool urunbulundu = false;
                    //    var exits = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text).ToList();

                    //    if (exits.Count > 0)
                    //    {
                    //        var dtgSira = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                    //        var arg = new DataGridViewCellEventArgs(dtKonteynerYapmaListesiDetay.Rows.Count, dtgSira);
                    //        dtgKonteynerListesiDetay_CellClick(dtgKonteynerListesiDetay, arg);

                    //        dtgKonteynerListesiDetay.ClearSelection();

                    //        dtgKonteynerListesiDetay.Rows[dtgSira].Cells[0].Selected = true;

                    //        urunbulundu = true;
                    //    }

                    //    if (!urunbulundu)
                    //    {
                    //        exits = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text).ToList();
                    //        if (exits.Count > 0)
                    //        {
                    //            var dtgSira = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                    //            var arg = new DataGridViewCellEventArgs(dtKonteynerYapmaListesiDetay.Rows.Count, dtgSira);
                    //            dtgKonteynerListesiDetay_CellClick(dtgKonteynerListesiDetay, arg);

                    //            dtgKonteynerListesiDetay.ClearSelection();

                    //            dtgKonteynerListesiDetay.Rows[dtgSira].Cells[0].Selected = true;

                    //            urunbulundu = true;
                    //        }
                    //    }

                    //    if (!urunbulundu)
                    //    {
                    //        exits = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Kalem Kodu") == txtBarkod.Text).ToList();
                    //        if (exits.Count > 0)
                    //        {
                    //            var dtgSira = dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Kalem Kodu") == txtBarkod.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                    //            var arg = new DataGridViewCellEventArgs(dtKonteynerYapmaListesiDetay.Rows.Count, dtgSira);
                    //            dtgKonteynerListesiDetay_CellClick(dtgKonteynerListesiDetay, arg);

                    //            dtgKonteynerListesiDetay.ClearSelection();

                    //            dtgKonteynerListesiDetay.Rows[dtgSira].Cells[0].Selected = true;

                    //            urunbulundu = true;
                    //        }
                    //    }
                    btnDetay.PerformClick();

                    //dr["Kalem Kodu"]

                    //    txtBarkod.Text = "";
                    //    txtPaletNo.Text = "";
                    //}
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgPaletListesiDetay_DoubleClick(object sender, EventArgs e)
        {
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgKonteynerListesiDetay.Rows.Count == 0)
                {
                    //ne uyarısı yazılabilir buraya?
                    CustomMsgBox.Show("ÜRÜN OLMADAN PALET OLUŞTURULAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }

                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                    return;
                }

                KonteynerYapma konteynerYapma = new KonteynerYapma();
                KonteynerYapmaDetay konteynerYapmaDetay = new KonteynerYapmaDetay();
                List<KonteynerYapmaDetay> konteynerYapmaDetays = new List<KonteynerYapmaDetay>();
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                int i = 1;
                konteynerYapma.KonteynerNumarasi = txtKonteynerNo.Text;

                foreach (DataRow items in dtKonteynerYapmaListesiDetay.Rows)
                {
                    if (items["Miktar"].ToString() == "0" || items["Miktar"].ToString() == "")
                    {
                        continue;
                    }

                    konteynerYapmaDetays.Add(new KonteynerYapmaDetay
                    {
                        PaletNo = items["Palet No"].ToString(),
                        Barkod = items["Barkod"].ToString(),
                        MuhatapKatalogNo = items["MuhatapKatalogNo"].ToString(),
                        KalemKodu = items["Kalem Kodu"].ToString(),
                        KalemTanimi = items["Kalem Tanimi"].ToString(),
                        Quantity = Math.Round(Convert.ToDouble(items["Miktar"]), Giris.genelParametreler.OndalikMiktar),
                        siparisNo = items["SiparisNumarasi"] == DBNull.Value ? -1 : Convert.ToInt32(items["SiparisNumarasi"]),
                        siparisSatirNo = items["SiparisSatirNo"] == DBNull.Value ? -1 : Convert.ToInt32(items["SiparisSatirNo"]),
                        UrunKonteynereDahaOnceEklendi = items["UrunKonteynereDahaOnceEklendi"].ToString(),
                        CekmeListesiNo = items["CekmeListesiNo"].ToString(),
                        koliMiktari = items["KoliMiktari"] == DBNull.Value || items["KoliMiktari"].ToString() == "" ? 0 : Convert.ToInt32(items["KoliMiktari"]),
                        netKilo = items["NetKilo"] == DBNull.Value || items["NetKilo"].ToString() == "" ? 0 : Convert.ToDouble(items["NetKilo"]),
                        brutKilo = items["BrutKilo"] == DBNull.Value || items["BrutKilo"].ToString() == "" ? 0 : Convert.ToDouble(items["BrutKilo"]),
                        satirKaynagi = items["Kaynak"] == DBNull.Value || items["Kaynak"].ToString() == "" ? "" : items["Kaynak"].ToString(),
                    });

                    konteynerYapma.konteynerYapmaDetays = konteynerYapmaDetays.ToArray();
                    i++;
                }

                //var resp1 = aIFTerminalServiceSoapClient1.addOrUpdateKonteynerYapmaListesi(Giris._dbName, konteynerYapma, konteynerIcindenSilinenlers.ToArray(), Giris.genelParametreler.CekmeListesiKalemleriniGrupla);
                var resp1 = aIFTerminalServiceSoapClient1.addOrUpdateKonteynerYapmaListesi_Final(Giris._dbName, konteynerYapma, konteynerIcindenSilinenlers.ToArray(), Giris.genelParametreler.CekmeListesiKalemleriniGrupla);

                if (resp1.Val == 0)
                {
                    kayitYapildi = true;
                    Close();
                }
                else
                {
                    CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void dtgKonteynerListesiDetay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                barcode = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["Barkod"].Value.ToString();
                muhatapkatalogno = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["MuhatapKatalogNo"].Value.ToString();
                kalemKodu = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["Kalem Kodu"].Value.ToString();
                kalemTanimi = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["Kalem Tanimi"].Value.ToString();
                miktar = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["Miktar"].Value == DBNull.Value || dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["Miktar"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["Miktar"].Value);
                paletNo = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["Palet No"].Value == DBNull.Value || dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["Palet No"].Value.ToString() == "" ? "" : dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["Palet No"].Value.ToString();

                if (barcode != "")
                {
                    txtBarkod.Text = barcode;
                }
                else if (muhatapkatalogno != "")
                {
                    txtBarkod.Text = muhatapkatalogno;
                }
                else if (kalemKodu != "")
                {
                    txtBarkod.Text = kalemKodu;
                }

                txtPaletNo.Text = paletNo;
                siparisNumarasi = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["SiparisNumarasi"].Value.ToString();
                siparisSatirNo = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["SiparisSatirNo"].Value.ToString();
                cekmeListesiNo = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["CekmeListesiNo"].Value == DBNull.Value || dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["CekmeListesiNo"].Value.ToString() == "" ? 0 : Convert.ToInt32(dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["CekmeListesiNo"].Value);

                koliMiktari = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["koliMiktari"].Value == DBNull.Value || dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["koliMiktari"].Value.ToString() == "" ? 0 : Convert.ToInt32(dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["koliMiktari"].Value);
                netKilo = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["netKilo"].Value == DBNull.Value || dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["netKilo"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["netKilo"].Value);
                brutKilo = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["brutKilo"].Value == DBNull.Value || dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["brutKilo"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["brutKilo"].Value);
                currentRow = e.RowIndex;
                satirKaynagi = dtgKonteynerListesiDetay.Rows[e.RowIndex].Cells["Kaynak"].Value.ToString();
            }
        }

        private void dtgKonteynerListesiDetay_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
            btnDetay.PerformClick();
            doubleclick = false;
        }

        private void KonteynerYapma_2_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            vScrollBar1.Maximum = dtgKonteynerListesiDetay.RowCount;
            listAllPrinters();
        }

        private void txtPaletNo_DoubleClick(object sender, EventArgs e)
        {
            SelectList nesne = new SelectList("PaletSorgulama", "PaletNoArama", "Palet ARAMA", txtPaletNo, null);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (SelectList.dialogResult == "Ok")
            {
                SelectList.dialogResult = "";
            }
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPaletNo.Focus();

                string paletNo = txtPaletNo.Text;

                if (txtMusteriKodu.Text == "")
                {
                    CustomMsgBox.Show("MÜŞTERİ SEÇİMİ YAPILMADAN PALET EKLENEMEZ.", "Uyarı", "Tamam", "");
                    txtPaletNo.Text = "";
                    return;
                }

                if (dtKonteynerYapmaListesiDetay.AsEnumerable().Where(x => x.Field<string>("Palet No") == paletNo).Count() > 0)
                {
                    CustomMsgBox.Show("DAHA ÖNCE EKLENMİŞ PALET TEKRAR EKLENEMEZ.", "Uyarı", "Tamam", "");
                    txtPaletNo.Text = "";
                    return;
                }

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = null;
                Response resp1 = null;

                resp = aIFTerminalServiceSoapClient.getPaletYapmaListesiDetaylari(Giris._dbName, paletNo, Giris.mKodValue, Giris.genelParametreler.CekmeListesiKalemleriniGrupla);

                if (resp._list != null)
                {
                    if (resp._list.Rows.Count == 0)
                    {
                        CustomMsgBox.Show("PALET DETAYI BULUNAMADI.", "Uyarı", "Tamam", "");
                        txtPaletNo.Text = "";
                        return;
                    }

                    for (int i = 0; i <= resp._list.Rows.Count - 1; i++)
                    {
                        DataRow dr = dtKonteynerYapmaListesiDetay.NewRow();
                        dr["Konteyner No"] = txtKonteynerNo.Text;
                        dr["Palet No"] = txtPaletNo.Text;
                        dr["Kalem Kodu"] = resp._list.Rows[i]["Kalem Kodu"].ToString();
                        dr["Kalem Tanimi"] = resp._list.Rows[i]["Kalem Tanimi"].ToString();
                        dr["Miktar"] = resp._list.Rows[i]["Miktar"].ToString();
                        if (resp._list.Rows[i]["SiparisNumarasi"] != DBNull.Value)
                        {
                            dr["SiparisNumarasi"] = Convert.ToInt32(resp._list.Rows[i]["SiparisNumarasi"]);
                        }

                        if (resp._list.Rows[i]["SiparisSatirNo"] != DBNull.Value)
                        {
                            dr["SiparisSatirNo"] = Convert.ToInt32(resp._list.Rows[i]["SiparisSatirNo"]);
                        }

                        if (resp._list.Rows[i]["CekmeNo"] != DBNull.Value)
                        {
                            dr["CekmeListesiNo"] = Convert.ToInt32(resp._list.Rows[i]["CekmeNo"]);
                        }

                        if (resp._list.Rows[i]["Kaynak"] != DBNull.Value)
                        {
                            dr["Kaynak"] = resp._list.Rows[i]["Kaynak"].ToString();
                        }

                        resp1 = aIFTerminalServiceSoapClient.getKalemKoduMuhatapKatalogNoBarkod(Giris._dbName, resp._list.Rows[i]["Kalem Kodu"].ToString(), txtMusteriKodu.Text, Giris.mKodValue);

                        if (resp1._list != null && resp1._list.Rows.Count > 0)
                        {
                            dr["MuhatapKatalogNo"] = resp1._list.Rows[0]["MuhatapKatalogNo"].ToString();
                            dr["Barkod"] = resp1._list.Rows[0]["Barkod"].ToString();
                        }

                        dr["UrunKonteynereDahaOnceEklendi"] = "Y";

                        dtKonteynerYapmaListesiDetay.Rows.Add(dr);
                    }

                    dtgKonteynerListesiDetay.DataSource = dtKonteynerYapmaListesiDetay;

                    for (int i = 0; i <= dtgKonteynerListesiDetay.Rows.Count - 1; i++)
                    {
                        dtgKonteynerListesiDetay.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                    }
                }

                txtPaletNo.Text = "";
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            SelectList nesne = new SelectList("CEKMELISTESIMUSTERIGETIRME", "CekmeListesiMusteriGetirme", "ÇEKME LİSTESİ MÜŞTERİ ARAMA", txtMusteriAdi, txtMusteriKodu);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (SelectList.dialogResult == "Ok")
            {
                SelectList.dialogResult = "";
            }
            KonteynerYapma_3.MusteriKod = txtMusteriKodu.Text;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                vScrollBar1.Value = e.NewValue;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("hata" + ex.Message);
            }
        }

        private void dtgKonteynerListesiDetay_Scroll(object sender, ScrollEventArgs e)
        {
            //vscrollbar koyulmadan kaydırma sorunu yaşanıyor.visible false yapıldığında da kaydırma işleminde sorun olduğundan 0.1 genişliğinde çalışır duruma getirildi.
            try
            {
                dtgKonteynerListesiDetay.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void listAllPrinters()
        {
            cmbPrinter.Items.Clear();
            cmbPrinter.Items.Add("");

            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                cmbPrinter.Items.Add(item);
            }
            //default
            PrintDocument printDocument = new PrintDocument();
            string defaultPrinter = printDocument.PrinterSettings.PrinterName;
            cmbPrinter.SelectedItem = defaultPrinter;
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            PackingListPrint();
        }

        private void PackingListPrint()
        {
            #region Crystal reports işlemlerinin yapıldığı yer

            try
            {
                string path = "";

                if (Giris._dbName == "ZTEST2")
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + "Packinglist_Canli.rpt";
                }
                else if (Giris._dbName == "ANATOLYA_DB")
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + "Packinglist_Canli.rpt";
                }

                ReportDocument cryRpt = new ReportDocument();

                cryRpt.Load(path);

                string server = @"ANATOLYA-SAP\SAPB1";

                cryRpt.SetDatabaseLogon("sa", "Eropa2018!", server, Giris._dbName);

                cryRpt.VerifyDatabase();

                //if (txtPaletNo.Text == "")
                //{
                //    MessageBox.Show("Lütfen satır seçimi yapınız.");
                //    return;
                //}
                cryRpt.SetParameterValue(0, txtPaletNo.Text);
                cryRpt.SetParameterValue(1, txtKonteynerNo.Text);

                cryRpt.PrintOptions.PrinterName = cmbPrinter.Text;

                //cryRpt.PrintToPrinter(txtPrintMik.Text == "" ? 1 : Convert.ToInt32(txtPrintMik.Text), false, 0, 1);
                cryRpt.PrintToPrinter(1, false, 0, 0);

                cryRpt.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            #endregion Crystal reports işlemlerinin yapıldığı yer
        }
    }
}