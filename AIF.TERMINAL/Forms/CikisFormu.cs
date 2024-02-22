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
    public partial class CikisFormu : Form
    {
        public CikisFormu()
        {
            InitializeComponent();
        }

        private void CikisFormu_Load(object sender, EventArgs e)
        {
           
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            try
            {
                if (Giris.genelParametreler.UygulamaYetkiSifresi != "")
                {
                    if (txtSifre.Text == Giris.genelParametreler.UygulamaYetkiSifresi)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        CustomMsgBox.Show("Yanlış şifre girişi yaptınız", "UYARI", "TAMAM", "");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
