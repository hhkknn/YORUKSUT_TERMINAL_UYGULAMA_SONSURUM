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
    public partial class DepoSayimi_2 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public DepoSayimi_2(bool _tekilKalem, string _kalemKodu, string _depoKodu, string _formName, DataGridView _dtgSayimListesi)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            //end font
            //formName = _formName;
            //inventoryTransferLists = _inventoryTransferLists;
            tekilKalem = _tekilKalem;
            kalemKodu = _kalemKodu;
            depoKodu = _depoKodu;
            formName = _formName;

            dtgSayimListesi = _dtgSayimListesi;
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

            txtArama.Font = new Font(txtArama.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtArama.Font.Style);

            dtgDetails.Font = new Font(dtgDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgDetails.Font.Style);

            btnDeleteRow.Font = new Font(btnDeleteRow.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDeleteRow.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            btnClose.Font = new Font(btnClose.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnClose.Font.Style);

            lblSayMik.Font = new Font(lblSayMik.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblSayMik.Font.Style);

            txtSayilanMiktar.Font = new Font(txtSayilanMiktar.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSayilanMiktar.Font.Style);

            lblSayilanKalem.Font = new Font(lblSayilanKalem.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblSayilanKalem.Font.Style);

            txtSayilanKalemMiktar.Font = new Font(txtSayilanKalemMiktar.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSayilanKalemMiktar.Font.Style);

            txtArama.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
        }

        private bool tekilKalem = false;
        private string depoKodu = "";
        private string kalemKodu = "";
        private DataGridView dtgSayimListesi = new DataGridView();

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

        private DataTable dtDetay = new DataTable();
        private DataTable dtDetayOrjinal = new DataTable();
        private string formName = "";

        private void DepoSayimi_2_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            dtgDetails.RowTemplate.Height = 55;
            dtgDetails.ColumnHeadersHeight = 65;

            dtDetay.Columns.Add("Barkod", typeof(string));
            dtDetay.Columns.Add("Ürün Kodu", typeof(string));
            dtDetay.Columns.Add("Ürün Adı", typeof(string));
            dtDetay.Columns.Add("Depo Kodu", typeof(string));
            dtDetay.Columns.Add("Depo Adı", typeof(string));
            dtDetay.Columns.Add("Miktar", typeof(double));
            dtDetay.Columns.Add("Partili", typeof(string));
            dtDetay.Columns.Add("ÜrünAdiArama", typeof(string));

            dtgDetails.DataSource = dtDetay;

            dtgDetails.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

            if (Giris.mKodValue == "30TRMN")
            {
                dtgDetails.Columns["Barkod"].Visible = false;
            }
            else if (Giris.mKodValue == "10TRMN" || Giris.mKodValue == "20TRMN")
            {
                dtgDetails.Columns["Ürün Kodu"].Visible = false;
            }

            dtgDetails.Columns["Depo Kodu"].Visible = false;

            dtgDetails.Columns["Barkod"].HeaderText = "BARKOD";
            dtgDetails.Columns["Ürün Kodu"].HeaderText = "ÜRÜN KODU";
            dtgDetails.Columns["Ürün Adı"].HeaderText = "ÜRÜN ADI";
            dtgDetails.Columns["Depo Kodu"].HeaderText = "DEPO KODU";
            dtgDetails.Columns["Depo Adı"].HeaderText = "DEPO ADI";
            dtgDetails.Columns["Miktar"].HeaderText = "MİKTAR";
            dtgDetails.Columns["Partili"].HeaderText = "PARTİLİ";
            dtgDetails.Columns["Partili"].Visible = false;
            dtgDetails.Columns["ÜrünAdiArama"].Visible = false;

            if (!tekilKalem)
            {
                //foreach (var item in DepoSayimi_1.depoSayimiDetaylars)
                //{
                //    DataRow dr = dtDetay.NewRow();

                //    if (Giris.mKodValue == "30TRMN")
                //    {
                //        dr["Ürün Kodu"] = item.UrunKodu;
                //    }
                //    else if (Giris.mKodValue == "10TRMN")
                //    {
                //        dr["Barkod"] = item.Barkod;

                //    }

                //    dr["Ürün Adı"] = item.UrunAdi;
                //    dr["Depo Kodu"] = item.DepoKodu;
                //    dr["Depo Adı"] = item.DepoAdi;
                //    dr["Miktar"] = Convert.ToDouble(item.Miktar);
                //    dr["Partili"] = item.Partili;

                //    dtDetay.Rows.Add(dr);
                //}

                foreach (DataGridViewRow item in dtgSayimListesi.Rows)
                {
                    DataRow dr = dtDetay.NewRow();

                    if (Giris.mKodValue == "30TRMN")
                    {
                        dr["Ürün Kodu"] = item.Cells["Ürün Kodu"].Value.ToString();
                    }
                    else if (Giris.mKodValue == "10TRMN" || Giris.mKodValue == "20TRMN")
                    {
                        dr["Barkod"] = item.Cells["Barkod"].Value.ToString();
                    }
                    else if (Giris.mKodValue == "70TRMN")
                    {
                        dr["Ürün Kodu"] = item.Cells["Ürün Kodu"].Value.ToString();
                        dr["Barkod"] = item.Cells["Barkod"].Value.ToString();
                    }

                    dr["Ürün Adı"] = item.Cells["Ürün Adı"].Value.ToString();
                    dr["ÜrünAdiArama"] = item.Cells["Ürün Adı"].Value.ToString();
                    dr["Depo Kodu"] = item.Cells["Depo Kodu"].Value.ToString();
                    dr["Depo Adı"] = item.Cells["Depo Adı"].Value.ToString();

                    dr["Miktar"] = Convert.ToDouble(item.Cells["Miktar"].Value);
                    dr["Partili"] = item.Cells["Partili"].Value.ToString();

                    dtDetay.Rows.Add(dr);
                }
            }
            else
            {
                //foreach (var item in DepoSayimi_1.depoSayimiDetaylars.Where(x => x.UrunKodu == kalemKodu && x.DepoKodu == depoKodu))
                //{
                //    DataRow dr = dtDetay.NewRow();
                //    if (Giris.mKodValue == "30TRMN")
                //    {
                //        dr["Ürün Kodu"] = item.UrunKodu;
                //    }
                //    else if (Giris.mKodValue == "10TRMN")
                //    {
                //        dr["Barkod"] = item.Barkod;

                //    }
                //    dr["Ürün Adı"] = item.UrunAdi;
                //    dr["Depo Kodu"] = item.DepoKodu;
                //    dr["Depo Adı"] = item.DepoAdi;
                //    dr["Miktar"] = Convert.ToDouble(item.Miktar);
                //    dr["Partili"] = item.Partili;

                //    dtDetay.Rows.Add(dr);
                //}
                foreach (DataGridViewRow item in dtgSayimListesi.Rows)
                {
                    if (item.Cells["Ürün Kodu"].Value.ToString() != kalemKodu)
                    {
                        continue;
                    }
                    else if (item.Cells["Depo Kodu"].Value.ToString() != depoKodu)
                    {
                        continue;
                    }

                    DataRow dr = dtDetay.NewRow();

                    if (Giris.mKodValue == "30TRMN")
                    {
                        dr["Ürün Kodu"] = item.Cells["Ürün Kodu"].Value.ToString();
                    }
                    else if (Giris.mKodValue == "10TRMN" || Giris.mKodValue == "20TRMN")
                    {
                        dr["Barkod"] = item.Cells["Barkod"].Value.ToString();
                    }

                    dr["Ürün Adı"] = item.Cells["Ürün Adı"].Value.ToString();
                    dr["ÜrünAdiArama"] = item.Cells["Ürün Adı"].Value.ToString();
                    dr["Depo Kodu"] = item.Cells["Depo Kodu"].Value.ToString();
                    dr["Depo Adı"] = item.Cells["Depo Adı"].Value.ToString();

                    dr["Miktar"] = Convert.ToDouble(item.Cells["Miktar"].Value);
                    dr["Partili"] = item.Cells["Partili"].Value.ToString();

                    dtDetay.Rows.Add(dr);
                }
            }
            dtgDetails.DataSource = dtDetay;
            dtDetayOrjinal = dtDetay.Copy();

            foreach (DataRow row in dtDetay.Rows)
            {
                string whsName = row["Depo Adı"].ToString();
                string itemName = row["ÜrünAdiArama"].ToString();

                whsName = KarakterDegistir(whsName);
                itemName = KarakterDegistir(itemName);

                row.SetField("ÜrünAdiArama", itemName.ToUpper());
                row.SetField("Depo Adı", whsName.ToUpper());
            }
            //txtSayilanKalemMiktar.Text = dtDetay.AsEnumerable().Where(x => x.Field<string>("Depo Adı").Contains(kelime.ToUpper()) || x.Field<string>("Ürün Adı").Contains(kelime.ToUpper()) || x.Field<string>("Barkod").Contains(kelime.ToUpper())).ToList();

            #region old ters yazılmış dendi değiştirildi. 20220911

            //txtSayilanKalemMiktar.Text = dtDetay.AsEnumerable().Sum(x => x.Field<double>("Miktar")).ToString();
            //txtSayilanMiktar.Text = dtDetay.Rows.Count.ToString();

            #endregion old ters yazılmış dendi değiştirildi. 20220911

            txtSayilanKalemMiktar.Text = dtDetay.Rows.Count.ToString();
            txtSayilanMiktar.Text = dtDetay.AsEnumerable().Sum(x => x.Field<double>("Miktar")).ToString();

            vScrollBar1.Maximum = dtgDetails.RowCount + 5;
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

        private void txtArama_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    string kelime = txtArama.Text;

            //    kelime = KarakterDegistir(kelime);

            //    var resp = dtDetay.AsEnumerable().Where(x => x.Field<string>("Depo Adı").Contains(kelime.ToUpper()) || x.Field<string>("Ürün Adı").Contains(kelime.ToUpper()) || x.Field<string>("Barkod").Contains(kelime.ToUpper())).ToList();

            //    if (resp.Count > 0)
            //    {
            //        DataTable dts = resp.CopyToDataTable();
            //        DataTable dtsOrjinalValues = dts.Copy();
            //        dtsOrjinalValues.Rows.Clear();

            //        foreach (DataRow item in dts.Rows)
            //        {
            //            string tempItemCode = item["Ürün Kodu"].ToString();

            //            var dt = dtDetayOrjinal.AsEnumerable().Where(x => x.Field<string>("Ürün Kodu") == tempItemCode).ToList();

            //            if (dt.Count > 0)
            //            {
            //                DataRow dr = dtsOrjinalValues.NewRow();
            //                dr["Barkod"] = dt[0][0].ToString();
            //                dr["Ürün Kodu"] = dt[0][1].ToString();
            //                dr["Ürün Adı"] = dt[0][2].ToString();
            //                dr["Depo Kodu"] = dt[0][3].ToString();
            //                dr["Depo Adı"] = dt[0][4].ToString();
            //                dr["Miktar"] = Convert.ToDouble(dt[0][5]);
            //                dr["Partili"] = dt[0][6].ToString();

            //                dtsOrjinalValues.Rows.Add(dr);

            //            }

            //        }

            //        foreach (DataRow row in dtsOrjinalValues.Rows)
            //        {
            //            string whsName = row["Depo Adı"].ToString();
            //            string itemName = row["Ürün Adı"].ToString();

            //            whsName = KarakterDegistir(whsName);
            //            itemName = KarakterDegistir(itemName);

            //            row.SetField("Ürün Adı", itemName.ToUpper());
            //            row.SetField("Depo Adı", whsName.ToUpper());

            //        }

            //        dtgDetails.DataSource = dtsOrjinalValues;

            //        //dtgResult.Columns["WhsCode"].HeaderText = "DEPO KODU";
            //        //dtgResult.Columns["WhsName"].HeaderText = "DEPO ADI";

            //        dtgDetails.Columns["Partili"].Visible = false;
            //        dtgDetails.Columns["Depo Kodu"].Visible = false;

            //    }
            //    else
            //    {
            //        dtgDetails.DataSource = null;
            //    }
            //    vScrollBar1.Maximum = dtgDetails.RowCount;

            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                var index = dtgDetails.CurrentCell.RowIndex;

                if (index > -1)
                {
                    DialogResult dialog = new DialogResult();
                    dialog = CustomMsgBtn.Show("SATIR SİLİNECEKTİR DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                    if (dialog == DialogResult.No)
                    {
                        return;
                    }

                    dtgDetails.Rows.RemoveAt(index);
                    dtgSayimListesi.Rows.RemoveAt(index);

                    //var kalemKodu = dtgDetails.Rows[index].Cells["Ürün Kodu"].Value;
                    //var depoKodu = dtgDetails.Rows[index].Cells["Depo Kodu"].Value;
                    //for (int i = dtDetay.Rows.Count - 1; i >= 0; i--)
                    //{
                    //    DataRow dr = dtDetay.Rows[i];
                    //    if (dr["Ürün Kodu"].ToString() == kalemKodu.ToString() && dr["Depo Kodu"].ToString() == depoKodu.ToString())
                    //    {
                    //        dr.Delete();
                    //        dtDetay.AcceptChanges();
                    //        i = -1;
                    //    }
                    //}

                    ////kalemKodu = dtgDetails.Rows[index].Cells["Ürün Kodu"].Value;
                    ////depoKodu = dtgDetails.Rows[index].Cells["Depo Kodu"].Value;
                    //for (int i = DepoSayimi_1.dtDetay.Rows.Count - 1; i >= 0; i--)
                    //{
                    //    DataRow dr = DepoSayimi_1.dtDetay.Rows[i];
                    //    if (dr["Ürün Kodu"].ToString() == kalemKodu.ToString() && dr["Depo Kodu"].ToString() == depoKodu.ToString())
                    //    {
                    //        dr.Delete();
                    //        DepoSayimi_1.dtDetay.AcceptChanges();
                    //        DepoSayimi_1.depoSayimiDetaylars.RemoveAll(x => x.UrunKodu == kalemKodu.ToString() && x.DepoKodu == depoKodu.ToString());
                    //        DepoSayimi_1.depoSayimiPartilers.RemoveAll(x => x.UrunKodu == kalemKodu.ToString() && x.DepoKodu == depoKodu.ToString());
                    //        return;
                    //    }
                    //}
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtgDetails_DoubleClick(object sender, EventArgs e)
        {
            return;
            DepoSayimi_3 depoSayimi_3 = new DepoSayimi_3("FORM");
            depoSayimi_3.ShowDialog();
            depoSayimi_3.Dispose();
            GC.Collect();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgDetails.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        public static int currentRow;

        private void dtgDetails_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                vScrollBar1.Value = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void dtgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentRow = e.RowIndex;
            }
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kelime = txtArama.Text;

                kelime = KarakterDegistir(kelime);

                var resp = dtDetay.AsEnumerable().Where(x => x.Field<string>("Depo Adı").Contains(kelime.ToUpper()) || x.Field<string>("ÜrünAdiArama").Contains(kelime.ToUpper()) || x.Field<string>("Barkod").Contains(kelime.ToUpper())).ToList();

                if (resp.Count > 0)
                {
                    DataTable dts = resp.CopyToDataTable();
                    DataTable dtsOrjinalValues = dts.Copy();
                    dtsOrjinalValues.Rows.Clear();

                    foreach (DataRow item in dts.Rows)
                    {
                        string tempItemCode = item["Ürün Kodu"].ToString();

                        var dt = dtDetayOrjinal.AsEnumerable().Where(x => x.Field<string>("Ürün Kodu") == tempItemCode).ToList();

                        if (dt.Count > 0)
                        {
                            DataRow dr = dtsOrjinalValues.NewRow();
                            dr["Barkod"] = dt[0][0].ToString();
                            dr["Ürün Kodu"] = dt[0][1].ToString();
                            dr["Ürün Adı"] = dt[0][2].ToString();
                            dr["Depo Kodu"] = dt[0][3].ToString();
                            dr["Depo Adı"] = dt[0][4].ToString();
                            dr["Miktar"] = Convert.ToDouble(dt[0][5]);
                            dr["Partili"] = dt[0][6].ToString();
                            dr["ÜrünAdiArama"] = dt[0][2].ToString();

                            dtsOrjinalValues.Rows.Add(dr);
                        }
                    }

                    foreach (DataRow row in dtsOrjinalValues.Rows)
                    {
                        string whsName = row["Depo Adı"].ToString();
                        string itemName = row["ÜrünAdiArama"].ToString();

                        whsName = KarakterDegistir(whsName);
                        itemName = KarakterDegistir(itemName);

                        row.SetField("ÜrünAdiArama", itemName.ToUpper());
                        row.SetField("Depo Adı", whsName.ToUpper());
                    }

                    dtgDetails.DataSource = dtsOrjinalValues;

                    //dtgResult.Columns["WhsCode"].HeaderText = "DEPO KODU";
                    //dtgResult.Columns["WhsName"].HeaderText = "DEPO ADI";

                    dtgDetails.Columns["Partili"].Visible = false;
                    dtgDetails.Columns["Depo Kodu"].Visible = false;
                }
                else
                {
                    dtgDetails.DataSource = null;
                }
                vScrollBar1.Maximum = dtgDetails.RowCount;
            }
            catch (Exception ex)
            {
            }
        }
    }
}