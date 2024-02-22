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
    public partial class MagazaDepoMalKabul_3 : form_Base
    {
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        private string type = "";
        private string formName = "";
        public static double quantity = 0; 
        public MagazaDepoMalKabul_3(string _formName, string _type, string _itemCode, string _itemName, string _barkod, double _siparisMiktari, double _kabuledilen)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            //end font

            type = _type;
            formName = _formName;
            //toplananMiktar_3 = _toplananMiktar;
            if (type == "DepoKabul")// depo mal kabul
            {
                txtItemCode.Text = _itemCode;
                txtItemName.Text = _itemName;
                txtBarCode.Text = _barkod;
                //txtUomCode.Text = list[3].ToString();
                //txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.Text = Convert.ToDouble(_siparisMiktari).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtAccepted.Text = Convert.ToDouble(_kabuledilen).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtUnAccepted.Text = Convert.ToDouble(_siparisMiktari - _kabuledilen).ToString("N" + Giris.genelParametreler.OndalikMiktar);

                //var accept = Convert.ToDouble(txtAccepted.Text);
                //var unaccept = Convert.ToDouble(txtUnAccepted.Text);

                //var toplanmayan = unaccept - accept;

                //txtUnAccepted.Text = toplanmayan.ToString();

                txtOnOrder.ReadOnly = true;
                txtMiktar.Text = Convert.ToDouble(txtUnAccepted.Value).ToString("N" + Giris.genelParametreler.OndalikMiktar);
            }

            if (type == "DepoTransfer")
            {
                txtItemCode.Text = _itemCode;
                txtItemName.Text = _itemName;
                txtBarCode.Text = _barkod;
                //txtUomCode.Text = list[3].ToString();
                //txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.Text = Convert.ToDouble(_siparisMiktari).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtAccepted.Text = Convert.ToDouble(_kabuledilen).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtUnAccepted.Text = Convert.ToDouble(_siparisMiktari - _kabuledilen).ToString("N" + Giris.genelParametreler.OndalikMiktar);

                //var accept = Convert.ToDouble(txtAccepted.Text);
                //var unaccept = Convert.ToDouble(txtUnAccepted.Text);

                //var toplanmayan = unaccept - accept;

                //txtUnAccepted.Text = toplanmayan.ToString();

                txtOnOrder.ReadOnly = true;
                txtMiktar.Text = Convert.ToDouble(txtUnAccepted.Value).ToString("N" + Giris.genelParametreler.OndalikMiktar);
            }
        }

        #region font
        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;


            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

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

            label10.Font = new Font(label10.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label10.Font.Style);

            label14.Font = new Font(label14.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label14.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            txtItemCode.Font = new Font(txtItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemCode.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtWhsQuantity.Font = new Font(txtWhsQuantity.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWhsQuantity.Font.Style);

            txtUomCode.Font = new Font(txtUomCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUomCode.Font.Style);

            txtOnOrder.Font = new Font(txtOnOrder.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtOnOrder.Font.Style);

            txtAccepted.Font = new Font(txtAccepted.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtAccepted.Font.Style);

            txtUnAccepted.Font = new Font(txtUnAccepted.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUnAccepted.Font.Style);

            txtMiktar.Font = new Font(txtMiktar.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtMiktar.Font.Style);

            btnTamamla.Font = new Font(btnTamamla.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTamamla.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            //txtAccepted.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtItemCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtMiktar.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtOnOrder.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtUnAccepted.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtUomCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtWhsQuantity.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
        }
        #endregion

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
        private void MagazaDepoMalKabul_3_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            txtOnOrder.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtUnAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtMiktar.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
        }

        private void btnTamamla_Click(object sender, EventArgs e)
        {
            if (type == "DepoKabul")
            {
                #region onaydaki miktarve toplanna miktar toplamından fazla miktar girişi yapılmaması için eklendi

                double girilebilir = 0;
                girilebilir = Convert.ToDouble(txtAccepted.Value); //+ Convert.ToDouble(txtMiktar.Value);
                if (girilebilir > Convert.ToDouble(txtOnOrder.Value))
                {
                    CustomMsgBox.Show("FAZLA MİKTAR GİRİŞİ YAPTINIZ.", "Uyarı", "Tamam", "");
                    txtMiktar.Focus();
                    txtMiktar.Select(0, txtMiktar.Text.Length);
                    return;
                }

                #endregion onaydaki miktarve toplanna miktar toplamından fazla miktar girişi yapılmaması için eklendi

                quantity = txtMiktar.Text == "" ? 0 : Convert.ToDouble(txtMiktar.Value);
                DialogResult = DialogResult.OK;
                Close();
            }

            if (type == "DepoTransfer")
            {
                #region onaydaki miktarve toplanna miktar toplamından fazla miktar girişi yapılmaması için eklendi

                double girilebilir = 0;
                girilebilir = Convert.ToDouble(txtMiktar.Value); //+ Convert.ToDouble(txtMiktar.Value);
                if (girilebilir > Convert.ToDouble(txtOnOrder.Value))
                {
                    CustomMsgBox.Show("FAZLA MİKTAR GİRİŞİ YAPTINIZ.", "Uyarı", "Tamam", "");
                    txtMiktar.Focus();
                    txtMiktar.Select(0, txtMiktar.Text.Length);
                    return;
                }

                #endregion onaydaki miktarve toplanna miktar toplamından fazla miktar girişi yapılmaması için eklendi

                quantity = txtMiktar.Text == "" ? 0 : Convert.ToDouble(txtMiktar.Value);
                DialogResult = DialogResult.OK;
                Close();
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
