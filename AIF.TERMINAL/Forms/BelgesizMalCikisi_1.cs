using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class BelgesizMalCikisi_1 : form_Base
    {
        //start font.
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //end font

        public static string wareHouse = "";
        public static string arananItemCode = "";
        private string partino = "";
        private string partili = "";
        private string barcode = "";
        private string depoYeriId = "";
        private string depoYeriAdi = "";
        private string itemCode = "";
        private string itemName = "";
        public static int currentRow = 0;
        private double acceptqty = 0;
        private double paletIciKoliAD = 0;
        private double koliIciAD = 0;
        private double paletIciAD = 0;
        private int DocEntry = -1;

        private double topMik = 0;

        private DataTable dtProducts = new DataTable();

        private string paletNo = "";

        public static List<InventoryGenExitBatch> inventoryGenExitBatches = new List<InventoryGenExitBatch>();
        private string formName = "";
        string olcuBirimi = "";
        public BelgesizMalCikisi_1(string _formName)
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

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label4.Font.Style);

            label5.Font = new Font(label5.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label5.Font.Style);

            lblItemName.Font = new Font(lblItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemName.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            dtpDocDate.Font = new Font(dtpDocDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpDocDate.Font.Style);

            cmbWareHouse.Font = new Font(cmbWareHouse.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbWareHouse.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbItemName.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                richTextBox1.Font.Style);

            btnAdd.Font = new Font(btnAdd.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAdd.Font.Style);

            btnSearch.Font = new Font(btnSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSearch.Font.Style);

            btnAddOrUpdate.Font = new Font(btnAddOrUpdate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAddOrUpdate.Font.Style);

            btnBarkodGoster.Font = new Font(btnBarkodGoster.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBarkodGoster.Font.Style);

            dtgProducts.Font = new Font(dtgProducts.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgProducts.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtDepoYeri.Font = new Font(txtDepoYeri.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtDepoYeri.Font.Style);

            txtDepoYeriAdi.Font = new Font(txtDepoYeriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtDepoYeriAdi.Font.Style);

            btnBarkodPalet.Font = new Font(btnBarkodPalet.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBarkodPalet.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            dtpDocDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbWareHouse.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtDepoYeri.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtDepoYeriAdi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private void BelgesizMalCikisi_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            //cmbItemName.DropDownWidth = cmbItemName.Width + btnSearch.Width;
            //cmbItemName.Font = new Font("Tahoma", 26);
            //cmbWareHouse.Font = new Font("Tahoma", 26);

            //dtpDocDate.Format = DateTimePickerFormat.Custom;
            //dtpDocDate.CustomFormat = "dd-MM-yyyy";

            txtBarCode.Focus();

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = null;

            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_BlgszMalC", Giris.mKodValue);
            }

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    cmbWareHouse.DataSource = resp._list;
                    cmbWareHouse.DisplayMember = "WhsName";
                    cmbWareHouse.ValueMember = "WhsCode";
                    cmbWareHouse.Enabled = true;
                }
            }

            dtProducts.Columns.Add("KalemKodu", typeof(string));
            dtProducts.Columns.Add("KalemAdi", typeof(string));
            dtProducts.Columns.Add("Barkod", typeof(string));
            dtProducts.Columns.Add("OlcuBirimi", typeof(string));
            dtProducts.Columns.Add("DepoMiktar", typeof(double));
            dtProducts.Columns.Add("ToplananMiktar", typeof(double));
            dtProducts.Columns.Add("Partili", typeof(string));

            dtProducts.Columns.Add("PaletIciKoliAD", typeof(double));
            dtProducts.Columns.Add("KoliIciAD", typeof(double));
            dtProducts.Columns.Add("PaletIciAD", typeof(double));

            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                dtProducts.Columns.Add("DepoYeriId", typeof(string));
                dtProducts.Columns.Add("DepoYeriAdi", typeof(string));
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            btn = new DataGridViewButtonColumn();
            dtgProducts.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Detay";
            btn.Name = "btnDetail";
            btn.UseColumnTextForButtonValue = true;

            dtgProducts.DataSource = dtProducts;

            dtgProducts.Columns["DepoMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
            dtgProducts.Columns["ToplananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

            dtgProducts.Columns["KalemKodu"].HeaderText = " KALEM KODU";
            dtgProducts.Columns["KalemAdi"].HeaderText = "KALEM ADI";
            dtgProducts.Columns["OlcuBirimi"].HeaderText = "BRM";
            dtgProducts.Columns["DepoMiktar"].HeaderText = "STOK";
            dtgProducts.Columns["ToplananMiktar"].HeaderText = "TOP.MİK";
            dtgProducts.Columns["Partili"].HeaderText = "PARTİLİ";

            dtgProducts.Columns["Barkod"].Visible = false;
            dtgProducts.Columns["btnDetail"].Visible = false;
            dtgProducts.Columns["KalemKodu"].Visible = false;
            dtgProducts.Columns["Partili"].Visible = false;

            dtgProducts.Columns["PaletIciKoliAD"].Visible = false;
            dtgProducts.Columns["KoliIciAD"].Visible = false;
            dtgProducts.Columns["PaletIciAD"].Visible = false;

            dtgProducts.Columns["Partili"].ReadOnly = true;
            dtgProducts.Columns["KalemKodu"].ReadOnly = true;
            dtgProducts.Columns["KalemAdi"].ReadOnly = true;
            dtgProducts.Columns["OlcuBirimi"].ReadOnly = true;
            dtgProducts.Columns["DepoMiktar"].ReadOnly = true;
            dtgProducts.Columns["ToplananMiktar"].ReadOnly = true;

            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                txtDepoYeri.Visible = false;
                txtDepoYeriAdi.Visible = false;
            }
            else
            {
                dtgProducts.Columns["DepoYeriId"].HeaderText = "DEPO YERI";
                dtgProducts.Columns["DepoYeriAdi"].HeaderText = "DEPO YERI ADI";
            }

            //dtgProducts.Columns["KalemKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["OlcuBirimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["DepoMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["ToplananMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtgProducts.Columns["Partili"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dtgProducts.Columns["KalemAdi"].Width = dtgProducts.Width - dtgProducts.Columns["OlcuBirimi"].Width -
            //    dtgProducts.Columns["DepoMiktar"].Width - dtgProducts.Columns["ToplananMiktar"].Width;

            dtgProducts.Columns["DepoMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgProducts.Columns["ToplananMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgProducts.EnableHeadersVisualStyles = false;
            dtgProducts.RowTemplate.Height = 55;
            dtgProducts.ColumnHeadersHeight = 60;

            vScrollBar1.Maximum = dtgProducts.RowCount + 5;

            foreach (DataGridViewColumn column in dtgProducts.Columns) //columns tıklayınca girişe atıyor
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //dtgPurchaseOrders.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            if (dtgProducts.Rows.Count > 0)
            {
                dtgProducts.Rows[0].Selected = false;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string ItemCode = "";
                //string partili = "";
                wareHouse = cmbWareHouse.SelectedValue.ToString();

                if (wareHouse == "")
                {
                    CustomMsgBox.Show("ÇIKIŞ DEPO SEÇİMİ YAPILMADAN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                    txtBarCode.Text = "";
                    return;
                }

                double warehouseQty = 0;
                List<dynamic> list = new List<dynamic>();
                string Val = txtBarCode.Text;

                string tip = "";

                if (doubleclick)
                {
                    if (paletNo != "")
                    {
                        tip = "PALET";
                    }
                    else
                    {
                        tip = "BARKOD";
                    }
                }
                else
                {
                    tip = btnBarkodPalet.Text;
                }

                if (tip == "BARKOD")
                {
                    partino = Giris.UrunKoduBarkod(txtBarCode.Text, "Parti");
                    Val = Giris.UrunKoduBarkod(txtBarCode.Text, "Barkod");

                    if (Val == "")
                    {
                        CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "Tamam", "");
                        return;
                    }

                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    Response resp = new Response();
                    if (Val != "TANIMSIZ")
                    {
                        resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, wareHouse, Giris.mKodValue);
                    }
                    else
                    {
                        if (arananItemCode != null)
                        {
                            Val = arananItemCode;
                            //resp._list = new DataTable();
                        }
                        else
                        {
                            Val = "";
                        }
                    }

                    if (resp._list == null)
                    {
                        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, wareHouse, "", Giris.mKodValue);
                    }

                    if (resp._list != null)
                    {
                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            try
                            {
                                resp._list.Columns.Add("DepoYeriId", typeof(string));
                                resp._list.Columns.Add("DepoYeriAdi", typeof(string));

                                DataColumnCollection columns = dtProducts.Columns;
                                if (!columns.Contains("DepoYeriId"))
                                {
                                    dtProducts.Columns.Add("DepoYeriId", typeof(string));
                                }

                                if (!columns.Contains("DepoYeriAdi"))
                                {
                                    dtProducts.Columns.Add("DepoYeriAdi", typeof(string));
                                }

                            }
                            catch (Exception)
                            {
                            }
                        }

                        //dtProducts = resp._list;
                        foreach (DataRow item in resp._list.Rows)
                        {
                            DataRow dr = dtProducts.NewRow();
                            dr["KalemKodu"] = item["Kalem Kodu"];
                            dr["KalemAdi"] = item["Kalem Tanımı"];
                            dr["Barkod"] = item["Barkod"];
                            dr["OlcuBirimi"] = item["Ölçü Birimi"];
                            try
                            {
                                dr["DepoMiktar"] = item["Depo Miktari"];
                            }
                            catch (Exception)
                            {
                                dr["Miktar"] = item["Depo Miktari"];
                            }
                            dr["Partili"] = item["Partili"];

                            dr["PaletIciKoliAD"] = item["PaletIciKoliAD"];
                            dr["KoliIciAD"] = item["KoliIciAD"];
                            dr["PaletIciAD"] = item["PaletIciAD"];

                            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                            {
                                dr["DepoYeriId"] = txtDepoYeri.Text.ToString();
                                dr["DepoYeriAdi"] = txtDepoYeriAdi.Text.ToString();

                                item["DepoYeriId"] = txtDepoYeri.Text.ToString();
                                item["DepoYeriAdi"] = txtDepoYeriAdi.Text.ToString();
                            }

                            partili = item["Partili"].ToString();

                            ItemCode = item["Kalem Kodu"].ToString();
                            list.Add(item["Kalem Kodu"]);
                            list.Add(item["Kalem Tanımı"]);
                            list.Add(item["Barkod"]);
                            list.Add(item["Ölçü Birimi"]);
                            list.Add(item["Depo Miktari"]);

                            list.Add(item["PaletIciKoliAD"]);
                            list.Add(item["KoliIciAD"]);
                            list.Add(item["PaletIciAD"]);
                            //if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                            //{
                            list.Add(partino);
                            partino = "";
                            //}

                            list.Add(wareHouse);
                            list.Add(txtDepoYeri.Text);
                            if (dtgProducts.Columns.Contains("DepoKodu") != true)
                            {
                                addcombo();
                            }

                            if (!doubleclick)
                            {
                                dtProducts.Rows.Add(dr);
                            }

                                (dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = wareHouse;
                        }

                        if (partili == "Y")
                        {
                            if (!doubleclick)
                            {
                                currentRow = dtProducts.Rows.Count;
                            }

                            SipariseBagliTeslimat_3 n = new SipariseBagliTeslimat_3("60", list, "BELGESİZ MAL ÇIKIŞI");
                            n.ShowDialog();
                            n.Dispose();
                            GC.Collect();

                            if (SipariseBagliTeslimat_3.dialogResult != "Ok")
                            {
                                if (!doubleclick)
                                {
                                    dtProducts.Rows.RemoveAt(currentRow - 1);
                                    dtgProducts.Refresh();
                                }
                            }
                            else
                            {
                                var quantity = inventoryGenExitBatches.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow && (x.Palet == null || x.Palet == false)).Sum(y => y.BatchQuantity);

                                dtProducts.Rows[currentRow - 1]["ToplananMiktar"] = quantity;
                                dtgProducts.Refresh();
                            }

                            SipariseBagliTeslimat_3.dialogResult = "";
                        }
                        else
                        {
                            //dtProducts.Rows[dtProducts.Rows.Count - 1]["ToplananMiktar"] = "1";
                            if (wareHouse == "")
                            {
                                CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ.", "Uyarı", "TAMAM", "");
                                return;
                            }
                            //ItemCode = "";

                            list = new List<dynamic>();
                            Val = txtBarCode.Text;

                            if (Val == "")
                            {
                                CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "TAMAM", "");
                                return;
                            }

                            if (!doubleclick)
                            {
                                currentRow = dtgProducts.Rows.Count;
                            }

                            //ItemCode = resp._list.Rows[0]["Kalem Kodu"].ToString();
                            list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                            list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                            list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);
                            list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                            list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                            list.Add(Math.Round(acceptqty, Giris.genelParametreler.OndalikMiktar).ToString());

                            var toplananmiktar = dtgProducts.Rows[currentRow - 1].Cells["ToplananMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgProducts.Rows[currentRow - 1].Cells["ToplananMiktar"].Value);

                            list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString());

                            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                            {
                                list.Add(resp._list.Rows[0]["DepoYeriId"]);
                                list.Add(resp._list.Rows[0]["DepoYeriAdi"]);
                                list.Add(cmbWareHouse.Text.ToString());
                                list.Add(cmbWareHouse.SelectedValue.ToString());
                            }

                            txtBarCode.Text = "";

                            PartisizKalemSecimi n = new PartisizKalemSecimi("60", list, "BELGESİZ MAL ÇIKIŞI");
                            n.ShowDialog();
                            n.Dispose();
                            GC.Collect();

                            if (PartisizKalemSecimi.dialogresult == "Ok")
                            {
                                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                                {
                                    dtProducts.Rows[currentRow - 1]["DepoYeriId"] = PartisizKalemSecimi.depoYeriId;
                                    dtProducts.Rows[currentRow - 1]["DepoYeriAdi"] = PartisizKalemSecimi.depoYeriAdi;
                                    PartisizKalemSecimi.depoYeriId = "";
                                    PartisizKalemSecimi.depoYeriAdi = "";
                                }
                                dtProducts.Rows[currentRow - 1]["ToplananMiktar"] = PartisizKalemSecimi.quantity;
                                PartisizKalemSecimi.dialogresult = "";
                                dtgProducts.Rows[currentRow - 1].Selected = false;
                            }
                            else
                            {
                                if (!doubleclick)
                                {
                                    dtProducts.Rows.RemoveAt(currentRow - 1);
                                    dtgProducts.Refresh();
                                    //dtgProducts.DataSource = dtProducts;
                                }
                            }
                            partili = "";
                            barcode = "";
                        }

                        dtgProducts.Columns["DepoKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        //dtgProducts.Columns["KalemAdi"].Width = dtgProducts.Width - dtgProducts.Columns["OlcuBirimi"].Width - dtgProducts.Columns["DepoMiktar"].Width - dtgProducts.Columns["ToplananMiktar"].Width - dtgProducts.Columns["DepoKodu"].Width;

                        txtBarCode.Focus();
                        txtBarCode.Text = "";
                        cmbItemName.Text = "";
                        arananItemCode = "";
                        txtItemName.Text = "";

                        btnSearch.PerformClick();
                        cmbItemName.DroppedDown = false;
                        vScrollBar1.Maximum = dtgProducts.RowCount + 5;

                        try
                        {
                            if (dtgProducts.Rows.Count > 0)
                            {
                                dtgProducts.Rows[currentRow - 1].Selected = false;
                            }
                            else
                            {
                                txtBarCode.Select(0, txtBarCode.Text.Length);

                                //CustomMsgBox.Show(resp.Desc, "Uyarı", "TAMAM", "");
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        txtBarCode.Select(0, txtBarCode.Text.Length);
                        CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                    }
                }
                else if (tip == "PALET")
                {
                    if (!doubleclick)
                    {
                        if (Val == "")
                        {
                            CustomMsgBox.Show("LÜTFEN PALET NUMARASI GİRİNİZ.", "Uyarı", "Tamam", "");
                            return;
                        }

                        if (dtgProducts.Columns.Contains("PaletNo"))
                        {
                            var dahaoncepaleteklenmis = dtProducts.AsEnumerable().Where(x => x.Field<string>("PaletNo") == Val.ToString()).ToList().Count;

                            if (dahaoncepaleteklenmis > 0)
                            {
                                CustomMsgBox.Show("BU PALET DAHA ÖNCE EKLENMİŞTİR. TEKRAR EKLENEMEZ", "Uyarı", "Tamam", "");
                                return;
                            }
                        }

                        AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                        Response resp = null;
                        Response resp1 = null;
                        resp = aIFTerminalServiceSoapClient.PaletKalemleriniGetir(Giris._dbName, Val, wareHouse, Giris.mKodValue);

                        if (resp == null || resp._list == null)
                        {
                            CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                            return;
                        }


                        Dictionary<int, string> oncedensecilenler = new Dictionary<int, string>()
                    {
                         { -1, "BOS" },
                    };



                        for (int i = 0; i <= dtgProducts.Rows.Count - 1; i++)
                        {
                            if (dtgProducts.Rows[i].Cells["DepoKodu"].Value != DBNull.Value && dtgProducts.Rows[i].Cells["DepoKodu"].Value != null && dtgProducts.Rows[i].Cells["DepoKodu"].Value.ToString() != "")
                            {
                                oncedensecilenler.Add(i, dtgProducts.Rows[i].Cells["DepoKodu"].Value.ToString());
                            }
                        }

                        if (resp._list.Rows.Count > 0)
                        {
                            //dtProducts = resp._list;
                            DataColumnCollection columns = dtProducts.Columns;
                            if (!columns.Contains("PaletNo"))
                            {
                                dtProducts.Columns.Add("PaletNo", typeof(string));
                                dtProducts.Columns.Add("DetaySatirNo", typeof(string));
                                //dtProducts.Columns.Add("DepoKoduPlt", typeof(string));
                            }

                            foreach (DataRow dr2 in resp._list.Rows)
                            {
                                DataRow dryeni = dtProducts.NewRow();
                                dryeni["PaletNo"] = dr2["PaletNo"].ToString();
                                dryeni["KalemKodu"] = dr2["KalemKodu"].ToString();
                                dryeni["KalemAdi"] = dr2["KalemAdi"].ToString();
                                dryeni["OlcuBirimi"] = dr2["OlcuBirimi"].ToString();
                                dryeni["Barkod"] = dr2["Barkod"].ToString();
                                dryeni["Partili"] = dr2["Partili"].ToString();
                                dryeni["DepoMiktar"] = Convert.ToDouble(dr2["Miktar"]);
                                //dryeni["DepoAdi"] = dr2["DepoAdi"].ToString();
                                //dryeni["DepoKoduPlt"] = dr2["DepoKoduPlt"].ToString();
                                dryeni["ToplananMiktar"] = Convert.ToDouble(dr2["ToplananMiktar"]);
                                dryeni["PaletIciKoliAD"] = dr2["PaletIciKoliAD"].ToString();
                                dryeni["KoliIciAD"] = dr2["KoliIciAD"].ToString();
                                //dryeni["MuhatapKatalogNo"] = dr2["MuhatapKatalogNo"].ToString();
                                dryeni["DetaySatirNo"] = Convert.ToInt32(dr2["DetaySatirNo"]);
                                dryeni["DepoYeriId"] = dr2["DepoYeriId"].ToString();
                                dryeni["DepoYeriAdi"] = dr2["DepoYeriAdi"].ToString();

                                dtProducts.Rows.Add(dryeni);

                                if (dtgProducts.Columns.Contains("DepoKodu") != true)
                                {
                                    addcombo();
                                }

                                //if ((dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value == null)
                                //{
                                //    (dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = dr2["DepoKoduPlt"].ToString();
                                //}
                                oncedensecilenler.Add(dtgProducts.Rows.Count - 1, dr2["DepoKoduPlt"].ToString());


                            }
                            dtgProducts.DataSource = dtProducts;

                            //for (int i = 0; i <= dtgProducts.Rows.Count - 1; i++)
                            //{
                            //    if (dtgProducts.Rows[i].Cells["DepoKoduPlt"].Value != DBNull.Value)
                            //    {
                            //        (dtgProducts.Rows[i].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = dtgProducts.Rows[i].Cells["DepoKoduPlt"].Value;
                            //    }
                            //}

                            foreach (var item in oncedensecilenler.Where(x => x.Key != -1))
                            {
                                (dtgProducts.Rows[item.Key].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = item.Value;
                            }

                            //try
                            //{
                            //    dtgProducts.Columns.Remove("DepoKoduPlt");
                            //}
                            //catch (Exception)
                            //{

                            //    throw;
                            //}

                            dtgProducts.Columns["PaletNo"].ReadOnly = true;
                            dtgProducts.Columns["KalemKodu"].ReadOnly = true;
                            dtgProducts.Columns["KalemAdi"].ReadOnly = true;
                            dtgProducts.Columns["OlcuBirimi"].ReadOnly = true;
                            dtgProducts.Columns["Barkod"].ReadOnly = true;
                            dtgProducts.Columns["Partili"].ReadOnly = true;
                            dtgProducts.Columns["DepoMiktar"].ReadOnly = true;
                            //dtgProducts.Columns["DepoKoduPlt"].ReadOnly = true;
                            //dtgProducts.Columns["DepoAdi"].ReadOnly = true;
                            dtgProducts.Columns["ToplananMiktar"].ReadOnly = true;
                            dtgProducts.Columns["PaletIciKoliAD"].ReadOnly = true;
                            dtgProducts.Columns["KoliIciAD"].ReadOnly = true;
                            dtgProducts.Columns["PaletIciAD"].ReadOnly = true;
                            //dtgProducts.Columns["MuhatapKatalogNo"].ReadOnly = true;
                            dtgProducts.Columns["DetaySatirNo"].ReadOnly = true;
                            //if (Giris.genelParametreler.DepoYeriCalisir != "Y")
                            //{
                            //    txtDepoYeri.Visible = false;
                            //    txtDepoYeriAdi.Visible = false;
                            //}
                            //else
                            //{
                            //    dtgProducts.Columns["DepoYeriId"].HeaderText = "DEPO YERI";
                            //    dtgProducts.Columns["DepoYeriAdi"].HeaderText = "DEPO YERI ADI";
                            //}
                            dtgProducts.Columns["DepoMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                            dtgProducts.Columns["ToplananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                            //dtgProducts.Columns["KalemKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dtgProducts.Columns["OlcuBirimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dtgProducts.Columns["DepoMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dtgProducts.Columns["ToplananMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            //dtgProducts.Columns["Partili"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                            //dtgProducts.Columns["KalemAdi"].Width = dtgProducts.Width - dtgProducts.Columns["OlcuBirimi"].Width -
                            //    dtgProducts.Columns["DepoMiktar"].Width - dtgProducts.Columns["ToplananMiktar"].Width;

                            dtgProducts.Columns["DepoMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dtgProducts.Columns["ToplananMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            if (dtgProducts.Columns.Contains("DepoKodu") != true)
                            {
                                addcombo();

                            }
                            //(dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = wareHouse;

                            //for (int i = 0; i <= dtgProducts.Rows.Count - 1; i++)
                            //{
                            //    (dtgProducts.Rows[i].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = dtgProducts.Rows[i].Cells["DepoKoduPlt"].Value;
                            //}

                            resp1 = aIFTerminalServiceSoapClient.PaletPartiDetaylariniGetir(Giris._dbName, Val, Giris.mKodValue);

                            if (resp1 == null || resp1._list == null)
                            {
                                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");
                                return;
                            }

                            if (resp1._list.Rows.Count > 0)
                            {
                                DataTable dtPaletParti = new DataTable();
                                dtPaletParti = resp1._list;
                                //inventoryGenExitBatches = new List<InventoryGenExitBatch>();
                                foreach (DataRow item in dtPaletParti.Rows)
                                {
                                    inventoryGenExitBatches.Add(new InventoryGenExitBatch
                                    {
                                        BatchNumber = item["PartiNo"].ToString(),
                                        BatchQuantity = Convert.ToDouble(item["Miktar"]),
                                        ItemCode = item["KalemKodu"].ToString(),
                                        LineNumber = Convert.ToInt32(item["PartiSatirNo"]), //currentRow,
                                        DepoYeriId = item["DepoYeriId"].ToString(),
                                        DepoYeriAdi = item["DepoYeriAdi"].ToString(),
                                        Palet = true
                                    });
                                }

                            }
                        }
                        else
                        {
                            CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                            return;
                        }

                    }
                    else if (doubleclick)
                    {
                        if (partili == "Y")
                        {
                            list.Add(itemCode);
                            list.Add(itemName);
                            list.Add(barcode);
                            list.Add(olcuBirimi);
                            list.Add(topMik);

                            list.Add(paletIciKoliAD);
                            list.Add(koliIciAD);
                            list.Add(paletIciAD);
                            //if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                            //{
                            list.Add("");
                            //list.Add(partino);
                            partino = "";
                            //}

                            list.Add(wareHouse);
                            list.Add(txtDepoYeri.Text);

                            if (!doubleclick)
                            {
                                currentRow = dtProducts.Rows.Count;
                            }

                            SipariseBagliTeslimat_3 n = new SipariseBagliTeslimat_3("PALET", list, "BELGESİZ MAL ÇIKIŞI");
                            n.ShowDialog();
                            n.Dispose();
                            GC.Collect();

                            if (SipariseBagliTeslimat_3.dialogResult != "Ok")
                            {
                                if (!doubleclick)
                                {
                                    dtProducts.Rows.RemoveAt(currentRow - 1);
                                    dtgProducts.Refresh();
                                }
                            }
                            else
                            {
                                var quantity = inventoryGenExitBatches.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                                dtProducts.Rows[currentRow - 1]["ToplananMiktar"] = quantity;
                                dtgProducts.Refresh();
                            }

                        }
                        else
                        {
                            //dtProducts.Rows[dtProducts.Rows.Count - 1]["ToplananMiktar"] = "1";
                            if (wareHouse == "")
                            {
                                CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ.", "Uyarı", "TAMAM", "");
                                return;
                            }
                            //ItemCode = "";

                            list = new List<dynamic>();
                            Val = txtBarCode.Text;

                            if (Val == "")
                            {
                                CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "TAMAM", "");
                                return;
                            }

                            if (!doubleclick)
                            {
                                currentRow = dtgProducts.Rows.Count;
                            }

                            //ItemCode = resp._list.Rows[0]["Kalem Kodu"].ToString();
                            list.Add(itemCode);
                            list.Add(itemName);
                            list.Add(barcode == "" ? "Tanımsız" : barcode);
                            list.Add(olcuBirimi);
                            list.Add(Math.Round(Convert.ToDouble(topMik), Giris.genelParametreler.OndalikMiktar));
                            list.Add(Math.Round(acceptqty, Giris.genelParametreler.OndalikMiktar).ToString());

                            var toplananmiktar = dtgProducts.Rows[currentRow - 1].Cells["ToplananMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgProducts.Rows[currentRow - 1].Cells["ToplananMiktar"].Value);

                            list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString());

                            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                            {
                                list.Add(depoYeriId);
                                list.Add(depoYeriAdi);
                                list.Add(cmbWareHouse.Text.ToString());
                                list.Add(cmbWareHouse.SelectedValue.ToString());
                            }

                            txtBarCode.Text = "";

                            PartisizKalemSecimi n = new PartisizKalemSecimi("PALET", list, "BELGESİZ MAL ÇIKIŞI");
                            n.ShowDialog();
                            n.Dispose();
                            GC.Collect();

                            if (PartisizKalemSecimi.dialogresult == "Ok")
                            {
                                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                                {
                                    dtProducts.Rows[currentRow - 1]["DepoYeriId"] = PartisizKalemSecimi.depoYeriId;
                                    dtProducts.Rows[currentRow - 1]["DepoYeriAdi"] = PartisizKalemSecimi.depoYeriAdi;
                                    PartisizKalemSecimi.depoYeriId = "";
                                    PartisizKalemSecimi.depoYeriAdi = "";
                                }
                                dtProducts.Rows[currentRow - 1]["ToplananMiktar"] = PartisizKalemSecimi.quantity;
                                PartisizKalemSecimi.dialogresult = "";
                                dtgProducts.Rows[currentRow - 1].Selected = false;
                            }
                            else
                            {
                                if (!doubleclick)
                                {
                                    dtProducts.Rows.RemoveAt(currentRow - 1);
                                    dtgProducts.Refresh();
                                    //dtgProducts.DataSource = dtProducts;
                                }
                            }
                            partili = "";
                            barcode = "";
                        }

                        dtgProducts.Columns["DepoKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        //dtgProducts.Columns["KalemAdi"].Width = dtgProducts.Width - dtgProducts.Columns["OlcuBirimi"].Width - dtgProducts.Columns["DepoMiktar"].Width - dtgProducts.Columns["ToplananMiktar"].Width - dtgProducts.Columns["DepoKodu"].Width;

                        txtBarCode.Focus();
                        txtBarCode.Text = "";
                        cmbItemName.Text = "";
                        arananItemCode = "";
                        txtItemName.Text = "";

                        btnSearch.PerformClick();
                        cmbItemName.DroppedDown = false;
                        vScrollBar1.Maximum = dtgProducts.RowCount + 5;

                        try
                        {
                            if (dtgProducts.Rows.Count > 0)
                            {
                                dtgProducts.Rows[currentRow - 1].Selected = false;
                            }
                            else
                            {
                                txtBarCode.Select(0, txtBarCode.Text.Length);

                                //CustomMsgBox.Show(resp.Desc, "Uyarı", "TAMAM", "");
                            }
                        }
                        catch (Exception)
                        {
                        }


                        paletMi = false;
                        SipariseBagliTeslimat_3.dialogResult = "";
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void addcombo()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response r = null;

            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_BlgszMalC", Giris.mKodValue);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(r._list);

            DataGridViewComboBoxColumn comboLookup = new DataGridViewComboBoxColumn();
            comboLookup.DataSource = ds.Tables[0];
            comboLookup.HeaderText = "DEPO";
            comboLookup.Name = "DepoKodu";
            comboLookup.DisplayMember = "WhsName";
            comboLookup.ValueMember = "WhsCode";
            dtgProducts.Columns.Add(comboLookup);

            //DataGridViewColumn column = dtgProducts.Columns["DepoKodu"];
            //column.Width = 150;
        }
        public static int detaySatirNo = -1;
        public static bool paletMi = false;
        private void dtgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    List<dynamic> list = new List<dynamic>();
                    if (senderGrid.Columns[e.ColumnIndex].Name == "btnDetail")
                    {
                        currentRow = e.RowIndex + 1;

                        string ItemCode = dtProducts.Rows[e.RowIndex]["KalemKodu"].ToString();
                        list.Add(dtProducts.Rows[e.RowIndex]["KalemKodu"].ToString());
                        list.Add(dtProducts.Rows[e.RowIndex]["KalemAdi"].ToString());
                        list.Add(dtProducts.Rows[e.RowIndex]["Barkod"].ToString());
                        list.Add(dtProducts.Rows[e.RowIndex]["OlcuBirimi"].ToString());
                        list.Add(dtProducts.Rows[e.RowIndex]["DepoMiktar"].ToString());

                        SipariseBagliTeslimat_3 n = new SipariseBagliTeslimat_3("60", list, "BELGESİZ MAL ÇIKIŞI");
                        n.ShowDialog();
                        n.Dispose();
                        GC.Collect();

                        var quantity = inventoryGenExitBatches.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                        dtProducts.Rows[currentRow - 1]["ToplananMiktar"] = quantity;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void dtgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                paletMi = false;
                currentRow = e.RowIndex + 1;
                partili = dtProducts.Rows[e.RowIndex]["Partili"].ToString();
                barcode = dtProducts.Rows[e.RowIndex]["Barkod"].ToString();
                itemCode = dtProducts.Rows[e.RowIndex]["KalemKodu"].ToString();
                itemName = dtProducts.Rows[e.RowIndex]["KalemAdi"].ToString();
                txtBarCode.Text = barcode == "" ? itemCode : barcode;

                paletIciKoliAD = dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"]);
                koliIciAD = dtProducts.Rows[e.RowIndex]["KoliIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["KoliIciAD"]);
                paletIciAD = dtProducts.Rows[e.RowIndex]["PaletIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciAD"]);

                topMik = dtProducts.Rows[e.RowIndex]["ToplananMiktar"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["ToplananMiktar"]);
                if (Giris.genelParametreler.PaletYapmadaDepoSecilsin == "Y")
                {
                    if (dtgProducts.Columns.Contains("PaletNo"))
                    {
                        paletNo = dtProducts.Rows[e.RowIndex]["PaletNo"].ToString();
                        if (paletNo != "")
                        {
                            paletMi = true;

                        }
                        olcuBirimi = dtProducts.Rows[e.RowIndex]["OlcuBirimi"].ToString();
                        detaySatirNo = (dtProducts.Rows[e.RowIndex]["DetaySatirNo"] == DBNull.Value || dtProducts.Rows[e.RowIndex]["DetaySatirNo"] == null || dtProducts.Rows[e.RowIndex]["DetaySatirNo"] == "") ? -1 : Convert.ToInt32(dtProducts.Rows[e.RowIndex]["DetaySatirNo"]);
                    }
                    else
                    {
                        paletMi = false;
                    }


                }

                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    depoYeriId = dtProducts.Rows[e.RowIndex]["DepoYeriId"].ToString();
                    depoYeriAdi = dtProducts.Rows[e.RowIndex]["DepoYeriAdi"].ToString();
                }

                if (btnBarkodPalet.Text == "PALET")
                {
                    txtBarCode.Text = paletNo;

                }
            }
        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgProducts.Rows.Count == 0)
                {
                    //ne uyarısı yazılabilir buraya?
                    //CustomMsgBox.Show("Lütfen Çıkış Depo Seçimi Yapınız.", "Uyarı", "Tamam", "");
                    return;
                }

                if (cmbWareHouse.SelectedValue.ToString() == "")
                {
                    CustomMsgBox.Show("LÜTFEN ÇIKIŞ DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    return;
                }
                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                    return;
                }
                InventoryGenExit inventoryGenExit = new InventoryGenExit();
                InventoryGenExitLines inventoryGenExitLines = new InventoryGenExitLines();
                List<InventoryGenExitLines> inventoryGenExitLines1 = new List<InventoryGenExitLines>();
                List<InventoryGenExitLinesBatch> inventoryGenExitBatchList1 = new List<InventoryGenExitLinesBatch>();
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                int detaysatirno = -1;
                int i = 1;
                int index = 0;
                inventoryGenExit.DocDate = dtpDocDate.Value.ToString("yyyyMMdd");

                foreach (DataRow items in dtProducts.Rows)
                {
                    if (items["ToplananMiktar"].ToString() == "0")
                    {
                        continue;
                    }

                    try
                    {
                        detaySatirNo = Convert.ToInt32(items["DetaySatirNo"]);
                    }
                    catch (Exception)
                    {
                        detaySatirNo = -1;
                    }


                    inventoryGenExitBatchList1 = new List<InventoryGenExitLinesBatch>();
                    if (items["DetaySatirNo"] != DBNull.Value && items["DetaySatirNo"] != null && items["DetaySatirNo"].ToString() != "")
                    {
                        foreach (var aifx in inventoryGenExitBatches.Where(x => x.ItemCode == items["KalemKodu"].ToString() && x.LineNumber == detaySatirNo && (x.Palet != null && x.Palet == true)))
                        {
                            inventoryGenExitBatchList1.Add(new InventoryGenExitLinesBatch
                            {
                                BatchNumber = aifx.BatchNumber,
                                BatchQuantity = aifx.BatchQuantity,
                                DepoYeriId = aifx.DepoYeriId,
                                DepoYeriAdi = aifx.DepoYeriAdi
                            });
                        }
                    }
                    else
                    {
                        foreach (var aifx in inventoryGenExitBatches.Where(x => x.ItemCode == items["KalemKodu"].ToString() && x.LineNumber == i && (x.Palet == null || x.Palet == false)))
                        {
                            inventoryGenExitBatchList1.Add(new InventoryGenExitLinesBatch
                            {
                                BatchNumber = aifx.BatchNumber,
                                BatchQuantity = aifx.BatchQuantity,
                                DepoYeriId = aifx.DepoYeriId,
                                DepoYeriAdi = aifx.DepoYeriAdi
                            });
                        }

                    }

                    inventoryGenExitLines1.Add(new InventoryGenExitLines
                    {
                        InventoryGenExitLinesBatch = inventoryGenExitBatchList1.ToArray(),
                        ItemCode = items["KalemKodu"].ToString(),
                        Quantity = Math.Round(Convert.ToDouble(items["ToplananMiktar"]), Giris.genelParametreler.OndalikMiktar),
                        WareHouse = dtgProducts.Rows[index].Cells["DepoKodu"].Value.ToString(),
                        BinCode = Giris.genelParametreler.DepoYeriCalisir == "Y" && items["Partili"].ToString() != "Y" ? dtgProducts.Rows[index].Cells["DepoYeriId"].Value.ToString() : "",
                    });

                    inventoryGenExit.InventoryGenExitLines = inventoryGenExitLines1.ToArray();
                    i++;
                    index++;
                }

                if (inventoryGenExit.InventoryGenExitLines.Count() == 0)
                {
                    CustomMsgBox.Show("BELGENİN TÜM SATIRLARI 0 OLDUĞUNDAN DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                    return;
                }

                var resp1 = aIFTerminalServiceSoapClient1.AddOrUpdateInventoryGenExit(Giris._dbName, Convert.ToInt32(Giris._userCode), inventoryGenExit);

                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

                if (resp1.Val == 0)
                {
                    inventoryGenExitBatchList1 = new List<InventoryGenExitLinesBatch>();
                    Close();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void cmbWareHouse_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (dtgProducts.Rows.Count > 0)
            //{
            //    DialogResult dialog = MessageBox.Show("TÜM DEPOLARI DEĞİŞTİRMEYİ İSTİYOR MUSUNUZ?", "DEPO DEĞİŞİMİ", MessageBoxButtons.YesNo);

            //    if (dialog == DialogResult.Yes)
            //    {
            //        for (int i = 0; i <= dtgProducts.Rows.Count - 1; i++)
            //        {
            //            (dtgProducts.Rows[i].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = cmbWareHouse.SelectedValue;
            //        }
            //    }
            //    else
            //    {
            //    }
            //}

            try
            {
                if (cmbWareHouse.Text.ToString() != "" && cmbWareHouse.Text.ToString() != "System.Data.DataRowView")
                {
                    txtBarCode.ReadOnly = false;
                    txtBarCode.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void cmbWareHouse_Click(object sender, EventArgs e)
        {
            cmbWareHouse.DroppedDown = true;
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }

        private bool doubleclick = false;

        private void dtgProducts_DoubleClick(object sender, EventArgs e)
        {
            //if (partili == "Y")
            //{
            doubleclick = true;
            btnAdd.PerformClick();
            partili = "";
            barcode = "";
            doubleclick = false;
            return;
            //}
            //string ItemCode = "";
            //List<dynamic> list = new List<dynamic>();
            //string Val = txtBarCode.Text;

            //AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            //Response resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, wareHouse);

            //if (resp._list == null)
            //{
            //    resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, wareHouse);
            //}

            //if (resp._list != null)
            //{
            //    //dtProducts = resp._list;
            //    foreach (DataRow item in resp._list.Rows)
            //    {
            //        ItemCode = item["Kalem Kodu"].ToString();
            //        list.Add(item["Kalem Kodu"]);
            //        list.Add(item["Kalem Tanımı"]);
            //        list.Add(item["Barkod"].ToString() == "" ? "Tanımsız" : item["Barkod"]);

            //        list.Add(item["Ölçü Birimi"]);
            //        list.Add(item["Depo Miktari"]);

            //        PartisizKalemSecimi n = new PartisizKalemSecimi("60", list, "BELGESİZ MAL ÇIKIŞI");
            //        n.ShowDialog();

            //        if (PartisizKalemSecimi.dialogresult == "Ok")
            //        {
            //            dtProducts.Rows[currentRow]["ToplananMiktar"] = PartisizKalemSecimi.quantity;

            //        }
            //    }
            //}
            //partili = "";
            //barcode = "";
        }

        private DataTable dtProductsItem = new DataTable();
        private DataView dtview = new DataView();

        private void GetAllProducts()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetAllProducts(Giris._dbName, Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtProductsItem = resp._list;
                    dtview = new DataView(resp._list);
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
                        else
                        {
                            txtBarCode.Text = "TANIMSIZ";
                        }

                        dtgProducts.DataSource = dtProducts;

                        dtgProducts.Columns["DepoMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                        dtgProducts.Columns["ToplananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                        dtgProducts.Columns["KalemKodu"].HeaderText = " KALEM KODU";
                        dtgProducts.Columns["KalemAdi"].HeaderText = "KALEM ADI";
                        dtgProducts.Columns["OlcuBirimi"].HeaderText = "BRM";
                        dtgProducts.Columns["DepoMiktar"].HeaderText = "STOKTA";
                        dtgProducts.Columns["ToplananMiktar"].HeaderText = "TOPLANAN MİKTAR";
                        dtgProducts.Columns["Partili"].HeaderText = "PARTİLİ";

                        dtgProducts.Columns["Barkod"].Visible = false;
                        dtgProducts.Columns["btnDetail"].Visible = false;

                        dtgProducts.Columns["Partili"].ReadOnly = true;
                        dtgProducts.Columns["KalemKodu"].ReadOnly = true;
                        dtgProducts.Columns["KalemAdi"].ReadOnly = true;
                        dtgProducts.Columns["OlcuBirimi"].ReadOnly = true;
                        dtgProducts.Columns["DepoMiktar"].ReadOnly = true;
                        dtgProducts.Columns["ToplananMiktar"].ReadOnly = true;

                        btnAdd.PerformClick();
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbWareHouse.SelectedValue.ToString() == "" || cmbWareHouse.SelectedValue.ToString() == null)
            {
                CustomMsgBox.Show("LÜTFEN ÇIKIŞ DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }
            GetAllProducts();
            if (dtProductsItem.Rows.Count > 0)
            {
                dtview.RowFilter = "ItemName = '' or ItemName like '%" + cmbItemName.Text + "%'";

                //cmbItemName.DroppedDown = true;
                cmbItemName.DataSource = null;

                if (dtview.Count > 0)
                {
                    cmbItemName.DisplayMember = "ItemName";
                    cmbItemName.ValueMember = "ItemCode";
                    cmbItemName.DataSource = dtview;

                    cmbItemName.DroppedDown = true;
                }
                else
                {
                    CustomMsgBox.Show("ARAMA SONUCU EŞLEŞEN KAYIT BULUNAMAMIŞTIR.", "Uyarı", "TAMAM", "");
                }
            }
        }

        private void dtgProducts_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgProducts.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBarkodGoster_Click(object sender, EventArgs e)
        {
            ListParties = new List<Parties>();

            List<dynamic> list = new List<dynamic>();
            var partiler = inventoryGenExitBatches.Where(x => x.ItemCode == itemCode).ToList();
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
                    #region old

                    //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

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
            }
            else
            {
                #region old

                //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

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
            BarkodGoruntule barkodGoruntule = new BarkodGoruntule("60", ListParties, "BARKOD GÖRÜNTÜLEME");
            barkodGoruntule.ShowDialog();
            barkodGoruntule.Dispose();
            GC.Collect();
            if (dtgProducts.Rows.Count > 0)
            {
                dtgProducts.Rows[currentRow - 1].Selected = false;
            }
            ListParties = new List<Parties>();
        }

        public static List<Parties> ListParties = new List<Parties>();

        private void txtItemName_Click(object sender, EventArgs e)
        {
            if (cmbWareHouse.SelectedValue == "" || cmbWareHouse.SelectedValue == null)
            {
                CustomMsgBox.Show("LÜTFEN ÇIKIŞ DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }
            SelectList nesne = new SelectList("60", "KalemAra", "KALEM ARAMA", txtBarCode, txtItemName);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (SelectList.dialogResult == "Ok")
            {
                if (txtBarCode.Text == "")
                {
                    txtBarCode.Text = "TANIMSIZ";
                }
                btnAdd.PerformClick();
                SelectList.dialogResult = "";
            }
        }

        private void txtDepoYeri_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox t = new TextBox();
                t.Text = cmbWareHouse.SelectedValue.ToString();
                SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtDepoYeri, txtDepoYeriAdi, t);
                nesne.ShowDialog();
                nesne.Dispose();
                GC.Collect();

                if (SelectList.dialogResult == "Ok")
                {
                    SelectList.dialogResult = "";
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnBarkodPalet_Click(object sender, EventArgs e)
        {
            if (btnBarkodPalet.Text == "BARKOD")
            {
                btnBarkodPalet.Text = "PALET";
                txtBarCode.Focus();
            }
            else
            {
                btnBarkodPalet.Text = "BARKOD";
                txtBarCode.Focus();
            }
        }
    }
}