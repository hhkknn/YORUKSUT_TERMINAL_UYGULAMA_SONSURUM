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
    public partial class TalebeBagliDepoNakli_3_Kabul : form_Base
    {
        private int rowIndex = 0;

        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        private string type = "";

        private List<dynamic> list = null;

        public TalebeBagliDepoNakli_3_Kabul(string _type, List<dynamic> _list, string _formName)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;
            //end font

            formName = _formName;
            list = _list;
            type = _type;
            txtItemCode.Text = list[0].ToString();
            txtItemName.Text = list[1].ToString();
            txtBarCode.Text = list[2].ToString();
            txtUomCode.Text = list[3].ToString();
            //txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
            //txtAccepted.Text = Convert.ToDouble(list[6]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
            txtOnOrder.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
            txtUnAccepted.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
            txtOnOrder.ReadOnly = true;
            if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
            {
                txtBatchNumber.Text = list[7];
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

            label9.Font = new Font(label9.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label9.Font.Style);

            label10.Font = new Font(label10.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label10.Font.Style);

            label12.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label12.Font.Style);

            label13.Font = new Font(label13.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label13.Font.Style);

            label14.Font = new Font(label14.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label14.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            txtItemCode.Font = new Font(txtItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemCode.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtWhsQuantity.Font = new Font(txtWhsQuantity.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWhsQuantity.Font.Style);

            txtUomCode.Font = new Font(txtUomCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUomCode.Font.Style);

            txtOnOrder.Font = new Font(txtOnOrder.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtOnOrder.Font.Style);

            txtAccepted.Font = new Font(txtAccepted.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtAccepted.Font.Style);

            txtUnAccepted.Font = new Font(txtUnAccepted.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUnAccepted.Font.Style);

            txtBatchNumber.Font = new Font(txtBatchNumber.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBatchNumber.Font.Style);

            txtPartyBarcode.Font = new Font(txtPartyBarcode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyBarcode.Font.Style);

            txtBatchQty.Font = new Font(txtBatchQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBatchQty.Font.Style);

            btnShowBatchWhs.Font = new Font(btnShowBatchWhs.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnShowBatchWhs.Font.Style);

            btnCollect.Font = new Font(btnCollect.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnCollect.Font.Style);

            btnComplete.Font = new Font(btnComplete.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnComplete.Font.Style);

            dtgParties.Font = new Font(dtgParties.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgParties.Font.Style);

            btnRowDel.Font = new Font(btnRowDel.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnRowDel.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtBatchNumber.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBatchQty.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
        }

        public static string dialogresult = "";

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

        public static DataTable dtParties = new DataTable();

        private void btnCollect_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentRow != -1)
                {
                    dtgParties.Rows[currentRow].Cells["Parti Miktarı"].Value = Convert.ToDouble(txtBatchQty.Text);
                    //currentRow = -1;
                }
            }
            catch (Exception)
            {
            }
        }

        private string warehouse = "";
        private string formName = "";

        private void TalebeBagliDepoNakli_3_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;

            txtOnOrder.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtUnAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtBatchQty.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;

            TableLayoutRowStyleCollection styles = this.tableLayoutPanel1.RowStyles;
            styles[10].SizeType = SizeType.Absolute;
            styles[10].Height = 0;
            dtgParties.RowTemplate.Height = 55;
            dtgParties.ColumnHeadersHeight = 60;
            try
            {
                dtParties = new DataTable();
                dtParties.Columns.Add("Parti No", typeof(string));
                if (Giris.mKodValue == "20TRMN")
                {
                    dtParties.Columns.Add("Parti Niteliği", typeof(string));
                }
                dtParties.Columns.Add("Parti Miktarı", typeof(double));
                dtParties.Columns.Add("DepoYeriId", typeof(string));
                dtParties.Columns.Add("DepoYeriAdi", typeof(string));
            }
            catch (Exception)
            {
            }

            #region hatalı satır no yörük

            //var existrecord = TalebeBagliDepoNakli_2_Kabul.inventoryGenEntryBatches.Where(x => x.DocEntry == TalebeBagliDepoNakli_2_Kabul.DocEntry && x.LineNumber == TalebeBagliDepoNakli_2_Kabul.currentRow).ToList(); //old

            #endregion hatalı satır no yörük

            var existrecord = TalebeBagliDepoNakli_2_Kabul.inventoryGenEntryBatches.Where(x => x.DocEntry == TalebeBagliDepoNakli_2_Kabul.DocEntry && x.SAPLineNum == TalebeBagliDepoNakli_2_Kabul.sapLineNum).ToList();
            if (existrecord.Count > 0)
            {
                foreach (var item in existrecord)
                {
                    DataRow dr = dtParties.NewRow();
                    dr["Parti No"] = item.BatchNumber.ToString();
                    if (Giris.mKodValue == "20TRMN")
                    {
                        dr["Parti Niteliği"] = item.MnfSerial == null ? "" : item.MnfSerial.ToString();
                    }
                    dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                    dr["DepoYeriId"] = item.DepoYeriId;
                    dr["DepoYeriAdi"] = item.DepoYeriAdi;

                    dtParties.Rows.Add(dr);
                }
            }

            #region hatalı satır no yörük

            //var sum = TalebeBagliDepoNakli_2_Kabul.inventoryGenEntryBatches.Where(x => x.DocEntry == TalebeBagliDepoNakli_2_Kabul.DocEntry && x.LineNumber == TalebeBagliDepoNakli_2_Kabul.currentRow).Sum(y => y.BatchQuantity); //old

            #endregion hatalı satır no yörük

            var sum = TalebeBagliDepoNakli_2_Kabul.inventoryGenEntryBatches.Where(x => x.DocEntry == TalebeBagliDepoNakli_2_Kabul.DocEntry && x.SAPLineNum == TalebeBagliDepoNakli_2_Kabul.sapLineNum).Sum(y => y.BatchQuantity);

            var unaccepted = Convert.ToDouble(txtUnAccepted.Text);

            var res = unaccepted - sum;
            txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            txtUnAccepted.Text = res.ToString("N" + Giris.genelParametreler.OndalikMiktar);

            warehouse = TalebeBagliDepoNakli_2_Kabul.warehouse;

            dtgParties.DataSource = dtParties;

            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                dtgParties.Columns["DepoYeriId"].Visible = false;
                dtgParties.Columns["DepoYeriAdi"].Visible = false;
            }

            //dtgParties.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in dtgParties.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgParties.Rows.Count > 0)
            {
                dtgParties.Rows[0].Selected = false;
            }

            dtgParties.Columns["Parti No"].HeaderText = "PARTİ NO";
            dtgParties.Columns["Parti Miktarı"].HeaderText = "PARTİ MİKTARI";
            if (Giris.mKodValue == "20TRMN")
            {
                dtgParties.Columns["Parti Niteliği"].HeaderText = "PARTİ NİTELİĞİ";
            }

            dtgParties.EnableHeadersVisualStyles = false;
            dtgParties.RowTemplate.Height = 55;

            DataTable BatchDt = new DataTable();

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            //var resp = aIFTerminalServiceSoapClient.GetBatchByItemCodeToDraftDocument(Giris._dbName, warehouse, txtItemCode.Text);

            //if (resp.Val != 0)
            //{
            //    //CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");

            //}
            //else
            //{
            //    BatchInWarehouseDt = resp._list;
            //    //dtview = new DataView(resp._list);
            //    //BatchInWarehouseDt = resp._list;
            //    //BatchDt = resp._list.DefaultView.ToTable(false, "Quantity", "BatchNum");
            //    //txtBatchNumber.DataSource = BatchDt;

            //    //txtBatchNumber.DisplayMember = "BatchNum";
            //    //txtBatchNumber.ValueMember = "Quantity";

            //}

            dtgParties.Columns["Parti Miktarı"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
            txtBatchNumber.Focus();
            vScrollBar1.Maximum = dtgParties.RowCount;
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //if (dtParties.Rows.Count == 0)
            //{
            //    CustomMsgBox.Show("SATIR DOLU OLMADAN İŞLEM YAPILAMAZ.", "Uyarı", "Tamma", "");
            //    return;
            //}
            if (type == "1250000001")
            {
                //if (Convert.ToDouble(txtUnAccepted.Text) != 0)
                //{
                //    MessageBox.Show("Toplanmayan miktar varken işleme devam edilemez.");
                //    return;
                //}

                #region hatalı satır no yörük

                //TalebeBagliDepoNakli_2_Kabul.inventoryGenEntryBatches.RemoveAll(x => x.LineNumber == TalebeBagliDepoNakli_2_Kabul.currentRow && x.DocEntry == TalebeBagliDepoNakli_2_Kabul.DocEntry);//old

                #endregion hatalı satır no yörük

                TalebeBagliDepoNakli_2_Kabul.inventoryGenEntryBatches.RemoveAll(x => x.SAPLineNum == TalebeBagliDepoNakli_2_Kabul.sapLineNum && x.DocEntry == TalebeBagliDepoNakli_2_Kabul.DocEntry);

                foreach (DataRow item in dtParties.Rows)
                {
                    if (Giris.mKodValue == "20TRMN")
                    {
                        TalebeBagliDepoNakli_2_Kabul.inventoryGenEntryBatches.Add(new Models.InventoryGenEntryBatch
                        {
                            BatchNumber = item["Parti No"].ToString(),
                            BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                            ItemCode = txtItemCode.Text,
                            LineNumber = TalebeBagliDepoNakli_2_Kabul.currentRow,
                            DocEntry = TalebeBagliDepoNakli_2_Kabul.DocEntry,
                            SAPLineNum = TalebeBagliDepoNakli_2_Kabul.sapLineNum,
                            MnfSerial = item["Parti Niteliği"].ToString()
                        });
                    }
                    else
                    {
                        TalebeBagliDepoNakli_2_Kabul.inventoryGenEntryBatches.Add(new Models.InventoryGenEntryBatch
                        {
                            BatchNumber = item["Parti No"].ToString(),
                            BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                            ItemCode = txtItemCode.Text,
                            LineNumber = TalebeBagliDepoNakli_2_Kabul.currentRow,
                            DocEntry = TalebeBagliDepoNakli_2_Kabul.DocEntry,
                            SAPLineNum = TalebeBagliDepoNakli_2_Kabul.sapLineNum,
                            DepoYeriId = item["DepoYeriId"].ToString(),
                            DepoYeriAdi = item["DepoYeriAdi"].ToString()
                        });
                    }
                }

                dialogresult = "Ok";

                Close();
            }
            else if (type == "Tlpsz1250000001")
            {
                //if (Convert.ToDouble(txtUnAccepted.Text) != 0)
                //{
                //    MessageBox.Show("Toplanmayan miktar varken işleme devam edilemez.");
                //    return;
                //}

                TalepsizDepoNakli_1.StokTransferBatches.RemoveAll(x => x.LineNumber == TalepsizDepoNakli_1.currentRow);

                foreach (DataRow item in dtParties.Rows)
                {
                    TalepsizDepoNakli_1.StokTransferBatches.Add(new Models.StokTransferBatch
                    {
                        BatchNumber = item["Parti No"].ToString(),
                        BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                        ItemCode = txtItemCode.Text,
                        LineNumber = TalepsizDepoNakli_1.currentRow,
                    });
                }

                dialogresult = "Ok";

                Close();
            }
        }

        public static DataTable BatchInWarehouseDt = new DataTable();

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnShowBatchWhs_Click(object sender, EventArgs e)
        {
            DepodakiPartiler n = new DepodakiPartiler("67", BatchInWarehouseDt, txtWhsQuantity, txtBatchNumber, "TALEBE BAĞLI DEPO NAKLİ KABUL");
            n.ShowDialog();
            n.Dispose();
            GC.Collect();

            if (dialogresult == "Ok")
            {
                var txtWhsQuantityVal = txtWhsQuantity.Text == "" ? 0 : Convert.ToDouble(txtWhsQuantity.Text);
                var txtUnAcceptedVal = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

                double UnacceptedQty = Convert.ToDouble(txtUnAcceptedVal) > Convert.ToDouble(txtWhsQuantityVal) ? Convert.ToDouble(txtWhsQuantityVal) : Convert.ToDouble(txtUnAcceptedVal);

                txtBatchQty.Text = UnacceptedQty.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                dialogresult = "";

                txtBatchNumber.Focus();
            }
        }

        private void cmbBatch_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private DataView dtview = new DataView();

        private void cmbBatch_TextChanged(object sender, EventArgs e)
        {
            //dtview.RowFilter = "BatchNum like '%" + cmbBatch.Text + "%'";

            //cmbBatch.DataSource = null;
            //cmbBatch.DisplayMember = "BatchNum";
            //cmbBatch.ValueMember = "Quantity";
            //cmbBatch.DataSource = dtview;

            //cmbBatch.DroppedDown = true;
        }

        private void txtBatchNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtBatchQty.Text = txtUnAccepted.Text;//chn

                string warehouse = "";

                if (type == "Tlpsz1250000001")
                {
                    warehouse = TalepsizDepoNakli_1.fromWhsCode;
                }
                else
                {
                    warehouse = TalebeBagliDepoNakli_2_Kabul.warehouse;
                }

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                var resp = aIFTerminalServiceSoapClient.GetBatchQuantity(Giris._dbName, warehouse, txtBatchNumber.Text, txtItemCode.Text, Giris.mKodValue);

                if (resp.Val == 0)
                {
                    if (txtBatchNumber.Text == "")
                    {
                        CustomMsgBox.Show("PARTİ NUMARASI BOŞ BIRAKILAMAZ.", "Uyarı", "Tamam", "");
                        txtBatchNumber.Text = "";
                        txtBatchNumber.Focus();

                        return;
                    }
                    else if (resp._list.Rows[0].ItemArray[0].ToString() == "")
                    {
                        CustomMsgBox.Show("PARTİ NUMARASI BULUNAMADI.", "Uyarı", "Tamam", "");
                        txtBatchNumber.Focus();
                        txtBatchNumber.Select(0, txtBatchNumber.Text.Length);

                        return;
                    }

                    txtWhsQuantity.Text = resp._list.Rows[0].ItemArray[0].ToString() == "" ? "0" : Convert.ToDouble(resp._list.Rows[0].ItemArray[0]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                    txtWhsQuantity.BackColor = Color.LimeGreen;

                    double UnacceptedQty = Convert.ToDouble(txtUnAccepted.Text) > Convert.ToDouble(txtWhsQuantity.Text) ? Convert.ToDouble(txtWhsQuantity.Text) : Convert.ToDouble(txtUnAccepted.Text);

                    txtBatchQty.Text = UnacceptedQty.ToString();
                    txtBatchQty.Focus();
                    txtBatchQty.Select(0, txtBatchQty.Text.Length);
                }
                else
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
        }

        private void dtgParties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void txtBatchQty_MouseDown(object sender, MouseEventArgs e)
        {
            txtBatchQty.Select(0, txtBatchQty.Text.Length);
        }

        private void txtBatchQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBatchQty.Text == "" || Convert.ToDouble(txtBatchQty.Value) == 0)
                {
                    CustomMsgBox.Show("MİKTAR GİRİNİZ.", "Uyarı", "Tamam", "");
                    txtBatchQty.Focus();
                    txtBatchQty.Select(0, txtBatchQty.Text.Length);
                }
                else
                {
                    btnCollect.PerformClick();
                }
                //if (txtBatchQty.Text != "")
                //{
                //    if (Convert.ToDouble(txtBatchQty.Value) > 0)
                //    {
                //        btnCollect.PerformClick();
                //    }
                //}
            }
        }

        private int currentRow = -1;

        private void btnRowDel_Click(object sender, EventArgs e)
        {
            if (dtgParties.DataSource == null)
            {
                return;
            }
            if (currentRow == -1)
            {
                CustomMsgBox.Show("SİLMEK İÇİN SATIR SEÇİNİZ.", "Uyarı", "Tamam", "");
                return;
            }

            var satirdasilinenMiktar = Convert.ToDouble(dtParties.Rows[currentRow]["Parti Miktarı"]);

            dtgParties.Rows.RemoveAt(currentRow);

            currentRow = -1;

            var sum = dtParties.AsEnumerable().Sum(x => x.Field<double>("Parti Miktarı"));

            double Unaccepted = Convert.ToDouble(txtUnAccepted.Text);
            double accepted = Convert.ToDouble(txtAccepted.Text);

            accepted = sum;
            Unaccepted = Unaccepted + satirdasilinenMiktar;

            txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            if (type == "1250000001")
            {
                txtUnAccepted.Text = Unaccepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            }
            if (dtgParties.Rows.Count > 0)
            {
                dtgParties.Rows[0].Selected = false;
            }
        }

        private void dtgParties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;

            var partino = dtgParties.Rows[e.RowIndex].Cells[0].Value.ToString();
            var partiMiktar = Convert.ToDouble(dtgParties.Rows[e.RowIndex].Cells[2].Value);

            txtBatchNumber.Text = partino;
            txtBatchQty.Value = Convert.ToDecimal(partiMiktar);
        }

        private void dtgParties_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgParties.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void txtBatchQty_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtBatchQty, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }
    }
}