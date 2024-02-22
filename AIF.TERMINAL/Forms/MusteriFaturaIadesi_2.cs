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
    public partial class MusteriFaturaIadesi_2 : form_Base
    {
        //start font.
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //end font

        public MusteriFaturaIadesi_2(List<Invoices> invoiceList, string _formName)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            initialFontSize = btnAddOrUpdate.Font.Size;
            btnAddOrUpdate.Resize += Form_Resize;

            initialFontSize = btnSelectAll.Font.Size;
            btnSelectAll.Resize += Form_Resize;

            initialFontSize = dtgInvoicesDetails.Font.Size;
            dtgInvoicesDetails.Resize += Form_Resize;
            //end font

            formName = _formName;

            InvoiceLists = invoiceList;
            if (InvoiceLists != null)
            {
                txtCustomerCode.Text = invoiceList[0].CardCode;
                txtCustomerName.Text = invoiceList[0].CardName;

                List<string> docEntryList = new List<string>();

                foreach (var item in InvoiceLists)
                {
                    docEntryList.Add(item.DocEntry.ToString());
                }
                GetInvoicesDetails(docEntryList);
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

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtCustomerCode.Font = new Font(txtCustomerCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCustomerCode.Font.Style);

            txtCustomerName.Font = new Font(txtCustomerName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCustomerName.Font.Style);

            btnSelectAll.Font = new Font(btnSelectAll.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSelectAll.Font.Style);

            btnAddOrUpdate.Font = new Font(btnAddOrUpdate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAddOrUpdate.Font.Style);

            dtgInvoicesDetails.Font = new Font(dtgInvoicesDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgInvoicesDetails.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtCustomerCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtCustomerName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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
        string formName = "";

        private void MusteriFaturaIadesi_2_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            vScrollBar1.Maximum = dtgInvoicesDetails.RowCount;

            dtgInvoicesDetails.RowTemplate.Height = 55;
            dtgInvoicesDetails.ColumnHeadersHeight = 60;

            dtgInvoicesDetails.Width = dtgInvoicesDetails.Width;

            if (dtgInvoicesDetails.Rows.Count > 0)
            {
                dtgInvoicesDetails.Rows[0].Selected = false;
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
            dtgInvoicesDetails.Columns.Add(checkColumn);

            dtgInvoicesDetails.RowHeadersVisible = false;


        }
        DataTable dtDetails = new DataTable();
        List<Invoices> InvoiceLists = new List<Invoices>();

        private void GetInvoicesDetails(List<string> docEntryList)
        {

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.GetInvoicesDetails(Giris._dbName, docEntryList.ToArray(), Giris.mKodValue);

            if (resp._list != null)
            {
                dtDetails = resp._list;
                dtgInvoicesDetails.DataSource = null;


                if (dtgInvoicesDetails.Columns.Contains("ScmCheck") == true)
                {
                    dtgInvoicesDetails.Columns.RemoveAt(0);
                }
                dtgInvoicesDetails.DataSource = dtDetails;
                dtgInvoicesDetails.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;


                if (dtgInvoicesDetails.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();

                }

                dtgInvoicesDetails.RowTemplate.Height = 55;


                dtgInvoicesDetails.Columns["Fatura No"].HeaderText = "FAT.NO";
                dtgInvoicesDetails.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
                dtgInvoicesDetails.Columns["Kalem Adı"].HeaderText = "KALEM ADI";
                dtgInvoicesDetails.Columns["Miktar"].HeaderText = "MİKTAR";
                dtgInvoicesDetails.Columns["Birim"].HeaderText = "BRM";
                dtgInvoicesDetails.Columns["Sıra"].HeaderText = "SIRA";

                dtgInvoicesDetails.Columns["Sıra"].Visible = false;
                dtgInvoicesDetails.Columns["Kalem Kodu"].Visible = false;

                dtgInvoicesDetails.Columns["Fatura No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgInvoicesDetails.Columns["Kalem Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgInvoicesDetails.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInvoicesDetails.Columns["Birim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgInvoicesDetails.Columns["Sıra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInvoicesDetails.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dtgInvoicesDetails.Columns["Kalem Adı"].Width = dtgInvoicesDetails.Width - dtgInvoicesDetails.Columns["Fatura No"].Width -
                //dtgInvoicesDetails.Columns["Miktar"].Width - dtgInvoicesDetails.Columns["Birim"].Width;

                dtgInvoicesDetails.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                foreach (DataGridViewColumn column in dtgInvoicesDetails.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (dtgInvoicesDetails.Rows.Count > 0)
                {
                    dtgInvoicesDetails.Rows[0].Selected = false;
                }
            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
            vScrollBar1.Maximum = dtgInvoicesDetails.RowCount + 5;

        }
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgInvoicesDetails.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];

                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    chk.Value = chk.TrueValue;
                    dtgInvoicesDetails.EndEdit();
                }
                else
                {
                    chk.Value = chk.FalseValue;
                    dtgInvoicesDetails.EndEdit();
                }
            }


        }
        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();
            InvoiceReturn invoiceReturn = new InvoiceReturn();
            InvoiceReturnDetails invoiceReturnDetails = new InvoiceReturnDetails();
            List<InvoiceReturnDetails> InvoiceReturnDetails = new List<InvoiceReturnDetails>();

            DataGridViewRow row = dtgInvoicesDetails.Rows[0];
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];

            bool check = false;

            for (int i = 0; i <= dtgInvoicesDetails.Rows.Count - 1; i++)
            {
                row = dtgInvoicesDetails.Rows[i];
                chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
                if (chk.Value == chk.TrueValue)
                {
                    invoiceReturnDetails = new InvoiceReturnDetails();
                    invoiceReturnDetails.DocEntry = Convert.ToInt32(dtgInvoicesDetails.Rows[i].Cells["Fatura No"].Value);
                    invoiceReturnDetails.LineNum = dtgInvoicesDetails.Rows[i].Cells["Sıra"].Value.ToString();
                    invoiceReturnDetails.Quantity = Convert.ToDouble(dtgInvoicesDetails.Rows[i].Cells["Miktar"].Value);
                    InvoiceReturnDetails.Add(invoiceReturnDetails);
                    check = true;
                }
            }

            if (check)
            {
                invoiceReturn.InvoiceReturnDetails = InvoiceReturnDetails.ToArray();

                var resp = aIFTerminalServiceSoapClient1.AddOrUpdateInvoiceReturn(Giris._dbName,Convert.ToInt32(Giris._userCode), invoiceReturn);

                if (resp.Val == 0)
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                    this.Close();
                }
                else
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                    return;
                }
            }
            else
            {
                CustomMsgBox.Show("SATIR SEÇİLMEDEN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
            }
        }
        private void dtgInvoicesDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dtgInvoicesDetails.Rows[e.RowIndex];
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];


                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    chk.Value = chk.TrueValue;
                    dtgInvoicesDetails.EndEdit();
                }
                else
                {
                    chk.Value = chk.FalseValue;
                    dtgInvoicesDetails.EndEdit();
                }
            }
        }
    }
}
