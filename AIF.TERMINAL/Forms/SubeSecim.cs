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
    public partial class SubeSecim : form_Base
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        public SubeSecim(string _formName)
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
        string formName = "";
        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);
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
        private void SubeSecim_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            GetSubeler();
        }
        Button btnSube; 

        DataTable dt = new DataTable();
        public static string subeId = "";
        public static string subeAdi = "";
        private void GetSubeler()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            var respSube = aIFTerminalServiceSoapClient.GetSubeler(Giris._dbName, Giris._userCode, Giris.mKodValue);

            if (respSube != null && respSube._list != null && respSube._list.Rows.Count > 0)
            {
                dt = respSube._list;
                
                for (int i = 0; i <= dt.Rows.Count -1; i++)
                {
                    btnSube = new Button();
                    btnSube.Size = new Size(150,100);
                    btnSube.Font = new Font("Calibri", 12, FontStyle.Bold);
                    btnSube.TabIndex = i;
                    btnSube.Margin = new Padding(5);
                    btnSube.BackColor = Color.LimeGreen;
                    btnSube.FlatStyle = FlatStyle.Flat;
                    btnSube.Text = dt.Rows[i][0].ToString()+ "." + dt.Rows[i][1].ToString();
                    btnSube.Click += BtnSube_Click;
                    flowLayoutSube.Controls.Add(btnSube);
                }
            }
        }

        private void BtnSube_Click(object sender, EventArgs e)
        {
            var sube = (sender as Button).Text.ToString();
            string[] subeid = sube.Split('.');
            subeId = subeid[0].ToString();
            subeAdi = subeid[1].ToString();

            if (subeId != "")
            {
                Forms.Menu menu = new Menu(Giris._userCode, Giris._dbName);
                menu.ShowDialog();
                menu.Dispose();
                GC.Collect();
            }
        }
    }
}
