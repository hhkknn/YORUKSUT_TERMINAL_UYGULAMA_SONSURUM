using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class SipariseBagliTeslimat_Detay : Form
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public SipariseBagliTeslimat_Detay(string _formName)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize; //tam ekran olmadıgından form resize yapılamıyor
            //end font
            formName = _formName;

            //start yükseklik-genislik
            txtCarPlate.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
            numCarTemp.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
            txtDriverName.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
            cmbType.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik

            txtDriverName.Text = SipariseBagliTeslimat_2.deliveryDetails.DriverName;
            txtCarPlate.Text = SipariseBagliTeslimat_2.deliveryDetails.CarPlate;
            numCarTemp.Text = SipariseBagliTeslimat_2.deliveryDetails.CarTemp.ToString();
            cmbType.Text = SipariseBagliTeslimat_2.deliveryDetails.PostType;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label3.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label4.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtDriverName.Font = new Font(txtDriverName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtDriverName.Font.Style);

            txtCarPlate.Font = new Font(txtCarPlate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCarPlate.Font.Style);

            numCarTemp.Font = new Font(numCarTemp.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                numCarTemp.Font.Style);

            cmbType.Font = new Font(cmbType.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbType.Font.Style);

            btnOk.Font = new Font(btnOk.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnOk.Font.Style);

            btnClose.Font = new Font(btnClose.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnClose.Font.Style);

            label5.Font = new Font(label5.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label5.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtCarPlate.Font = new Font("Microsoft Sans Serif", 38, FontStyle.Bold);
            numCarTemp.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
            txtDriverName.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
            cmbType.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
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

        private class select
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }

        private string shipmentType = "";

        private void SipariseBagliTeslimat_Detay_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            txtCarPlate.Focus();

            numCarTemp.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            //List<select> sl = new List<select>();
            ////sl.Add(new select() { Text = "", Value = "" });
            //sl.Add(new select() { Text = "Komple Sevk", Value = "1" });
            //sl.Add(new select() { Text = "Parsiyel Sevk", Value = "2" });
            //cmbType.DataSource = sl;
            //cmbType.DisplayMember = "Text";

            //cmbType.Items.Add(new { Text = "", Value = "" });
            //cmbType.Items.Add(new { Text = "Parsiyel Sevk", Value = "2" });
            //cmbType.DisplayMember = "Text";
            //cmbType.ValueMember = "Value";
            GetShipmentTypes();
        }

        private void GetShipmentTypes()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response response = aIFTerminalServiceSoapClient.getShipmentTypes(Giris._dbName, Giris.mKodValue);
            if (response._list.Rows.Count > 0)
            {
                //DataTable dtCopy = new DataTable();
                //foreach (DataRow dr in response._list.Rows)
                //{
                //    dtCopy.Rows.Add(dr.ItemArray);
                //}

                DataTable dtabc = response._list.Copy();

                DataRow dr = dtabc.NewRow();
                dr["TrnspCode"] = -999;
                dr["TrnspName"] = "";

                dtabc.Rows.Add(dr);

                dtabc.DefaultView.Sort = "TrnspCode";
                dtabc = dtabc.DefaultView.ToTable(true);

                cmbType.DataSource = dtabc;
                cmbType.DisplayMember = "TrnspName";
                cmbType.ValueMember = "TrnspCode";
                cmbType.Enabled = true;

                shipmentType = cmbType.SelectedValue.ToString();

                //cmbType.Items.Add(new { Text = "", Value = "" });
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtCarPlate.Text == "")
            {
                CustomMsgBox.Show("LÜTFEN PLAKA GİRİNİZ.", "UYARI", "TAMAM", "");
                txtCarPlate.Focus();
                return;
            }
            if (txtDriverName.Text == "")
            {
                CustomMsgBox.Show("LÜTFEN SÜRÜCÜ ADI GİRİNİZ.", "UYARI", "TAMAM", "");
                txtDriverName.Focus();
                return;
            }

            if (numCarTemp.Text == "")
            {
                CustomMsgBox.Show("LÜTFEN SICAKLIK GİRİNİZ.", "UYARI", "TAMAM", "");
                numCarTemp.Focus();
                return;
            }
            if (cmbType.Text == "")
            {
                CustomMsgBox.Show("LÜTFEN GÖNDERİ TİPİ GİRİNİZ.", "UYARI", "TAMAM", "");
                cmbType.Focus();
                return;
            }
            SipariseBagliTeslimat_2.deliveryDetails.DriverName = txtDriverName.Text;
            SipariseBagliTeslimat_2.deliveryDetails.CarPlate = txtCarPlate.Text;
            SipariseBagliTeslimat_2.deliveryDetails.CarTemp = Convert.ToDouble(numCarTemp.Value);
            SipariseBagliTeslimat_2.deliveryDetails.PostType = cmbType.SelectedValue.ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select sl1 = cmbType.SelectedItem as select;

            SipariseBagliTeslimat_2.deliveryDetails.PostType = Convert.ToString(shipmentType);
            //t1.Text = Convert.ToString(sl1.Value);
        }

        private void numCarTemp_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(numCarTemp, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }
    }
}