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
    public partial class TeslimatIadesi_2 : form_Base
    {
        //start font.
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //end font

        public TeslimatIadesi_2(List<DeliveryNote> _deliveryNotes, string _formName)
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

            deliveryNotes = _deliveryNotes;

            if (deliveryNotes != null)
            {
                txtCustomerCode.Text = deliveryNotes[0].CardCode;
                txtCustomerName.Text = deliveryNotes[0].CardName;

                List<string> docEntryList = new List<string>();

                foreach (var item in deliveryNotes)
                {
                    docEntryList.Add(item.DocEntry.ToString());

                }
                GetDeliveryDetails(docEntryList);
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

            dtgDeliveryDetails.Font = new Font(dtgDeliveryDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgDeliveryDetails.Font.Style);

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

        DataTable dtDetails = new DataTable();
        List<DeliveryNote> deliveryNotes = new List<DeliveryNote>();
        private void TeslimatIadesi_2_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            vScrollBar1.Maximum = dtgDeliveryDetails.RowCount;

            dtgDeliveryDetails.RowTemplate.Height = 55;
            dtgDeliveryDetails.ColumnHeadersHeight = 60;

            if (dtgDeliveryDetails.Rows.Count > 0)
            {
                dtgDeliveryDetails.Rows[0].Selected = false;
            }
        }

        private void GetDeliveryDetails(List<string> docEntryList)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.GetDeliveryNoteDetails(Giris._dbName, docEntryList.ToArray(), Giris.mKodValue);

            if (resp._list != null)
            {
                dtDetails = resp._list;
                dtgDeliveryDetails.DataSource = null;

                //dtgDeliveryDetails.RowHeadersVisible = false;

                if (dtgDeliveryDetails.Columns.Contains("ScmCheck") == true)
                {
                    dtgDeliveryDetails.Columns.RemoveAt(0);
                }

                dtgDeliveryDetails.DataSource = dtDetails;
                dtgDeliveryDetails.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                if (dtgDeliveryDetails.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();

                }
                dtgDeliveryDetails.Columns["Fatura No"].HeaderText = "FAT.NO";
                dtgDeliveryDetails.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
                dtgDeliveryDetails.Columns["Kalem Adı"].HeaderText = "KALEM ADI";
                dtgDeliveryDetails.Columns["Miktar"].HeaderText = "MİKTAR";
                dtgDeliveryDetails.Columns["Birim"].HeaderText = "BRM";

                dtgDeliveryDetails.Columns["Sıra"].Visible = false;
                dtgDeliveryDetails.Columns["Kalem Kodu"].Visible = false;
                dtgDeliveryDetails.RowTemplate.Height = 55;

                dtgDeliveryDetails.Columns["Fatura No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgDeliveryDetails.Columns["Kalem Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDeliveryDetails.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDeliveryDetails.Columns["Birim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dtgDeliveryDetails.Columns["Kalem Adı"].Width = dtgDeliveryDetails.Width - dtgDeliveryDetails.Columns["Fatura No"].Width -
                //        dtgDeliveryDetails.Columns["Kalem Kodu"].Width - dtgDeliveryDetails.Columns["Miktar"].Width - dtgDeliveryDetails.Columns["Birim"].Width;

                dtgDeliveryDetails.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                foreach (DataGridViewColumn column in dtgDeliveryDetails.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (dtgDeliveryDetails.Rows.Count > 0)
                {
                    dtgDeliveryDetails.Rows[0].Selected = false;
                }
            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");

            }
            vScrollBar1.Maximum = dtgDeliveryDetails.RowCount + 5;

            

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
            dtgDeliveryDetails.Columns.Add(checkColumn);

            dtgDeliveryDetails.RowHeadersVisible = false;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgDeliveryDetails.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];

                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    chk.Value = chk.TrueValue;
                    dtgDeliveryDetails.EndEdit();
                }
                else
                {
                    chk.Value = chk.FalseValue;
                    dtgDeliveryDetails.EndEdit();
                }
            }
        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();
            DeliveryNotesReturns deliveryNotesReturns = new DeliveryNotesReturns();
            DeliveryNotesReturnDetails deliveryNotesReturnDetails = new DeliveryNotesReturnDetails();
            List<DeliveryNotesReturnDetails> DeliveryNotesReturnDetails = new List<DeliveryNotesReturnDetails>();

            DataGridViewRow row = dtgDeliveryDetails.Rows[0];
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];

            bool check = false;

            for (int i = 0; i <= dtgDeliveryDetails.Rows.Count - 1; i++)
            {
                row = dtgDeliveryDetails.Rows[i];
                chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
                if (chk.Value == chk.TrueValue)
                {
                    deliveryNotesReturnDetails = new DeliveryNotesReturnDetails();
                    deliveryNotesReturnDetails.DocEntry = Convert.ToInt32(dtgDeliveryDetails.Rows[i].Cells["Fatura No"].Value);
                    deliveryNotesReturnDetails.LineNum = dtgDeliveryDetails.Rows[i].Cells["Sıra"].Value.ToString();
                    deliveryNotesReturnDetails.Quantity = Convert.ToDouble(dtgDeliveryDetails.Rows[i].Cells["Miktar"].Value);
                    DeliveryNotesReturnDetails.Add(deliveryNotesReturnDetails);
                    check = true;
                }
            }

            if (check)
            {
                deliveryNotesReturns.DeliveryNotesReturnDetails = DeliveryNotesReturnDetails.ToArray();

                var resp = aIFTerminalServiceSoapClient1.AddOrUpdateDeliveryNote(Giris._dbName, Convert.ToInt32(Giris._userCode), deliveryNotesReturns);

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
                CustomMsgBox.Show("SATIR SEÇMEDEN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
            }
        }

        private void dtgDeliveryDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dtgDeliveryDetails.Rows[e.RowIndex];
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];


                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    chk.Value = chk.TrueValue;
                    dtgDeliveryDetails.EndEdit();
                }
                else
                {
                    chk.Value = chk.FalseValue;
                    dtgDeliveryDetails.EndEdit();
                }
            }
        }
    }
}
