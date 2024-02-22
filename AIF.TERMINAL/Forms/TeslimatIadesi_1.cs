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
    public partial class TeslimatIadesi_1 : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //end font

        public TeslimatIadesi_1(string _formName)
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

            txtSearchDelivery.Font = new Font(txtSearchDelivery.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSearchDelivery.Font.Style);

            btnList.Font = new Font(btnList.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnList.Font.Style);

            btnDeliveryList.Font = new Font(btnDeliveryList.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDeliveryList.Font.Style);

            dtgDeliveryList.Font = new Font(dtgDeliveryList.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgDeliveryList.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            dtpStartDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpEndDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtSearchDelivery.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private void TeslimatIadesi_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            vScrollBar1.Maximum = dtgDeliveryList.RowCount;

            dtgDeliveryList.RowTemplate.Height = 55;
            dtgDeliveryList.ColumnHeadersHeight = 60;

            formAciliyor = true;
            btnList.PerformClick();
            formAciliyor = false;

            if (dtgDeliveryList.Rows.Count > 0)
            {
                txtSearchDelivery.Focus();
            }
        }

        private DataTable dtDelivery = new DataTable();
        private List<DeliveryNote> deliveryNotes = new List<DeliveryNote>();

        private void btnList_Click(object sender, EventArgs e)
        {
            dtgDeliveryList.DataSource = null;
            deliveryNotes = new List<DeliveryNote>();

            string startDate = dtpStartDate.Value.ToString("yyyyMMdd");
            string endDate = dtpEndDate.Value.ToString("yyyyMMdd");

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                CustomMsgBox.Show("BAŞLANGIÇ TARİHİ, BİTİŞ TARİHİNDEN BÜYÜK OLAMAZ.", "UYARI", "TAMAM", "");
                dtpStartDate.Focus();
                return;
            }

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.GetDeliveryNote(Giris._dbName, startDate, endDate, Giris.mKodValue);

            if (resp._list != null)
            {
                dtDelivery = resp._list;
                dtgDeliveryList.DataSource = null;

                if (dtgDeliveryList.Columns.Contains("ScmCheck") == true)
                {
                    dtgDeliveryList.Columns.RemoveAt(0);
                }

                dtgDeliveryList.DataSource = dtDelivery;

                if (dtgDeliveryList.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }
                dtgDeliveryList.Columns["Teslimat No"].HeaderText = "TES.NO";
                dtgDeliveryList.Columns["Teslimat Tarihi"].HeaderText = "TES.TAR";
                dtgDeliveryList.Columns["Müşteri Kodu"].HeaderText = "MÜŞTERİ KODU";
                dtgDeliveryList.Columns["Müşteri Adı"].HeaderText = "MÜŞTERİ ADI";

                dtgDeliveryList.Columns["Müşteri Kodu"].Visible = false;

                dtgDeliveryList.Columns["Teslimat No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDeliveryList.Columns["Teslimat Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgDeliveryList.Columns["Müşteri Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDeliveryList.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dtgDeliveryList.Columns["Müşteri Adı"].Width = dtgDeliveryList.Width - dtgDeliveryList.Columns["Teslimat No"].Width - dtgDeliveryList.Columns["Teslimat Tarihi"].Width - dtgDeliveryList.Columns["Müşteri Kodu"].Width - dtgDeliveryList.Columns["ScmCheck"].Width;
            }
            else
            {
                dtgDeliveryList.DataSource = null;

                if (!formAciliyor)
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");

                    return;
                }

                if (dtgDeliveryList.Columns.Count > 0)
                {
                    dtgDeliveryList.Columns.RemoveAt(0);
                }

                formAciliyor = false;
            }
            vScrollBar1.Maximum = dtgDeliveryList.RowCount;

            foreach (DataGridViewColumn column in dtgDeliveryList.Columns) //columns
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgDeliveryList.Rows.Count > 0)
            {
                dtgDeliveryList.Rows[0].Selected = false;
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
            dtgDeliveryList.Columns.Add(checkColumn);

            dtgDeliveryList.RowHeadersVisible = false;
        }

        private void btnDeliveryList_Click(object sender, EventArgs e)
        {
            if (deliveryNotes.Count > 0)
            {
                TeslimatIadesi_2 teslimatIadesi_2 = new TeslimatIadesi_2(deliveryNotes, "TESLİMAT İADESİ");
                teslimatIadesi_2.ShowDialog();
                teslimatIadesi_2.Dispose();
                GC.Collect();
                txtSearchDelivery.Text = "";
                btnList.PerformClick();
            }
            else
            {
                CustomMsgBox.Show("FATURA SEÇİLMEDEN GİDİLEMEZ.", "Uyarı", "Tamam", "");
            }
        }

        private void dtgDeliveryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //header tıklama
            {
                return;
            }
            DataGridViewRow row = dtgDeliveryList.Rows[e.RowIndex];
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];

            if (chk.Value == chk.FalseValue || chk.Value == null)
            {
                DateTime dtDocDate = DateTime.ParseExact(row.Cells["Teslimat Tarihi"].Value.ToString(), "dd/MM/yyyy", null);
                if (deliveryNotes.Count == 0)
                {
                    deliveryNotes.Add(new DeliveryNote
                    {
                        CardCode = row.Cells["Müşteri Kodu"].Value.ToString(),
                        CardName = row.Cells["Müşteri Adı"].Value.ToString(),
                        DocDate = dtDocDate.ToString("yyyyMMdd"),
                        DocEntry = Convert.ToInt32(row.Cells["Teslimat No"].Value)
                    });
                }
                else
                {
                    string code = dtDelivery.Rows[e.RowIndex]["Müşteri Kodu"].ToString();

                    if (code != deliveryNotes[0].CardCode)
                    {
                        CustomMsgBox.Show("BİRDEN FAZLA SATICIYA AİT SEÇİM YAPILAMAZ.", "Uyarı", "Tamam", "");
                        return;
                    }
                    else
                    {
                        deliveryNotes.Add(new DeliveryNote
                        {
                            CardCode = row.Cells["Müşteri Kodu"].Value.ToString(),
                            CardName = row.Cells["Müşteri Adı"].Value.ToString(),
                            DocDate = dtDocDate.ToString("yyyyMMdd"),
                            DocEntry = Convert.ToInt32(row.Cells["Teslimat No"].Value)
                        });
                    }
                }
                chk.Value = chk.TrueValue;
                dtgDeliveryList.EndEdit();
            }
            else
            {
                chk.Value = chk.FalseValue;
                deliveryNotes.RemoveAt(0);
            }
        }

        private void txtSearchDelivery_TextChanged(object sender, EventArgs e)
        {
            var resp = dtDelivery.AsEnumerable().Where(x => x.Field<string>("Müşteri Adı").Contains(txtSearchDelivery.Text.ToUpper()) || x.Field<string>("Müşteri Kodu").Contains(txtSearchDelivery.Text.ToUpper())).ToList();

            int parsedValue;
            if (int.TryParse(txtSearchDelivery.Text, out parsedValue))
            {
                var resp2 = dtDelivery.AsEnumerable().Where(x => x.Field<int>("Fatura No") == Convert.ToInt32(txtSearchDelivery.Text)).ToList();

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

                dtgDeliveryList.DataSource = dts;

                if (dtgDeliveryList.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }
                dtgDeliveryList.Columns["Teslimat No"].HeaderText = "TES.NO";
                dtgDeliveryList.Columns["Teslimat Tarihi"].HeaderText = "TES.TAR";
                dtgDeliveryList.Columns["Müşteri Kodu"].HeaderText = "MÜŞTERİ KODU";
                dtgDeliveryList.Columns["Müşteri Adı"].HeaderText = "MÜŞTERİ ADI";

                dtgDeliveryList.Columns["Müşteri Kodu"].Visible = false;

                dtgDeliveryList.Columns["Teslimat No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDeliveryList.Columns["Teslimat Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgDeliveryList.Columns["Müşteri Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDeliveryList.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                dtgDeliveryList.DataSource = null;

                if (dtgDeliveryList.Columns.Contains("ScmCheck") == true)
                {
                    dtgDeliveryList.Columns.RemoveAt(0);
                }
            }
            vScrollBar1.Maximum = dtgDeliveryList.RowCount;

            foreach (DataGridViewColumn column in dtgDeliveryList.Columns) //columns
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgDeliveryList.Rows.Count > 0)
            {
                dtgDeliveryList.Rows[0].Selected = false;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgDeliveryList.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void dtgDeliveryList_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }
    }
}