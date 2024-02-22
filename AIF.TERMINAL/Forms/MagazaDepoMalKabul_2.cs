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
    public partial class MagazaDepoMalKabul_2 : form_Base
    {
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;

        private List<SiparisKabul> siparisKabuls = new List<SiparisKabul>();
        private DataTable dtDetails = new DataTable();

        private Color defaultColor = Color.White;

        private string formName = "";
        private string itemCode = "";
        private string itemName = "";
        private string barcode = "";
        private string siparisRefNo = "";
        private string siraNumarasi = "";

        public static int currentRow = 0;
        private double siparisMiktari = 0;
        private double kabulEdilenMiktar = 0;

        public MagazaDepoMalKabul_2(List<SiparisKabul> _siparisKabuls, string _formName)
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
            siparisKabuls = _siparisKabuls;

            if (siparisKabuls != null)
            {
                txtMagaza.Text = siparisKabuls[0].magaza;
                //txtVendorName.Text = purchaseOrderList[0].VendorName;

                var max = siparisKabuls.OrderByDescending(t => t.siparisTarihi)
                   .FirstOrDefault();

                //dtpSiparisTar.Value = new DateTime(Convert.ToInt32(max.siparisTarihi.Substring(0, 4)), Convert.ToInt32(max.DocDueDate.Substring(4, 2)), Convert.ToInt32(max.DocDueDate.Substring(6, 2)));
                //dtpTerminTar.Value = new DateTime(Convert.ToInt32(max.TaxDate.Substring(0, 4)), Convert.ToInt32(max.TaxDate.Substring(4, 2)), Convert.ToInt32(max.TaxDate.Substring(6, 2)));

                dtpSiparisTar.Value = siparisKabuls[0].siparisTarihi;
                dtpTerminTar.Value = siparisKabuls[0].terminTarihi;

                //List<string> sipRefNums = new List<string>();
                //foreach (var item in siparisKabuls)
                //{
                //    sipRefNums.Add(item.siparisRefNo.ToString());
                //}
                siparisRefNo = siparisKabuls[0].siparisRefNo.ToString();
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

            lblItemName.Font = new Font(lblItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemName.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtHedefDepo.Font = new Font(txtHedefDepo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtHedefDepo.Font.Style);

            txtKaynakDepo.Font = new Font(txtKaynakDepo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtKaynakDepo.Font.Style);

            txtKabulSum.Font = new Font(txtKabulSum.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtKabulSum.Font.Style);

            dtpSiparisTar.Font = new Font(dtpSiparisTar.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpSiparisTar.Font.Style);

            dtpTerminTar.Font = new Font(dtpTerminTar.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpTerminTar.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbItemName.Font.Style);

            btnDetay.Font = new Font(btnDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDetay.Font.Style);

            btnSearch.Font = new Font(btnSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSearch.Font.Style);

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
            txtMagaza.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtKaynakDepo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtKaynakDepo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtHedefDepo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            dtpSiparisTar.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpTerminTar.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

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

        private void MagazaDepoMalKabul_2_Load(object sender, EventArgs e)
        {
            //defaultColor = dtgDetails.Rows[0].Cells[0].Style.BackColor;

            frmName.Text = formName.ToUpper();
            //btnColumnsWidth.Visible = false;
            txtBarCode.Focus();

            dtgDetails.RowTemplate.Height = 55;
            dtgDetails.ColumnHeadersHeight = 60;
            vScrollBar1.Maximum = dtgDetails.RowCount + 5;

            txtKabulSum.Text = 0.ToString("N" + Giris.genelParametreler.OndalikMiktar);

            GetSiparisSecimDetay();
            GridDuzenleme();
            GetMagazaDepo();
        }
        private void GetMagazaDepo()
        {
            try
            {
                #region kaynak
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = aIFTerminalServiceSoapClient.GetMagazaDepoKaynak(Giris._dbName, SubeSecim.subeId, Giris.mKodValue);

                if (resp._list != null)
                {
                    txtKaynakDepo.Text = resp._list.Rows[0][0].ToString();
                }
                else
                {
                    CustomMsgBox.Show(resp.Desc, "UYARI", "TAMAM", "");
                }
                #endregion

                aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                resp = aIFTerminalServiceSoapClient.GetMagazaDepoHedef(Giris._dbName, SubeSecim.subeId, Giris.mKodValue);

                if (resp._list != null)
                {
                    txtHedefDepo.Text = resp._list.Rows[0][0].ToString();

                }
                else
                {
                    CustomMsgBox.Show(resp.Desc, "UYARI", "TAMAM", "");
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM", "");
            }
        }
        private void GetSiparisSecimDetay()
        {
            try
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = aIFTerminalServiceSoapClient.GetMagazaSiparisSecimDetay(Giris._dbName, siparisRefNo, Giris.mKodValue);

                if (resp._list != null)
                {
                    dtDetails = resp._list;
                    dtgDetails.DataSource = null;

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
                     

                    var sum = dtDetails.AsEnumerable().Sum(x => x.Field<decimal>("KabulEdilen"));
                    txtKabulSum.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM", "");
            }
        }
        private void GridDuzenleme()
        {
            try
            {
                if (dtgDetails.RowCount > 0)
                {
                    dtgDetails.Columns["U_Quantity"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                    dtgDetails.Columns["onaylanan"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                    dtgDetails.Columns["kabulEdilen"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                    dtgDetails.Columns["dtgSira"].Visible = false;
                    dtgDetails.Columns["btnDetail"].Visible = false;
                    dtgDetails.Columns["U_OrderRefNo"].Visible = false;
                    dtgDetails.Columns["U_OrderDate"].Visible = false;
                    dtgDetails.Columns["onaylanan"].Visible = false;
                    dtgDetails.Columns["U_Branchid"].Visible = false;
                    dtgDetails.Columns["SiraNumarasi"].Visible = false;
                    dtgDetails.Columns["Durum"].Visible = false;
                    dtgDetails.Columns["dtgSira"].Visible = false;

                    dtgDetails.Columns["U_OrderRefNo"].ReadOnly = true;
                    dtgDetails.Columns["U_OrderDate"].ReadOnly = true;
                    dtgDetails.Columns["U_CodeBar"].ReadOnly = true;
                    dtgDetails.Columns["U_ItemCode"].ReadOnly = true;
                    dtgDetails.Columns["U_ItemName"].ReadOnly = true;
                    dtgDetails.Columns["U_Quantity"].ReadOnly = true;
                    dtgDetails.Columns["onaylanan"].ReadOnly = true;
                    dtgDetails.Columns["kabulEdilen"].ReadOnly = true;
                    dtgDetails.Columns["U_Branchid"].ReadOnly = true;
                    dtgDetails.Columns["SiraNumarasi"].ReadOnly = true;
                    dtgDetails.Columns["Durum"].ReadOnly = true;
                    //dtgDetails.Columns["miktar"].ReadOnly = true;
                    //dtgDetails.Columns["fiyat"].ReadOnly = true;
                    dtgDetails.Columns["dtgSira"].ReadOnly = true;


                    dtgDetails.Columns["U_OrderRefNo"].HeaderText = "SİP.REF.NO";
                    dtgDetails.Columns["U_OrderDate"].HeaderText = "SİP.TAR";
                    dtgDetails.Columns["U_CodeBar"].HeaderText = "BARKOD";
                    dtgDetails.Columns["U_ItemCode"].HeaderText = "ÜRÜN KODU";
                    dtgDetails.Columns["U_ItemName"].HeaderText = "ÜRÜN TANIMI";
                    dtgDetails.Columns["U_Quantity"].HeaderText = "MİKTAR(TALEP)";
                    dtgDetails.Columns["onaylanan"].HeaderText = "ONAY.MİK(MRKZ)";
                    dtgDetails.Columns["kabulEdilen"].HeaderText = "KABUL.MİK";
                    dtgDetails.Columns["U_Branchid"].HeaderText = "ŞUBE";
                    dtgDetails.Columns["SiraNumarasi"].HeaderText = "SIRA NO";
                    dtgDetails.Columns["Durum"].HeaderText = "DURUM"; 
                    dtgDetails.Columns["dtgSira"].HeaderText = "DTGSIRA";
                    //dtgDetails.Columns["fiyat"].HeaderText = "FİYAT"; 

                    dtgDetails.Columns["U_Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dtgDetails.Columns["onaylanan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dtgDetails.Columns["kabulEdilen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dtgDetails.Columns["fiyat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    //if (Giris.genelParametreler.DepoYeriCalisir != "Y")
                    //{
                    //    dtgDetails.Columns["DepoYeriId"].Visible = false;
                    //    dtgDetails.Columns["DepoYeriAdi"].Visible = false;
                    //}
                    dtgDetails.RowTemplate.Height = 55;
                    dtgDetails.ColumnHeadersHeight = 60;
                    vScrollBar1.Maximum = dtgDetails.RowCount + 5;

                    //dtgDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //dtgDetails.AutoResizeRows();
                    //dtgDetails.AutoResizeColumns();

                    //for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                    //{
                    //    var partili = dtgDetails.Rows[i].Cells["Partili"].Value;

                    //    if (partili.ToString() == "Y")
                    //    {
                    //        dtgDetails.Rows[i].Cells["Toplanan Miktar"].ReadOnly = true;
                    //    }
                    //}

                    for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                    {
                        dtgDetails.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);


                        if (Math.Round(Convert.ToDouble(dtgDetails.Rows[i].Cells["U_Quantity"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgDetails.Rows[i].Cells["kabulEdilen"].Value), Giris.genelParametreler.OndalikMiktar))
                        {
                            dtgDetails.Rows[i].Cells["kabulEdilen"].Style.BackColor = Color.Lime;
                        }
                        else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[i].Cells["kabulEdilen"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                        {
                            dtgDetails.Rows[i].Cells["kabulEdilen"].Style.BackColor = defaultColor;
                        }
                        else
                        {
                            dtgDetails.Rows[i].Cells["kabulEdilen"].Style.BackColor = Color.OrangeRed;
                            //dtgDetails.Rows[i].Cells["kabulEdilen"].Style.BackColor = Color.OrangeRed;
                        }
                    }

                    foreach (DataGridViewColumn column in dtgDetails.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    if (dtgDetails.Rows.Count > 0)
                    {
                        dtgDetails.Rows[0].Selected = false;
                    }
                    //dtgDetails.Columns["KalemAdi"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //dtgDetails.AutoResizeRows();

                    //dtgDetails.Columns["DepoMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    //dtgDetails.Columns["KalemAdi"].Width = dtgDetails.Width - dtgDetails.Columns["OlcuBirimi"].Width - dtgDetails.Columns["Miktar"].Width -
                    //    dtgDetails.Columns["ToplananMiktar"].Width - dtgDetails.Columns["DepoMiktar"].Width;

                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM", "");

            }
        }
        private void dtgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                barcode = dtDetails.Rows[e.RowIndex]["U_CodeBar"].ToString();
                itemCode = dtDetails.Rows[e.RowIndex]["U_ItemCode"].ToString();
                itemName = dtDetails.Rows[e.RowIndex]["U_ItemName"].ToString();
                //warehouse = dtDetails.Rows[e.RowIndex]["DepoKodu"].ToString(); 
                txtBarCode.Text = barcode.ToString() != "" ? barcode.ToString() : itemCode;
                currentRow = e.RowIndex;
                siparisRefNo = dtDetails.Rows[e.RowIndex]["U_OrderRefNo"].ToString();
                siraNumarasi = dtDetails.Rows[e.RowIndex]["SiraNumarasi"].ToString();
                siparisMiktari = dtDetails.Rows[e.RowIndex]["U_Quantity"].ToString() == "" ? 0 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["U_Quantity"]);
                kabulEdilenMiktar = dtDetails.Rows[e.RowIndex]["kabulEdilen"].ToString() == "" ? 0 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["kabulEdilen"]);
            }
        }
        private void btnDetay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode.Text == "")
                {
                    CustomMsgBox.Show("BARKOD GİRİŞİ YAPILMADAN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                    txtBarCode.Focus();
                    return;
                }

                MagazaDepoMalKabul_3 magazaDepoMalKabul_3 = new MagazaDepoMalKabul_3("SİPARİŞ MİKTAR GİRİŞİ", "DepoKabul", itemCode, itemName, barcode, siparisMiktari, kabulEdilenMiktar);
                DialogResult dialogResult = magazaDepoMalKabul_3.ShowDialog();
                magazaDepoMalKabul_3.Dispose();
                GC.Collect();

                if (dialogResult == DialogResult.OK)
                {
                    dtDetails.Rows[currentRow]["kabulEdilen"] = MagazaDepoMalKabul_3.quantity;
                    //dtDetails.AcceptChanges();
                    if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["U_Quantity"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["kabulEdilen"].Value), Giris.genelParametreler.OndalikMiktar))
                    {
                        dtgDetails.Rows[currentRow].Cells["kabulEdilen"].Style.BackColor = Color.Lime;
                    }
                    else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["kabulEdilen"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                    {
                        dtgDetails.Rows[currentRow].Cells["kabulEdilen"].Style.BackColor = defaultColor;
                    }
                    else
                    {
                        dtgDetails.Rows[currentRow].Cells["kabulEdilen"].Style.BackColor = Color.OrangeRed;
                    }
                }
                dtgDetails.Rows[currentRow].Selected = false;
                barcode = "";

                var sum = dtDetails.AsEnumerable().Sum(x => x.Field<decimal>("KabulEdilen"));
                txtKabulSum.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);

            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM", "");
            }
        }

        private void dtgDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarCode.Text != "")
                {
                    btnDetay.PerformClick();
                }
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode.Focus();

                if (txtBarCode.Text != "")
                {
                    txtBarCode.Text = Giris.UrunKoduBarkod(txtBarCode.Text, "Barkod");
                    bool urunbulundu = false;
                    var exits = dtDetails.AsEnumerable().Where(x => x.Field<string>("U_CodeBar") == txtBarCode.Text).ToList();

                    if (exits.Count > 0)
                    {
                        var dtgSira = dtDetails.AsEnumerable().Where(x => x.Field<string>("U_CodeBar") == txtBarCode.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                        var arg = new DataGridViewCellEventArgs(dtDetails.Rows.Count, dtgSira);
                        dtgDetails_CellClick(dtgDetails, arg);

                        dtgDetails.ClearSelection();

                        dtgDetails.Rows[dtgSira].Cells[0].Selected = true;
                        btnDetay.PerformClick();
                        urunbulundu = true;
                    }

                    if (!urunbulundu)
                    {
                        exits = dtDetails.AsEnumerable().Where(x => x.Field<string>("U_ItemCode") == txtBarCode.Text).ToList();
                        if (exits.Count > 0)
                        {
                            var dtgSira = dtDetails.AsEnumerable().Where(x => x.Field<string>("U_ItemCode") == txtBarCode.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                            var arg = new DataGridViewCellEventArgs(dtDetails.Rows.Count, dtgSira);
                            dtgDetails_CellClick(dtgDetails, arg);

                            dtgDetails.ClearSelection();

                            dtgDetails.Rows[dtgSira].Cells[0].Selected = true;
                            btnDetay.PerformClick();
                            urunbulundu = true;
                        }
                    }

                    if (!urunbulundu)
                    {
                        CustomMsgBox.Show("BARKOD BULUNAMADI.", "Uyarı", "Tamam", "");
                        txtBarCode.Focus();
                        txtBarCode.Select(0, txtBarCode.Text.Length);
                        return;
                    }
                }
                else
                {
                    CustomMsgBox.Show("BARKOD BULUNAMADI.", "Uyarı", "Tamam", "");
                    txtBarCode.Focus();
                    txtBarCode.Select(0, txtBarCode.Text.Length);
                    return;
                }
            }
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
                SiparisKabul siparisKabul = new SiparisKabul();
                SiparisKabulDetay siparisKabulDetay = new SiparisKabulDetay();
                List<SiparisKabulDetay> siparisKabulDetays = new List<SiparisKabulDetay>();
                //List<GoodRecieptPOBatchList> goodRecieptPOBatchList1 = new List<GoodRecieptPOBatchList>();
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                siparisKabul.subeId = SubeSecim.subeId;
                siparisKabul.siparisRefNo = siparisRefNo;
                siparisKabul.siparisTarihi = Convert.ToDateTime(dtpSiparisTar.Value);
                siparisKabul.kabulTarihi = Convert.ToDateTime(dtpTerminTar.Value);
                siparisKabul.kaynakDepo = txtKaynakDepo.Text;
                siparisKabul.hedefDepo = txtHedefDepo.Text;

                //goodRecieptPO.DocDate = DateTime.Now.ToString("yyyyMMdd");
                //goodRecieptPO.DocDueDate = DateTime.Now.ToString("yyyyMMdd"); 


                //if (cmbDurum.Text == "Taslak")
                //{
                //    siparisKabul.durumNo = "1";
                //}
                //else if (cmbDurum.Text == "Onaylandı - Mağaza")
                //{
                //    siparisKabul.durumNo = "2";
                //}

                siparisKabul.durumNo = "1";

                int i = 0;

                foreach (DataRow items in dtDetails.Rows)
                {
                    if (Convert.ToDouble(items["kabulEdilen"]) ==0|| items["kabulEdilen"].ToString() == "")
                    {
                        continue;
                    }

                    siparisKabulDetay = new SiparisKabulDetay();
                    siparisKabulDetay.barkod = items["U_CodeBar"].ToString();
                    siparisKabulDetay.urunKodu = items["U_ItemCode"].ToString();
                    siparisKabulDetay.urunTanimi = items["U_ItemName"].ToString();
                    siparisKabulDetay.miktar = Convert.ToDouble(items["kabulEdilen"]);
                    siparisKabulDetay.kabulEdilenMiktar = Convert.ToDouble(items["kabulEdilen"]);
                    siparisKabulDetay.siraNumarasi = items["SiraNumarasi"].ToString(); //SiraNumarasi

                    siparisKabulDetays.Add(siparisKabulDetay);

                    i++;
                }
                siparisKabul.siparisKabulDetays = siparisKabulDetays.ToArray();

                if (siparisKabul.siparisKabulDetays == null)
                {
                    CustomMsgBox.Show("TÜM SATIRLARIN MİKTARI 0 OLAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }

                string durum = "";

                //if (btnTamam.Text == "Güncelle" && cmbDurum.Text == "Taslak") //Belge GÜNCELLE ve durum TASLAK ise RT_ORDRACP güncelleme yapılır.
                //{
                durum = "GuncelleTaslak";
                //}

                //if (btnTamam.Text == "Güncelle" && cmbDurum.Text == "Onaylandı - Mağaza") //Belge GÜNCELLE ve durum ONAYLANDI ise RT_ORDRACP güncelleme yapılır.Mal Giriş-çıkış yapılır
                //{
                //    durum = "GuncelleOnaylandi";

                //}

                var resp1 = aIFTerminalServiceSoapClient1.AddOrUpdateSiparisKabul(Giris._dbName, durum, SubeSecim.subeAdi,Giris.mKodValue, siparisKabul);

                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

                if (resp1.Val == 0)
                {
                    MagazaDepoMalKabul_1.formAciliyor = true;
                    //DialogResult dialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void btnBarkodGoster_Click(object sender, EventArgs e)
        {

        }

        private void dtgDetails_DoubleClick(object sender, EventArgs e)
        {
            btnDetay.PerformClick();
            barcode = "";
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
    }
}
