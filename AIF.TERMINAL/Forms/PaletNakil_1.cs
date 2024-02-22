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
    public partial class PaletNakil_1 : form_Base
    {
        //start font
        public int initialWidth; 
        public int initialHeight;
        public float initialFontSize;
        //end font
         
        private DataTable dtcmbWarehouseSource = new DataTable();
        private DataTable dtcmbWarehouseTarget = new DataTable();
        private DataTable dtcmbCardCode = new DataTable();

        private string formName = "";

        private DataView dtview = new DataView();

        public static string fromWhsCode = "";
        public static string ToWhsCode = "";

        //public static int currentRow = 0;
        private DataTable dtPaletNakilDetay = new DataTable();
        private DataTable dtPaletNakilParti = new DataTable();
        public static List<StokTransferBatch> StokTransferBatches = new List<StokTransferBatch>();
        public static string arananItemCode = "";

        public static List<PaletYapmaPartiler> paletYapmaPartilers = new List<PaletYapmaPartiler>();

        public PaletNakil_1(string _formName)
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

            label9.Font = new Font(label9.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label9.Font.Style);

            lblItemName.Font = new Font(lblItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemName.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtCustomerCode.Font = new Font(txtCustomerCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCustomerCode.Font.Style);

            cmbCarCode.Font = new Font(cmbCarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbCarCode.Font.Style);

            cmbToWhsCode.Font = new Font(cmbToWhsCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbToWhsCode.Font.Style);

            cmbFromWhsCode.Font = new Font(cmbFromWhsCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbFromWhsCode.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               cmbItemName.Font.Style);

            dtpDocDate.Font = new Font(dtpDocDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpDocDate.Font.Style);

            dtpDocDueDate.Font = new Font(dtpDocDueDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpDocDueDate.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            txtSourceCode.Font = new Font(txtSourceCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSourceCode.Font.Style);

            txtTargetCode.Font = new Font(txtTargetCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtTargetCode.Font.Style);

            btnPaletNakliYap.Font = new Font(btnPaletNakliYap.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPaletNakliYap.Font.Style);

            btnDetay.Font = new Font(btnDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDetay.Font.Style);

            btnSearch.Font = new Font(btnSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSearch.Font.Style);

            btnItemSearch.Font = new Font(btnItemSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnItemSearch.Font.Style); 

            dtgPaletNakilDetay.Font = new Font(dtgPaletNakilDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgPaletNakilDetay.Font.Style);

            txtCustomerName.Font = new Font(txtCustomerName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCustomerName.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtKaynakDepoYeriId.Font = new Font(txtKaynakDepoYeriId.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtKaynakDepoYeriId.Font.Style);

            txtKaynakDepoYeriAdi.Font = new Font(txtKaynakDepoYeriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtKaynakDepoYeriAdi.Font.Style);

            txtHedefDepoYeriId.Font = new Font(txtHedefDepoYeriId.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtHedefDepoYeriId.Font.Style);

            txtHedefDepoYeriAdi.Font = new Font(txtHedefDepoYeriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtHedefDepoYeriAdi.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtCustomerCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtCustomerName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            dtpDocDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpDocDueDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            cmbFromWhsCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbToWhsCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtSourceCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtTargetCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            cmbFromWhsCode.DropDownWidth = cmbFromWhsCode.Width + btnDetay.Width;
            cmbToWhsCode.DropDownWidth = cmbToWhsCode.Width + btnDetay.Width;

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
         
        private void PaletNakil_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            txtBarCode.Focus();
            dtgPaletNakilDetay.RowTemplate.Height = 55;
            dtgPaletNakilDetay.ColumnHeadersHeight = 60;

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpszDepK", Giris.mKodValue);
            }

            Response resp1 = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp1 = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp1 = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpszDepH", Giris.mKodValue);
            }

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtcmbWarehouseSource = resp._list;
                    dtcmbWarehouseTarget = resp1._list;

                    cmbFromWhsCode.DataSource = dtcmbWarehouseSource;
                    cmbFromWhsCode.DisplayMember = "WhsName";
                    cmbFromWhsCode.ValueMember = "WhsCode";
                    cmbFromWhsCode.Enabled = true;

                    cmbToWhsCode.DataSource = dtcmbWarehouseTarget;
                    cmbToWhsCode.DisplayMember = "WhsName";
                    cmbToWhsCode.ValueMember = "WhsCode";
                    cmbToWhsCode.Enabled = true;
                }
            }

            Response resp3 = aIFTerminalServiceSoapClient.GetAllBusinessPartner(Giris._dbName, Giris.mKodValue);

            if (resp3.Val == 0)
            {
                dtview = new DataView(resp3._list);
                dtcmbCardCode = resp3._list;
                cmbCarCode.DataSource = null;
                cmbCarCode.DataSource = dtcmbCardCode;
                cmbCarCode.DisplayMember = "CardName";
                cmbCarCode.ValueMember = "CardCode";
                cmbCarCode.Enabled = true;
            }

            dtPaletNakilDetay.Columns.Add("Palet No", typeof(string));
            dtPaletNakilDetay.Columns.Add("Kalem Kodu", typeof(string));
            dtPaletNakilDetay.Columns.Add("Kalem Tanımı", typeof(string));
            dtPaletNakilDetay.Columns.Add("Ölçü Birimi", typeof(string));
            dtPaletNakilDetay.Columns.Add("Barkod", typeof(string));
            dtPaletNakilDetay.Columns.Add("Miktar", typeof(double));
            dtPaletNakilDetay.Columns.Add("DepoMiktar", typeof(double));
            dtPaletNakilDetay.Columns.Add("Partili", typeof(string));
            dtPaletNakilDetay.Columns.Add("DepoKodu", typeof(string));
            dtPaletNakilDetay.Columns.Add("PaletIciKoliAD", typeof(double));
            dtPaletNakilDetay.Columns.Add("KoliIciAD", typeof(double));
            dtPaletNakilDetay.Columns.Add("PaletIciAD", typeof(double));

            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                try
                {
                    dtPaletNakilDetay.Columns.Add("HDepoYeriId", typeof(string));
                    dtPaletNakilDetay.Columns.Add("HDepoYeriAdi", typeof(string));
                    dtPaletNakilDetay.Columns.Add("KDepoYeriId", typeof(string));
                    dtPaletNakilDetay.Columns.Add("KDepoYeriAdi", typeof(string));
                }
                catch (Exception)
                {
                }
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            btn = new DataGridViewButtonColumn();
            dtgPaletNakilDetay.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Detay";
            btn.Name = "btnDetail";
            btn.UseColumnTextForButtonValue = true;

            dtgPaletNakilDetay.DataSource = dtPaletNakilDetay;
            if (dtgPaletNakilDetay.Columns.Contains("FromWhsCode") != true)
            {
                addcomboFromWhsCode();
            }

            if (dtgPaletNakilDetay.Columns.Contains("ToWhsCode") != true)
            {
                addcomboToWhsCode();
            }

            dtgPaletNakilDetay.Columns["DepoMiktar"].Visible = false;
            dtgPaletNakilDetay.Columns["btnDetail"].Visible = false;
            dtgPaletNakilDetay.Columns["Barkod"].Visible = false;

            dtgPaletNakilDetay.Columns["Kalem Kodu"].Visible = false;
            dtgPaletNakilDetay.Columns["Partili"].Visible = false;

            dtgPaletNakilDetay.Columns["PaletIciKoliAD"].Visible = false;
            dtgPaletNakilDetay.Columns["KoliIciAD"].Visible = false;
            dtgPaletNakilDetay.Columns["PaletIciAD"].Visible = false;

            dtgPaletNakilDetay.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

            foreach (DataGridViewColumn column in dtgPaletNakilDetay.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgPaletNakilDetay.Rows.Count > 0)
            {
                dtgPaletNakilDetay.Rows[0].Selected = false;
            }

            dtgPaletNakilDetay.EnableHeadersVisualStyles = false;


            dtgPaletNakilDetay.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
            dtgPaletNakilDetay.Columns["Kalem Tanımı"].HeaderText = "KALEM ADI";
            dtgPaletNakilDetay.Columns["Ölçü Birimi"].HeaderText = "BRM";
            dtgPaletNakilDetay.Columns["Barkod"].HeaderText = "BARKOD";
            dtgPaletNakilDetay.Columns["Miktar"].HeaderText = "MİKTAR";
            dtgPaletNakilDetay.Columns["DepoMiktar"].HeaderText = "DEPO MİK.";
            dtgPaletNakilDetay.Columns["Partili"].HeaderText = "PARTİLİ";

            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                txtHedefDepoYeriId.Visible = false;
                txtHedefDepoYeriAdi.Visible = false;
                txtKaynakDepoYeriAdi.Visible = false;
                txtKaynakDepoYeriId.Visible = false;
            }
            else
            {
                dtgPaletNakilDetay.Columns["HDepoYeriId"].HeaderText = "HDF DEPO YER";
                dtgPaletNakilDetay.Columns["HDepoYeriAdi"].HeaderText = "HDF DEPO YER AD";
                dtgPaletNakilDetay.Columns["KDepoYeriId"].HeaderText = "KAYNAK DEPO YER";
                dtgPaletNakilDetay.Columns["KDepoYeriAdi"].HeaderText = "KYNK DEPO YER AD";

                dtgPaletNakilDetay.Columns["HDepoYeriId"].Visible = false;
                dtgPaletNakilDetay.Columns["KDepoYeriId"].Visible = false;
            }

            dtgPaletNakilDetay.Columns["Kalem Kodu"].ReadOnly = true;
            dtgPaletNakilDetay.Columns["Kalem Tanımı"].ReadOnly = true;
            dtgPaletNakilDetay.Columns["Ölçü Birimi"].ReadOnly = true;
            dtgPaletNakilDetay.Columns["Miktar"].ReadOnly = true;
            dtgPaletNakilDetay.Columns["Partili"].ReadOnly = true;

            vScrollBar1.Maximum = dtgPaletNakilDetay.RowCount + 5;

            //dtgProducts.Columns["Kalem Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgPaletNakilDetay.Columns["Ölçü Birimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgPaletNakilDetay.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                dtgPaletNakilDetay.Columns["HDepoYeriId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPaletNakilDetay.Columns["HDepoYeriAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPaletNakilDetay.Columns["KDepoYeriId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgPaletNakilDetay.Columns["KDepoYeriAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            //dtgProducts.Columns["Partili"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgPaletNakilDetay.Columns["FromWhsCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dtgPaletNakilDetay.Columns["ToWhsCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dtgPaletNakilDetay.Columns["Kalem Tanımı"].Width = dtgPaletNakilDetay.Width - dtgPaletNakilDetay.Columns["Ölçü Birimi"].Width - dtgPaletNakilDetay.Columns["Miktar"].Width -
            dtgPaletNakilDetay.Columns["FromWhsCode"].Width - dtgPaletNakilDetay.Columns["ToWhsCode"].Width;
            //cmbCarCode.Focus();
        }
        int maxdetaysatirno = -1;
        private void PaletYapmaListesiDetay()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.getPaletYapmaListesiDetaylari(Giris._dbName, txtBarCode.Text, Giris.mKodValue, Giris.genelParametreler.CekmeListesiKalemleriniGrupla);

            if (resp._list.Rows != null)
            {
                dtPaletNakilDetay = resp._list;
                dtgPaletNakilDetay.DataSource = null;

                if (Giris.genelParametreler.PaletYapmadaDepoSecilsin == "Y")
                {
                    dtPaletNakilParti = new DataTable();
                    paletYapmaPartilers = new List<PaletYapmaPartiler>();
                    //PartileriListele();
                }

                dtgPaletNakilDetay.DataSource = dtPaletNakilDetay;

                dtgPaletNakilDetay.RowTemplate.Height = 55;
                dtgPaletNakilDetay.ColumnHeadersHeight = 60;

                dtgPaletNakilDetay.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                //dtPaletYapmaListesiDetay.Columns.Add("dtgSira", typeof(int));

                if (Giris.genelParametreler.PaletYapmadaDepoSecilsin == "Y")
                {
                    dtPaletNakilDetay.Columns.Add("ToplananMiktar", typeof(double));
                }
                if (resp._list.Rows.Count > 0)
                {
                    var max = resp._list.AsEnumerable().Select(x => x.Field<int>("DetaySatirNo")).Max();
                    maxdetaysatirno = Convert.ToInt32(max + 1);
                    for (int i = 0; i <= dtgPaletNakilDetay.Rows.Count - 1; i++)
                    {
                        //dtgPaletListesiDetay.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                        if (dtgPaletNakilDetay.Rows[i].Cells["DetaySatirNo"].Value == null || dtgPaletNakilDetay.Rows[i].Cells["DetaySatirNo"].Value.ToString() == "" || Convert.ToInt32(dtgPaletNakilDetay.Rows[i].Cells["DetaySatirNo"].Value) == -1)
                        {
                            dtgPaletNakilDetay.Rows[i].Cells["DetaySatirNo"].Value = Convert.ToInt32(maxdetaysatirno);
                            maxdetaysatirno = maxdetaysatirno + 1;
                        }
                        if (Giris.genelParametreler.PaletYapmadaDepoSecilsin == "Y")
                        {
                            dtgPaletNakilDetay.Rows[i].Cells["ToplananMiktar"].Value = paletYapmaPartilers.Where(x => x.PartiSatirNo == Convert.ToInt32(dtgPaletNakilDetay.Rows[i].Cells["DetaySatirNo"].Value)).Select(c => c.Miktar).Sum();
                        }
                    }
                }
                else
                {
                    //var max = resp._list.AsEnumerable().Select(x => x.Field<int>("DetaySatirNo")).Max();
                    maxdetaysatirno = Convert.ToInt32(0);
                    for (int i2 = 0; i2 <= dtgPaletNakilDetay.Rows.Count - 1; i2++)
                    {
                        //dtgPaletListesiDetay.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                        if (dtgPaletNakilDetay.Rows[i2].Cells["DetaySatirNo"].Value == null || dtgPaletNakilDetay.Rows[i2].Cells["DetaySatirNo"].Value.ToString() == "" || Convert.ToInt32(dtgPaletNakilDetay.Rows[i2].Cells["DetaySatirNo"].Value) == -1)
                        {
                            dtgPaletNakilDetay.Rows[i2].Cells["DetaySatirNo"].Value = Convert.ToInt32(maxdetaysatirno);
                            maxdetaysatirno = maxdetaysatirno + 1;
                        }
                        if (Giris.genelParametreler.PaletYapmadaDepoSecilsin == "Y")
                        {
                            dtgPaletNakilDetay.Rows[i2].Cells["ToplananMiktar"].Value = paletYapmaPartilers.Where(x => x.PartiSatirNo == Convert.ToInt32(dtgPaletNakilDetay.Rows[i2].Cells["DetaySatirNo"].Value)).Select(c => c.Miktar).Sum();
                        }
                    }
                }

                dtgPaletNakilDetay.Columns["Kalem Tanimi"].HeaderText = "Kalem Tanımı";

                //dtgPaletListesiDetay.Columns["dtgSira"].Visible = false;
                dtgPaletNakilDetay.Columns["ToplamKap"].Visible = false;
                dtgPaletNakilDetay.Columns["NetKilo"].Visible = false;
                dtgPaletNakilDetay.Columns["BrutKilo"].Visible = false;
                dtgPaletNakilDetay.Columns["SiparisNumarasi"].Visible = false;
                dtgPaletNakilDetay.Columns["SiparisSatirNo"].Visible = false;
                dtgPaletNakilDetay.Columns["MuhatapKatalogNo"].Visible = false;
                dtgPaletNakilDetay.Columns["CekmeNo"].Visible = false;
                dtgPaletNakilDetay.Columns["SatirKaynagi"].Visible = false;
                //dtgPaletListesiDetay.Columns["DetaySatirNo"].Visible = false;

                dtgPaletNakilDetay.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgPaletNakilDetay.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (Giris.genelParametreler.PaletYapmadaDepoSecilsin == "Y")
                {

                    dtgPaletNakilDetay.Columns["ToplananMiktar"].HeaderText = "TOP.MİK";
                    dtgPaletNakilDetay.Columns["ToplananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                    dtgPaletNakilDetay.Columns["ToplananMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                }
                 

                vScrollBar1.Maximum = dtgPaletNakilDetay.RowCount + 5;

                if (resp._list.Rows.Count > 0)
                {
                    //txtToplamKap.Text = resp._list.Rows[0]["ToplamKap"] == DBNull.Value ? "0" : string.Format("{0:#,##0.0000}", double.Parse(resp._list.Rows[0]["ToplamKap"].ToString()));
                    //txtNetKilo.Text = resp._list.Rows[0]["NetKilo"] == DBNull.Value ? "0" : string.Format("{0:#,##0.0000}", double.Parse(resp._list.Rows[0]["NetKilo"].ToString()));
                    //txtBrutKilo.Text = resp._list.Rows[0]["BrutKilo"] == DBNull.Value ? "0" : string.Format("{0:#,##0.0000}", double.Parse(resp._list.Rows[0]["BrutKilo"].ToString()));
                }
            }
            else
            {
                dtgPaletNakilDetay.DataSource = null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtview.RowFilter = "CardCode like '%" + cmbCarCode.Text + "%' or CardName like '%" + cmbCarCode.Text + "%' or  CardCode = '' or CardName =''";

            cmbCarCode.DataSource = null;
            cmbCarCode.DisplayMember = "CardName";
            cmbCarCode.ValueMember = "CardCode";
            cmbCarCode.DataSource = dtview;

            cmbCarCode.DroppedDown = true;
        }

        private void cmbCarCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCarCode.SelectedIndex > 0)
            {
                string code = cmbCarCode.SelectedValue.ToString();
                txtCustomerCode.Text = code;
            }
            else
            {
                txtCustomerCode.Text = "";
            }
        }
        private void addcomboFromWhsCode()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response r = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpszDepK", Giris.mKodValue);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(r._list);

            DataGridViewComboBoxColumn comboLookup = new DataGridViewComboBoxColumn();
            comboLookup.DataSource = ds.Tables[0];
            comboLookup.HeaderText = "KAYNAK";
            comboLookup.Name = "FromWhsCode";
            comboLookup.DisplayMember = "WhsName";
            comboLookup.ValueMember = "WhsCode";
            dtgPaletNakilDetay.Columns.Add(comboLookup);
        }

        private void addcomboToWhsCode()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response r = null;

            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_TlpszDepH", Giris.mKodValue);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(r._list);

            DataGridViewComboBoxColumn comboLookup = new DataGridViewComboBoxColumn();
            comboLookup.DataSource = ds.Tables[0];
            comboLookup.HeaderText = "HEDEF";
            comboLookup.Name = "ToWhsCode";
            comboLookup.DisplayMember = "WhsName";
            comboLookup.ValueMember = "WhsCode";
            dtgPaletNakilDetay.Columns.Add(comboLookup);
        } 
         
        private void btnDetay_Click(object sender, EventArgs e)
        { 
        }

        private void btnPaletNakliYap_Click(object sender, EventArgs e)
        {

        }
    }
}
