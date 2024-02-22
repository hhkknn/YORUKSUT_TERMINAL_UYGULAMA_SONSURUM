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
    public partial class IadeIrsaliyeGirisi_2 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //end font

        private string type = "";
        private List<dynamic> list = null;

        public IadeIrsaliyeGirisi_2(string _type, List<dynamic> _list, string _formName)
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

            list = _list;
            type = _type;

            if (type == "16")//irsaliye
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtCardCode.Text = list[4].ToString();

                //if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                //{
                txtPartyNo.Text = list[5];
                //}
                txtOnEkrandaSecilenDepo.Text = list[6];
            }

            if (type == "IadeTalep")
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtCardCode.Text = list[4].ToString();

                //if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                //{
                txtPartyNo.Text = list[5];
                //}
                txtOnEkrandaSecilenDepo.Text = list[6];
            }
        }

        private DataTable dtParties = new DataTable();

        private string formName = "";
        public static string dialogresult = "";
        public static string arananPartyNo = "";
        public static string secilenDepoYeriId = "";
        public static string secilenDepoYeriAdi = "";

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

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            txtUomCode.Font = new Font(txtUomCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUomCode.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtItemCode.Font = new Font(txtItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemCode.Font.Style);

            txtPartyNo.Font = new Font(txtPartyNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyNo.Font.Style);

            numPartyQty.Font = new Font(numPartyQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                numPartyQty.Font.Style);

            btnPartiSec.Font = new Font(btnPartiSec.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPartiSec.Font.Style);

            btnRowDel.Font = new Font(btnRowDel.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnRowDel.Font.Style);

            btnCollect.Font = new Font(btnCollect.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnCollect.Font.Style);

            dtgParties.Font = new Font(dtgParties.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgParties.Font.Style);

            btnComplete.Font = new Font(btnComplete.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnComplete.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);
            ResumeLayout();

            //start yükseklik-genislik
            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtUomCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtPartyNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            numPartyQty.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private void IadeIrsaliyeGirisi_2_Load(object sender, EventArgs e)
        {
            try
            {
                frmName.Text = formName.ToUpper();
                numPartyQty.Focus();
                vScrollBar1.Maximum = dtgParties.RowCount;

                dtgParties.RowTemplate.Height = 55;
                dtgParties.ColumnHeadersHeight = 60;

                numPartyQty.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;

                dtParties.Columns.Add("Parti No", typeof(string));
                dtParties.Columns.Add("Parti Miktarı", typeof(double));
                dtParties.Columns.Add("DepoYeriId", typeof(string));
                dtParties.Columns.Add("DepoYeriAdi", typeof(string));

                if (type == "16")
                {
                    var existrecord = IadeIrsaliyeGirisi_1.waybillReturnBatches.Where(x => x.ItemCode == txtItemCode.Text && x.LineNumber == IadeIrsaliyeGirisi_1.currentRow).ToList();

                    if (existrecord.Count > 0)
                    {
                        foreach (var item in existrecord)
                        {
                            DataRow dr = dtParties.NewRow();
                            dr["Parti No"] = item.BatchNumber.ToString();
                            dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                            dr["DepoYeriId"] = item.DepoYeriId.ToString();
                            dr["DepoYeriAdi"] = item.DepoYeriAdi.ToString();

                            dtParties.Rows.Add(dr);
                        }
                    }
                }
                if (type == "IadeTalep")
                {
                    var existrecord = IadeTalebi_2.iadeTalepPartis.Where(x => x.ItemCode == txtItemCode.Text && x.LineNumber == IadeTalebi_2.currentRow).ToList();

                    if (existrecord.Count > 0)
                    {
                        foreach (var item in existrecord)
                        {
                            DataRow dr = dtParties.NewRow();
                            dr["Parti No"] = item.BatchNumber.ToString();
                            dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                            dr["DepoYeriId"] = item.DepoYeriId.ToString();
                            dr["DepoYeriAdi"] = item.DepoYeriAdi.ToString();

                            dtParties.Rows.Add(dr);
                        }
                    }
                }

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

                dtgParties.Columns["DepoYeriId"].Visible = false;
                dtgParties.Columns["DepoYeriAdi"].Visible = false;

            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void btnRowDel_Click(object sender, EventArgs e)
        {
            try
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

                //var satirdasilinenMiktar = Convert.ToDouble(dtParties.Rows[currentRow]["Parti Miktarı"]);//kapatıldı

                dtgParties.Rows.RemoveAt(currentRow);
                currentRow = -1;

                if (dtgParties.Rows.Count > 0)
                {
                    dtgParties.Rows[0].Selected = false;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private int currentRow = -1;

        private void btnCollect_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPartyNo.Text == "")
                {
                    CustomMsgBox.Show("PARTİ NUMARASI BOŞ BIRAKILAMAZ.", "Uyarı", "Tamam", "");
                    txtPartyNo.Focus();
                    return;
                }

                if (Convert.ToDouble(numPartyQty.Value) == 0 || numPartyQty.Text == "")
                {
                    numPartyQty.Focus();
                    numPartyQty.Select(0, numPartyQty.Text.Length);
                    CustomMsgBox.Show("MİKTAR GİRİNİZ.", "Uyarı", "Tamam", "");
                    return;
                }

                if (type == "16" || type == "IadeTalep")
                {
                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                    Response resp = null;

                    resp = aIFTerminalServiceSoapClient.getDepoYerleri(Giris._dbName, txtOnEkrandaSecilenDepo.Text, Giris.mKodValue);

                    if (resp.Val == 0)
                    {
                        if (resp._list.Rows.Count > 0)
                        {
                            if (resp._list.Rows.Count > 0)
                            {
                                SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtSecilenDepoYeriId, txtSecilenDepoYeriAdi, txtOnEkrandaSecilenDepo, null);
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
                            //}

                            //double accepted = Convert.ToDouble(txtAccepted.Text);
                            //double currentvalue = Convert.ToDouble(txtPartyQty.Text);

                            //accepted = accepted + currentvalue;

                            //txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                        }
                    }

                    DataRow dr = dtParties.NewRow();
                    dr["Parti No"] = txtPartyNo.Text;
                    dr["Parti Miktarı"] = Convert.ToDouble(numPartyQty.Text);
                    dr["DepoYeriId"] = txtSecilenDepoYeriId.Text;
                    dr["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text;

                    dtParties.Rows.Add(dr);
                    //}

                    //double accepted = Convert.ToDouble(txtAccepted.Text);
                    //double currentvalue = Convert.ToDouble(txtPartyQty.Text);

                    //accepted = accepted + currentvalue;

                    //txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                }

                txtPartyNo.Text = "";
                numPartyQty.Text = "";
                //txtPartyBarcode.Text = "";//kapatıldı

                txtPartyNo.Focus();
                //txtPartyQty.Text = txtUnAccepted.Text;//kapatıldı

                if (dtgParties.Rows.Count > 0)
                {
                    dtgParties.Rows[0].Selected = false;
                }
                //dtgParties.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgParties.AutoResizeRows();
                dtgParties.Columns["Parti Miktarı"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                vScrollBar1.Maximum = dtgParties.RowCount + 5;
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                if (type == "16")
                {
                    IadeIrsaliyeGirisi_1.waybillReturnBatches.RemoveAll(x => x.LineNumber == IadeIrsaliyeGirisi_1.currentRow);

                    foreach (DataRow item in dtParties.Rows)
                    {
                        IadeIrsaliyeGirisi_1.waybillReturnBatches.Add(new Models.WaybillReturnBatch
                        {
                            BatchNumber = item["Parti No"].ToString(),
                            BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                            ItemCode = txtItemCode.Text,
                            LineNumber = IadeIrsaliyeGirisi_1.currentRow,
                            DepoYeriId = item["DepoYeriId"].ToString(),
                            DepoYeriAdi = item["DepoYeriAdi"].ToString()
                        });
                    }

                    dialogresult = "Ok";

                    Close();
                }

                if (type == "IadeTalep")
                {
                    IadeTalebi_2.iadeTalepPartis.RemoveAll(x => x.LineNumber == IadeTalebi_2.currentRow && x.DocEntry == IadeTalebi_2.DocEntry);

                    foreach (DataRow item in dtParties.Rows)
                    {
                        IadeTalebi_2.iadeTalepPartis.Add(new Models.IadeTalepParti
                        {  
                            BatchNumber = item["Parti No"].ToString(),
                            BatchQuantity = Math.Round(Convert.ToDouble(item["Parti Miktarı"]), Giris.genelParametreler.OndalikMiktar),
                            ItemCode = txtItemCode.Text,
                            LineNumber = IadeTalebi_2.currentRow,
                            DocEntry = IadeTalebi_2.DocEntry,
                            SAPLineNum = IadeTalebi_2.sapLineNum,
                            DepoYeriId = item["DepoYeriId"].ToString(),
                            DepoYeriAdi = item["DepoYeriAdi"].ToString()
                        });
                    }

                    dialogresult = "Ok";

                    Close();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void txtPartyNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtPartyNo.Text == "")
                    {
                        CustomMsgBox.Show("PARTİ NUMARASI BOŞ BIRAKILAMAZ.", "Uyarı", "Tamam", "");
                        txtPartyNo.Focus();
                        return;
                    }

                    numPartyQty.Focus();
                    numPartyQty.Select(0, numPartyQty.Text.Length);
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void numPartyQty_MouseDown(object sender, MouseEventArgs e)
        {
            numPartyQty.Select(0, numPartyQty.Text.Length);
        }

        private void numPartyQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (numPartyQty.Text == "" || Convert.ToDouble(numPartyQty.Value) == 0)
                    {
                        CustomMsgBox.Show("MİKTAR GİRİNİZ.", "Uyarı", "Tamam", "");
                        numPartyQty.Focus();
                        numPartyQty.Select(0, numPartyQty.Text.Length);
                    }
                    else
                    {
                        btnCollect.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
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

        private void btnPartiSec_Click(object sender, EventArgs e)
        {
            try
            {
                #region satış ve teslimat parti seçiminde oldugundan buradan kaldırıldı

                //AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                //var resp = aIFTerminalServiceSoapClient.GetBatchNumberByCardCodeAndItemCode(Giris._dbName, txtCardCode.Text, txtItemCode.Text, Giris.mKodValue);

                //if (resp._list == null)
                //{
                //    CustomMsgBox.Show("PARTİ NUMARASI BULUNAMADI.", "Uyarı", "Tamam", "");
                //    numPartyQty.Focus();
                //    numPartyQty.Select(0, numPartyQty.Text.Length);
                //    return;
                //}

                #endregion satış ve teslimat parti seçiminde oldugundan buradan kaldırıldı

                SatisVeTeslimatPartiSecim nesne = new SatisVeTeslimatPartiSecim("16", "PartiAra", "PARTİ ARAMA", txtCardCode, txtItemCode, txtItemName);
                nesne.ShowDialog();
                nesne.Dispose();
                GC.Collect();

                if (SatisVeTeslimatPartiSecim.dialogResult == "Ok")
                {
                    txtPartyNo.Text = arananPartyNo;

                    numPartyQty.Focus();
                    numPartyQty.Select(0, numPartyQty.Text.Length);

                    SelectList.dialogResult = "";
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void numPartyQty_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(numPartyQty, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }
    }
}