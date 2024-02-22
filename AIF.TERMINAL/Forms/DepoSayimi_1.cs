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
using System.Windows.Forms.VisualStyles;

namespace AIF.TERMINAL.Forms
{
    public partial class DepoSayimi_1 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public DepoSayimi_1(string _formName)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            //end font
            formName = _formName;
            //inventoryTransferLists = _inventoryTransferLists;
        }

        private string formName = "";

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

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtCountingQty.Font = new Font(txtCountingQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCountingQty.Font.Style);

            txtWhsName.Font = new Font(txtWhsName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWhsName.Font.Style);

            btnAddOrUpdate.Font = new Font(btnAddOrUpdate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAddOrUpdate.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtWhsCode.Font = new Font(txtWhsCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWhsCode.Font.Style);

            dtgDetay.Font = new Font(dtgDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgDetay.Font.Style);

            btnSay.Font = new Font(btnSay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSay.Font.Style);

            label5.Font = new Font(label5.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label5.Font.Style);

            dtpSayimTarihi.Font = new Font(dtpSayimTarihi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpSayimTarihi.Font.Style);

            btnListe.Font = new Font(btnListe.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnListe.Font.Style);

            txtItemCode.Font = new Font(txtItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemCode.Font.Style);

            btnShowDetails.Font = new Font(btnShowDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnShowDetails.Font.Style);

            label6.Font = new Font(label6.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label6.Font.Style);

            txtAciklama.Font = new Font(txtAciklama.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtAciklama.Font.Style);

            txtOlcuBirimi.Font = new Font(txtOlcuBirimi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtOlcuBirimi.Font.Style);

            btnRowDel.Font = new Font(btnRowDel.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnRowDel.Font.Style);

            label7.Font = new Font(label7.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label7.Font.Style);

            txtDepoYeriId.Font = new Font(txtDepoYeriId.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtDepoYeriId.Font.Style);

            txtDepoYeriAdi.Font = new Font(txtDepoYeriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtDepoYeriAdi.Font.Style);

            //start yükseklik-genislik
            dtpSayimTarihi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtWhsCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtWhsName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtCountingQty.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtAciklama.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtOlcuBirimi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtDepoYeriId.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtDepoYeriAdi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
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

        public static DataTable dtDetay = new DataTable();
        public static string SelectListcardCode = "";
        private string partino = "";

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    Response resp = new Response();
                    string Val = txtBarCode.Text;
                    partino = Giris.UrunKoduBarkod(Val, "Parti");
                    Val = Giris.UrunKoduBarkod(Val, "Barkod");
                    resp = aIFTerminalServiceSoapClient.GetProductByBarCode(Giris._dbName, Val, Giris.mKodValue);

                    if (resp._list == null)
                    {
                        resp = aIFTerminalServiceSoapClient.getProductsMuhatapKatalogNo(Giris._dbName, Val, Giris.mKodValue);

                        if (resp._list != null)
                        {
                            if (resp._list.Rows.Count > 1)
                            {
                                SelectList nesne = new SelectList("99", "KatalogArama", "KATALOG SEÇİMİ", txtBarCode, txtItemCode, txtItemName, _respParam: resp);
                                nesne.ShowDialog();
                                nesne.Dispose();
                                GC.Collect();

                                if (SelectList.dialogResult == "Ok")
                                {
                                    SelectList.dialogResult = "";

                                    resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, Val, txtWhsCode.Text, SelectListcardCode, Giris.mKodValue);

                                    SelectListcardCode = "";
                                }
                            }
                            else
                            {
                                resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, Val, txtWhsCode.Text, resp._list.Rows[0][0].ToString(), Giris.mKodValue);
                            }
                        }
                    }

                    if (resp._list == null)
                    {
                        resp = aIFTerminalServiceSoapClient.GetProductByItemCode(Giris._dbName, Val, Giris.mKodValue);
                    }

                    if (resp._list != null)
                    {
                        if (resp.Val == 0)
                        {
                            txtBarCode.Text = resp._list.Rows[0]["Barkod"].ToString() == "" ? "TANIMSIZ" : resp._list.Rows[0]["Barkod"].ToString();
                            txtItemCode.Text = resp._list.Rows[0]["Kalem Kodu"].ToString();
                            txtItemName.Text = resp._list.Rows[0]["Kalem Tanımı"].ToString();
                            txtPartili.Text = resp._list.Rows[0]["Partili"].ToString();
                            txtOlcuBirimi.Text = resp._list.Rows[0]["Ölçü Birimi"].ToString();

                            if (Giris.genelParametreler.SayimMiktariOtomatikOlarakAcilsin == "Y")
                            {
                                txtCountingQty.Focus();

                                #region ondalık hatası için eklendi

                                double counting = parseNumber_Seperator.ConvertToDouble(txtCountingQty.Value.ToString());
                                txtCountingQty.Value = Convert.ToDecimal(counting);

                                #endregion ondalık hatası için eklendi

                                SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtCountingQty, null, false);
                                sayiKlavyesi.ShowDialog();
                                sayiKlavyesi.Dispose();
                                GC.Collect();

                                if (Giris.genelParametreler.SayimButonuOtomatikOlarakBasilsin == "Y")
                                {
                                    btnSay.PerformClick();
                                }
                            }
                        }
                        else
                        {
                            CustomMsgBox.Show(Val + " BARKOD NUMARASINA AİT ÜRÜN BULUNAMADI", "UYARI", "TAMAM", "");
                        }
                        vScrollBar1.Maximum = dtgDetay.RowCount + 5;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtItemName_Click(object sender, EventArgs e)
        {
            try
            {
                SelectList nesne = new SelectList("DepoSayimi", "KalemAra", "KALEM ARAMA", txtBarCode, txtItemName, txtItemCode);
                nesne.ShowDialog();
                nesne.Dispose();
                GC.Collect();

                if (SelectList.dialogResult == "Ok")
                {
                    if (txtBarCode.Text == "")
                    {
                        txtBarCode.Text = "TANIMSIZ";
                    }

                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    Response resp = new Response();
                    string Val = txtItemCode.Text;
                    resp = aIFTerminalServiceSoapClient.GetProductByItemCode(Giris._dbName, Val, Giris.mKodValue);
                    txtPartili.Text = resp._list.Rows[0]["Partili"].ToString();
                    txtOlcuBirimi.Text = resp._list.Rows[0]["Ölçü Birimi"].ToString();
                    //btnAdd.PerformClick();
                    SelectList.dialogResult = "";
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtWhsCode_Click(object sender, EventArgs e)
        {
            try
            {
                SelectList nesne = new SelectList("DepoSayimi", "DepoAra", "DEPO ARAMA", txtWhsCode, txtWhsName, txtDepoYeriZorunlu);
                nesne.ShowDialog();
                nesne.Dispose();
                GC.Collect();

                if (SelectList.dialogResult == "Ok")
                {
                    SelectList.dialogResult = "";
                }
            }
            catch (Exception)
            {
            }
        }

        private void DepoSayimi_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            txtCountingQty.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;

            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                tableLayoutPanel1.RowStyles[5].Height = 0;
            }

            dtDetay.Clear();
            dtgDetay.DataSource = null;
            depoSayimiDetaylars = new List<DepoSayimiDetaylar>();
            depoSayimiPartilers = new List<DepoSayimiPartiler>();
            listeleDocEntry = 0;
            if (dtDetay.Columns.Count == 0)
            {
                dtDetay.Columns.Add("Barkod", typeof(string));
                dtDetay.Columns.Add("Ürün Kodu", typeof(string));
                dtDetay.Columns.Add("Ürün Adı", typeof(string));
                dtDetay.Columns.Add("Depo Kodu", typeof(string));
                dtDetay.Columns.Add("Depo Adı", typeof(string));
                dtDetay.Columns.Add("Miktar", typeof(double));
                dtDetay.Columns.Add("Partili", typeof(string));
                dtDetay.Columns.Add("Ölçü Birimi", typeof(string));
                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    dtDetay.Columns.Add("DepoYeriId", typeof(string));
                    dtDetay.Columns.Add("DepoYeriAdi", typeof(string));
                }
            }

            dtgDetay.DataSource = dtDetay;

            dtgDetay.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

            dtgDetay.Columns["Barkod"].HeaderText = "BARKOD";
            dtgDetay.Columns["Ürün Kodu"].HeaderText = "KOD";
            dtgDetay.Columns["Ürün Adı"].HeaderText = "TANIM";
            dtgDetay.Columns["Depo Kodu"].HeaderText = "DEPO";
            dtgDetay.Columns["Depo Adı"].HeaderText = "DEPO ADI";
            dtgDetay.Columns["Miktar"].HeaderText = "MKT";
            dtgDetay.Columns["Partili"].HeaderText = "PARTİLİ";
            dtgDetay.Columns["Ölçü Birimi"].HeaderText = "BRM";

            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                dtgDetay.Columns["DepoYeriId"].HeaderText = "DEPO YERI";
                dtgDetay.Columns["DepoYeriAdi"].HeaderText = "D.YERI";

                dtgDetay.Columns["DepoYeriId"].Visible = false;
            }

            dtgDetay.Columns["Depo adı"].Visible = false;
            dtgDetay.Columns["Partili"].Visible = false;
            dtgDetay.Columns["Barkod"].Visible = false;
            dtgDetay.RowTemplate.Height = 55;
            dtgDetay.ColumnHeadersHeight = 60;

            //dtgDetay.Columns["Barkod"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetay.Columns["Ürün Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetay.Columns["Depo Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtgDetay.Columns["Depo Adı"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetay.Columns["Ölçü Birimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetay.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtgDetay.Columns["Partili"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                dtgDetay.Columns["DepoYeriId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDetay.Columns["DepoYeriAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dtgDetay.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            #region içerideki sayımın kontrolü

            //AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            //var resp = aIFTerminalServiceSoapClient.getCountingCustomTable(Giris._dbName);

            //if (resp._list != null)
            //{
            //    CustomMsgBox.Show("DEVAM EDEN SAYIM LİSTENİZ BULUNMAKTADIR.", "UYARI", "TAMAM", "");

            //    //DepoSayimi_5 depoSayimi_5 = new DepoSayimi_5("LİSTE");
            //    //depoSayimi_5.ShowDialog();

            //    btnListe.PerformClick();
            //}

            #endregion içerideki sayımın kontrolü

            SayimKontrolu();

            vScrollBar1.Maximum = dtgDetay.RowCount + 5;
        }

        public static int satirNumarasi = 0;

        private void btnSay_Click(object sender, EventArgs e)
        {
            try
            {
                bool kontrol = false;
                if (txtItemCode.Text == "")
                {
                    CustomMsgBox.Show("LÜTFEN ÜRÜN SEÇİMİ YAPINIZ", "UYARI", "TAMAM", "");
                    return;
                }

                if (txtWhsCode.Text == "")
                {
                    CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ", "UYARI", "TAMAM", "");
                    return;
                }

                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    if (txtDepoYeriZorunlu.Text == "Y")
                    {
                        if (txtDepoYeriId.Text == "")
                        {
                            CustomMsgBox.Show("DEPO İÇİN DEPO YERI ZORUNLUDUR. LÜTFEN SEÇİM YAPINIZ.", "UYARI", "TAMAM", "");
                            return;
                        }
                    }
                }

                var sayilanMiktar = txtCountingQty.Value.ToString() == "" ? 0 : Convert.ToDouble(txtCountingQty.Value);

                if (sayilanMiktar == 0)
                {
                    CustomMsgBox.Show("LÜTFEN SAYILAN MİKTAR GİRİŞİ YAPINIZ", "UYARI", "TAMAM", "");
                    return;
                }

                double sMiktar = 0;
                var ItemCode = txtItemCode.Text;

                #region satırda kalem varsa üzerine ekle -- kaldırıldı

                //var exist = dtDetay.AsEnumerable().Where(x => x.Field<string>("Ürün Kodu") == ItemCode && x.Field<string>("Depo Kodu") == txtWhsCode.Text).ToList();

                //if (exist.Count > 0)
                //{
                //    var miktar = dtDetay.AsEnumerable().Where(x => x.Field<string>("Ürün Kodu") == ItemCode && x.Field<string>("Depo Kodu") == txtWhsCode.Text).Select(y => y.Field<double>("Miktar")).FirstOrDefault();
                //    var detay = dtDetay.AsEnumerable().Where(x => x.Field<string>("Ürün Kodu") == ItemCode && x.Field<string>("Depo Kodu") == txtWhsCode.Text).ToList();

                //    foreach (var row in detay)
                //    {
                //        row.SetField("Miktar", miktar + sayilanMiktar);
                //    }

                //    depoSayimiDetaylars.Where(x => x.UrunKodu == ItemCode && x.DepoKodu == txtWhsCode.Text).ToList().ForEach(y => y.Miktar = miktar + sayilanMiktar);
                //    sMiktar = miktar + sayilanMiktar;
                //    kontrol = true;
                //}
                //else
                //{
                //    DataRow dr = dtDetay.NewRow();
                //    dr["Barkod"] = txtBarCode.Text;
                //    dr["Ürün Kodu"] = txtItemCode.Text;
                //    dr["Ürün Adı"] = txtItemName.Text;
                //    dr["Depo Kodu"] = txtWhsCode.Text;
                //    dr["Depo Adı"] = txtWhsName.Text;
                //    dr["Miktar"] = Convert.ToDouble(txtCountingQty.Value);
                //    dr["Partili"] = txtPartili.Text;

                //    dtDetay.Rows.Add(dr);

                //    depoSayimiDetaylars.Add(new DepoSayimiDetaylar { Barkod = txtBarCode.Text, UrunKodu = txtItemCode.Text, UrunAdi = txtItemName.Text, DepoKodu = txtWhsCode.Text, DepoAdi = txtWhsName.Text, Miktar = Convert.ToDouble(txtCountingQty.Value), Partili = txtPartili.Text });
                //    sMiktar = Convert.ToDouble(txtCountingQty.Value);
                //}

                #endregion satırda kalem varsa üzerine ekle -- kaldırıldı

                DataRow dr = dtDetay.NewRow();
                dr["Barkod"] = txtBarCode.Text;
                dr["Ürün Kodu"] = txtItemCode.Text;
                dr["Ürün Adı"] = txtItemName.Text;
                dr["Depo Kodu"] = txtWhsCode.Text;
                dr["Depo Adı"] = txtWhsName.Text;
                dr["Miktar"] = Convert.ToDouble(txtCountingQty.Value);
                dr["Partili"] = txtPartili.Text;
                dr["Ölçü Birimi"] = txtOlcuBirimi.Text;
                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    dr["DepoYeriId"] = txtDepoYeriId.Text;
                    dr["DepoYeriAdi"] = txtDepoYeriAdi.Text;
                }
                dtDetay.Rows.Add(dr);

                depoSayimiDetaylars.Add(new DepoSayimiDetaylar { Barkod = txtBarCode.Text, UrunKodu = txtItemCode.Text, UrunAdi = txtItemName.Text, DepoKodu = txtWhsCode.Text, DepoAdi = txtWhsName.Text, Miktar = Convert.ToDouble(txtCountingQty.Value), Partili = txtPartili.Text, OlcuBirimi = txtOlcuBirimi.Text, DepoYeriId = txtDepoYeriId.Text, DepoYeriAdi = txtDepoYeriAdi.Text });
                sMiktar = Convert.ToDouble(txtCountingQty.Value);

                satirNumarasi = dtDetay.Rows.Count;

                if (txtPartili.Text == "Y")
                {
                    DataTable BatchDt = new DataTable();

                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                    var resp = aIFTerminalServiceSoapClient.GetBatchByItemCode(Giris._dbName, txtWhsCode.Text, txtItemCode.Text, Giris.mKodValue);

                    Response response = new Response();
                    if (kontrol)
                    {
                        var partivarmi = depoSayimiPartilers.Where(c => c.DepoKodu == txtWhsCode.Text && c.UrunKodu == txtItemCode.Text).ToList();

                        if (partivarmi.Count > 0)
                        {
                            foreach (var item in partivarmi)
                            {
                                var detay = resp._list.AsEnumerable().Where(x => x.Field<string>("BatchNum") == item.PartiNo).ToList();

                                foreach (var row in detay)
                                {
                                    double miktar = Convert.ToDouble(row.Field<decimal>("Quantity"));
                                    row.SetField("Quantity", miktar - Convert.ToDouble(item.Miktar));
                                }
                            }
                        }
                        response._list = resp._list.Copy();
                    }
                    else
                    {
                        #region sap partisini getirme kaldırıldı

                        //if (resp.Val == 0)
                        //{
                        //    response._list = resp._list.Copy();
                        //}
                        //else
                        //{
                        //    response._list = new DataTable();
                        //    response._list.Columns.Add("BatchNum", typeof(string));
                        //    response._list.Columns.Add("Quantity", typeof(decimal));
                        //}

                        #endregion sap partisini getirme kaldırıldı

                        response._list = new DataTable();
                        response._list.Columns.Add("BatchNum", typeof(string));
                        response._list.Columns.Add("Quantity", typeof(decimal));

                        //response._list.Clear();
                        //foreach (var item in depoSayimiPartilers.Where(x => x.UrunKodu == txtItemCode.Text && x.DepoKodu == txtWhsCode.Text))
                        //{
                        //    DataRow dr = response._list.NewRow();
                        //    dr["ItemCode"] = item.UrunKodu;
                        //    dr["WhsCode"] = item.DepoKodu;
                        //    dr["BatchNum"] = item.PartiNo;
                        //    dr["Quantity"] = item.Miktar;

                        //    response._list.Rows.Add(dr);
                        //}
                    }

                    if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                    {
                        DepoSayimi_4 depoSayimi_4 = new DepoSayimi_4(response._list, sMiktar, txtItemCode.Text, txtWhsCode.Text, "DEPO SAYIMI", txtOlcuBirimi.Text, txtPartili.Text, partino);
                        depoSayimi_4.ShowDialog();
                        depoSayimi_4.Dispose();
                        GC.Collect();
                    }
                    else
                    {
                        DepoSayimi_4 depoSayimi_4 = new DepoSayimi_4(response._list, sMiktar, txtItemCode.Text, txtWhsCode.Text, "DEPO SAYIMI", txtOlcuBirimi.Text, txtPartili.Text);
                        depoSayimi_4.ShowDialog();
                        depoSayimi_4.Dispose();
                        GC.Collect();
                    }

                    if (DepoSayimi_4.dialogResult != "Ok")
                    {
                        dtDetay.Rows.RemoveAt(dtgDetay.Rows.Count - 1);
                    }
                    else
                    {
                        if (depoSayimiPartilers.Where(x => x.SatirNumarasi == satirNumarasi).Count() > 0)
                        {
                            dtgDetay.Rows[satirNumarasi - 1].Cells["Miktar"].Value = depoSayimiPartilers.Where(x => x.SatirNumarasi == satirNumarasi).Sum(y => y.Miktar);
                        }
                        else
                        {
                            dtgDetay.Rows[satirNumarasi - 1].Cells["Miktar"].Value = sMiktar;
                        }
                    }
                }

                Temizle();
                txtBarCode.Focus();

                vScrollBar1.Maximum = dtgDetay.RowCount + 5;
            }
            catch (Exception ex)
            {
            }
        }

        private void Temizle()
        {
            txtBarCode.Text = "";
            txtItemName.Text = "";
            txtItemCode.Text = "";
            //txtWhsCode.Text = "";
            //txtWhsName.Text = "";
            txtCountingQty.Value = 1;
            txtPartili.Text = "";
            txtOlcuBirimi.Text = "";
        }

        public static List<DepoSayimiDetaylar> depoSayimiDetaylars = new List<DepoSayimiDetaylar>();
        public static List<DepoSayimiPartiler> depoSayimiPartilers = new List<DepoSayimiPartiler>();

        public class DepoSayimiDetaylar
        {
            public string Barkod { get; set; }

            public string UrunKodu { get; set; }

            public string UrunAdi { get; set; }

            public string DepoKodu { get; set; }

            public string DepoAdi { get; set; }

            public string DepoYeriId { get; set; }

            public string DepoYeriAdi { get; set; }

            public double Miktar { get; set; }

            public string Partili { get; set; }

            public string OlcuBirimi { get; set; }
        }

        public class DepoSayimiPartiler
        {
            public string PartiNo { get; set; }

            public string UrunKodu { get; set; }

            public string DepoKodu { get; set; }

            public double Miktar { get; set; }

            public int SatirNumarasi { get; set; }
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            DepoSayimi_2 depoSayimi_2 = new DepoSayimi_2(false, "", "", "SAYIM FİŞİ", dtgDetay);
            depoSayimi_2.ShowDialog();
            depoSayimi_2.Dispose();
            GC.Collect();
        }

        private void dtgDetay_DoubleClick(object sender, EventArgs e)
        {
            //var depokodu = dtgDetay.Rows[e.].
        }

        private void dtgDetay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string UrunKodu = dtgDetay.Rows[e.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                string DepoKodu = dtgDetay.Rows[e.RowIndex].Cells["Depo Kodu"].Value.ToString();
                double SayilanMiktar = dtgDetay.Rows[e.RowIndex].Cells["Miktar"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgDetay.Rows[e.RowIndex].Cells["Miktar"].Value);
                string olcuBirimi = dtgDetay.Rows[e.RowIndex].Cells["Ölçü Birimi"].Value.ToString();

                txtPartili.Text = dtgDetay.Rows[e.RowIndex].Cells["Partili"].Value.ToString();
                satirNumarasi = dtDetay.Rows.Count;
                DataTable dtlist = new DataTable();

                dtlist = new DataTable();
                dtlist.Columns.Add("ItemCode", typeof(string));
                dtlist.Columns.Add("ItemName", typeof(string));
                dtlist.Columns.Add("BatchNum", typeof(string));
                dtlist.Columns.Add("WhsCode", typeof(string));
                dtlist.Columns.Add("WhsName", typeof(string));
                dtlist.Columns.Add("Quantity", typeof(decimal));

                foreach (var item in depoSayimiPartilers.Where(x => x.SatirNumarasi == e.RowIndex + 1))
                {
                    DataRow dr = dtlist.NewRow();
                    dr["ItemCode"] = item.UrunKodu;
                    dr["WhsCode"] = item.DepoKodu;
                    dr["BatchNum"] = item.PartiNo;
                    dr["Quantity"] = item.Miktar;

                    dtlist.Rows.Add(dr);
                }

                satirNumarasi = e.RowIndex + 1;
                DepoSayimi_4 depoSayimi_4 = new DepoSayimi_4(dtlist, SayilanMiktar, UrunKodu, DepoKodu, "DEPO SAYIMI", olcuBirimi, txtPartili.Text);
                depoSayimi_4.ShowDialog();
                depoSayimi_4.Dispose();
                GC.Collect();

                #region 4.ekrandan gelen miktar

                if (txtPartili.Text == "Y")
                {
                    if (DepoSayimi_4.dialogResult == "Ok")
                    {
                        //var sumQty = Convert.ToDouble(resp._list.AsEnumerable().Select(z => z.Field<decimal>("Quantity")).Sum());

                        //foreach (var item in depoSayimiPartilers.Where(x => x.SatirNumarasi == satirNumarasi))
                        //{
                        dtgDetay.Rows[satirNumarasi - 1].Cells["Miktar"].Value = depoSayimiPartilers.Where(x => x.SatirNumarasi == satirNumarasi).Sum(y => y.Miktar);
                        //}
                        DepoSayimi_4.dialogResult = "";

                        //dtgDetay.Rows[currentRow -1].Cells["Miktar"].Value = Convert.ToDouble(sumQty);
                    }
                }
                else
                {
                    if (DepoSayimi_4.dialogResult == "Ok")
                    {
                        dtgDetay.Rows[satirNumarasi - 1].Cells["Miktar"].Value = DepoSayimi_4.partisizmiktar;
                        DepoSayimi_4.partisizmiktar = 0;
                        DepoSayimi_4.dialogResult = "";
                    }
                }
                #endregion 4.ekrandan gelen miktar

            }

            catch (Exception ex)
            {
            }

            #region Eski

            //try
            //{
            //    string UrunKodu = dtgDetay.Rows[e.RowIndex].Cells["Ürün Kodu"].Value.ToString();
            //    string DepoKodu = dtgDetay.Rows[e.RowIndex].Cells["Depo Kodu"].Value.ToString();
            //    double SayilanMiktar = dtgDetay.Rows[e.RowIndex].Cells["Miktar"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgDetay.Rows[e.RowIndex].Cells["Miktar"].Value);
            //    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            //    var resp = aIFTerminalServiceSoapClient.GetBatchByItemCode(Giris._dbName, DepoKodu, UrunKodu);

            //    Response response = new Response();
            //    if (response.Val == 0)
            //    {
            //        if (resp._list != null)
            //        {
            //            response._list = resp._list.Copy();
            //        }
            //        else
            //        {
            //            response._list = new DataTable();
            //            response._list.Columns.Add("ItemCode", typeof(string));
            //            response._list.Columns.Add("ItemName", typeof(string));
            //            response._list.Columns.Add("BatchNum", typeof(string));
            //            response._list.Columns.Add("WhsCode", typeof(string));
            //            response._list.Columns.Add("WhsName", typeof(string));
            //            response._list.Columns.Add("Quantity", typeof(decimal));
            //        }

            //        var aa = depoSayimiPartilers.Where(x => x.UrunKodu == UrunKodu && x.DepoKodu == DepoKodu).ToList();

            //        response._list.Clear();
            //        //foreach (var item in depoSayimiPartilers.Where(x => x.UrunKodu == UrunKodu && x.DepoKodu == DepoKodu))
            //        foreach (var item in depoSayimiPartilers.Where(x => x.SatirNumarasi == e.RowIndex + 1))
            //        {
            //            DataRow dr = response._list.NewRow();
            //            dr["ItemCode"] = item.UrunKodu;
            //            dr["WhsCode"] = item.DepoKodu;
            //            dr["BatchNum"] = item.PartiNo;
            //            dr["Quantity"] = item.Miktar;

            //            response._list.Rows.Add(dr);
            //        }

            //        satirNumarasi = e.RowIndex + 1;
            //        DepoSayimi_4 depoSayimi_4 = new DepoSayimi_4(response._list, SayilanMiktar, UrunKodu, DepoKodu, "DEPO SAYIMI");
            //        depoSayimi_4.ShowDialog();

            //        #region 4.ekrandan gelen miktar
            //        if (DepoSayimi_4.dialogResult == "Ok")
            //        {
            //            //var sumQty = Convert.ToDouble(resp._list.AsEnumerable().Select(z => z.Field<decimal>("Quantity")).Sum());

            //            //foreach (var item in depoSayimiPartilers.Where(x => x.SatirNumarasi == satirNumarasi))
            //            //{
            //            dtgDetay.Rows[satirNumarasi - 1].Cells["Miktar"].Value = depoSayimiPartilers.Where(x => x.SatirNumarasi == satirNumarasi).Sum(y => y.Miktar);
            //            //}

            //            //dtgDetay.Rows[currentRow -1].Cells["Miktar"].Value = Convert.ToDouble(sumQty);
            //        }
            //        #endregion
            //    }
            //    else
            //    {
            //        CustomMsgBox.Show(response.Desc, "UYARI", "TAMAM", "");
            //    }

            //    //DepoSayimi_2 depoSayimi_2 = new DepoSayimi_2(true, UrunKodu, DepoKodu);
            //    //depoSayimi_2.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //}

            #endregion Eski
        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDetay.Rows.Count == 0)
                {
                    //ne uyarısı yazılabilir buraya?
                    //CustomMsgBox.Show("Lütfen Çıkış Depo Seçimi Yapınız.", "Uyarı", "Tamam", "");
                    return;
                }
                //if (txtBarCode.Text == "")
                //{
                //    CustomMsgBox.Show("Lütfen Barkod Girişi Yapınız.", "Uyarı", "Tamam", "");
                //    txtBarCode.Focus();
                //    return;
                //}
                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                    return;
                }
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();
                StockCounting stockCounting = new StockCounting();
                StockCountingLines stockCountingLines = new StockCountingLines();
                List<StockCountingLines> stockCountingLines1 = new List<StockCountingLines>();
                StockCountingParties stockCountingParties = new StockCountingParties();
                List<StockCountingParties> stockCountingParties1 = new List<StockCountingParties>();

                stockCounting.SayimTarihi = dtpSayimTarihi.Value.ToString("yyyyMMdd");
                stockCounting.KullaniciId = Giris._userCode;
                stockCounting.Aciklama = txtAciklama.Text;
                stockCounting.VarolanSayimaDevamEdilmekIstendi = varolanSayimaDevametmekIstendi;
                stockCounting.BelgeNo = txtBelgeNo.Text;
                for (int i = 0; i <= dtgDetay.Rows.Count - 1; i++)
                {
                    stockCountingLines = new StockCountingLines();
                    var barkod = dtgDetay.Rows[i].Cells["Barkod"].Value.ToString();
                    var kalemKodu = dtgDetay.Rows[i].Cells["Ürün Kodu"].Value.ToString();
                    var kalemAdi = dtgDetay.Rows[i].Cells["Ürün Adı"].Value.ToString();
                    var depoKodu = dtgDetay.Rows[i].Cells["Depo Kodu"].Value.ToString();
                    var depoAdi = dtgDetay.Rows[i].Cells["Depo Adı"].Value.ToString();
                    var miktar = Convert.ToDouble(dtgDetay.Rows[i].Cells["Miktar"].Value);
                    var olcuBirimi = dtgDetay.Rows[i].Cells["Ölçü Birimi"].Value.ToString();
                    var depoYeriId = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgDetay.Rows[i].Cells["DepoYeriId"].Value.ToString() : "";
                    var depoYeriAdi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgDetay.Rows[i].Cells["DepoYeriAdi"].Value.ToString() : "";

                    stockCountingLines.Barkod = barkod;
                    stockCountingLines.KalemKodu = kalemKodu;
                    stockCountingLines.KalemTanimi = kalemAdi;
                    stockCountingLines.DepoKodu = depoKodu;
                    stockCountingLines.DepoAdi = depoAdi;
                    stockCountingLines.Miktar = miktar;
                    stockCountingLines.OlcuBirimi = olcuBirimi;
                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        stockCountingLines.DepoYeriId = depoYeriId;
                        stockCountingLines.DepoYeriAdi = depoYeriAdi;
                    }

                    stockCountingLines1.Add(stockCountingLines);
                }

                stockCounting.stockCountings = stockCountingLines1.ToArray();

                foreach (var item in depoSayimiPartilers)
                {
                    stockCountingParties = new StockCountingParties();

                    stockCountingParties.DepoKodu = item.DepoKodu;
                    stockCountingParties.KalemKodu = item.UrunKodu;
                    stockCountingParties.Miktar = item.Miktar;
                    stockCountingParties.PartiNo = item.PartiNo;

                    stockCountingParties1.Add(stockCountingParties);
                }

                stockCounting.StockCountingParties = stockCountingParties1.ToArray();

                var aa = aIFTerminalServiceSoapClient1.AddOrUpdateStockCounting(Giris._dbName, stockCounting);

                if (aa.Val == 0)
                {
                    CustomMsgBox.Show("İŞLEM BAŞARI İLE GERÇEKLEŞTİRİLDİ.", "UYARI", "TAMAM", "");
                    Close();
                }
                else
                {
                    CustomMsgBox.Show("HATA OLUŞTU." + aa.Desc, "UYARI", "TAMAM", "");
                }
            }
            catch (Exception)
            {
            }
            dtgDetay.Refresh();
        }

        public static DataTable listelemeDt = new DataTable();
        public static int listeleDocEntry = 0;
        public static DateTime listeleTarih = DateTime.Now;
        private bool listeacildi = false;
        private string varolanSayimaDevametmekIstendi = "N";
        private string tarih = "";

        private void btnListe_Click(object sender, EventArgs e)
        {
            try
            {
                depoSayimiDetaylars = new List<DepoSayimiDetaylar>();
                depoSayimiPartilers = new List<DepoSayimiPartiler>();

                #region içerideki sayımın kontrolü

                //AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                //var resp6 = aIFTerminalServiceSoapClient.getCountingCustomTable(Giris._dbName);

                //if (resp6._list == null)
                //{
                //    CustomMsgBox.Show("LİSTELENECEK SAYIM BULUNAMADI.", "UYARI", "TAMAM", "");
                //    return;
                //}

                #endregion içerideki sayımın kontrolü

                if (varolanSayimaDevametmekIstendi == "N")
                {
                    DepoSayimi_5 depoSayimi_5 = new DepoSayimi_5("LİSTE", tarih);
                    depoSayimi_5.ShowDialog();
                    depoSayimi_5.Dispose();
                    GC.Collect();
                    tarih = "";
                }
                else
                {
                    if (listeleDocEntry == 0)
                    {
                        DepoSayimi_5 depoSayimi_5 = new DepoSayimi_5("LİSTE", "");
                        depoSayimi_5.ShowDialog();
                        depoSayimi_5.Dispose();
                        GC.Collect();
                    }
                }

                //if (DepoSayimi_5.dialogResult5 == "Ok")
                //{
                //    DepoSayimi_5.dialogResult5 = "";
                //}
                //else
                //{
                //    Menu menu = new Menu(Giris._userCode, Giris._dbName);
                //    menu.ShowDialog();
                //    Close();
                //}

                if (listeleDocEntry > 0)
                {
                    txtBelgeNo.Text = listeleDocEntry.ToString();
                    if (varolanSayimaDevametmekIstendi != "Y")
                    {
                        txtAciklama.Text = DepoSayimi_5.aciklama;
                        //txtBelgeNo.Text = "";
                    }

                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    var resp = aIFTerminalServiceSoapClient.getLinesCountingCustomTableByDocEntry(Giris._dbName, listeleDocEntry, Giris.mKodValue);

                    if (resp.Val == 0)
                    {
                        resp._list.Columns.Add("Partili", typeof(string));
                        foreach (DataRow dr in resp._list.Rows)
                        {
                            var itemCode = dr["Ürün Kodu"].ToString();
                            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();
                            var respItemCode = aIFTerminalServiceSoapClient1.GetProductByItemCode(Giris._dbName, itemCode, Giris.mKodValue);

                            if (respItemCode.Val == 0)
                            {
                                dr["Partili"] = respItemCode._list.Rows[0]["Partili"].ToString();
                            }

                            //depoSayimiDetaylars.RemoveAll(x => x.UrunKodu == itemCode);

                            //depoSayimiDetaylars.Add(new DepoSayimiDetaylar { Barkod = dr["Barkod"].ToString(), UrunKodu = dr["Ürün Kodu"].ToString(), UrunAdi = dr["Ürün Adı"].ToString(), DepoKodu = dr["Depo Kodu"].ToString(), DepoAdi = dr["Depo Adı"].ToString(), Miktar = Convert.ToDouble(dr["Miktar"].ToString()), Partili = dr["Partili"].ToString(), OlcuBirimi = dr["Ölçü Birimi"].ToString() });
                        }

                        dtDetay = resp._list.Copy();
                        dtgDetay.DataSource = dtDetay;

                        if (Giris.genelParametreler.DepoYeriCalisir != "Y")
                        {
                            dtgDetay.Columns["DepoYeriId"].Visible = false;
                            dtgDetay.Columns["DepoYeriAdi"].Visible = false;
                        }

                        if (resp._list.Rows[0]["Açıklama"].ToString() != null)
                        {
                            txtAciklama.Text = resp._list.Rows[0]["Açıklama"].ToString();//c
                        }
                        dtpSayimTarihi.Value = listeleTarih;

                        if (dtgDetay.Rows.Count > 0)
                        {
                            dtgDetay.Rows[0].Selected = false;
                        }
                    }

                    aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    var resp2 = aIFTerminalServiceSoapClient.getPartiesCountingCustomTableByDocEntry(Giris._dbName, listeleDocEntry, Giris.mKodValue);

                    if (resp2.Val == 0)
                    {
                        int i = 1;
                        foreach (DataRow dr in resp2._list.Rows)
                        {
                            depoSayimiPartilers.Add(new DepoSayimiPartiler
                            {
                                UrunKodu = dr["Ürün Kodu"].ToString(),
                                Miktar = Convert.ToDouble(dr["Miktar"]),
                                DepoKodu = dr["Depo Kodu"].ToString(),
                                PartiNo = dr["Parti No"].ToString(),
                                SatirNumarasi = i,
                            }); ;
                            i++;
                        }
                    }

                    //dtgDetay.Columns["Barkod"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgDetay.Columns["Ürün Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgDetay.Columns["Depo Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dtgDetay.Columns["Depo Adı"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgDetay.Columns["Ölçü Birimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgDetay.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dtgDetay.Columns["Partili"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                    dtgDetay.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dtgDetay.Columns["Açıklama"].Visible = false;

                    listeleDocEntry = 0;
                }
                vScrollBar1.Maximum = dtgDetay.RowCount + 5;
            }
            catch (Exception)
            {
            }
        }

        private void dtgDetay_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                vScrollBar1.Value = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgDetay.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        public static int currentRow;

        private void dtgDetay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentRow = e.RowIndex;
            }
        }

        private void btnRowDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDetay.DataSource == null)
                {
                    return;
                }
                if (currentRow > -1)
                {
                    if (dtgDetay.CurrentCell != null)
                    {
                        satirNumarasi = dtgDetay.CurrentCell.RowIndex;
                        DialogResult resp = CustomMsgBtn.Show("SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ?", "Uyarı", "EVET", "HAYIR");

                        if (CustomMsgBtn.result == DialogResult.Yes)
                        {
                            var urunKodu = dtgDetay.Rows[currentRow].Cells["Ürün Kodu"].Value.ToString();
                            var depoKodu = dtgDetay.Rows[currentRow].Cells["Depo Kodu"].Value.ToString();
                            dtgDetay.Rows.RemoveAt(currentRow);
                            dtgDetay.Refresh();

                            //depoSayimiPartilers.RemoveAll(x => x.UrunKodu == urunKodu && x.DepoKodu == depoKodu);
                            depoSayimiPartilers.RemoveAll(x => x.SatirNumarasi == satirNumarasi + 1);

                            depoSayimiPartilers.Where(u => u.SatirNumarasi > satirNumarasi + 1).ToList().ForEach(x => x.SatirNumarasi = x.SatirNumarasi - 1);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtDepoYeriAdi_Click(object sender, EventArgs e)
        {
            try
            {
                SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtDepoYeriId, txtDepoYeriAdi, txtWhsCode);
                nesne.ShowDialog();
                nesne.Dispose();
                GC.Collect();

                if (SelectList.dialogResult == "Ok")
                {
                    SelectList.dialogResult = "";
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtCountingQty_Click(object sender, EventArgs e)
        {
            #region ondalık hatası için eklendi

            double counting = parseNumber_Seperator.ConvertToDouble(txtCountingQty.Value.ToString());
            txtCountingQty.Value = Convert.ToDecimal(counting);

            #endregion ondalık hatası için eklendi

            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtCountingQty, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }

        private void SayimKontrolu()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            var resp = aIFTerminalServiceSoapClient.getCountingCustomTableByDate(Giris._dbName, Giris._userCode, DateTime.Now.ToString("yyyyMMdd"), Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    if (resp._list.Rows.Count == 1)
                    {
                        DialogResult dialog = new DialogResult();
                        dialog = CustomMsgBtn.Show("BUGÜN İÇİN DEVAM EDEN SAYIMINIZ BULUNMAKTADIR. DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                        if (dialog == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            varolanSayimaDevametmekIstendi = "Y";
                            listeleDocEntry = Convert.ToInt32(resp._list.Rows[0][0]);
                            txtAciklama.Text = resp._list.Rows[0]["Açıklama"].ToString();
                            txtBelgeNo.Text = "";//c
                            btnListe.PerformClick();
                        }
                    }
                    else if (resp._list.Rows.Count > 1)
                    {
                        CustomMsgBox.Show("BİRDEN FAZLA SAYIM LİSTESİ OLDUĞUNDAN LİSTE AÇILIYOR.", "UYARI", "TAMAM", "");
                        tarih = DateTime.Now.ToString("yyyyMMdd");
                        varolanSayimaDevametmekIstendi = "Y"; //c
                        txtBelgeNo.Text = "";//c
                        btnListe.PerformClick();
                    }
                }
            }
            vScrollBar1.Maximum = dtgDetay.RowCount + 5;
            if (dtgDetay.RowCount > 0)
            {
                dtgDetay.Columns["Açıklama"].Visible = false;
            }
        }
    }
}