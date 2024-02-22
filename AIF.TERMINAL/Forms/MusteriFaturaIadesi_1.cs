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
    public partial class MusteriFaturaIadesi_1 : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //end font

        public MusteriFaturaIadesi_1(string _formName)
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

            dtpStartDate.Font = new Font(dtpStartDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpStartDate.Font.Style);

            dtpEndDate.Font = new Font(dtpEndDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpEndDate.Font.Style);

            txtInvoiceSearch.Font = new Font(txtInvoiceSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtInvoiceSearch.Font.Style);

            btnList.Font = new Font(btnList.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnList.Font.Style);

            btnInvoiceList.Font = new Font(btnInvoiceList.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnInvoiceList.Font.Style);

            dtgInvoiceList.Font = new Font(dtgInvoiceList.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgInvoiceList.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            dtpStartDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpEndDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtInvoiceSearch.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private void MusteriFaturaIadesi_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            vScrollBar1.Maximum = dtgInvoiceList.RowCount;

            dtgInvoiceList.RowTemplate.Height = 55;
            dtgInvoiceList.ColumnHeadersHeight = 60;

            formAciliyor = true;
            btnList.PerformClick();
            formAciliyor = false;

            if (dtgInvoiceList.Rows.Count > 0)
            {
                txtInvoiceSearch.Focus();
            }
        }

        private DataTable dtInvoices = new DataTable();
        private List<Invoices> InvoiceList = new List<Invoices>();
        private string dbName = "";

        private void btnList_Click(object sender, EventArgs e)
        {
            dtgInvoiceList.DataSource = null;
            InvoiceList = new List<Invoices>();
            string startDate = dtpStartDate.Value.ToString("yyyyMMdd");
            string endDate = dtpEndDate.Value.ToString("yyyyMMdd");

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                CustomMsgBox.Show("BAŞLANGIÇ TARİHİ, BİTİŞ TARİHİNDEN BÜYÜK OLAMAZ.", "Uyarı", "Tamam", "");
                dtpStartDate.Focus();
                return;
            }

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.GetInvoices(Giris._dbName, startDate, endDate, Giris.mKodValue);

            if (resp._list != null)
            {
                dtInvoices = resp._list;
                dtgInvoiceList.DataSource = null;

                if (dtgInvoiceList.Columns.Contains("ScmCheck") == true)
                {
                    dtgInvoiceList.Columns.RemoveAt(0);
                }

                dtgInvoiceList.DataSource = dtInvoices;

                if (dtgInvoiceList.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }
                dtgInvoiceList.Columns["Fatura No"].HeaderText = "FAT.NO";
                dtgInvoiceList.Columns["Fatura Tarihi"].HeaderText = "FAT.TAR";
                dtgInvoiceList.Columns["Müşteri Kodu"].HeaderText = "MÜŞTERİ KODU";
                dtgInvoiceList.Columns["Müşteri Adı"].HeaderText = "MÜŞTERİ ADI";

                dtgInvoiceList.Columns["Müşteri Kodu"].Visible = false;

                dtgInvoiceList.Columns["Fatura No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInvoiceList.Columns["Fatura Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInvoiceList.Columns["Müşteri Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dtgInvoiceList.Columns["Müşteri Adı"].Width = dtgInvoiceList.Width - dtgInvoiceList.Columns["Fatura No"].Width - dtgInvoiceList.Columns["Fatura Tarihi"].Width - dtgInvoiceList.Columns["ScmCheck"].Width;
            }
            else
            {
                dtgInvoiceList.DataSource = null;

                if (!formAciliyor)
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");

                    return;
                }

                if (dtgInvoiceList.Columns.Count > 0)
                {
                    dtgInvoiceList.Columns.RemoveAt(0);
                }

                formAciliyor = false;
            }
            vScrollBar1.Maximum = dtgInvoiceList.RowCount + 5;

            foreach (DataGridViewColumn column in dtgInvoiceList.Columns) //columns tıklama
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgInvoiceList.Rows.Count > 0)
            {
                dtgInvoiceList.Rows[0].Selected = false;
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
            dtgInvoiceList.Columns.Add(checkColumn);

            dtgInvoiceList.RowHeadersVisible = false;
        }

        private void btnInvoiceList_Click(object sender, EventArgs e)
        {
            if (InvoiceList.Count > 0)
            {
                MusteriFaturaIadesi_2 musteriFaturaIadesi_2 = new MusteriFaturaIadesi_2(InvoiceList, "MÜŞTERİ FATURA İADESİ");
                musteriFaturaIadesi_2.ShowDialog();
                txtInvoiceSearch.Text = "";
                btnList.PerformClick();
            }
            else
            {
                CustomMsgBox.Show("FATURA SEÇİLMEDEN GİDİLEMEZ.", "Uyarı", "Tamam", "");
            }
        }

        private void dtgInvoiceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //header tıklama
            {
                return;
            }
            DataGridViewRow row = dtgInvoiceList.Rows[e.RowIndex];
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];

            if (chk.Value == chk.FalseValue || chk.Value == null)
            {
                DateTime dtDocDate = DateTime.ParseExact(row.Cells["Fatura Tarihi"].Value.ToString(), "dd/MM/yyyy", null);
                if (InvoiceList.Count == 0)
                {
                    InvoiceList.Add(new Invoices
                    {
                        CardCode = row.Cells["Müşteri Kodu"].Value.ToString(),
                        CardName = row.Cells["Müşteri Adı"].Value.ToString(),
                        DocDate = dtDocDate.ToString("yyyyMMdd"),
                        DocEntry = Convert.ToInt32(row.Cells["Fatura No"].Value)
                    });
                }
                else
                {
                    string code = dtInvoices.Rows[e.RowIndex]["Müşteri Kodu"].ToString();

                    if (code != InvoiceList[0].CardCode)
                    {
                        CustomMsgBox.Show("BİRDEN FAZLA SATICIYA AİT SEÇİM YAPILAMAZ.", "Uyarı", "Tamam", "");
                        return;
                    }
                    else
                    {
                        InvoiceList.Add(new Invoices
                        {
                            CardCode = row.Cells["Müşteri Kodu"].Value.ToString(),
                            CardName = row.Cells["Müşteri Adı"].Value.ToString(),
                            DocDate = dtDocDate.ToString("yyyyMMdd"),
                            DocEntry = Convert.ToInt32(row.Cells["Fatura No"].Value)
                        });
                    }
                }
                chk.Value = chk.TrueValue;
                dtgInvoiceList.EndEdit();
            }
            else
            {
                chk.Value = chk.FalseValue;
                InvoiceList.RemoveAt(0);
            }
        }

        private void txtInvoiceSearch_TextChanged(object sender, EventArgs e)
        {
            var resp = dtInvoices.AsEnumerable().Where(x => x.Field<string>("Müşteri Adı").Contains(txtInvoiceSearch.Text.ToUpper()) || x.Field<string>("Müşteri Kodu").Contains(txtInvoiceSearch.Text.ToUpper())).ToList();

            int parsedValue;
            if (int.TryParse(txtInvoiceSearch.Text, out parsedValue))
            {
                var resp2 = dtInvoices.AsEnumerable().Where(x => x.Field<int>("Fatura No") == Convert.ToInt32(txtInvoiceSearch.Text)).ToList();

                if (resp2.Count > 0)
                {
                    foreach (var item in resp2)
                    {
                        var faturaNoVarmi = resp.Where(x => x.Field<int>("Fatura No") == item.Field<int>("Fatura No")).ToList();

                        if (faturaNoVarmi.Count == 0)
                        {
                            resp.AddRange(resp2);
                        }
                    }
                }
            }

            if (resp.Count > 0)
            {
                DataTable dts = resp.CopyToDataTable();

                dtgInvoiceList.DataSource = dts;

                if (dtgInvoiceList.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }

                dtgInvoiceList.Columns["Fatura No"].HeaderText = "FAT.NO";
                dtgInvoiceList.Columns["Fatura Tarihi"].HeaderText = "FAT.TAR";
                dtgInvoiceList.Columns["Müşteri Kodu"].HeaderText = "MÜŞTERİ KODU";
                dtgInvoiceList.Columns["Müşteri Adı"].HeaderText = "MÜŞTERİ ADI";

                dtgInvoiceList.Columns["Müşteri Kodu"].Visible = false;

                dtgInvoiceList.Columns["Fatura No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInvoiceList.Columns["Fatura Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInvoiceList.Columns["Müşteri Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                dtgInvoiceList.DataSource = null;

                if (dtgInvoiceList.Columns.Contains("ScmCheck") == true)
                {
                    dtgInvoiceList.Columns.RemoveAt(0);
                }
            }
            vScrollBar1.Maximum = dtgInvoiceList.RowCount + 5;

            foreach (DataGridViewColumn column in dtgInvoiceList.Columns) //columns tıklama
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgInvoiceList.Rows.Count > 0)
            {
                dtgInvoiceList.Rows[0].Selected = false;
            }
        }

        private void dtgInvoiceList_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgInvoiceList.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }
    }
}