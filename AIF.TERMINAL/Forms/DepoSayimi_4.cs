using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class DepoSayimi_4 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        private DataTable dtBatch = new DataTable();

        public DepoSayimi_4(DataTable _dtBatchParam, double _sayilacakMiktar, string _itemCode, string _whsCode, string _formName, string _birim, string _partili, string _partino = "")
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            //end font
            //formName = _formName;
            //inventoryTransferLists = _inventoryTransferLists;

            dtBatch = _dtBatchParam;
            sayilacakmiktar = _sayilacakMiktar;
            ItemCode = _itemCode;
            whsCode = _whsCode;
            formName = _formName;
            birim = _birim;
            partili = _partili;
            if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
            {
                txtParti.Text = _partino;
            }
            if (partili != "Y")
            {
                TableLayoutRowStyleCollection styles = this.tableLayoutPanel1.RowStyles;
                styles[3].Height = 0;
                label4.Visible = false;
                txtParti.Visible = false;
                dtgDetails.Visible = false;
                btnUrunSay.Visible = false;
            }
        }

        private string formName = "";
        private double sayilacakmiktar = 0;

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            dtgDetails.Font = new Font(dtgDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgDetails.Font.Style);

            btnSelect.Font = new Font(btnSelect.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSelect.Font.Style);

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

            txtSayilan.Font = new Font(txtSayilan.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSayilan.Font.Style);

            txtPartili.Font = new Font(txtPartili.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartili.Font.Style);

            txtParti.Font = new Font(txtParti.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtParti.Font.Style);

            txtMiktar.Font = new Font(txtMiktar.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtMiktar.Font.Style);

            btnUrunSay.Font = new Font(btnUrunSay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnUrunSay.Font.Style);

            txtOlcuBirimi.Font = new Font(txtOlcuBirimi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtOlcuBirimi.Font.Style);
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

        private string ItemCode = "";
        private string whsCode = "";
        private string birim = "";
        private string partili = "";

        private void DepoSayimi_4_Load(object sender, EventArgs e)
        {
            TableLayoutRowStyleCollection styles = this.tableLayoutPanel1.RowStyles;

            frmName.Text = formName;
            dtgDetails.RowTemplate.Height = 55;
            dtgDetails.ColumnHeadersHeight = 60;

            txtMiktar.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtSayilan.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtPartili.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;

            #region sap dan gelen miktar(partili) satırının kaldırılması

            label3.Visible = false;
            txtPartili.Visible = false;

            styles[2].SizeType = SizeType.Absolute;
            styles[2].Height = 0;

            #endregion sap dan gelen miktar(partili) satırının kaldırılması

            Checkboxolustur();
            dtgDetails.DataSource = dtBatch;

            if (dtBatch != null)
            {
                dtgDetails.Columns["BatchNum"].HeaderText = "Parti No";
                dtgDetails.Columns["Quantity"].HeaderText = "Miktar";
                dtgDetails.Columns["Quantity"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                if (dtBatch.Rows.Count > 0)
                {
                    dtgDetails.Columns["ItemCode"].Visible = false;
                    dtgDetails.Columns["ItemName"].Visible = false;
                    dtgDetails.Columns["WhsCode"].Visible = false;
                    dtgDetails.Columns["WhsName"].Visible = false;

                    dtgDetails.Columns["BatchNum"].HeaderText = "Parti No";
                    dtgDetails.Columns["Quantity"].HeaderText = "Miktar";
                    dtgDetails.Columns["Quantity"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                    var sumQty = Convert.ToDouble(dtBatch.AsEnumerable().Select(z => z.Field<decimal>("Quantity")).Sum());

                    txtPartili.Value = Convert.ToDecimal(sumQty);

                    dtgDetails.RowTemplate.Height = 55;
                    dtgDetails.ColumnHeadersHeight = 60;
                }
            }

            txtSayilan.Value = sayilacakmiktar.ToString() == "" ? 0 : Convert.ToDecimal(sayilacakmiktar);
            txtOlcuBirimi.Text = birim;

            if (dtBatch.Rows.Count == 0)
            {
                txtMiktar.Value = sayilacakmiktar.ToString() == "" ? 0 : Convert.ToDecimal(sayilacakmiktar);
            }

            txtParti.Focus();
        }

        private DataGridViewCheckBoxColumn checkColumn = null;

        private void Checkboxolustur()
        {
            checkColumn = new DataGridViewCheckBoxColumn();

            checkColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn.HeaderText = "Seçim";
            checkColumn.Name = "ScmCheck";
            checkColumn.TrueValue = true;
            checkColumn.FalseValue = false;
            dtgDetails.Columns.Add(checkColumn);

            dtgDetails.RowHeadersVisible = false;
        }

        private void dtgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var partiNo = dtgDetails.Rows[e.RowIndex].Cells["BatchNum"].Value.ToString();
            var Quantity = Convert.ToDouble(dtgDetails.Rows[e.RowIndex].Cells["Quantity"].Value);

            txtParti.Text = partiNo;
            txtMiktar.Value = Convert.ToDecimal(Quantity);

            #region kaldırılmıştı-seçim görünmesi için açıldı(chn)

            DataGridViewRow row = dtgDetails.Rows[e.RowIndex];
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
            if (chk.Value == chk.FalseValue || chk.Value == null)
            {
                chk.Value = chk.TrueValue;
                dtgDetails.EndEdit();
            }
            else
            {
                chk.Value = chk.FalseValue;
            }

            #endregion kaldırılmıştı-seçim görünmesi için açıldı(chn)
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var sayilanMiktar = Convert.ToDouble(txtSayilan.Value);
            if (partili == "Y")
            {
                var partili = Convert.ToDouble(txtPartili.Value);

                if (dtgDetails.Rows.Count == 0)
                {
                    CustomMsgBox.Show("PARTİ NUMARASI GİRİLMEDEN İŞLEM YAPILAMAZ.", "UYARI", "TAMAM", "");
                    txtParti.Focus();
                    return;
                }

                double _partiMiktari = 0;
                foreach (DataGridViewRow dr in dtgDetails.Rows)
                {
                    _partiMiktari += Convert.ToDouble(dr.Cells["Quantity"].Value);
                }

                if (_partiMiktari != sayilanMiktar)
                {
                    CustomMsgBox.Show("PARTİ NUMARASI SEÇİMİ TAMAMLANMADAN DEVAM EDİLEMEZ.", "UYARI", "TAMAM", "");
                    txtParti.Focus();
                    return;
                }

                #region fazla giriş için kaldırıldı

                //if (sayilanMiktar != partili)
                //{
                //    CustomMsgBox.Show("PARTİ SEÇİMİ TAMAMLANMADIĞI İÇİN DEVAM EDİLEMEZ.", "UYARI", "TAMAM", "");
                //    return;
                //}

                #endregion fazla giriş için kaldırıldı

                foreach (DataGridViewRow dr in dtgDetails.Rows)
                {
                    bool check = Convert.ToBoolean(dr.Cells["ScmCheck"].Value);
                    //var depoKodu = dr.Cells["WhsCode"].Value.ToString();
                    var miktar = Convert.ToDouble(dr.Cells["Quantity"].Value);
                    var partiNo = dr.Cells["BatchNum"].Value.ToString();
                    //var itemCode = dr.Cells["ItemCode"].Value.ToString();

                    //if (check)
                    //{

                    #region fazla giriş için kaldırıldı

                    //double yazilacakMiktar = 0;

                    //if (miktar > sayilacakmiktar)
                    //{
                    //    yazilacakMiktar = sayilacakmiktar;
                    //}
                    //else
                    //{
                    //    yazilacakMiktar = miktar;
                    //}

                    #endregion fazla giriş için kaldırıldı

                    //var partivarmi = DepoSayimi_1.depoSayimiPartilers.Where(z => z.DepoKodu == whsCode && z.UrunKodu == ItemCode && z.PartiNo == partiNo).ToList(); //
                    var partivarmi = DepoSayimi_1.depoSayimiPartilers.Where(z => z.SatirNumarasi == DepoSayimi_1.satirNumarasi && z.PartiNo == partiNo).ToList();

                    if (partivarmi.Count() > 0)
                    {
                        double geciciMiktar = partivarmi.Select(x => x.Miktar).FirstOrDefault();

                        //DepoSayimi_1.depoSayimiPartilers.Where(z => z.DepoKodu == whsCode && z.UrunKodu == ItemCode && z.PartiNo == partiNo).ToList().ForEach(y => y.Miktar = miktar); //güncelleme
                        DepoSayimi_1.depoSayimiPartilers.Where(z => z.SatirNumarasi == DepoSayimi_1.satirNumarasi && z.PartiNo == partiNo).ToList().ForEach(y => y.Miktar = miktar);
                    }
                    else
                    {
                        DepoSayimi_1.depoSayimiPartilers.Add(new DepoSayimi_1.DepoSayimiPartiler { DepoKodu = whsCode, Miktar = miktar, PartiNo = partiNo, UrunKodu = ItemCode, SatirNumarasi = DepoSayimi_1.satirNumarasi });
                    }

                    #region fazla giriş için kaldırıldı

                    //sayilacakmiktar = sayilacakmiktar - yazilacakMiktar;
                    //if (sayilacakmiktar == 0)
                    //{
                    //    dialogResult = "Ok";
                    //    Close();
                    //    return;
                    //}
                    //}

                    #endregion fazla giriş için kaldırıldı
                }
            }
            else
            {
                partisizmiktar = txtMiktar.Value.ToString() == "" ? 0 : Convert.ToDouble(txtMiktar.Value);
            }
            dialogResult = "Ok";
            Close();
            return;
        }

        public static string dialogResult = "";
        public static double partisizmiktar = 0;

        private void btnUrunSay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtParti.Text == "")
                {
                    CustomMsgBox.Show("PARTİ NUMARASI GİRİLMEDEN İŞLEM YAPILAMAZ.", "UYARI", "TAMAM", "");
                    txtParti.Focus();
                    return;
                }

                if (txtMiktar.Value == 0)
                {
                    CustomMsgBox.Show("MİKTAR GİRİLMEDEN İŞLEM YAPILAMAZ.", "UYARI", "TAMAM", "");
                    txtMiktar.Focus();
                    txtMiktar.Select(0, txtMiktar.Text.Length);

                    return;
                }
                var sayilanMiktar = Convert.ToDouble(txtSayilan.Value);
                var partili = Convert.ToDouble(txtPartili.Value);
                //if (sayilanMiktar == partili)
                //{
                //    CustomMsgBox.Show("PARTİ SEÇİMİ TAMAMLANDI", "UYARI", "TAMAM", "");
                //    return;
                //}

                var parti = txtParti.Text;
                var miktar = Convert.ToDouble(txtMiktar.Value);

                var partivarmi = dtBatch.AsEnumerable().Where(x => x.Field<string>("BatchNum") == parti).ToList();
                if (partivarmi.Count > 0)
                {
                    if (miktar == 0)
                    {
                        for (int i = dtBatch.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = dtBatch.Rows[i];
                            if (dr["BatchNum"].ToString() == parti.ToString())
                            {
                                dr.Delete();
                                dtBatch.AcceptChanges();
                                txtParti.Text = "";
                                txtPartili.Value = 0;
                                i = -1;

                                if (dtBatch.Rows.Count > 0)
                                {
                                    var sumQty = Convert.ToDouble(dtBatch.AsEnumerable().Select(z => z.Field<decimal>("Quantity")).Sum());

                                    txtPartili.Value = Convert.ToDecimal(sumQty);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = dtBatch.Rows.Count - 1; i >= 0; i--)
                        {
                            //txtPartili.Value = 0;
                            DataRow dr = dtBatch.Rows[i];
                            if (dr["BatchNum"].ToString() == parti.ToString())
                            {
                                dr["Quantity"] = txtMiktar.Value;
                                //dr.Delete();
                                dtBatch.AcceptChanges();
                                txtParti.Text = "";
                                txtPartili.Value = txtMiktar.Value;
                                txtMiktar.Value = 0;
                                i = -1;

                                if (dtBatch.Rows.Count > 0)
                                {
                                    var sumQty = Convert.ToDouble(dtBatch.AsEnumerable().Select(z => z.Field<decimal>("Quantity")).Sum());

                                    txtPartili.Value = Convert.ToDecimal(sumQty);
                                }
                            }
                        }
                    }
                }
                else
                {
                    DataRow dr = dtBatch.NewRow();
                    dr["BatchNum"] = parti;
                    dr["Quantity"] = miktar;

                    dtBatch.Rows.Add(dr);

                    txtPartili.Value = Convert.ToDecimal(txtPartili.Value) + Convert.ToDecimal(miktar);
                    txtParti.Text = "";
                    txtMiktar.Value = 0;

                    if (dtBatch.Rows.Count > 0)
                    {
                        var sumQty = Convert.ToDouble(dtBatch.AsEnumerable().Select(z => z.Field<decimal>("Quantity")).Sum());

                        txtPartili.Value = Convert.ToDecimal(sumQty);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void txtMiktar_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtMiktar, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }
    }
}