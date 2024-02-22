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
    public partial class TalebeBagliDepoNakli_2_Kabul : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //end font

        private Button buttonListele = new Button();

        public TalebeBagliDepoNakli_2_Kabul(List<InventoryTransferList> _inventoryTransferLists, Button _buttonListele, string _formName)
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

                dtpDocDate.Value = new DateTime(Convert.ToInt32(max.DocDate.Substring(0, 4)), Convert.ToInt32(max.DocDate.Substring(4, 2)), Convert.ToInt32(max.DocDate.Substring(6, 2)));
                dtpTransferDate.Value = new DateTime(Convert.ToInt32(max.DocDueDate.Substring(0, 4)), Convert.ToInt32(max.DocDueDate.Substring(4, 2)), Convert.ToInt32(max.DocDueDate.Substring(6, 2)));

                List<string> docEntryList = new List<string>();
                foreach (var item in inventoryTransferLists)
                {
                    docEntryList.Add(item.DocEntry.ToString());
                }

                GetDraftInventoryTransferRequestDetails(docEntryList, inventoryTransferLists[0].fromwhscode, inventoryTransferLists[0].towhscode);
            }

            buttonListele = _buttonListele;
        }

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

        private void TalebeBagliDepoNakli_2_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            if (dtgDetails.Rows.Count > 0)
            {
                defaultColor = dtgDetails.Rows[0].Cells[0].Style.BackColor;
                //cmbItemName.DropDownStyle = ComboBoxStyle.DropDown;

                txtBarCode.Focus();

                dtgDetails.RowTemplate.Height = 55;
                dtgDetails.ColumnHeadersHeight = 60;

                dtgDetails.Columns["KalemKodu"].Visible = false;
                dtgDetails.Columns["BelgeNumarasi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgDetails.Columns["KalemKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDetails.Columns["OlcuBirimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDetails.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDetails.Columns["OnaylananMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDetails.Columns["DepoMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDetails.Columns["HedefDepo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dtgDetails.Columns["KalemAdi"].Width = dtgDetails.Width - dtgDetails.Columns["BelgeNumarasi"].Width - dtgDetails.Columns["OlcuBirimi"].Width - dtgDetails.Columns["Miktar"].Width - dtgDetails.Columns["OnaylananMiktar"].Width - dtgDetails.Columns["DepoMiktar"].Width;

                dtgDetails.Columns["btnDetail"].Visible = false;
                vScrollBar1.Maximum = dtgDetails.RowCount + 5;

                dtgDetails.Rows[0].Selected = false;
            }
        }

        private DataTable dtDetails = new DataTable();

        private void GetDraftInventoryTransferRequestDetails(List<string> docentryList, string fromwhscode, string towhscode)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;
            Response respDepo = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetDraftInventoryTransferRequestDetails(Giris._dbName, docentryList.ToArray(), Giris.whsCodes.ToArray(), Giris._userCode, Giris.genelParametreler.TalepsizDepoNaklindeTaslakBelgeOlustur, fromwhscode, towhscode, Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                List<string> whsCodes2 = new List<string>();

                respDepo = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpKabulK", Giris.mKodValue);

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

                respDepo = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpKabulH", Giris.mKodValue);

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

                resp = aIFTerminalServiceSoapClient.GetDraftInventoryTransferRequestDetails(Giris._dbName, docentryList.ToArray(), null, Giris._userCode, Giris.genelParametreler.TalepsizDepoNaklindeTaslakBelgeOlustur, fromwhscode, towhscode, Giris.mKodValue);
            }

            if (resp._list != null)
            {
                dtDetails = resp._list;

                dtgDetails.DataSource = null;

                dtDetails.Columns.Add("OnaylananMiktar", typeof(double));
                dtDetails.Columns.Add("dtgSira", typeof(int));

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
                dtgDetails.Columns["OnaylananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgDetails.Columns["DepoMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                dtgDetails.Columns["BelgeNumarasi"].ReadOnly = true;
                dtgDetails.Columns["KalemKodu"].ReadOnly = true;
                dtgDetails.Columns["KalemAdi"].ReadOnly = true;
                dtgDetails.Columns["Miktar"].ReadOnly = true;
                dtgDetails.Columns["OnaylananMiktar"].ReadOnly = true;
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
                dtgDetails.Columns["OnaylananMiktar"].DisplayIndex = 7;
                dtgDetails.Columns["Partili"].DisplayIndex = 8;
                //dtgDetails.Columns["DepoKodu"].DisplayIndex = 9;
                dtgDetails.Columns["HedefDepo"].DisplayIndex = 9;
                dtgDetails.Columns["SiraNo"].DisplayIndex = 10;

                dtgDetails.Columns["BelgeNumarasi"].HeaderText = "ONAY NO";
                dtgDetails.Columns["KalemKodu"].HeaderText = "KALEM KODU";
                dtgDetails.Columns["KalemAdi"].HeaderText = "KALEM ADI";
                dtgDetails.Columns["Barkod"].HeaderText = "BARKOD";
                dtgDetails.Columns["Miktar"].HeaderText = "MİKTAR";
                dtgDetails.Columns["OlcuBirimi"].HeaderText = "BRM";
                dtgDetails.Columns["OnaylananMiktar"].HeaderText = "ONAY.MİK";
                dtgDetails.Columns["DepoMiktar"].HeaderText = "STOK";
                dtgDetails.Columns["HedefDepo"].HeaderText = "HEDEF";

                dtgDetails.Columns["KalemKodu"].Visible = false;
                dtgDetails.Columns["Partili"].Visible = false;
                dtgDetails.Columns["DepoKodu"].Visible = false;
                dtgDetails.Columns["SiraNo"].Visible = false;
                dtgDetails.Columns["Barkod"].Visible = false;

                dtgDetails.Columns["PaletIciKoliAD"].Visible = false;
                dtgDetails.Columns["KoliIciAD"].Visible = false;
                dtgDetails.Columns["PaletIciAD"].Visible = false;
                dtgDetails.Columns["TaslakGercek"].Visible = false;

                dtgDetails.EnableHeadersVisualStyles = false;

                dtgDetails.Columns["OnaylananMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDetails.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDetails.Columns["DepoMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtgDetails.RowTemplate.Height = 55;
                dtgDetails.ColumnHeadersHeight = 60;

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
                    dtgDetails.Rows[i].Cells["OnaylananMiktar"].Value = dtgDetails.Rows[i].Cells["Miktar"].Value;
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

                List<string> itemCodeList = new List<string>();

                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
                    itemCodeList.Add(dtDetails.Rows[i]["KalemKodu"].ToString());
                }
                aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                int sira = 0;

                List<int> docentryIntList = new List<int>();

                foreach (var item in docentryList.Distinct())
                {
                    if (item == "")
                    {
                        continue;
                    }
                    docentryIntList.Add(Convert.ToInt32(item));
                }

                docentryIntList.Sort();

                foreach (var item in docentryIntList)
                {
                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        resp = aIFTerminalServiceSoapClient.GetBatchByItemCodeToDraftDocument_DepoYerli(Giris._dbName, warehouse, itemCodeList.ToArray(), Convert.ToInt32(item), Giris.mKodValue);
                    }
                    else
                    {
                        resp = aIFTerminalServiceSoapClient.GetBatchByItemCodeToDraftDocument(Giris._dbName, warehouse, itemCodeList.ToArray(), Convert.ToInt32(item), Giris.mKodValue);
                    }
                    if (resp.Val != 0)
                    {
                        //CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                    }
                    else
                    {
                        //TalebeBagliDepoNakli_3_Kabul.BatchInWarehouseDt = resp._list;

                        int docEntry = 0;
                        string batchNum = "";
                        double batchQty = 0;
                        string itemCode = "";
                        int lineNumber = 0;
                        string partinitelik = "";
                        string depoyeriid = "";
                        string hedefdepoyeriid = "";
                        string depoyeriAdi = "";
                        string hedefdepoyeriAdi = "";

                        for (int i = 0; i < resp._list.Rows.Count; i++)
                        {
                            docEntry = Convert.ToInt32(resp._list.Rows[i]["docentry"]);
                            batchNum = resp._list.Rows[i]["BatchNum"].ToString();
                            batchQty = resp._list.Rows[i]["Quantity"].ToString() == "" ? 0 : Convert.ToDouble(resp._list.Rows[i]["Quantity"]); //miktar boş gelen kayıt hata verdiği için eklendi

                            itemCode = resp._list.Rows[i]["ItemCode"].ToString();
                            lineNumber = Convert.ToInt32(resp._list.Rows[i]["LineNum"]);

                            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                            {
                                depoyeriid = resp._list.Rows[i]["KaynakDepoId"].ToString();
                                hedefdepoyeriid = resp._list.Rows[i]["HedefDepoId"].ToString();
                                depoyeriAdi = resp._list.Rows[i]["KaynakDepoAdi"].ToString();
                                hedefdepoyeriAdi = resp._list.Rows[i]["HedefDepoAdi"].ToString(); 
                            }
                            if (Giris.mKodValue == "20TRMN")
                            {
                                partinitelik = resp._list.Rows[i]["MnfSerial"].ToString();
                            }
                            if (inventoryGenEntryBatches.Where(x => x.DocEntry == docEntry && x.SAPLineNum == lineNumber).Count() == 0)
                            {
                                if (Giris.mKodValue == "20TRMN")
                                {
                                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                                    {
                                        inventoryGenEntryBatches.Add(new InventoryGenEntryBatch { BatchNumber = batchNum, BatchQuantity = batchQty, MnfSerial = partinitelik, DocEntry = docEntry, ItemCode = itemCode, LineNumber = sira + 1, SAPLineNum = lineNumber, DepoYeriId = depoyeriid, DepoYeriAdi = depoyeriAdi, HedefDepoYeriId = hedefdepoyeriid, HedefDepoYeriAdi = hedefdepoyeriAdi });
                                    }
                                    else
                                    {
                                        inventoryGenEntryBatches.Add(new InventoryGenEntryBatch { BatchNumber = batchNum, BatchQuantity = batchQty, MnfSerial = partinitelik, DocEntry = docEntry, ItemCode = itemCode, LineNumber = sira + 1, SAPLineNum = lineNumber });
                                    }
                                }
                                else
                                {
                                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                                    {
                                        inventoryGenEntryBatches.Add(new InventoryGenEntryBatch { BatchNumber = batchNum, BatchQuantity = batchQty, DocEntry = docEntry, ItemCode = itemCode, LineNumber = sira + 1, SAPLineNum = lineNumber, DepoYeriId = depoyeriid, DepoYeriAdi = depoyeriAdi, HedefDepoYeriId = hedefdepoyeriid, HedefDepoYeriAdi = hedefdepoyeriAdi });
                                    }
                                    else
                                    {
                                        inventoryGenEntryBatches.Add(new InventoryGenEntryBatch { BatchNumber = batchNum, BatchQuantity = batchQty, DocEntry = docEntry, ItemCode = itemCode, LineNumber = sira + 1, SAPLineNum = lineNumber });
                                    }    
                                }
                                sira++;
                            }
                            else
                            {
                                if (Giris.mKodValue == "20TRMN")
                                {
                                    inventoryGenEntryBatches.Add(new InventoryGenEntryBatch { BatchNumber = batchNum, BatchQuantity = batchQty, MnfSerial = partinitelik, DocEntry = docEntry, ItemCode = itemCode, LineNumber = inventoryGenEntryBatches.Where(x => x.DocEntry == docEntry && x.SAPLineNum == lineNumber).Select(y => y.LineNumber).FirstOrDefault(), SAPLineNum = inventoryGenEntryBatches.Where(x => x.DocEntry == docEntry && x.SAPLineNum == lineNumber).Select(y => y.SAPLineNum).FirstOrDefault() });
                                }
                                else
                                {
                                    inventoryGenEntryBatches.Add(new InventoryGenEntryBatch { BatchNumber = batchNum, BatchQuantity = batchQty, DocEntry = docEntry, ItemCode = itemCode, LineNumber = inventoryGenEntryBatches.Where(x => x.DocEntry == docEntry && x.SAPLineNum == lineNumber).Select(y => y.LineNumber).FirstOrDefault(), SAPLineNum = inventoryGenEntryBatches.Where(x => x.DocEntry == docEntry && x.SAPLineNum == lineNumber).Select(y => y.SAPLineNum).FirstOrDefault() });
                                }
                            }
                        }

                        //dtview = new DataView(resp._list);
                        //BatchInWarehouseDt = resp._list;
                        //BatchDt = resp._list.DefaultView.ToTable(false, "Quantity", "BatchNum");
                        //txtBatchNumber.DataSource = BatchDt;

                        //txtBatchNumber.DisplayMember = "BatchNum";
                        //txtBatchNumber.ValueMember = "Quantity";
                    }
                }
            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
        }

        public static int sapLineNum = 0;
        public static int DocEntry = 0;
        private string barcode = "";
        private string itemCode = "";
        private string itemName = "";
        public static string warehouse = "";
        private string partili = "";
        public static List<InventoryGenEntryBatch> inventoryGenEntryBatches = new List<InventoryGenEntryBatch>();
        public static int currentRow = 0;
        private double orderqty = 0;
        private double paletIciKoliAD = 0;
        private double koliIciAD = 0;
        private double paletIciAD = 0;

        private void dtgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                barcode = dtDetails.Rows[e.RowIndex]["Barkod"].ToString();
                itemCode = dtDetails.Rows[e.RowIndex]["KalemKodu"].ToString();
                itemName = dtDetails.Rows[e.RowIndex]["KalemAdi"].ToString();
                warehouse = dtDetails.Rows[e.RowIndex]["DepoKodu"].ToString();
                orderqty = Convert.ToDouble(dtDetails.Rows[e.RowIndex]["Miktar"]);
                partili = dtDetails.Rows[e.RowIndex]["Partili"].ToString();
                txtBarCode.Text = barcode.ToString() != "" ? barcode.ToString() : itemCode;
                currentRow = e.RowIndex + 1;
                DocEntry = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["BelgeNumarasi"]);
                sapLineNum = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["SiraNo"]);
                paletIciKoliAD = dtDetails.Rows[e.RowIndex]["PaletIciKoliAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["PaletIciKoliAD"]);
                koliIciAD = dtDetails.Rows[e.RowIndex]["KoliIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["KoliIciAD"]);
                paletIciAD = dtDetails.Rows[e.RowIndex]["PaletIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["PaletIciAD"]);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (partili != "Y")
            {
                ////List<dynamic> list = new List<dynamic>();
                ////list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                ////list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                //////list.Add(resp._list.Rows[0]["Barkod"]);
                ////list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);
                ////list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                ////list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                ////list.Add(Math.Round(orderqty, Giris.genelParametreler.OndalikMiktar).ToString());

                //var OnaylananMiktar = dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Value);

                //list.Add(Math.Round(OnaylananMiktar, Giris.genelParametreler.OndalikMiktar).ToString());

                //TalebeBagliDepoNakli_3_Kabul talebeBagliDepoNakli_3_Kabul = new TalebeBagliDepoNakli_3_Kabul("1250000001", list, "TALEBE BAĞLI DEPO NAKLİ KABUL");
                //talebeBagliDepoNakli_3_Kabul.ShowDialog();

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
                    var OnaylananMiktar = dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Value);

                    list.Add(Math.Round(OnaylananMiktar, Giris.genelParametreler.OndalikMiktar).ToString());

                    PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("1250000001", list, "TALEP KABUL");
                    partisizKalemSecimi.ShowDialog();
                    partisizKalemSecimi.Dispose();
                    GC.Collect();
                    //this.Hide();

                    if (PartisizKalemSecimi.dialogresult == "Ok")
                    {
                        dtDetails.Rows[currentRow - 1]["OnaylananMiktar"] = PartisizKalemSecimi.quantity;
                        //dtDetails.AcceptChanges();
                        if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Value), Giris.genelParametreler.OndalikMiktar))
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Style.BackColor = Color.LimeGreen;
                        }
                        else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Style.BackColor = defaultColor;
                        }
                        else
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Style.BackColor = Color.OrangeRed;
                        }
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

                    var OnaylananMiktar = dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Value);

                    list.Add(Math.Round(OnaylananMiktar, Giris.genelParametreler.OndalikMiktar).ToString());

                    if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                    {
                        list.Add(partino);
                        partino = "";
                    }

                    TalebeBagliDepoNakli_3_Kabul talebeBagliDepoNakli_3_Kabul = new TalebeBagliDepoNakli_3_Kabul("1250000001", list, "TALEBE BAĞLI DEPO NAKLİ KABUL");
                    talebeBagliDepoNakli_3_Kabul.ShowDialog();
                    talebeBagliDepoNakli_3_Kabul.Dispose();
                    GC.Collect();
                    //this.Hide();

                    if (TalebeBagliDepoNakli_3_Kabul.dialogresult == "Ok")
                    {
                        #region CURRENT ROW KARŞILAŞTIRMASI HATALI OLABİLİR - YÖRÜK

                        //var quantity = inventoryGenEntryBatches.Where(x => x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                        #endregion CURRENT ROW KARŞILAŞTIRMASI HATALI OLABİLİR - YÖRÜK

                        var quantity = inventoryGenEntryBatches.Where(x => x.DocEntry == DocEntry && x.SAPLineNum == sapLineNum).Sum(y => y.BatchQuantity);

                        dtDetails.Rows[currentRow - 1]["OnaylananMiktar"] = quantity;
                        //dtDetails.AcceptChanges();
                        if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Value), Giris.genelParametreler.OndalikMiktar))
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Style.BackColor = Color.LimeGreen;
                        }
                        else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Style.BackColor = defaultColor;
                        }
                        else
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["OnaylananMiktar"].Style.BackColor = Color.OrangeRed;
                        }
                    }

                    TalebeBagliDepoNakli_3_Kabul.dialogresult = "";
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

                var sifiricerenSatirlar = dtDetails.AsEnumerable().Where(x => x.Field<double>("OnaylananMiktar") == 0).Select(y => y.Field<int>("BelgeNumarasi")).Distinct();

                //int ixx = 0;

                //foreach (var itexm in sifiricerenSatirlar)
                //{
                //    foreach (DataRow drr in dtDetails.AsEnumerable().Where(x => x.Field<int>("BelgeNumarasi") == Convert.ToInt32(itexm) && x.Field<double>("OnaylananMiktar") > 0))
                //    {
                //        drr["SiraNo"] = ixx.ToString();

                //        ixx++;
                //    }
                //}

                //dtDetails.AcceptChanges();

                //inventoryGenEntry..DocDueDate = dtpTransferDate.Value.ToString("yyyyMMdd");

                foreach (DataRow items in dtDetails.Rows)
                {
                    if (items["OnaylananMiktar"].ToString() == "0" || items["OnaylananMiktar"].ToString() == "")
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
                        Quantity = Math.Round(Convert.ToDouble(items["OnaylananMiktar"]), Giris.genelParametreler.OndalikMiktar),
                        BaseEntry = Convert.ToInt32(items["BelgeNumarasi"]),
                        BaseType = 1250000001,
                        BaseLine = Convert.ToInt32(items["SiraNo"]),
                        taslakGercek = items["TaslakGercek"].ToString()
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

                //if (sifiricerenSatirlar.Count() > 0)
                //{
                //    foreach (var item in sifiricerenSatirlar)
                //    {
                //        int ixxx = 0;
                //        foreach (var itemx in inventoryGenEntry.InventoryGenEntryLines.Where(x => x.BaseEntry == item))
                //        {
                //            itemx.BaseLine = ixxx;
                //            ixxx++;
                //        }
                //    }
                //}

                var resp1 = aIFTerminalServiceSoapClient1.AddOrUpdateStockTransfer_2(Giris._dbName, Convert.ToInt32(Giris._userCode), inventoryGenEntry);

                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

                if (resp1.Val == 0)
                {
                    TalebeBagliDepoNakli_1_Kabul.formAciliyor = true;
                    TalebeBagliDepoNakli_1_Kabul.dialogresult = "Ok";
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

                    TalebeBagliDepoNakli_3_Kabul n = new TalebeBagliDepoNakli_3_Kabul("1250000001", list, "TALEP KABUL");
                    n.ShowDialog();
                    n.Dispose();
                    GC.Collect();

                    var quantity = inventoryGenEntryBatches.Where(x => x.DocEntry == DocEntry && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                    dtDetails.Rows[currentRow]["OnaylananMiktar"] = quantity;

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
            //            dtDetails.Rows[currentRow]["OnaylananMiktar"] = PartisizKalemSecimi.quantity;
            //            //dtDetails.AcceptChanges();
            //            if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["Miktar"].Value), 4) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["OnaylananMiktar"].Value), 4))
            //            {
            //                dtgDetails.Rows[currentRow].Cells["OnaylananMiktar"].Style.BackColor = Color.LimeGreen;
            //            }
            //            else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["OnaylananMiktar"].Value), 4) == 0)
            //            {
            //                dtgDetails.Rows[currentRow].Cells["OnaylananMiktar"].Style.BackColor = defaultColor;
            //            }
            //            else
            //            {
            //                dtgDetails.Rows[currentRow].Cells["OnaylananMiktar"].Style.BackColor = Color.OrangeRed;
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
                        dtgDetails.Columns["OnaylananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
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
                        dtgDetails.Columns["OnaylananMiktar"].DisplayIndex = 7;
                        dtgDetails.Columns["Partili"].DisplayIndex = 8;
                        dtgDetails.Columns["DepoKodu"].DisplayIndex = 9;
                        dtgDetails.Columns["SiraNo"].DisplayIndex = 10;

                        dtgDetails.Columns["BelgeNumarasi"].HeaderText = "BELGE NO";
                        dtgDetails.Columns["KalemKodu"].HeaderText = "KALEM KODU";
                        dtgDetails.Columns["KalemAdi"].HeaderText = "KALEM ADI";
                        dtgDetails.Columns["Barkod"].HeaderText = "BARKOD";
                        dtgDetails.Columns["Miktar"].HeaderText = "MİKTAR";
                        dtgDetails.Columns["OlcuBirimi"].HeaderText = "BRM";
                        dtgDetails.Columns["OnaylananMiktar"].HeaderText = "TOPLANAN MİKTAR";
                        dtgDetails.Columns["DepoMiktar"].HeaderText = "STOKTA";

                        dtgDetails.Columns["Partili"].Visible = false;
                        dtgDetails.Columns["DepoKodu"].Visible = false;
                        dtgDetails.Columns["SiraNo"].Visible = false;
                        dtgDetails.Columns["Barkod"].Visible = false;

                        dtgDetails.EnableHeadersVisualStyles = false;
                        dtgDetails.RowTemplate.Height = 55;

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
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
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

                        //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD) });

                        #endregion old

                        if (barcode == "")
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD) });
                        }
                        else
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD) });
                        }
                    }
                }
                else
                {
                    #region old

                    //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD) });

                    #endregion old

                    if (barcode == "")
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD) });
                    }
                    else
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD) });
                    }
                }
            }
            else
            {
                #region old

                //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD) });

                #endregion old

                if (barcode == "")
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD) });
                }
                else
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD) });
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
    }
}