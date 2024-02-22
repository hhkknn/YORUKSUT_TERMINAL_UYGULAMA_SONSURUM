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
    public partial class SiparisliMalGirisi_1 : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public SiparisliMalGirisi_1(string _formName)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = label3.Font.Size;
            label3.Resize += Form_Resize;

            initialFontSize = label4.Font.Size;
            label4.Resize += Form_Resize;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            //initialFontSize = dtpStartDate.Font.Size;
            //dtpStartDate.Resize += Form_Resize;

            //initialFontSize = dtpEndDate.Font.Size;
            //dtpEndDate.Resize += Form_Resize;

            //initialFontSize = txtSearch.Font.Size;
            //txtSearch.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = dtgPurchaseOrders.Font.Size;
            dtgPurchaseOrders.Resize += Form_Resize;
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

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            dtpStartDate.Font = new Font(dtpStartDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpStartDate.Font.Style);

            dtpEndDate.Font = new Font(dtpEndDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpEndDate.Font.Style);

            txtSearch.Font = new Font(txtSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSearch.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button1.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button2.Font.Style);

            dtgPurchaseOrders.Font = new Font(dtgPurchaseOrders.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgPurchaseOrders.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            dtpStartDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpEndDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtSearch.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        public static bool formAciliyor = false;

        private void SiparisliMalGirisi_1_Load(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = true;
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            vScrollBar1.Maximum = dtgPurchaseOrders.RowCount;

            dtgPurchaseOrders.RowTemplate.Height = 55;

            formAciliyor = true;
            button1.PerformClick();
            formAciliyor = false;
            frmName.Text = formName.ToUpper();

            if (dtgPurchaseOrders.Rows.Count > 0)
            {
                txtSearch.Focus();
            }
        }

        public static string dialogresult = "";

        private void button2_Click(object sender, EventArgs e)
        {
            if (PurchaseOrderLists.Count > 0)
            {
                SiparisliMalGirisi_2 siparisliMalGirisi_2 = new SiparisliMalGirisi_2(PurchaseOrderLists, "SİPARİŞLİ MAL GİRİŞİ");
                siparisliMalGirisi_2.ShowDialog();
                siparisliMalGirisi_2.Dispose();
                GC.Collect();
                txtSearch.Text = "";
                button1.PerformClick();
                //this.Hide();
            }
            else
            {
                CustomMsgBox.Show("SATIN ALMA SİPARİŞİ SEÇİLMEDEN SİPARİŞE GİDİLEMEZ.", "Uyarı", "Tamam", "");
            }
        }

        private List<PurchaseOrderList> PurchaseOrderLists = new List<PurchaseOrderList>();
        private string dbName = "";
        private DataTable dtPurchase = new DataTable();

        private void button1_Click_1(object sender, EventArgs e)
        {
            dtgPurchaseOrders.DataSource = null;
            PurchaseOrderLists = new List<PurchaseOrderList>();
            string startDate = dtpStartDate.Value.ToString("yyyyMMdd");
            string endDate = dtpEndDate.Value.ToString("yyyyMMdd");

            txtSearch.ReadOnly = false;

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                CustomMsgBox.Show("BAŞLANGIÇ TARİHİ, BİTİŞ TARİHİNDEN BÜYÜK OLAMAZ.", "Uyarı", "Tamam", "");
                dtpStartDate.Focus();
                return;
            }

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = null;
            Response respDepo = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetPurchaseOrdersByDate(Giris._dbName, startDate, endDate, Giris.whsCodes.ToArray(), Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                respDepo = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_SipMalGrs", Giris.mKodValue);

                if (respDepo != null)
                {
                    List<string> whsCodes2 = new List<string>();
                    if (respDepo.Val == 0)
                    {
                        foreach (DataRow item in respDepo._list.Rows)
                        {
                            if (item["WhsCode"].ToString() != "")
                            {
                                whsCodes2.Add(item["WhsCode"].ToString());
                            }
                        }
                    }

                    resp = aIFTerminalServiceSoapClient.GetPurchaseOrdersByDate(Giris._dbName, startDate, endDate, whsCodes2.ToArray(), Giris.mKodValue);
                }
            }

            if (resp._list != null)
            {
                //dtgPurchaseOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtPurchase = resp._list;
                dtgPurchaseOrders.DataSource = null;

                if (dtgPurchaseOrders.Columns.Contains("ScmCheck") == true)
                {
                    dtgPurchaseOrders.Columns.RemoveAt(0);
                }
                dtgPurchaseOrders.DataSource = dtPurchase;
                //dtgPurchaseOrders.AutoResizeColumns();
                //dtgPurchaseOrders.AutoResizeRows();

                if (dtgPurchaseOrders.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }

                dtgPurchaseOrders.RowTemplate.Height = 55;
                dtgPurchaseOrders.ColumnHeadersHeight = 60;

                dtgPurchaseOrders.Columns["Belge Numarası"].HeaderText = "BEL.NO";
                dtgPurchaseOrders.Columns["Tedarikçi Kodu"].HeaderText = "TED.KOD";
                dtgPurchaseOrders.Columns["Tedarikçi Adı"].HeaderText = "TEDARİKÇİ ADI";
                dtgPurchaseOrders.Columns["Belge Tarihi"].HeaderText = "BEL.TAR";
                dtgPurchaseOrders.Columns["Teslimat Tarihi"].HeaderText = "TES.TAR";
                dtgPurchaseOrders.Columns["ScmCheck"].HeaderText = "SEÇ";

                dtgPurchaseOrders.Columns["Tedarikçi Kodu"].Visible = false;
                dtgPurchaseOrders.Columns["Belge Numarası"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPurchaseOrders.Columns["Tedarikçi Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPurchaseOrders.Columns["Belge Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPurchaseOrders.Columns["Teslimat Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPurchaseOrders.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dtgPurchaseOrders.Columns["Tedarikçi Adı"].Width = dtgPurchaseOrders.Width -dtgPurchaseOrders.Columns["Belge Numarası"].Width -dtgPurchaseOrders.Columns["Tedarikçi Kodu"].Width - dtgPurchaseOrders.Columns["Belge Tarihi"].Width - dtgPurchaseOrders.Columns["Teslimat Tarihi"].Width - dtgPurchaseOrders.Columns["ScmCheck"].Width;
            }
            else
            {
                //CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                dtgPurchaseOrders.DataSource = null;

                if (!formAciliyor)
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");

                    return;
                }

                if (dtgPurchaseOrders.Columns.Count > 0)
                {
                    dtgPurchaseOrders.Columns.RemoveAt(0);
                }

                formAciliyor = false;
            }
            vScrollBar1.Maximum = dtgPurchaseOrders.RowCount;

            //dtgPurchaseOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgPurchaseOrders.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgPurchaseOrders.Columns) //columns tıklayınca girişe atma
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgPurchaseOrders.Rows.Count > 0)
            {
                dtgPurchaseOrders.Rows[0].Selected = false;
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
            dtgPurchaseOrders.Columns.Add(checkColumn);

            dtgPurchaseOrders.RowHeadersVisible = false;
        }

        private void dtgPurchaseOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //header tıklama
            {
                return;
            }
            DataGridViewRow row = dtgPurchaseOrders.Rows[e.RowIndex];
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];

            if (chk.Value == chk.FalseValue || chk.Value == null)
            {
                DateTime dtTaxDate = DateTime.ParseExact(row.Cells["Teslimat Tarihi"].Value.ToString(), "dd/MM/yyyy", null);
                DateTime dtDocDueDate = DateTime.ParseExact(row.Cells["Belge Tarihi"].Value.ToString(), "dd/MM/yyyy", null);
                if (PurchaseOrderLists.Count == 0)
                {
                    PurchaseOrderLists.Add(new PurchaseOrderList
                    {
                        VendorCardCode = row.Cells["Tedarikçi Kodu"].Value.ToString(),
                        VendorName = row.Cells["Tedarikçi Adı"].Value.ToString(),
                        TaxDate = dtTaxDate.ToString("yyyyMMdd"),
                        DocDueDate = dtDocDueDate.ToString("yyyyMMdd"),
                        DocEntry = Convert.ToInt32(row.Cells["Belge Numarası"].Value)
                    });
                }
                else
                {
                    string vendor = row.Cells["Tedarikçi Kodu"].Value.ToString();

                    //string vendor = dtPurchase.Rows[e.RowIndex]["Tedarikçi Kodu"].ToString();

                    if (vendor != PurchaseOrderLists[0].VendorCardCode)
                    {
                        CustomMsgBox.Show("BİRDEN FAZLA SATICIYA AİT SEÇİM YAPILAMAZ.", "Uyarı", "Tamam", "");
                        return;
                    }
                    else
                    {
                        PurchaseOrderLists.Add(new PurchaseOrderList
                        {
                            VendorCardCode = row.Cells["Tedarikçi Kodu"].Value.ToString(),
                            VendorName = row.Cells["Tedarikçi Adı"].Value.ToString(),
                            TaxDate = dtTaxDate.ToString("yyyyMMdd"),
                            DocDueDate = dtDocDueDate.ToString("yyyyMMdd"),
                            DocEntry = Convert.ToInt32(row.Cells["Belge Numarası"].Value)
                        });
                    }
                }
                chk.Value = chk.TrueValue;
                dtgPurchaseOrders.EndEdit();

                //setFormatGrid(dataGridView1, 15);
            }
            else
            {
                chk.Value = chk.FalseValue;
                PurchaseOrderLists.RemoveAt(0);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var resp = dtPurchase.AsEnumerable().Where(x => x.Field<string>("Tedarikçi Adı").Contains(txtSearch.Text.ToUpper()) || x.Field<string>("Tedarikçi Kodu").Contains(txtSearch.Text.ToUpper())).ToList();

            int parsedValue;
            if (int.TryParse(txtSearch.Text, out parsedValue))
            {
                var resp2 = dtPurchase.AsEnumerable().Where(x => x.Field<int>("Belge Numarası") == Convert.ToInt32(txtSearch.Text)).ToList();

                if (resp2.Count > 0)
                {
                    foreach (var item in resp2)
                    {
                        var belgenovarmi = resp.Where(x => x.Field<int>("Belge Numarası") == item.Field<int>("Belge Numarası")).ToList();

                        if (belgenovarmi.Count == 0)
                        {
                            resp.AddRange(resp2);
                        }
                    }
                }
            }

            if (resp.Count > 0)
            {
                DataTable dts = resp.CopyToDataTable();

                dtgPurchaseOrders.DataSource = dts;

                if (dtgPurchaseOrders.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }
                dtgPurchaseOrders.RowTemplate.Height = 55;
                dtgPurchaseOrders.ColumnHeadersHeight = 60;

                dtgPurchaseOrders.Columns["Belge Numarası"].HeaderText = "BEL.NO";
                dtgPurchaseOrders.Columns["Tedarikçi Kodu"].HeaderText = "TED.KOD";
                dtgPurchaseOrders.Columns["Tedarikçi Adı"].HeaderText = "TEDARİKÇİ ADI";
                dtgPurchaseOrders.Columns["Belge Tarihi"].HeaderText = "BEL.TAR";
                dtgPurchaseOrders.Columns["Teslimat Tarihi"].HeaderText = "TES.TAR";
                dtgPurchaseOrders.Columns["ScmCheck"].HeaderText = "SEÇ";

                dtgPurchaseOrders.Columns["Tedarikçi Kodu"].Visible = false;
                dtgPurchaseOrders.Columns["Belge Numarası"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPurchaseOrders.Columns["Tedarikçi Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPurchaseOrders.Columns["Belge Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPurchaseOrders.Columns["Teslimat Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPurchaseOrders.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgPurchaseOrders.AutoResizeRows();

                #region arama yapılırken seçim checkbox ı kaybolma durumu

                if (PurchaseOrderLists.Count > 0)
                {
                    foreach (var item in PurchaseOrderLists)
                    {
                        string doc = item.DocEntry.ToString();

                        foreach (DataGridViewRow row in dtgPurchaseOrders.Rows)
                        {
                            //row.Cells["ScmCheck"].Value = true; //tüm satırları işaretler
                            if (doc == row.Cells["Belge Numarası"].Value.ToString())
                            {
                                row.Cells["ScmCheck"].Value = true;
                            }
                        }
                    }
                }

                #endregion arama yapılırken seçim checkbox ı kaybolma durumu
            }
            else
            {
                dtgPurchaseOrders.DataSource = null;

                if (dtgPurchaseOrders.Columns.Contains("ScmCheck") == true)
                {
                    dtgPurchaseOrders.Columns.RemoveAt(0);
                }
            }
            vScrollBar1.Maximum = dtgPurchaseOrders.RowCount;

            //dtgPurchaseOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgPurchaseOrders.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgPurchaseOrders.Columns) //columns tıklayınca girişe atma
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgPurchaseOrders.Rows.Count > 0)
            {
                dtgPurchaseOrders.Rows[0].Selected = false;
            }
        }

        private void dtpStartDate_DropDown(object sender, EventArgs e)
        {
            //if (dtpStartDate.Value.ToString("yyyyMMdd") == dtpEndDate.Value.ToString("yyyyMMdd"))
            //{
            //    CustomMsgBox.Show("dtpStartDate_DropDown", "Uyarı", "Tamam", "");
            //}
        }

        private void dtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            //if (dtpStartDate.Value.ToString("yyyyMMdd") == dtpEndDate.Value.ToString("yyyyMMdd"))
            //{
            //    CustomMsgBox.Show("dtpStartDate_KeyDown", "Uyarı", "Tamam", "");
            //}
        }

        private void dtpStartDate_Leave(object sender, EventArgs e)
        {
            //if (dtpStartDate.Value > dtpEndDate.Value)
            //{
            //    CustomMsgBox.Show("Başlangıç Tarihi, Bitiş Tarihinden Büyük Olamaz.", "Uyarı", "Tamam", "");
            //    dtpStartDate.Focus();
            //    return;
            //}
        }

        private void dtpEndDate_Leave(object sender, EventArgs e)
        {
            //if (dtpEndDate.Value < dtpStartDate.Value)
            //{
            //    CustomMsgBox.Show("Bitiş Tarihi, Başlangıç Tarihinden Küçük Olamaz.", "Uyarı", "Tamam", "");
            //    dtpEndDate.Focus();
            //    return;
            //}
        }

        private void dtgPurchaseOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //button2.PerformClick();
        }

        private void dtgPurchaseOrders_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgPurchaseOrders.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomMonthCalendar customMonthCalendar = new CustomMonthCalendar();
            customMonthCalendar.ShowDialog();
            customMonthCalendar.Dispose();
            GC.Collect();
        }

        //satırı seçince önizleme için yapılacak.
        private void dtgPurchaseOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgPurchaseOrders.SelectedCells.Count > 0)
            {
                int selectedrowindex = dtgPurchaseOrders.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dtgPurchaseOrders.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells["Tedarikçi Adı"].Value);
            }
        }
    }
}