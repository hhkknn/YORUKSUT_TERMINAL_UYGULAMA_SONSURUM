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
    public partial class CustomMsgBtn : Form
    {
        //font start.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        public CustomMsgBtn()
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;
            //initialWidth = 1024;
            //initialHeight = 768;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = btnOK.Font.Size;
            btnOK.Resize += Form_Resize;

            initialFontSize = btnCANCEL.Font.Size;
            btnCANCEL.Resize += Form_Resize;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start.
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            btnOK.Font = new Font(btnOK.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnOK.Font.Style);

            btnCANCEL.Font = new Font(btnCANCEL.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnCANCEL.Font.Style);
            ResumeLayout();
            ////font end
        }

        private static CustomMsgBtn MsgBox; public static DialogResult result = DialogResult.No;

        public static DialogResult Show(string Text, string Caption, string btnOK, string btnCancel)
        {
            MsgBox = new CustomMsgBtn();
            MsgBox.label1.Text = Text.ToUpper();
            MsgBox.btnOK.Text = btnOK.ToUpper();
            MsgBox.btnCANCEL.Text = btnCancel.ToUpper();
            MsgBox.Text = Caption;
            MsgBox.ShowDialog();
            MsgBox.Dispose();
            GC.Collect();
            return result;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes; MsgBox.Close();
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            result = DialogResult.No; MsgBox.Close();
        }
    }
}