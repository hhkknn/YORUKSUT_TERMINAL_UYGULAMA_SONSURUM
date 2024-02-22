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
    public partial class SayiKlavyesi : form_Base
    {
        //font start
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end

        private DataGridView dtgridParams = null;
        private string basevalue = "";
        private bool timeField = false;
        private NumericUpDown tparam = new NumericUpDown();
        private TextBox txtParam = new TextBox();
        //private TextBox tparam = new TextBox();
        public static string GirisOk = "";
        public SayiKlavyesi(NumericUpDown text, DataGridView _dtgridParams = null, bool _timeField = false, TextBox _txtParam = null)
        {
            InitializeComponent();

            tparam = text;
            dtgridParams = _dtgridParams;
            txtParam = _txtParam;
            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = txtSayiGirisi.Font.Size;
            txtSayiGirisi.Resize += Form_Resize;
            //font end

            System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

            if (text != null)
            {
                try
                {
                    #region ondalık hatası için eklendi
                    double sayi = parseNumber_Seperator.ConvertToDouble(text.Value.ToString());
                    txtSayiGirisi.Text = sayi.ToString("N" + Giris.genelParametreler.OndalikMiktar, cultureTR);
                    #endregion
                    //txtSayiGirisi.Text = Convert.ToDouble(text.Text).ToString("N"+Giris.genelParametreler.OndalikMiktar, cultureTR);
                }
                catch (Exception)
                {
                }
            }
            else if (txtParam != null)
            {
                try
                {
                    #region ondalık hatası için eklendi
                    double sayi = parseNumber_Seperator.ConvertToDouble(text.Value.ToString());
                    txtParam.Text = sayi.ToString();
                    #endregion
                    txtSayiGirisi.Text = txtParam.Text == "" ? Convert.ToDouble("0").ToString("N" + Giris.genelParametreler.OndalikMiktar, cultureTR) : Convert.ToDouble(txtParam.Text).ToString("N" + Giris.genelParametreler.OndalikMiktar, cultureTR);
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    if (dtgridParams.Name == "dtgKoliGirisi")
                    {
                        #region ondalık hatası için eklendi
                        double sayi = parseNumber_Seperator.ConvertToDouble(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells[dtgridParams.CurrentCell.ColumnIndex].Value.ToString());

                        txtSayiGirisi.Text = sayi.ToString("N"+ Giris.genelParametreler.OndalikMiktar, cultureTR);
                        #endregion

                        txtSayiGirisi.Text = Convert.ToDouble(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells[dtgridParams.CurrentCell.ColumnIndex].Value).ToString("N"+ Giris.genelParametreler.OndalikMiktar, cultureTR);
                    }
                }
                catch (Exception)
                {
                }
            }
            basevalue = txtSayiGirisi.Text;
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            btnBir.Font = new Font(btnBir.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnBir.Font.Style);

            btnIki.Font = new Font(btnIki.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnIki.Font.Style);

            btnUc.Font = new Font(btnUc.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnUc.Font.Style);

            btnDort.Font = new Font(btnDort.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnDort.Font.Style);

            btnBes.Font = new Font(btnBes.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnBes.Font.Style);

            btnAlti.Font = new Font(btnAlti.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAlti.Font.Style);

            btnYedi.Font = new Font(btnYedi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnYedi.Font.Style);

            btnSekiz.Font = new Font(btnSekiz.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSekiz.Font.Style);

            btnDokuz.Font = new Font(btnDokuz.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnDokuz.Font.Style);

            btnVirgul.Font = new Font(btnVirgul.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnVirgul.Font.Style);

            btnSifir.Font = new Font(btnSifir.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSifir.Font.Style);

            btnSil.Font = new Font(btnSil.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSil.Font.Style);

            btnGiris.Font = new Font(btnGiris.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnGiris.Font.Style);

            btnTire.Font = new Font(btnTire.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnTire.Font.Style);

            btnIptal.Font = new Font(btnIptal.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnIptal.Font.Style);

            txtSayiGirisi.Font = new Font(txtSayiGirisi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtSayiGirisi.Font.Style);

            ResumeLayout();
            //font end
            //watch.Stop();
            //MessageBox.Show(string.Format("Süre: {0}", watch.Elapsed.TotalMilliseconds));

            //start yükseklik-genislik
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
        private void textboxTemizle()
        {
            if (txtSayiGirisi.Text == basevalue)
            {
                txtSayiGirisi.Text = "";
            }
        }
        private void SayiKlavyesi_Load(object sender, EventArgs e)
        {

            txtSayiGirisi.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
        }

        private void btnBir_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtSayiGirisi.Text = txtSayiGirisi.Text + "1";
        }

        private void btnIki_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtSayiGirisi.Text = txtSayiGirisi.Text + "2";
        }

        private void btnUc_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtSayiGirisi.Text = txtSayiGirisi.Text + "3";
        }

        private void btnDort_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtSayiGirisi.Text = txtSayiGirisi.Text + "4";
        }

        private void btnBes_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtSayiGirisi.Text = txtSayiGirisi.Text + "5";
        }

        private void btnAlti_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtSayiGirisi.Text = txtSayiGirisi.Text + "6";
        }

        private void btnYedi_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtSayiGirisi.Text = txtSayiGirisi.Text + "7";
        }

        private void btnSekiz_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtSayiGirisi.Text = txtSayiGirisi.Text + "8";
        }

        private void btnDokuz_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtSayiGirisi.Text = txtSayiGirisi.Text + "9";
        }

        private void btnVirgul_Click(object sender, EventArgs e)
        {
            if (!txtSayiGirisi.Text.Contains(","))
            {
                txtSayiGirisi.Text = txtSayiGirisi.Text + ",";
            }
        }

        private void btnSifir_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtSayiGirisi.Text = txtSayiGirisi.Text + "0";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                txtSayiGirisi.Text = txtSayiGirisi.Text.Remove(txtSayiGirisi.Text.Length - 1, 1);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (timeField)
            {
                if (txtSayiGirisi.Text.Length != 5 && txtSayiGirisi.Text != "")
                {
                    MessageBox.Show(string.Format("{0} saat girişi saat formatına uygun değildir.", txtSayiGirisi.Text));
                    return;
                }
            }
            if (tparam != null)
            {
                #region ondalıklı sayı hatası için eklendi
                double sayi = parseNumber_Seperator.ConvertToDouble(txtSayiGirisi.Text.ToString());
                tparam.Text = sayi.ToString();
                #endregion
                //tparam.Text = txtSayiGirisi.Text.Replace(",",".");
            }
            else if (txtParam != null)
            {
                #region ondalıklı sayı hatası için eklendi
                double sayi = parseNumber_Seperator.ConvertToDouble(txtSayiGirisi.Text.ToString());
                tparam.Text = sayi.ToString();
                #endregion
                //txtParam.Text = txtSayiGirisi.Text;
            }
            else if (dtgridParams != null)
            {
                try
                {
                    if (timeField == false)
                    {
                        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                        //double val = Convert.ToDouble(textBox1.Text.Replace(",", "."));
                        double val = double.Parse(txtSayiGirisi.Text, cultureTR);
                        dtgridParams.NotifyCurrentCellDirty(true);

                        GirisOk = "DEG";
                        if (dtgridParams.Name == "dtgKoliGirisi")
                        {

                            dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells[dtgridParams.CurrentCell.ColumnIndex].Value = Convert.ToString(val);
                        }
                        else
                        {
                            dtgridParams.CurrentCell.Value = Convert.ToString(val);
                        }
                    }
                    else if (timeField == true)
                    {
                        //System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");
                        //double val = double.Parse(textBox1.Text, cultureTR);
                        //string saat = val.ToString().PadRight(4, '0');

                        //saat = saat.Insert(2, ":");

                        //dtgridParams.NotifyCurrentCellDirty(true);
                        //dtgridParams.CurrentCell.Value = "";
                        dtgridParams.CurrentCell.Value = Convert.ToString(txtSayiGirisi.Text);
                    }
                }
                catch (Exception)
                {
                }
            }
            Close();
        }

        private void btnTire_Click(object sender, EventArgs e)
        {

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
