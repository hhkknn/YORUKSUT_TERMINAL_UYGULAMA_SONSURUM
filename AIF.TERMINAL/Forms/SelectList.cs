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
    public partial class SelectList : form_Base
    {
        //start font.
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //end font
        string type = "";
        string searchType = "";
        string formName = "";
        TextBox textBoxParam = null;
        TextBox textBoxParam2 = null;
        TextBox textBoxParam3 = null;
        public static string dialogResult = "";
        public SelectList(string _type, string _searchType, string _formName, TextBox _textBoxParam, TextBox _textBoxParam2, TextBox _textBoxParam3 = null, Response _respParam = null)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = lblSearch.Font.Size;
            lblSearch.Resize += Form_Resize;

            //initialFontSize = txtSearch.Font.Size;
            //txtSearch.Resize += Form_Resize;

            initialFontSize = btnSelect.Font.Size;
            btnSelect.Resize += Form_Resize;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            initialFontSize = dtgResult.Font.Size;
            dtgResult.Resize += Form_Resize;
            //end font

            type = _type;
            searchType = _searchType;
            formName = _formName;
            textBoxParam = _textBoxParam;
            textBoxParam2 = _textBoxParam2;
            textBoxParam3 = _textBoxParam3;
            respParam = _respParam;

        }
        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            lblSearch.Font = new Font(lblSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblSearch.Font.Style);

            txtSearch.Font = new Font(txtSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSearch.Font.Style);

            btnSelect.Font = new Font(btnSelect.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSelect.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            dtgResult.Font = new Font(dtgResult.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgResult.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtSearch.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dtgResult.CurrentCell != null)
            {
                if (dtgResult.CurrentCell.RowIndex != -1)
                {
                    dialogResult = "Ok";
                    if (searchType == "TedarikciAra")
                    {
                        string cardCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["CardCode"].Value.ToString();
                        string cardName = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["CardName"].Value.ToString();


                        textBoxParam.Text = cardCode;
                        textBoxParam2.Text = cardName;

                        Close();
                    }
                    else if (searchType == "KalemAra")
                    {
                        string BarCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["CodeBars"].Value.ToString();
                        string ItemName = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemName"].Value.ToString();


                        textBoxParam.Text = BarCode;
                        textBoxParam2.Text = ItemName;

                        if (textBoxParam3 != null)
                        {
                            textBoxParam3.Text = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();
                        }

                        Close();

                        if (type == "20")
                        {
                            SiparissizMalGirisi_1.arananItemCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();
                        }
                        else if (type == "Sprssz17")
                        {
                            SiparissizTesilmat_1.arananItemCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();

                        }
                        else if (type == "Tlpsz1250000001")
                        {
                            TalepsizDepoNakli_1.arananItemCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();

                        }
                        else if (type == "60")
                        {
                            BelgesizMalCikisi_1.arananItemCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();

                        }
                        else if (type == "59")
                        {
                            BelgesizMalGirisi_1.arananItemCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();

                        }
                        else if (type == "UrunSorgula")
                        {
                            UrunSorgulama.ItemCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();

                        }
                        else if (type == "UrunSorgulaBarkod")
                        {
                            BarkodOlusturma.arananItemCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();

                        }
                        else if (type == "16")
                        {
                            IadeIrsaliyeGirisi_1.arananItemCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();

                        }
                        else if (type == "PartiHareketRaporu")
                        {
                            PartiHareketRaporu.ItemCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();

                        }
                    }
                    else if (searchType == "MusteriAra")
                    {
                        string cardCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["CardCode"].Value.ToString();
                        string cardName = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["CardName"].Value.ToString();


                        textBoxParam.Text = cardCode;
                        textBoxParam2.Text = cardName;

                        Close();
                    }
                    else if (searchType == "MuhatapAra")
                    {
                        string cardCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["CardCode"].Value.ToString();
                        string cardName = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["CardName"].Value.ToString();


                        textBoxParam.Text = cardCode;
                        textBoxParam2.Text = cardName;

                        Close();
                    }
                    else if (searchType == "DepoAra")
                    {
                        string whsCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["WhsCode"].Value.ToString();
                        string whsName = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["WhsName"].Value.ToString();


                        textBoxParam.Text = whsCode;
                        textBoxParam2.Text = whsName;

                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            textBoxParam3.Text = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["DepoYeriZorunlu"].Value.ToString();
                        }

                        Close();
                    }
                    else if (searchType == "DepoYerleri")
                    {
                        string absEntry = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["AbsEntry"].Value.ToString();
                        string binCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["BinCode"].Value.ToString();


                        textBoxParam.Text = absEntry;
                        textBoxParam2.Text = binCode;

                        Close();
                    }
                    else if (searchType == "PaletNoArama")
                    {
                        string paletNo = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["PaletNo"].Value.ToString();


                        textBoxParam.Text = paletNo;

                        Close();
                    }
                    else if (searchType == "KatalogArama")
                    {
                        string cardCode = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["MUHATAP KODU"].Value.ToString();
                        DepoSayimi_1.SelectListcardCode = cardCode;
                        Close();
                    }
                    else if (searchType == "CekmeListesiMusteriGetirme")
                    {
                        string musteriKodu = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["MusteriKodu"].Value.ToString();
                        string musteriAdi = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["MusteriAdi"].Value.ToString();


                        textBoxParam.Text = musteriAdi;
                        textBoxParam2.Text = musteriKodu;

                        Close();
                    }
                    else if (searchType == "CekmeListesiMusteriUrunuSecme")
                    {
                        string urunKodu = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["UrunKodu"].Value.ToString();
                        string urunAdi = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["UrunTanimi"].Value.ToString();
                        string siparisNumarasi = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["SiparisNumarasi"].Value.ToString();
                        string siparisSatirNo = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["SiparisSatirNo"].Value.ToString();
                        string aciklama = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["Aciklama"].Value.ToString();
                        int cekmeListesiNo = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["CekmeListesiNo"].Value.ToString() == "" ? -1 : Convert.ToInt32(dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["CekmeListesiNo"].Value);
                        int girilebilecekMaxMiktar = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["Miktar"].Value.ToString() == "" ? -1 : Convert.ToInt32(dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["Miktar"].Value);
                        string satirKaynagi = dtgResult.Rows[dtgResult.CurrentCell.RowIndex].Cells["Kaynak"].Value.ToString();

                        KonteynerYapma_3.secilenUrunKodu = urunKodu;
                        KonteynerYapma_3.secilenUrunTanimi = urunAdi;
                        KonteynerYapma_3.secilenSiparisNumarasi = siparisNumarasi;
                        KonteynerYapma_3.secilenSiparisSatirNo = siparisSatirNo;
                        KonteynerYapma_3.secilenAciklama = aciklama;
                        KonteynerYapma_3.secilenCekiListesiNo = cekmeListesiNo;
                        KonteynerYapma_3.girilebilecekMaxMiktar = girilebilecekMaxMiktar;
                        KonteynerYapma_3.secilensatirKaynagi = satirKaynagi;

                        Close();
                    }
                }
            }
        }
        DataTable dtParamsOrjinalValues = new DataTable();
        DataTable dtParams = new DataTable();
        Response respParam = new Response();
        private void SelectList_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            txtSearch.Focus();

            dtgResult.RowTemplate.Height = 55;
            dtgResult.ColumnHeadersHeight = 60;

            if (searchType == "KalemAra")
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = null;


                resp = aIFTerminalServiceSoapClient.GetAllProducts(Giris._dbName, Giris.mKodValue);

                if (resp.Val == 0)
                {
                    foreach (DataRow item in resp._list.Rows)
                    {
                        item["ItemName"] = item["ItemName"].ToString().Replace(item["ItemCode"].ToString() + "-", "");
                    }
                    var ilkSatir = resp._list.Rows[0][0].ToString();

                    if (ilkSatir == "" || ilkSatir == null)
                    {
                        resp._list.Rows.RemoveAt(0);
                    }
                    dtgResult.DataSource = resp._list;

                    dtParams = resp._list.Copy();
                    dtParamsOrjinalValues = resp._list.Copy();

                    dtgResult.Columns["ItemCode"].HeaderText = "KALEM KODU";
                    dtgResult.Columns["ItemName"].HeaderText = "KALEM ADI";
                    dtgResult.Columns["Codebars"].HeaderText = "BARKOD";

                    dtgResult.Columns["Codebars"].Visible = false;

                    dtgResult.Columns["ItemCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dtgResult.Columns["CodeBars"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dtgResult.Columns["ItemName"].Width = dtgResult.Width - dtgResult.Columns["ItemCode"].Width;

                    foreach (DataRow row in dtParams.Rows)
                    {
                        string itemCode = row["ItemCode"].ToString();
                        string itemName = row["ItemName"].ToString();
                        itemName = itemName.Replace(itemCode + "-", "");
                        string codeBars = row["CodeBars"].ToString();

                        itemCode = KarakterDegistir(itemCode);
                        itemName = KarakterDegistir(itemName);
                        codeBars = KarakterDegistir(codeBars);

                        row.SetField("ItemCode", itemCode);
                        row.SetField("ItemName", itemName);
                        row.SetField("CodeBars", codeBars);
                    }
                }

            }
            else if (searchType == "TedarikciAra")
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = null;


                resp = aIFTerminalServiceSoapClient.GetBusinessVendorPartner(Giris._dbName, Giris.mKodValue);

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

                    dtgResult.Columns["CardCode"].HeaderText = "TEDARİKÇİ KODU";
                    dtgResult.Columns["CardName"].HeaderText = "TEDARİKÇİ ADI";

                    dtgResult.Columns["CardCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dtgResult.Columns["CardName"].Width = dtgResult.Width - dtgResult.Columns["CardCode"].Width;

                    foreach (DataRow row in dtParams.Rows)
                    {
                        string cardCode = row["CardCode"].ToString();
                        string cardName = row["CardName"].ToString();

                        cardCode = KarakterDegistir(cardCode);

                        cardName = KarakterDegistir(cardName);

                        row.SetField("CardCode", cardCode);
                        row.SetField("CardName", cardName);

                    }
                }
            }
            else if (searchType == "MusteriAra")
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = null;


                resp = aIFTerminalServiceSoapClient.GetBusinessCustomerPartner(Giris._dbName, Giris.mKodValue);

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

                    dtgResult.Columns["CardCode"].HeaderText = "MÜŞTERİ KODU";
                    dtgResult.Columns["CardName"].HeaderText = "MÜŞTERİ ADI";

                    dtgResult.Columns["CardCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dtgResult.Columns["CardName"].Width = dtgResult.Width - dtgResult.Columns["CardCode"].Width;

                    foreach (DataRow row in dtParams.Rows)
                    {
                        string cardCode = row["CardCode"].ToString();
                        string cardName = row["CardName"].ToString();

                        cardCode = KarakterDegistir(cardCode);

                        cardName = KarakterDegistir(cardName);

                        row.SetField("CardCode", cardCode);
                        row.SetField("CardName", cardName);

                    }
                }
            }
            else if (searchType == "MuhatapAra")
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = null;


                resp = aIFTerminalServiceSoapClient.GetBusinessCustomerPartner(Giris._dbName, Giris.mKodValue);

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

                    dtgResult.Columns["CardCode"].HeaderText = "MUHATAP KODU";
                    dtgResult.Columns["CardName"].HeaderText = "MUHATAP ADI";

                    dtgResult.Columns["CardCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dtgResult.Columns["CardName"].Width = dtgResult.Width - dtgResult.Columns["CardCode"].Width;

                    foreach (DataRow row in dtParams.Rows)
                    {
                        string cardCode = row["CardCode"].ToString();
                        string cardName = row["CardName"].ToString();

                        cardCode = KarakterDegistir(cardCode);

                        cardName = KarakterDegistir(cardName);

                        row.SetField("CardCode", cardCode);
                        row.SetField("CardName", cardName);

                    }
                }
            }
            else if (searchType == "DepoAra")
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = null; 

                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode,"", Giris.mKodValue); //Burası da depo parametresine bağlanabilir.

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

                    dtgResult.Columns["WhsCode"].HeaderText = "DEPO KODU";
                    dtgResult.Columns["WhsName"].HeaderText = "DEPO ADI";

                    dtgResult.Columns["WhsCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dtgResult.Columns["WhsName"].Width = dtgResult.Width - dtgResult.Columns["WhsCode"].Width;

                    foreach (DataRow row in dtParams.Rows)
                    {
                        string whsCode = row["WhsCode"].ToString();
                        string whsName = row["WhsName"].ToString();

                        whsCode = KarakterDegistir(whsCode);

                        whsName = KarakterDegistir(whsName);

                        row.SetField("WhsCode", whsCode);
                        row.SetField("WhsName", whsName);

                    }
                }

                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    dtgResult.Columns["DepoYeriZorunlu"].Visible = false;
                }
            }
            else if (searchType == "DepoYerleri")
            {
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                Response resp = null;

                resp = aIFTerminalServiceSoapClient.getDepoYerleri(Giris._dbName, textBoxParam3.Text, Giris.mKodValue);

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

                    dtgResult.Columns["AbsEntry"].HeaderText = "TANITICI ID";
                    dtgResult.Columns["BinCode"].HeaderText = "DEPO YERİ";

                    dtgResult.Columns["AbsEntry"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dtgResult.Columns["BinCode"].Width = dtgResult.Width - dtgResult.Columns["AbsEntry"].Width;

                    foreach (DataRow row in dtParams.Rows)
                    {
                        string absEntry = row["AbsEntry"].ToString();
                        string bincode = row["BinCode"].ToString();

                        absEntry = KarakterDegistir(absEntry);

                        bincode = KarakterDegistir(bincode);

                        row.SetField("AbsEntry", absEntry);
                        row.SetField("BinCode", bincode);

                    }
                }
            }
            else if (searchType == "PaletNoArama")
            {
                try
                {
                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                    Response resp = null;

                    resp = aIFTerminalServiceSoapClient.getPaletYapmaListesi(Giris._dbName, "N", Giris.mKodValue);


                    if (resp.Val == 0)
                    {
                        for (int i = 0; i <= CekmeListesi_2.dahaonceGirilmisPaletler.Rows.Count - 1; i++)
                        {
                            if (resp._list.AsEnumerable().Where(x => x.Field<string>("PaletNo") == CekmeListesi_2.dahaonceGirilmisPaletler.Rows[i][0].ToString()).Count() == 0)
                            {
                                DataRow drw = resp._list.NewRow();
                                drw["PaletNo"] = CekmeListesi_2.dahaonceGirilmisPaletler.Rows[i][0].ToString();
                                resp._list.Rows.Add(drw);
                            }
                        }

                        dtgResult.DataSource = resp._list;


                        dtParams = resp._list.Copy();
                        dtParamsOrjinalValues = resp._list.Copy();

                        dtgResult.Columns["PaletNo"].HeaderText = "PALET NO";


                        foreach (DataRow row in dtParams.Rows)
                        {
                            string paletNo = row["PaletNo"].ToString();

                            paletNo = KarakterDegistir(paletNo);

                            row.SetField("PaletNo", paletNo);

                        }

                    }
                }
                catch (Exception ex)
                {

                }


            }
            else if (searchType == "KatalogArama")
            {
                if (respParam.Val == 0)
                {

                    var ilkSatir = respParam._list.Rows[0][0].ToString();

                    if (ilkSatir == "" || ilkSatir == null)
                    {
                        respParam._list.Rows.RemoveAt(0);
                    }

                    dtgResult.DataSource = respParam._list;

                    dtParams = respParam._list.Copy();
                    dtParamsOrjinalValues = respParam._list.Copy();

                    dtgResult.Columns["MUHATAP KODU"].Visible = false;


                    //dtgResult.Columns["MUHATAP ADI"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dtgResult.Columns["ÜRÜN KODU"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dtgResult.Columns["ÜRÜN ADI"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dtgResult.Columns["KATALOG NO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    //foreach (DataRow row in dtParams.Rows)
                    //{
                    //    string paletNo = row["PaletNo"].ToString();

                    //    paletNo = KarakterDegistir(paletNo);

                    //    row.SetField("PaletNo", paletNo);

                    //}
                }
            }
            else if (searchType == "CekmeListesiMusteriGetirme")
            {
                try
                {
                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    Response resp = aIFTerminalServiceSoapClient.getCekmeListesiMusterileri(Giris._dbName, Giris.mKodValue);

                    if (resp.Val == 0)
                    {

                        dtgResult.DataSource = resp._list;

                        dtParams = resp._list.Copy();
                        dtParamsOrjinalValues = resp._list.Copy();

                        dtgResult.Columns["MusteriKodu"].HeaderText = "MUHATAP KODU";
                        dtgResult.Columns["MusteriAdi"].HeaderText = "MUHATAP ADI";

                        dtgResult.Columns["MusteriKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        dtgResult.Columns["MusteriAdi"].Width = dtgResult.Width - dtgResult.Columns["MusteriAdi"].Width;

                        foreach (DataRow row in dtParams.Rows)
                        {
                            string cardCode = row["MusteriKodu"].ToString();
                            string cardName = row["MusteriAdi"].ToString();

                            cardCode = KarakterDegistir(cardCode);

                            cardName = KarakterDegistir(cardName);

                            row.SetField("MusteriKodu", cardCode);
                            row.SetField("MusteriAdi", cardName);

                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else if (searchType == "CekmeListesiMusteriUrunuSecme")
            {
                try
                {
                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    Response resp = aIFTerminalServiceSoapClient.getCekmeListesiMusteriyeGoreUrunListesi(Giris._dbName, textBoxParam.Text, Giris.mKodValue,KonteynerYapma_3.MusteriKod);

                    if (resp.Val == 0)
                    {

                        var paletolmayaneklenmisler = KonteynerYapma_3.dtGirilenler.AsEnumerable().Where(x => x.Field<string>("Palet No") == "" && x.Field<int>("CekmeListesiNo") > 0 && x.Field<string>("UrunKonteynereDahaOnceEklendi") != "Y").ToList();

                        //foreach (var item in paletolmayaneklenmisler)
                        //{
                        //    var siparisNo = item.Field<int>("SiparisNumarasi");
                        //    var siparisSatirNo = item.Field<int>("SiparisSatirNo");
                        //    var miktar = item.Field<decimal>("Miktar");


                        //    var kayitliMiktar = resp._list.AsEnumerable().Where(x => x.Field<int>("SiparisNo") == siparisNo && x.Field<int>("SiparisSatirNo") == siparisSatirNo).Sum(y => y.Field<decimal>("Miktar"));


                        //    var final = kayitliMiktar - miktar;

                        //    resp._list.AsEnumerable().Where(x => x.Field<int>("SiparisNo") == siparisNo && x.Field<int>("SiparisSatirNo") == siparisSatirNo).ToList().ForEach(y => y.Field<decimal>("Miktar") = 10);



                        //}

                        //if (paletolmayaneklenmisler.Count > 0)
                        //{
                        //    foreach (DataRow dr in resp._list.Rows)
                        //    {
                        //        if (paletolmayaneklenmisler.Where(x => x.Field<int>("SiparisNumarasi") == Convert.ToInt32(dr["SiparisNumarasi"]) && x.Field<int>("SiparisSatirNo") == Convert.ToInt32(dr["SiparisSatirNo"]) && x.Field<string>("Palet No") == "").Count() > 0)
                        //        {
                        //            dr["Miktar"] = Convert.ToDecimal(dr["Miktar"]) - (paletolmayaneklenmisler.Where(x => x.Field<int>("SiparisNumarasi") == Convert.ToInt32(dr["SiparisNumarasi"]) && x.Field<int>("SiparisSatirNo") == Convert.ToInt32(dr["SiparisSatirNo"]) && x.Field<string>("Palet No") == "").Sum(y => y.Field<decimal>("Miktar")));
                        //        }
                        //    }
                        //}


                        //foreach (DataRow item in resp._list.Rows)
                        //{
                        //    if (Convert.ToDecimal(item["Miktar"]) == 0)
                        //    {
                        //        item.Delete();

                        //    }
                        //}

                        //resp._list.AcceptChanges();


                        dtgResult.DataSource = resp._list;

                        dtParams = resp._list.Copy();
                        dtParamsOrjinalValues = resp._list.Copy();

                        dtgResult.Columns["UrunKodu"].HeaderText = "ÜRÜN KODU";
                        dtgResult.Columns["UrunTanimi"].HeaderText = "ÜRÜN ADI";
                        dtgResult.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
                        dtgResult.Columns["CekmeListesiNo"].HeaderText = "ÇEK.LİSTE NO";

                        dtgResult.Columns["UrunTanimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        dtgResult.Columns["UrunTanimi"].Width = dtgResult.Width - dtgResult.Columns["UrunTanimi"].Width;

                        foreach (DataRow row in dtParams.Rows)
                        {
                            string urunKodu = row["UrunKodu"].ToString();
                            string urunAdi = row["UrunTanimi"].ToString();

                            urunKodu = KarakterDegistir(urunKodu);

                            urunAdi = KarakterDegistir(urunAdi);

                            row.SetField("UrunKodu", urunKodu);
                            row.SetField("UrunTanimi", urunAdi);

                        }

                        dtgResult.Columns["SiparisNumarasi"].Visible = false;
                        dtgResult.Columns["SiparisSatirNo"].Visible = false;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            vScrollBar1.Maximum = dtgResult.RowCount;

            dtgResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dtgResult.RowCount > 0)
            {
                dtgResult.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (searchType == "KalemAra")
            {
                string kelime = txtSearch.Text;

                kelime = KarakterDegistir(kelime);

                var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("ItemName").Contains(kelime.ToUpper()) || x.Field<string>("ItemCode").Contains(kelime.ToUpper()) || x.Field<string>("CodeBars").Contains(kelime.ToUpper())).ToList();

                if (Giris.genelParametreler.TurkceArama == "Y")
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        DataTable dtsOrjinalValues = dts.Copy();
                        dtsOrjinalValues.Rows.Clear();

                        foreach (DataRow item in dts.Rows)
                        {
                            string tempItemCode = item["ItemCode"].ToString();

                            var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<string>("ItemCode") == tempItemCode).ToList();

                            if (dt.Count > 0)
                            {

                                DataRow dr = dtsOrjinalValues.NewRow();
                                dr["ItemCode"] = dt[0][0].ToString();
                                dr["ItemName"] = dt[0][1].ToString();
                                dr["CodeBars"] = dt[0][2].ToString();

                                dtsOrjinalValues.Rows.Add(dr);

                            }


                        }
                        dtgResult.DataSource = dtsOrjinalValues;
                        dtgResult.Columns["ItemCode"].HeaderText = "KALEM KODU";
                        dtgResult.Columns["ItemName"].HeaderText = "KALEM ADI";
                        dtgResult.Columns["CodeBars"].HeaderText = "BARKOD";

                        dtgResult.Columns["Codebars"].Visible = false;

                        dtgResult.Columns["ItemCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
                else
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        dtgResult.DataSource = dts;

                        dtgResult.Columns["Codebars"].Visible = false;

                        dtgResult.Columns["ItemCode"].HeaderText = "KALEM KODU";
                        dtgResult.Columns["ItemName"].HeaderText = "KALEM ADI";
                        dtgResult.Columns["CodeBars"].HeaderText = "BARKOD";

                        dtgResult.Columns["ItemCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }

            }
            else if (searchType == "TedarikciAra")
            {
                string kelime = txtSearch.Text;

                kelime = KarakterDegistir(kelime);

                var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("CardName").Contains(kelime.ToUpper()) || x.Field<string>("CardCode").Contains(kelime.ToUpper())).ToList();

                if (Giris.genelParametreler.TurkceArama == "Y")
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        DataTable dtsOrjinalValues = dts.Copy();
                        dtsOrjinalValues.Rows.Clear();

                        foreach (DataRow item in dts.Rows)
                        {
                            string tempCardCode = item["CardCode"].ToString();

                            var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<string>("CardCode") == tempCardCode).ToList();

                            if (dt.Count > 0)
                            {

                                DataRow dr = dtsOrjinalValues.NewRow();
                                dr["CardCode"] = dt[0][0].ToString();
                                dr["CardName"] = dt[0][1].ToString();

                                dtsOrjinalValues.Rows.Add(dr);

                            }


                        }
                        dtgResult.DataSource = dtsOrjinalValues;
                        dtgResult.Columns["CardCode"].HeaderText = "TEDARİKÇİ KODU";
                        dtgResult.Columns["CardName"].HeaderText = "TEDARİKÇİ ADI";

                        dtgResult.Columns["CardCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
                else
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        dtgResult.DataSource = dts;

                        dtgResult.Columns["CardCode"].HeaderText = "TEDARİKÇİ KODU";
                        dtgResult.Columns["CardName"].HeaderText = "TEDARİKÇİ ADI";

                        dtgResult.Columns["CardCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
            }
            else if (searchType == "MusteriAra")
            {
                string kelime = txtSearch.Text;

                kelime = KarakterDegistir(kelime);

                var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("CardName").Contains(kelime.ToUpper()) || x.Field<string>("CardCode").Contains(kelime.ToUpper())).ToList();


                if (Giris.genelParametreler.TurkceArama == "Y")
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        DataTable dtsOrjinalValues = dts.Copy();
                        dtsOrjinalValues.Rows.Clear();

                        foreach (DataRow item in dts.Rows)
                        {
                            string tempCardCode = item["CardCode"].ToString();

                            var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<string>("CardCode") == tempCardCode).ToList();

                            if (dt.Count > 0)
                            {

                                DataRow dr = dtsOrjinalValues.NewRow();
                                dr["CardCode"] = dt[0][0].ToString();
                                dr["CardName"] = dt[0][1].ToString();

                                dtsOrjinalValues.Rows.Add(dr);

                            }


                        }
                        dtgResult.DataSource = dtsOrjinalValues;
                        dtgResult.Columns["CardCode"].HeaderText = "MÜŞTERİ KODU";
                        dtgResult.Columns["CardName"].HeaderText = "MÜŞTERİ ADI";
                        dtgResult.Columns["CardCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
                else
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        dtgResult.DataSource = dts;

                        dtgResult.Columns["CardCode"].HeaderText = "MÜŞTERİ KODU";
                        dtgResult.Columns["CardName"].HeaderText = "MÜŞTERİ ADI";
                        dtgResult.Columns["CardCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
            }
            else if (searchType == "MuhatapAra")
            {
                string kelime = txtSearch.Text;

                kelime = KarakterDegistir(kelime);

                var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("CardName").Contains(kelime.ToUpper()) || x.Field<string>("CardCode").Contains(kelime.ToUpper())).ToList();

                if (Giris.genelParametreler.TurkceArama == "Y")
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        DataTable dtsOrjinalValues = dts.Copy();
                        dtsOrjinalValues.Rows.Clear();

                        foreach (DataRow item in dts.Rows)
                        {
                            string tempCardCode = item["CardCode"].ToString();

                            var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<string>("CardCode") == tempCardCode).ToList();

                            if (dt.Count > 0)
                            {

                                DataRow dr = dtsOrjinalValues.NewRow();
                                dr["CardCode"] = dt[0][0].ToString();
                                dr["CardName"] = dt[0][1].ToString();

                                dtsOrjinalValues.Rows.Add(dr);

                            }


                        }
                        dtgResult.DataSource = dtsOrjinalValues;
                        dtgResult.Columns["CardCode"].HeaderText = "MUHATAP KODU";
                        dtgResult.Columns["CardName"].HeaderText = "MUHATAP ADI";
                        dtgResult.Columns["CardCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
                else
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        dtgResult.DataSource = dts;

                        dtgResult.Columns["CardCode"].HeaderText = "MUHATAP KODU";
                        dtgResult.Columns["CardName"].HeaderText = "MUHATAP ADI";
                        dtgResult.Columns["CardCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
            }
            else if (searchType == "DepoAra")
            {
                string kelime = txtSearch.Text;

                kelime = KarakterDegistir(kelime);

                var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("WhsName").Contains(kelime.ToUpper()) || x.Field<string>("WhsCode").Contains(kelime.ToUpper())).ToList();

                if (Giris.genelParametreler.TurkceArama == "Y")
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        DataTable dtsOrjinalValues = dts.Copy();
                        dtsOrjinalValues.Rows.Clear();

                        foreach (DataRow item in dts.Rows)
                        {
                            string tempWhsCode = item["WhsCode"].ToString();

                            var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<string>("WhsCode") == tempWhsCode).ToList();

                            if (dt.Count > 0)
                            {

                                DataRow dr = dtsOrjinalValues.NewRow();
                                dr["WhsCode"] = dt[0][0].ToString();
                                dr["WhsName"] = dt[0][1].ToString();

                                dtsOrjinalValues.Rows.Add(dr);

                            }


                        }
                        dtgResult.DataSource = dtsOrjinalValues;
                        dtgResult.Columns["WhsCode"].HeaderText = "DEPO KODU";
                        dtgResult.Columns["WhsName"].HeaderText = "DEPO ADI";
                        dtgResult.Columns["DepoYeriZorunlu"].Visible = false;
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
                else
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        dtgResult.DataSource = dts;

                        dtgResult.Columns["WhsCode"].HeaderText = "DEPO KODU";
                        dtgResult.Columns["WhsName"].HeaderText = "DEPO ADI";

                        dtgResult.Columns["DepoYeriZorunlu"].Visible = false;

                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
            }
            else if (searchType == "DepoYerleri")
            {
                string kelime = txtSearch.Text;

                kelime = KarakterDegistir(kelime);

                var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("BinCode").Contains(kelime.ToUpper()) || x.Field<string>("AbsEntry").Contains(kelime.ToUpper())).ToList();

                if (Giris.genelParametreler.TurkceArama == "Y")
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        DataTable dtsOrjinalValues = dts.Copy();
                        dtsOrjinalValues.Rows.Clear();

                        foreach (DataRow item in dts.Rows)
                        {
                            string tempAbsEntry = item["AbsEntry"].ToString();

                            var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<string>("AbsEntry") == tempAbsEntry).ToList();

                            if (dt.Count > 0)
                            {

                                DataRow dr = dtsOrjinalValues.NewRow();
                                dr["AbsEntry"] = dt[0][0].ToString();
                                dr["BinCode"] = dt[0][1].ToString();

                                dtsOrjinalValues.Rows.Add(dr);

                            }


                        }
                        dtgResult.DataSource = dtsOrjinalValues;
                        dtgResult.Columns["AbsEntry"].HeaderText = "TANITICI ID";
                        dtgResult.Columns["BinCode"].HeaderText = "DEPO YERİ";
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
                else
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        dtgResult.DataSource = dts;

                        dtgResult.Columns["AbsEntry"].HeaderText = "TANITICI ID";
                        dtgResult.Columns["BinCode"].HeaderText = "DEPO YERİ";
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
            }
            else if (searchType == "PaletNoArama")
            {
                string kelime = txtSearch.Text;

                kelime = KarakterDegistir(kelime);

                var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("PaletNo").Contains(kelime.ToUpper())).ToList();

                if (Giris.genelParametreler.TurkceArama == "Y")
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        DataTable dtsOrjinalValues = dts.Copy();
                        dtsOrjinalValues.Rows.Clear();

                        foreach (DataRow item in dts.Rows)
                        {
                            string tempAbsEntry = item["PaletNo"].ToString();

                            var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<string>("PaletNo") == tempAbsEntry).ToList();

                            if (dt.Count > 0)
                            {

                                DataRow dr = dtsOrjinalValues.NewRow();
                                dr["PaletNo"] = dt[0][0].ToString();

                                dtsOrjinalValues.Rows.Add(dr);

                            }


                        }
                        dtgResult.DataSource = dtsOrjinalValues;
                        dtgResult.Columns["PaletNo"].HeaderText = "PALET NO";
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
                else
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        dtgResult.DataSource = dts;
                        dtgResult.Columns["PaletNo"].HeaderText = "PALET NO";
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
            }
            else if (searchType == "CekmeListesiMusteriGetirme")
            {

                string kelime = txtSearch.Text;

                kelime = KarakterDegistir(kelime);

                var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("MusteriAdi").Contains(kelime.ToUpper()) || x.Field<string>("MusteriKodu").Contains(kelime.ToUpper())).ToList();

                if (Giris.genelParametreler.TurkceArama == "Y")
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        DataTable dtsOrjinalValues = dts.Copy();
                        dtsOrjinalValues.Rows.Clear();

                        foreach (DataRow item in dts.Rows)
                        {
                            string tempMusteriKou = item["MusteriKodu"].ToString();

                            var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<string>("MusteriKodu") == tempMusteriKou).ToList();

                            if (dt.Count > 0)
                            {

                                DataRow dr = dtsOrjinalValues.NewRow();
                                dr["MusteriKodu"] = dt[0][0].ToString();
                                dr["MusteriAdi"] = dt[0][1].ToString();

                                dtsOrjinalValues.Rows.Add(dr);

                            }


                        }
                        dtgResult.DataSource = dtsOrjinalValues;
                        dtgResult.Columns["MusteriKodu"].HeaderText = "MUHATAP KODU";
                        dtgResult.Columns["MusteriAdi"].HeaderText = "MUHATAP ADI";
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
                else
                {
                    if (resp.Count > 0)
                    {
                        DataTable dts = resp.CopyToDataTable();
                        dtgResult.DataSource = dts;

                        dtgResult.Columns["MusteriKodu"].HeaderText = "MUHATAP KODU";
                        dtgResult.Columns["MusteriAdi"].HeaderText = "MUHATAP ADI";
                    }
                    else
                    {
                        dtgResult.DataSource = null;
                    }
                }
            }
            else if (searchType == "CekmeListesiMusteriUrunuSecme")
            {

                try
                {
                    string kelime = txtSearch.Text;

                    kelime = KarakterDegistir(kelime);

                    var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("UrunKodu").Contains(kelime.ToUpper()) || x.Field<string>("UrunTanimi").Contains(kelime.ToUpper()) || x.Field<string>("Aciklama").Contains(kelime.ToUpper()) || x.Field<string>("SiparisNumarasi").Contains(kelime.ToUpper()) || x.Field<string>("SiparisSatirNo").Contains(kelime.ToUpper())).ToList();

                    if (Giris.genelParametreler.TurkceArama == "Y")
                    {
                        if (resp.Count > 0)
                        {
                            DataTable dts = resp.CopyToDataTable();
                            DataTable dtsOrjinalValues = dts.Copy();
                            dtsOrjinalValues.Rows.Clear();

                            foreach (DataRow item in dts.Rows)
                            {
                                string tempUrunKodu = item["UrunKodu"].ToString();
                                string tempSiparisNumarasi = item["SiparisNumarasi"].ToString();
                                string tempSiparisSatirNo = item["SiparisSatirNo"].ToString();

                                var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == tempUrunKodu && x.Field<string>("SiparisNumarasi") == tempSiparisNumarasi && x.Field<string>("SiparisSatirNo") == tempSiparisSatirNo).ToList();

                                if (dt.Count > 0)
                                {

                                    DataRow dr = dtsOrjinalValues.NewRow();
                                    dr["UrunKodu"] = dt[0][0].ToString();
                                    dr["UrunTanimi"] = dt[0][1].ToString();
                                    dr["Aciklama"] = dt[0][2].ToString();
                                    dr["SiparisNumarasi"] = dt[0][3].ToString();
                                    dr["SiparisSatirNo"] = dt[0][4].ToString();

                                    dtsOrjinalValues.Rows.Add(dr);

                                }


                            }
                            dtgResult.DataSource = dtsOrjinalValues;

                            dtgResult.Columns["UrunKodu"].HeaderText = "ÜRÜN KODU";
                            dtgResult.Columns["UrunTanimi"].HeaderText = "ÜRÜN ADI";
                            dtgResult.Columns["Aciklama"].HeaderText = "AÇIKLAMA";

                        }
                        else
                        {
                            dtgResult.DataSource = null;
                        }
                    }
                    else
                    {
                        if (resp.Count > 0)
                        {
                            DataTable dts = resp.CopyToDataTable();
                            dtgResult.DataSource = dts;

                            dtgResult.Columns["UrunKodu"].HeaderText = "ÜRÜN KODU";
                            dtgResult.Columns["UrunTanimi"].HeaderText = "ÜRÜN ADI";
                            dtgResult.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
                        }
                        else
                        {
                            dtgResult.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            vScrollBar1.Maximum = dtgResult.RowCount;

        }
        //
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

        private void dtgResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dtgResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    dtgResult.CurrentRow.Selected = true;
            //}
        }

        private void dtgResult_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Test");
            //for (int i = 0; i <= dtgResult.Rows.Count; i++)
            //{
            //    dtgResult.CurrentRow.Selected = true;

            //}

        }
    }
}