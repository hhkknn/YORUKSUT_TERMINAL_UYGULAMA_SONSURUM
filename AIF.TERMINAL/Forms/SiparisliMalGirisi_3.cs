using AIF.TERMINAL.AIFTerminalService;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class SiparisliMalGirisi_3 : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //end font

        private string type = "";
        private List<dynamic> list = null;

        public SiparisliMalGirisi_3(string _type, List<dynamic> _list, string _formName)
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
            list = _list;
            type = _type;

            if (type == "20")//siparissiz
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;
                txtAccepted.Text = "0";
                txtUnAccepted.ReadOnly = true;
                txtDepo.Text = list[8].ToString();//Depo
            }
            else if (type == "22")//siparisli
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtAccepted.Text = "0";
                txtUnAccepted.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;
                txtDepo.Text = list[6].ToString();
            }
            else if (type == "59") //belgesiz mal girisi
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;
                txtAccepted.Text = "0";
                txtUnAccepted.ReadOnly = true;
                txtDepo.Text = list[8].ToString();
            }

            //txtPartyNo.Focus();
            //txtPartyQty.Value = txtUnAccepted.Value;
        }

        private DataTable dtParties = new DataTable();

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

            txtPartyNo.Font = new Font(txtPartyNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyNo.Font.Style);

            txtPartyBarcode.Font = new Font(txtPartyBarcode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyBarcode.Font.Style);

            txtPartyQty.Font = new Font(txtPartyQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyQty.Font.Style);

            btnPartyCreate.Font = new Font(btnPartyCreate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPartyCreate.Font.Style);

            btnCollect.Font = new Font(btnCollect.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnCollect.Font.Style);

            btnComplete.Font = new Font(btnComplete.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnComplete.Font.Style);

            btnRowDel.Font = new Font(btnRowDel.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnRowDel.Font.Style);

            dtgParties.Font = new Font(dtgParties.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgParties.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            //txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtItemCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtWhsQuantity.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtUomCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtPartyNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtPartyQty.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private void SiparisliMalGirisi_3_Load(object sender, EventArgs e)
        {
            frmName.Text = formName.ToUpper();

            txtPartyNo.Focus();
            dtgParties.RowTemplate.Height = 55;
            dtgParties.ColumnHeadersHeight = 60;

            txtOnOrder.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtUnAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtPartyQty.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;

            vScrollBar1.Maximum = dtgParties.RowCount;
            TableLayoutRowStyleCollection styles = this.tableLayoutPanel1.RowStyles;
            styles[10].SizeType = SizeType.Absolute;
            styles[10].Height = 0;

            dtParties.Columns.Add("Parti No", typeof(string));
            dtParties.Columns.Add("Parti Miktarı", typeof(double));
            dtParties.Columns.Add("DepoYeriId", typeof(string));
            dtParties.Columns.Add("DepoYeriAdi", typeof(string));

            if (type == "20")
            {
                var existrecord = SiparissizMalGirisi_1.goodRecieptPOBatches.Where(x => x.ItemCode == txtItemCode.Text && x.LineNumber == SiparissizMalGirisi_1.currentRow).ToList();

                if (existrecord.Count > 0)
                {
                    foreach (var item in existrecord)
                    {
                        DataRow dr = dtParties.NewRow();
                        dr["Parti No"] = item.BatchNumber.ToString();
                        dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                        dr["DepoYeriId"] = item.DepoYeriId;
                        dr["DepoYeriAdi"] = item.DepoYeriAdi;

                        dtParties.Rows.Add(dr);
                    }
                }

                var sum = SiparissizMalGirisi_1.goodRecieptPOBatches.Where(x => x.ItemCode == txtItemCode.Text && x.LineNumber == SiparissizMalGirisi_1.currentRow).Sum(y => y.BatchQuantity);

                txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            }
            else if (type == "22")
            {
                var existrecord = SiparisliMalGirisi_2.goodRecieptPOBatches.Where(x => x.DocEntry == SiparisliMalGirisi_2.DocEntry && x.LineNumber == SiparisliMalGirisi_2.currentRow).ToList();

                if (existrecord.Count > 0)
                {
                    foreach (var item in existrecord)
                    {
                        DataRow dr = dtParties.NewRow();
                        dr["Parti No"] = item.BatchNumber.ToString();
                        dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                        dr["DepoYeriId"] = item.DepoYeriId;
                        dr["DepoYeriAdi"] = item.DepoYeriAdi;

                        dtParties.Rows.Add(dr);
                    }
                }

                var sum = SiparisliMalGirisi_2.goodRecieptPOBatches.Where(x => x.DocEntry == SiparisliMalGirisi_2.DocEntry && x.LineNumber == SiparisliMalGirisi_2.currentRow).Sum(y => y.BatchQuantity);

                var unaccepted = Convert.ToDouble(txtUnAccepted.Text);

                var res = unaccepted - sum;
                txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtUnAccepted.Text = res.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            }
            else if (type == "59")
            {
                var existrecord = BelgesizMalGirisi_1.inventoryGenEntryBatches.Where(x => x.ItemCode == txtItemCode.Text && x.LineNumber == BelgesizMalGirisi_1.currentRow).ToList();

                if (existrecord.Count > 0)
                {
                    foreach (var item in existrecord)
                    {
                        DataRow dr = dtParties.NewRow();
                        dr["Parti No"] = item.BatchNumber.ToString();
                        dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                        dr["DepoYeriId"] = item.DepoYeriId;
                        dr["DepoYeriAdi"] = item.DepoYeriAdi;

                        dtParties.Rows.Add(dr);
                    }
                }

                var sum = BelgesizMalGirisi_1.inventoryGenEntryBatches.Where(x => x.ItemCode == txtItemCode.Text && x.LineNumber == BelgesizMalGirisi_1.currentRow).Sum(y => y.BatchQuantity);

                txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            }

            txtPartyQty.Value = txtUnAccepted.Value;

            dtgParties.DataSource = dtParties;

            dtgParties.EnableHeadersVisualStyles = false;
            dtgParties.RowTemplate.Height = 55;

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
            dtgParties.Columns["Parti Miktarı"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                dtgParties.Columns["DepoYeriId"].Visible = false;
                dtgParties.Columns["DepoYeriAdi"].Visible = false;
            }
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            if (txtPartyNo.Text == "")
            {
                CustomMsgBox.Show("PARTİ NUMARASI BOŞ BIRAKILAMAZ.", "Uyarı", "Tamam", "");
                txtPartyNo.Focus();
                return;
            }

            if (Convert.ToDouble(txtPartyQty.Value) == 0 || txtPartyQty.Text == "")
            {
                txtPartyQty.Focus();
                txtPartyQty.Select(0, txtPartyQty.Text.Length);
                CustomMsgBox.Show("MİKTAR GİRİNİZ.", "Uyarı", "Tamam", "");
                return;
            }
            if (type == "22")
            {
                //if (txtPartyQty.Value > txtOnOrder.Value)
                //{
                //    CustomMsgBox.Show("MİKTAR, TALEP EDİLEN MİKTARDAN FAZLA OLAMAZ", "Uyarı", "Tamam", "");
                //    txtPartyQty.Focus();
                //    txtPartyQty.Select(0, txtPartyQty.Text.Length);
                //    return;

                //}
            }

            string depoYeriId = "";
            string depoYeriAdi = "";
            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = null;

                resp = aIFTerminalServiceSoapClient.getDepoYerleri(Giris._dbName, txtDepo.Text, Giris.mKodValue);

                if (resp.Val == 0)
                {
                    if (resp._list.Rows.Count > 0)
                    {
                        SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtSecilenDepoYeriId, txtSecilenDepoYeriAdi, txtDepo, null);
                        nesne.ShowDialog();
                        nesne.Dispose();
                        GC.Collect();

                        if (SelectList.dialogResult == "Ok")
                        {
                            SelectList.dialogResult = "";
                        }

                        if (txtSecilenDepoYeriId.Text == "")
                        {
                            CustomMsgBox.Show("DEPO YERI SEÇİLMEDEN İŞLEME DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                            txtPartyNo.Focus();
                            return;
                        }
                    }
                }

                //SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtSecilenDepoYeriId, txtSecilenDepoYeriAdi, txtDepo, null);
                //nesne.ShowDialog();
                //nesne.Dispose();
                //GC.Collect();

                //if (SelectList.dialogResult == "Ok")
                //{
                //    SelectList.dialogResult = "";
                //}

                //if (txtSecilenDepoYeriId.Text == "")
                //{
                //    CustomMsgBox.Show("DEPO YERI SEÇİLMEDEN İŞLEME DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                //    txtPartyNo.Focus();
                //    return;
                //}
            }

            //foreach (DataRow item in resp._list.Rows)
            //{
            if (type == "20" || type == "59")
            {
                DataRow dr = dtParties.NewRow();
                dr["Parti No"] = txtPartyNo.Text;
                dr["Parti Miktarı"] = Convert.ToDouble(txtPartyQty.Text);
                dr["DepoYeriId"] = txtSecilenDepoYeriId.Text;
                dr["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text;

                dtParties.Rows.Add(dr);
                //}

                txtSecilenDepoYeriId.Text = "";
                txtSecilenDepoYeriAdi.Text = "";

                //double accepted = Convert.ToDouble(txtAccepted.Text);
                //double currentvalue = Convert.ToDouble(txtPartyQty.Text);

                //accepted = accepted + currentvalue;

                //txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            }
            else if (type == "22")//siparisli
            {
                double Unaccepted = Convert.ToDouble(txtUnAccepted.Text);
                double accepted = Convert.ToDouble(txtAccepted.Text);
                double currentvalue = Convert.ToDouble(txtPartyQty.Text);

                accepted = accepted + currentvalue;
                Unaccepted = Unaccepted - currentvalue;

                DataRow dr = dtParties.NewRow();
                dr["Parti No"] = txtPartyNo.Text;
                dr["Parti Miktarı"] = Convert.ToDouble(txtPartyQty.Text);
                dr["DepoYeriId"] = txtSecilenDepoYeriId.Text;
                dr["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text;

                dtParties.Rows.Add(dr);

                txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtUnAccepted.Text = Unaccepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                txtSecilenDepoYeriId.Text = "";
                txtSecilenDepoYeriAdi.Text = "";
            }

            txtPartyNo.Text = "";
            txtPartyQty.Text = "";
            txtPartyBarcode.Text = "";

            txtPartyNo.Focus();
            txtPartyQty.Text = txtUnAccepted.Text;

            if (dtgParties.Rows.Count > 0)
            {
                dtgParties.Rows[0].Selected = false;
            }
            //dtgParties.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgParties.AutoResizeRows();
            dtgParties.Columns["Parti Miktarı"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
            vScrollBar1.Maximum = dtgParties.RowCount + 5;
        }

        public static string dialogresult = "";

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //if (dtParties.Rows.Count == 0)
            //{
            //    CustomMsgBox.Show("SATIR DOLU OLMADAN İŞLEM YAPILAMAZ.", "Uyarı", "TAMAM", "");
            //    return;
            //}
            if (type == "20")
            {
                SiparissizMalGirisi_1.goodRecieptPOBatches.RemoveAll(x => x.LineNumber == SiparissizMalGirisi_1.currentRow);

                foreach (DataRow item in dtParties.Rows)
                {
                    SiparissizMalGirisi_1.goodRecieptPOBatches.Add(new Models.GoodRecieptPOBatch
                    {
                        BatchNumber = item["Parti No"].ToString(),
                        BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                        ItemCode = txtItemCode.Text,
                        LineNumber = SiparissizMalGirisi_1.currentRow,
                        DepoYeriId = item["DepoYeriId"].ToString(),
                        DepoYeriAdi = item["DepoYeriAdi"].ToString()
                    });
                }

                dialogresult = "Ok";

                Close();
            }
            else if (type == "22")
            {
                //if (Convert.ToDouble(txtUnAccepted.Text) != 0)
                //{
                //    MessageBox.Show("Toplanmayan miktar varken işleme devam edilemez.");
                //    return;
                //}

                SiparisliMalGirisi_2.goodRecieptPOBatches.RemoveAll(x => x.LineNumber == SiparisliMalGirisi_2.currentRow && x.DocEntry == SiparisliMalGirisi_2.DocEntry);

                foreach (DataRow item in dtParties.Rows)
                {
                    SiparisliMalGirisi_2.goodRecieptPOBatches.Add(new Models.GoodRecieptPOBatch
                    {
                        BatchNumber = item["Parti No"].ToString(),
                        BatchQuantity = Math.Round(Convert.ToDouble(item["Parti Miktarı"]), Giris.genelParametreler.OndalikMiktar),
                        ItemCode = txtItemCode.Text,
                        LineNumber = SiparisliMalGirisi_2.currentRow,
                        DocEntry = SiparisliMalGirisi_2.DocEntry,
                        SAPLineNum = SiparisliMalGirisi_2.sapLineNum,
                        DepoYeriId = item["DepoYeriId"].ToString(),
                        DepoYeriAdi = item["DepoYeriAdi"].ToString()
                    });
                }

                dialogresult = "Ok";

                Close();
            }
            else if (type == "59")
            {
                BelgesizMalGirisi_1.inventoryGenEntryBatches.RemoveAll(x => x.LineNumber == BelgesizMalGirisi_1.currentRow);

                foreach (DataRow item in dtParties.Rows)
                {
                    BelgesizMalGirisi_1.inventoryGenEntryBatches.Add(new Models.InventoryGenEntryBatch
                    {
                        BatchNumber = item["Parti No"].ToString(),
                        BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                        ItemCode = txtItemCode.Text,
                        LineNumber = BelgesizMalGirisi_1.currentRow,
                        DepoYeriId = item["DepoYeriId"].ToString(),
                        DepoYeriAdi = item["DepoYeriAdi"].ToString(),
                    });
                }

                dialogresult = "Ok";
                Close();
            }
        }

        private void dtgParties_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgParties.Columns[e.ColumnIndex].Name == "Parti Miktarı")
            {
                var sum = dtParties.AsEnumerable().Sum(x => x.Field<double>("Parti Miktarı"));

                txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            }
        }

        private void txtPartyNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPartyNo.Text == "")
                {
                    CustomMsgBox.Show("PARTİ NUMARASI BOŞ BIRAKILAMAZ.", "Uyarı", "Tamam", "");
                    txtPartyNo.Focus();
                    return;
                }

                txtPartyQty.Focus();
                txtPartyQty.Select(0, txtPartyQty.Text.Length);
            }
        }

        private void txtPartyQty_MouseDown(object sender, MouseEventArgs e)
        {
            txtPartyQty.Select(0, txtPartyQty.Text.Length);
        }

        private void txtPartyQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPartyQty.Text == "" || Convert.ToDouble(txtPartyQty.Value) == 0)
                {
                    CustomMsgBox.Show("MİKTAR GİRİNİZ.", "Uyarı", "Tamam", "");
                    txtPartyQty.Focus();
                    txtPartyQty.Select(0, txtPartyQty.Text.Length);
                }
                else
                {
                    btnCollect.PerformClick();
                }
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

            if (type == "22")
            {
                var sum = dtParties.AsEnumerable().Sum(x => x.Field<double>("Parti Miktarı"));

                double Unaccepted = Convert.ToDouble(txtUnAccepted.Text);
                double accepted = Convert.ToDouble(txtAccepted.Text);

                accepted = sum;
                Unaccepted = Unaccepted + satirdasilinenMiktar;

                txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtUnAccepted.Text = Unaccepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                txtPartyQty.Value = txtUnAccepted.Value;
            }

            if (dtgParties.Rows.Count > 0)
            {
                dtgParties.Rows[0].Selected = false;
            }
        }

        private void dtgParties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;
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

        private void btnPartyCreate_Click(object sender, EventArgs e)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = new Response();

            if (Giris.genelParametreler.TarihBazliPartiOlustur == "Y")
            {
                resp = aIFTerminalServiceSoapClient.GetPartiNoSorgula(Giris._dbName, txtItemCode.Text, Giris.mKodValue);

                if (resp != null)
                {
                    string partino = resp._list.Rows[0]["Parti"].ToString();
                    txtPartyNo.Text = partino;
                }
            }
            else
            {
                if (resp.Val == 0)
                {
                    resp = aIFTerminalServiceSoapClient.GetBatchNextNumber(Giris._dbName, Giris.mKodValue);
                    string batchPrefix = resp._list.Rows[0]["U_BatchPrefix"].ToString();
                    int nextNumber = Convert.ToInt32(resp._list.Rows[0]["U_NextNumber"]);
                    int docEntry = Convert.ToInt32(resp._list.Rows[0]["DocEntry"]);

                    txtPartyNo.Text = batchPrefix == "" ? nextNumber.ToString() : batchPrefix + nextNumber.ToString();

                    resp = aIFTerminalServiceSoapClient.UpdateBatchNextNumber(Giris._dbName, docEntry, nextNumber, Giris.mKodValue);

                    if (resp.Val != 0)
                    {
                        CustomMsgBox.Show(resp.Desc, "Uyarı", "TAMAM", "");
                    }
                }
            }
            txtPartyQty.Focus();
            txtPartyQty.Select(0, txtPartyQty.Text.Length);
        }

        private void txtPartyQty_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtPartyQty, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }
    }
}