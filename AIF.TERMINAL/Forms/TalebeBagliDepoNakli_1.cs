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
    public partial class TalebeBagliDepoNakli_1 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public TalebeBagliDepoNakli_1(string _formName)
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

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            dtpStartDate.Font = new Font(dtpStartDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpStartDate.Font.Style);

            dtpEndDate.Font = new Font(dtpEndDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpEndDate.Font.Style);

            cmbTargetCode.Font = new Font(cmbTargetCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbTargetCode.Font.Style);

            cmbSourceCode.Font = new Font(cmbSourceCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbSourceCode.Font.Style);

            txtSearch.Font = new Font(txtSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSearch.Font.Style);

            txtSourceCode.Font = new Font(txtSourceCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSourceCode.Font.Style);

            txtTargetCode.Font = new Font(txtTargetCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtTargetCode.Font.Style);

            btnList.Font = new Font(btnList.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnList.Font.Style);

            btnStockTransferList.Font = new Font(btnStockTransferList.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnStockTransferList.Font.Style);

            dtgInventoryTransfer.Font = new Font(dtgInventoryTransfer.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgInventoryTransfer.Font.Style);

            btnTumunuSec.Font = new Font(btnTumunuSec.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTumunuSec.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            dtpStartDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpEndDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            cmbSourceCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbTargetCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtSourceCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtTargetCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            cmbSourceCode.DropDownWidth = cmbSourceCode.Width * 2;
            cmbTargetCode.DropDownWidth = cmbTargetCode.Width * 2;

            txtSearch.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
            dtpStartDate.Value = DateTime.Now.AddDays(-1);
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

        public static bool formAciliyor = false;
        private DataTable dtcmbWarehouseSource = new DataTable();
        private DataTable dtcmbWarehouseTarget = new DataTable();
        private string formName = "";

        private void TalebeBagliDepoNakli_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            dtgInventoryTransfer.RowTemplate.Height = 55;
            dtgInventoryTransfer.ColumnHeadersHeight = 60;

            txtSearch.Focus();

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpBagDepK", Giris.mKodValue);
            }

            Response resp1 = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp1 = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp1 = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpBagDepH", Giris.mKodValue);
            }

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtcmbWarehouseSource = resp._list;
                    dtcmbWarehouseTarget = resp1._list;

                    cmbSourceCode.DataSource = dtcmbWarehouseSource;
                    cmbSourceCode.DisplayMember = "WhsName";
                    cmbSourceCode.ValueMember = "WhsCode";
                    cmbSourceCode.Enabled = true;

                    cmbTargetCode.DataSource = dtcmbWarehouseTarget;
                    cmbTargetCode.DisplayMember = "WhsName";
                    cmbTargetCode.ValueMember = "WhsCode";
                    cmbTargetCode.Enabled = true;
                }
            }

            formAciliyor = true;
            btnList.PerformClick();
            formAciliyor = false;
            vScrollBar1.Maximum = dtgInventoryTransfer.RowCount;
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
            dtgInventoryTransfer.Columns.Add(checkColumn);

            dtgInventoryTransfer.RowHeadersVisible = false;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();
            dtgInventoryTransfer.RowTemplate.Height = 55;
            dtgInventoryTransfer.ColumnHeadersHeight = 60;

            InventoryTransferLists = new List<InventoryTransferList>();
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            var startDate = dtpStartDate.Value.ToString("yyyyMMdd");
            var endDate = dtpEndDate.Value.ToString("yyyyMMdd");
            var fromwhsCode = cmbSourceCode.SelectedValue.ToString();
            var towhsCode = cmbTargetCode.SelectedValue.ToString();

            Response resp = null;

            Response respDepo = null;

            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetInventoryTransferRequest(Giris._dbName, startDate, endDate, fromwhsCode, towhsCode, Giris.whsCodes.ToArray(), Giris._userCode, Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                List<string> whsCodes2 = new List<string>();
                respDepo = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpBagDepK", Giris.mKodValue);

                if (respDepo != null)
                {
                    if (respDepo.Val == 0)
                    {
                        foreach (DataRow item in respDepo._list.Rows)
                        {
                            if (item["WhsCode"].ToString() != "")
                            {
                                whsCodes2.Add("K-" + item["WhsCode"].ToString());
                            }
                        }
                    }
                }

                respDepo = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpBagDepH", Giris.mKodValue);

                if (respDepo != null)
                {
                    if (respDepo.Val == 0)
                    {
                        foreach (DataRow item in respDepo._list.Rows)
                        {
                            if (item["WhsCode"].ToString() != "")
                            {
                                whsCodes2.Add("H-" + item["WhsCode"].ToString());
                            }
                        }
                    }
                }

                resp = aIFTerminalServiceSoapClient.GetInventoryTransferRequest(Giris._dbName, startDate, endDate, fromwhsCode, towhsCode, whsCodes2.ToArray(), Giris._userCode, Giris.mKodValue);
            }

            if (resp._list != null)
            {
                dtInventoryTransfer = resp._list;
                dtgInventoryTransfer.DataSource = null;
                dtgInventoryTransfer.DataSource = resp._list;

                if (dtgInventoryTransfer.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }

                dtgInventoryTransfer.Columns["ScmCheck"].DisplayIndex = dtgInventoryTransfer.Columns.Count - 1;

                dtgInventoryTransfer.Columns["MuhatapKodu"].Visible = false;
                dtgInventoryTransfer.Columns["MuhatapAdi"].Visible = false;
                dtgInventoryTransfer.Columns["BelgeTarihi"].Visible = false;//belge tarihi onat bey in isteği ile transfer tarihi olarak değiştirildi

                dtgInventoryTransfer.Columns["BelgeNumarasi"].HeaderText = "TALEP";
                dtgInventoryTransfer.Columns["MuhatapKodu"].HeaderText = "MUHATAP KODU";
                dtgInventoryTransfer.Columns["MuhatapAdi"].HeaderText = "MUHATAP ADI";
                dtgInventoryTransfer.Columns["TransferTarihi"].HeaderText = "TALEP TAR";
                dtgInventoryTransfer.Columns["BelgeTarihi"].HeaderText = "BEL.TAR";
                dtgInventoryTransfer.Columns["KaynakDepo"].HeaderText = "KAYNAK";
                dtgInventoryTransfer.Columns["HedefDepo"].HeaderText = "HEDEF";
                dtgInventoryTransfer.Columns["ScmCheck"].HeaderText = "SEÇ";
                dtgInventoryTransfer.Columns["BelgeDurumu"].HeaderText = "DURUM";

                dtgInventoryTransfer.Columns["BelgeNumarasi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInventoryTransfer.Columns["TransferTarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInventoryTransfer.Columns["BelgeTarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInventoryTransfer.Columns["KaynakDepo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgInventoryTransfer.Columns["HedefDepo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                //dtgInventoryTransfer.Columns["BelgeDurumu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInventoryTransfer.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtgInventoryTransfer.Columns["BelgeNumarasi"].DisplayIndex = 0;
                dtgInventoryTransfer.Columns["BelgeTarihi"].DisplayIndex = 1;
                dtgInventoryTransfer.Columns["TransferTarihi"].DisplayIndex = 2;
                dtgInventoryTransfer.Columns["KaynakDepo"].DisplayIndex = 3;
                dtgInventoryTransfer.Columns["HedefDepo"].DisplayIndex = 4;
                dtgInventoryTransfer.Columns["BelgeDurumu"].DisplayIndex = 5;
                dtgInventoryTransfer.Columns["ScmCheck"].DisplayIndex = 6;

                //dtgInventoryTransfer.Columns["MuhatapAdi"].Width = dtgInventoryTransfer.Width - dtgInventoryTransfer.Columns["BelgeNumarasi"].Width - dtgInventoryTransfer.Columns["TransferTarihi"].Width - dtgInventoryTransfer.Columns["BelgeTarihi"].Width - dtgInventoryTransfer.Columns["ScmCheck"].Width;
            }
            else
            {
                dtgInventoryTransfer.DataSource = null;
                if (!formAciliyor)
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                }

                if (dtgInventoryTransfer.Columns.Contains("ScmCheck") == true)
                {
                    dtgInventoryTransfer.Columns.RemoveAt(0);
                }
            }
            dtgInventoryTransfer.EnableHeadersVisualStyles = false;
            dtgInventoryTransfer.RowTemplate.Height = 55;
            dtgInventoryTransfer.ColumnHeadersHeight = 60;
            vScrollBar1.Maximum = dtgInventoryTransfer.RowCount + 2;

            //dtgInventoryTransfer.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgInventoryTransfer.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgInventoryTransfer.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgInventoryTransfer.Rows.Count > 0)
            {
                dtgInventoryTransfer.Rows[0].Selected = false;
            }
        }

        private List<InventoryTransferList> InventoryTransferLists = new List<InventoryTransferList>();
        private DataTable dtInventoryTransfer = new DataTable();

        private void dtgInventoryTransfer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtgInventoryTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dtgInventoryTransfer.Rows[e.RowIndex];
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
            if (chk.Value == chk.FalseValue || chk.Value == null)
            {
                DateTime dtDocDate = DateTime.ParseExact(row.Cells["BelgeTarihi"].Value.ToString(), "dd/MM/yyyy", null);
                DateTime dtDocDueDate = DateTime.ParseExact(row.Cells["TransferTarihi"].Value.ToString(), "dd/MM/yyyy", null);
                if (InventoryTransferLists.Count == 0)
                {
                    InventoryTransferLists.Add(new InventoryTransferList
                    {
                        CardCode = row.Cells["MuhatapKodu"].Value.ToString(),
                        CardName = row.Cells["MuhatapAdi"].Value.ToString(),
                        DocDate = dtDocDate.ToString("yyyyMMdd"),
                        DocDueDate = dtDocDueDate.ToString("yyyyMMdd"),
                        DocEntry = Convert.ToInt32(row.Cells["BelgeNumarasi"].Value),
                        fromwhscode = row.Cells["KaynakDepo"].Value.ToString(),
                        towhscode = row.Cells["HedefDepo"].Value.ToString()
                    });
                }
                else
                {
                    string vendor = dtInventoryTransfer.Rows[e.RowIndex]["MuhatapKodu"].ToString();

                    if (vendor != InventoryTransferLists[0].CardCode)
                    {
                        CustomMsgBox.Show("BİRDEN FAZLA MUHATABA AİT SEÇİM YAPILAMAZ", "Uyarı", "Tamam", "");
                        return;
                    }
                    else
                    {
                        InventoryTransferLists.Add(new InventoryTransferList
                        {
                            CardCode = row.Cells["MuhatapKodu"].Value.ToString(),
                            CardName = row.Cells["MuhatapAdi"].Value.ToString(),
                            DocDate = dtDocDate.ToString("yyyyMMdd"),
                            DocDueDate = dtDocDueDate.ToString("yyyyMMdd"),
                            DocEntry = Convert.ToInt32(row.Cells["BelgeNumarasi"].Value),
                            fromwhscode = row.Cells["KaynakDepo"].Value.ToString(),
                            towhscode = row.Cells["HedefDepo"].Value.ToString()
                        });
                    }
                }
                chk.Value = chk.TrueValue;
                dtgInventoryTransfer.EndEdit();
                //setFormatGrid(dataGridView1, 15);
            }
            else
            {
                chk.Value = chk.FalseValue;
                InventoryTransferLists.RemoveAt(0);
            }
        }

        public static string dialogresult = "";

        private void btnStockTransferList_Click(object sender, EventArgs e)
        {
            if (InventoryTransferLists.Count > 0)
            {
                TalebeBagliDepoNakli_2.inventoryGenEntryBatches = new List<InventoryGenEntryBatch>();
                TalebeBagliDepoNakli_2 siparisliMalGirisi_2 = new TalebeBagliDepoNakli_2(InventoryTransferLists, btnList, "TALEBE BAĞLI DEPO NAKLİ");
                siparisliMalGirisi_2.ShowDialog();
                siparisliMalGirisi_2.Dispose();
                GC.Collect();
                btnList.PerformClick();
                ////2. ekrandan geri geldiğinde dtg temizleme kaldırıldı
                //dtgInventoryTransfer.DataSource = null;

                //if (dtgInventoryTransfer.Columns.Count > 0)
                //{
                //    dtgInventoryTransfer.Columns.RemoveAt(0);
                //}
                //InventoryTransferLists = new List<InventoryTransferList>();
            }
            else
            {
                CustomMsgBox.Show("STOK NAKLİ TALEBİ SEÇİLMEDEN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
            }
        }

        private void cmbSourceCode_Click(object sender, EventArgs e)
        {
            cmbSourceCode.DroppedDown = true;
        }

        private void cmbTargetCode_Click(object sender, EventArgs e)
        {
            cmbTargetCode.DroppedDown = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var emptyvalues = dtInventoryTransfer.AsEnumerable().Where(x => x.Field<string>("MuhatapAdi") == null && x.Field<string>("MuhatapKodu") == null).ToList();

            foreach (var row in emptyvalues)
            {
                row.SetField("MuhatapKodu", "");
                row.SetField("MuhatapAdi", "");
            }

            var resp = dtInventoryTransfer.AsEnumerable().Where(x => x.Field<string>("MuhatapAdi") != null && x.Field<string>("MuhatapKodu") != null).ToList();

            if (resp != null)
            {
                var resp1 = resp.Where(x => x.Field<string>("MuhatapAdi").Contains(txtSearch.Text.ToUpper()) || x.Field<string>("MuhatapKodu").Contains(txtSearch.Text.ToUpper())).ToList();

                int parsedValue;
                if (int.TryParse(txtSearch.Text, out parsedValue))
                {
                    var resp2 = dtInventoryTransfer.AsEnumerable().Where(x => x.Field<int>("BelgeNumarasi") == Convert.ToInt32(txtSearch.Text)).ToList();

                    if (resp2.Count > 0)
                    {
                        foreach (var item in resp2)
                        {
                            var belgenovarmi = resp.Where(x => x.Field<int>("BelgeNumarasi") == item.Field<int>("BelgeNumarasi")).ToList();

                            if (belgenovarmi.Count == 0)
                            {
                                resp.AddRange(resp2);
                            }
                        }
                    }
                }
                else
                    resp = resp1;
            }

            if (resp.Count > 0)
            {
                DataTable dts = resp.CopyToDataTable();

                dtgInventoryTransfer.DataSource = dts;

                if (dtgInventoryTransfer.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }

                dtgInventoryTransfer.Columns["ScmCheck"].DisplayIndex = dtgInventoryTransfer.Columns.Count - 1;

                dtgInventoryTransfer.Columns["MuhatapKodu"].Visible = false;
                dtgInventoryTransfer.Columns["MuhatapAdi"].Visible = false;

                dtgInventoryTransfer.Columns["BelgeNumarasi"].HeaderText = "TALEP";
                dtgInventoryTransfer.Columns["MuhatapKodu"].HeaderText = "MUHATAP KODU";
                dtgInventoryTransfer.Columns["MuhatapAdi"].HeaderText = "MUHATAP ADI";
                dtgInventoryTransfer.Columns["TransferTarihi"].HeaderText = "TRANS.TAR";
                dtgInventoryTransfer.Columns["BelgeTarihi"].HeaderText = "BEL.TAR";
                dtgInventoryTransfer.Columns["KaynakDepo"].HeaderText = "KAYNAK";
                dtgInventoryTransfer.Columns["HedefDepo"].HeaderText = "HEDEF";
                dtgInventoryTransfer.Columns["ScmCheck"].HeaderText = "SEÇ";
                dtgInventoryTransfer.Columns["BelgeDurumu"].HeaderText = "DURUM";

                dtgInventoryTransfer.Columns["BelgeNumarasi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInventoryTransfer.Columns["TransferTarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInventoryTransfer.Columns["BelgeTarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInventoryTransfer.Columns["KaynakDepo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgInventoryTransfer.Columns["HedefDepo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                //dtgInventoryTransfer.Columns["BelgeDurumu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInventoryTransfer.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtgInventoryTransfer.Columns["BelgeNumarasi"].DisplayIndex = 0;
                dtgInventoryTransfer.Columns["BelgeTarihi"].DisplayIndex = 1;
                dtgInventoryTransfer.Columns["TransferTarihi"].DisplayIndex = 2;
                dtgInventoryTransfer.Columns["KaynakDepo"].DisplayIndex = 3;
                dtgInventoryTransfer.Columns["HedefDepo"].DisplayIndex = 4;
                dtgInventoryTransfer.Columns["BelgeDurumu"].DisplayIndex = 5;
                dtgInventoryTransfer.Columns["ScmCheck"].DisplayIndex = 6;

                //dtgInventoryTransfer.AutoResizeRows();
            }
            else
            {
                if (txtSearch.Text == "")
                {
                    dtgInventoryTransfer.DataSource = dtInventoryTransfer;

                    if (dtInventoryTransfer.Rows.Count == 0)
                    {
                        dtgInventoryTransfer.DataSource = null;
                        return;
                    }

                    if (dtgInventoryTransfer.Columns.Contains("ScmCheck") != true)
                    {
                        Checkboxolustur();
                    }
                    dtgInventoryTransfer.Columns["ScmCheck"].DisplayIndex = dtgInventoryTransfer.Columns.Count - 1;

                    dtgInventoryTransfer.Columns["MuhatapKodu"].Visible = false;
                    dtgInventoryTransfer.Columns["MuhatapAdi"].Visible = false;

                    dtgInventoryTransfer.Columns["BelgeNumarasi"].HeaderText = "TALEP";
                    dtgInventoryTransfer.Columns["MuhatapKodu"].HeaderText = "MUHATAP KODU";
                    dtgInventoryTransfer.Columns["MuhatapAdi"].HeaderText = "MUHATAP ADI";
                    dtgInventoryTransfer.Columns["TransferTarihi"].HeaderText = "TRANS.TAR";
                    dtgInventoryTransfer.Columns["BelgeTarihi"].HeaderText = "BEL.TAR";
                    dtgInventoryTransfer.Columns["KaynakDepo"].HeaderText = "KAYNAK";
                    dtgInventoryTransfer.Columns["HedefDepo"].HeaderText = "HEDEF";
                    dtgInventoryTransfer.Columns["ScmCheck"].HeaderText = "SEÇ";
                    dtgInventoryTransfer.Columns["BelgeDurumu"].HeaderText = "DURUM";

                    dtgInventoryTransfer.Columns["BelgeNumarasi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgInventoryTransfer.Columns["TransferTarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgInventoryTransfer.Columns["BelgeTarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgInventoryTransfer.Columns["KaynakDepo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    dtgInventoryTransfer.Columns["HedefDepo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    //dtgInventoryTransfer.Columns["BelgeDurumu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgInventoryTransfer.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dtgInventoryTransfer.Columns["BelgeNumarasi"].DisplayIndex = 0;
                    dtgInventoryTransfer.Columns["BelgeTarihi"].DisplayIndex = 1;
                    dtgInventoryTransfer.Columns["TransferTarihi"].DisplayIndex = 2;
                    dtgInventoryTransfer.Columns["KaynakDepo"].DisplayIndex = 3;
                    dtgInventoryTransfer.Columns["HedefDepo"].DisplayIndex = 4;
                    dtgInventoryTransfer.Columns["BelgeDurumu"].DisplayIndex = 5;
                    dtgInventoryTransfer.Columns["ScmCheck"].DisplayIndex = 6;
                }
                else
                {
                    dtgInventoryTransfer.DataSource = null;
                    if (dtgInventoryTransfer.Columns.Contains("ScmCheck") == true)
                    {
                        dtgInventoryTransfer.Columns.RemoveAt(0);
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void cmbSourceCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSourceCode.SelectedIndex > 0)
            {
                string code = cmbSourceCode.SelectedValue.ToString();
                txtSourceCode.Text = code;
                txtSearch.Focus();
            }
            else
            {
                //cmbSuppLierName.DroppedDown = true;
                txtSourceCode.Text = "";
            }
        }

        private void cmbTargetCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTargetCode.SelectedIndex > 0)
            {
                string code = cmbTargetCode.SelectedValue.ToString();
                txtTargetCode.Text = code;
                txtSearch.Focus();
            }
            else
            {
                //cmbSuppLierName.DroppedDown = true;
                txtTargetCode.Text = "";
            }
        }

        private void dtgInventoryTransfer_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                vScrollBar1.Value = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgInventoryTransfer.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void cmbSourceCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbSourceCode.Text != "" && cmbTargetCode.Text != "")
            {
                if (cmbSourceCode.SelectedValue.ToString() == cmbTargetCode.SelectedValue.ToString())
                {
                    CustomMsgBox.Show("KAYNAK DEPO, HEDEF DEPO İLE AYNI OLAMAZ.", "Uyarı", "TAMAM", "");
                    cmbSourceCode.Text = "";
                    return;
                }
            }
        }

        private void cmbTargetCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbSourceCode.Text != "" && cmbTargetCode.Text != "")
            {
                if (cmbSourceCode.SelectedValue.ToString() == cmbTargetCode.SelectedValue.ToString())
                {
                    CustomMsgBox.Show("HEDEF DEPO, KAYNAK DEPO İLE AYNI OLAMAZ.", "Uyarı", "TAMAM", "");
                    cmbTargetCode.Text = "";
                    return;
                }
            }
        }

        private void btnTumunuSec_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rows in dtgInventoryTransfer.Rows)
            {
                //DataGridViewRow row = dtgInventoryTransfer.Rows[rows.Index];
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)rows.Cells["ScmCheck"];
                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    DateTime dtDocDate = DateTime.ParseExact(rows.Cells["BelgeTarihi"].Value.ToString(), "dd/MM/yyyy", null);
                    DateTime dtDocDueDate = DateTime.ParseExact(rows.Cells["TransferTarihi"].Value.ToString(), "dd/MM/yyyy", null);
                    if (InventoryTransferLists.Count == 0)
                    {
                        InventoryTransferLists.Add(new InventoryTransferList
                        {
                            CardCode = rows.Cells["MuhatapKodu"].Value.ToString(),
                            CardName = rows.Cells["MuhatapAdi"].Value.ToString(),
                            DocDate = dtDocDate.ToString("yyyyMMdd"),
                            DocDueDate = dtDocDueDate.ToString("yyyyMMdd"),
                            DocEntry = Convert.ToInt32(rows.Cells["BelgeNumarasi"].Value)
                        });
                    }
                    else
                    {
                        string vendor = dtInventoryTransfer.Rows[rows.Index]["MuhatapKodu"].ToString();

                        if (vendor != InventoryTransferLists[0].CardCode)
                        {
                            CustomMsgBox.Show("BİRDEN FAZLA MUHATABA AİT SEÇİM YAPILAMAZ", "Uyarı", "Tamam", "");
                            return;
                        }
                        else
                        {
                            InventoryTransferLists.Add(new InventoryTransferList
                            {
                                CardCode = rows.Cells["MuhatapKodu"].Value.ToString(),
                                CardName = rows.Cells["MuhatapAdi"].Value.ToString(),
                                DocDate = dtDocDate.ToString("yyyyMMdd"),
                                DocDueDate = dtDocDueDate.ToString("yyyyMMdd"),
                                DocEntry = Convert.ToInt32(rows.Cells["BelgeNumarasi"].Value)
                            });
                        }
                    }
                    chk.Value = chk.TrueValue;
                    dtgInventoryTransfer.EndEdit();
                    //setFormatGrid(dataGridView1, 15);
                }
                else
                {
                    chk.Value = chk.FalseValue;
                    InventoryTransferLists.RemoveAt(0);
                }
            }
        }
    }
}