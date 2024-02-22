using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class SiparissizTesilmat_1 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public SiparissizTesilmat_1(string _formName)
        {
            //CultureInfo culture = new CultureInfo("tr-TR");
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;
            //end font

            formName = _formName;
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

            label6.Font = new Font(label6.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label6.Font.Style);

            label7.Font = new Font(label7.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label7.Font.Style);

            label8.Font = new Font(label8.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label8.Font.Style);

            label9.Font = new Font(label9.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label9.Font.Style);

            lblItemName.Font = new Font(lblItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemName.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               frmName.Font.Style);

            txtCustomerCode.Font = new Font(txtCustomerCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCustomerCode.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbItemName.Font.Style);

            btnSearch.Font = new Font(btnSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSearch.Font.Style);

            btnItemSearch.Font = new Font(btnItemSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnItemSearch.Font.Style);

            dtpDocDate.Font = new Font(dtpDocDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpDocDate.Font.Style);

            dtpDocDueDate.Font = new Font(dtpDocDueDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpDocDueDate.Font.Style);

            txtWayBillNo.Font = new Font(txtWayBillNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWayBillNo.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            cmbWareHouse.Font = new Font(cmbWareHouse.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbWareHouse.Font.Style);

            btnAddorUpdateOrder.Font = new Font(btnAddorUpdateOrder.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAddorUpdateOrder.Font.Style);

            btnAdd.Font = new Font(btnAdd.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAdd.Font.Style);

            btnBarkodGoster.Font = new Font(btnBarkodGoster.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBarkodGoster.Font.Style);

            cmbCustomerName.Font = new Font(cmbCustomerName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbCustomerName.Font.Style);

            dtgProducts.Font = new Font(dtgProducts.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgProducts.Font.Style);

            txtCustomerName.Font = new Font(txtCustomerName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCustomerName.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtDepoYeri.Font = new Font(txtDepoYeri.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtDepoYeri.Font.Style);

            txtDepoYeriAdi.Font = new Font(txtDepoYeriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtDepoYeriAdi.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtCustomerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtWayBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            dtpDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dtpDocDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            cmbWareHouse.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtDepoYeri.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtDepoYeriAdi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //cmbWareHouse.DropDownWidth = cmbWareHouse.Width + btnBarkodGoster.Width;
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

        private Response respCmbSupplier = null;
        private string formName = "";

        private void SiparissizTesilmat_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName.ToUpper();
            dtgProducts.RowTemplate.Height = 55;
            //cmbItemName.DropDownWidth = cmbItemName.Width + btnItemSearch.Width;
            //cmbCustomerName.Font = new Font("Tahoma", 26);
            //cmbItemName.Font = new Font("Tahoma", 26);

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetBusinessCustomerPartner(Giris._dbName, Giris.mKodValue);
            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    respCmbSupplier = resp;
                    dtview = new DataView(resp._list);
                    cmbCustomerName.DataSource = resp._list;
                    cmbCustomerName.DisplayMember = "CardName";
                    cmbCustomerName.ValueMember = "CardCode";
                    cmbCustomerName.Enabled = true;

                    //cmbSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cmbSupplier.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }

            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_SprsszTes", Giris.mKodValue);
            }

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    cmbWareHouse.DataSource = resp._list;
                    cmbWareHouse.DisplayMember = "WhsName";
                    cmbWareHouse.ValueMember = "WhsCode";
                    cmbWareHouse.Enabled = true;
                }
            }

            dtProducts.Columns.Add("Kalem Kodu", typeof(string));
            dtProducts.Columns.Add("Kalem Tanımı", typeof(string));
            dtProducts.Columns.Add("Ölçü Birimi", typeof(string));
            dtProducts.Columns.Add("Barkod", typeof(string));
            dtProducts.Columns.Add("Miktar", typeof(double));
            dtProducts.Columns.Add("DepoMiktar", typeof(double));
            dtProducts.Columns.Add("Partili", typeof(string));
            //dtProducts.Columns.Add("DepoKodu", typeof(string));
            dtProducts.Columns.Add("PaletIciKoliAD", typeof(double));
            dtProducts.Columns.Add("KoliIciAD", typeof(double));
            dtProducts.Columns.Add("PaletIciAD", typeof(double));

            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                dtProducts.Columns.Add("DepoYeriId", typeof(string));
                dtProducts.Columns.Add("DepoYeriAdi", typeof(string));
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            btn = new DataGridViewButtonColumn();
            dtgProducts.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Detay";
            btn.Name = "btnDetail";
            btn.UseColumnTextForButtonValue = true;

            dtgProducts.DataSource = dtProducts;

            dtgProducts.Columns["DepoMiktar"].Visible = false;
            dtgProducts.Columns["btnDetail"].Visible = false;
            dtgProducts.Columns["Kalem Kodu"].Visible = false;
            dtgProducts.Columns["Partili"].Visible = false;
            dtgProducts.Columns["Barkod"].Visible = false;

            dtgProducts.Columns["PaletIciKoliAD"].Visible = false;
            dtgProducts.Columns["KoliIciAD"].Visible = false;
            dtgProducts.Columns["PaletIciAD"].Visible = false;

            dtgProducts.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

            dtgProducts.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
            dtgProducts.Columns["Kalem Tanımı"].HeaderText = "KALEM ADI";
            dtgProducts.Columns["Ölçü Birimi"].HeaderText = "BRM";
            dtgProducts.Columns["Barkod"].HeaderText = "BARKOD";
            dtgProducts.Columns["Miktar"].HeaderText = "MİKTAR";
            dtgProducts.Columns["DepoMiktar"].HeaderText = "DEPO MİKTAR";
            dtgProducts.Columns["Partili"].HeaderText = "PARTİLİ";

            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                txtDepoYeri.Visible = false;
                txtDepoYeriAdi.Visible = false;
            }
            else
            {
                dtgProducts.Columns["DepoYeriId"].HeaderText = "DEPO YERI";
                dtgProducts.Columns["DepoYeriAdi"].HeaderText = "DEPO YERI ADI";
            }

            dtgProducts.Columns["Kalem Kodu"].ReadOnly = true;
            dtgProducts.Columns["Kalem Tanımı"].ReadOnly = true;
            dtgProducts.Columns["Ölçü Birimi"].ReadOnly = true;
            dtgProducts.Columns["Barkod"].ReadOnly = true;
            dtgProducts.Columns["Miktar"].ReadOnly = true;
            //dtgProducts.Columns["DepoMiktar"].ReadOnly = true;
            dtgProducts.Columns["Partili"].ReadOnly = true;

            dtgProducts.EnableHeadersVisualStyles = false;
            dtgProducts.RowTemplate.Height = 55;
            dtgProducts.ColumnHeadersHeight = 60;

            //dtgProducts.Columns["Kalem Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["Ölçü Birimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtgProducts.Columns["Barkod"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtgProducts.Columns["Partili"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dtgProducts.Columns["Kalem Tanımı"].Width = dtgProducts.Width - dtgProducts.Columns["Ölçü Birimi"].Width -
            //    dtgProducts.Columns["Miktar"].Width - dtgProducts.Columns["Barkod"].Width - dtgProducts.Columns["Partili"].Width;

            //DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();

            //btn2 = new DataGridViewButtonColumn();
            //dtgProducts.Columns.Add(btn2);
            //btn2.HeaderText = "";
            //btn2.Text = "Sil";
            //btn2.Name = "btnDelete";
            //btn2.UseColumnTextForButtonValue = true;

            foreach (DataGridViewColumn column in dtgProducts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgProducts.Rows.Count > 0)
            {
                dtgProducts.Rows[0].Selected = false;
            }

            cmbCustomerName.Focus();
            vScrollBar1.Maximum = dtgProducts.RowCount;
        }

        private DataView dtview = new DataView();
        private DataTable dtProducts = new DataTable();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtview.RowFilter = "CardCode like '%" + cmbCustomerName.Text + "%' or CardName like '%" + cmbCustomerName.Text + "%' or  CardCode = '' or CardName =''";

            cmbCustomerName.DataSource = null;
            cmbCustomerName.DisplayMember = "CardName";
            cmbCustomerName.ValueMember = "CardCode";
            cmbCustomerName.DataSource = dtview;

            cmbCustomerName.DroppedDown = true;
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomerName.SelectedIndex > 0)
            {
                string code = cmbCustomerName.SelectedValue.ToString();
                txtCustomerCode.Text = code;
            }
            else
            {
                txtCustomerCode.Text = "";
            }
        }

        //public static int currentrow = 0;
        public static List<DeliveryBatch> DeliveryBatches = new List<DeliveryBatch>();

        public static string wareHouse = "";
        public static string staticdepoYeriId = "";
        public static string arananItemCode = "";
        private string partino = "";

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ItemCode = "";
            //string partili = "";
            wareHouse = cmbWareHouse.SelectedValue.ToString();
            staticdepoYeriId = txtDepoYeri.Text;
            double warehouseQty = 0;

            if (wareHouse == "")
            {
                CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "Kapat");
                return;
            }
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
                resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, wareHouse, Giris.mKodValue);
            }
            else
            {
                if (arananItemCode != null)
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
                resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, wareHouse, txtCustomerCode.Text, Giris.mKodValue);
            }

            if (resp._list != null)
            {
                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    try
                    {
                        resp._list.Columns.Add("DepoYeriId", typeof(string));
                        resp._list.Columns.Add("DepoYeriAdi", typeof(string));
                    }
                    catch (Exception)
                    {
                    }
                }
                dtDetails = resp._list;
                foreach (DataRow item in resp._list.Rows)
                {
                    DataRow dr = dtProducts.NewRow();
                    dr["Kalem Kodu"] = item["Kalem Kodu"];
                    dr["Kalem Tanımı"] = item["Kalem Tanımı"];
                    dr["Barkod"] = item["Barkod"];
                    dr["Ölçü Birimi"] = item["Ölçü Birimi"];
                    dr["DepoMiktar"] = item["Depo Miktari"];
                    dr["Partili"] = item["Partili"];

                    dr["PaletIciKoliAD"] = item["PaletIciKoliAD"];
                    dr["KoliIciAD"] = item["KoliIciAD"];
                    dr["PaletIciAD"] = item["PaletIciAD"];

                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        dr["DepoYeriId"] = txtDepoYeri.Text.ToString();
                        dr["DepoYeriAdi"] = txtDepoYeriAdi.Text.ToString();

                        item["DepoYeriId"] = txtDepoYeri.Text.ToString();
                        item["DepoYeriAdi"] = txtDepoYeriAdi.Text.ToString();

                        dtgProducts.Columns["DepoYeriId"].Visible = false;
                    }

                    //dr["DepoKodu"] = wareHouse;
                    partili = item["Partili"].ToString();

                    ItemCode = item["Kalem Kodu"].ToString();
                    list.Add(item["Kalem Kodu"]);
                    list.Add(item["Kalem Tanımı"]);
                    list.Add(item["Barkod"]);
                    list.Add(item["Ölçü Birimi"]);
                    list.Add(item["Depo Miktari"]);

                    list.Add(item["PaletIciKoliAD"]);
                    list.Add(item["KoliIciAD"]);
                    list.Add(item["PaletIciAD"]);

                    if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                    {
                        list.Add(partino);
                        partino = "";
                    }

                    if (dtgProducts.Columns.Contains("DepoKodu") != true)
                    {
                        addcombo();
                    }

                    if (!doubleclick)
                    {
                        dtProducts.Rows.Add(dr);
                    }

                    (dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = wareHouse;
                }

                if (partili == "Y")
                {
                    if (!doubleclick)
                    {
                        currentRow = dtProducts.Rows.Count;
                    }

                    SipariseBagliTeslimat_3 n = new SipariseBagliTeslimat_3("Sprssz17", list, "SİPARİŞSİZ TESLİMAT");
                    n.ShowDialog();
                    n.Dispose();
                    GC.Collect();

                    if (SipariseBagliTeslimat_3.dialogResult != "Ok")
                    {
                        if (!doubleclick)
                        {
                            dtProducts.Rows.RemoveAt(currentRow - 1);
                            dtgProducts.Refresh();
                        }
                    }
                    else
                    {
                        var quantity = DeliveryBatches.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                        dtProducts.Rows[currentRow - 1]["Miktar"] = quantity;
                        dtgProducts.Refresh();
                    }

                    SipariseBagliTeslimat_3.dialogResult = "";
                }
                else
                {
                    //dtProducts.Rows[dtProducts.Rows.Count - 1]["Miktar"] = "1";

                    //ItemCode = "";
                    //string partili = "";

                    list = new List<dynamic>();
                    Val = txtBarCode.Text;

                    //aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    //resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, wareHouse);

                    //if (resp._list == null)
                    //{
                    //    resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, wareHouse);
                    //}

                    //if (resp._list != null)
                    //{
                    //    dtDetails = resp._list;

                    //    foreach (DataRow item in resp._list.Rows)
                    //    {
                    //        //DataRow dr = dtProducts.NewRow();
                    //        //dr["Kalem Kodu"] = item["Kalem Kodu"];
                    //        //dr["Kalem Tanımı"] = item["Kalem Tanımı"];
                    //        //dr["Barkod"] = item["Barkod"];
                    //        //dr["Ölçü Birimi"] = item["Ölçü Birimi"];
                    //        //dr["DepoMiktar"] = item["Depo Miktari"];
                    //        //dr["Partili"] = item["Partili"];
                    //        ////dr["DepoKodu"] = wareHouse;
                    //        //partili = item["Partili"].ToString();

                    //        ItemCode = item["Kalem Kodu"].ToString();
                    //        list.Add(item["Kalem Kodu"]);
                    //        list.Add(item["Kalem Tanımı"]);
                    //        list.Add(item["Barkod"].ToString() == "" ? "Tanımsız" : item["Barkod"].ToString());
                    //        list.Add(item["Ölçü Birimi"]);
                    //        list.Add(item["Depo Miktari"]);
                    //    }
                    //}
                    if (!doubleclick)
                    {
                        currentRow = dtgProducts.Rows.Count;
                    }
                    //ItemCode = resp._list.Rows[0]["Kalem Kodu"].ToString();
                    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                    list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"].ToString());
                    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                    //list.Add(resp._list.Rows[0]["Depo Miktari"]);
                    list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                    var toplananmiktar = dtgProducts.Rows[currentRow - 1].Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgProducts.Rows[currentRow - 1].Cells["Miktar"].Value);

                    list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString());

                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        list.Add(resp._list.Rows[0]["DepoYeriId"]);
                        list.Add(resp._list.Rows[0]["DepoYeriAdi"]);
                        list.Add((dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).FormattedValue.ToString());
                        list.Add((dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value.ToString());
                    }

                    txtBarCode.Text = "";

                    PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("Sprssz17", list, "SİPARİŞSİZ TESLİMAT");
                    partisizKalemSecimi.ShowDialog();
                    partisizKalemSecimi.Dispose();
                    GC.Collect();

                    if (PartisizKalemSecimi.dialogresult == "Ok")
                    {
                        dtProducts.Rows[currentRow - 1]["Miktar"] = PartisizKalemSecimi.quantity;
                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            dtProducts.Rows[currentRow - 1]["DepoYeriId"] = PartisizKalemSecimi.depoYeriId;
                            dtProducts.Rows[currentRow - 1]["DepoYeriAdi"] = PartisizKalemSecimi.depoYeriAdi;
                            PartisizKalemSecimi.depoYeriId = "";
                            PartisizKalemSecimi.depoYeriAdi = "";
                        }
                        //dtProducts.Rows[currentRow - 1]["DepoKodu"] = PartisizKalemSecimi.depoKodu;
                        //dtProducts.AcceptChanges();
                        PartisizKalemSecimi.dialogresult = "";
                        dtgProducts.Rows[currentRow - 1].Selected = false;
                    }
                    else
                    {
                        if (!doubleclick)
                        {
                            dtProducts.Rows.RemoveAt(currentRow - 1);
                            dtgProducts.Refresh();
                            //dtgProducts.DataSource = dtProducts;
                        }
                    }
                    partili = "";
                    barcode = "";
                }
                dtgProducts.Columns["DepoKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgProducts.Columns["DepoKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgProducts.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dtgProducts.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgProducts.AutoResizeRows();
                txtBarCode.Focus();
                txtBarCode.Text = "";
                cmbItemName.Text = "";
                arananItemCode = "";
                txtItemName.Text = "";
                vScrollBar1.Maximum = dtgProducts.RowCount + 5;

                btnItemSearch.PerformClick();
                cmbItemName.DroppedDown = false;
                try
                {
                    if (dtgProducts.Rows.Count > 0)
                    {
                        dtgProducts.Rows[currentRow - 1].Selected = false;
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
                CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
            //vScrollBar1.Maximum = dtgProducts.RowCount + 5;
        }

        private void addcombo()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response r = null;

            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_SprsszTes", Giris.mKodValue);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(r._list);

            DataGridViewComboBoxColumn comboLookup = new DataGridViewComboBoxColumn();
            comboLookup.DataSource = ds.Tables[0];
            comboLookup.HeaderText = "DEPO";
            comboLookup.Name = "DepoKodu";
            comboLookup.DisplayMember = "WhsName";
            comboLookup.ValueMember = "WhsCode";
            dtgProducts.Columns.Add(comboLookup);
        }

        private void btnAddorUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgProducts.Rows.Count == 0)
                {
                    //ne uyarısı yazılabilir buraya?
                    //CustomMsgBox.Show("Lütfen Çıkış Depo Seçimi Yapınız.", "Uyarı", "Tamam", "");
                    return;
                }
                if (txtCustomerCode.Text == "")
                {
                    CustomMsgBox.Show("LÜTFEN MÜŞTERİ SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    cmbCustomerName.Focus();
                    return;
                }
                if (cmbCustomerName.Text == "")
                {
                    CustomMsgBox.Show("LÜTFEN ÇIKIŞ DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    txtBarCode.Focus();
                    return;
                }
                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                    return;
                }
                Orders orders = new Orders();
                OrderDetails orderDetails = new OrderDetails();
                List<OrderDetails> orderDetails1 = new List<OrderDetails>();
                List<OrderBatchList> orderBatchList1 = new List<OrderBatchList>();
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                int i = 1;
                int index = 0;
                orders.CarCode = txtCustomerCode.Text;
                orders.DocDate = dtpDocDate.Value.ToString("yyyyMMdd");
                orders.DocDueDate = dtpDocDueDate.Value.ToString("yyyyMMdd");
                orders.WayBillNo = txtWayBillNo.Text;

                foreach (DataRow items in dtProducts.Rows)
                {
                    if (items["Miktar"].ToString() == "0")
                    {
                        continue;
                    }

                    orderBatchList1 = new List<OrderBatchList>();
                    foreach (var aifx in DeliveryBatches.Where(x => x.ItemCode == items["Kalem Kodu"].ToString() && x.LineNumber == i))
                    {
                        orderBatchList1.Add(new OrderBatchList
                        {
                            BatchNumber = aifx.BatchNumber,
                            BatchQuantity = aifx.BatchQuantity,
                            DepoyYeriId = Giris.genelParametreler.DepoYeriCalisir == "Y" ? aifx.DepoYeriId:"",
                            DepoyYeriAdi = Giris.genelParametreler.DepoYeriCalisir == "Y"  ? aifx.DepoYeriAdi:""
                        });
                    }

                    orderDetails1.Add(new OrderDetails
                    {
                        BatchLists = orderBatchList1.ToArray(),
                        ItemCode = items["Kalem Kodu"].ToString(),
                        Quantity = Math.Round(Convert.ToDouble(items["Miktar"]), Giris.genelParametreler.OndalikMiktar),
                        WareHouse = dtgProducts.Rows[index].Cells["DepoKodu"].Value.ToString(),
                        DepoyYeriId = Giris.genelParametreler.DepoYeriCalisir == "Y" && items["Partili"].ToString() != "Y" ? dtgProducts.Rows[index].Cells["DepoYeriId"].Value.ToString() : "",
                    });

                    orders.OrderDetails = orderDetails1.ToArray();
                    i++;
                    index++;
                }

                if (orders.OrderDetails.Count() == 0)
                {
                    CustomMsgBox.Show("BELGENİN TÜM SATIRLARI 0 OLDUĞUNDAN DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                    return;
                }

                var resp1 = aIFTerminalServiceSoapClient1.AddOrUpdateOrders(Giris._dbName, Convert.ToInt32(Giris._userCode), orders);

                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

                if (resp1.Val == 0)
                {
                    orderBatchList1 = new List<OrderBatchList>();
                    Close();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private DataTable dtDetails = new DataTable();

        private void dtgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                List<dynamic> list = new List<dynamic>();
                if (senderGrid.Columns[e.ColumnIndex].Name == "btnDetail")
                {
                    currentRow = dtProducts.Rows.Count;

                    string ItemCode = dtProducts.Rows[e.RowIndex]["Kalem Kodu"].ToString();
                    list.Add(dtProducts.Rows[e.RowIndex]["Kalem Kodu"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["Kalem Tanımı"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["Barkod"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["Ölçü Birimi"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["DepoMiktar"].ToString());

                    SipariseBagliTeslimat_3 n = new SipariseBagliTeslimat_3("Sprssz17", list, "SİPARİŞSİZ TESLİMAT");
                    n.ShowDialog();
                    n.Dispose();
                    GC.Collect();

                    var quantity = DeliveryBatches.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                    dtProducts.Rows[currentRow - 1]["Miktar"] = quantity;
                }
            }
        }

        public static int sapLineNum = 0;
        private int DocEntry = -1;
        private string partili = "";
        private string barcode = "";
        private string itemCode = "";
        private string itemName = "";
        private double orderqty = 0;
        public static int currentRow = 0;
        private double paletIciKoliAD = 0;
        private double koliIciAD = 0;
        private double paletIciAD = 0;
        private double topMik = 0;

        private void dtgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                barcode = dtProducts.Rows[e.RowIndex]["Barkod"].ToString();
                itemCode = dtProducts.Rows[e.RowIndex]["Kalem Kodu"].ToString();
                itemName = dtProducts.Rows[e.RowIndex]["Kalem Tanımı"].ToString();
                orderqty = Convert.ToDouble(dtProducts.Rows[e.RowIndex]["Miktar"]);
                partili = dtProducts.Rows[e.RowIndex]["Partili"].ToString();
                txtBarCode.Text = barcode.ToString() != "" ? barcode.ToString() : itemCode;
                currentRow = e.RowIndex + 1;

                paletIciKoliAD = dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"]);
                koliIciAD = dtProducts.Rows[e.RowIndex]["KoliIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["KoliIciAD"]);
                paletIciAD = dtProducts.Rows[e.RowIndex]["PaletIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciAD"]);

                topMik = dtProducts.Rows[e.RowIndex]["Miktar"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["Miktar"]);
            }
        }

        private void cmbWareHouse_Click(object sender, EventArgs e)
        {
            cmbWareHouse.DroppedDown = true;
        }

        private void cmbWareHouse_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtBarCode.Focus();
            }
            catch (Exception)
            {
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }

        private bool doubleclick = false;

        private void dtgProducts_DoubleClick(object sender, EventArgs e)
        {
            //if (partili == "Y")
            //{
            doubleclick = true;
            btnAdd.PerformClick();
            partili = "";
            barcode = "";
            doubleclick = false;
            //    return;
            //}

            //string ItemCode = "";
            ////string partili = "";

            //List<dynamic> list = new List<dynamic>();
            //string Val = txtBarCode.Text;

            //AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            //Response resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, wareHouse);

            //if (resp._list == null)
            //{
            //    resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, wareHouse);
            //}

            //if (resp._list != null)
            //{
            //    dtDetails = resp._list;

            //    foreach (DataRow item in resp._list.Rows)
            //    {
            //        //DataRow dr = dtProducts.NewRow();
            //        //dr["Kalem Kodu"] = item["Kalem Kodu"];
            //        //dr["Kalem Tanımı"] = item["Kalem Tanımı"];
            //        //dr["Barkod"] = item["Barkod"];
            //        //dr["Ölçü Birimi"] = item["Ölçü Birimi"];
            //        //dr["DepoMiktar"] = item["Depo Miktari"];
            //        //dr["Partili"] = item["Partili"];
            //        ////dr["DepoKodu"] = wareHouse;
            //        //partili = item["Partili"].ToString();

            //        ItemCode = item["Kalem Kodu"].ToString();
            //        list.Add(item["Kalem Kodu"]);
            //        list.Add(item["Kalem Tanımı"]);
            //        list.Add(item["Barkod"].ToString() == "" ? "Tanımsız" : item["Barkod"].ToString());
            //        list.Add(item["Ölçü Birimi"]);
            //        list.Add(item["Depo Miktari"]);
            //    }
            //}
            //txtBarCode.Text = "";
            //PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("Sprssz17", list, "SİPARİŞSİZ TESLİMAT");
            //partisizKalemSecimi.ShowDialog();

            //if (PartisizKalemSecimi.dialogresult == "Ok")
            //{
            //    dtProducts.Rows[currentRow]["Miktar"] = PartisizKalemSecimi.quantity;
            //    //dtProducts.AcceptChanges();
            //    PartisizKalemSecimi.dialogresult = "";
            //}
            //dtgProducts.Rows[currentRow].Selected = false;
            //partili = "";
            //barcode = "";
        }

        private DataTable dtProductsItem = new DataTable();

        private DataView dtViewItem = new DataView();

        private void GetAllProducts()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetAllProducts(Giris._dbName, Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtProductsItem = resp._list;
                    dtViewItem = new DataView(resp._list);
                }
            }
        }

        private void cmbItemName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbItemName.SelectedValue != null)
            {
                var value = cmbItemName.SelectedValue.ToString();

                if (value != "")
                {
                    if (dtProductsItem.Rows.Count > 0)
                    {
                        var listProducts = dtProductsItem.AsEnumerable().Where(x => x.Field<string>("ItemCode") == value).ToList();

                        var itemCode = listProducts.Select(x => x.Field<string>("ItemCode")).First();
                        var barcode = listProducts.Select(x => x.Field<string>("CodeBars")).First();

                        if (barcode != "" && barcode != null)
                        {
                            txtBarCode.Text = barcode;
                        }
                        else
                        {
                            txtBarCode.Text = "TANIMSIZ";
                        }

                        dtgProducts.DataSource = dtProducts;

                        dtgProducts.Columns["DepoMiktar"].Visible = false;
                        dtgProducts.Columns["btnDetail"].Visible = false;

                        dtgProducts.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                        dtgProducts.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
                        dtgProducts.Columns["Kalem Tanımı"].HeaderText = "KALEM ADI";
                        dtgProducts.Columns["Ölçü Birimi"].HeaderText = "BRM";
                        dtgProducts.Columns["Barkod"].HeaderText = "BARKOD";
                        dtgProducts.Columns["Miktar"].HeaderText = "MİKTAR";
                        dtgProducts.Columns["DepoMiktar"].HeaderText = "DEPO MİKTAR";
                        dtgProducts.Columns["Partili"].HeaderText = "PARTİLİ";

                        dtgProducts.Columns["Kalem Kodu"].ReadOnly = true;
                        dtgProducts.Columns["Kalem Tanımı"].ReadOnly = true;
                        dtgProducts.Columns["Ölçü Birimi"].ReadOnly = true;
                        dtgProducts.Columns["Barkod"].ReadOnly = true;
                        dtgProducts.Columns["Miktar"].ReadOnly = true;
                        //dtgProducts.Columns["DepoMiktar"].ReadOnly = true;
                        dtgProducts.Columns["Partili"].ReadOnly = true;

                        btnAdd.PerformClick();
                    }
                }
            }
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            if (cmbWareHouse.SelectedValue == "" || cmbWareHouse.SelectedValue == null)
            {
                CustomMsgBox.Show("LÜTFEN ÇIKIŞ DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }
            GetAllProducts();
            if (dtProductsItem.Rows.Count > 0)
            {
                dtViewItem.RowFilter = "ItemName = '' or ItemName like '%" + cmbItemName.Text + "%'";

                //cmbItemName.DroppedDown = true;
                cmbItemName.DataSource = null;

                if (dtViewItem.Count > 0)
                {
                    cmbItemName.DisplayMember = "ItemName";
                    cmbItemName.ValueMember = "ItemCode";
                    cmbItemName.DataSource = dtViewItem;

                    cmbItemName.DroppedDown = true;
                }
                else
                {
                    CustomMsgBox.Show("ARAMA SONUCU EŞLEŞEN KAYIT BULUNAMAMIŞTIR.", "Uyarı", "TAMAM", "");
                }
            }
        }

        private void dtgProducts_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgProducts.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void btnBarkodGoster_Click(object sender, EventArgs e)
        {
            ListParties = new List<Parties>();

            List<dynamic> list = new List<dynamic>();
            var partiler = DeliveryBatches.Where(x => x.ItemCode == itemCode && x.SAPLineNum == Convert.ToInt32(sapLineNum)).ToList();
            //if (partiler.Count == 0)
            //{
            //    CustomMsgBox.Show("PARTİ GİRİŞİ YAPILMAMIŞTIR.", "Uyarı", "TAMAM", "");
            //    return;
            //}
            if (txtBarCode.Text == "")
            {
                CustomMsgBox.Show("BARKOD VEYA KALEM KODU GİRİNİZ.", "Uyarı", "TAMAM", "");
                txtBarCode.Focus();
                txtBarCode.Select(0, txtBarCode.Text.Length);
                return;
            }
            string Val = txtBarCode.Text;

            if (partili == "Y")
            {
                if (partiler.Count > 0)
                {
                    foreach (var item in partiler)
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                    }
                }
                else
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                }
            }
            else
            {
                ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
            }

            txtBarCode.Text = "";
            BarkodGoruntule barkodGoruntule = new BarkodGoruntule("Sprssz17", ListParties, "BARKOD GÖRÜNTÜLEME");
            barkodGoruntule.ShowDialog();
            barkodGoruntule.Dispose();
            GC.Collect();
            try
            {
                if (dtgProducts.Rows.Count > 0)
                {
                    dtgProducts.Rows[currentRow - 1].Selected = false;
                }
            }
            catch (Exception ex)
            {
            }
            ListParties = new List<Parties>();
        }

        public static List<Parties> ListParties = new List<Parties>();

        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            SelectList nesne = new SelectList("Sprssz17", "MusteriAra", "MÜŞTERİ ARAMA", txtCustomerCode, txtCustomerName);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();
        }

        private void txtItemName_Click(object sender, EventArgs e)
        {
            if (cmbWareHouse.SelectedValue == "" || cmbWareHouse.SelectedValue == null)
            {
                CustomMsgBox.Show("LÜTFEN GİRİŞ DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }
            SelectList nesne = new SelectList("Sprssz17", "KalemAra", "KALEM ARAMA", txtBarCode, txtItemName);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (SelectList.dialogResult == "Ok")
            {
                if (txtBarCode.Text == "")
                {
                    txtBarCode.Text = "TANIMSIZ";
                }
                btnAdd.PerformClick();
                SelectList.dialogResult = "";
            }
        }

        private void txtDepoYeri_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox t = new TextBox();
                t.Text = cmbWareHouse.SelectedValue.ToString();
                SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtDepoYeri, txtDepoYeriAdi, t);
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
    }
}