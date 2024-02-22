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
    public partial class CekmeListesiToplanan : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public CekmeListesiToplanan(string _formName, string belgeNo, string musteriKodu, string musteriAdi)
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


            dtgCekmeListesiToplanan.Font = new Font(dtgCekmeListesiToplanan.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgCekmeListesiToplanan.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik 

            txtBelgeNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtMusteriKodu.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtMusteriAdi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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


        List<SilinenPaletNoListesi> silinenPaletNoListesis = new List<SilinenPaletNoListesi>();

        List<string> gridPaletNumarlari = new List<string>();

        private void CekmeListesiToplanan_Load(object sender, EventArgs e)
        {
            //cekmeListesiOnaylamaKoliDetays = new List<CekmeListesiOnaylamaKoliDetay>(); 
            frmName.Text = formName;

            if (dtgCekmeListesiToplanan.Rows.Count > 0)
            {
                dtgCekmeListesiToplanan.Rows[0].Selected = false;
                defaultColor = dtgCekmeListesiToplanan.Rows[0].Cells[0].Style.BackColor;
            }

            if (dtgCekmeListesiToplanan.Rows.Count > 0)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

                btn = new DataGridViewButtonColumn();
                dtgCekmeListesiToplanan.Columns.Add(btn);
                btn.HeaderText = "SATIR SİL";
                btn.Text = "Sil";
                btn.Name = "btnSil";
                btn.UseColumnTextForButtonValue = true;
                //btn.
                btn.DefaultCellStyle.BackColor = Color.OrangeRed;
                //btn.DefaultCellStyle.ForeColor= Color.OrangeRed;
                btn.FlatStyle = FlatStyle.Flat;
                //Application.EnableVisualStyles();

                vScrollBar1.Maximum = dtgCekmeListesiToplanan.RowCount;
                dtgCekmeListesiToplanan.Columns["UrunKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgCekmeListesiToplanan.Columns["ToplananMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgCekmeListesiToplanan.Columns["PaletNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgCekmeListesiToplanan.Columns["btnSil"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtgCekmeListesiToplanan.Columns["UrunTanimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                btn.Visible = false;//Silme işlemi yapılacağı zaman burası açılacak.
            }

        }
        CekmeListesiOnaylama cekmeListesiOnaylama = new CekmeListesiOnaylama();

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgCekmeListesiToplanan.Rows.Count == 0)
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

                foreach (DataRow items in dtCekmeToplananDetaylari.Rows)
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
                        SipNo = Convert.ToInt32(items["SiparisNumarasi"]),
                        SatirNo = Convert.ToInt32(items["SipSatirNo"]),
                        SiparisKarsilamaLineId = items["SatirNo"].ToString(),
                        GridViewGorunenSira = items["dtgSira"].ToString(),
                    });

                    i++;
                }

                //cekmeListesiOnaylamaDetays.RemoveAll(x => x.PaletNo == "");

                cekmeListesiOnaylama.cekmeListesiOnaylamaDetays = cekmeListesiOnaylamaDetays.ToArray();
                cekmeListesiOnaylama.cekmeListesiOnaylamaKoliDetays = cekmeListesiOnaylamaKoliDetays.ToArray();


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

        public static DataTable dtCekmeToplananDetaylari = new DataTable();
        private void DetaylariListele()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.getToplamaListesiDetay(Giris._dbName, txtBelgeNo.Text, Giris.mKodValue);

            if (resp._list != null)
            {
                dtCekmeToplananDetaylari = resp._list;
                //dtCekmeListesiDetaylari.Columns.Add("Miktar", typeof(double));
                dtCekmeToplananDetaylari.Columns.Add("dtgSira", typeof(int));

                dtgCekmeListesiToplanan.DataSource = dtCekmeToplananDetaylari;


                dtgCekmeListesiToplanan.EnableHeadersVisualStyles = false;

                dtgCekmeListesiToplanan.RowTemplate.Height = 55;
                dtgCekmeListesiToplanan.ColumnHeadersHeight = 60;


                dtgCekmeListesiToplanan.Columns["SiparisNumarasi"].HeaderText = "S.NO";
                dtgCekmeListesiToplanan.Columns["UrunKodu"].HeaderText = "KALEM KOD";
                dtgCekmeListesiToplanan.Columns["UrunTanimi"].HeaderText = "KALEM AD";
                dtgCekmeListesiToplanan.Columns["SiparisSatirNo"].HeaderText = "SATIR NO";
                dtgCekmeListesiToplanan.Columns["PlanlananSiparisMiktari"].HeaderText = "PLN.MIK";
                dtgCekmeListesiToplanan.Columns["ToplananMiktar"].HeaderText = "MIK";
                dtgCekmeListesiToplanan.Columns["PaletNo"].HeaderText = "PLT";
                dtgCekmeListesiToplanan.Columns["MusteriKodu"].HeaderText = "MÜŞTERİ KODU";
                dtgCekmeListesiToplanan.Columns["MusteriAdi"].HeaderText = "MÜŞTERİ ADI";

                //dtgCekmeListesi.Columns["MuhatapKatalogNo"].HeaderText = "MUH.KAT";

                dtgCekmeListesiToplanan.Columns["SiparisNumarasi"].Visible = false;
                dtgCekmeListesiToplanan.Columns["SiparisSatirNo"].Visible = false;
                dtgCekmeListesiToplanan.Columns["SiparisTarihi"].Visible = false;
                dtgCekmeListesiToplanan.Columns["TeslimatTarihi"].Visible = false;
                dtgCekmeListesiToplanan.Columns["ToplamSiparisMiktari"].Visible = false;
                dtgCekmeListesiToplanan.Columns["AcikSiparisMiktari"].Visible = false;
                dtgCekmeListesiToplanan.Columns["SevkSipMiktari"].Visible = false;
                //dtgCekmeListesi.Columns["SatirNo"].Visible = false;
                //dtgCekmeListesi.Columns["Barkod"].Visible = false;
                //dtgCekmeListesi.Columns["Partili"].Visible = false;
                //dtgCekmeListesi.Columns["MuhatapKatalogNo"].Visible = false;
                //dtgCekmeListesi.Columns["dtgSira"].Visible = false;
                dtgCekmeListesiToplanan.Columns["PlanlananSiparisMiktari"].Visible = false;
                dtgCekmeListesiToplanan.Columns["SiparisDepoKodu"].Visible = false;
                dtgCekmeListesiToplanan.Columns["U_TeslimatNo"].Visible = false;
                dtgCekmeListesiToplanan.Columns["ToplananDocEntry"].Visible = false;
                dtgCekmeListesiToplanan.Columns["KonteynerVarMi"].Visible = false;
                dtgCekmeListesiToplanan.Columns["dtgSira"].Visible = false;
                dtgCekmeListesiToplanan.Columns["MusteriKodu"].Visible = false;
                dtgCekmeListesiToplanan.Columns["MusteriAdi"].Visible = false;
                dtgCekmeListesiToplanan.Columns["BelgeNo"].Visible = false;


                dtgCekmeListesiToplanan.Columns["PlanlananSiparisMiktari"].DefaultCellStyle.Format = "N"+ Giris.genelParametreler.OndalikMiktar;
                dtgCekmeListesiToplanan.Columns["ToplananMiktar"].DefaultCellStyle.Format = "N"+ Giris.genelParametreler.OndalikMiktar;


                dtgCekmeListesiToplanan.Columns["PlanlananSiparisMiktari"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgCekmeListesiToplanan.Columns["ToplananMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



                //dtgCekmeListesi.Columns["SiparisNumarasi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgCekmeListesi.Columns["UrunKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgCekmeListesi.Columns["PlanlananSiparisMiktari"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgCekmeListesi.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgCekmeListesi.Columns["PaletNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ////dtgCekmeListesi.Columns["MuhatapKatalogNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgCekmeListesi.Columns["UrunTanimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dtgCekmeListesi.Columns["ToplananMiktar"].DisplayIndex = 5;
                //dtgCekmeListesi.Columns["PaletNo"].DisplayIndex = 6;

                foreach (DataGridViewColumn column in dtgCekmeListesiToplanan.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                for (int i = 0; i <= dtgCekmeListesiToplanan.Rows.Count - 1; i++)
                {
                    dtgCekmeListesiToplanan.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                }
                //dtgCekmeListesi.Columns["dtgSira"].Visible = false;

                if (dtCekmeToplananDetaylari.AsEnumerable().Where(x => x.Field<string>("PaletNo") != "").Count() > 0)
                {
                    paletVar = true;
                }

                dtgCekmeListesiToplanan.Columns["UrunKodu"].DisplayIndex = 1;
                dtgCekmeListesiToplanan.Columns["UrunTanimi"].DisplayIndex = 2;
                dtgCekmeListesiToplanan.Columns["MusteriKodu"].DisplayIndex = 3;
                dtgCekmeListesiToplanan.Columns["MusteriAdi"].DisplayIndex = 4;
                dtgCekmeListesiToplanan.Columns["ToplananMiktar"].DisplayIndex = 5;
                dtgCekmeListesiToplanan.Columns["PaletNo"].DisplayIndex = 6;



                #region Çekme Listesi Koli Detaylarını Getir
                //KoliDetaylariListele(); //Yalnızca satır silinecek olduğundan dolayı satırda miktar değişmeyeceğinden bu bilgiye ihtiyaç yok.
                #endregion

            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
            vScrollBar1.Maximum = dtgCekmeListesiToplanan.RowCount + 5;



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


        string barcode = "";
        string itemCode = "";
        string itemName = "";
        string partili = "";
        string paletNo = "";
        string siparisNumarasi = "";
        string siparisSatirNo = "";
        int dtgSira = -1;
        public static int currentRow = 0;
        double planlananMiktar = 0;
        double toplananMiktar = 0;
        private Color defaultColor = Color.White;

        private void dtgCekmeListesiToplanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                currentRow = e.RowIndex;
            }
        }


        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgCekmeListesiToplanan.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {

            }
        }

        private void dtgCekmeListesiToplanan_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void dtgCekmeListesiToplanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    //List<dynamic> list = new List<dynamic>();
                    if (senderGrid.Columns[e.ColumnIndex].Name == "btnSil")
                    {
                        //CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.RemoveAll(x => x.sapSatirNo == sapSatirNo && x.siparisNumarasi == siparisNo);

                        dtgCekmeListesiToplanan.Rows.RemoveAt(currentRow);
                        currentRow = -1;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}