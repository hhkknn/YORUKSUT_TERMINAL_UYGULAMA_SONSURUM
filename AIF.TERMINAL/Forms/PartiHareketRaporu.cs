using AIF.TERMINAL.AIFTerminalService;
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
    public partial class PartiHareketRaporu : form_Base
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        public PartiHareketRaporu(string _formName)
        {
            InitializeComponent();

            //font start.
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;
            formName = _formName;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            lblPartiNo.Font = new Font(lblPartiNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblPartiNo.Font.Style);

            lblDepoKodu.Font = new Font(lblDepoKodu.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblDepoKodu.Font.Style);

            lblKalemKodu.Font = new Font(lblKalemKodu.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblKalemKodu.Font.Style);

            lblKalemAdi.Font = new Font(lblKalemAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblKalemAdi.Font.Style);

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            txtPartiNo.Font = new Font(txtPartiNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartiNo.Font.Style);

            txtDepoKodu.Font = new Font(txtDepoKodu.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtDepoKodu.Font.Style);

            txtKalemAdi.Font = new Font(txtKalemAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtKalemAdi.Font.Style);

            txtCikisGiris.Font = new Font(txtCikisGiris.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCikisGiris.Font.Style);

            cmbWareHouseName.Font = new Font(cmbWareHouseName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbWareHouseName.Font.Style);

            lblKalemKodu.Font = new Font(lblKalemKodu.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblKalemKodu.Font.Style);

            btnListele.Font = new Font(btnListele.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnListele.Font.Style);

            btnTemizle.Font = new Font(btnTemizle.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTemizle.Font.Style);

            dtgPartiHareketRapor.Font = new Font(dtgPartiHareketRapor.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgPartiHareketRapor.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtPartiNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtDepoKodu.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbWareHouseName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtKalemKodu.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtKalemAdi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtCikisGiris.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            ////font end.
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
        private DataView dtview = new DataView();
        private DataTable dtPartiliHareketRapor = new DataTable();
        private DataTable dt = new DataTable();
        private DataTable dtWarehouses = new DataTable();
        public static string ItemCode = "";

        private void PartiHareketRaporu_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            txtPartiNo.Focus();

            dtgPartiHareketRapor.RowTemplate.Height = 55;
            dtgPartiHareketRapor.ColumnHeadersHeight = 60;
            //dtgPartiHareketRapor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //cmbItemName.Font = new Font("Tahoma", 26);

            vScrollBar1.Maximum = dtgPartiHareketRapor.RowCount;

            GetWareHouseByUserCodeAddName();
        }

        private void GetWareHouseByUserCodeAddName()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;

            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCodeAddName(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCodeAddName(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtWarehouses = resp._list;
                    cmbWareHouseName.DisplayMember = "WhsName";
                    cmbWareHouseName.ValueMember = "WhsCode";
                    cmbWareHouseName.DataSource = dtWarehouses;

                    cmbWareHouseName.Enabled = true;

                    if (txtDepoKodu.Text.ToString() == "System.Data.DataRowView")
                    {
                        txtDepoKodu.Text = "";
                    }
                }
            }
            vScrollBar1.Maximum = dtgPartiHareketRapor.RowCount;
        }

        private void PartiHareketVeriGetir()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;

            resp = aIFTerminalServiceSoapClient.GetPartiliHareketRaporu(Giris._dbName, txtPartiNo.Text, txtDepoKodu.Text, txtKalemKodu.Text, Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtgPartiHareketRapor.DataSource = resp._list;
                    dt = resp._list;

                    //dtgPartiHareketRapor.Columns["ItemCode"].Visible = false;
                    //var sum = dt.AsEnumerable().Sum(x => x.Field<decimal>("OnHand"));

                    var sumCikis = dt.AsEnumerable().Where(c => c.Field<string>("Yön") == "Cikis").Sum(x => x.Field<decimal>("Miktar"));
                    var sumGiris = dt.AsEnumerable().Where(c => c.Field<string>("Yön") == "Giris").Sum(x => x.Field<decimal>("Miktar"));
                    double sumTotal = Convert.ToDouble(sumGiris) - Convert.ToDouble(sumCikis);
                    txtCikisGiris.Text = sumTotal.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                    dtgPartiHareketRapor.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                    //dtgProductDetails.Columns["ItemCode"].HeaderText = "KALEM KODU";

                    //dtgPartiHareketRapor.Columns["Belge Tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dtgPartiHareketRapor.Columns["Belge Türü"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dtgPartiHareketRapor.Columns["Belge No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dtgPartiHareketRapor.Columns["Yön"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dtgPartiHareketRapor.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    //dtgProductDetails.Columns["WhsName"].Width = dtgProductDetails.Width - dtgProductDetails.Columns["WhsCode"].Width - dtgProductDetails.Columns["OnHand"].Width - dtgProductDetails.Columns["UomCode"].Width;

                    dtgPartiHareketRapor.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    vScrollBar1.Maximum = dtgPartiHareketRapor.RowCount + 5;
                }
            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "UYARI", "TAMAM", "");
            }
        }

        private void GetWareHouse()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetWareHouse(Giris._dbName, Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dt = resp._list;

                    var whs = dt.AsEnumerable().Where(x => x.Field<string>("WhsCode") == txtDepoKodu.Text).ToList();

                    if (whs.Count > 0)
                    {
                        var whsname = whs[0][1].ToString();

                        if (dtWarehouses.AsEnumerable().Where(x => x.Field<string>("WhsCode") == txtDepoKodu.Text).Count() == 0)
                        {
                            CustomMsgBox.Show("" + whsname + " ADLI DEPO İÇİN YETKİNİZ BULUNMAMAKTADIR.", "Uyarı", "TAMAM", "");
                            cmbWareHouseName.SelectedValue = "";
                            return;
                        }
                        else
                        {
                            cmbWareHouseName.SelectedValue = whs[0][0].ToString();
                            //cmbWareHouseName.Text = whsname.ToString();
                        }
                    }
                    else
                    {
                        CustomMsgBox.Show("" + txtDepoKodu.Text + " KODLU DEPO BULUNAMADI.", "Uyarı", "TAMAM", "");
                        cmbWareHouseName.SelectedValue = "";
                        txtDepoKodu.Text = "";
                        return;
                    }
                }
            }
        }

        private void txtPartiNo_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtDepoKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetWareHouse();
            }
        }

        private void txtKalemKodu_Click(object sender, EventArgs e)
        {
            txtKalemKodu.Text = "";
            txtKalemAdi.Text = "";
            txtCikisGiris.Text = "";
            SelectList nesne = new SelectList("PartiHareketRaporu", "KalemAra", "KALEM ARAMA", txtKalemKodu, txtKalemAdi);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (SelectList.dialogResult == "Ok")
            {
                txtKalemKodu.Text = ItemCode;
                SelectList.dialogResult = "";
            }
        }

        private void txtKalemAdi_Click(object sender, EventArgs e)
        {
            txtKalemKodu.Text = "";
            txtKalemAdi.Text = "";
            txtCikisGiris.Text = "";
            SelectList nesne = new SelectList("PartiHareketRaporu", "KalemAra", "KALEM ARAMA", txtKalemKodu, txtKalemAdi);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (SelectList.dialogResult == "Ok")
            {
                txtKalemKodu.Text = ItemCode;
                SelectList.dialogResult = "";
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            if (txtPartiNo.Text == "")
            {
                CustomMsgBox.Show("LÜTFEN PARTİ NUMARASI GİRİNİZ.", "Uyarı", "TAMAM", "");
                return;
            }

            if (txtDepoKodu.Text == "")
            {
                CustomMsgBox.Show("LÜTFEN DEPO KODU GİRİNİZ.", "Uyarı", "TAMAM", "");
                return;
            }

            if (txtKalemKodu.Text == "")
            {
                CustomMsgBox.Show("LÜTFEN KALEM KODU GİRİNİZ.", "Uyarı", "TAMAM", "");
                return;
            }

            try
            {
                PartiHareketVeriGetir();
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "Uyarı", "TAMAM", "");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void temizle()
        {
            dtgPartiHareketRapor.DataSource = null;
            txtPartiNo.Text = "";
            txtDepoKodu.Text = "";
            cmbWareHouseName.Text = "";
            txtKalemKodu.Text = "";
            txtKalemAdi.Text = "";
            txtCikisGiris.Text = "";
        }

        private void cmbWareHouseName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbWareHouseName.SelectedValue != null)
            {
                txtDepoKodu.Text = "";

                var whsCode = cmbWareHouseName.SelectedValue.ToString();

                if (whsCode == "")
                {
                    return;
                }
                //dtgWareHouseDetails.DataSource = null;

                txtDepoKodu.Text = whsCode;
                //GetWareHouseDetailsWithQty();
            }
        }
    }
}