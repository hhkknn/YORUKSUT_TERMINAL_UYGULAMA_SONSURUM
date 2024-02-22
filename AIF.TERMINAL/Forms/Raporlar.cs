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
    public partial class Raporlar : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public Raporlar(string _formName)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            //end font

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

            btnProduct.Font = new Font(btnProduct.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnProduct.Font.Style);

            btnWareHouse.Font = new Font(btnWareHouse.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnWareHouse.Font.Style);

            btnParty.Font = new Font(btnParty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnParty.Font.Style);

            btnPartiHareketRaporu.Font = new Font(btnPartiHareketRaporu.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPartiHareketRaporu.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            btnProduct.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Bold);
            btnParty.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Bold);
            btnWareHouse.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Bold);
            btnPartiHareketRaporu.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Bold);
            //end yükseklik-genislik
            ////font end
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

        private void Raporlar_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                UrunSorgulama urunSorgulama = new UrunSorgulama("ÜRÜN SORGULAMA");
                urunSorgulama.ShowDialog();
                urunSorgulama.Dispose();
                GC.Collect();
            }
            catch (Exception)
            {
            }
        }

        private void btnParty_Click(object sender, EventArgs e)
        {
            PartiSorgulama partiSorgulama = new PartiSorgulama("PARTİ SORGULAMA");
            partiSorgulama.ShowDialog();
            partiSorgulama.Dispose();
            GC.Collect();
        }

        private void btnWareHouse_Click(object sender, EventArgs e)
        {
            DepoSorgulama depoSorgulama = new DepoSorgulama("DEPO SORGULAMA");
            depoSorgulama.ShowDialog();
            depoSorgulama.Dispose();
            GC.Collect();
        }

        private void btnPartiHareketRaporu_Click(object sender, EventArgs e)
        {
            PartiHareketRaporu partiHareketRaporu = new PartiHareketRaporu("PARTİ HAREKET RAPORU");
            partiHareketRaporu.ShowDialog();
            partiHareketRaporu.Dispose();
            GC.Collect();
        }
    }
}