using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class CekmeListesi_2 : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public CekmeListesi_2(string _formName, string belgeNo, string musteriKodu, string musteriAdi)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            //end font

            formName = _formName;

            txtBelgeNo.Text = belgeNo;
            txtMusteriKodu.Text = musteriKodu;
            txtMusteriAdi.Text = musteriAdi;

            DetaylariListele();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

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

            txtBelgeNo.Font = new Font(txtBelgeNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBelgeNo.Font.Style);

            txtMusteriKodu.Font = new Font(txtMusteriKodu.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtMusteriKodu.Font.Style);

            txtMusteriAdi.Font = new Font(txtMusteriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtMusteriAdi.Font.Style);

            btnAddOrUpdate.Font = new Font(btnAddOrUpdate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAddOrUpdate.Font.Style);

            dtgCekmeListesi.Font = new Font(dtgCekmeListesi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgCekmeListesi.Font.Style);

            txtBarkod.Font = new Font(txtBarkod.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarkod.Font.Style);

            btnDetay.Font = new Font(btnDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDetay.Font.Style);

            cmbPrinter.Font = new Font(cmbPrinter.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbPrinter.Font.Style);

            btnYazdir.Font = new Font(btnYazdir.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnYazdir.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik

            txtBelgeNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtMusteriKodu.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtMusteriAdi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBarkod.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbPrinter.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private string formName = "";

        private AIFTerminalService.CekmeListesiOnaylamaKoliDetay cekmeListesiOnaylamaKoliDetay = new AIFTerminalService.CekmeListesiOnaylamaKoliDetay();
        public static List<AIFTerminalService.CekmeListesiOnaylamaKoliDetay> cekmeListesiOnaylamaKoliDetays = new List<AIFTerminalService.CekmeListesiOnaylamaKoliDetay>();

        private List<SilinenPaletNoListesi> silinenPaletNoListesis = new List<SilinenPaletNoListesi>();

        private List<string> gridPaletNumarlari = new List<string>();

        private void CekmeListesi_2_Load(object sender, EventArgs e)
        {
            ///cekmeListesiOnaylamaKoliDetays = new List<CekmeListesiOnaylamaKoliDetay>();
            frmName.Text = formName;
            defaultColor = dtgCekmeListesi.Rows[0].Cells[0].Style.BackColor;

            if (dtgCekmeListesi.Rows.Count > 0)
            {
                dtgCekmeListesi.Rows[0].Selected = false;
            }

            txtBarkod.Focus();

            if (dahaonceGirilmisPaletler.Columns.Count == 0)
            {
                dahaonceGirilmisPaletler.Columns.Add("PaletNo", typeof(string));
            }

            dahaonceGirilmisPaletler.Rows.Clear();
            paletVar = false;
        }

        private CekmeListesiOnaylama cekmeListesiOnaylama = new CekmeListesiOnaylama();

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgCekmeListesi.Rows.Count == 0)
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

                CekmeListesiOnaylamaDetay cekmeListesiOnaylamaDetay = new CekmeListesiOnaylamaDetay();
                List<CekmeListesiOnaylamaDetay> cekmeListesiOnaylamaDetays = new List<CekmeListesiOnaylamaDetay>();

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                int i = 1;
                cekmeListesiOnaylama.BelgeNo = txtBelgeNo.Text;
                cekmeListesiOnaylama.MusteriKodu = txtMusteriKodu.Text;

                foreach (DataRow items in dtCekmeListesiDetaylari.Rows)
                {
                    if (items["Miktar"].ToString() == "0" || items["Miktar"].ToString() == "")
                    {
                        continue;
                    }

                    if (Convert.ToDouble(items["Miktar"]) == 0)
                    {
                        continue;
                    }

                    cekmeListesiOnaylamaDetays.Add(new CekmeListesiOnaylamaDetay
                    {
                        PaletNo = items["PaletNo"].ToString(),
                        Barkod = items["Barkod"].ToString(),
                        MuhatapKatalogNo = items["MuhatapKatalogNo"].ToString(),
                        KalemKodu = items["UrunKodu"].ToString(),
                        KalemTanimi = items["UrunTanimi"].ToString(),
                        PlanlananMiktar = Math.Round(Convert.ToDouble(items["PlanlananSiparisMiktari"]), Giris.genelParametreler.OndalikMiktar),
                        Miktar = Math.Round(Convert.ToDouble(items["Miktar"]), Giris.genelParametreler.OndalikMiktar),
                        SipNo = items["SiparisNumarasi"] != null && items["SiparisNumarasi"].ToString() != "" ? Convert.ToInt32(items["SiparisNumarasi"]) : -1,
                        SatirNo = items["SipSatirNo"] != null && items["SipSatirNo"].ToString() != "" ? Convert.ToInt32(items["SipSatirNo"]) : -1,
                        SiparisKarsilamaLineId = items["SatirNo"].ToString(),
                        GridViewGorunenSira = items["dtgSira"].ToString(),
                        satirKaynagi = items["SatirKaynagi"] != null && items["SatirKaynagi"].ToString() != "" ? items["SatirKaynagi"].ToString() : "",
                    });

                    #region koli tablosunun satırına palet no gönderldi

                    if (Giris.genelParametreler.CekmeListesiKalemleriniGrupla != "Y")
                    {
                        cekmeListesiOnaylamaKoliDetays.Where(x => x.siparisNumarasi == Convert.ToInt32(items["SiparisNumarasi"]) && x.sapSatirNo == Convert.ToInt32(items["SipSatirNo"])).ToList().ForEach(y => y.PaletNo = items["PaletNo"].ToString());
                    }
                    else
                    {
                        cekmeListesiOnaylamaKoliDetays.Where(x => x.KalemKodu == items["UrunKodu"].ToString()).ToList().ForEach(y => y.PaletNo = items["PaletNo"].ToString());
                    }

                    #endregion koli tablosunun satırına palet no gönderldi

                    i++;
                }

                //cekmeListesiOnaylamaDetays.RemoveAll(x => x.PaletNo == "");

                cekmeListesiOnaylama.cekmeListesiOnaylamaDetays = cekmeListesiOnaylamaDetays.ToArray();
                cekmeListesiOnaylama.cekmeListesiOnaylamaKoliDetays = cekmeListesiOnaylamaKoliDetays.ToArray();

                #region iki veya daha fazla uygulamadan fazladan miktar girişini engellemek için yapılmıştır

                bool cekmelistesikontrol = true;
                if (Giris.genelParametreler.CekmeListesiFazlaMiktarGirer != "Y")
                {
                    cekmelistesikontrol = CekmeListesiKontrol();
                }

                if (!cekmelistesikontrol)
                {
                    return;
                }

                #endregion iki veya daha fazla uygulamadan fazladan miktar girişini engellemek için yapılmıştır

                var resp1 = aIFTerminalServiceSoapClient1.addOrUpdateCekmeListesiOnaylama(Giris._dbName, cekmeListesiOnaylama, silinenPaletNoListesis.ToArray(), Giris.genelParametreler.CekmeListesiKalemleriniGrupla);

                if (resp1.Val == 0)
                {
                    silinenPaletNoListesis = new List<SilinenPaletNoListesi>();
                    CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

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

        private bool doubleclick = false;

        public static List<Parties> ListParties = new List<Parties>();

        public static DataTable dtCekmeListesiDetaylari = new DataTable();

        private void DetaylariListele()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = new Response();

            resp = aIFTerminalServiceSoapClient.getCekmeListesiDetaylari(Giris._dbName, txtBelgeNo.Text, Giris.mKodValue, Giris.genelParametreler.CekmeListesiKalemleriniGrupla);

            if (resp._list != null)
            {
                dtCekmeListesiDetaylari = resp._list;
                //dtCekmeListesiDetaylari.Columns.Add("Miktar", typeof(double));
                dtCekmeListesiDetaylari.Columns.Add("dtgSira", typeof(int));

                dtgCekmeListesi.DataSource = dtCekmeListesiDetaylari;

                dtgCekmeListesi.EnableHeadersVisualStyles = false;

                dtgCekmeListesi.RowTemplate.Height = 55;
                dtgCekmeListesi.ColumnHeadersHeight = 60;

                dtgCekmeListesi.Columns["SiparisNumarasi"].HeaderText = "S.NO";
                dtgCekmeListesi.Columns["UrunKodu"].HeaderText = "KALEM KOD";
                dtgCekmeListesi.Columns["UrunTanimi"].HeaderText = "KALEM AD";
                dtgCekmeListesi.Columns["SipSatirNo"].HeaderText = "SATIR NO";
                dtgCekmeListesi.Columns["PlanlananSiparisMiktari"].HeaderText = "PLN.MIK";
                dtgCekmeListesi.Columns["Miktar"].HeaderText = "MIK";
                dtgCekmeListesi.Columns["PaletNo"].HeaderText = "PLT";
                dtgCekmeListesi.Columns["MuhKat"].HeaderText = "MUH.KAT";

                dtgCekmeListesi.Columns["MuhatapKatalogNo"].HeaderText = "MUH.KAT";

                dtgCekmeListesi.Columns["SiparisNumarasi"].Visible = false;
                dtgCekmeListesi.Columns["SipSatirNo"].Visible = false;
                dtgCekmeListesi.Columns["SatirNo"].Visible = false;
                dtgCekmeListesi.Columns["Barkod"].Visible = false;
                dtgCekmeListesi.Columns["Partili"].Visible = false;
                dtgCekmeListesi.Columns["MuhatapKatalogNo"].Visible = false;
                dtgCekmeListesi.Columns["dtgSira"].Visible = false;
                dtgCekmeListesi.Columns["MuhKatGoster"].Visible = false;

                if (dtgCekmeListesi.Rows[0].Cells["MuhKatGoster"].Value.ToString() == "Y")
                {
                    dtgCekmeListesi.Columns["UrunKodu"].Visible = false;
                }
                else
                {
                    dtgCekmeListesi.Columns["MuhKat"].Visible = false;
                }

                dtgCekmeListesi.Columns["PlanlananSiparisMiktari"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgCekmeListesi.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                dtgCekmeListesi.Columns["PlanlananSiparisMiktari"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgCekmeListesi.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //dtgCekmeListesi.Columns["SiparisNumarasi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgCekmeListesi.Columns["UrunKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgCekmeListesi.Columns["PlanlananSiparisMiktari"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgCekmeListesi.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgCekmeListesi.Columns["PaletNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ////dtgCekmeListesi.Columns["MuhatapKatalogNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgCekmeListesi.Columns["UrunTanimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtgCekmeListesi.Columns["Miktar"].DisplayIndex = 5;
                dtgCekmeListesi.Columns["PaletNo"].DisplayIndex = 6;

                foreach (DataGridViewColumn column in dtgCekmeListesi.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                for (int i = 0; i <= dtgCekmeListesi.Rows.Count - 1; i++)
                {
                    dtgCekmeListesi.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                }
                //dtgCekmeListesi.Columns["dtgSira"].Visible = false;

                listAllPrinters();

                if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("PaletNo") != "").Count() > 0)
                {
                    paletVar = true;
                }

                #region Çekme Listesi Koli Detaylarını Getir

                //KoliDetaylariListele();

                #endregion Çekme Listesi Koli Detaylarını Getir
            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
            vScrollBar1.Maximum = dtgCekmeListesi.RowCount + 5;
        }

        public static bool paletVar = false;

        private void KoliDetaylariListele()
        {
            try
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp2 = aIFTerminalServiceSoapClient.getCekmeListesiKoliDetaylari(Giris._dbName, txtBelgeNo.Text, Giris.mKodValue);

                if (resp2._list != null)
                {
                    for (int i = 0; i <= resp2._list.Rows.Count - 1; i++)
                    {
                        cekmeListesiOnaylamaKoliDetays.Add(new CekmeListesiOnaylamaKoliDetay
                        {
                            siparisNumarasi = Convert.ToInt32(resp2._list.Rows[i]["U_SiparisNo"]),
                            sapSatirNo = Convert.ToInt32(resp2._list.Rows[i]["U_SatirNo"]),
                            KoliAdedi = Convert.ToInt32(resp2._list.Rows[i]["U_KoliAdedi"]),
                            KoliIciAdedi = Convert.ToInt32(resp2._list.Rows[i]["U_KoliIciAdedi"]),
                            ToplamMiktar = Convert.ToInt32(resp2._list.Rows[i]["U_ToplamMiktar"]),
                        });
                    }
                    //cekmeListesiOnaylama.cekmeListesiOnaylamaKoliDetays = cekmeListesiOnaylamaKoliDetays.ToArray();
                }
                //else
                //{
                //    CustomMsgBox.Show(resp2.Desc, "Uyarı", "Tamam", "");
                //}
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show(ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarkod.Focus();

                if (txtBarkod.Text != "")
                {
                    bool urunbulundu = false;
                    var exits = dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text).ToList();

                    if (exits.Count > 0)
                    {
                        int dtgSira = -1;
                        if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text && x.Field<decimal>("Miktar") == 0).Count() == 0)
                        {
                            dtgSira = dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                        }
                        else
                        {
                            dtgSira = dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text && x.Field<decimal>("Miktar") == 0).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                        }

                        var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, dtgSira);
                        dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);

                        dtgCekmeListesi.ClearSelection();

                        dtgCekmeListesi.Rows[dtgSira].Cells[0].Selected = true;

                        urunbulundu = true;
                    }

                    if (!urunbulundu)
                    {
                        exits = dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text).ToList();
                        if (exits.Count > 0)
                        {
                            int dtgSira = -1;
                            if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text && x.Field<decimal>("Miktar") == 0).Count() == 0)
                            {
                                dtgSira = dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                            }
                            else
                            {
                                dtgSira = dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text && x.Field<decimal>("Miktar") == 0).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                            }

                            if (dtgSira > -1)
                            {
                                var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, dtgSira);
                                dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);

                                dtgCekmeListesi.ClearSelection();

                                dtgCekmeListesi.Rows[dtgSira].Cells[0].Selected = true;

                                urunbulundu = true;
                            }
                        }
                    }

                    if (!urunbulundu)
                    {
                        exits = dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == txtBarkod.Text).ToList();
                        if (exits.Count > 0)
                        {
                            int dtgSira = -1;
                            if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == txtBarkod.Text && x.Field<decimal>("Miktar") == 0).Count() == 0)
                            {
                                dtgSira = dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == txtBarkod.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                            }
                            else
                            {
                                dtgSira = dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == txtBarkod.Text && x.Field<decimal>("Miktar") == 0).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                            }

                            var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, dtgSira);
                            dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);

                            dtgCekmeListesi.ClearSelection();

                            dtgCekmeListesi.Rows[dtgSira].Cells[0].Selected = true;

                            urunbulundu = true;
                        }
                    }

                    btnDetay.PerformClick();
                    txtBarkod.Text = "";
                }
                else
                {
                    txtBarkod.Text = "";
                    CustomMsgBox.Show("BARKOD BULUNAMADI.", "Uyarı", "Tamam", "");
                    txtBarkod.Focus();
                    txtBarkod.Select(0, txtBarkod.Text.Length);
                    return;
                }
            }
        }

        private string barcode = "";
        private string itemCode = "";
        private string itemName = "";
        private string partili = "";
        private string paletNo = "";
        private int siparisNumarasi = -1;
        private int siparisSatirNo = -1;
        private int dtgSira = -1;
        public static int currentRow = 0;
        private double planlananMiktar = 0;
        private double toplananMiktar = 0;
        private Color defaultColor = Color.White;
        public static DataTable dahaonceGirilmisPaletler = new DataTable();
        private string satirKaynagi = "";

        private void dtgCekmeListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    barcode = dtCekmeListesiDetaylari.Rows[e.RowIndex]["Barkod"].ToString();
                    itemCode = dtCekmeListesiDetaylari.Rows[e.RowIndex]["UrunKodu"].ToString();
                    itemName = dtCekmeListesiDetaylari.Rows[e.RowIndex]["UrunTanimi"].ToString();
                    paletNo = dtCekmeListesiDetaylari.Rows[e.RowIndex]["PaletNo"].ToString();
                    siparisNumarasi = dtCekmeListesiDetaylari.Rows[e.RowIndex]["SiparisNumarasi"].ToString() == "" ? -1 : Convert.ToInt32(dtCekmeListesiDetaylari.Rows[e.RowIndex]["SiparisNumarasi"]);
                    siparisSatirNo = dtCekmeListesiDetaylari.Rows[e.RowIndex]["SipSatirNo"].ToString() == "" ? -1 : Convert.ToInt32(dtCekmeListesiDetaylari.Rows[e.RowIndex]["SipSatirNo"]);
                    dtgSira = dtCekmeListesiDetaylari.Rows[e.RowIndex]["dtgSira"].ToString() == "" ? -1 : Convert.ToInt32(dtCekmeListesiDetaylari.Rows[e.RowIndex]["dtgSira"]);

                    partili = dtCekmeListesiDetaylari.Rows[e.RowIndex]["Partili"].ToString();
                    planlananMiktar = dtCekmeListesiDetaylari.Rows[e.RowIndex]["PlanlananSiparisMiktari"].ToString() == "" ? 0 : Convert.ToDouble(dtCekmeListesiDetaylari.Rows[e.RowIndex]["PlanlananSiparisMiktari"]);
                    toplananMiktar = dtCekmeListesiDetaylari.Rows[e.RowIndex]["Miktar"].ToString() == "" ? 0 : Convert.ToDouble(dtCekmeListesiDetaylari.Rows[e.RowIndex]["Miktar"]);
                    satirKaynagi = dtCekmeListesiDetaylari.Rows[e.RowIndex]["SatirKaynagi"].ToString();
                    currentRow = e.RowIndex;

                    if (barcode != "")
                    {
                        txtBarkod.Text = barcode.ToString();
                    }
                    else if (dtCekmeListesiDetaylari.Rows[e.RowIndex]["MuhatapKatalogNo"].ToString() != "") //Bu alanı ekranda bir yere yazmadığımız için buradan aldım.
                    {
                        txtBarkod.Text = dtCekmeListesiDetaylari.Rows[e.RowIndex]["MuhatapKatalogNo"].ToString();
                    }
                    else if (itemCode != "")
                    {
                        txtBarkod.Text = itemCode.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM", "");
            }
        }

        private void btnDetay_Click(object sender, EventArgs e)
        {
            if (txtBarkod.Text == "")
            {
                return;
            }
            if (partili == "Y")
            {
                //List<dynamic> list = new List<dynamic>();
                //list.Add(itemCode);
                //list.Add(itemName);
                //list.Add(barcode);
                //list.Add(planlananMiktar);
                //list.Add(toplananMiktar);
                //list.Add(planlananMiktar - toplananMiktar);
                //txtBarkod.Text = "";
                //PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("AIF_CEKMELISTESI", list, "ÇEKME LİSTESİ");
                //partisizKalemSecimi.ShowDialog();
            }
            else
            {
                #region Burada satıra yeni ürün ekleme vardı ama artık olmayacak.

                //if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text).Count() == 0 && dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text).Count() == 0 && dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == txtBarkod.Text).Count() == 0)
                //{
                //    bool uruntamam = false;

                //    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                //    Response resp = new Response();

                //    if (txtBarkod.Text != "TANIMSIZ")
                //    {
                //        resp = aIFTerminalServiceSoapClient.GetProductByBarCode(Giris._dbName, txtBarkod.Text, Giris.mKodValue);
                //    }

                //    if (resp._list == null)
                //    {
                //        resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, txtBarkod.Text, "", "", Giris.mKodValue);
                //    }
                //    else
                //    {
                //        uruntamam = true;
                //    }

                //    if (resp._list == null)
                //    {
                //        resp = aIFTerminalServiceSoapClient.GetProductByItemCode(Giris._dbName, txtBarkod.Text, Giris.mKodValue);
                //    }

                //    if (resp._list != null)
                //    {
                //        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                //        {
                //            try
                //            {
                //                resp._list.Columns.Add("DepoYeriId", typeof(string));
                //                resp._list.Columns.Add("DepoYeriAdi", typeof(string));
                //            }
                //            catch (Exception)
                //            {
                //            }
                //        }
                //        uruntamam = true;
                //    }

                //    if (uruntamam)
                //    {
                //        DataRow dr = dtCekmeListesiDetaylari.NewRow();
                //        dr["UrunKodu"] = resp._list.Rows[0]["Kalem Kodu"].ToString();
                //        dr["UrunTanimi"] = resp._list.Rows[0]["Kalem Tanımı"].ToString();
                //        dr["Partili"] = resp._list.Rows[0]["Partili"].ToString();
                //        dr["PlanlananSiparisMiktari"] = "0";

                //        resp = aIFTerminalServiceSoapClient.getKalemKoduMuhatapKatalogNoBarkod(Giris._dbName, resp._list.Rows[0]["Kalem Kodu"].ToString(), "", Giris.mKodValue);

                //        if (resp._list != null)
                //        {
                //            dr["MuhatapKatalogNo"] = resp._list.Rows[0]["MuhatapKatalogNo"].ToString();
                //            dr["Barkod"] = resp._list.Rows[0]["Barkod"].ToString();
                //        }

                //        dtCekmeListesiDetaylari.Rows.Add(dr);

                //        dtgCekmeListesi.DataSource = dtCekmeListesiDetaylari;

                //        for (int i = 0; i <= dtgCekmeListesi.Rows.Count - 1; i++)
                //        {
                //            dtgCekmeListesi.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                //        }

                //        var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, dtCekmeListesiDetaylari.Rows.Count - 1);
                //        dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);

                //    }
                //    else
                //    {
                //        txtBarkod.Text = "";
                //        CustomMsgBox.Show("BARKOD BULUNAMADI.", "Uyarı", "Tamam", "");
                //        txtBarkod.Focus();
                //        txtBarkod.Select(0, txtBarkod.Text.Length);
                //        return;
                //    }
                //}
                //else
                //{
                //    if (!doubleclick)
                //    {
                //        int sira = -1;
                //        if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text).Count() > 0)
                //        {
                //            sira = Convert.ToInt32(dtgCekmeListesi.Rows[currentRow].Cells["dtgSira"].Value);
                //            var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, sira);
                //            dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);
                //        }
                //        else if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text).Count() > 0)
                //        {
                //            sira = Convert.ToInt32(dtgCekmeListesi.Rows[currentRow].Cells["dtgSira"].Value);
                //            var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, sira);
                //            dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);
                //        }
                //        else if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == txtBarkod.Text).Count() > 0)
                //        {
                //            sira = Convert.ToInt32(dtgCekmeListesi.Rows[currentRow].Cells["dtgSira"].Value);
                //            var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, sira);
                //            dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);
                //        }

                //        if (sira == -1)
                //        {
                //            return;
                //        }
                //    }
                //}

                #endregion Burada satıra yeni ürün ekleme vardı ama artık olmayacak.

                if (!doubleclick)
                {
                    int sira = -1;
                    if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarkod.Text).Count() > 0)
                    {
                        sira = Convert.ToInt32(dtgCekmeListesi.Rows[currentRow].Cells["dtgSira"].Value);
                        var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, sira);
                        dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);
                    }
                    else if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarkod.Text).Count() > 0)
                    {
                        sira = Convert.ToInt32(dtgCekmeListesi.Rows[currentRow].Cells["dtgSira"].Value);
                        var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, sira);
                        dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);
                    }
                    else if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == txtBarkod.Text).Count() > 0)
                    {
                        sira = Convert.ToInt32(dtgCekmeListesi.Rows[currentRow].Cells["dtgSira"].Value);
                        var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, sira);
                        dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);
                    }

                    if (sira == -1)
                    {
                        CustomMsgBox.Show("ÜRÜN BULUMAMADI.", "UYARI", "TAMAM", "");
                        txtBarkod.Text = "";
                        txtBarkod.Focus();
                        return;
                    }
                }

                #region list mantığından cıkılıp class yapısına geçildi 2022.03.25 -- iptal

                //List<PartiliPartisizEkranList> partiliPartisizEkranLists = new List<PartiliPartisizEkranList>();
                //partiliPartisizEkranLists.Add(new PartiliPartisizEkranList
                //{
                //    UrunKodu = itemCode,
                //    UrunTanimi = itemName,
                //    Barkod = barcode,
                //    SiparisMiktari = Convert.ToDouble(Math.Round(planlananMiktar, Giris.genelParametreler.OndalikMiktar).ToString()),
                //    ToplananMiktar = Convert.ToDouble(Math.Round(toplananMiktar, Giris.genelParametreler.OndalikMiktar).ToString()),
                //    SiparisSatirNo = siparisSatirNo,
                //    SiparisNumarasi = siparisNumarasi,
                //    PaletNumarasi = paletNo,
                //    SatirKaynagi = satirKaynagi

                //});
                List<dynamic> list = new List<dynamic>();
                list.Add(itemCode);
                list.Add(itemName);
                list.Add(barcode);
                list.Add(Math.Round(planlananMiktar, Giris.genelParametreler.OndalikMiktar).ToString());
                list.Add(Math.Round(toplananMiktar, Giris.genelParametreler.OndalikMiktar).ToString());
                list.Add(siparisSatirNo);
                list.Add(paletNo);
                list.Add(siparisNumarasi);
                list.Add(satirKaynagi);

                #endregion list mantığından cıkılıp class yapısına geçildi 2022.03.25 -- iptal

                if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("PaletNo") != "").Count() > 0)
                {
                    paletVar = true;

                    for (int i = 0; i <= dtgCekmeListesi.Rows.Count - 1; i++)
                    {
                        if (dtgCekmeListesi.Rows[i].Cells["PaletNo"].Value != DBNull.Value && dtgCekmeListesi.Rows[i].Cells["PaletNo"].Value.ToString() != "")
                        {
                            DataRow drw = dahaonceGirilmisPaletler.NewRow();
                            drw["PaletNo"] = dtgCekmeListesi.Rows[i].Cells["PaletNo"].Value.ToString();

                            dahaonceGirilmisPaletler.Rows.Add(drw);
                        }
                    }
                }

                txtBarkod.Text = "";
                //PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("AIF_CEKMELISTESI", partiliPartisizEkranLists, "ÇEKME LİSTESİ");
                PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("AIF_CEKMELISTESI", list, "ÇEKME LİSTESİ");
                partisizKalemSecimi.ShowDialog();
                partisizKalemSecimi.Dispose();
                GC.Collect();

                if (PartisizKalemSecimi.dialogresult == "Ok")
                {
                    if (PartisizKalemSecimi.paletNo != "")
                    {
                        if (PartisizKalemSecimi.paletNo != paletNo)
                        {
                            silinenPaletNoListesis.Add(new SilinenPaletNoListesi
                            {
                                paletNo = paletNo,
                                siparisNo = siparisNumarasi,
                                siparisSatirNo = siparisSatirNo
                            });
                        }

                        dtCekmeListesiDetaylari.Rows[currentRow]["Miktar"] = PartisizKalemSecimi.quantity;
                        dtCekmeListesiDetaylari.Rows[currentRow]["PaletNo"] = PartisizKalemSecimi.paletNo;
                    }
                    else
                    {
                        silinenPaletNoListesis.Add(new SilinenPaletNoListesi
                        {
                            paletNo = paletNo,
                            siparisNo = siparisNumarasi,
                            siparisSatirNo = siparisSatirNo
                        });
                        dtCekmeListesiDetaylari.Rows[currentRow]["PaletNo"] = null;
                    }
                    //dtDetails.AcceptChanges();
                    if (Math.Round(Convert.ToDouble(dtgCekmeListesi.Rows[currentRow].Cells["PlanlananSiparisMiktari"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgCekmeListesi.Rows[currentRow].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar))
                    {
                        dtgCekmeListesi.Rows[currentRow].Cells["Miktar"].Style.BackColor = Color.LimeGreen;
                    }
                    else if (Math.Round(Convert.ToDouble(dtgCekmeListesi.Rows[currentRow].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                    {
                        dtgCekmeListesi.Rows[currentRow].Cells["Miktar"].Style.BackColor = defaultColor;
                    }
                    else
                    {
                        dtgCekmeListesi.Rows[currentRow].Cells["Miktar"].Style.BackColor = Color.OrangeRed;
                    }
                    PartisizKalemSecimi.dialogresult = "";
                }
                dtgCekmeListesi.Rows[currentRow].Selected = false;

                partili = "";
                barcode = "";
                itemCode = "";
                planlananMiktar = 0;
                toplananMiktar = 0;

                PartisizKalemSecimi.quantity = 0;
                PartisizKalemSecimi.paletNo = "";
            }

            if (dtgCekmeListesi.Rows.Count > 0)
            {
                dtgCekmeListesi.Rows[0].Selected = false;
            }

            txtBarkod.Focus();
            txtBarkod.Text = "";
        }

        private void dtgCekmeListesi_DoubleClick(object sender, EventArgs e)
        {
            if (partili == "Y")
            {
                btnDetay.PerformClick();
                doubleclick = true;
                partili = "";
                barcode = "";
                return;
            }
            else
            {
                List<dynamic> list = new List<dynamic>();
                string Val = txtBarkod.Text;
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = null;

                //if (Val != "TANIMSIZ")
                //{
                //    resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, "", Giris.mKodValue);
                //}

                //if (Val != "TANIMSIZ")
                //{
                //    if (resp._list == null)
                //    {
                //        resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, Val, "", txtMusteriKodu.Text, Giris.mKodValue);
                //    }
                //}

                //if (Val != "TANIMSIZ")
                //{
                //    if (resp._list == null)
                //    {
                //        if (Val != "")
                //        {
                //            //Val = cmbItemName.SelectedValue.ToString();
                //            resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, "", txtMusteriKodu.Text, Giris.mKodValue);
                //        }
                //    }
                //}
                //else
                //{
                //    if (resp._list == null)
                //    {
                //        //Val = cmbItemName.SelectedValue.ToString();
                //        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, "", txtMusteriKodu.Text, Giris.mKodValue);
                //    }
                //}

                //if (resp._list != null)
                //{
                list.Add(itemCode);
                list.Add(itemName);
                //list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                //list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                //string brkd = "";
                //if (resp._list.Rows[0]["Barkod"].ToString() == "" && resp._list.Rows[0]["MuhatapKatalogNo"].ToString() == "")
                //{
                //    brkd = "Tanımsız";
                //}
                //else if (resp._list.Rows[0]["Barkod"].ToString() != "")
                //{
                //    brkd = resp._list.Rows[0]["Barkod"].ToString();
                //}
                //else if (resp._list.Rows[0]["MuhatapKatalogNo"].ToString() != "")
                //{
                //    brkd = resp._list.Rows[0]["MuhatapKatalogNo"].ToString();
                //}

                list.Add(txtBarkod.Text);
                //list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                list.Add(Math.Round(planlananMiktar, Giris.genelParametreler.OndalikMiktar).ToString());
                list.Add(Math.Round(toplananMiktar, Giris.genelParametreler.OndalikMiktar).ToString());
                //list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                list.Add(siparisSatirNo);
                list.Add(paletNo);
                list.Add(siparisNumarasi);
                list.Add(satirKaynagi);
                //list.Add(depoTanimi);
                //list.Add(warehouse);
                //list.Add(depoYeriId);
                //list.Add(depoYeriAdi);

                if (dtCekmeListesiDetaylari.AsEnumerable().Where(x => x.Field<string>("PaletNo") != "").Count() > 0)
                {
                    paletVar = true;
                    for (int i = 0; i <= dtgCekmeListesi.Rows.Count - 1; i++)
                    {
                        if (dtgCekmeListesi.Rows[i].Cells["PaletNo"].Value != DBNull.Value && dtgCekmeListesi.Rows[i].Cells["PaletNo"].Value.ToString() != "")
                        {
                            DataRow drw = dahaonceGirilmisPaletler.NewRow();
                            drw["PaletNo"] = dtgCekmeListesi.Rows[i].Cells["PaletNo"].Value.ToString();

                            dahaonceGirilmisPaletler.Rows.Add(drw);
                        }
                    }
                }

                txtBarkod.Text = "";
                PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("AIF_CEKMELISTESI", list, "ÇEKME LİSTESİ");
                partisizKalemSecimi.ShowDialog();
                partisizKalemSecimi.Dispose();
                GC.Collect();

                if (PartisizKalemSecimi.dialogresult == "Ok")
                {
                    dtCekmeListesiDetaylari.Rows[currentRow]["Miktar"] = PartisizKalemSecimi.quantity;
                    if (PartisizKalemSecimi.paletNo != "")
                    {
                        if (PartisizKalemSecimi.paletNo != paletNo)
                        {
                            silinenPaletNoListesis.Add(new SilinenPaletNoListesi
                            {
                                paletNo = paletNo,
                                siparisNo = siparisNumarasi,
                                siparisSatirNo = siparisSatirNo
                            });
                        }
                        dtCekmeListesiDetaylari.Rows[currentRow]["PaletNo"] = PartisizKalemSecimi.paletNo;
                    }
                    else
                    {
                        silinenPaletNoListesis.Add(new SilinenPaletNoListesi
                        {
                            paletNo = paletNo,
                            siparisNo = siparisNumarasi,
                            siparisSatirNo = siparisSatirNo
                        });
                        dtCekmeListesiDetaylari.Rows[currentRow]["PaletNo"] = null;
                    }
                    //dtDetails.AcceptChanges();
                    if (Math.Round(Convert.ToDouble(dtgCekmeListesi.Rows[currentRow].Cells["PlanlananSiparisMiktari"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgCekmeListesi.Rows[currentRow].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar))
                    {
                        dtgCekmeListesi.Rows[currentRow].Cells["Miktar"].Style.BackColor = Color.LimeGreen;
                    }
                    else if (Math.Round(Convert.ToDouble(dtgCekmeListesi.Rows[currentRow].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                    {
                        dtgCekmeListesi.Rows[currentRow].Cells["Miktar"].Style.BackColor = defaultColor;
                    }
                    else
                    {
                        dtgCekmeListesi.Rows[currentRow].Cells["Miktar"].Style.BackColor = Color.OrangeRed;
                    }

                    PartisizKalemSecimi.dialogresult = "";
                }
                dtgCekmeListesi.Rows[currentRow].Selected = false;
                //}

                partili = "";
                barcode = "";
                itemCode = "";
                itemName = "";
                planlananMiktar = 0;
                toplananMiktar = 0;
                PartisizKalemSecimi.quantity = 0;
                PartisizKalemSecimi.paletNo = "";
            }
        }

        private void btnSatirSil_Click(object sender, EventArgs e)
        {
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgCekmeListesi.FirstDisplayedScrollingRowIndex = e.NewValue;
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

        private int yazdirMik = 0;

        private void Print()
        {
            #region Crystal reports işlemlerinin yapıldığı yer

            try
            {
                string paletNo = "";

                if (dtgCekmeListesi.CurrentCell != null)
                {
                    paletNo = dtgCekmeListesi.Rows[dtgCekmeListesi.CurrentCell.RowIndex].Cells["PaletNo"].Value.ToString();
                }

                if (paletNo == "")
                {
                    CustomMsgBox.Show("SATIR SEÇİMİ VEYA PALET SEÇİMİ YAPILMADAN YAZDIRMA YAPILAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }
                string path = "";

                if (Giris._dbName == "ZTEST2")
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + "ZTest2_Plt_105_70_mm_1.rpt";
                }
                else if (Giris._dbName == "ANATOLYA_DB")
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + "Plt_105_70_mm_1.rpt";
                }

                ReportDocument cryRpt = new ReportDocument();

                cryRpt.Load(path);

                string server = @"ANATOLYA-SAP\SAPB1";

                cryRpt.SetDatabaseLogon("sa", "Eropa2018!", server, Giris._dbName);

                cryRpt.VerifyDatabase();

                cryRpt.SetParameterValue(0, paletNo);

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

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            Print();
        }

        private bool CekmeListesiKontrol()
        {
            try
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = aIFTerminalServiceSoapClient.getCekmeListesiKontrol(Giris._dbName, txtBelgeNo.Text, Giris.mKodValue);
                DataTable dt = new DataTable();

                if (resp._list != null)
                {
                    dt = resp._list;

                    int i = 1;
                    foreach (var item in cekmeListesiOnaylama.cekmeListesiOnaylamaDetays)
                    {
                        var chn = dt.AsEnumerable().Where(x => x.Field<int>("U_SiparisNumarasi") == Convert.ToInt32(item.SipNo) && x.Field<int>("U_SipSatirNo") == Convert.ToInt32(item.SatirNo)).ToList();

                        #region gerek duyulmadıgı ıcın gruplamalı mantı eklenmedı (dogan)

                        //if (Giris.genelParametreler.CekmeListesiKalemleriniGrupla != "Y")
                        //{
                        //    chn = dt.AsEnumerable().Where(x => x.Field<int>("U_SiparisNumarasi") == Convert.ToInt32(item.SipNo) && x.Field<int>("U_SipSatirNo") == Convert.ToInt32(item.SatirNo)).ToList();
                        //}
                        //else
                        //{
                        //    //chn = dt.AsEnumerable().Where(x => x.Field<string>("U_UrunKodu") == item.KalemKodu).ToList();

                        //}

                        #endregion gerek duyulmadıgı ıcın gruplamalı mantı eklenmedı (dogan)

                        if (chn.Count > 0)
                        {
                            var mik = chn.Select(x => x.Field<decimal>("Kalan Miktar")).FirstOrDefault();
                            double mikmevcut = Convert.ToDouble(item.Miktar);
                            if (mikmevcut > Convert.ToDouble(mik))
                            {
                                CustomMsgBox.Show(item.KalemKodu + " için en fazla " + mik.ToString("N" + Giris.genelParametreler.OndalikMiktar) + " miktar girişi yapılabilir.", "Uyarı", "Tamam", "");

                                //var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, i);
                                //dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);
                                return false;
                            }
                        }

                        i++;
                    }
                }
                else
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                    return false;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("Hata oluştu." + ex.Message, "Uyarı", "Tamam", "");
                return false;
            }

            return true;
        }
    }
}