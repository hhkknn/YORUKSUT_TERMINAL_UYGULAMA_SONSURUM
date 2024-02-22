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
    public partial class IadeTalebi_1 : form_Base
    {
        //start font.
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //end font

        private string formName = "";
        public static bool formAciliyor = false;
        public static string dialogresult = "";
        private DataGridViewCheckBoxColumn checkColumn = null;

        private List<IadeTalepleri> iadeTalepleris = new List<IadeTalepleri>();
        private string dbName = "";
        private DataTable dtIadeTalepleri = new DataTable();
        public IadeTalebi_1(string _formName)
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

            btnListele.Font = new Font(btnListele.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnListele.Font.Style);

            btnTalebeGit.Font = new Font(btnTalebeGit.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTalebeGit.Font.Style);

            dtgIadeTalebi.Font = new Font(dtgIadeTalebi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgIadeTalebi.Font.Style);
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
            dtgIadeTalebi.Columns.Add(checkColumn);

            dtgIadeTalebi.RowHeadersVisible = false;
        }

        private void IadeTalebi_1_Load(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = true;
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            vScrollBar1.Maximum = dtgIadeTalebi.RowCount;

            dtgIadeTalebi.RowTemplate.Height = 55;

            formAciliyor = true;
            btnListele.PerformClick();
            formAciliyor = false;
            frmName.Text = formName;

            if (dtgIadeTalebi.Rows.Count > 0)
            {
                txtSearch.Focus();
            }
        }

        private void dtgIadeTalebi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //header tıklama
            {
                return;
            }
            DataGridViewRow row = dtgIadeTalebi.Rows[e.RowIndex];
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];

            if (chk.Value == chk.FalseValue || chk.Value == null)
            {
                DateTime dtTaxDate = DateTime.ParseExact(row.Cells["Teslimat Tarihi"].Value.ToString(), "dd/MM/yyyy", null);
                DateTime dtDocDueDate = DateTime.ParseExact(row.Cells["Belge Tarihi"].Value.ToString(), "dd/MM/yyyy", null);
                if (iadeTalepleris.Count == 0)
                {
                    iadeTalepleris.Add(new IadeTalepleri
                    {
                        CardCode = row.Cells["Müşteri Kodu"].Value.ToString(),
                        CardName = row.Cells["Müşteri Adı"].Value.ToString(),
                        SevkAdresi = row.Cells["Sevkiyat Adresi"].Value.ToString(),
                        TaxDate = dtTaxDate.ToString("yyyyMMdd"),
                        DocDueDate = dtDocDueDate.ToString("yyyyMMdd"),
                        DocEntry = Convert.ToInt32(row.Cells["Belge Numarası"].Value)
                    });
                }
                else
                {
                    string vendor = row.Cells["Müşteri Kodu"].Value.ToString();

                    //string vendor = dtPurchase.Rows[e.RowIndex]["Tedarikçi Kodu"].ToString();

                    if (vendor != iadeTalepleris[0].CardCode)
                    {
                        CustomMsgBox.Show("BİRDEN FAZLA SATICIYA AİT SEÇİM YAPILAMAZ.", "Uyarı", "Tamam", "");
                        return;
                    }
                    else
                    {
                        iadeTalepleris.Add(new IadeTalepleri
                        {
                            CardCode = row.Cells["Müşteri Kodu"].Value.ToString(),
                            CardName = row.Cells["Müşteri Adı"].Value.ToString(),
                            SevkAdresi = row.Cells["Sevkiyat Adresi"].Value.ToString(),
                            TaxDate = dtTaxDate.ToString("yyyyMMdd"),
                            DocDueDate = dtDocDueDate.ToString("yyyyMMdd"),
                            DocEntry = Convert.ToInt32(row.Cells["Belge Numarası"].Value)
                        });
                    }
                }
                chk.Value = chk.TrueValue;
                dtgIadeTalebi.EndEdit();

                //setFormatGrid(dataGridView1, 15);
            }
            else
            {
                chk.Value = chk.FalseValue;
                iadeTalepleris.RemoveAt(0);
            }
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            dtgIadeTalebi.DataSource = null;
            iadeTalepleris = new List<IadeTalepleri>();
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
                resp = aIFTerminalServiceSoapClient.GetIadeTalepleri(Giris._dbName, startDate, endDate, Giris.whsCodes.ToArray(), Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                respDepo = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_IadeTalep", Giris.mKodValue);

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

                    resp = aIFTerminalServiceSoapClient.GetIadeTalepleri(Giris._dbName, startDate, endDate, whsCodes2.ToArray(), Giris.mKodValue);
                }
            }

            if (resp._list != null)
            {
                //dtgPurchaseOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtIadeTalepleri = resp._list;
                dtgIadeTalebi.DataSource = null;

                if (dtgIadeTalebi.Columns.Contains("ScmCheck") == true)
                {
                    dtgIadeTalebi.Columns.RemoveAt(0);
                }
                dtgIadeTalebi.DataSource = dtIadeTalepleri;
                //dtgPurchaseOrders.AutoResizeColumns();
                //dtgPurchaseOrders.AutoResizeRows();

                if (dtgIadeTalebi.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }

                dtgIadeTalebi.RowTemplate.Height = 55;
                dtgIadeTalebi.ColumnHeadersHeight = 60;

                dtgIadeTalebi.Columns["Belge Numarası"].HeaderText = "BEL.NO";
                dtgIadeTalebi.Columns["Müşteri Kodu"].HeaderText = "TED.KOD";
                dtgIadeTalebi.Columns["Müşteri Adı"].HeaderText = "TEDARİKÇİ ADI";
                dtgIadeTalebi.Columns["Belge Tarihi"].HeaderText = "BEL.TAR";
                dtgIadeTalebi.Columns["Teslimat Tarihi"].HeaderText = "TES.TAR";
                dtgIadeTalebi.Columns["Sevkiyat Adresi"].HeaderText = "SEVK ADRESİ";
                dtgIadeTalebi.Columns["ScmCheck"].HeaderText = "SEÇ";

                dtgIadeTalebi.Columns["Müşteri Kodu"].Visible = false;
                //dtgPurchaseOrders.Columns["Belge Numarası"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgPurchaseOrders.Columns["Tedarikçi Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgPurchaseOrders.Columns["Belge Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgPurchaseOrders.Columns["Teslimat Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgPurchaseOrders.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dtgPurchaseOrders.Columns["Tedarikçi Adı"].Width = dtgPurchaseOrders.Width -dtgPurchaseOrders.Columns["Belge Numarası"].Width -dtgPurchaseOrders.Columns["Tedarikçi Kodu"].Width - dtgPurchaseOrders.Columns["Belge Tarihi"].Width - dtgPurchaseOrders.Columns["Teslimat Tarihi"].Width - dtgPurchaseOrders.Columns["ScmCheck"].Width;
            }
            else
            {
                //CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                dtgIadeTalebi.DataSource = null;

                if (!formAciliyor)
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");

                    return;
                }

                if (dtgIadeTalebi.Columns.Count > 0)
                {
                    dtgIadeTalebi.Columns.RemoveAt(0);
                }

                formAciliyor = false;
            }
            vScrollBar1.Maximum = dtgIadeTalebi.RowCount;

            //dtgPurchaseOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgPurchaseOrders.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgIadeTalebi.Columns) //columns tıklayınca girişe atma
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgIadeTalebi.Rows.Count > 0)
            {
                dtgIadeTalebi.Rows[0].Selected = false;
            }
        }

        private void btnTalebeGit_Click(object sender, EventArgs e)
        {
            if (iadeTalepleris.Count > 0)
            {
                IadeTalebi_2 iadeTalebi_2 = new IadeTalebi_2(iadeTalepleris, "İADE TALEPLERİ");
                iadeTalebi_2.ShowDialog();
                iadeTalebi_2.Dispose();
                GC.Collect();
                txtSearch.Text = "";
                btnListele.PerformClick();
                //this.Hide();
            }
            else
            {
                CustomMsgBox.Show("SATIN ALMA SİPARİŞİ SEÇİLMEDEN SİPARİŞE GİDİLEMEZ.", "Uyarı", "Tamam", "");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var resp = dtIadeTalepleri.AsEnumerable().Where(x => x.Field<string>("Müşteri Adı").Contains(txtSearch.Text.ToUpper()) || x.Field<string>("Müşteri Kodu").Contains(txtSearch.Text.ToUpper())).ToList();

            int parsedValue;
            if (int.TryParse(txtSearch.Text, out parsedValue))
            {
                var resp2 = dtIadeTalepleri.AsEnumerable().Where(x => x.Field<int>("Belge Numarası") == Convert.ToInt32(txtSearch.Text)).ToList();

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

                dtgIadeTalebi.DataSource = dts;

                if (dtgIadeTalebi.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }
                dtgIadeTalebi.RowTemplate.Height = 55;
                dtgIadeTalebi.ColumnHeadersHeight = 60;

                dtgIadeTalebi.Columns["Belge Numarası"].HeaderText = "BEL.NO";
                dtgIadeTalebi.Columns["Müşteri Kodu"].HeaderText = "TED.KOD";
                dtgIadeTalebi.Columns["Müşteri Adı"].HeaderText = "TEDARİKÇİ ADI";
                dtgIadeTalebi.Columns["Belge Tarihi"].HeaderText = "BEL.TAR";
                dtgIadeTalebi.Columns["Teslimat Tarihi"].HeaderText = "TES.TAR";
                dtgIadeTalebi.Columns["Sevkiyat Adresi"].HeaderText = "SEVK ADRESİ";
                dtgIadeTalebi.Columns["ScmCheck"].HeaderText = "SEÇ";

                dtgIadeTalebi.Columns["Müşteri Kodu"].Visible = false;
                //dtgPurchaseOrders.AutoResizeRows();

                #region arama yapılırken seçim checkbox ı kaybolma durumu

                if (iadeTalepleris.Count > 0)
                {
                    foreach (var item in iadeTalepleris)
                    {
                        string doc = item.DocEntry.ToString();

                        foreach (DataGridViewRow row in dtgIadeTalebi.Rows)
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
                dtgIadeTalebi.DataSource = null;

                if (dtgIadeTalebi.Columns.Contains("ScmCheck") == true)
                {
                    dtgIadeTalebi.Columns.RemoveAt(0);
                }
            }
            vScrollBar1.Maximum = dtgIadeTalebi.RowCount;

            //dtgPurchaseOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgPurchaseOrders.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgIadeTalebi.Columns) //columns tıklayınca girişe atma
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgIadeTalebi.Rows.Count > 0)
            {
                dtgIadeTalebi.Rows[0].Selected = false;
            }
        }

        private void dtgIadeTalebi_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgIadeTalebi.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }
    }
}
