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
    public partial class TalebeBagliDepoNakli_2 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //end font

        private Button buttonListele = new Button();

        public TalebeBagliDepoNakli_2(List<InventoryTransferList> _inventoryTransferLists, Button _buttonListele, string _formName)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            //initialFontSize = label3.Font.Size;
            //label3.Resize += Form_Resize;

            //initialFontSize = label4.Font.Size;
            //label4.Resize += Form_Resize;

            //initialFontSize = label5.Font.Size;
            //label5.Resize += Form_Resize;

            //initialFontSize = label7.Font.Size;
            //label7.Resize += Form_Resize;

            //initialFontSize = label8.Font.Size;
            //label8.Resize += Form_Resize;

            //initialFontSize = frmName.Font.Size;
            //frmName.Resize += Form_Resize;

            //initialFontSize = txtVendorCode.Font.Size;
            //txtVendorCode.Resize += Form_Resize;

            //initialFontSize = txtVendorName.Font.Size;
            //txtVendorName.Resize += Form_Resize;

            //initialFontSize = dtpDocDate.Font.Size;
            //dtpDocDate.Resize += Form_Resize;

            //initialFontSize = dtpTransferDate.Font.Size;
            //dtpTransferDate.Resize += Form_Resize;

            //initialFontSize = txtBarCode.Font.Size;
            //txtBarCode.Resize += Form_Resize;

            //initialFontSize = btnDetails.Font.Size;
            //btnDetails.Resize += Form_Resize;

            //initialFontSize = btnAddOrUpdate.Font.Size;
            //btnAddOrUpdate.Resize += Form_Resize;

            //initialFontSize = dtgDetails.Font.Size;
            //dtgDetails.Resize += Form_Resize;
            //end font
            formName = _formName;
            inventoryTransferLists = _inventoryTransferLists;

            if (inventoryTransferLists != null)
            {
                txtVendorCode.Text = inventoryTransferLists[0].CardCode;
                txtVendorName.Text = inventoryTransferLists[0].CardName;

                var max = inventoryTransferLists.OrderByDescending(t => t.DocDueDate)
                   .FirstOrDefault();

                dtpDocDate.Value = new DateTime(Convert.ToInt32(max.DocDueDate.Substring(0, 4)), Convert.ToInt32(max.DocDueDate.Substring(4, 2)), Convert.ToInt32(max.DocDueDate.Substring(6, 2)));//belge tarihi(docdate), onat beyin isteği ile transfer tarihi(docduedate) yapıldı

                //dtpTransferDate.Value = new DateTime(Convert.ToInt32(max.DocDueDate.Substring(0, 4)), Convert.ToInt32(max.DocDueDate.Substring(4, 2)), Convert.ToInt32(max.DocDueDate.Substring(6, 2))); //kapatıldı
                dtpTransferDate.Value = DateTime.Now; //new

                foreach (var item in inventoryTransferLists)
                {
                    docEntryList.Add(item.DocEntry.ToString());
                }
                formYukleniyor = true;
                GetInventoryTransferRequestDetails(docEntryList);
            }

            buttonListele = _buttonListele;
        }

        private List<string> docEntryList = new List<string>();

        private List<InventoryTransferList> inventoryTransferLists = new List<InventoryTransferList>();

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

            label7.Font = new Font(label7.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label7.Font.Style);

            label8.Font = new Font(label8.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label8.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtVendorCode.Font = new Font(txtVendorCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtVendorCode.Font.Style);

            txtVendorName.Font = new Font(txtVendorName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtVendorName.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbItemName.Font.Style);

            dtpDocDate.Font = new Font(dtpDocDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpDocDate.Font.Style);

            dtpTransferDate.Font = new Font(dtpTransferDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpTransferDate.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            btnDetails.Font = new Font(btnDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDetails.Font.Style);

            btnItemSearch.Font = new Font(btnItemSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnItemSearch.Font.Style);

            btnAddOrUpdate.Font = new Font(btnAddOrUpdate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAddOrUpdate.Font.Style);

            btnBarkodGoster.Font = new Font(btnBarkodGoster.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBarkodGoster.Font.Style);

            dtgDetails.Font = new Font(dtgDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgDetails.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtVendorCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtVendorName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            dtpDocDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpTransferDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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
        private Color defaultColor = Color.White;
        private bool formYukleniyor = false;
        private bool miktarGiriliyor = false;

        private void TalebeBagliDepoNakli_2_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            defaultColor = dtgDetails.Rows[0].Cells[0].Style.BackColor;
            //cmbItemName.DropDownStyle = ComboBoxStyle.DropDown;

            txtBarCode.Focus();

            dtgDetails.RowTemplate.Height = 100;
            dtgDetails.ColumnHeadersHeight = 50;

            dtgDetails.Columns["KalemKodu"].Visible = false;
            dtgDetails.Columns["BelgeNumarasi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtgDetails.Columns["KalemKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["OlcuBirimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["ToplananMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["DepoMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["HedefDepo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["OnaydaBekleyenMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["KalemKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            //dtgDetails.Columns["KalemAdi"].Width = dtgDetails.Width - dtgDetails.Columns["BelgeNumarasi"].Width - dtgDetails.Columns["OlcuBirimi"].Width - dtgDetails.Columns["Miktar"].Width - dtgDetails.Columns["ToplananMiktar"].Width - dtgDetails.Columns["DepoMiktar"].Width;

            dtgDetails.Columns["btnDetail"].Visible = false;
            vScrollBar1.Maximum = dtgDetails.RowCount + 10;

            if (dtgDetails.Rows.Count > 0)
            {
                dtgDetails.Rows[0].Selected = false;
            }

            if (Giris.mKodValue == "30TRMN")
            {
                dtgDetails.Columns["OlcuBirimi"].Visible = false;
                dtgDetails.Columns["KalemKodu"].Visible = true;
                //dtgDetails.Columns["OnaydaBekleyenMiktar"].Visible = false;
                dtgDetails.Columns["HedefDepo"].Visible = false;
                dtgDetails.Columns["HedefDepoAdi"].Visible = false;
                dtgDetails.Columns["HDepoYeriId"].Visible = false;
                dtgDetails.Columns["DepoMiktar"].Visible = false;
                dtgDetails.Columns["HDepoYeriAdi"].Visible = true;
                dtgDetails.Columns["DepoYeriAdi"].Visible = true;
            }
            else if (Giris.mKodValue == "10TRMN" || Giris.mKodValue == "20TRMN")
            {
                dtgDetails.Columns["OlcuBirimi"].Visible = false;
                dtgDetails.Columns["KalemKodu"].Visible = true;
                //dtgDetails.Columns["OnaydaBekleyenMiktar"].Visible = false;
                dtgDetails.Columns["HedefDepo"].Visible = true;
                dtgDetails.Columns["HedefDepoAdi"].Visible = false;
                dtgDetails.Columns["HDepoYeriId"].Visible = false;
                dtgDetails.Columns["DepoMiktar"].Visible = false;
                dtgDetails.Columns["HDepoYeriAdi"].Visible = false;
                dtgDetails.Columns["DepoYeriAdi"].Visible = false;
            }
            ////grid scrollbar
            //for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
            //{
            //    var rowYukseklik = dtgDetails.RowTemplate.Height;
            //    //dtgDetails.Rows[i].Height = scrollVal;
            //}
            ////grid scrollbar
            ///
            formYukleniyor = false;
        }

        private DataTable dtDetails = new DataTable();

        private void GetInventoryTransferRequestDetails(List<string> docentryList)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;
            Response respDepo = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetInventoryTransferRequestDetails(Giris._dbName, docentryList.ToArray(), Giris.whsCodes.ToArray(), Giris._userCode, Giris.mKodValue);
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

                resp = aIFTerminalServiceSoapClient.GetInventoryTransferRequestDetails(Giris._dbName, docentryList.ToArray(), whsCodes2.ToArray(), Giris._userCode, Giris.mKodValue);
            }

            if (resp._list != null)
            {
                dtDetails = resp._list;
                dtgDetails.DataSource = null;

                dtDetails.Columns.Add("ToplananMiktar", typeof(double));
                dtDetails.Columns.Add("dtgSira", typeof(int));

                try
                {
                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        //dtDetails.Columns.Add("DepoYeriId", typeof(string));
                        //dtDetails.Columns.Add("DepoYeriAdi", typeof(string));
                        //dtDetails.Columns.Add("HDepoYeriId", typeof(string));
                        //dtDetails.Columns.Add("HDepoYeriAdi", typeof(string));
                    }
                }
                catch (Exception)
                {
                }

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

                btn = new DataGridViewButtonColumn();
                dtgDetails.Columns.Add(btn);
                //dtgDetails.Columns[dtgDetails.ColumnCount - 1].DisplayIndex = dtgDetails.Columnscount-1;
                btn.HeaderText = "";
                btn.Text = "Detay";
                btn.Name = "btnDetail";
                btn.UseColumnTextForButtonValue = true;

                dtgDetails.DataSource = dtDetails;

                dtgDetails.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgDetails.Columns["ToplananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgDetails.Columns["DepoMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgDetails.Columns["OnaydaBekleyenMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                dtgDetails.Columns["BelgeNumarasi"].ReadOnly = true;
                dtgDetails.Columns["KalemKodu"].ReadOnly = true;
                dtgDetails.Columns["KalemAdi"].ReadOnly = true;
                dtgDetails.Columns["Miktar"].ReadOnly = true;
                dtgDetails.Columns["OnaydaBekleyenMiktar"].ReadOnly = true;
                dtgDetails.Columns["ToplananMiktar"].ReadOnly = true;
                dtgDetails.Columns["Barkod"].ReadOnly = true;
                dtgDetails.Columns["Partili"].ReadOnly = true;
                dtgDetails.Columns["OlcuBirimi"].ReadOnly = true;

                dtgDetails.Columns["btnDetail"].DisplayIndex = 0;
                dtgDetails.Columns["BelgeNumarasi"].DisplayIndex = 1;
                dtgDetails.Columns["KalemKodu"].DisplayIndex = 2;
                dtgDetails.Columns["KalemAdi"].DisplayIndex = 3;
                dtgDetails.Columns["OlcuBirimi"].DisplayIndex = 4;
                dtgDetails.Columns["Barkod"].DisplayIndex = 5;
                dtgDetails.Columns["Miktar"].DisplayIndex = 6;
                dtgDetails.Columns["OnaydaBekleyenMiktar"].DisplayIndex = 7;
                dtgDetails.Columns["ToplananMiktar"].DisplayIndex = 8;
                dtgDetails.Columns["Partili"].DisplayIndex = 9;
                //dtgDetails.Columns["DepoKodu"].DisplayIndex = 9;
                dtgDetails.Columns["HedefDepo"].DisplayIndex = 10;
                dtgDetails.Columns["SiraNo"].DisplayIndex = 11;

                dtgDetails.Columns["BelgeNumarasi"].HeaderText = "TLP";
                //dtgDetails.Columns["BelgeNumarasi"].HeaderText = "TALEP";
                dtgDetails.Columns["KalemKodu"].HeaderText = "KALEM KODU";
                dtgDetails.Columns["KalemAdi"].HeaderText = "KALEM ADI";
                dtgDetails.Columns["Barkod"].HeaderText = "BARKOD";
                dtgDetails.Columns["Miktar"].HeaderText = "MİKTAR";
                dtgDetails.Columns["OlcuBirimi"].HeaderText = "BR";
                //dtgDetails.Columns["OlcuBirimi"].HeaderText = "BRM";
                dtgDetails.Columns["ToplananMiktar"].HeaderText = "TOP.MİK";
                dtgDetails.Columns["DepoMiktar"].HeaderText = "STOK";
                dtgDetails.Columns["HedefDepo"].HeaderText = "HDF";
                //dtgDetails.Columns["HedefDepo"].HeaderText = "HEDEF";
                dtgDetails.Columns["OnaydaBekleyenMiktar"].HeaderText = "ONYDA";
                //dtgDetails.Columns["OnaydaBekleyenMiktar"].HeaderText = "ONAYDA";

                if (Giris.mKodValue == "30TRMN")
                {
                    dtgDetails.Columns["Miktar"].HeaderText = "MIK";
                    dtgDetails.Columns["DepoYeriAdi"].HeaderText = "KDEPOYERI";
                    dtgDetails.Columns["HDepoYeriAdi"].HeaderText = "HDEPOYERI";
                }

                dtgDetails.Columns["KalemKodu"].Visible = false;
                dtgDetails.Columns["Partili"].Visible = false;
                dtgDetails.Columns["DepoKodu"].Visible = false;
                dtgDetails.Columns["SiraNo"].Visible = false;
                dtgDetails.Columns["Barkod"].Visible = false;
                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    //dtgDetails.Columns["DepoYeriId"].Visible = false;
                    dtgDetails.Columns["HDepoYeriId"].Visible = false;
                }
                dtgDetails.Columns["Barkod"].Visible = false;

                dtgDetails.Columns["PaletIciKoliAD"].Visible = false;
                dtgDetails.Columns["KoliIciAD"].Visible = false;
                dtgDetails.Columns["PaletIciAD"].Visible = false;
                dtgDetails.Columns["UretimdenGonderildi"].Visible = false;
                dtgDetails.Columns["DepoAdi"].Visible = false;

                dtgDetails.EnableHeadersVisualStyles = false;

                dtgDetails.Columns["ToplananMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDetails.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDetails.Columns["DepoMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDetails.Columns["OnaydaBekleyenMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtgDetails.RowTemplate.Height = 100;
                dtgDetails.ColumnHeadersHeight = 50;
                vScrollBar1.Maximum = dtgDetails.RowCount + 10;

                //dtgDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgDetails.AutoResizeColumns();

                //for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                //{
                //    var partili = dtgDetails.Rows[i].Cells["Partili"].Value;

                //    if (partili.ToString() == "Y")
                //    {
                //        dtgDetails.Rows[i].Cells["Toplanan Miktar"].ReadOnly = true;
                //    }
                //}
                for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++) //chn
                {
                    dtgDetails.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                }
                dtgDetails.Columns["dtgSira"].Visible = false;

                foreach (DataGridViewColumn column in dtgDetails.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (dtgDetails.Rows.Count > 0)
                {
                    dtgDetails.Rows[0].Selected = false;
                }
                else
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                }
            }
        }

        public static int sapLineNum = 0;
        public static int DocEntry = 0;
        private string barcode = "";
        private string itemCode = "";
        private string itemName = "";
        private string kaynakdepo = "";
        private string hedefdepo = "";
        public static string warehouse = "";
        private string partili = "";
        public static List<InventoryGenEntryBatch> inventoryGenEntryBatches = new List<InventoryGenEntryBatch>();
        public static int currentRow = 0;
        private double orderqty = 0;
        private double paletIciKoliAD = 0;
        private double koliIciAD = 0;
        private double paletIciAD = 0;
        private double topMik = 0;
        private double onaybekleyenMik = 0;

        private void dtgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                barcode = dtDetails.Rows[e.RowIndex]["Barkod"].ToString();
                itemCode = dtDetails.Rows[e.RowIndex]["KalemKodu"].ToString();
                itemName = dtDetails.Rows[e.RowIndex]["KalemAdi"].ToString();
                warehouse = dtDetails.Rows[e.RowIndex]["DepoKodu"].ToString();
                kaynakdepo = dtDetails.Rows[e.RowIndex]["DepoKodu"].ToString();
                hedefdepo = dtDetails.Rows[e.RowIndex]["HedefDepo"].ToString();
                orderqty = Convert.ToDouble(dtDetails.Rows[e.RowIndex]["Miktar"]);
                partili = dtDetails.Rows[e.RowIndex]["Partili"].ToString();
                txtBarCode.Text = barcode.ToString() != "" ? barcode.ToString() : itemCode;
                currentRow = e.RowIndex + 1;
                DocEntry = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["BelgeNumarasi"]);
                sapLineNum = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["SiraNo"]);
                paletIciKoliAD = dtDetails.Rows[e.RowIndex]["PaletIciKoliAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["PaletIciKoliAD"]);
                koliIciAD = dtDetails.Rows[e.RowIndex]["KoliIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["KoliIciAD"]);
                paletIciAD = dtDetails.Rows[e.RowIndex]["PaletIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["PaletIciAD"]);

                topMik = dtDetails.Rows[e.RowIndex]["ToplananMiktar"].ToString() == "" ? 0 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["ToplananMiktar"]);

                onaybekleyenMik = dtDetails.Rows[e.RowIndex]["OnaydaBekleyenMiktar"].ToString() == "" ? 0 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["OnaydaBekleyenMiktar"]);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            #region FAZLA MİKTAR GİRİŞİ KONTROLÜ

            double toplananveonaylanan = onaybekleyenMik + topMik;
            if (toplananveonaylanan >= orderqty)
            {
                CustomMsgBox.Show("TOPLAMA İŞLEMİ TAMAMLANDIĞINDAN DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                return;
            }

            #endregion FAZLA MİKTAR GİRİŞİ KONTROLÜ

            if (partili != "Y")
            {
                List<dynamic> list = new List<dynamic>();

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = null;

                if (barcode != "")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, barcode, warehouse.ToString(), Giris.mKodValue);
                }
                else if (itemCode != "")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, itemCode, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                }
                else
                {
                    CustomMsgBox.Show("SATIR SEÇİMİ YAPMADAN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }

                if (resp._list != null)
                {
                    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                    //list.Add(resp._list.Rows[0]["Barkod"]);
                    list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);
                    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                    list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                    list.Add(Math.Round(orderqty, Giris.genelParametreler.OndalikMiktar).ToString());
                    var toplananmiktar = dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value);

                    list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString());
                    list.Add(dtgDetails.Rows[currentRow - 1].Cells["DepoKodu"].Value);
                    list.Add(dtgDetails.Rows[currentRow - 1].Cells["DepoAdi"].Value);
                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        list.Add(dtgDetails.Rows[currentRow - 1].Cells["DepoYeriId"].Value);
                        list.Add(dtgDetails.Rows[currentRow - 1].Cells["DepoYeriAdi"].Value);
                        list.Add(dtgDetails.Rows[currentRow - 1].Cells["HedefDepo"].Value);
                        list.Add(dtgDetails.Rows[currentRow - 1].Cells["HedefDepoAdi"].Value);
                        list.Add(dtgDetails.Rows[currentRow - 1].Cells["HDepoYeriId"].Value);
                        list.Add(dtgDetails.Rows[currentRow - 1].Cells["HDepoYeriAdi"].Value);
                    }
                    var onaydaBekleyen = dtgDetails.Rows[currentRow - 1].Cells["OnaydaBekleyenMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["OnaydaBekleyenMiktar"].Value);
                    list.Add(Math.Round(onaydaBekleyen, Giris.genelParametreler.OndalikMiktar).ToString());

                    PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("1250000001", list, "TALEBE BAĞLI DEPO NAKLİ");
                    partisizKalemSecimi.ShowDialog();
                    partisizKalemSecimi.Dispose();
                    GC.Collect();
                    //this.Hide();

                    if (PartisizKalemSecimi.dialogresult == "Ok")
                    {
                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            if (PartisizKalemSecimi.depoYeriId != "")
                            {
                                dtDetails.Rows[currentRow - 1]["DepoYeriId"] = PartisizKalemSecimi.depoYeriId;
                            }
                            if (PartisizKalemSecimi.depoYeriAdi != "")
                            {
                                dtDetails.Rows[currentRow - 1]["DepoYeriAdi"] = PartisizKalemSecimi.depoYeriAdi;
                            }
                            if (PartisizKalemSecimi.hedefDepoYeriId != "")
                            {
                                dtDetails.Rows[currentRow - 1]["HDepoYeriId"] = PartisizKalemSecimi.hedefDepoYeriId;
                            }
                            if (PartisizKalemSecimi.hedefDepoYeriAdi != "")
                            {
                                dtDetails.Rows[currentRow - 1]["HDepoYeriAdi"] = PartisizKalemSecimi.hedefDepoYeriAdi;
                            }
                            PartisizKalemSecimi.depoYeriId = "";
                            PartisizKalemSecimi.depoYeriAdi = "";
                            PartisizKalemSecimi.hedefDepoYeriId = "";
                            PartisizKalemSecimi.hedefDepoYeriAdi = "";
                        }
                        dtDetails.Rows[currentRow - 1]["ToplananMiktar"] = PartisizKalemSecimi.quantity;

                        #region onayda bekleyen nul oldugundan toplayamıyordu patlıyordu.buun için koyuldu

                        var onaydabekleyen = dtgDetails.Rows[currentRow - 1].Cells["OnaydaBekleyenMiktar"].Value;
                        if (onaydabekleyen == DBNull.Value)
                        {
                            onaydabekleyen = 0;
                        }

                        #endregion onayda bekleyen nul oldugundan toplayamıyordu patlıyordu.buun için koyuldu

                        //dtDetails.AcceptChanges();
                        if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(onaydabekleyen), Giris.genelParametreler.OndalikMiktar) + Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar))
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = Color.LimeGreen;
                        }
                        else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = defaultColor;
                        }
                        else
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;
                        }

                        PartisizKalemSecimi.dialogresult = "";
                    }
                    if (dtgDetails.Rows.Count > 0)
                    {
                        dtgDetails.Rows[currentRow - 1].Selected = false;
                    }

                    //TalebeBagliDepoNakli_3.dialogresult = "";
                    //txtBarCode.Text = "";
                }
                partili = "";
                barcode = "";
            }
            else
            {
                List<dynamic> list = new List<dynamic>();
                //partino = Giris.UrunKoduBarkod(txtBarCode.Text, "Parti");
                string Val = txtBarCode.Text;
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = new Response();

                if (Val != "TANIMSIZ")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), Giris.mKodValue);
                }

                if (Val != "TANIMSIZ")
                {
                    if (resp._list == null)
                    {
                        if (Val != "")
                        {
                            //Val = cmbItemName.SelectedValue.ToString();
                            resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                        }
                    }
                }
                else
                {
                    if (resp._list == null)
                    {
                        Val = cmbItemName.SelectedValue.ToString();
                        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                    }
                }
                //else
                //{
                //    if (cmbItemName.SelectedValue != null)
                //    {
                //        Val = cmbItemName.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        Val = "";
                //    }
                //}

                if (resp._list != null)
                {
                    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                    //list.Add(resp._list.Rows[0]["Barkod"]);
                    list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);
                    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                    list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                    list.Add(Math.Round(orderqty, Giris.genelParametreler.OndalikMiktar).ToString());

                    var toplananmiktar = dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value);

                    list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString());

                    var onaydaBekleyen = dtgDetails.Rows[currentRow - 1].Cells["OnaydaBekleyenMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["OnaydaBekleyenMiktar"].Value);
                    list.Add(Math.Round(onaydaBekleyen, Giris.genelParametreler.OndalikMiktar).ToString());

                    //if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                    //{
                    list.Add(partino);
                    partino = "";
                    //}

                    list.Add(kaynakdepo);
                    list.Add(hedefdepo);
                    TalebeBagliDepoNakli_3 talebeBagliDepoNakli_3 = new TalebeBagliDepoNakli_3("1250000001", list, "TALEBE BAĞLI DEPO NAKLİ");
                    talebeBagliDepoNakli_3.ShowDialog();
                    talebeBagliDepoNakli_3.Dispose();
                    GC.Collect();
                    //this.Hide();

                    if (TalebeBagliDepoNakli_3.dialogresult == "Ok")
                    {
                        var quantity = inventoryGenEntryBatches.Where(x => x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                        dtDetails.Rows[currentRow - 1]["ToplananMiktar"] = quantity;

                        #region onayda bekleyen nul oldugundan toplayamıyordu patlıyordu.buun için koyuldu

                        var onaydabekleyen = dtgDetails.Rows[currentRow - 1].Cells["OnaydaBekleyenMiktar"].Value;
                        if (onaydabekleyen == DBNull.Value)
                        {
                            onaydabekleyen = 0;
                        }

                        #endregion onayda bekleyen nul oldugundan toplayamıyordu patlıyordu.buun için koyuldu

                        //dtDetails.AcceptChanges();
                        if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(onaydabekleyen), Giris.genelParametreler.OndalikMiktar) + Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar))
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = Color.LimeGreen;
                        }
                        else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = defaultColor;
                        }
                        else
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;
                        }
                    }

                    TalebeBagliDepoNakli_3.dialogresult = "";
                }
                partili = "";
                barcode = "";
            }
            if (dtgDetails.Rows.Count > 0)
            {
                dtgDetails.Rows[currentRow - 1].Selected = false;
            }

            //dtgDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgDetails.AutoResizeRows();
            txtBarCode.Focus();
            txtBarCode.Text = "";
            cmbItemName.Text = "";

            btnItemSearch.PerformClick();
            cmbItemName.DroppedDown = false;
        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDetails.Rows.Count == 0)
                {
                    //ne uyarısı yazılabilir buraya?
                    //CustomMsgBox.Show("Lütfen Çıkış Depo Seçimi Yapınız.", "Uyarı", "Tamam", "");
                    return;
                }

                #region miktardan fazla giriş yapılmaması için eklendi

                //double mik = 0;
                //double onaydaBekleyen = 0;
                //double toplanan = 0;
                //double girilebilirMiktar = 0;
                //string kalemkod = "";

                //foreach (DataRow items in dtDetails.Rows)
                //{
                //    kalemkod = items["KalemKodu"].ToString();
                //    mik = items["Miktar"] == DBNull.Value ? 0 : Convert.ToDouble(items["Miktar"]);
                //    onaydaBekleyen = items["OnaydaBekleyenMiktar"] == DBNull.Value ? 0 : Convert.ToDouble(items["OnaydaBekleyenMiktar"]);
                //    toplanan = items["ToplananMiktar"] == DBNull.Value ? 0 : Convert.ToDouble(items["ToplananMiktar"]);

                //    girilebilirMiktar = onaydaBekleyen + toplanan;

                //    if (girilebilirMiktar > mik)
                //    {
                //        CustomMsgBox.Show(kalemkod + " için fazla miktar girişi.", "Uyarı", "TAMAM", "");
                //        return;
                //    }
                //}

                #endregion miktardan fazla giriş yapılmaması için eklendi

                //if (txtBarCode.Text == "")
                //{
                //    CustomMsgBox.Show("Lütfen Barkod Girişi Yapınız.", "Uyarı", "Tamam", "");
                //    txtBarCode.Focus();
                //    return;
                //}
                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                    return;
                }
                InventoryGenEntry inventoryGenEntry = new InventoryGenEntry();
                InventoryGenEntryLines inventoryGenEntryLines = new InventoryGenEntryLines();
                List<InventoryGenEntryLines> inventoryGenEntryLines1 = new List<InventoryGenEntryLines>();
                List<InventoryGenEntryLinesBatch> inventoryGenEntryBatchlist = new List<InventoryGenEntryLinesBatch>();
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                int i = 1;
                inventoryGenEntry.CardCode = txtVendorCode.Text;
                inventoryGenEntry.DocDate = dtpDocDate.Value.ToString("yyyyMMdd");
                inventoryGenEntry.DocDueDate = dtpTransferDate.Value.ToString("yyyyMMdd");

                foreach (DataRow items in dtDetails.Rows)
                {
                    if (items["ToplananMiktar"].ToString() == "0" || items["ToplananMiktar"].ToString() == "")
                    {
                        continue;
                    }

                    inventoryGenEntryBatchlist = new List<InventoryGenEntryLinesBatch>();
                    //inventoryGenEntryLines1 = new List<InventoryGenEntryLines>();
                    foreach (var aifx in inventoryGenEntryBatches.Where(x => x.ItemCode == items["KalemKodu"].ToString() && x.SAPLineNum == Convert.ToInt32(items["SiraNo"]) && x.DocEntry == Convert.ToInt32(items["BelgeNumarasi"])))
                    {
                        inventoryGenEntryBatchlist.Add(new InventoryGenEntryLinesBatch
                        {
                            BatchNumber = aifx.BatchNumber,
                            BatchQuantity = aifx.BatchQuantity,
                            DepoYeriId = aifx.DepoYeriId,
                            HedefDepoYeriId = aifx.HedefDepoYeriId
                        });
                    }

                    inventoryGenEntryLines1.Add(new InventoryGenEntryLines
                    {
                        InventoryGenEntryLinesBatch = inventoryGenEntryBatchlist.ToArray(),
                        ItemCode = items["KalemKodu"].ToString(),
                        Quantity = Math.Round(Convert.ToDouble(items["ToplananMiktar"]), Giris.genelParametreler.OndalikMiktar),
                        BaseEntry = Convert.ToInt32(items["BelgeNumarasi"]),
                        BaseType = 1250000001,
                        BaseLine = Convert.ToInt32(items["SiraNo"]),
                        uretimdenGonderildi = items["UretimdenGonderildi"].ToString(),
                        toWhsCode = items["HedefDepo"].ToString(),
                        fromWhsCode = items["DepoKodu"].ToString(),
                        BinCode_from = Giris.genelParametreler.DepoYeriCalisir == "Y" && items["Partili"].ToString() != "Y" ? items["DepoYeriId"].ToString() : "",
                        BinCode_to = Giris.genelParametreler.DepoYeriCalisir == "Y" && items["Partili"].ToString() != "Y" ? items["HDepoYeriId"].ToString() : "",
                    });

                    inventoryGenEntry.InventoryGenEntryLines = inventoryGenEntryLines1.ToArray();
                    i++;
                }
                if (inventoryGenEntry.InventoryGenEntryLines == null)
                {
                    CustomMsgBox.Show("TÜM SATIRLARIN MİKTARI 0 OLAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }
                if (inventoryGenEntry.InventoryGenEntryLines.Count() == 0)
                {
                    CustomMsgBox.Show("TÜM SATIRLARIN MİKTARI 0 OLAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }

                #region iki veya daha fazla uygulamadan fazladan miktar girişini engellemek için yapılmıştır

                if (Giris.mKodValue == "10TRMN" || Giris.mKodValue == "30TRMN" || Giris.mKodValue == "20TRMN")
                {
                    try
                    {
                        AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                        Response resp = aIFTerminalServiceSoapClient.GetStokNakliFazlaMiktarKontrol(Giris._dbName, docEntryList.ToArray(), Giris.whsCodes.ToArray(), Giris.mKodValue);

                        DataTable dt = new DataTable();

                        if (resp._list != null)
                        {
                            dt = resp._list;

                            int c = 1;
                            foreach (var item in inventoryGenEntry.InventoryGenEntryLines)
                            {
                                var chn = dt.AsEnumerable().Where(x => x.Field<int>("BelgeNumarasi") == Convert.ToInt32(item.BaseEntry) && x.Field<int>("SiraNo") == Convert.ToInt32(item.BaseLine)).ToList();

                                if (chn.Count > 0)
                                {
                                    var mik = chn.Select(x => x.Field<decimal>("AcikMiktar")).FirstOrDefault();
                                    double mikmevcut = Convert.ToDouble(item.Quantity);
                                    if (mikmevcut > Convert.ToDouble(mik))
                                    {
                                        CustomMsgBox.Show(item.ItemCode + " için en fazla " + mik.ToString("N" + Giris.genelParametreler.OndalikMiktar) + " miktar girişi yapılabilir.", "Uyarı", "Tamam", "");

                                        //var arg = new DataGridViewCellEventArgs(dtCekmeListesiDetaylari.Rows.Count, i);
                                        //dtgCekmeListesi_CellClick(dtgCekmeListesi, arg);
                                        return;
                                    }
                                }
                                c++;
                            }
                        }
                        else
                        {
                            CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomMsgBox.Show("Hata oluştu." + ex.Message, "Uyarı", "Tamam", "");
                        return;
                    }
                }

                #endregion iki veya daha fazla uygulamadan fazladan miktar girişini engellemek için yapılmıştır

                var resp1 = Giris.genelParametreler.TalebeBaglidaOrjinalOlustur == "N" ? aIFTerminalServiceSoapClient1.AddOrUpdateStockTransferDraft(Giris._dbName, Convert.ToInt32(Giris._userCode), inventoryGenEntry) : Giris.genelParametreler.TalebeBaglidaOrjinalOlustur == "" ? aIFTerminalServiceSoapClient1.AddOrUpdateStockTransferDraft(Giris._dbName, Convert.ToInt32(Giris._userCode), inventoryGenEntry) : aIFTerminalServiceSoapClient1.AddOrUpdateStockTransfer(Giris._dbName, Convert.ToInt32(Giris._userCode), inventoryGenEntry);

                //if (Giris.genelParametreler.TalebeBaglidaOrjinalOlustur == "" || Giris.genelParametreler.TalebeBaglidaOrjinalOlustur == "N")
                //{
                //    aIFTerminalServiceSoapClient1.AddOrUpdateStockTransferDraft(Giris._dbName, inventoryGenEntry);
                //}
                //else if (Giris.genelParametreler.TalebeBaglidaOrjinalOlustur == "Y")
                //{
                //    aIFTerminalServiceSoapClient1.AddOrUpdateStockTransfer(Giris._dbName, inventoryGenEntry);
                //}

                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

                if (resp1.Val == 0)
                {
                    TalebeBagliDepoNakli_1.formAciliyor = true;
                    TalebeBagliDepoNakli_1.dialogresult = "Ok";
                    Close();
                    //buttonListele.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void dtgDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                List<dynamic> list = new List<dynamic>();
                if (senderGrid.Columns[e.ColumnIndex].Name == "btnDetail")
                {
                    partili = dtDetails.Rows[e.RowIndex]["Partili"].ToString();
                    if (partili != "Y")
                    {
                        CustomMsgBox.Show("PARTİLİ OLMAYAN ÜRÜNÜN DETAYINA GİDİLEMEZ.", "Uyarı", "Tamam", "");
                        return;
                    }

                    DocEntry = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["BelgeNumarasi"]);
                    currentRow = e.RowIndex;

                    string ItemCode = dtDetails.Rows[e.RowIndex]["KalemKodu"].ToString();
                    list.Add(dtDetails.Rows[e.RowIndex]["KalemKodu"].ToString());
                    list.Add(dtDetails.Rows[e.RowIndex]["KalemAdi"].ToString());
                    list.Add(dtDetails.Rows[e.RowIndex]["Barkod"].ToString());
                    list.Add(dtDetails.Rows[e.RowIndex]["OlcuBirimi"].ToString());
                    list.Add(dtDetails.Rows[e.RowIndex]["DepoMiktar"].ToString());
                    list.Add(dtDetails.Rows[e.RowIndex]["Miktar"].ToString());

                    TalebeBagliDepoNakli_3 n = new TalebeBagliDepoNakli_3("1250000001", list, "TALEBE BAĞLI DEPO NAKLİ");
                    n.ShowDialog();
                    n.Dispose();
                    GC.Collect();

                    var quantity = inventoryGenEntryBatches.Where(x => x.DocEntry == DocEntry && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                    dtDetails.Rows[currentRow]["ToplananMiktar"] = quantity;

                    dtgDetails.Refresh();
                }
            }
        }

        private string partino = "";

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode.Focus();

                if (txtBarCode.Text != "")
                {
                    partino = Giris.UrunKoduBarkod(txtBarCode.Text, "Parti");
                    txtBarCode.Text = Giris.UrunKoduBarkod(txtBarCode.Text, "Barkod");
                    var exits = dtDetails.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarCode.Text).ToList();
                    if (exits.Count > 0)
                    {
                        var dtgSira = dtDetails.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarCode.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                        var arg = new DataGridViewCellEventArgs(dtDetails.Rows.Count, dtgSira);
                        dtgDetails_CellClick(dtgDetails, arg);

                        dtgDetails.ClearSelection();

                        dtgDetails.Rows[dtgSira].Cells[0].Selected = true;
                        btnDetails.PerformClick();
                    }

                    exits = dtDetails.AsEnumerable().Where(x => x.Field<string>("KalemKodu") == txtBarCode.Text).ToList();
                    if (exits.Count > 0)
                    {
                        var dtgSira = dtDetails.AsEnumerable().Where(x => x.Field<string>("KalemKodu") == txtBarCode.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                        var arg = new DataGridViewCellEventArgs(dtDetails.Rows.Count, dtgSira);
                        dtgDetails_CellClick(dtgDetails, arg);

                        dtgDetails.ClearSelection();

                        dtgDetails.Rows[dtgSira].Cells[0].Selected = true;
                        btnDetails.PerformClick();
                    }
                }
            }
        }

        private void dtgDetails_DoubleClick(object sender, EventArgs e)
        {
            //if (partili == "Y")
            //{
            btnDetails.PerformClick();
            partili = "";
            barcode = "";
            return;
            //}
            //else if (partili != "Y")
            //{
            //    List<dynamic> list = new List<dynamic>();

            //    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            //    Response resp = null;

            //    if (barcode != "")
            //    {
            //        resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, barcode, warehouse.ToString());
            //    }
            //    else if (itemCode != "")
            //    {
            //        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, itemCode, warehouse.ToString());
            //    }

            //    if (resp._list != null)
            //    {
            //        list.Add(resp._list.Rows[0]["Kalem Kodu"]);
            //        list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
            //        list.Add(resp._list.Rows[0]["Barkod"]);
            //        list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
            //        list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), 4));
            //        list.Add(Math.Round(orderqty, 4).ToString());

            //        PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("1250000001", list, "TALEBE BAĞLI DEPO NAKLİ");
            //        partisizKalemSecimi.ShowDialog();
            //        //this.Hide();

            //        if (PartisizKalemSecimi.dialogresult == "Ok")
            //        {
            //            dtDetails.Rows[currentRow]["ToplananMiktar"] = PartisizKalemSecimi.quantity;
            //            //dtDetails.AcceptChanges();
            //            if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["Miktar"].Value), 4) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), 4))
            //            {
            //                dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.LimeGreen;
            //            }
            //            else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), 4) == 0)
            //            {
            //                dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = defaultColor;
            //            }
            //            else
            //            {
            //                dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;
            //            }
            //        }
            //        dtgDetails.Rows[currentRow].Selected = false;

            //        //TalebeBagliDepoNakli_3.dialogresult = "";
            //        //txtBarCode.Text = "";

            //    }
            //    partili = "";
            //    barcode = "";
            //}
        }

        private DataTable dtProductsItem = new DataTable();

        private DataView dtViewItem = new DataView();

        private void GetAllProducts()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetAllProducts(Giris._dbName, Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtProductsItem = resp._list;
                    dtViewItem = new DataView(resp._list);
                }
            }
        }

        private void cmbItemName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbItemName.SelectedValue != null)
            {
                var value = cmbItemName.SelectedValue.ToString();

                if (value != "")
                {
                    if (dtProductsItem.Rows.Count > 0)
                    {
                        var listProducts = dtProductsItem.AsEnumerable().Where(x => x.Field<string>("ItemCode") == value).ToList();

                        var itemCode = listProducts.Select(x => x.Field<string>("ItemCode")).First();
                        var barcode = listProducts.Select(x => x.Field<string>("CodeBars")).First();

                        if (barcode != "" && barcode != null)
                        {
                            txtBarCode.Text = barcode;
                        }
                        else if (itemCode != "" && itemCode != null)
                        {
                            txtBarCode.Text = "TANIMSIZ";
                        }

                        dtgDetails.DataSource = dtDetails;

                        dtgDetails.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                        dtgDetails.Columns["ToplananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                        dtgDetails.Columns["DepoMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                        dtgDetails.Columns["BelgeNumarasi"].ReadOnly = true;
                        dtgDetails.Columns["KalemKodu"].ReadOnly = true;
                        dtgDetails.Columns["KalemAdi"].ReadOnly = true;
                        dtgDetails.Columns["Miktar"].ReadOnly = true;
                        dtgDetails.Columns["Barkod"].ReadOnly = true;
                        dtgDetails.Columns["Partili"].ReadOnly = true;
                        dtgDetails.Columns["OlcuBirimi"].ReadOnly = true;

                        dtgDetails.Columns["btnDetail"].DisplayIndex = 0;
                        dtgDetails.Columns["BelgeNumarasi"].DisplayIndex = 1;
                        dtgDetails.Columns["KalemKodu"].DisplayIndex = 2;
                        dtgDetails.Columns["KalemAdi"].DisplayIndex = 3;
                        dtgDetails.Columns["OlcuBirimi"].DisplayIndex = 4;
                        dtgDetails.Columns["Barkod"].DisplayIndex = 5;
                        dtgDetails.Columns["Miktar"].DisplayIndex = 6;
                        dtgDetails.Columns["ToplananMiktar"].DisplayIndex = 7;
                        dtgDetails.Columns["Partili"].DisplayIndex = 8;
                        dtgDetails.Columns["DepoKodu"].DisplayIndex = 9;
                        dtgDetails.Columns["SiraNo"].DisplayIndex = 10;

                        dtgDetails.Columns["BelgeNumarasi"].HeaderText = "BELGE NO";
                        dtgDetails.Columns["KalemKodu"].HeaderText = "KALEM KODU";
                        dtgDetails.Columns["KalemAdi"].HeaderText = "KALEM ADI";
                        dtgDetails.Columns["Barkod"].HeaderText = "BARKOD";
                        dtgDetails.Columns["Miktar"].HeaderText = "MİKTAR";
                        dtgDetails.Columns["OlcuBirimi"].HeaderText = "BRM";
                        dtgDetails.Columns["ToplananMiktar"].HeaderText = "TOPLANAN MİKTAR";
                        dtgDetails.Columns["DepoMiktar"].HeaderText = "STOKTA";

                        dtgDetails.Columns["Partili"].Visible = false;
                        dtgDetails.Columns["DepoKodu"].Visible = false;
                        dtgDetails.Columns["SiraNo"].Visible = false;
                        dtgDetails.Columns["Barkod"].Visible = false;

                        dtgDetails.EnableHeadersVisualStyles = false;
                        dtgDetails.RowTemplate.Height = 100;
                        dtgDetails.ColumnHeadersHeight = 50;

                        btnDetails.PerformClick();
                    }
                }
            }
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            GetAllProducts();
            if (dtProductsItem.Rows.Count > 0)
            {
                dtViewItem.RowFilter = "ItemName = '' or ItemName like '%" + cmbItemName.Text + "%'";
                cmbItemName.DataSource = null;

                if (dtViewItem.Count > 0)
                {
                    cmbItemName.DisplayMember = "ItemName";
                    cmbItemName.ValueMember = "ItemCode";
                    cmbItemName.DataSource = dtViewItem;

                    cmbItemName.DroppedDown = true;
                }
                else
                {
                    CustomMsgBox.Show("ARAMA SONUCU EŞLEŞEN KAYIT BULUNAMAMIŞTIR.", "Uyarı", "TAMAM", "");
                }
            }
        }

        private void dtgDetails_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                vScrollBar1.Value = e.NewValue;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("hata" + ex.Message);
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //vscrollbar koyulmadan kaydırma sorunu yaşanıyor.visible false yapıldığında da kaydırma işleminde sorun olduğundan 0.1 genişliğinde çalışır duruma getirildi.
            try
            {
                dtgDetails.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void btnBarkodGoster_Click(object sender, EventArgs e)
        {
            ListParties = new List<Parties>();

            List<dynamic> list = new List<dynamic>();
            var partiler = inventoryGenEntryBatches.Where(x => x.ItemCode == itemCode && x.SAPLineNum == Convert.ToInt32(sapLineNum) && x.DocEntry == Convert.ToInt32(DocEntry)).ToList();

            //if (partiler.Count == 0)
            //{
            //    CustomMsgBox.Show("PARTİ GİRİŞİ YAPILMAMIŞTIR.", "Uyarı", "TAMAM", "");
            //    return;
            //}
            if (txtBarCode.Text == "")
            {
                CustomMsgBox.Show("BARKOD VEYA KALEM KODU GİRİNİZ.", "Uyarı", "TAMAM", "");
                txtBarCode.Focus();
                txtBarCode.Select(0, txtBarCode.Text.Length);
                return;
            }
            string Val = txtBarCode.Text;
            if (partili == "Y")
            {
                if (partiler.Count > 0)
                {
                    foreach (var item in partiler)
                    {
                        #region old

                        //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                        #endregion old

                        if (barcode == "")
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                        }
                        else
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                        }
                    }
                }
                else
                {
                    #region old 2022909

                    //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                    #endregion old 2022909

                    if (barcode == "")
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                    }
                    else
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                    }
                }
            }
            else
            {
                #region old

                /*ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) })*/
                ;

                #endregion old

                if (barcode == "")
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                }
                else
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                }
            }

            txtBarCode.Text = "";
            BarkodGoruntule barkodGoruntule = new BarkodGoruntule("1250000001", ListParties, "BARKOD GÖRÜNTÜLEME");
            barkodGoruntule.ShowDialog();
            barkodGoruntule.Dispose();
            GC.Collect();

            if (dtgDetails.Rows.Count > 0)
            {
                dtgDetails.Rows[currentRow - 1].Selected = false;
            }
            ListParties = new List<Parties>();
        }

        public static List<Parties> ListParties = new List<Parties>();

        private void dtgDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (!formYukleniyor)
            //    {
            //        double girilebilirMiktar = 0;

            //        var senderGrid = (DataGridView)sender;

            //        if (senderGrid.Columns[e.ColumnIndex].Name == "ToplananMiktar")
            //        {
            //            double miktar = dtgDetails.Rows[e.RowIndex].Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[e.RowIndex].Cells["Miktar"].Value);

            //            double onaydaBekleyenMiktar = dtgDetails.Rows[e.RowIndex].Cells["OnaydaBekleyenMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[e.RowIndex].Cells["OnaydaBekleyenMiktar"].Value);

            //            double toplananMiktar = dtgDetails.Rows[e.RowIndex].Cells["ToplananMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[e.RowIndex].Cells["ToplananMiktar"].Value);

            //            girilebilirMiktar = toplananMiktar + onaydaBekleyenMiktar;

            //            if (girilebilirMiktar > miktar)
            //            {
            //                MessageBox.Show("fazla miktar girilemez");
            //                return;
            //            }

            //            //toplammiktar = koliadedi * koliiciadedi;

            //            //dtgDetails.Rows[e.RowIndex].Cells["ToplamMiktar"].Value = toplammiktar;
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("hata" + ex.Message);
            //}
        }

        private void txtMiktarGiriliyor_TextChanged(object sender, EventArgs e)
        {
        }
    }
}