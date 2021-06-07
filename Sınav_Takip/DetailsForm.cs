using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sınav_Takip
{
    public partial class DetailsForm : Form
    {
        public DetailsForm()
        {
            InitializeComponent();
        }

        // Gerçekten gerekli değişken tanımlamaları
        string[] netler_sadelesmis = new string[11];
        TextBox[] textBoxesT = new TextBox[10];
        TextBox[] textBoxesF = new TextBox[10];
        TextBox[] textBoxesN = new TextBox[10];
        string[] yanlislar = new string[11];
        string[] dogrular = new string[11];
        string[] puanlar = new string[50];
        Label[] labels = new Label[10];
        public string sinav_id;
        public string k_adi;
        string[] dersler;
        string sinav_adi;
        string[] netler;
        string puanOrt;
        string sure;
        string puan;

        // Her şey form açıldığında gerçekleşiyor 
        private void DetailsForm_Load(object sender, EventArgs e)
        {
            // Detayları gösterilecek denemenin bilgileri getiriliyor
            DataTable gecerliDeneme = Exam.DenemeGetir(sinav_id);
            sinav_adi = gecerliDeneme.Rows[0]["sinav_adi"].ToString();
            netler = gecerliDeneme.Rows[0]["netler"].ToString().Split(',');
            puan = gecerliDeneme.Rows[0]["puan"].ToString();
            sure = gecerliDeneme.Rows[0]["sure"].ToString();

            // Denemenin dersleri getiriliyor
            dersler = Exam.DersleriAl(sinav_adi);

            // Formdaki bilgilendirme kısımları
            Text = sinav_adi;
            lblPuan.Text = puan;
            lblSure.Text = sure + "  dakika";

            // Gerekli metodlar çağırılıyor
            StringIslemleri();
            ArayuzOlustur(dersler);
            ChartOlustur();
        }

        // Puan ortalaması bulan ve netleri sadeleştiren metod
        private void StringIslemleri()
        {
            DataTable denemeOrtalamalar = Exam.GenelOrtalamaGetir(k_adi, sinav_adi);
            for (int i = 0; i < denemeOrtalamalar.Rows.Count; i++)
            {
                puanlar[i] = denemeOrtalamalar.Rows[i]["puan"].ToString();
            }

            double toplam = 0;
            for (int i = 0; i < denemeOrtalamalar.Rows.Count; i++) toplam += int.Parse(puanlar[i]);
            puanOrt = (toplam / denemeOrtalamalar.Rows.Count).ToString();

            for (int i = 0; i < netler.Count(); i++)
            {
                if (i % 2 == 0) dogrular[i / 2] = netler[i];
                else yanlislar[(i - 1) / 2] = netler[i];
            }
            for (int i = 0; i < dersler.Length; i++)
            {
                float dogru = float.Parse(dogrular[i]);
                float yanlis = float.Parse(yanlislar[i]);
                netler_sadelesmis[i] = (dogru - yanlis - yanlis / 4).ToString();
            }
        }

        // Netleri ve puanı veri kaynağı olarak alıp chart oluşturan metod
        // Net değerlerini ve puanın ortalamayla ilişkisini netler
        public void ChartOlustur()
        {
            foreach (var series in chartNetler.Series)
            {
                series.Points.Clear();
            }

            for (int i = 0; i < dersler.Count(); i++)
            {
                chartNetler.Series["Dersler"].Points.Add(double.Parse(netler_sadelesmis[i]));
                chartNetler.Series["Dersler"].Points[i].AxisLabel = dersler[i];

            }
            chartNetler.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

            foreach (var series in chartPuan.Series)
            {
                series.Points.Clear();
            }

            chartPuan.Series["Puan"].Points.Add(double.Parse(puan));
            chartPuan.Series["Puan"].Points.Add(double.Parse(puanOrt));
            chartPuan.Series["Puan"].Points[0].AxisLabel = "Puan";
            chartPuan.Series["Puan"].Points[1].AxisLabel = "Ortalama Puan";

            chartPuan.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
        }

        // Deneme ekleme formundaki gibi gerekli label ve textboxları oluşturur ama bu sefer
        // içlerini de doldurur
        public void ArayuzOlustur(string[] dersler)
        {
            for (int i = 0; i < labels.Count(); i++)
            {
                this.Controls.Remove(labels[i]);
                Controls.Remove(textBoxesT[i]);
                Controls.Remove(textBoxesF[i]);
            }

            for (int i = 0; i < dersler.Count(); i++)
            {
                labels[i] = new Label();
                labels[i].Text = dersler[i];
                Controls.Add(labels[i]);
                labels[i].Top = i * 25 + 82;
                labels[i].Left = 7;

                textBoxesT[i] = new TextBox();
                Controls.Add(textBoxesT[i]);
                textBoxesT[i].Top = i * 25 + 82;
                textBoxesT[i].Left = 105;
                textBoxesT[i].Width = 30;
                textBoxesT[i].Enabled = false;

                textBoxesF[i] = new TextBox();
                Controls.Add(textBoxesF[i]);
                textBoxesF[i].Top = i * 25 + 82;
                textBoxesF[i].Left = 145;
                textBoxesF[i].Width = 30;
                textBoxesF[i].Enabled = false;

                textBoxesN[i] = new TextBox();
                Controls.Add(textBoxesN[i]);
                textBoxesN[i].Top = i * 25 + 82;
                textBoxesN[i].Left = 185;
                textBoxesN[i].Width = 35;
                textBoxesN[i].Enabled = false;

                float dogru = float.Parse(dogrular[i]);
                float yanlis = float.Parse(yanlislar[i]);
                float net = dogru - yanlis - yanlis / 4;
                textBoxesT[i].Text = dogru.ToString();
                textBoxesF[i].Text = yanlis.ToString();
                textBoxesN[i].Text = net.ToString();
            }
        }
    }
}
