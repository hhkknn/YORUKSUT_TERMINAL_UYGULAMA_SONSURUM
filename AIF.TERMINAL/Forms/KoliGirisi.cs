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
    public partial class KoliGirisi : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public KoliGirisi(string _formName, NumericUpDown _textBoxQty, DataTable _dtKoliGirisi, int _sapSatirNo, int _siparisNumarasi, string _kalemKodu, string _satirkaynagi)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            formName = _formName;
            textboxQty = _textBoxQty;

            //dtKoliGirisi = _dtKoliGirisi;
            sapSatirNo = _sapSatirNo;
            siparisNo = _siparisNumarasi;
            kalemKodu = _kalemKodu;
            satirkaynagi = _satirkaynagi;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            btnKaydet.Font = new Font(btnKaydet.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnKaydet.Font.Style);

            btnIptal.Font = new Font(btnIptal.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnIptal.Font.Style);

            dtgKoliGirisi.Font = new Font(dtgKoliGirisi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgKoliGirisi.Font.Style);
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

        private string formName = "";
        private NumericUpDown textboxQty = new NumericUpDown();

        private DataTable dtKoliGirisi = new DataTable();
        private DataTable dtKoliGirisiTemp = new DataTable();
        private bool formYukleniyor = false;
        private double koliadedi = 0;
        private double koliiciadedi = 0;
        private double toplammiktar = 0;
        private int sapSatirNo = -1;
        private int siparisNo = -1;
        private string satirkaynagi = "";
        private string kalemKodu = "";
        private int currentRow = -1;
        private DataGridViewColumn column = null;

        private void columnsadd(string headerText, string name, string type)
        {
            column = new DataGridViewColumn();

            column.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            column.CellTemplate = new DataGridViewTextBoxCell();
            column.HeaderText = headerText;
            column.Name = name;
            if (type == "int")
            {
                column.ValueType = typeof(int);
            }
            else if (type == "double")
            {
                column.ValueType = typeof(double);
            }
            else if (type == "string")
            {
                column.ValueType = typeof(string);
            }
            dtgKoliGirisi.Columns.Add(column);

            dtgKoliGirisi.RowHeadersVisible = false;
        }

        private void KoliGirisi_Load(object sender, EventArgs e)
        {
            formYukleniyor = true;
            frmName.Text = formName;
            dtgKoliGirisi.EnableHeadersVisualStyles = false;

            dtgKoliGirisi.RowTemplate.Height = 55;
            dtgKoliGirisi.ColumnHeadersHeight = 60;

            vScrollBar1.Maximum = dtgKoliGirisi.RowCount;

            try
            {
                if (dtKoliGirisi.Columns.Count == 0)
                {
                    dtKoliGirisi.Columns.Add("SiparisNumarasi", typeof(int));
                    dtKoliGirisi.Columns.Add("SapSatirNo", typeof(int));
                    dtKoliGirisi.Columns.Add("KoliAdedi", typeof(double));
                    dtKoliGirisi.Columns.Add("KoliIciAdedi", typeof(double));
                    dtKoliGirisi.Columns.Add("ToplamMiktar", typeof(double));
                    dtKoliGirisi.Columns.Add("KalemKodu", typeof(string));
                }

                if (Giris.genelParametreler.CekmeListesiKalemleriniGrupla != "Y")
                {
                    if (CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.Where(x => x.sapSatirNo == sapSatirNo && x.siparisNumarasi == siparisNo).Count() > 0)
                    {
                        DataRow dr2 = null;
                        foreach (var item in CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.Where(x => x.sapSatirNo == sapSatirNo && x.siparisNumarasi == siparisNo))
                        {
                            dr2 = dtKoliGirisi.NewRow();
                            dr2["SiparisNumarasi"] = item.siparisNumarasi;
                            dr2["SapSatirNo"] = item.sapSatirNo;
                            dr2["KoliAdedi"] = item.KoliAdedi;
                            dr2["KoliIciAdedi"] = item.KoliIciAdedi;
                            dr2["ToplamMiktar"] = item.ToplamMiktar;

                            dtKoliGirisi.Rows.Add(dr2);
                        }

                        dr2 = dtKoliGirisi.NewRow();
                        dr2["SiparisNumarasi"] = siparisNo;
                        dr2["SapSatirNo"] = sapSatirNo;
                        dr2["KoliAdedi"] = 0;
                        dr2["KoliIciAdedi"] = 0;
                        dr2["ToplamMiktar"] = 0;

                        dtKoliGirisi.Rows.Add(dr2);
                    }
                    else
                    {
                        DataRow dr2 = dtKoliGirisi.NewRow();
                        dr2["SiparisNumarasi"] = siparisNo;
                        dr2["SapSatirNo"] = sapSatirNo;
                        dr2["KoliAdedi"] = 0;
                        dr2["KoliIciAdedi"] = 0;
                        dr2["ToplamMiktar"] = 0;

                        dtKoliGirisi.Rows.Add(dr2);
                    }
                }
                else
                {
                    if (CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.Where(x => x.KalemKodu == kalemKodu).Count() > 0)
                    {
                        DataRow dr2 = null;
                        foreach (var item in CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.Where(x => x.KalemKodu == kalemKodu))
                        {
                            dr2 = dtKoliGirisi.NewRow();
                            //dr2["SiparisNumarasi"] = item.siparisNumarasi;
                            //dr2["SapSatirNo"] = item.sapSatirNo;
                            dr2["KoliAdedi"] = item.KoliAdedi;
                            dr2["KoliIciAdedi"] = item.KoliIciAdedi;
                            dr2["ToplamMiktar"] = item.ToplamMiktar;
                            dr2["KalemKodu"] = item.KalemKodu;

                            dtKoliGirisi.Rows.Add(dr2);
                        }

                        dr2 = dtKoliGirisi.NewRow();
                        //dr2["SiparisNumarasi"] = siparisNo;
                        //dr2["SapSatirNo"] = sapSatirNo;
                        dr2["KoliAdedi"] = 0;
                        dr2["KoliIciAdedi"] = 0;
                        dr2["ToplamMiktar"] = 0;
                        dr2["KalemKodu"] = kalemKodu;

                        dtKoliGirisi.Rows.Add(dr2);
                    }
                    else
                    {
                        DataRow dr2 = dtKoliGirisi.NewRow();
                        //dr2["SiparisNumarasi"] = siparisNo;
                        //dr2["SapSatirNo"] = sapSatirNo;
                        dr2["KoliAdedi"] = 0;
                        dr2["KoliIciAdedi"] = 0;
                        dr2["ToplamMiktar"] = 0;
                        dr2["KalemKodu"] = kalemKodu;

                        dtKoliGirisi.Rows.Add(dr2);
                    }
                }

                //columnsadd("DtgSatirNo", "DtgSatirNo", "int");
                //columnsadd("KoliAdedi", "KoliAdedi", "double");
                //columnsadd("KoliIciAdedi", "KoliIciAdedi", "double");
                //columnsadd("ToplamMiktar", "ToplamMiktar", "double");

                //dtgKoliGirisi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

                btn = new DataGridViewButtonColumn();
                dtgKoliGirisi.Columns.Add(btn);
                btn.HeaderText = "";
                btn.Text = "Sil";
                btn.Name = "btnSil";
                btn.UseColumnTextForButtonValue = true;
                //btn.
                btn.DefaultCellStyle.BackColor = Color.OrangeRed;
                //btn.DefaultCellStyle.ForeColor= Color.OrangeRed;
                btn.FlatStyle = FlatStyle.Flat;
                //Application.EnableVisualStyles();

                dtgKoliGirisi.DataSource = dtKoliGirisi;

                //if (dtKoliGirisiTemp.Rows.Count == 0)
                //{
                //    Close();
                //    CustomMsgBox.Show("KOLİ BULUNAMADI", "UYARI", "TAMAM", "");
                //    return;

                //}

                //if (dtgKoliGirisi.Rows.Count > 0)
                //{
                dtgKoliGirisi.Columns["KoliAdedi"].HeaderText = "KOLİ ADT";
                dtgKoliGirisi.Columns["KoliIciAdedi"].HeaderText = "KOLİ İÇİ ADT";
                dtgKoliGirisi.Columns["ToplamMiktar"].HeaderText = "TOPLAM MİK";

                dtgKoliGirisi.Columns["KoliAdedi"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgKoliGirisi.Columns["KoliIciAdedi"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgKoliGirisi.Columns["ToplamMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                dtgKoliGirisi.Columns["SapSatirNo"].Visible = false;

                dtgKoliGirisi.Columns["SapSatirNo"].ReadOnly = true;
                dtgKoliGirisi.Columns["SiparisNumarasi"].Visible = false;

                dtgKoliGirisi.Columns["SiparisNumarasi"].ReadOnly = true;
                dtgKoliGirisi.Columns["ToplamMiktar"].ReadOnly = true;

                dtgKoliGirisi.Columns["KoliAdedi"].DefaultCellStyle.BackColor = Color.LightGreen;
                dtgKoliGirisi.Columns["KoliIciAdedi"].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu" + ex.Message);
                return;
            }

            if (dtgKoliGirisi.Rows.Count > 0)
            {
                dtgKoliGirisi.Rows[0].Selected = false;
            }

            foreach (DataGridViewColumn column in dtgKoliGirisi.Columns) //columns tıklayınca girişe atıyor
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //}

            formYukleniyor = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //var sum = CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.Where(x => x.DtgSatirNo == CekmeListesi_2.currentRow).Sum(y => y.ToplamMiktar);

            //var Qty = Convert.ToDouble(dtgKoliGirisi.Rows[dtgKoliGirisi.CurrentCell.RowIndex].Cells["ToplamMiktar"].Value);

            try
            {
                //for (int i = 0; i <= dtgKoliGirisi.Rows.Count - 1; i++)
                //{
                //    dtgKoliGirisi.Rows[i].Cells["DtgSatirNo"].Value = Convert.ToInt32(i);

                //}
                //int i = 0;

                if (Giris.genelParametreler.CekmeListesiKalemleriniGrupla != "Y")
                {
                    CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.RemoveAll(x => x.sapSatirNo == sapSatirNo && x.siparisNumarasi == siparisNo);
                }
                else
                {
                    CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.RemoveAll(x => x.KalemKodu == kalemKodu);
                }
                foreach (DataRow item in dtKoliGirisi.Rows)
                {
                    if (Convert.ToDouble(item["KoliAdedi"]) == 0 && Convert.ToDouble(item["KoliIciAdedi"]) == 0)
                    {
                        continue;
                    }
                    //DataRow dr = dtKoliGirisi.NewRow();
                    //dr["DtgSatirNo"] = Convert.ToInt32(item["DtgSatirNo"]);
                    //dr["ToplamMiktar"] = Convert.ToDouble(item["ToplamMiktar"]);

                    if (Giris.genelParametreler.CekmeListesiKalemleriniGrupla != "Y")
                    {
                        CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.Add(new AIFTerminalService.CekmeListesiOnaylamaKoliDetay
                        {
                            //DtgSatirNo = Convert.ToInt32(item["DtgSatirNo"]),
                            siparisNumarasi = siparisNo,
                            sapSatirNo = sapSatirNo,
                            KoliAdedi = Convert.ToDouble(item["KoliAdedi"]),
                            KoliIciAdedi = Convert.ToDouble(item["KoliIciAdedi"]),
                            ToplamMiktar = Convert.ToDouble(item["ToplamMiktar"]),
                            satirKaynagi = satirkaynagi,
                        });
                    }
                    else
                    {
                        CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.Add(new AIFTerminalService.CekmeListesiOnaylamaKoliDetay
                        {
                            //DtgSatirNo = Convert.ToInt32(item["DtgSatirNo"]),
                            siparisNumarasi = siparisNo,
                            sapSatirNo = sapSatirNo,
                            KoliAdedi = Convert.ToDouble(item["KoliAdedi"]),
                            KoliIciAdedi = Convert.ToDouble(item["KoliIciAdedi"]),
                            ToplamMiktar = Convert.ToDouble(item["ToplamMiktar"]),
                            KalemKodu = item["KalemKodu"].ToString(),
                            satirKaynagi = satirkaynagi,
                        });
                    }
                    //i++;
                }

                if (CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.Count > 0)
                {
                    if (Giris.genelParametreler.CekmeListesiKalemleriniGrupla != "Y")
                    {
                        textboxQty.Text = CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.Where(x => x.sapSatirNo == sapSatirNo && x.siparisNumarasi == siparisNo).Sum(x => x.ToplamMiktar).ToString();
                    }
                    else
                    {
                        textboxQty.Text = CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.Where(x => x.KalemKodu == kalemKodu).Sum(x => x.ToplamMiktar).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu" + ex.Message);
                return;
            }
            Close();
        }

        private void dtgKoliGirisi_CurrentCellChanged(object sender, EventArgs e)
        {
        }

        private void dtgKoliGirisi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgKoliGirisi.Columns[e.ColumnIndex].Name == "KoliAdedi" || dtgKoliGirisi.Columns[e.ColumnIndex].Name == "KoliIciAdedi")
            {
                SayiKlavyesi n = new SayiKlavyesi(null, dtgKoliGirisi, false);
                n.ShowDialog();
                n.Dispose();
                GC.Collect();
            }
            currentRow = e.RowIndex;
        }

        private void dtgKoliGirisi_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtgKoliGirisi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!formYukleniyor)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex].Name == "KoliAdedi" || senderGrid.Columns[e.ColumnIndex].Name == "KoliIciAdedi")
                {
                    try
                    {
                        if (dtgKoliGirisi.Rows[e.RowIndex].Cells["KoliAdedi"].Value.ToString() == "")
                        {
                            dtgKoliGirisi.Rows[e.RowIndex].Cells["KoliAdedi"].Value = 0;
                        }

                        if (dtgKoliGirisi.Rows[e.RowIndex].Cells["KoliIciAdedi"].Value.ToString() == "")
                        {
                            dtgKoliGirisi.Rows[e.RowIndex].Cells["KoliIciAdedi"].Value = 0;
                        }

                        double koliadedi = Convert.ToDouble(dtgKoliGirisi.Rows[e.RowIndex].Cells["KoliAdedi"].Value);
                        double koliiciadedi = Convert.ToDouble(dtgKoliGirisi.Rows[e.RowIndex].Cells["KoliIciAdedi"].Value);

                        toplammiktar = koliadedi * koliiciadedi;

                        dtgKoliGirisi.Rows[e.RowIndex].Cells["ToplamMiktar"].Value = toplammiktar;

                        if (dtgKoliGirisi.Rows[e.RowIndex].Cells["KoliAdedi"].Value != DBNull.Value && dtgKoliGirisi.Rows[e.RowIndex].Cells["KoliAdedi"].Value != null && dtgKoliGirisi.Rows[e.RowIndex].Cells["KoliIciAdedi"].Value != DBNull.Value && dtgKoliGirisi.Rows[e.RowIndex].Cells["KoliIciAdedi"].Value != null)
                        {
                            double newrowKoliAdedi = dtgKoliGirisi.Rows[dtgKoliGirisi.Rows.Count - 1].Cells["KoliAdedi"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgKoliGirisi.Rows[dtgKoliGirisi.Rows.Count - 1].Cells["KoliAdedi"].Value);
                            double newrowkoliiciadedi = dtgKoliGirisi.Rows[dtgKoliGirisi.Rows.Count - 1].Cells["KoliIciAdedi"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgKoliGirisi.Rows[dtgKoliGirisi.Rows.Count - 1].Cells["KoliIciAdedi"].Value);

                            if (Giris.genelParametreler.CekmeListesiKalemleriniGrupla != "Y")
                            {
                                if (newrowKoliAdedi != 0 && newrowkoliiciadedi != 0)
                                {
                                    DataRow dr2 = dtKoliGirisi.NewRow();
                                    dr2["SiparisNumarasi"] = siparisNo;
                                    dr2["SapSatirNo"] = sapSatirNo;
                                    dr2["KoliAdedi"] = 0;
                                    dr2["KoliIciAdedi"] = 0;
                                    dr2["ToplamMiktar"] = 0;

                                    dtKoliGirisi.Rows.Add(dr2);
                                }
                            }
                            else
                            {
                                if (newrowKoliAdedi != 0 && newrowkoliiciadedi != 0)
                                {
                                    DataRow dr2 = dtKoliGirisi.NewRow();
                                    //dr2["SiparisNumarasi"] = siparisNo;
                                    //dr2["SapSatirNo"] = sapSatirNo;
                                    dr2["KoliAdedi"] = 0;
                                    dr2["KoliIciAdedi"] = 0;
                                    dr2["ToplamMiktar"] = 0;
                                    dr2["KalemKodu"] = kalemKodu;

                                    dtKoliGirisi.Rows.Add(dr2);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hesaplama sırasında hata oluştu" + ex.Message);
                    }
                }
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtgKoliGirisi_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //dtgKoliGirisi.Rows[e.RowIndex].Cells["DtgSatirNo"].Value = dtgSatirNo;
        }

        private void dtgKoliGirisi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    //List<dynamic> list = new List<dynamic>();
                    if (senderGrid.Columns[e.ColumnIndex].Name == "btnSil")
                    {
                        CekmeListesi_2.cekmeListesiOnaylamaKoliDetays.RemoveAll(x => x.sapSatirNo == sapSatirNo && x.siparisNumarasi == siparisNo);

                        dtgKoliGirisi.Rows.RemoveAt(currentRow);
                        currentRow = -1;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}