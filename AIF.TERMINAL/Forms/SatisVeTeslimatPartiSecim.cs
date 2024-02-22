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
    public partial class SatisVeTeslimatPartiSecim : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        private string type = "";

        private string searchType = "";
        private string formName = "";
        private TextBox textBoxParam = null;
        private TextBox textBoxParam2 = null;
        private TextBox textBoxParam3 = null;
        public static string dialogResult = "";

        public SatisVeTeslimatPartiSecim(string _type, string _searchType, string _formName, TextBox _textBoxParam, TextBox _textBoxParam2, TextBox _textBoxParam3)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            type = _type;
            searchType = _searchType;
            formName = _formName;
            textBoxParam = _textBoxParam;
            textBoxParam2 = _textBoxParam2;
            textBoxParam3 = _textBoxParam3;
        }

        private DataTable dtParamsOrjinalValues = new DataTable();
        private DataTable dtParams = new DataTable();

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            txtSearch.Font = new Font(txtSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSearch.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtItemCode.Font = new Font(txtItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemCode.Font.Style);

            dtgResult.Font = new Font(dtgResult.Font.FontFamily, initialFontSize *
            (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            dtgResult.Font.Style);

            btnSelect.Font = new Font(btnSelect.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSelect.Font.Style);

            btnTumPartiler.Font = new Font(btnTumPartiler.Font.FontFamily, initialFontSize *
             (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
             btnTumPartiler.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtSearch.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private void SatisVeTeslimatPartiSecim_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            txtSearch.Focus();
            txtItemCode.Text = textBoxParam2.Text;
            txtItemName.Text = textBoxParam3.Text;

            dtgResult.RowTemplate.Height = 55;
            dtgResult.ColumnHeadersHeight = 60;

            dtParams = null;
            dtParamsOrjinalValues = null;
            dtgResult.DataSource = null;

            btnTumPartiler.Text = "TÜM PARTİLERİ GETİR";
            PartiGetir();
            vScrollBar1.Maximum = dtgResult.RowCount;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgResult.CurrentCell != null)
                {
                    if (dtgResult.CurrentCell.RowIndex != -1)
                    {
                        dialogResult = "Ok";
                        if (searchType == "PartiAra")
                        {
                            //string whsCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["WhsCode"].Value.ToString();
                            //string whsName = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["WhsName"].Value.ToString();
                            string batchnum = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["BatchNum"].Value.ToString();

                            //textBoxParam.Text = batchnum;
                            //textBoxParam2.Text = whsName;

                            Close();
                            if (type == "16")
                            {
                                IadeIrsaliyeGirisi_2.arananPartyNo = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["BatchNum"].Value.ToString();
                                IadeIrsaliyeGirisi_2.secilenDepoYeriId = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["BatchNum"].Value.ToString();
                                IadeIrsaliyeGirisi_2.secilenDepoYeriAdi = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["BatchNum"].Value.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA." + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private string KarakterDegistir(string text)
        {
            string val = text;

            val = val.Replace("i", "I");
            val = val.Replace("İ", "I");
            val = val.Replace("ç", "C");
            val = val.Replace("Ç", "C");
            val = val.Replace("ş", "S");
            val = val.Replace("Ş", "S");
            val = val.Replace("Ü", "U");
            val = val.Replace("ü", "U");
            val = val.Replace("Ö", "O");
            val = val.Replace("ö", "O");
            val = val.Replace("Ğ", "G");
            val = val.Replace("ğ", "G");

            return val;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (searchType == "PartiAra")
                {
                    var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("BatchNum").Contains(txtSearch.Text.ToUpper())).ToList();

                    int parsedValue;
                    if (int.TryParse(txtSearch.Text, out parsedValue))
                    {
                        var resp2 = dtParams.AsEnumerable().Where(x => x.Field<int>("ID") == Convert.ToInt32(txtSearch.Text)).ToList();

                        if (resp2.Count > 0)
                        {
                            foreach (var item in resp2)
                            {
                                var belgenovarmi = resp.Where(x => x.Field<int>("ID") == item.Field<int>("ID")).ToList();

                                if (belgenovarmi.Count == 0)
                                {
                                    resp.AddRange(resp2);
                                }
                            }
                        }
                    }

                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();

                        dtgResult.DataSource = dts;

                        dtgResult.RowTemplate.Height = 55;
                        dtgResult.ColumnHeadersHeight = 60;

                        dtgResult.Columns["BatchNum"].HeaderText = "PARTİ NO";
                        dtgResult.Columns["Quantity"].HeaderText = "MİKTAR";

                        dtgResult.Columns["ID"].Visible = false;

                        //dtgResult.Columns["WhsCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        //dtgResult.Columns["WhsName"].Width = dtgResult.Width - dtgResult.Columns["WhsCode"].Width;

                        foreach (DataRow row in dtParams.Rows)
                        {
                            //string whsCode = row["WhsCode"].ToString();
                            //string whsName = row["WhsName"].ToString();
                            string partyName = row["BatchNum"].ToString();

                            //whsCode = KarakterDegistir(whsCode);

                            //whsName = KarakterDegistir(whsName);

                            partyName = KarakterDegistir(partyName);

                            //row.SetField("WhsCode", whsCode);
                            //row.SetField("WhsName", whsName);
                            row.SetField("BatchNum", partyName);
                        }
                    }
                    else
                    {
                        dtParams = new DataTable();
                        dtParamsOrjinalValues = new DataTable();
                        dtgResult.DataSource = null;
                    }
                    vScrollBar1.Maximum = dtgResult.RowCount;

                    //dtgPurchaseOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //dtgPurchaseOrders.AutoResizeRows();

                    foreach (DataGridViewColumn column in dtgResult.Columns) //columns tıklayınca girişe atma
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    if (dtgResult.Rows.Count > 0)
                    {
                        dtgResult.Rows[0].Selected = false;
                    }
                }

                #region eski arama

                //if (searchType == "PartiAra")
                //{
                //    string kelime = txtSearch.Text;

                //    DataTable dtParamsFinal = new DataTable();
                //    dtParamsFinal = dtParams.Copy();
                //    dtParamsFinal.Rows.Clear();

                //    foreach (DataRow item in dtParams.Rows)
                //    {
                //        //item["BatchNum"] = item["BatchNum"].ToString().ToUpper();

                //        DataRow dr = dtParamsFinal.NewRow();
                //        dr["ID"] = item["ID"];
                //        dr["BatchNum"] = item["BatchNum"].ToString().ToUpper();

                //        dtParamsFinal.Rows.Add(dr);
                //    }

                //    //dtParams.AsEnumerable().ToList().ForEach(x => x.Field<string>("BatchNum") = x.Field<string>("BatchNum").ToString().ToUpper());

                //    kelime = KarakterDegistir(kelime);

                //    var resp = dtParamsFinal.AsEnumerable().Where(x => x.Field<string>("BatchNum").Contains(kelime.ToUpper())).ToList();

                //    if (resp.Count > 0)
                //    {
                //        DataTable dts = resp.CopyToDataTable();
                //        DataTable dtsOrjinalValues = dts.Copy();
                //        dtsOrjinalValues.Rows.Clear();

                //        foreach (DataRow item in dts.Rows)
                //        {
                //            int ID = Convert.ToInt32(item["ID"]);

                //            var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<dynamic>("ID") == ID).ToList();

                //            if (dt.Count > 0)
                //            {
                //                DataRow dr = dtsOrjinalValues.NewRow();
                //                dr["ID"] = dt[0][0].ToString();
                //                dr["BatchNum"] = dt[0][1].ToString();

                //                dtsOrjinalValues.Rows.Add(dr);

                //            }

                //        }
                //        dtgResult.DataSource = dtsOrjinalValues;
                //        dtgResult.RowTemplate.Height = 55;
                //        dtgResult.ColumnHeadersHeight = 60;

                //        dtgResult.Columns["BatchNum"].HeaderText = "PARTİ NO";
                //        dtgResult.Columns["ID"].Visible = false;

                //    }
                //    else
                //    {
                //        dtgResult.DataSource = null;
                //    }
                //}

                #endregion eski arama

                //vScrollBar1.Maximum = dtgResult.RowCount;

                //foreach (DataGridViewColumn column in dtgResult.Columns) //columns tıklayınca girişe atma
                //{
                //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                //}

                //if (dtgResult.Rows.Count > 0)
                //{
                //    dtgResult.Rows[0].Selected = false;
                //}
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA." + ex.Message, "Uyarı", "Tamam", "");
                dtParams = new DataTable();
                dtParamsOrjinalValues = new DataTable();
                dtgResult.DataSource = null;
            }
        }

        private void dtgResult_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgResult.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void dtgResult_DoubleClick(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }

        private void btnTumPartiler_Click(object sender, EventArgs e)
        {
            //TumPartileriGetir();

            if (btnTumPartiler.Text == "TÜM PARTİLERİ GETİR")
            {
                //btnTumPartiler.BackColor = Color.Gold;
                TumPartileriGetir();
                btnTumPartiler.Text = "BELGE PARTİLERİNİ GETİR";
            }
            else
            {
                //btnTumPartiler.BackColor = Color.Green;
                PartiGetir();
                btnTumPartiler.Text = "TÜM PARTİLERİ GETİR";
            }
        }

        private void PartiGetir()
        {
            try
            {
                if (searchType == "PartiAra")
                {
                    dtParams = null;
                    dtParamsOrjinalValues = null;
                    dtgResult.DataSource = null;

                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                    var resp = aIFTerminalServiceSoapClient.GetBatchNumberByCardCodeAndItemCode(Giris._dbName, textBoxParam.Text, textBoxParam2.Text, Giris.mKodValue);

                    if (resp.Val == 0)
                    {
                        var ilkSatir = resp._list.Rows[0][0].ToString();

                        if (ilkSatir == "" || ilkSatir == null)
                        {
                            resp._list.Rows.RemoveAt(0);
                        }

                        dtgResult.DataSource = resp._list;

                        dtParams = resp._list.Copy();
                        dtParamsOrjinalValues = resp._list.Copy();

                        //dtgResult.Columns["WhsCode"].HeaderText = "DEPO KODU";
                        //dtgResult.Columns["WhsName"].HeaderText = "DEPO ADI";
                        dtgResult.Columns["BatchNum"].HeaderText = "PARTİ NO";
                        dtgResult.Columns["Quantity"].HeaderText = "MİKTAR";
                        if (Giris.mKodValue == "20TRMN")
                        {
                            dtgResult.Columns["MnfSerial"].HeaderText = "PARTİ NİTELİĞİ";
                        }

                        dtgResult.Columns["ID"].Visible = false;

                        //dtgResult.Columns["WhsCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        //dtgResult.Columns["WhsName"].Width = dtgResult.Width - dtgResult.Columns["WhsCode"].Width;

                        foreach (DataRow row in dtParams.Rows)
                        {
                            //string whsCode = row["WhsCode"].ToString();
                            //string whsName = row["WhsName"].ToString();
                            string partyName = row["BatchNum"].ToString();

                            //whsCode = KarakterDegistir(whsCode);

                            //whsName = KarakterDegistir(whsName);

                            partyName = KarakterDegistir(partyName);

                            //row.SetField("WhsCode", whsCode);
                            //row.SetField("WhsName", whsName);
                            row.SetField("BatchNum", partyName);
                        }
                    }
                    else
                    {
                        CustomMsgBox.Show("PARTİ NUMARASI BULUNAMADI.", "Uyarı", "Tamam", "");
                        dtParams = new DataTable();
                        dtParamsOrjinalValues = new DataTable();
                        dtgResult.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA." + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void TumPartileriGetir()
        {
            try
            {
                if (searchType == "PartiAra")
                {
                    dtParams = null;
                    dtParamsOrjinalValues = null;
                    dtgResult.DataSource = null;
                    txtSearch.Text = "";

                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                    var resp = aIFTerminalServiceSoapClient.GetBatchNumberByCardCodeAndItemCode(Giris._dbName, "", textBoxParam2.Text, Giris.mKodValue);

                    if (resp.Val == 0)
                    {
                        var ilkSatir = resp._list.Rows[0][0].ToString();

                        if (ilkSatir == "" || ilkSatir == null)
                        {
                            resp._list.Rows.RemoveAt(0);
                        }

                        dtgResult.DataSource = resp._list;

                        dtParams = resp._list.Copy();
                        dtParamsOrjinalValues = resp._list.Copy();

                        //dtgResult.Columns["WhsCode"].HeaderText = "DEPO KODU";
                        //dtgResult.Columns["WhsName"].HeaderText = "DEPO ADI";
                        dtgResult.Columns["BatchNum"].HeaderText = "PARTİ NO";
                        dtgResult.Columns["Quantity"].HeaderText = "MİKTAR";
                        if (Giris.mKodValue == "20TRMN")
                        {
                            dtgResult.Columns["MnfSerial"].HeaderText = "PARTİ NİTELİĞİ";
                        }
                        dtgResult.Columns["ID"].Visible = false;

                        //dtgResult.Columns["WhsCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        //dtgResult.Columns["WhsName"].Width = dtgResult.Width - dtgResult.Columns["WhsCode"].Width;

                        foreach (DataRow row in dtParams.Rows)
                        {
                            //string whsCode = row["WhsCode"].ToString();
                            //string whsName = row["WhsName"].ToString();
                            string partyName = row["BatchNum"].ToString();

                            //whsCode = KarakterDegistir(whsCode);

                            //whsName = KarakterDegistir(whsName);

                            partyName = KarakterDegistir(partyName);

                            //row.SetField("WhsCode", whsCode);
                            //row.SetField("WhsName", whsName);
                            row.SetField("BatchNum", partyName);
                        }
                    }
                    else
                    {
                        CustomMsgBox.Show("PARTİ NUMARASI BULUNAMADI.", "Uyarı", "Tamam", "");
                        dtParams = new DataTable();
                        dtParamsOrjinalValues = new DataTable();
                        dtgResult.DataSource = null;
                    }
                }
                vScrollBar1.Maximum = dtgResult.RowCount;
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA." + ex.Message, "Uyarı", "Tamam", "");
            }
        }
    }
}