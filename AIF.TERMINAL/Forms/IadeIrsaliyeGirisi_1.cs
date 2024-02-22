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
    public partial class IadeIrsaliyeGirisi_1 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public IadeIrsaliyeGirisi_1(string _formName)
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

        private string formName = "";
        private DataTable dtProducts = new DataTable();

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

            label6.Font = new Font(label6.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label6.Font.Style);

            label7.Font = new Font(label7.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label7.Font.Style);

            label8.Font = new Font(label8.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label8.Font.Style);

            txtSupplierCode.Font = new Font(txtSupplierCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSupplierCode.Font.Style);

            txtSupplier.Font = new Font(txtSupplier.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSupplier.Font.Style);

            dtpTaxDate.Font = new Font(dtpTaxDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpTaxDate.Font.Style);

            txtWayBillNo.Font = new Font(txtWayBillNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWayBillNo.Font.Style);

            cmbWareHouse.Font = new Font(cmbWareHouse.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbWareHouse.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                richTextBox1.Font.Style);

            btnEkle.Font = new Font(btnEkle.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnEkle.Font.Style);

            dtgProducts.Font = new Font(dtgProducts.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               dtgProducts.Font.Style);

            btnSave.Font = new Font(btnSave.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSave.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            cmbSevkAdresi.Font = new Font(cmbSevkAdresi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbSevkAdresi.Font.Style);

            //start yükseklik-genislik
            txtSupplierCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtSupplier.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpTaxDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtWayBillNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbWareHouse.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            richTextBox1.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbSevkAdresi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            btnEkle.Height = txtBarCode.Height;
            //end yükseklik-genislik
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

        private void IadeIrsaliyeGirisi_1_Load(object sender, EventArgs e)
        {
            try
            {
                //Stopwatch watch = new Stopwatch();
                //watch.Start();
                txtBarCode.Focus();

                frmName.Text = formName.ToUpper();

                vScrollBar1.Maximum = dtgProducts.RowCount;
                dtProducts.Columns.Add("Kalem Kodu", typeof(string));
                dtProducts.Columns.Add("Kalem Tanımı", typeof(string));
                dtProducts.Columns.Add("Ölçü Birimi", typeof(string));
                dtProducts.Columns.Add("Barkod", typeof(string));
                dtProducts.Columns.Add("Miktar", typeof(double));
                dtProducts.Columns.Add("DepoMiktar", typeof(double));
                dtProducts.Columns.Add("Partili", typeof(string));
                dtProducts.Columns.Add("dtgSira", typeof(int));
                ////dtProducts.Columns.Add("DepoKodu", typeof(string));
                //dtProducts.Columns.Add("PaletIciKoliAD", typeof(double));
                //dtProducts.Columns.Add("KoliIciAD", typeof(double));
                //dtProducts.Columns.Add("PaletIciAD", typeof(double));

                dtgProducts.DataSource = dtProducts;
                dtgProducts.EnableHeadersVisualStyles = false;

                dtgProducts.Columns["DepoMiktar"].Visible = false;
                dtgProducts.Columns["Barkod"].Visible = false;
                //dtgProducts.Columns["btnDetail"].Visible = false;
                dtgProducts.Columns["dtgSira"].Visible = false;

                dtgProducts.Columns["Kalem Kodu"].Visible = false;
                dtgProducts.Columns["Partili"].Visible = false;

                //dtgProducts.Columns["PaletIciKoliAD"].Visible = false;
                //dtgProducts.Columns["KoliIciAD"].Visible = false;
                //dtgProducts.Columns["PaletIciAD"].Visible = false;

                dtgProducts.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                dtgProducts.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
                dtgProducts.Columns["Kalem Tanımı"].HeaderText = "KALEM ADI";
                dtgProducts.Columns["Ölçü Birimi"].HeaderText = "BRM";
                dtgProducts.Columns["Barkod"].HeaderText = "BARKOD";
                dtgProducts.Columns["Miktar"].HeaderText = "MİKTAR";
                dtgProducts.Columns["DepoMiktar"].HeaderText = "STOKTA";
                dtgProducts.Columns["Partili"].HeaderText = "PARTİLİ";

                dtgProducts.Columns["Kalem Kodu"].ReadOnly = true;
                dtgProducts.Columns["Kalem Tanımı"].ReadOnly = true;
                dtgProducts.Columns["Ölçü Birimi"].ReadOnly = true;
                dtgProducts.Columns["Miktar"].ReadOnly = true;
                dtgProducts.Columns["DepoMiktar"].ReadOnly = true;
                dtgProducts.Columns["Partili"].ReadOnly = true;

                dtgProducts.RowTemplate.Height = 55;
                dtgProducts.ColumnHeadersHeight = 60;

                //dtgProducts.Columns["Kalem Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgProducts.Columns["Ölçü Birimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgProducts.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgProducts.Columns["DepoMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dtgProducts.Columns["Partili"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dtgProducts.Columns["Kalem Tanımı"].Width = dtgProducts.Width - dtgProducts.Columns["Ölçü Birimi"].Width -
                //    dtgProducts.Columns["Miktar"].Width - dtgProducts.Columns["DepoMiktar"].Width;

                //DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();

                //btn2 = new DataGridViewButtonColumn();
                //dtgProducts.Columns.Add(btn2);
                //btn2.HeaderText = "";
                //btn2.Text = "Sil";
                //btn2.Name = "btnDelete";
                //btn2.UseColumnTextForButtonValue = true;

                vScrollBar1.Maximum = dtgProducts.RowCount + 5;

                foreach (DataGridViewColumn column in dtgProducts.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (dtgProducts.Rows.Count > 0)
                {
                    dtgProducts.Rows[0].Selected = false;
                }

                //watch.Stop();
                //MessageBox.Show(string.Format("Süre: {0}", watch.Elapsed.TotalMilliseconds));
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void txtSupplier_Click(object sender, EventArgs e)
        {
            SelectList nesne = new SelectList("20", "MusteriAra", "MÜŞTERİ ARAMA", txtSupplierCode, txtSupplier);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();
        }

        private void cmbWareHouse_Click(object sender, EventArgs e)
        {
            cmbWareHouse.DroppedDown = true;
        }

        private void cmbWareHouse_DropDown(object sender, EventArgs e)
        {
            try
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp1 = null;

                if (Giris.genelParametreler.DepoCalismaTipi == "1")
                {
                    resp1 = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
                }
                else if (Giris.genelParametreler.DepoCalismaTipi == "2")
                {
                    resp1 = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_SatisIade", Giris.mKodValue);
                }

                if (resp1.Val == 0)
                {
                    if (resp1._list.Rows.Count > 0)
                    {
                        cmbWareHouse.DataSource = resp1._list;
                        cmbWareHouse.DisplayMember = "WhsName";
                        cmbWareHouse.ValueMember = "WhsCode";
                        cmbWareHouse.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void cmbWareHouse_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgProducts.Rows.Count > 0)
                {
                    DialogResult dialog = MessageBox.Show("TÜM DEPOLARI DEĞİŞTİRMEYİ İSTİYOR MUSUNUZ?", "DEPO DEĞİŞİMİ", MessageBoxButtons.YesNo);

                    if (dialog == DialogResult.Yes)
                    {
                        for (int i = 0; i <= dtgProducts.Rows.Count - 1; i++)
                        {
                            (dtgProducts.Rows[i].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = cmbWareHouse.SelectedValue;
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA." + ex.Message, "Uyarı", "Tamam", "");
            }

            txtBarCode.Focus();
        }

        public static bool enter = false;

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEkle.PerformClick();
            }
        }

        public static int sapLineNum = 0;

        //int DocEntry = -1;
        private string barcode = "";

        private string partili = "";
        private string itemCode = "";
        private string itemName = "";
        public static int currentRow = 0;
        private double acceptqty = 0;
        //double paletIciKoliAD = 0;
        //double koliIciAD = 0;
        //double paletIciAD = 0;

        private double topMik = 0;

        //public static List<GoodRecieptPOBatch> goodRecieptPOBatches = new List<GoodRecieptPOBatch>();
        public static List<WaybillReturnBatch> waybillReturnBatches = new List<WaybillReturnBatch>();

        public static string arananItemCode = "";
        private string partino = "";

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string ItemCode = "";
                //string partili = "";
                string wareHouse = cmbWareHouse.SelectedValue == null ? "" : cmbWareHouse.SelectedValue.ToString();
                double warehouseQty = 0;

                if (wareHouse == "")
                {
                    CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    return;
                }
                List<dynamic> list = new List<dynamic>();
                string Val = txtBarCode.Text;
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
                    if (arananItemCode != "")
                    {
                        Val = arananItemCode;
                    }
                    else
                    {
                        Val = "";
                    }
                }

                if (resp._list == null)
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, wareHouse, txtSupplierCode.Text, Giris.mKodValue);
                }

                if (resp._list != null)
                {
                    foreach (DataRow item in resp._list.Rows)
                    {
                        DataRow dr = dtProducts.NewRow();
                        dr["Kalem Kodu"] = item["Kalem Kodu"];
                        dr["Kalem Tanımı"] = item["Kalem Tanımı"];
                        dr["Barkod"] = item["Barkod"];
                        dr["Ölçü Birimi"] = item["Ölçü Birimi"];
                        //dr["Müşteri Kodu"] = txtSupplierCode.Text.ToString();
                        dr["DepoMiktar"] = item["Depo Miktari"];
                        dr["Partili"] = item["Partili"];

                        //dr["PaletIciKoliAD"] = item["PaletIciKoliAD"];
                        //dr["KoliIciAD"] = item["KoliIciAD"];
                        //dr["PaletIciAD"] = item["PaletIciAD"];
                        //dr["DepoKodu"] = wareHouse;
                        partili = item["Partili"].ToString();

                        ItemCode = item["Kalem Kodu"].ToString();

                        list.Add(item["Kalem Kodu"]);
                        list.Add(item["Kalem Tanımı"]);
                        list.Add(item["Barkod"]);
                        list.Add(item["Ölçü Birimi"]);
                        list.Add(txtSupplierCode.Text);
                        //if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                        //{
                        list.Add(partino);
                        partino = "";
                        //}

                        list.Add(wareHouse);

                        //list.Add(item["Depo Miktari"]);

                        //list.Add(item["PaletIciKoliAD"]);
                        //list.Add(item["KoliIciAD"]);
                        //list.Add(item["PaletIciAD"]);

                        if (dtgProducts.Columns.Contains("DepoKodu") != true)
                        {
                            addcombo();
                            dtgProducts.Columns["DepoKodu"].ReadOnly = false;
                        }

                        if (!doubleclick)
                        {
                            dtProducts.Rows.Add(dr);
                        }

                        //dtProducts.AcceptChanges();
                        (dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = wareHouse;

                        //dtProducts.Rows[dtProducts.Rows.Count - 1]["ToplananMiktar"] = "1";
                    }

                    if (partili == "Y")
                    {
                        if (!doubleclick)
                        {
                            currentRow = dtgProducts.Rows.Count;
                        }

                        IadeIrsaliyeGirisi_2 n = new IadeIrsaliyeGirisi_2("16", list, "IADE IRSALIYE GIRIŞI");
                        n.ShowDialog();
                        n.Dispose();
                        GC.Collect();

                        if (IadeIrsaliyeGirisi_2.dialogresult != "Ok")
                        {
                            if (!doubleclick)
                            {
                                dtProducts.Rows.RemoveAt(currentRow - 1);
                                dtgProducts.Refresh();
                            }
                        }
                        else
                        {
                            var quantity = waybillReturnBatches.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                            dtProducts.Rows[currentRow - 1]["Miktar"] = quantity;
                            dtgProducts.Refresh();
                        }

                        IadeIrsaliyeGirisi_2.dialogresult = "";
                    }
                    else
                    {
                        //CustomMsgBox.Show("KALEM İÇİN PARTİ BULUNMAMAKTADIR", "Uyarı", "Tamam", "");
                        //return;

                        #region partisiz kalem seçimi olamyacak dendi.bu yüzden kaldırıldı

                        ////dtProducts.Rows[dtProducts.Rows.Count - 1]["ToplananMiktar"] = "1";
                        //if (wareHouse == "")
                        //{
                        //    CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ.", "Uyarı", "TAMAM", "");
                        //    return;
                        //}
                        ////ItemCode = "";

                        //list = new List<dynamic>();
                        //Val = txtBarCode.Text;

                        //if (Val == "")
                        //{
                        //    CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "TAMAM", "");
                        //    return;
                        //}

                        //if (!doubleclick)
                        //{
                        //    currentRow = dtgProducts.Rows.Count;
                        //}

                        //list.Add(resp._list.Rows[0]["Kalem Kodu"]); //0
                        //list.Add(resp._list.Rows[0]["Kalem Tanımı"]);//1
                        //list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);//2
                        //list.Add(resp._list.Rows[0]["Ölçü Birimi"]);//3
                        //list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));//4
                        //list.Add(Math.Round(acceptqty, Giris.genelParametreler.OndalikMiktar).ToString());//5

                        //var toplananmiktar = dtgProducts.Rows[currentRow - 1].Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgProducts.Rows[currentRow - 1].Cells["Miktar"].Value);

                        //list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString()); //6
                        //txtBarCode.Text = "";

                        //PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("16", list, "IADE IRSALIYE GIRIŞI");
                        //partisizKalemSecimi.ShowDialog();

                        //if (PartisizKalemSecimi.dialogresult == "Ok")
                        //{
                        //    dtProducts.Rows[currentRow - 1]["Miktar"] = PartisizKalemSecimi.quantity;
                        //    //(dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = PartisizKalemSecimi.depoKodu;
                        //    PartisizKalemSecimi.dialogresult = "";
                        //    dtgProducts.Rows[currentRow - 1].Selected = false;
                        //}
                        //else
                        //{
                        //    if (!doubleclick)
                        //    {
                        //        dtProducts.Rows.RemoveAt(currentRow - 1);
                        //        dtgProducts.Refresh();
                        //        //dtgProducts.DataSource = dtProducts;
                        //    }
                        //}
                        //partili = "";
                        //barcode = "";

                        ////btnItemSearch.PerformClick(); //kapatıldı teste göre bakılacak
                        ////cmbItemName.DroppedDown = false; //kapatıldı teste göre bakılacak
                        //vScrollBar1.Maximum = dtgProducts.RowCount + 5;
                        //try
                        //{
                        //    if (dtgProducts.Rows.Count > 0)
                        //    {
                        //        dtgProducts.Rows[currentRow - 1].Selected = false;
                        //    }
                        //    else
                        //    {
                        //        txtBarCode.Select(0, txtBarCode.Text.Length);

                        //        //CustomMsgBox.Show(resp.Desc, "Uyarı", "TAMAM", "");
                        //    }
                        //}
                        //catch (Exception)
                        //{
                        //}

                        #endregion partisiz kalem seçimi olamyacak dendi.bu yüzden kaldırıldı
                    }

                    //dtgProducts.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //dtgProducts.AutoResizeRows();

                    dtgProducts.Columns["DepoKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    //dtgProducts.Columns["KalemAdi"].Width = dtgProducts.Width - dtgProducts.Columns["OlcuBirimi"].Width - dtgProducts.Columns["DepoMiktar"].Width - dtgProducts.Columns["ToplananMiktar"].Width - dtgProducts.Columns["DepoKodu"].Width;

                    txtBarCode.Focus();
                    txtBarCode.Text = "";
                    txtItemName.Text = "";
                    arananItemCode = "";
                    txtItemName.Text = "";

                    //btnEkle.PerformClick();
                    cmbWareHouse.DroppedDown = false;
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
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_SatisIade", Giris.mKodValue);
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
            //comboLookup.Width = 55;
            //comboLookup.FillWeight = 55;
        }

        private void txtItemName_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbWareHouse.SelectedValue == "" || cmbWareHouse.SelectedValue == null)
                {
                    CustomMsgBox.Show("LÜTFEN GİRİŞ DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    return;
                }
                if (txtSupplierCode.Text == "")
                {
                    CustomMsgBox.Show("LÜTFEN MUHATAP SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    return;
                }
                SelectList nesne = new SelectList("16", "KalemAra", "KALEM ARAMA", txtBarCode, txtItemName);
                nesne.ShowDialog();
                nesne.Dispose();
                GC.Collect();

                if (SelectList.dialogResult == "Ok")
                {
                    if (txtBarCode.Text == "")
                    {
                        txtBarCode.Text = "TANIMSIZ";
                    }
                    btnEkle.PerformClick();
                    SelectList.dialogResult = "";
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private bool doubleclick = false;

        private void dtgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                partili = dtProducts.Rows[e.RowIndex]["Partili"].ToString();
                barcode = dtProducts.Rows[e.RowIndex]["Barkod"].ToString();
                itemCode = dtProducts.Rows[e.RowIndex]["Kalem Kodu"].ToString();
                itemName = dtProducts.Rows[e.RowIndex]["Kalem Tanımı"].ToString();
                //sapLineNum = Convert.ToInt32(dtProducts.Rows[e.RowIndex]["dtgSira"]);

                acceptqty = dtProducts.Rows[e.RowIndex]["Miktar"].ToString() == "" ? 0 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["Miktar"]);
                txtBarCode.Text = barcode == "" ? itemCode : barcode;
                currentRow = e.RowIndex + 1;

                //paletIciKoliAD = dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"]);
                //koliIciAD = dtProducts.Rows[e.RowIndex]["KoliIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["KoliIciAD"]);
                //paletIciAD = dtProducts.Rows[e.RowIndex]["PaletIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciAD"]);

                topMik = dtProducts.Rows[e.RowIndex]["Miktar"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["Miktar"]);
            }
        }

        private void dtgProducts_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
            btnEkle.PerformClick();
            partili = "";
            barcode = "";
            doubleclick = false;
            //return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtWayBillNo.Text == "")
            {
                CustomMsgBox.Show("İRSALİYE NUMARASI BOŞ BIRAKILAMAZ.", "Uyarı", "Tamam", "");
                txtWayBillNo.Focus();
                return;
            }

            #region satış - iade - ORDN -16

            try
            {
                if (dtgProducts.Rows.Count == 0)
                {
                    //ne uyarısı yazılabilir buraya?
                    //CustomMsgBox.Show("Lütfen Çıkış Depo Seçimi Yapınız.", "Uyarı", "Tamam", "");
                    return;
                }
                if (txtSupplierCode.Text == "")
                {
                    CustomMsgBox.Show("LÜTFEN MUHATAP SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    return;
                }
                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                    return;
                }

                WaybillReturn waybillReturn = new WaybillReturn();
                WaybillReturnDetails waybillReturnDetails = new WaybillReturnDetails();
                List<WaybillReturnDetails> waybillReturnDetails1 = new List<WaybillReturnDetails>();
                List<WaybillReturnBatchList> waybillReturnBatchLists = new List<WaybillReturnBatchList>();
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient4 = new AIFTerminalServiceSoapClient();

                int i = 1;
                int index = 0;

                waybillReturn.CardCode = txtSupplierCode.Text;
                waybillReturn.TaxDate = dtpTaxDate.Value.ToString("yyyyMMdd");
                waybillReturn.WayBillNo = txtWayBillNo.Text;
                waybillReturn.Comments = richTextBox1.Text;
                waybillReturn.ShipToCode = cmbSevkAdresi.Text;
                foreach (DataRow items in dtProducts.Rows)
                {
                    if (items["Miktar"].ToString() == "0")
                    {
                        continue;
                    }

                    waybillReturnBatchLists = new List<WaybillReturnBatchList>();
                    foreach (var aifx in waybillReturnBatches.Where(x => x.ItemCode == items["Kalem Kodu"].ToString() && x.LineNumber == i))
                    {
                        waybillReturnBatchLists.Add(new WaybillReturnBatchList
                        {
                            BatchNumber = aifx.BatchNumber,
                            BatchQuantity = aifx.BatchQuantity,
                            DepoYeriId = aifx.DepoYeriId,
                            DepoYeriAdi = aifx.DepoYeriAdi
                        });
                    }

                    waybillReturnDetails1.Add(new WaybillReturnDetails
                    {
                        BatchLists = waybillReturnBatchLists.ToArray(),
                        ItemCode = items["Kalem Kodu"].ToString(),
                        Quantity = Math.Round(Convert.ToDouble(items["Miktar"]), Giris.genelParametreler.OndalikMiktar),
                        WareHouse = dtgProducts.Rows[index].Cells["DepoKodu"].Value.ToString(),
                    });

                    waybillReturn.WaybillReturnDetails = waybillReturnDetails1.ToArray();
                    i++;
                    index++;
                }

                if (waybillReturn.WaybillReturnDetails.Count() == 0)
                {
                    CustomMsgBox.Show("BELGENİN TÜM SATIRLARI 0 OLDUĞUNDAN DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                    return;
                }
                var resp4 = aIFTerminalServiceSoapClient4.AddOrUpdateReturnWaybillEntry(Giris._dbName, Convert.ToInt32(Giris._userCode), waybillReturn);

                CustomMsgBox.Show(resp4.Desc, "Uyarı", "Tamam", "");

                if (resp4.Val == 0)
                {
                    waybillReturnBatchLists = new List<WaybillReturnBatchList>();
                    Close();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }

            #endregion satış - iade - ORDN -16

            #region satınalma siparişli mal girişi - taslak

            //try
            //{
            //    if (dtgProducts.Rows.Count == 0)
            //    {
            //        //ne uyarısı yazılabilir buraya?
            //        //CustomMsgBox.Show("Lütfen Çıkış Depo Seçimi Yapınız.", "Uyarı", "Tamam", "");
            //        return;
            //    }
            //    if (txtSupplierCode.Text == "")
            //    {
            //        CustomMsgBox.Show("LÜTFEN TEDARİKÇİ SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
            //        return;
            //    }
            //    DialogResult dialog = new DialogResult();
            //    dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

            //    if (dialog == DialogResult.No)
            //    {
            //        return;
            //    }
            //    GoodRecieptPO goodRecieptPO = new GoodRecieptPO();
            //    GoodRecieptPODetails goodRecieptPODetails = new GoodRecieptPODetails();
            //    List<GoodRecieptPODetails> goodRecieptPODetails1 = new List<GoodRecieptPODetails>();
            //    List<GoodRecieptPOBatchList> goodRecieptPOBatchList1 = new List<GoodRecieptPOBatchList>();
            //    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

            //    int i = 1;
            //    int index = 0;
            //    goodRecieptPO.CarCode = txtSupplierCode.Text;
            //    goodRecieptPO.TaxDate = dtpTaxDate.Value.ToString("yyyyMMdd");
            //    //goodRecieptPO.DocDueDate = dtpDocDueDate.Value.ToString("yyyyMMdd");
            //    goodRecieptPO.WayBillNo = txtWayBillNo.Text;
            //    foreach (DataRow items in dtProducts.Rows)
            //    {
            //        if (items["Miktar"].ToString() == "0")
            //        {
            //            continue;
            //        }

            //        goodRecieptPOBatchList1 = new List<GoodRecieptPOBatchList>();
            //        foreach (var aifx in goodRecieptPOBatches.Where(x => x.ItemCode == items["Kalem Kodu"].ToString() && x.LineNumber == i))
            //        {
            //            goodRecieptPOBatchList1.Add(new GoodRecieptPOBatchList
            //            {
            //                BatchNumber = aifx.BatchNumber,
            //                BatchQuantity = aifx.BatchQuantity
            //            });
            //        }

            //        goodRecieptPODetails1.Add(new GoodRecieptPODetails
            //        {
            //            BatchLists = goodRecieptPOBatchList1.ToArray(),
            //            ItemCode = items["Kalem Kodu"].ToString(),
            //            Quantity = Math.Round(Convert.ToDouble(items["Miktar"]), Giris.genelParametreler.OndalikMiktar),
            //            WareHouse = dtgProducts.Rows[index].Cells["DepoKodu"].Value.ToString()
            //        });

            //        goodRecieptPO.GoodRecieptPODetails = goodRecieptPODetails1.ToArray();
            //        i++;
            //        index++;
            //    }

            //    if (goodRecieptPO.GoodRecieptPODetails.Count() == 0)
            //    {
            //        CustomMsgBox.Show("BELGENİN TÜM SATIRLARI 0 OLDUĞUNDAN DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
            //        return;
            //    }

            //    var resp1 = aIFTerminalServiceSoapClient1.AddGoodRecieptPODraft(Giris._dbName, goodRecieptPO);

            //    CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

            //    if (resp1.Val == 0)
            //    {
            //        goodRecieptPOBatchList1 = new List<GoodRecieptPOBatchList>();
            //        Close();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            //}

            #endregion satınalma siparişli mal girişi - taslak
        }

        private void txtSupplierCode_Click(object sender, EventArgs e)
        {
            SelectList nesne = new SelectList("20", "MusteriAra", "MÜŞTERİ ARAMA", txtSupplierCode, txtSupplier);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (txtSupplierCode.Text != "")
            {
                SevkAdresGetir();
            }
        }

        private void SevkAdresGetir()
        {
            try
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response r = aIFTerminalServiceSoapClient.GetSevkiyatAdresi(Giris._dbName, txtSupplierCode.Text, Giris.mKodValue);

                if (r.Val == 0)
                {
                    if (r._list.Rows.Count > 0)
                    {
                        cmbSevkAdresi.DataSource = r._list;
                        cmbSevkAdresi.DisplayMember = "Address";
                        cmbSevkAdresi.ValueMember = "Address";
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}