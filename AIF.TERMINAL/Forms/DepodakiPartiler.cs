using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class DepodakiPartiler : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        private string type = "";

        public DepodakiPartiler(string _type, DataTable _dtBatchList, NumericUpDown _textBoxQty, TextBox _textboxBatchNum, string _formName)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            dtBatchList = _dtBatchList;
            textboxBatchNum = _textboxBatchNum;
            textboxQty = _textBoxQty;

            formName = _formName;
            type = _type;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            lblItemCodeName.Font = new Font(lblItemCodeName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemCodeName.Font.Style);

            lblWareHouseCodeName.Font = new Font(lblWareHouseCodeName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblWareHouseCodeName.Font.Style);

            txtItemCode.Font = new Font(txtItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemCode.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtWhsCode.Font = new Font(txtWhsCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWhsCode.Font.Style);

            txtWhsName.Font = new Font(txtWhsName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWhsName.Font.Style);

            dtgBatch.Font = new Font(dtgBatch.Font.FontFamily, initialFontSize *
            (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            dtgBatch.Font.Style);

            btnSelect.Font = new Font(btnSelect.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSelect.Font.Style);

            ResumeLayout();
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

        private TextBox textboxBatchNum = new TextBox();
        //private TextBox textboxQty = new TextBox();
        private NumericUpDown textboxQty = new NumericUpDown();

        private DataTable dtBatchList = new DataTable();
        private DataTable dtBatchListTemp = new DataTable();
        private string formName = "";

        private void DepodakiPartiler_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;

            dtgBatch.RowTemplate.Height = 55;
            dtgBatch.ColumnHeadersHeight = 60;

            vScrollBar1.Maximum = dtgBatch.RowCount;
            try
            {
                if (type == "1250000001")
                {
                    dtBatchListTemp = dtBatchList.Copy();
                    dtBatchListTemp.Rows.Clear();
                    if (TalebeBagliDepoNakli_3.dtParties.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtBatchList.Rows)
                        {
                            var batchNumber = item["BatchNum"].ToString();
                            var batchQty = Convert.ToDouble(item["Quantity"]);

                            var PartyExist = TalebeBagliDepoNakli_3.dtParties.AsEnumerable().Where(x => x.Field<string>("Parti No") == batchNumber).ToList();

                            if (PartyExist.Count > 0)
                            {
                                double partyQty = PartyExist.Where(y => y.Field<string>("Parti No") == batchNumber).Sum(x => x.Field<double>("Parti Miktarı"));
                                if (batchQty - partyQty > 0)
                                {
                                    DataRow dr2 = dtBatchListTemp.NewRow();
                                    dr2["ItemCode"] = item["ItemCode"].ToString();
                                    dr2["ItemName"] = item["ItemName"].ToString();
                                    dr2["BatchNum"] = item["BatchNum"].ToString();
                                    dr2["Quantity"] = Convert.ToDouble(item["Quantity"]) - partyQty;
                                    dr2["WhsName"] = item["WhsName"].ToString();
                                    dr2["WhsCode"] = item["WhsCode"].ToString();
                                    dtBatchListTemp.Rows.Add(dr2);
                                }
                            }
                            else
                            {
                                DataRow dr2 = dtBatchListTemp.NewRow();
                                dr2["ItemCode"] = item["ItemCode"].ToString();
                                dr2["ItemName"] = item["ItemName"].ToString();
                                dr2["BatchNum"] = item["BatchNum"].ToString();
                                dr2["Quantity"] = Convert.ToDouble(item["Quantity"]);
                                dr2["WhsName"] = item["WhsName"].ToString();
                                dr2["WhsCode"] = item["WhsCode"].ToString();

                                dtBatchListTemp.Rows.Add(dr2);
                            }
                        }
                    }
                    else
                    {
                        dtBatchListTemp = dtBatchList;
                    }
                }
                else if (type == "Tlpsz1250000001")
                {
                    dtBatchListTemp = dtBatchList.Copy();
                    dtBatchListTemp.Rows.Clear();
                    if (TalebeBagliDepoNakli_3.dtParties.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtBatchList.Rows)
                        {
                            var batchNumber = item["BatchNum"].ToString();
                            var batchQty = Convert.ToDouble(item["Quantity"]);

                            var PartyExist = TalebeBagliDepoNakli_3.dtParties.AsEnumerable().Where(x => x.Field<string>("Parti No") == batchNumber).ToList();

                            if (PartyExist.Count > 0)
                            {
                                double partyQty = PartyExist.Where(y => y.Field<string>("Parti No") == batchNumber).Sum(x => x.Field<double>("Parti Miktarı"));
                                if (batchQty - partyQty > 0)
                                {
                                    DataRow dr2 = dtBatchListTemp.NewRow();
                                    dr2["ItemCode"] = item["ItemCode"].ToString();
                                    dr2["ItemName"] = item["ItemName"].ToString();
                                    dr2["BatchNum"] = item["BatchNum"].ToString();
                                    dr2["Quantity"] = Convert.ToDouble(item["Quantity"]) - partyQty;
                                    dr2["WhsName"] = item["WhsName"].ToString();
                                    dr2["WhsCode"] = item["WhsCode"].ToString();
                                    dtBatchListTemp.Rows.Add(dr2);
                                }
                            }
                            else
                            {
                                DataRow dr2 = dtBatchListTemp.NewRow();
                                dr2["ItemCode"] = item["ItemCode"].ToString();
                                dr2["ItemName"] = item["ItemName"].ToString();
                                dr2["BatchNum"] = item["BatchNum"].ToString();
                                dr2["Quantity"] = Convert.ToDouble(item["Quantity"]);
                                dr2["WhsName"] = item["WhsName"].ToString();
                                dr2["WhsCode"] = item["WhsCode"].ToString();

                                dtBatchListTemp.Rows.Add(dr2);
                            }
                        }
                    }
                    else
                    {
                        dtBatchListTemp = dtBatchList;
                    }
                }
                else if (type == "17")
                {
                    dtBatchListTemp = dtBatchList.Copy();
                    dtBatchListTemp.Rows.Clear();
                    if (SipariseBagliTeslimat_3.dtAllParties.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtBatchList.Rows)
                        {
                            var batchNumber = item["BatchNum"].ToString();
                            var batchQty = Convert.ToDouble(item["Quantity"]);

                            var PartyExist = SipariseBagliTeslimat_3.dtParties.AsEnumerable().Where(x => x.Field<string>("Parti No") == batchNumber).ToList();

                            if (PartyExist.Count > 0)
                            {
                                double partyQty = PartyExist.Where(y => y.Field<string>("Parti No") == batchNumber).Sum(x => x.Field<double>("Parti Miktarı"));

                                if (batchQty - partyQty > 0)
                                {
                                    DataRow dr2 = dtBatchListTemp.NewRow();
                                    dr2["ItemCode"] = item["ItemCode"].ToString();
                                    dr2["ItemName"] = item["ItemName"].ToString();
                                    dr2["BatchNum"] = item["BatchNum"].ToString();
                                    dr2["Quantity"] = Convert.ToDouble(item["Quantity"]) - partyQty;
                                    dr2["WhsName"] = item["WhsName"].ToString();
                                    dr2["WhsCode"] = item["WhsCode"].ToString();
                                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                                    {
                                        dr2["BinAbs"] = item["BinAbs"].ToString();
                                        dr2["BinCode"] = item["BinCode"].ToString(); 
                                    }
                                    dtBatchListTemp.Rows.Add(dr2);
                                }
                            }
                            else
                            {
                                DataRow dr2 = dtBatchListTemp.NewRow();
                                dr2["ItemCode"] = item["ItemCode"].ToString();
                                dr2["ItemName"] = item["ItemName"].ToString();
                                dr2["BatchNum"] = item["BatchNum"].ToString();
                                dr2["Quantity"] = Convert.ToDouble(item["Quantity"]);
                                dr2["WhsName"] = item["WhsName"].ToString();
                                dr2["WhsCode"] = item["WhsCode"].ToString();
                                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                                {
                                    dr2["BinAbs"] = item["BinAbs"].ToString();
                                    dr2["BinCode"] = item["BinCode"].ToString(); 
                                }

                                dtBatchListTemp.Rows.Add(dr2);
                            }
                        }
                    }
                    else
                    {
                        dtBatchListTemp = dtBatchList;
                    }
                }
                else if (type == "Sprssz17")
                {
                    dtBatchListTemp = dtBatchList.Copy();
                    dtBatchListTemp.Rows.Clear();

                    if (SipariseBagliTeslimat_3.dtParties.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtBatchList.Rows)
                        {
                            var batchNumber = item["BatchNum"].ToString();
                            var batchQty = Convert.ToDouble(item["Quantity"]);

                            //var PartyExist = SiparissizTesilmat_1.DeliveryBatches.Where(x => x.BatchNumber == batchNumber).ToList();
                            var PartyExist = SipariseBagliTeslimat_3.dtParties.AsEnumerable().Where(x => x.Field<string>("Parti No") == batchNumber).ToList();

                            if (PartyExist.Count > 0)
                            {
                                double partyQty = PartyExist.Where(y => y.Field<string>("Parti No") == batchNumber).Sum(x => x.Field<double>("Parti Miktarı"));

                                //double partyQty = PartyExist.Where(y => y.BatchNumber == batchNumber).Sum(z => z.BatchQuantity);
                                if (batchQty - partyQty > 0)
                                {
                                    DataRow dr2 = dtBatchListTemp.NewRow();
                                    dr2["ItemCode"] = item["ItemCode"].ToString();
                                    dr2["ItemName"] = item["ItemName"].ToString();
                                    dr2["BatchNum"] = item["BatchNum"].ToString();
                                    dr2["Quantity"] = Convert.ToDouble(item["Quantity"]) - partyQty;
                                    dr2["WhsName"] = item["WhsName"].ToString();
                                    dr2["WhsCode"] = item["WhsCode"].ToString();
                                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                                    {
                                        dr2["BinAbs"] = item["BinAbs"].ToString();
                                        dr2["BinCode"] = item["BinCode"].ToString(); 
                                    }
                                    dtBatchListTemp.Rows.Add(dr2);
                                }
                                //else
                                //{
                                //    MessageBox.Show("içeride parti yok");
                                //    return;
                                //}
                            }
                            else
                            {
                                DataRow dr2 = dtBatchListTemp.NewRow();
                                dr2["ItemCode"] = item["ItemCode"].ToString();
                                dr2["ItemName"] = item["ItemName"].ToString();
                                dr2["BatchNum"] = item["BatchNum"].ToString();
                                dr2["Quantity"] = Convert.ToDouble(item["Quantity"]);
                                dr2["WhsName"] = item["WhsName"].ToString();
                                dr2["WhsCode"] = item["WhsCode"].ToString();
                                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                                {
                                    dr2["BinAbs"] = item["BinAbs"].ToString();
                                    dr2["BinCode"] = item["BinCode"].ToString(); 
                                }

                                dtBatchListTemp.Rows.Add(dr2);
                            }
                        }
                    }
                    else
                    {
                        dtBatchListTemp = dtBatchList;
                    }
                }
                else if (type == "60")
                {
                    dtBatchListTemp = dtBatchList.Copy();
                    dtBatchListTemp.Rows.Clear();
                    if (SipariseBagliTeslimat_3.dtParties.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtBatchList.Rows)
                        {
                            var batchNumber = item["BatchNum"].ToString();
                            var batchQty = Convert.ToDouble(item["Quantity"]);

                            var PartyExist = SipariseBagliTeslimat_3.dtParties.AsEnumerable().Where(x => x.Field<string>("Parti No") == batchNumber).ToList();

                            if (PartyExist.Count > 0)
                            {
                                double partyQty = PartyExist.Where(y => y.Field<string>("Parti No") == batchNumber).Sum(x => x.Field<double>("Parti Miktarı"));

                                if (batchQty - partyQty > 0)
                                {
                                    DataRow dr2 = dtBatchListTemp.NewRow();
                                    dr2["ItemCode"] = item["ItemCode"].ToString();
                                    dr2["ItemName"] = item["ItemName"].ToString();
                                    dr2["BatchNum"] = item["BatchNum"].ToString();
                                    dr2["Quantity"] = Convert.ToDouble(item["Quantity"]) - partyQty;
                                    dr2["WhsName"] = item["WhsName"].ToString();
                                    dr2["WhsCode"] = item["WhsCode"].ToString();
                                    dtBatchListTemp.Rows.Add(dr2);
                                }
                            }
                            else
                            {
                                DataRow dr2 = dtBatchListTemp.NewRow();
                                dr2["ItemCode"] = item["ItemCode"].ToString();
                                dr2["ItemName"] = item["ItemName"].ToString();
                                dr2["BatchNum"] = item["BatchNum"].ToString();
                                dr2["Quantity"] = Convert.ToDouble(item["Quantity"]);
                                dr2["WhsName"] = item["WhsName"].ToString();
                                dr2["WhsCode"] = item["WhsCode"].ToString();

                                dtBatchListTemp.Rows.Add(dr2);
                            }
                        }
                    }
                    else
                    {
                        dtBatchListTemp = dtBatchList;
                    }
                }
                else if (type == "Palet")
                {
                    dtBatchListTemp = dtBatchList.Copy();
                    dtBatchListTemp.Rows.Clear();
                    if (PaletYapma_3.dtParties.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtBatchList.Rows)
                        {
                            var batchNumber = item["BatchNum"].ToString();
                            var batchQty = Convert.ToDouble(item["Quantity"]);

                            var PartyExist = PaletYapma_3.dtParties.AsEnumerable().Where(x => x.Field<string>("Parti No") == batchNumber).ToList();

                            if (PartyExist.Count > 0)
                            {
                                double partyQty = PartyExist.Where(y => y.Field<string>("Parti No") == batchNumber).Sum(x => x.Field<double>("Parti Miktarı"));

                                if (batchQty - partyQty > 0)
                                {
                                    DataRow dr2 = dtBatchListTemp.NewRow();
                                    dr2["ItemCode"] = item["ItemCode"].ToString();
                                    dr2["ItemName"] = item["ItemName"].ToString();
                                    dr2["BatchNum"] = item["BatchNum"].ToString();
                                    dr2["Quantity"] = Convert.ToDouble(item["Quantity"]) - partyQty;
                                    dr2["WhsName"] = item["WhsName"].ToString();
                                    dr2["WhsCode"] = item["WhsCode"].ToString();
                                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                                    {
                                        dr2["BinAbs"] = item["BinAbs"].ToString();
                                        dr2["BinCode"] = item["BinCode"].ToString(); 
                                    }
                                    dtBatchListTemp.Rows.Add(dr2);
                                }
                            }
                            else
                            {
                                DataRow dr2 = dtBatchListTemp.NewRow();
                                dr2["ItemCode"] = item["ItemCode"].ToString();
                                dr2["ItemName"] = item["ItemName"].ToString();
                                dr2["BatchNum"] = item["BatchNum"].ToString();
                                dr2["Quantity"] = Convert.ToDouble(item["Quantity"]);
                                dr2["WhsName"] = item["WhsName"].ToString();
                                dr2["WhsCode"] = item["WhsCode"].ToString();
                                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                                {
                                    dr2["BinAbs"] = item["BinAbs"].ToString();
                                    dr2["BinCode"] = item["BinCode"].ToString(); 
                                }

                                dtBatchListTemp.Rows.Add(dr2);
                            }
                        }
                    }
                    else
                    {
                        dtBatchListTemp = dtBatchList;
                    }
                }
                //}

                //parti ekranı girişinde hata veriyor
                dtgBatch.DataSource = dtBatchListTemp;

                if (dtBatchListTemp.Rows.Count == 0)
                {
                    Close();
                    CustomMsgBox.Show("PARTİ BULUNAMADI", "UYARI", "TAMAM", "");
                    return;
                }
                if (dtgBatch.Rows.Count > 0)
                {
                    dtgBatch.Columns["ItemCode"].HeaderText = "KALEM KODU";
                    dtgBatch.Columns["ItemName"].HeaderText = "KALEM ADI";
                    dtgBatch.Columns["BatchNum"].HeaderText = "PARTİ NUMARASI";
                    dtgBatch.Columns["WhsCode"].HeaderText = "DEPO KODU";
                    dtgBatch.Columns["WhsName"].HeaderText = "DEPO ADI";
                    dtgBatch.Columns["Quantity"].HeaderText = "MİKTAR";
                    dtgBatch.Columns["Quantity"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                    if (Giris.mKodValue == "20TRMN")
                    {
                        dtgBatch.Columns["MnfSerial"].HeaderText = "PARTİ NİTELİĞİ";
                    }

                    dtgBatch.Columns["ItemCode"].Visible = false;
                    dtgBatch.Columns["ItemName"].Visible = false;
                    dtgBatch.Columns["WhsCode"].Visible = false;
                    dtgBatch.Columns["WhsName"].Visible = false;
                    //Checkboxolustur();

                    //dtgBatch.Columns["BatchNum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dtgBatch.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    //dtgBatch.Columns["ItemName"].Width = dtgBatch.Width - dtgBatch.Columns["BatchNum"].Width - dtgBatch.Columns["Quantity"].Width;

                    dtgBatch.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    foreach (DataGridViewColumn column in dtgBatch.Columns) //columns tıklama
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    //dtgPurchaseOrders.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                    dtgBatch.Rows[0].Selected = false;

                    var itemCode = dtgBatch.Rows[0].Cells["ItemCode"].Value.ToString();
                    var itemName = dtgBatch.Rows[0].Cells["ItemName"].Value.ToString();

                    var whsCode = dtgBatch.Rows[0].Cells["WhsCode"].Value.ToString();
                    var whsName = dtgBatch.Rows[0].Cells["WhsName"].Value.ToString();

                    txtItemCode.Text = itemCode.ToString();
                    txtItemName.Text = itemName.ToString();

                    txtWhsCode.Text = whsCode.ToString();
                    txtWhsName.Text = whsName.ToString();

                    vScrollBar1.Maximum = dtgBatch.RowCount + 5;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private DataGridViewCheckBoxColumn checkColumn = null;

        private void Checkboxolustur()
        {
            checkColumn = new DataGridViewCheckBoxColumn();

            checkColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn.HeaderText = "SEÇ";
            checkColumn.Name = "ScmCheck";
            checkColumn.TrueValue = true;
            checkColumn.FalseValue = false;
            dtgBatch.Columns.Add(checkColumn);

            dtgBatch.RowHeadersVisible = false;
        }

        private void dtgBatch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dtgBatch.Rows[e.RowIndex];
            //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
            //if (chk.Value == chk.FalseValue || chk.Value == null)
            //{
            //    chk.Value = chk.TrueValue;
            //    dtgBatch.EndEdit();
            //}
            //else
            //{
            //    chk.Value = chk.FalseValue;
            //}
        }

        private void dtgBatch_DoubleClick(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgBatch.Rows.Count == 0)
                {
                    CustomMsgBox.Show("ÜRÜNE AİT PARTİ BULUNMADIĞINDAN SEÇİM YAPILAMAZ.", "UYARI", "TAMAM", "");
                    return;
                }
                if (dtgBatch.CurrentCell == null)
                {
                    return;
                }
                this.Close();
                var Batchvalue = dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BatchNum"].Value.ToString();
                var Qty = Convert.ToDouble(dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["Quantity"].Value);
                textboxBatchNum.Text = Batchvalue;
                textboxQty.Text = Qty.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                if (type == "1250000001")
                {
                    TalebeBagliDepoNakli_3.dialogresult = "Ok"; 
                        TalebeBagliDepoNakli_3.secilenpartinumarasinindepoyeridsi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BinAbs"].Value.ToString():"";
                        TalebeBagliDepoNakli_3.secilenpartinumarasinindepoyeriAdi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BinCode"].Value.ToString():"";  
                }
                else if (type == "Tlpsz1250000001")
                {
                    TalebeBagliDepoNakli_3.dialogresult = "Ok";

                    TalebeBagliDepoNakli_3.secilenpartinumarasinindepoyeridsi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BinAbs"].Value.ToString():"";
                    TalebeBagliDepoNakli_3.secilenpartinumarasinindepoyeriAdi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BinCode"].Value.ToString():"";
                }
                else if (type == "17")
                {
                    if (Qty > 0)
                    {
                        textboxQty.BackColor = Color.LimeGreen;
                    }
                    SipariseBagliTeslimat_3.secilenpartinumarasinindepoyeridsi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BinAbs"].Value.ToString():"";
                    SipariseBagliTeslimat_3.secilenpartinumarasinindepoyeriAdi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BinCode"].Value.ToString():"";

                    SipariseBagliTeslimat_3.dialogResult = "Ok";
                }
                else if (type == "Sprssz17")
                {
                    if (Qty > 0)
                    {
                        textboxQty.BackColor = Color.LimeGreen;
                    }
                    SipariseBagliTeslimat_3.secilenpartinumarasinindepoyeridsi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BinAbs"].Value.ToString():"";
                    SipariseBagliTeslimat_3.secilenpartinumarasinindepoyeriAdi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BinCode"].Value.ToString():"";

                    SipariseBagliTeslimat_3.dialogResult = "Ok";
                }
                else if (type == "60")
                {
                    if (Qty > 0)
                    {
                        textboxQty.BackColor = Color.LimeGreen;
                    }

                    SipariseBagliTeslimat_3.secilenpartinumarasinindepoyeridsi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BinAbs"].Value.ToString():"";
                    SipariseBagliTeslimat_3.secilenpartinumarasinindepoyeriAdi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgBatch.Rows[dtgBatch.CurrentCell.RowIndex].Cells["BinCode"].Value.ToString():"";

                    SipariseBagliTeslimat_3.dialogResult = "Ok";
                }
                else if (type == "Palet")
                {
                    if (Qty > 0)
                    {
                        PaletYapma_3.dialogresult = "Ok";
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgBatch_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgBatch.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }
    }
}