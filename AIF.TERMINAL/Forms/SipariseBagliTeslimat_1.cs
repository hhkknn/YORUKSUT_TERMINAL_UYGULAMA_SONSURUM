using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class SipariseBagliTeslimat_1 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public SipariseBagliTeslimat_1(string _formName)
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

            initialFontSize = btnList.Font.Size;
            btnList.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = dtgOrders.Font.Size;
            dtgOrders.Resize += Form_Resize;
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

            btnList.Font = new Font(btnList.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnList.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button2.Font.Style);

            dtgOrders.Font = new Font(dtgOrders.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgOrders.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            dtpStartDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpEndDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtSearch.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
        }

        //declares
        [DllImport("user32.dll")]
        private static extern bool PostMessage(
        IntPtr hWnd, // handle to destination window
        Int32 msg, // message
        Int32 wParam, // first message parameter
        Int32 lParam // second message parameter
        );

        private const Int32 WM_LBUTTONDOWN = 0x0201;

        //
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
        private string formName = "";

        private void SipariseBagliTeslimat_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName.ToUpper();

            dtpStartDate.Value = DateTime.Now.AddDays(-7);

            txtSearch.Focus();
            dtgOrders.RowTemplate.Height = 55;
            dtgOrders.ColumnHeadersHeight = 60;

            formAciliyor = true;
            btnList.PerformClick();
            formAciliyor = false;
            vScrollBar1.Maximum = dtgOrders.RowCount;
        }

        public static string dialogresult = "";

        private void button2_Click(object sender, EventArgs e)
        {
            if (OrderLists.Count > 0)
            {
                //string depo = dtgOrders.Rows[0].ToString();

                //if (depo != null)
                //{
                //    CustomMsgBox.Show("depo miktarı yok","uyarı","tamam","");
                //    //return;
                //}
                SipariseBagliTeslimat_2 sipariseBagliTeslimat_2 = new SipariseBagliTeslimat_2(OrderLists, btnList, "SİPARİŞE BAĞLI TESLİMAT");
                sipariseBagliTeslimat_2.ShowDialog();
                sipariseBagliTeslimat_2.Dispose();
                GC.Collect();
                txtSearch.Text = "";
                btnList.PerformClick();

                #region scrollbar aşağıda kalıyor- tekrar bakılacak

                //vScrollBar1.Location = new Point(
                //           0 + tableLayoutPanel1.AutoScrollPosition.X,
                //           0 + tableLayoutPanel1.AutoScrollPosition.Y);
                //tableLayoutPanel1.Controls.Add(vScrollBar1);

                #endregion scrollbar aşağıda kalıyor- tekrar bakılacak
            }
            else
            {
                CustomMsgBox.Show("SATIŞ SİPARİŞİ SEÇİLMEDEN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
            }
        }

        private DataTable dtOrders = new DataTable();

        private void btnList_Click(object sender, EventArgs e)
        {
            OrderLists = new List<OrderList>();

            string startDate = dtpStartDate.Value.ToString("yyyyMMdd");
            string endDate = dtpEndDate.Value.ToString("yyyyMMdd");

            List<string> wHsCodes = new List<string>();
            //wHsCodes.Add("800");
            //wHsCodes.Add("202");
            //wHsCodes.Add("203");

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;
            Response respDepo = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetOrdersByDate(Giris._dbName, startDate, endDate, Giris.whsCodes.ToArray(), Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                respDepo = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_SipBagTes", Giris.mKodValue);

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

                    resp = aIFTerminalServiceSoapClient.GetOrdersByDate(Giris._dbName, startDate, endDate, whsCodes2.ToArray(), Giris.mKodValue);
                }
            }

            if (resp._list != null)
            {
                //dtgOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtOrders = resp._list;
                dtgOrders.DataSource = null;

                if (dtgOrders.Columns.Count > 0)
                {
                    dtgOrders.Columns.RemoveAt(0);
                }
                dtgOrders.DataSource = dtOrders;
                //dtgOrders.AutoResizeColumns();
                //dtgOrders.AutoResizeRows();

                if (dtgOrders.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }

                dtgOrders.RowTemplate.Height = 55;
                dtgOrders.ColumnHeadersHeight = 60;

                dtgOrders.Columns["Belge Numarası"].HeaderText = "SİP.NO";
                dtgOrders.Columns["Müşteri Kodu"].HeaderText = "MÜŞTERİ KODU";
                dtgOrders.Columns["Müşteri Adı"].HeaderText = "MÜŞTERİ ADI";
                dtgOrders.Columns["Belge Tarihi"].HeaderText = "BEL.TAR";
                dtgOrders.Columns["Teslimat Tarihi"].HeaderText = "TESLİMAT";
                dtgOrders.Columns["Sevkiyat Adresi"].HeaderText = "SEVK";
                dtgOrders.Columns["ScmCheck"].HeaderText = "SEÇ";

                dtgOrders.Columns["Müşteri Kodu"].Visible = false;
                dtgOrders.Columns["Belge Tarihi"].Visible = false;

                dtgOrders.Columns["Belge Numarası"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgOrders.Columns["Müşteri Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgOrders.Columns["Belge Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgOrders.Columns["Teslimat Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgOrders.Columns["Sevkiyat Adresi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgOrders.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //2.ekrandan dönüşte hata verdiğinden kapatıldı.
                //dtgOrders.Columns["Müşteri Adı"].Width = dtgOrders.Width - dtgOrders.Columns["Belge Numarası"].Width - dtgOrders.Columns["Müşteri Kodu"].Width- dtgOrders.Columns["Belge Tarihi"].Width -dtgOrders.Columns["Teslimat Tarihi"].Width - dtgOrders.Columns["Sevkiyat Adresi"].Width - dtgOrders.Columns["ScmCheck"].Width;

                vScrollBar1.Maximum = dtgOrders.RowCount;
            }
            else
            {
                dtgOrders.DataSource = null;
                if (!formAciliyor)
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                    return;
                }
                if (dtgOrders.Columns.Count > 0)
                {
                    dtgOrders.Columns.RemoveAt(0);
                }
                formAciliyor = false;
            }

            //dtgOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgOrders.AutoResizeRows();
            txtSearch.Focus();

            foreach (DataGridViewColumn column in dtgOrders.Columns) //columns tıklama
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgOrders.Rows.Count > 0)
            {
                dtgOrders.Rows[0].Selected = false;
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
            dtgOrders.Columns.Add(checkColumn);

            dtgOrders.RowHeadersVisible = false;
        }

        private List<OrderList> OrderLists = new List<OrderList>();

        private void dtgOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow row = dtgOrders.Rows[e.RowIndex];
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
            if (chk.Value == chk.FalseValue || chk.Value == null)
            {
                DateTime dtTaxDate = DateTime.ParseExact(row.Cells["Teslimat Tarihi"].Value.ToString(), "dd/MM/yyyy", null);
                DateTime dtDocDueDate = DateTime.ParseExact(row.Cells["Belge Tarihi"].Value.ToString(), "dd/MM/yyyy", null);
                if (OrderLists.Count == 0)
                {
                    OrderLists.Add(new OrderList
                    {
                        CardCode = row.Cells["Müşteri Kodu"].Value.ToString(),
                        CardName = row.Cells["Müşteri Adı"].Value.ToString(),
                        TaxDate = dtTaxDate.ToString("yyyyMMdd"),
                        DocDueDate = dtDocDueDate.ToString("yyyyMMdd"),
                        DocEntry = Convert.ToInt32(row.Cells["Belge Numarası"].Value),
                        Address = row.Cells["Sevkiyat Adresi"].Value.ToString()
                    });
                }
                else
                {
                    //string CardCode = dtOrders.Rows[e.RowIndex]["Müşteri Kodu"].ToString();
                    string CardCode = row.Cells["Müşteri Kodu"].Value.ToString();

                    if (CardCode != OrderLists[0].CardCode)
                    {
                        CustomMsgBox.Show("BİRDEN FAZLA MÜŞTERİYE AİT SEÇİM YAPILAMAZ.", "Uyarı", "Tamam", "");
                        return;
                    }
                    else
                    {
                        OrderLists.Add(new OrderList
                        {
                            CardCode = row.Cells["Müşteri Kodu"].Value.ToString(),
                            CardName = row.Cells["Müşteri Adı"].Value.ToString(),
                            TaxDate = dtTaxDate.ToString("yyyyMMdd"),
                            DocDueDate = dtDocDueDate.ToString("yyyyMMdd"),
                            DocEntry = Convert.ToInt32(row.Cells["Belge Numarası"].Value),
                            Address = row.Cells["Sevkiyat Adresi"].Value.ToString()
                        });
                    }
                }
                chk.Value = chk.TrueValue;
                dtgOrders.EndEdit();
                //setFormatGrid(dataGridView1, 15);
            }
            else
            {
                chk.Value = chk.FalseValue;
                OrderLists.RemoveAt(0);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearch.Text != "")
            //{
            //    if (dtgOrders.DataSource == null)
            //    {
            //        CustomMsgBox.Show("LİSTELEME YAPILMADAN ARAMA YAPILAMAZ.", "Uyarı", "Tamam", "");
            //        //txtSearch.Text = "";
            //        return;
            //}
            //}
            //else if (txtSearch.Text == "")
            //{
            //    btnList.PerformClick();
            //    return;
            //}

            var liste = dtOrders.AsEnumerable().ToString();

            var resp = dtOrders.AsEnumerable().Where(x => x.Field<string>("Müşteri Adı").Contains(txtSearch.Text.ToUpper()) || x.Field<string>("Müşteri Kodu").Contains(txtSearch.Text.ToUpper())).ToList();
            //var resp1 = dtOrders.AsEnumerable().Where(x => x.Field<string>("Belge Numarası").Contains(txtSearch.Text.ToUpper())).ToList();

            int parsedValue;
            if (int.TryParse(txtSearch.Text, out parsedValue))
            {
                var resp2 = dtOrders.AsEnumerable().Where(x => x.Field<int>("Belge Numarası") == Convert.ToInt32(txtSearch.Text)).ToList();

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

                dtgOrders.DataSource = dts;

                if (dtgOrders.Columns.Contains("ScmCheck") != true)
                {
                    Checkboxolustur();
                }

                dtgOrders.RowTemplate.Height = 55;
                dtgOrders.ColumnHeadersHeight = 60;

                dtgOrders.Columns["Belge Numarası"].HeaderText = "SİP.NO";
                dtgOrders.Columns["Müşteri Kodu"].HeaderText = "MÜŞTERİ KODU";
                dtgOrders.Columns["Müşteri Adı"].HeaderText = "MÜŞTERİ ADI";
                dtgOrders.Columns["Belge Tarihi"].HeaderText = "BEL.TAR";
                dtgOrders.Columns["Teslimat Tarihi"].HeaderText = "TESLİMAT";
                dtgOrders.Columns["Sevkiyat Adresi"].HeaderText = "SEVK";
                dtgOrders.Columns["ScmCheck"].HeaderText = "SEÇ";

                dtgOrders.Columns["Müşteri Kodu"].Visible = false;
                dtgOrders.Columns["Belge Tarihi"].Visible = false;

                dtgOrders.Columns["Belge Numarası"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgOrders.Columns["Müşteri Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgOrders.Columns["Belge Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgOrders.Columns["Teslimat Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgOrders.Columns["Sevkiyat Adresi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgOrders.Columns["ScmCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                #region arama yapılırken seçim checkbox ı kaybolma durumu

                if (OrderLists.Count > 0)
                {
                    foreach (var item in OrderLists)
                    {
                        string doc = item.DocEntry.ToString();

                        foreach (DataGridViewRow row in dtgOrders.Rows)
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
                dtgOrders.DataSource = null;

                if (dtgOrders.Columns.Contains("ScmCheck") == true)
                {
                    dtgOrders.Columns.RemoveAt(0);
                }
            }

            vScrollBar1.Maximum = dtgOrders.RowCount;

            foreach (DataGridViewColumn column in dtgOrders.Columns) //columns tıklama
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgOrders.Rows.Count > 0)
            {
                dtgOrders.Rows[0].Selected = false;
            }
        }

        private void dtpStartDate_Enter(object sender, EventArgs e)
        {
        }

        private void dtpStartDate_MouseEnter(object sender, EventArgs e)
        {
        }

        private void dtpStartDate_DropDown(object sender, EventArgs e)
        {
            //Int32 x = dtpStartDate.Width - 10;
            //Int32 y = dtpStartDate.Height / 2;
            //Int32 lParam = x + y * 0x00010000;

            //PostMessage(dtpStartDate.Handle, WM_LBUTTONDOWN, 1, lParam);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void dtgOrders_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgOrders.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }
    }
}