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
    public partial class MagazacilikIslemleri : form_Base
    {
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        private string formName = "";
        private object magazaTransferMalKabul;

        public MagazacilikIslemleri(string _formName)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;
            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = btnDepoMalKabul.Font.Size;
            btnDepoMalKabul.Resize += Form_Resize;

            formName = _formName;
        }

        #region resize
        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style); 

            btnDepoMalKabul.Font = new Font(btnDepoMalKabul.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDepoMalKabul.Font.Style);

            btnTransferMalKabul.Font = new Font(btnTransferMalKabul.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTransferMalKabul.Font.Style);

            ResumeLayout(); 
        }
        #endregion
        private void MagazacilikIslemleri_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;

        }

        private void btnDepoMalKabul_Click(object sender, EventArgs e)
        {
            try
            {
                MagazaDepoMalKabul_1 magazaDepoMalKabul = new MagazaDepoMalKabul_1("MAĞAZA DEPO MAL KABUL");
                magazaDepoMalKabul.ShowDialog();
                magazaDepoMalKabul.Dispose();
                GC.Collect();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnTransferMalKabul_Click(object sender, EventArgs e)
        {
            try
            {
                MagazaTransfer_1 magazaTransfer_1 = new MagazaTransfer_1("MAĞAZA TRANSFER");
                magazaTransfer_1.ShowDialog();
                magazaTransfer_1.Dispose();
                GC.Collect();
            }
            catch (Exception)
            {
            }
        }
    }
}
