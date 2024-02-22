using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
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
    public partial class IadeTalebi_2 : form_Base
    {
        //start font.
        public int initialWidth; 
        public int initialHeight;
        public float initialFontSize;
        //end font
        private string formName = "";
        private Color defaultColor = Color.White;

        private List<IadeTalepleri> iadeTalepleris = new List<IadeTalepleri>();
        private DataTable dtDetails = new DataTable();
         
        public static int sapLineNum = 0;
        public static int DocEntry = 0;
        private string depoKodu = "";
        private string itemCode = "";
        private string itemName = "";
        private string barcode = "";
        private string partili = "";
        private string depoTanimi = "";
        private string depoYeriId = "";
        private string depoYeriAdi = "";
        private double orderqty = 0;
        private double acceptqty = 0;
        private double paletIciKoliAD = 0;
        private double koliIciAD = 0;
        private double paletIciAD = 0;

        private double topMik = 0;
         
        public static int currentRow = 0; 

        private bool doubleclick = false; 

        public static string arananItemCode = "";
        private string partino = "";

        public static List<IadeTalepParti> iadeTalepPartis = new List<IadeTalepParti>(); 


        public IadeTalebi_2(List<IadeTalepleri> _iadeTalepleris, string _formName)
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

            iadeTalepleris = _iadeTalepleris;

            if (iadeTalepleris != null)
            {
                txtCardCode.Text = iadeTalepleris[0].CardCode;
                txtCardName.Text = iadeTalepleris[0].CardName;
                txtSevkAdres.Text = iadeTalepleris[0].SevkAdresi;

                var max = iadeTalepleris.OrderByDescending(t => t.TaxDate)
                   .FirstOrDefault();

                dtpOrderTaxDate.Value = new DateTime(Convert.ToInt32(max.TaxDate.Substring(0, 4)), Convert.ToInt32(max.TaxDate.Substring(4, 2)), Convert.ToInt32(max.TaxDate.Substring(6, 2)));
                dtpOrderDocDueDate.Value = new DateTime(Convert.ToInt32(max.DocDueDate.Substring(0, 4)), Convert.ToInt32(max.DocDueDate.Substring(4, 2)), Convert.ToInt32(max.DocDueDate.Substring(6, 2)));

                List<string> docEntryList = new List<string>();
                foreach (var item in iadeTalepleris)
                {
                    docEntryList.Add(item.DocEntry.ToString());
                }

                GetIadeTalepDetay(docEntryList);
            }
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

            label6.Font = new Font(label6.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label6.Font.Style);

            label7.Font = new Font(label7.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label7.Font.Style);
            label8.Font = new Font(label8.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label8.Font.Style);

            lblItemName.Font = new Font(lblItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemName.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtCardCode.Font = new Font(txtCardCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCardCode.Font.Style);

            txtCardName.Font = new Font(txtCardName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCardName.Font.Style);

            txtSevkAdres.Font = new Font(txtSevkAdres.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSevkAdres.Font.Style);

            dtpOrderDocDueDate.Font = new Font(dtpOrderDocDueDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpOrderDocDueDate.Font.Style);

            dtpOrderTaxDate.Font = new Font(dtpOrderTaxDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpOrderTaxDate.Font.Style);

            txtWayBillNo.Font = new Font(txtWayBillNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWayBillNo.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbItemName.Font.Style);

            btnDetay.Font = new Font(btnDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDetay.Font.Style);

            btnSearch.Font = new Font(btnSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSearch.Font.Style);

            btnAddOrUpdate.Font = new Font(btnAddOrUpdate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAddOrUpdate.Font.Style);

            btnBarkodGoster.Font = new Font(btnBarkodGoster.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBarkodGoster.Font.Style);

            dtgDetails.Font = new Font(dtgDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgDetails.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtCardCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtCardName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            dtpOrderDocDueDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpOrderTaxDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtWayBillNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtSevkAdres.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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
         
        private void IadeTalebi_2_Load(object sender, EventArgs e)
        {
            defaultColor = dtgDetails.Rows[0].Cells[0].Style.BackColor;
            //cmbItemName.Font = new Font("Tahoma", 26);

            iadeTalepPartis = new List<IadeTalepParti>();

            frmName.Text = formName.ToUpper();
            //btnColumnsWidth.Visible = false;
            txtBarCode.Focus();

            dtgDetails.Columns["btnDetail"].Visible = false;
            dtgDetails.Columns["Barkod"].Visible = false;
            dtgDetails.Columns["Partili"].Visible = false;
            dtgDetails.Columns["DepoKodu"].Visible = false;
            dtgDetails.Columns["SiraNo"].Visible = false;
            //new
            dtgDetails.Columns["BelgeNumarasi"].Visible = false;
            dtgDetails.Columns["KalemKodu"].Visible = false;

            dtgDetails.Columns["PaletIciKoliAD"].Visible = false;
            dtgDetails.Columns["KoliIciAD"].Visible = false;
            dtgDetails.Columns["PaletIciAD"].Visible = false;
            dtgDetails.Columns["MuhatapKatalogNo"].Visible = false;
            //dtgDetails.Columns["DepoTanimi"].Visible = false;

            //new

            dtgDetails.Columns["OlcuBirimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["ToplananMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["DepoMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["DepoTanimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["DepoYeriId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["DepoYeriAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dtgDetails.Columns["KalemAdi"].Width = dtgDetails.Width - dtgDetails.Columns["Miktar"].Width - dtgDetails.Columns["OlcuBirimi"].Width - dtgDetails.Columns["DepoKodu"].Width - dtgDetails.Columns["DepoMiktar"].Width - dtgDetails.Columns["DepoTanimi"].Width - dtgDetails.Columns["DepoYeriId"].Width - dtgDetails.Columns["DepoYeriAdi"].Width - dtgDetails.Columns["ToplananMiktar"].Width;
             

            dtgDetails.RowTemplate.Height = 55;
            dtgDetails.ColumnHeadersHeight = 60;

            vScrollBar1.Maximum = dtgDetails.RowCount + 5;
            if (dtgDetails.Rows.Count > 0)
            {
                dtgDetails.Rows[0].Selected = false;

                //for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                //{
                //    dtgDetails.Rows[i].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;

                //}
            }

            //btnColumnsWidth.PerformClick();
        }
        private void GetIadeTalepDetay(List<string> docentryList)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetIadeTalepDetay(Giris._dbName, docentryList.ToArray(), Giris.whsCodes.ToArray(), Giris.mKodValue);

            if (resp._list != null)
            {
                dtDetails = resp._list;
                dtgDetails.DataSource = null;

                dtDetails.Columns.Add("ToplananMiktar", typeof(double));
                dtDetails.Columns.Add("dtgSira", typeof(int));

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

                btn = new DataGridViewButtonColumn();
                dtgDetails.Columns.Add(btn);
                //dtgDetails.Columns[dtgDetails.ColumnCount - 1].DisplayIndex = dtgDetails.Columnscount-1;
                btn.HeaderText = "";
                btn.Text = "Detay";
                btn.Name = "btnDetail";

                btn.UseColumnTextForButtonValue = true;

                dtgDetails.DataSource = dtDetails;

                dtgDetails.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgDetails.Columns["ToplananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgDetails.Columns["DepoMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                 
                dtgDetails.Columns["BelgeNumarasi"].ReadOnly = true; 
                dtgDetails.Columns["KalemKodu"].ReadOnly = true;
                dtgDetails.Columns["KalemAdi"].ReadOnly = true;
                dtgDetails.Columns["Miktar"].ReadOnly = true;
                dtgDetails.Columns["OlcuBirimi"].ReadOnly = true; 
                dtgDetails.Columns["Partili"].ReadOnly = true;
                dtgDetails.Columns["Barkod"].ReadOnly = true;
                dtgDetails.Columns["DepoKodu"].ReadOnly = true;
                dtgDetails.Columns["SiraNo"].ReadOnly = true;
                dtgDetails.Columns["DepoMiktar"].ReadOnly = true;
                dtgDetails.Columns["KoliIciAD"].ReadOnly = true;
                dtgDetails.Columns["PaletIciAD"].ReadOnly = true;
                dtgDetails.Columns["PaletIciKoliAD"].ReadOnly = true;
                dtgDetails.Columns["MuhatapKatalogNo"].ReadOnly = true;
                dtgDetails.Columns["DepoTanimi"].ReadOnly = true;
                dtgDetails.Columns["DepoYeriId"].ReadOnly = true;
                dtgDetails.Columns["DepoYeriAdi"].ReadOnly = true;
                dtgDetails.Columns["ToplananMiktar"].ReadOnly = true;

                //dtgDetails.Columns["btnDetail"].DisplayIndex = 0;
                //dtgDetails.Columns["BelgeNumarasi"].DisplayIndex = 1;
                //dtgDetails.Columns["KalemKodu"].DisplayIndex = 2;
                //dtgDetails.Columns["KalemAdi"].DisplayIndex = 3;
                //dtgDetails.Columns["OlcuBirimi"].DisplayIndex = 4;//5
                //dtgDetails.Columns["Barkod"].DisplayIndex = 5;
                //dtgDetails.Columns["Miktar"].DisplayIndex = 6;//4
                //dtgDetails.Columns["ToplananMiktar"].DisplayIndex = 7;//11
                //dtgDetails.Columns["Partili"].DisplayIndex = 8;
                //dtgDetails.Columns["DepoKodu"].DisplayIndex = 9;
                //dtgDetails.Columns["SiraNo"].DisplayIndex = 10;
                //dtgDetails.Columns["DepoMiktar"].DisplayIndex = 11;//10
                //dtgDetails.Columns["MuhatapKatalogNo"].DisplayIndex = 12;
                //dtgDetails.Columns["DepoTanimi"].DisplayIndex = 13;
                //dtgDetails.Columns["DepoYeriId"].DisplayIndex = 14;
                //dtgDetails.Columns["DepoYeriAdi"].DisplayIndex = 15;

                dtgDetails.Columns["BelgeNumarasi"].HeaderText = "BELGE NO";
                dtgDetails.Columns["KalemKodu"].HeaderText = "KALEM KODU";
                dtgDetails.Columns["KalemAdi"].HeaderText = "KALEM ADI";
                dtgDetails.Columns["OlcuBirimi"].HeaderText = "BRM";
                dtgDetails.Columns["ToplananMiktar"].HeaderText = "İADE MİK";
                dtgDetails.Columns["Barkod"].HeaderText = "BARKOD";
                dtgDetails.Columns["Miktar"].HeaderText = "TALEP MİK";
                dtgDetails.Columns["DepoMiktar"].HeaderText = "STOK";
                dtgDetails.Columns["MuhatapKatalogNo"].HeaderText = "KAT.NO";
                dtgDetails.Columns["DepoTanimi"].HeaderText = "DEPO TAN.";

                dtgDetails.Columns["ToplananMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDetails.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDetails.Columns["DepoMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (Giris.genelParametreler.DepoYeriCalisir != "Y")
                {
                    dtgDetails.Columns["DepoYeriId"].Visible = false;
                    dtgDetails.Columns["DepoYeriAdi"].Visible = false;
                }
                dtgDetails.RowTemplate.Height = 55;

                //dtgDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgDetails.AutoResizeRows();
                //dtgDetails.AutoResizeColumns();

                //vScrollBar1.Maximum = dtgDetails.RowCount = + 5;
                //for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                //{
                //    var partili = dtgDetails.Rows[i].Cells["Partili"].Value;

                //    if (partili.ToString() == "Y")
                //    {
                //        dtgDetails.Rows[i].Cells["Toplanan Miktar"].ReadOnly = true;
                //    }
                //}

                for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                {
                    dtgDetails.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                }
                dtgDetails.Columns["dtgSira"].Visible = false;

                foreach (DataGridViewColumn column in dtgDetails.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (dtgDetails.Rows.Count > 0)
                {
                    dtgDetails.Rows[0].Selected = false;
                }
                //dtgDetails.Columns["KalemAdi"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgDetails.AutoResizeRows();
            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
        }
        private void btnDetay_Click(object sender, EventArgs e)
        {
            try
            {
                string ItemCode = "";
                //string partili = "";
                //string wareHouse = cmbWareHouse.SelectedValue == null ? "" : cmbWareHouse.SelectedValue.ToString();
                //double warehouseQty = 0;

                //if (wareHouse == "")
                //{
                //    CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                //    return;
                //}
                List<dynamic> list = new List<dynamic>();
                string Val = txtBarCode.Text;
                partino = Giris.UrunKoduBarkod(txtBarCode.Text, "Parti");
                Val = Giris.UrunKoduBarkod(txtBarCode.Text, "Barkod");
                if (Val == "")
                {
                    CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "Tamam", "");
                    return;
                }

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = new Response();

                if (Val != "TANIMSIZ")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, depoKodu, Giris.mKodValue);
                }
                else
                {
                    if (arananItemCode != "")
                    {
                        Val = arananItemCode;
                    }
                    else
                    {
                        Val = "";
                    }
                }

                if (resp._list == null)
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, depoKodu, txtCardCode.Text, Giris.mKodValue);
                }

                if (resp._list != null)
                {
                    foreach (DataRow item in resp._list.Rows)
                    {
                        DataRow dr = dtDetails.NewRow();
                        dr["KalemKodu"] = item["Kalem Kodu"];
                        dr["KalemAdi"] = item["Kalem Tanımı"];
                        dr["Barkod"] = item["Barkod"];
                        dr["OlcuBirimi"] = item["Ölçü Birimi"];
                        //dr["Müşteri Kodu"] = txtCardCode.Text.ToString();
                        dr["DepoMiktar"] = item["Depo Miktari"];
                        dr["Partili"] = item["Partili"];

                        //dr["PaletIciKoliAD"] = item["PaletIciKoliAD"];
                        //dr["KoliIciAD"] = item["KoliIciAD"];
                        //dr["PaletIciAD"] = item["PaletIciAD"];
                        //dr["DepoKodu"] = wareHouse;
                        partili = item["Partili"].ToString();

                        ItemCode = item["Kalem Kodu"].ToString();

                        list.Add(item["Kalem Kodu"]);
                        list.Add(item["Kalem Tanımı"]);
                        list.Add(item["Barkod"]);
                        list.Add(item["Ölçü Birimi"]);
                        list.Add(txtCardCode.Text);
                        //if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                        //{
                        list.Add(partino);
                        partino = "";
                        //}

                        list.Add(depoKodu);

                        //list.Add(item["Depo Miktari"]);

                        //list.Add(item["PaletIciKoliAD"]);
                        //list.Add(item["KoliIciAD"]);
                        //list.Add(item["PaletIciAD"]);

                        //if (dtgDetails.Columns.Contains("DepoKodu") != true)
                        //{
                        //    addcombo();
                        //    dtgProducts.Columns["DepoKodu"].ReadOnly = false;
                        //}

                        //if (!doubleclick)
                        //{
                        //    dtDetails.Rows.Add(dr);
                        //}

                        //dtProducts.AcceptChanges();
                        //(dtgDetails.Rows[dtgDetails.Rows.Count - 1].Cells["Depo Kodu"] as DataGridViewComboBoxCell).Value = depoKodu;

                        //dtProducts.Rows[dtProducts.Rows.Count - 1]["ToplananMiktar"] = "1";
                    }

                    if (partili == "Y")
                    {
                        //if (!doubleclick)
                        //{
                        //    currentRow = dtgDetails.Rows.Count;
                        //}

                        IadeIrsaliyeGirisi_2 n = new IadeIrsaliyeGirisi_2("IadeTalep", list, "İADE TALEBİ GİRİŞİ");
                        n.ShowDialog();
                        n.Dispose();
                        GC.Collect();

                        if (IadeIrsaliyeGirisi_2.dialogresult != "Ok")
                        {
                            //if (!doubleclick)
                            //{
                            //    dtDetails.Rows.RemoveAt(currentRow);
                            //    dtgDetails.Refresh();
                            //}
                        }
                        else
                        {
                            var quantity = iadeTalepPartis.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                            dtDetails.Rows[currentRow]["ToplananMiktar"] = quantity;
                            dtgDetails.Refresh();
                        }

                        IadeIrsaliyeGirisi_2.dialogresult = "";
                    }
                    else
                    {
                        //CustomMsgBox.Show("KALEM İÇİN PARTİ BULUNMAMAKTADIR", "Uyarı", "Tamam", "");
                        //return;

                        #region partisiz kalem seçimi olamyacak dendi.bu yüzden kaldırıldı

                        ////dtProducts.Rows[dtProducts.Rows.Count - 1]["ToplananMiktar"] = "1";
                        //if (wareHouse == "")
                        //{
                        //    CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ.", "Uyarı", "TAMAM", "");
                        //    return;
                        //}
                        ////ItemCode = "";

                        //list = new List<dynamic>();
                        //Val = txtBarCode.Text;

                        //if (Val == "")
                        //{
                        //    CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "TAMAM", "");
                        //    return;
                        //}

                        //if (!doubleclick)
                        //{
                        //    currentRow = dtgProducts.Rows.Count;
                        //}

                        //list.Add(resp._list.Rows[0]["Kalem Kodu"]); //0
                        //list.Add(resp._list.Rows[0]["Kalem Tanımı"]);//1
                        //list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);//2
                        //list.Add(resp._list.Rows[0]["Ölçü Birimi"]);//3
                        //list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));//4
                        //list.Add(Math.Round(acceptqty, Giris.genelParametreler.OndalikMiktar).ToString());//5

                        //var toplananmiktar = dtgProducts.Rows[currentRow - 1].Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgProducts.Rows[currentRow - 1].Cells["Miktar"].Value);

                        //list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString()); //6
                        //txtBarCode.Text = "";

                        //PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("16", list, "IADE IRSALIYE GIRIŞI");
                        //partisizKalemSecimi.ShowDialog();

                        //if (PartisizKalemSecimi.dialogresult == "Ok")
                        //{
                        //    dtProducts.Rows[currentRow - 1]["Miktar"] = PartisizKalemSecimi.quantity;
                        //    //(dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = PartisizKalemSecimi.depoKodu;
                        //    PartisizKalemSecimi.dialogresult = "";
                        //    dtgProducts.Rows[currentRow - 1].Selected = false;
                        //}
                        //else
                        //{
                        //    if (!doubleclick)
                        //    {
                        //        dtProducts.Rows.RemoveAt(currentRow - 1);
                        //        dtgProducts.Refresh();
                        //        //dtgProducts.DataSource = dtProducts;
                        //    }
                        //}
                        //partili = "";
                        //barcode = "";

                        ////btnItemSearch.PerformClick(); //kapatıldı teste göre bakılacak
                        ////cmbItemName.DroppedDown = false; //kapatıldı teste göre bakılacak
                        //vScrollBar1.Maximum = dtgProducts.RowCount + 5;
                        //try
                        //{
                        //    if (dtgProducts.Rows.Count > 0)
                        //    {
                        //        dtgProducts.Rows[currentRow - 1].Selected = false;
                        //    }
                        //    else
                        //    {
                        //        txtBarCode.Select(0, txtBarCode.Text.Length);

                        //        //CustomMsgBox.Show(resp.Desc, "Uyarı", "TAMAM", "");
                        //    }
                        //}
                        //catch (Exception)
                        //{
                        //}

                        #endregion partisiz kalem seçimi olamyacak dendi.bu yüzden kaldırıldı
                    }

                    //dtgProducts.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //dtgProducts.AutoResizeRows();

                    dtgDetails.Columns["DepoKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    //dtgProducts.Columns["KalemAdi"].Width = dtgProducts.Width - dtgProducts.Columns["OlcuBirimi"].Width - dtgProducts.Columns["DepoMiktar"].Width - dtgProducts.Columns["ToplananMiktar"].Width - dtgProducts.Columns["DepoKodu"].Width;

                    txtBarCode.Focus();
                    txtBarCode.Text = ""; 
                    arananItemCode = ""; 

                    //btnEkle.PerformClick();
                    //cmbWareHouse.DroppedDown = false;
                    vScrollBar1.Maximum = dtgDetails.RowCount + 5;

                    try
                    {
                        if (dtgDetails.Rows.Count > 0)
                        {
                            dtgDetails.Rows[currentRow - 1].Selected = false;
                        }
                        else
                        {
                            txtBarCode.Select(0, txtBarCode.Text.Length);

                            //CustomMsgBox.Show(resp.Desc, "Uyarı", "TAMAM", "");
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    txtBarCode.Select(0, txtBarCode.Text.Length);
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDetay.PerformClick();
            }
        }

        private void dtgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                partili = dtDetails.Rows[e.RowIndex]["Partili"].ToString();
                barcode = dtDetails.Rows[e.RowIndex]["Barkod"].ToString();
                itemCode = dtDetails.Rows[e.RowIndex]["KalemKodu"].ToString();
                itemName = dtDetails.Rows[e.RowIndex]["KalemAdi"].ToString();
                depoKodu = dtDetails.Rows[e.RowIndex]["DepoKodu"].ToString();
                sapLineNum = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["SiraNo"]);
                DocEntry = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["BelgeNumarasi"]);
                acceptqty = dtDetails.Rows[e.RowIndex]["Miktar"].ToString() == "" ? 0 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["Miktar"]);
                txtBarCode.Text = barcode == "" ? itemCode : barcode;
                currentRow = e.RowIndex;

                //paletIciKoliAD = dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"]);
                //koliIciAD = dtProducts.Rows[e.RowIndex]["KoliIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["KoliIciAD"]);
                //paletIciAD = dtProducts.Rows[e.RowIndex]["PaletIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciAD"]);

                topMik = dtDetails.Rows[e.RowIndex]["ToplananMiktar"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["ToplananMiktar"]);
            }
        }

        private void dtgDetails_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
            btnDetay.PerformClick();
            partili = "";
            barcode = "";
            doubleclick = false;
            //return;
        }
        public static List<GoodRecieptPOBatch> goodRecieptPOBatches = new List<GoodRecieptPOBatch>();

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (txtWayBillNo.Text == "")
            {
                CustomMsgBox.Show("İRSALİYE NUMARASI BOŞ BIRAKILAMAZ.", "Uyarı", "Tamam", "");
                txtWayBillNo.Focus();
                return;
            }

            #region satış - iade - ORDN -16

            try
            {
                if (dtgDetails.Rows.Count == 0)
                {
                    //ne uyarısı yazılabilir buraya?
                    //CustomMsgBox.Show("Lütfen Çıkış Depo Seçimi Yapınız.", "Uyarı", "Tamam", "");
                    return;
                }
                if (txtCardCode.Text == "")
                {
                    CustomMsgBox.Show("MUHATAP BOŞ OLAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }
                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                    return;
                } 

                Iade iade = new Iade();
                IadeDetay iadeDetay = new IadeDetay();
                List<IadeDetay> iadeDetay1 = new List<IadeDetay>();
                List<IadeDetayParti> iadeDetayPartis1 = new List<IadeDetayParti>();
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient4 = new AIFTerminalServiceSoapClient();

                int i = 1; 

                iade.CardCode = txtCardCode.Text;
                iade.TaxDate = dtpOrderTaxDate.Value.ToString("yyyyMMdd");
                iade.WayBillNo = txtWayBillNo.Text;
                //iade.Comments = richTextBox1.Text;
                iade.ShipToCode = txtSevkAdres.Text;

                foreach (DataRow items in dtDetails.Rows)
                {
                    if (items["ToplananMiktar"].ToString() == "0" || items["ToplananMiktar"].ToString() == "")
                    {
                        continue;
                    }

                    iadeDetayPartis1 = new List<IadeDetayParti>();
                    foreach (var aifx in iadeTalepPartis.Where(x => x.ItemCode == items["KalemKodu"].ToString() && x.SAPLineNum == Convert.ToInt32(items["SiraNo"]) && x.DocEntry == Convert.ToInt32(items["BelgeNumarasi"])))
                    {
                        iadeDetayPartis1.Add(new IadeDetayParti
                        {
                            BatchNumber = aifx.BatchNumber,
                            BatchQuantity = Math.Round(Convert.ToDouble(aifx.BatchQuantity), Giris.genelParametreler.OndalikMiktar),
                            BinCode = aifx.DepoYeriId
                        });
                    }

                    iadeDetay1.Add(new IadeDetay
                    {
                        iadeDetayParti = iadeDetayPartis1.ToArray(),
                        ItemCode = items["KalemKodu"].ToString(),
                        Quantity = Math.Round(Convert.ToDouble(items["ToplananMiktar"]), Giris.genelParametreler.OndalikMiktar),
                        DocEntry = Convert.ToInt32(items["BelgeNumarasi"]),
                        BaseType = 16,
                        LineNum = Convert.ToInt32(items["SiraNo"]),
                        BinCode = Giris.genelParametreler.DepoYeriCalisir == "Y" && items["Partili"].ToString() != "Y" ? items["DepoYeriId"].ToString() : "",
                        WareHouse = items["DepoKodu"].ToString(),
                    });

                    iade.iadeDetays = iadeDetay1.ToArray();
                    i++;
                }

                if (iade.iadeDetays.Count() == 0)
                {
                    CustomMsgBox.Show("BELGENİN TÜM SATIRLARI 0 OLDUĞUNDAN DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                    return;
                }
                var resp4 = aIFTerminalServiceSoapClient4.AddOrUpdateIade(Giris._dbName, Convert.ToInt32(Giris._userCode), iade);

                CustomMsgBox.Show(resp4.Desc, "Uyarı", "Tamam", "");

                if (resp4.Val == 0)
                {
                    IadeTalebi_1.formAciliyor = true;
                    IadeTalebi_1.dialogresult = "OK";
                    Close();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }

            #endregion satış - iade - ORDN -16 
        }

        private void dtgDetails_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgDetails.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }
    }
}
