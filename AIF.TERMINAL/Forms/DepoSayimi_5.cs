using AIF.TERMINAL.AIFTerminalService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class DepoSayimi_5 : form_Base
    {
        //start font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //end font
        public DepoSayimi_5(string _formName, string _tarih)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = dtgDetails.Font.Size;
            dtgDetails.Resize += Form_Resize;

            //end font
            formName = _formName;
            tarih = _tarih;

        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            dtgDetails.Font = new Font(dtgDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgDetails.Font.Style);

            btnGetir.Font = new Font(btnGetir.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnGetir.Font.Style);

            btnIptal.Font = new Font(btnIptal.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnIptal.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            ResumeLayout();
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

        string formName = "";
        string tarih = "";
        DataTable dt = new DataTable();
        private void DepoSayimi_5_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            dtgDetails.RowTemplate.Height = 55;
            dtgDetails.ColumnHeadersHeight = 60;



            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            var resp = aIFTerminalServiceSoapClient.getCountingCustomTable(Giris._dbName, Giris._userCode, Giris.mKodValue);

            if (resp.Val == 0)
            {
                dt = resp._list.Copy();

                dt.Rows.Clear();



                if (tarih != "")
                {
                    DataTable datatable = resp._list;
                    DateTime datetime = new DateTime(Convert.ToInt32(tarih.Substring(0, 4)), Convert.ToInt32(tarih.Substring(4, 2)), Convert.ToInt32(tarih.Substring(6, 2)));
                    DateTime _dtRows = new DateTime();
                    foreach (DataRow item in datatable.Rows)
                    {

                        if (item["Sayım Tarihi"].ToString().Contains("/"))
                        {
                            _dtRows = DateTime.ParseExact(item["Sayım Tarihi"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                        else if (item["Sayım Tarihi"].ToString().Contains("."))
                        {
                            _dtRows = DateTime.ParseExact(item["Sayım Tarihi"].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

                        }

                        //_dtRows = Convert.ToDateTime(item["Sayım Tarihi"]);

                        if (datetime == _dtRows)
                        {
                            try
                            {
                                dt.Rows.Add(item.ItemArray);
                            }
                            catch (Exception ex)
                            {
                                  
                            }
                        }
                    } 
                }
                else
                {
                    dt = resp._list;
                }

                dtgDetails.DataSource = dt;

                dtgDetails.Columns["Belge No"].HeaderText = "BELGE NO";
                dtgDetails.Columns["Sayım Tarihi"].HeaderText = "SAYIM TARİHİ";
                dtgDetails.Columns["Kullanıcı Id"].HeaderText = "KULLANICI ID";
                dtgDetails.Columns["Kullanıcı Adı"].HeaderText = "KULLANICI ADI";
                dtgDetails.Columns["Açıklama"].HeaderText = "AÇIKLAMA";

                //dtgDetails.Columns["Belge No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (dtgDetails.Rows.Count > 0)
                {
                    dtgDetails.Rows[0].Selected = false;
                }
            }
        }

        public static string dialogResult5 = "";
        public static string aciklama = "";

        private void btnGetir_Click(object sender, EventArgs e)
        {
            //DepoSayimi_1.listelemeDt = dt.Copy();

            if (dtgDetails.CurrentCell != null)
            {
                var belgeNo = dtgDetails.Rows[dtgDetails.CurrentCell.RowIndex].Cells["Belge No"].Value.ToString();
                var date = dtgDetails.Rows[dtgDetails.CurrentCell.RowIndex].Cells["Sayım Tarihi"].Value.ToString();
                aciklama = dtgDetails.Rows[dtgDetails.CurrentCell.RowIndex].Cells["Açıklama"].Value.ToString();

                DateTime dt = new DateTime(Convert.ToInt32(date.ToString().Substring(6, 4)), Convert.ToInt32(date.ToString().PadLeft(2, '0').Substring(3, 2)), Convert.ToInt32(date.ToString().PadLeft(2, '0').Substring(0, 2)));

                if (belgeNo != "")
                {
                    DepoSayimi_1.listeleDocEntry = Convert.ToInt32(belgeNo);
                    DepoSayimi_1.listeleTarih = dt;
                }
            }

            #region satır seçili değilse menü ekranına git
            //dialogResult5 = "Ok";

            //if (dtgDetails.CurrentRow.Selected == false)
            //{
            //    Menu menu = new Menu(Giris._userCode, Giris._dbName);
            //    menu.ShowDialog();
            //    Close();
            //}
            #endregion

            Close();
        }

        private void dtgDetails_DoubleClick(object sender, EventArgs e)
        {
            btnGetir.PerformClick();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {

            //Menu menu = new Menu(Giris._userCode, Giris._dbName);
            //menu.ShowDialog();
            Close();

        }
    }
}
