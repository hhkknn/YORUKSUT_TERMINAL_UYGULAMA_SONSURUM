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
    public partial class MagazaTransfer_2 : form_Base
    {
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;

        private List<MagazaMalGirisCikis> magazaMalGirisCikis = new List<MagazaMalGirisCikis>();
        private DataTable dtDetails = new DataTable();

        private Color defaultColor = Color.White;

        private string formName = "";
        private string itemCode = "";
        private string itemName = "";
        private string barcode = "";
        private string belgeNo = "";
        private string siraNumarasi = "";

        public static int currentRow = 0;
        private double miktar = 0;
        private double toplananMiktar = 0;
        public MagazaTransfer_2(List<MagazaMalGirisCikis> _magazaMalGirisCikis, string _formName)
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
            magazaMalGirisCikis = _magazaMalGirisCikis;

            if (magazaMalGirisCikis != null)
            {
                txtGondericiSube.Text = magazaMalGirisCikis[0].gondericiSube;
                txtAliciSube.Text = magazaMalGirisCikis[0].aliciSube;
                txtIslemTipi.Text = "Mağaza Giriş";//magazaMalGirisCikis[0].girisMiCikisMi;

                var max = magazaMalGirisCikis.OrderByDescending(t => t.tarih)
                   .FirstOrDefault();

                //dtpSiparisTar.Value = new DateTime(Convert.ToInt32(max.siparisTarihi.Substring(0, 4)), Convert.ToInt32(max.DocDueDate.Substring(4, 2)), Convert.ToInt32(max.DocDueDate.Substring(6, 2)));
                //dtpTerminTar.Value = new DateTime(Convert.ToInt32(max.TaxDate.Substring(0, 4)), Convert.ToInt32(max.TaxDate.Substring(4, 2)), Convert.ToInt32(max.TaxDate.Substring(6, 2)));

                dtpBelgeTar.Value = magazaMalGirisCikis[0].tarih;
                //dtpTerminTar.Value = siparisKabuls[0].terminTarihi;

                //List<string> sipRefNums = new List<string>();
                //foreach (var item in siparisKabuls)
                //{
                //    sipRefNums.Add(item.siparisRefNo.ToString());
                //}
                belgeNo = magazaMalGirisCikis[0].belgeNo.ToString();
                txtMalCikisNo.Text = magazaMalGirisCikis[0].belgeNo.ToString();
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

            label6.Font = new Font(label6.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label6.Font.Style);

            label7.Font = new Font(label7.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label7.Font.Style);

            label5.Font = new Font(label5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label5.Font.Style);

            lblItemName.Font = new Font(lblItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemName.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtGondericiSube.Font = new Font(txtGondericiSube.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtGondericiSube.Font.Style);

            txtAliciSube.Font = new Font(txtAliciSube.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtAliciSube.Font.Style);

            txtMalCikisNo.Font = new Font(txtMalCikisNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtMalCikisNo.Font.Style);

            txtIslemTipi.Font = new Font(txtIslemTipi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtIslemTipi.Font.Style);

            dtpBelgeTar.Font = new Font(dtpBelgeTar.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpBelgeTar.Font.Style);

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
            txtGondericiSube.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtAliciSube.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtIslemTipi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtMalCikisNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            dtpBelgeTar.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

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
        private void MagazaTransfer_2_Load(object sender, EventArgs e)
        {
            //defaultColor = dtgDetails.Rows[0].Cells[0].Style.BackColor;

            frmName.Text = formName.ToUpper();
            //btnColumnsWidth.Visible = false;
            txtBarCode.Focus();

            dtgDetails.RowTemplate.Height = 55;
            dtgDetails.ColumnHeadersHeight = 60;
            vScrollBar1.Maximum = dtgDetails.RowCount + 5;

            GetMalGirisCikisDetay();
            GridDuzenleme();
            GetMagazaDepo();

        }

        private void GetMagazaDepo()
        {
            //try
            //{
            //    #region kaynak
            //    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            //    Response resp = aIFTerminalServiceSoapClient.getmal(Giris._dbName, SubeSecim.subeId, Giris.mKodValue);

            //    if (resp._list != null)
            //    {
            //        txtKaynakDepo.Text = resp._list.Rows[0][0].ToString();
            //    }
            //    else
            //    {
            //        CustomMsgBox.Show(resp.Desc, "UYARI", "TAMAM", "");
            //    }
            //    #endregion

            //    aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            //    resp = aIFTerminalServiceSoapClient.GetMagazaDepoHedef(Giris._dbName, SubeSecim.subeId, Giris.mKodValue);

            //    if (resp._list != null)
            //    {
            //        txtHedefDepo.Text = resp._list.Rows[0][0].ToString();

            //    }
            //    else
            //    {
            //        CustomMsgBox.Show(resp.Desc, "UYARI", "TAMAM", "");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM", "");
            //}
        }
        private void GetMalGirisCikisDetay()
        {
            try
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = aIFTerminalServiceSoapClient.GetMagazaMalGirisCikisDetay(Giris._dbName, SubeSecim.subeId, txtMalCikisNo.Text, "Mağaza Çıkış", "", Giris.mKodValue);

                if (resp._list != null)
                {
                    dtDetails = resp._list;
                    dtgDetails.DataSource = null;

                    dtDetails.Columns.Add("dtgSira", typeof(int));
                    dtDetails.Columns.Add("toplananMiktar", typeof(double));

                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

                    btn = new DataGridViewButtonColumn();
                    dtgDetails.Columns.Add(btn);
                    //dtgDetails.Columns[dtgDetails.ColumnCount - 1].DisplayIndex = dtgDetails.Columnscount-1;
                    btn.HeaderText = "";
                    btn.Text = "Detay";
                    btn.Name = "btnDetail";

                    btn.UseColumnTextForButtonValue = true;

                    dtgDetails.DataSource = dtDetails;
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
                    dtgDetails.Columns["Quantity"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                    dtgDetails.Columns["CodeBars"].DisplayIndex = 0;

                    dtgDetails.Columns["DocEntry"].Visible = false;
                    dtgDetails.Columns["DocDate"].Visible = false;
                    dtgDetails.Columns["dtgSira"].Visible = false;
                    dtgDetails.Columns["btnDetail"].Visible = false;
                    dtgDetails.Columns["ObjType"].Visible = false;
                    dtgDetails.Columns["U_AliciSubeId"].Visible = false;
                    dtgDetails.Columns["BPLId"].Visible = false;
                    dtgDetails.Columns["U_AliciAdi"].Visible = false;
                    dtgDetails.Columns["U_Adres"].Visible = false;
                    dtgDetails.Columns["U_ZipCode"].Visible = false;
                    dtgDetails.Columns["U_City"].Visible = false;
                    dtgDetails.Columns["U_County"].Visible = false;

                    dtgDetails.Columns["DocEntry"].ReadOnly = true;
                    dtgDetails.Columns["DocDate"].ReadOnly = true;
                    dtgDetails.Columns["ObjType"].ReadOnly = true;
                    dtgDetails.Columns["U_AliciSubeId"].ReadOnly = true;
                    dtgDetails.Columns["BPLId"].ReadOnly = true;
                    dtgDetails.Columns["U_AliciAdi"].ReadOnly = true;
                    dtgDetails.Columns["U_Adres"].ReadOnly = true;
                    dtgDetails.Columns["U_ZipCode"].ReadOnly = true;
                    dtgDetails.Columns["U_City"].ReadOnly = true;
                    dtgDetails.Columns["U_County"].ReadOnly = true;
                    dtgDetails.Columns["ItemCode"].ReadOnly = true;
                    dtgDetails.Columns["Dscription"].ReadOnly = true;
                    dtgDetails.Columns["CodeBars"].ReadOnly = true;
                    dtgDetails.Columns["Quantity"].ReadOnly = true;
                    dtgDetails.Columns["dtgSira"].ReadOnly = true;
                    dtgDetails.Columns["toplananMiktar"].ReadOnly = true;


                    dtgDetails.Columns["DocEntry"].HeaderText = "BELGE NO";
                    dtgDetails.Columns["DocDate"].HeaderText = "BELGE.TAR";
                    dtgDetails.Columns["ObjType"].HeaderText = "BELGE TYPE";
                    dtgDetails.Columns["U_AliciSubeId"].HeaderText = "ALICI ŞUBE ID";
                    dtgDetails.Columns["BPLId"].HeaderText = "ŞUBE ID";
                    dtgDetails.Columns["U_AliciAdi"].HeaderText = "ALICI ADI";
                    dtgDetails.Columns["U_Adres"].HeaderText = "ADRES";
                    dtgDetails.Columns["U_ZipCode"].HeaderText = "ZIPCODE";
                    dtgDetails.Columns["U_City"].HeaderText = "CITY";
                    dtgDetails.Columns["U_County"].HeaderText = "COUNTY";
                    dtgDetails.Columns["ItemCode"].HeaderText = "ÜRÜN KODU";
                    dtgDetails.Columns["Dscription"].HeaderText = "ÜRÜN TANIMI";
                    dtgDetails.Columns["CodeBars"].HeaderText = "BARKOD";
                    dtgDetails.Columns["Quantity"].HeaderText = "MİKTAR";
                    dtgDetails.Columns["dtgSira"].HeaderText = "DTGSIRA";
                    dtgDetails.Columns["toplananMiktar"].HeaderText = "TOP.MİK";

                    dtgDetails.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

                barcode = dtDetails.Rows[e.RowIndex]["CodeBars"].ToString();
                itemCode = dtDetails.Rows[e.RowIndex]["ItemCode"].ToString();
                itemName = dtDetails.Rows[e.RowIndex]["Dscription"].ToString();
                //warehouse = dtDetails.Rows[e.RowIndex]["DepoKodu"].ToString(); 
                txtBarCode.Text = barcode.ToString() != "" ? barcode.ToString() : itemCode;
                currentRow = e.RowIndex;
                belgeNo = dtDetails.Rows[e.RowIndex]["DocEntry"].ToString();
                //siraNumarasi = dtDetails.Rows[e.RowIndex]["SiraNumarasi"].ToString();
                miktar = dtDetails.Rows[e.RowIndex]["Quantity"].ToString() == "" ? 0 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["Quantity"]);
                toplananMiktar = dtDetails.Rows[e.RowIndex]["toplananMiktar"].ToString() == "" ? 0 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["toplananMiktar"]);
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

                MagazaDepoMalKabul_3 magazaDepoMalKabul_3 = new MagazaDepoMalKabul_3("MİKTAR GİRİŞİ", "DepoTransfer", itemCode, itemName, barcode, miktar, Top);
                DialogResult dialogResult = magazaDepoMalKabul_3.ShowDialog();
                magazaDepoMalKabul_3.Dispose();
                GC.Collect();

                if (dialogResult == DialogResult.OK)
                {
                    dtDetails.Rows[currentRow]["toplananMiktar"] = MagazaDepoMalKabul_3.quantity;
                    //dtDetails.AcceptChanges();
                    if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["Quantity"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["toplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar))
                    {
                        dtgDetails.Rows[currentRow].Cells["toplananMiktar"].Style.BackColor = Color.LimeGreen;
                    }
                    else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["toplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                    {
                        dtgDetails.Rows[currentRow].Cells["toplananMiktar"].Style.BackColor = defaultColor;
                    }
                    else
                    {
                        dtgDetails.Rows[currentRow].Cells["toplananMiktar"].Style.BackColor = Color.OrangeRed;
                    }
                }
                dtgDetails.Rows[currentRow].Selected = false;
                barcode = "";
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM", "");
            }
        }
        private void btnDetay_KeyDown(object sender, KeyEventArgs e)
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

                MalGirisCikis malGirisCikis = new MalGirisCikis();
                List<MalGirisCikisDetay> malGirisCikisDetays = new List<MalGirisCikisDetay>();

                malGirisCikis.girisMiCikisMi = txtIslemTipi.Text;
                //malGirisCikis.belgeNo = Convert.ToInt32(txtBelgeNo.EditValue);
                //malGirisCikis.durum = cmbDurum.Text; //kullanılmıyor
                malGirisCikis.tarih = Convert.ToDateTime(dtpBelgeTar.Value);//??
                malGirisCikis.malCikisNo = txtMalCikisNo.Text;
                //malGirisCikis.referansNo = txtReferansNo.Text;//?

                malGirisCikis.aliciAdi = dtDetails.Rows[0]["U_AliciAdi"].ToString();
                malGirisCikis.aliciAdres = dtDetails.Rows[0]["U_Adres"].ToString();
                malGirisCikis.postaKodu = dtDetails.Rows[0]["U_ZipCode"].ToString();
                malGirisCikis.ilAdi = "";
                malGirisCikis.ilKodu = dtDetails.Rows[0]["U_City"].ToString();
                malGirisCikis.ilceKodu = dtDetails.Rows[0]["U_County"].ToString();
                malGirisCikis.ilceAdi = "";
                malGirisCikis.aliciSubeId = dtDetails.Rows[0]["U_AliciSubeId"].ToString();

                int i = 0;

                foreach (DataRow items in dtDetails.Rows)
                {
                    if (items["toplananMiktar"] == DBNull.Value || Convert.ToDouble(items["toplananMiktar"]) == 0)
                    { 
                        continue;
                    }

                    malGirisCikisDetays.Add(new MalGirisCikisDetay
                    {

                        urunKodu = items["ItemCode"].ToString(),
                        miktar = Convert.ToDouble(items["toplananMiktar"])
                    });

                    i++;
                }
                malGirisCikis.malGirisCikisDetays = malGirisCikisDetays.ToArray();

                if (malGirisCikis.malGirisCikisDetays == null)
                {
                    CustomMsgBox.Show("TÜM SATIRLARIN MİKTARI 0 OLAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                var resp1 = aIFTerminalServiceSoapClient1.AddOrUpdateMagazaMalGirisCikis(Giris._dbName,  SubeSecim.subeId, Giris.mKodValue, SubeSecim.subeAdi.ToUpper(),malGirisCikis);

                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

                if (resp1.Val == 0)
                {
                    MagazaTransfer_1.formAciliyor = true;
                    //DialogResult dialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
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
