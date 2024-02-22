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
    public partial class TalepsizDepoNakli_1 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        private Button buttonlistele = new Button();

        public TalepsizDepoNakli_1(Button _buttonlistele, string _formName)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;
            //end font

            buttonlistele = _buttonlistele;
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

            cmbCarCode.Font = new Font(cmbCarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbCarCode.Font.Style);

            cmbToWhsCode.Font = new Font(cmbToWhsCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbToWhsCode.Font.Style);

            cmbFromWhsCode.Font = new Font(cmbFromWhsCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbFromWhsCode.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               cmbItemName.Font.Style);

            dtpDocDate.Font = new Font(dtpDocDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpDocDate.Font.Style);

            dtpDocDueDate.Font = new Font(dtpDocDueDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpDocDueDate.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            txtSourceCode.Font = new Font(txtSourceCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSourceCode.Font.Style);

            txtTargetCode.Font = new Font(txtTargetCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtTargetCode.Font.Style);

            btnAddorUpdateOrder.Font = new Font(btnAddorUpdateOrder.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAddorUpdateOrder.Font.Style);

            btnAdd.Font = new Font(btnAdd.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAdd.Font.Style);

            btnSearch.Font = new Font(btnSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSearch.Font.Style);

            btnItemSearch.Font = new Font(btnItemSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnItemSearch.Font.Style);

            btnBarkodGoster.Font = new Font(btnBarkodGoster.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBarkodGoster.Font.Style);

            dtgProducts.Font = new Font(dtgProducts.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgProducts.Font.Style);

            txtCustomerName.Font = new Font(txtCustomerName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCustomerName.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtKaynakDepoYeriId.Font = new Font(txtKaynakDepoYeriId.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtKaynakDepoYeriId.Font.Style);

            txtKaynakDepoYeriAdi.Font = new Font(txtKaynakDepoYeriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtKaynakDepoYeriAdi.Font.Style);

            txtHedefDepoYeriId.Font = new Font(txtHedefDepoYeriId.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtHedefDepoYeriId.Font.Style);

            txtHedefDepoYeriAdi.Font = new Font(txtHedefDepoYeriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtHedefDepoYeriAdi.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtCustomerCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtCustomerName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            dtpDocDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpDocDueDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            cmbFromWhsCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbToWhsCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtSourceCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtTargetCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            cmbFromWhsCode.DropDownWidth = cmbFromWhsCode.Width + btnAdd.Width;
            cmbToWhsCode.DropDownWidth = cmbToWhsCode.Width + btnAdd.Width;

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

        private DataTable dtcmbWarehouseSource = new DataTable();
        private DataTable dtcmbWarehouseTarget = new DataTable();
        private DataTable dtcmbCardCode = new DataTable();

        private string formName = "";

        private void TalepsizDepoNakli_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            txtBarCode.Focus();
            dtgProducts.RowTemplate.Height = 55;
            dtgProducts.ColumnHeadersHeight = 60;

            //cmbItemName.DropDownWidth = cmbItemName.Width + btnItemSearch.Width;
            //cmbItemName.DropDownStyle = ComboBoxStyle.DropDown;

            //cmbItemName.Font = new Font("Tahoma", 26);

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpszDepK", Giris.mKodValue);
            }

            Response resp1 = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp1 = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp1 = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpszDepH", Giris.mKodValue);
            }

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtcmbWarehouseSource = resp._list;
                    dtcmbWarehouseTarget = resp1._list;

                    cmbFromWhsCode.DataSource = dtcmbWarehouseSource;
                    cmbFromWhsCode.DisplayMember = "WhsName";
                    cmbFromWhsCode.ValueMember = "WhsCode";
                    cmbFromWhsCode.Enabled = true;

                    cmbToWhsCode.DataSource = dtcmbWarehouseTarget;
                    cmbToWhsCode.DisplayMember = "WhsName";
                    cmbToWhsCode.ValueMember = "WhsCode";
                    cmbToWhsCode.Enabled = true;
                }
            }

            Response resp3 = aIFTerminalServiceSoapClient.GetAllBusinessPartner(Giris._dbName, Giris.mKodValue);

            if (resp3.Val == 0)
            {
                dtview = new DataView(resp3._list);
                dtcmbCardCode = resp3._list;
                cmbCarCode.DataSource = null;
                cmbCarCode.DataSource = dtcmbCardCode;
                cmbCarCode.DisplayMember = "CardName";
                cmbCarCode.ValueMember = "CardCode";
                cmbCarCode.Enabled = true;
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
                try
                {
                    dtProducts.Columns.Add("HDepoYeriId", typeof(string));
                    dtProducts.Columns.Add("HDepoYeriAdi", typeof(string));
                    dtProducts.Columns.Add("KDepoYeriId", typeof(string));
                    dtProducts.Columns.Add("KDepoYeriAdi", typeof(string));
                }
                catch (Exception)
                {
                }
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            btn = new DataGridViewButtonColumn();
            dtgProducts.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Detay";
            btn.Name = "btnDetail";
            btn.UseColumnTextForButtonValue = true;

            dtgProducts.DataSource = dtProducts;
            if (dtgProducts.Columns.Contains("FromWhsCode") != true)
            {
                addcomboFromWhsCode();
            }

            if (dtgProducts.Columns.Contains("ToWhsCode") != true)
            {
                addcomboToWhsCode();
            }

            dtgProducts.Columns["DepoMiktar"].Visible = false;
            dtgProducts.Columns["btnDetail"].Visible = false;
            dtgProducts.Columns["Barkod"].Visible = false;

            dtgProducts.Columns["Kalem Kodu"].Visible = false;
            dtgProducts.Columns["Partili"].Visible = false;

            dtgProducts.Columns["PaletIciKoliAD"].Visible = false;
            dtgProducts.Columns["KoliIciAD"].Visible = false;
            dtgProducts.Columns["PaletIciAD"].Visible = false;

            dtgProducts.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

            foreach (DataGridViewColumn column in dtgProducts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgProducts.Rows.Count > 0)
            {
                dtgProducts.Rows[0].Selected = false;
            }

            dtgProducts.EnableHeadersVisualStyles = false;

            dtgProducts.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
            dtgProducts.Columns["Kalem Tanımı"].HeaderText = "KALEM ADI";
            dtgProducts.Columns["Ölçü Birimi"].HeaderText = "BRM";
            dtgProducts.Columns["Barkod"].HeaderText = "BARKOD";
            dtgProducts.Columns["Miktar"].HeaderText = "MİKTAR";
            dtgProducts.Columns["DepoMiktar"].HeaderText = "DEPO MİK.";
            dtgProducts.Columns["Partili"].HeaderText = "PARTİLİ";

            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                txtHedefDepoYeriId.Visible = false;
                txtHedefDepoYeriAdi.Visible = false;
                txtKaynakDepoYeriAdi.Visible = false;
                txtKaynakDepoYeriId.Visible = false;
            }
            else
            {
                dtgProducts.Columns["HDepoYeriId"].HeaderText = "HDF DEPO YER";
                dtgProducts.Columns["HDepoYeriAdi"].HeaderText = "HDF DEPO YER AD";
                dtgProducts.Columns["KDepoYeriId"].HeaderText = "KAYNAK DEPO YER";
                dtgProducts.Columns["KDepoYeriAdi"].HeaderText = "KYNK DEPO YER AD";

                dtgProducts.Columns["HDepoYeriId"].Visible = false;
                dtgProducts.Columns["KDepoYeriId"].Visible = false;
            }

            dtgProducts.Columns["Kalem Kodu"].ReadOnly = true;
            dtgProducts.Columns["Kalem Tanımı"].ReadOnly = true;
            dtgProducts.Columns["Ölçü Birimi"].ReadOnly = true;
            dtgProducts.Columns["Miktar"].ReadOnly = true;
            dtgProducts.Columns["Partili"].ReadOnly = true;

            vScrollBar1.Maximum = dtgProducts.RowCount + 5;

            //dtgProducts.Columns["Kalem Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["Ölçü Birimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                dtgProducts.Columns["HDepoYeriId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgProducts.Columns["HDepoYeriAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgProducts.Columns["KDepoYeriId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgProducts.Columns["KDepoYeriAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            //dtgProducts.Columns["Partili"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["FromWhsCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dtgProducts.Columns["ToWhsCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dtgProducts.Columns["Kalem Tanımı"].Width = dtgProducts.Width - dtgProducts.Columns["Ölçü Birimi"].Width - dtgProducts.Columns["Miktar"].Width -
            dtgProducts.Columns["FromWhsCode"].Width - dtgProducts.Columns["ToWhsCode"].Width;
            //cmbCarCode.Focus();
        }

        private DataView dtview = new DataView();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtview.RowFilter = "CardCode like '%" + cmbCarCode.Text + "%' or CardName like '%" + cmbCarCode.Text + "%' or  CardCode = '' or CardName =''";

            cmbCarCode.DataSource = null;
            cmbCarCode.DisplayMember = "CardName";
            cmbCarCode.ValueMember = "CardCode";
            cmbCarCode.DataSource = dtview;

            cmbCarCode.DroppedDown = true;
        }

        private void cmbCarCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCarCode.SelectedIndex > 0)
            {
                string code = cmbCarCode.SelectedValue.ToString();
                txtCustomerCode.Text = code;
            }
            else
            {
                txtCustomerCode.Text = "";
            }
        }

        public static string fromWhsCode = "";
        public static string ToWhsCode = "";

        //public static int currentRow = 0;
        private DataTable dtProducts = new DataTable();

        public static List<StokTransferBatch> StokTransferBatches = new List<StokTransferBatch>();
        public static string arananItemCode = "";

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string ItemCode = "";
                //string partili = "";
                fromWhsCode = cmbFromWhsCode.SelectedValue.ToString();
                ToWhsCode = cmbToWhsCode.SelectedValue.ToString();
                double warehouseQty = 0;

                if (fromWhsCode == "")
                {
                    CustomMsgBox.Show("LÜTFEN KAYNAK DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    return;
                }

                if (ToWhsCode == "")
                {
                    CustomMsgBox.Show("LÜTFEN HEDEF DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    return;
                }
                List<dynamic> list = new List<dynamic>();
                string Val = txtBarCode.Text;
                Val = Giris.UrunKoduBarkod(Val, "Barkod");
                if (Val == "")
                {
                    CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "Tamam", "");
                    txtBarCode.Focus();
                    return;
                }

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = new Response();
                if (Val != "TANIMSIZ")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, fromWhsCode, Giris.mKodValue);
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
                    resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, fromWhsCode, txtCustomerCode.Text, Giris.mKodValue);
                }

                if (resp._list != null)
                {
                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        try
                        {
                            resp._list.Columns.Add("HDepoYeriId", typeof(string));
                            resp._list.Columns.Add("HDepoYeriAdi", typeof(string));
                            resp._list.Columns.Add("KDepoYeriId", typeof(string));
                            resp._list.Columns.Add("KDepoYeriAdi", typeof(string));
                        }
                        catch (Exception)
                        {
                        }
                    }
                    //dtDetails = resp._list;
                    foreach (DataRow item in resp._list.Rows)
                    {
                        DataRow dr = dtProducts.NewRow();
                        dr["Kalem Kodu"] = item["Kalem Kodu"];
                        dr["Kalem Tanımı"] = item["Kalem Tanımı"];
                        dr["Barkod"] = item["Barkod"];
                        dr["Ölçü Birimi"] = item["Ölçü Birimi"];
                        dr["DepoMiktar"] = item["Depo Miktari"];
                        dr["Partili"] = item["Partili"];
                        //dr["DepoKodu"] = wareHouse;
                        dr["PaletIciKoliAD"] = item["PaletIciKoliAD"];
                        dr["KoliIciAD"] = item["KoliIciAD"];
                        dr["PaletIciAD"] = item["PaletIciAD"];
                        dr["PaletIciAD"] = item["PaletIciAD"];
                        dr["PaletIciAD"] = item["PaletIciAD"];

                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            dr["HDepoYeriId"] = txtHedefDepoYeriId.Text.ToString();
                            dr["HDepoYeriAdi"] = txtHedefDepoYeriAdi.Text.ToString();
                            dr["KDepoYeriId"] = txtKaynakDepoYeriId.Text.ToString();
                            dr["KDepoYeriAdi"] = txtHedefDepoYeriAdi.Text.ToString();

                            item["HDepoYeriId"] = txtHedefDepoYeriId.Text.ToString();
                            item["HDepoYeriAdi"] = txtHedefDepoYeriAdi.Text.ToString();
                            item["KDepoYeriId"] = txtKaynakDepoYeriId.Text.ToString();
                            item["KDepoYeriAdi"] = txtKaynakDepoYeriAdi.Text.ToString();
                        }

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
                        //if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                        //{
                        list.Add(txtBarCode.Text);
                        //}
                        if (!doubleclick)
                        {
                            dtProducts.Rows.Add(dr);
                        }

                        (dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["FromWhsCode"] as DataGridViewComboBoxCell).Value = fromWhsCode;

                        (dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["ToWhsCode"] as DataGridViewComboBoxCell).Value = ToWhsCode;
                    }

                    list.Add(txtKaynakDepoYeriId.Text);
                    list.Add(cmbFromWhsCode.SelectedValue);
                    list.Add(cmbToWhsCode.SelectedValue);
                    if (partili == "Y")
                    {
                        if (!doubleclick)
                        {
                            currentRow = dtProducts.Rows.Count;
                        }

                        TalebeBagliDepoNakli_3 n = new TalebeBagliDepoNakli_3("Tlpsz1250000001", list, "TALEPSİZ DEPO NAKLİ");
                        n.ShowDialog();
                        n.Dispose();
                        GC.Collect();

                        if (TalebeBagliDepoNakli_3.dialogresult != "Ok")
                        {
                            if (!doubleclick)
                            {
                                dtProducts.Rows.RemoveAt(currentRow - 1);
                                dtgProducts.Refresh();
                            }
                        }
                        else
                        {
                            var quantity = StokTransferBatches.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                            dtProducts.Rows[currentRow - 1]["Miktar"] = quantity;
                            dtgProducts.Refresh();
                        }

                        TalebeBagliDepoNakli_3.dialogresult = "";
                    }
                    else
                    {
                        //dtProducts.Rows[dtProducts.Rows.Count - 1]["Miktar"] = "1";

                        fromWhsCode = cmbFromWhsCode.SelectedValue.ToString();
                        ToWhsCode = cmbToWhsCode.SelectedValue.ToString();

                        if (fromWhsCode == "")
                        {
                            CustomMsgBox.Show("LÜTFEN KAYNAK DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                            return;
                        }

                        if (ToWhsCode == "")
                        {
                            CustomMsgBox.Show("LÜTFEN HEDEF DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                            return;
                        }
                        list = new List<dynamic>();
                        Val = txtBarCode.Text;

                        if (Val == "")
                        {
                            CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "Tamam", "");
                            txtBarCode.Focus();
                            return;
                        }

                        //aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                        //resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, fromWhsCode);

                        //if (resp._list == null)
                        //{
                        //    resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, fromWhsCode);
                        //}
                        if (!doubleclick)
                        {
                            currentRow = dtgProducts.Rows.Count;
                        }

                        list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                        list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                        list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);
                        list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                        list.Add(Math.Round(acceptqty, Giris.genelParametreler.OndalikMiktar).ToString());

                        var toplananmiktar = dtgProducts.Rows[currentRow - 1].Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgProducts.Rows[currentRow - 1].Cells["Miktar"].Value);

                        list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString());

                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            list.Add(resp._list.Rows[0]["KDepoYeriId"]);
                            list.Add(resp._list.Rows[0]["KDepoYeriAdi"]);
                            list.Add(cmbFromWhsCode.Text.ToString());
                            list.Add(cmbFromWhsCode.SelectedValue.ToString());
                            list.Add(resp._list.Rows[0]["HDepoYeriId"]);
                            list.Add(resp._list.Rows[0]["HDepoYeriAdi"]);
                            list.Add(cmbToWhsCode.Text.ToString());
                            list.Add(cmbToWhsCode.SelectedValue.ToString());
                        }

                        txtBarCode.Text = "";
                        PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("Tlpsz1250000001", list, "TALEPSİZ DEPO NAKLİ");
                        partisizKalemSecimi.ShowDialog();
                        partisizKalemSecimi.Dispose();
                        GC.Collect();

                        if (PartisizKalemSecimi.dialogresult == "Ok")
                        {
                            dtProducts.Rows[currentRow - 1]["Miktar"] = PartisizKalemSecimi.quantity;
                            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                            {
                                dtProducts.Rows[currentRow - 1]["HDepoYeriId"] = PartisizKalemSecimi.hedefDepoYeriId;
                                dtProducts.Rows[currentRow - 1]["HDepoYeriAdi"] = PartisizKalemSecimi.hedefDepoYeriAdi;
                                dtProducts.Rows[currentRow - 1]["KDepoYeriId"] = PartisizKalemSecimi.depoYeriId;
                                dtProducts.Rows[currentRow - 1]["KDepoYeriAdi"] = PartisizKalemSecimi.depoYeriAdi;

                                PartisizKalemSecimi.depoYeriId = "";
                                PartisizKalemSecimi.depoYeriAdi = "";
                                PartisizKalemSecimi.hedefDepoYeriId = "";
                                PartisizKalemSecimi.hedefDepoYeriAdi = "";
                            }
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
                    dtgProducts.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dtgProducts.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //dtgProducts.AutoResizeRows();
                    txtBarCode.Focus();
                    txtBarCode.Text = "";
                    cmbItemName.Text = "";
                    arananItemCode = "";
                    txtItemName.Text = "";

                    btnItemSearch.PerformClick();
                    cmbItemName.DroppedDown = false;
                    vScrollBar1.Maximum = dtgProducts.RowCount + 5;
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
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show(ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void addcomboFromWhsCode()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response r = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpszDepK", Giris.mKodValue);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(r._list);

            DataGridViewComboBoxColumn comboLookup = new DataGridViewComboBoxColumn();
            comboLookup.DataSource = ds.Tables[0];
            comboLookup.HeaderText = "KAYNAK";
            comboLookup.Name = "FromWhsCode";
            comboLookup.DisplayMember = "WhsName";
            comboLookup.ValueMember = "WhsCode";
            dtgProducts.Columns.Add(comboLookup);
        }

        private void addcomboToWhsCode()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response r = null;

            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpszDepH", Giris.mKodValue);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(r._list);

            DataGridViewComboBoxColumn comboLookup = new DataGridViewComboBoxColumn();
            comboLookup.DataSource = ds.Tables[0];
            comboLookup.HeaderText = "HEDEF";
            comboLookup.Name = "ToWhsCode";
            comboLookup.DisplayMember = "WhsName";
            comboLookup.ValueMember = "WhsCode";
            dtgProducts.Columns.Add(comboLookup);
        }

        private void cmbFromWhsCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                if (cmbFromWhsCode.Text != "" && cmbToWhsCode.Text != "")
                {
                    if (cmbFromWhsCode.SelectedValue.ToString() == cmbToWhsCode.SelectedValue.ToString())
                    {
                        CustomMsgBox.Show("KAYNAK DEPO, HEDEF DEPO İLE AYNI OLAMAZ.", "Uyarı", "TAMAM", "");
                        cmbFromWhsCode.SelectedValue = "";
                        return;
                    }
                }
            }
            if (dtgProducts.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("TÜM KAYNAK DEPOLARI DEĞİŞTİRMEYİ İSTİYOR MUSUNUZ?", "DEPO DEĞİŞİMİ", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    for (int i = 0; i <= dtgProducts.Rows.Count - 1; i++)
                    {
                        (dtgProducts.Rows[i].Cells["FromWhsCode"] as DataGridViewComboBoxCell).Value = cmbFromWhsCode.SelectedValue;
                    }
                }
                else
                {
                }
            }

            if (cmbToWhsCode.Text.ToString() != "" && cmbToWhsCode.Text.ToString() != "System.Data.DataRowView" && cmbFromWhsCode.Text.ToString() != "" && cmbFromWhsCode.Text.ToString() != "System.Data.DataRowView")
            {
                txtBarCode.ReadOnly = false;
                txtBarCode.Focus();
            }
        }

        private void cmbToWhsCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                if (cmbFromWhsCode.Text != "" && cmbToWhsCode.Text != "")
                {
                    if (cmbFromWhsCode.SelectedValue.ToString() == cmbToWhsCode.SelectedValue.ToString())
                    {
                        CustomMsgBox.Show("HEDEF DEPO, KAYNAK DEPO İLE AYNI OLAMAZ.", "Uyarı", "TAMAM", "");
                        cmbToWhsCode.SelectedValue = "";
                        return;
                    }
                }
            }
            if (dtgProducts.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("TÜM HEDEF DEPOLARI DEĞİŞTİRMEYİ İSTİYOR MUSUNUZ?", "DEPO DEĞİŞİMİ", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    for (int i = 0; i <= dtgProducts.Rows.Count - 1; i++)
                    {
                        (dtgProducts.Rows[i].Cells["ToWhsCode"] as DataGridViewComboBoxCell).Value = cmbToWhsCode.SelectedValue;
                    }
                }
                else
                {
                }
            }

            if (cmbToWhsCode.Text.ToString() != "" && cmbToWhsCode.Text.ToString() != "System.Data.DataRowView" && cmbFromWhsCode.Text.ToString() != "" && cmbFromWhsCode.Text.ToString() != "System.Data.DataRowView")
            {
                txtBarCode.ReadOnly = false;
                txtBarCode.Focus();
            }
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

                if (cmbFromWhsCode.SelectedValue.ToString() == "")
                {
                    CustomMsgBox.Show("LÜTFEN KAYNAK DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    cmbCarCode.Focus();
                    return;
                }
                if (cmbToWhsCode.SelectedValue.ToString() == "")
                {
                    CustomMsgBox.Show("LÜTFEN HEDEF DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    cmbCarCode.Focus();
                    return;
                }
                if (dtgProducts.Rows.Count == 0)
                {
                    CustomMsgBox.Show("KALEM SEÇİLMEDEN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                    txtBarCode.Focus();
                    return;
                }
                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                    return;
                }
                InventoryGenEntry inventoryGenEntry = new InventoryGenEntry();
                InventoryGenEntryLines inventoryGenEntryLines = new InventoryGenEntryLines();
                List<InventoryGenEntryLines> inventoryGenEntryLines1 = new List<InventoryGenEntryLines>();
                List<InventoryGenEntryLinesBatch> inventoryGenEntryBatchlist = new List<InventoryGenEntryLinesBatch>();
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                int i = 1;
                int index = 0;
                inventoryGenEntry.CardCode = txtCustomerCode.Text;
                inventoryGenEntry.DocDate = dtpDocDate.Value.ToString("yyyyMMdd");
                //inventoryGenEntry..DocDueDate = dtpTransferDate.Value.ToString("yyyyMMdd");

                foreach (DataRow items in dtProducts.Rows)
                {
                    if (items["Miktar"].ToString() == "0" || items["Miktar"].ToString() == "")
                    {
                        i++;
                        continue;
                    }

                    inventoryGenEntryLines = new InventoryGenEntryLines();
                    inventoryGenEntryBatchlist = new List<InventoryGenEntryLinesBatch>();
                    foreach (var aifx in StokTransferBatches.Where(x => x.ItemCode == items["Kalem Kodu"].ToString() && x.LineNumber == i))
                    {
                        inventoryGenEntryBatchlist.Add(new InventoryGenEntryLinesBatch
                        {
                            BatchNumber = aifx.BatchNumber,
                            BatchQuantity = aifx.BatchQuantity,
                            DepoYeriId = aifx.DepoYeriId,
                            HedefDepoYeriId = aifx.HedefDepoYeriId
                        });
                    }

                    inventoryGenEntryLines1.Add(new InventoryGenEntryLines
                    {
                        InventoryGenEntryLinesBatch = inventoryGenEntryBatchlist.ToArray(),
                        ItemCode = items["Kalem Kodu"].ToString(),
                        Quantity = Math.Round(Convert.ToDouble(items["Miktar"]), Giris.genelParametreler.OndalikMiktar),
                        fromWhsCode = dtgProducts.Rows[index].Cells["FromWhsCode"].Value.ToString(),
                        toWhsCode = dtgProducts.Rows[index].Cells["ToWhsCode"].Value.ToString(),
                        BinCode_from = Giris.genelParametreler.DepoYeriCalisir == "Y" && items["Partili"].ToString() != "Y" ? dtgProducts.Rows[index].Cells["KDepoYeriId"].Value.ToString() : "",
                        BinCode_to = Giris.genelParametreler.DepoYeriCalisir == "Y" && items["Partili"].ToString() != "Y" ? dtgProducts.Rows[index].Cells["HDepoYeriId"].Value.ToString() : "",
                    });

                    inventoryGenEntry.InventoryGenEntryLines = inventoryGenEntryLines1.ToArray();
                    i++;
                    index++;
                }

                if (inventoryGenEntry.InventoryGenEntryLines == null)
                {
                    CustomMsgBox.Show("TÜM SATIRLARIN MİKTARI 0 OLAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }
                else if (inventoryGenEntry.InventoryGenEntryLines.Count() == 0)
                {
                    CustomMsgBox.Show("TÜM SATIRLARIN MİKTARI 0 OLAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }

                Response resp1 = new Response();
                if (Giris.genelParametreler.TalepsizDepoNaklindeTaslakBelgeOlustur == "Y")
                {
                    resp1 = aIFTerminalServiceSoapClient1.AddOrUpdateStockTransfer_3(Giris._dbName, Convert.ToInt32(Giris._userCode), inventoryGenEntry);
                }
                else
                {
                    resp1 = aIFTerminalServiceSoapClient1.AddOrUpdateStockTransfer(Giris._dbName, Convert.ToInt32(Giris._userCode), inventoryGenEntry);
                }

                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

                if (resp1.Val == 0)
                {
                    Close();
                    //buttonlistele.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void cmbFromWhsCode_Click(object sender, EventArgs e)
        {
            cmbFromWhsCode.DroppedDown = true;
        }

        private void cmbToWhsCode_Click(object sender, EventArgs e)
        {
            cmbToWhsCode.DroppedDown = true;
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }

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

                    partili = dtProducts.Rows[e.RowIndex]["Partili"].ToString();
                    if (partili != "Y")
                    {
                        CustomMsgBox.Show("PARTİLİ OLMAYAN ÜRÜNÜN DETAYINA GİDİLEMEZ.", "Uyarı", "Tamam", "");
                        return;
                    }

                    string ItemCode = dtProducts.Rows[e.RowIndex]["Kalem Kodu"].ToString();
                    list.Add(dtProducts.Rows[e.RowIndex]["Kalem Kodu"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["Kalem Tanımı"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["Barkod"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["Ölçü Birimi"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["DepoMiktar"].ToString());

                    TalebeBagliDepoNakli_3 n = new TalebeBagliDepoNakli_3("Tlpsz1250000001", list, "TALEPSİZ DEPO NAKLİ");
                    n.ShowDialog();
                    n.Dispose();
                    GC.Collect();

                    var quantity = StokTransferBatches.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                    dtProducts.Rows[currentRow - 1]["Miktar"] = quantity;
                }
            }
        }

        private string barcode = "";
        private string partili = "";
        private string itemCode = "";
        private string itemName = "";
        public static int currentRow = 0;
        private double acceptqty = 0;
        private double paletIciKoliAD = 0;
        private double koliIciAD = 0;
        private double paletIciAD = 0;
        private int DocEntry = -1;

        private double topMik = 0;

        private void dtgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                partili = dtProducts.Rows[e.RowIndex]["Partili"].ToString();
                barcode = dtProducts.Rows[e.RowIndex]["Barkod"].ToString();
                itemCode = dtProducts.Rows[e.RowIndex]["Kalem Kodu"].ToString();
                itemName = dtProducts.Rows[e.RowIndex]["Kalem Tanımı"].ToString();
                //acceptqty = dtProducts.Rows[e.RowIndex]["Miktar"].ToString() == "" ? 0 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["Miktar"]);
                txtBarCode.Text = barcode == "" ? itemCode : barcode;
                //txtBarCode.Text = barcode.ToString() != "" ? barcode.ToString() : itemCode;
                currentRow = e.RowIndex + 1;

                paletIciKoliAD = dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"]);
                koliIciAD = dtProducts.Rows[e.RowIndex]["KoliIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["KoliIciAD"]);
                paletIciAD = dtProducts.Rows[e.RowIndex]["PaletIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciAD"]);

                topMik = dtProducts.Rows[e.RowIndex]["Miktar"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["Miktar"]);
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
            return;
            //}
            //else
            //{
            //    fromWhsCode = cmbFromWhsCode.SelectedValue.ToString();
            //    ToWhsCode = cmbToWhsCode.SelectedValue.ToString();

            //    if (fromWhsCode == "")
            //    {
            //        CustomMsgBox.Show("LÜTFEN KAYNAK DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
            //        return;
            //    }

            //    if (ToWhsCode == "")
            //    {
            //        CustomMsgBox.Show("LÜTFEN HEDEF DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
            //        return;
            //    }
            //    List<dynamic> list = new List<dynamic>();
            //    string Val = txtBarCode.Text;

            //    if (Val == "")
            //    {
            //        CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "Tamam", "");
            //        txtBarCode.Focus();
            //        return;
            //    }

            //    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            //    Response resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, fromWhsCode);

            //    if (resp._list == null)
            //    {
            //        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, fromWhsCode);
            //    }

            //    currentRow = dtProducts.Rows.Count;

            //    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
            //    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
            //    list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);
            //    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
            //    list.Add(Math.Round(acceptqty, 4).ToString());

            //    txtBarCode.Text = "";
            //    PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("Tlpsz1250000001", list, "TALEPSİZ DEPO NAKLİ");
            //    partisizKalemSecimi.ShowDialog();

            //    if (PartisizKalemSecimi.dialogresult == "Ok")
            //    {
            //        dtProducts.Rows[currentRow]["Miktar"] = PartisizKalemSecimi.quantity;
            //        PartisizKalemSecimi.dialogresult = "";
            //    }
            //    dtgProducts.Rows[currentRow].Selected = false;
            //    partili = "";
            //    barcode = "";
            //}
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
                        //if (dtgProducts.Columns.Contains("FromWhsCode") != true)
                        //{
                        //    addcomboFromWhsCode();
                        //}

                        //if (dtgProducts.Columns.Contains("ToWhsCode") != true)
                        //{
                        //    addcomboToWhsCode();
                        //}

                        dtgProducts.Columns["DepoMiktar"].Visible = false;
                        dtgProducts.Columns["btnDetail"].Visible = false;
                        dtgProducts.Columns["Barkod"].Visible = false;

                        dtgProducts.Columns["Kalem Kodu"].Visible = false;
                        dtgProducts.Columns["Partili"].Visible = false;

                        dtgProducts.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                        dtgProducts.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
                        dtgProducts.Columns["Kalem Tanımı"].HeaderText = "KALEM ADI";
                        dtgProducts.Columns["Ölçü Birimi"].HeaderText = "BRM";
                        dtgProducts.Columns["Barkod"].HeaderText = "BARKOD";
                        dtgProducts.Columns["Miktar"].HeaderText = "MİKTAR";
                        dtgProducts.Columns["DepoMiktar"].HeaderText = "DEPO MİK.";
                        dtgProducts.Columns["Partili"].HeaderText = "PARTİLİ";

                        dtgProducts.Columns["Kalem Kodu"].ReadOnly = true;
                        dtgProducts.Columns["Kalem Tanımı"].ReadOnly = true;
                        dtgProducts.Columns["Ölçü Birimi"].ReadOnly = true;
                        dtgProducts.Columns["Miktar"].ReadOnly = true;
                        dtgProducts.Columns["Partili"].ReadOnly = true;

                        btnAdd.PerformClick();
                    }
                }
            }
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            if (cmbFromWhsCode.SelectedValue == "" || cmbFromWhsCode.SelectedValue.ToString() == null)
            {
                CustomMsgBox.Show("LÜTFEN KAYNAK DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }
            if (cmbToWhsCode.SelectedValue == "" || cmbToWhsCode.SelectedValue.ToString() == null)
            {
                CustomMsgBox.Show("LÜTFEN HEDEF DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
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

        private void cmbFromWhsCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFromWhsCode.SelectedIndex > 0)
            {
                string code = cmbFromWhsCode.SelectedValue.ToString();
                txtSourceCode.Text = code;
                txtBarCode.Focus();
            }
            else
            {
                //cmbSuppLierName.DroppedDown = true;
                txtSourceCode.Text = "";
            }
        }

        private void cmbToWhsCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbToWhsCode.SelectedIndex > 0)
            {
                string code = cmbToWhsCode.SelectedValue.ToString();
                txtTargetCode.Text = code;
                txtBarCode.Focus();
            }
            else
            {
                //cmbSuppLierName.DroppedDown = true;
                txtTargetCode.Text = "";
            }
        }

        private void btnBarkodGoster_Click(object sender, EventArgs e)
        {
            ListParties = new List<Parties>();

            List<dynamic> list = new List<dynamic>();
            var partiler = StokTransferBatches.Where(x => x.ItemCode == itemCode).ToList();
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
                        #region old

                        //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                        #endregion old

                        if (barcode == "")
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                        }
                        else
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                        }
                    }
                }
                else
                {
                    #region old

                    //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                    #endregion old

                    if (barcode == "")
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                    }
                    else
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                    }
                }
            }
            else
            {
                #region old 20trmn

                //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                #endregion old 20trmn

                if (barcode == "")
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                }
                else
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                }
            }

            txtBarCode.Text = "";
            BarkodGoruntule barkodGoruntule = new BarkodGoruntule("Tlpsz1250000001", ListParties, "BARKOD GÖRÜNTÜLEME");
            barkodGoruntule.ShowDialog();
            barkodGoruntule.Dispose();
            GC.Collect();

            try
            {
                dtgProducts.Rows[currentRow - 1].Selected = false;
            }
            catch (Exception ex)
            {
            }
            ListParties = new List<Parties>();
        }

        public static List<Parties> ListParties = new List<Parties>();

        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            SelectList nesne = new SelectList("Tlpsz1250000001", "MuhatapAra", "MUHATAP ARAMA", txtCustomerCode, txtCustomerName);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();
        }

        private void txtItemName_Click(object sender, EventArgs e)
        {
            if (cmbFromWhsCode.SelectedValue == null || cmbFromWhsCode.SelectedValue.ToString() == "")
            {
                CustomMsgBox.Show("LÜTFEN KAYNAK DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }
            if (cmbToWhsCode.SelectedValue == null || cmbToWhsCode.SelectedValue.ToString() == "")
            {
                CustomMsgBox.Show("LÜTFEN HEDEF DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }
            SelectList nesne = new SelectList("Tlpsz1250000001", "KalemAra", "KALEM ARAMA", txtBarCode, txtItemName);
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

        private void txtKaynakDepoYeriAdi_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtKaynakDepoYeriAdi_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox t = new TextBox();
                t.Text = cmbFromWhsCode.SelectedValue.ToString();
                SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtKaynakDepoYeriId, txtKaynakDepoYeriAdi, t);
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

        private void txtHedefDepoYeriAdi_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox t = new TextBox();
                t.Text = cmbToWhsCode.SelectedValue.ToString();
                SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtHedefDepoYeriId, txtHedefDepoYeriAdi, t);
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