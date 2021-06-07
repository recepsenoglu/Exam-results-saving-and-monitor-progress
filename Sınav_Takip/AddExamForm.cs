using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sınav_Takip
{
    public partial class AddExamForm : Form
    {
        public AddExamForm()
        {
            InitializeComponent();
        }

        // Gerekli değişken tanımlamaları
        public string k_adi;
        string[] dersler = { };

        Label[] labels = new Label[10];
        TextBox[] textBoxesT = new TextBox[10];
        TextBox[] textBoxesF = new TextBox[10];

        private void cmbboxSinavSecimi_SelectedValueChanged(object sender, EventArgs e)
        {
            // Combobox'dan seçilen derse göre dersler değişkenine Exam sınıfından static derslerin listesi alınır
            dersler = Exam.DersleriAl(cmbboxSinavSecimi.SelectedItem.ToString());

            // Bu derslere göre arayüz oluşturulur. (4 ders varsa 4 tane label, 8 tane textbox oluşur. 6 ders
            // varsa 6 label 12 textbox...
            ArayuzOlustur(dersler);
        }

        // Çalışma esnasında label ve textbox oluşturan metod
        public void ArayuzOlustur(string[] dersler)
        {
            // Ders sayısına göre dinamik olarak form boyutu ve konumu ayarlama
            Size = new Size(300, 230 + (dersler.Count() * 23));
            Location = new Point(600, 200);

            // Daha önceden label ve textbox varsa kaldıran döngü
            for (int i = 0; i < labels.Count(); i++)
            {
                Controls.Remove(labels[i]);
                Controls.Remove(textBoxesT[i]);
                Controls.Remove(textBoxesF[i]);
            }

            // Ders sayısı kadar dönen ve her döngüde label ve textboxları ekleyen döngü
            for (int i = 0; i < dersler.Count(); i++)
            {
                labels[i] = new Label();
                labels[i].Text = dersler[i];
                Controls.Add(labels[i]);
                labels[i].Top = i * 25 + 170;
                labels[i].Left = 7;

                textBoxesT[i] = new TextBox();
                Controls.Add(textBoxesT[i]);
                textBoxesT[i].Top = i * 25 + 170;
                textBoxesT[i].Left = 137;
                textBoxesT[i].Width = 50;

                textBoxesF[i] = new TextBox();
                Controls.Add(textBoxesF[i]);
                textBoxesF[i].Top = i * 25 + 170;
                textBoxesF[i].Left = 200;
                textBoxesF[i].Width = 60;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // Gerekli bilgiler girilip girilmediği kontrol edilir
            if(cmbboxSinavSecimi.SelectedIndex == -1)
            {
                MessageBox.Show("Sınav seçimi yapın!");
                return;
            }
            else if(txtPuan.Text == "" || txtSure.Text == "")
            {
                MessageBox.Show("Lütfen tüm bilgileri girin!");
                return;
            }
            for(int i = 0; i < dersler.Count(); i++)
            {
                if(textBoxesT[i].Text == "" || textBoxesF[i].Text == "")
                {
                    MessageBox.Show("Lütfen tüm derslerin doğru ve yanlış soru sayılarını girin!");
                    return;
                }
            }

            // Gerekli bilgiler girildiyse sınav(deneme) eklenmek üzere veriler hazırlanır
            dtpkTarih.Format = DateTimePickerFormat.Custom;
            dtpkTarih.CustomFormat = "d/M/yyyy h:mm";
            DateTime dt = dtpkTarih.Value;
            string tarih = dt.ToString();
            int dogru = 0;
            int yanlis = 0;
            float net;
            string netler = "";

            // Bu döngüde veritabanına liste tipinde değişken eklenmediği için liste elemanlarını aralarına virgül
            // koyarak string haline getirdim. Bir nevi boxing işlemi gibi düşünebiliriz. Derslerin doğru ve yanlış
            // sayılarını veritabanında tabloda ayrı ayrı sütunlar eklemek yerine 'netler' sütununa bu doğru ve yanlışları
            // virgül ile ayrılmış tek bir string halinde tuttum
            for(int i = 0; i < dersler.Count(); i++)
            {
                dogru = int.Parse(textBoxesT[i].Text);
                yanlis = int.Parse(textBoxesF[i].Text);
                netler += dogru + "," + yanlis + ","; // paketleme işlemi
            }
            net = dogru - yanlis - ((float)yanlis / 4);
            netler = netler.Substring(0, netler.Length - 1);

            // Exam sınıfının verileriyükle adlı static metoduna kullanıcı girdileri parametre olarak verilir. 
            if (Exam.VerileriYükle(k_adi, cmbboxSinavSecimi.SelectedItem.ToString(), tarih, txtSure.Text, txtPuan.Text,
                dogru.ToString(),yanlis.ToString(),net.ToString(),netler))
            {
                MessageBox.Show("Kayıt başarıyla eklendi.");
                Close();
            }
            else
            {
                MessageBox.Show("Bir hata oluştu. Lütfen girdiğiniz verileri kontrol edin.");
                return;
            }
        }

        // Sınav ekleme formu kapanınca review(anasayfa) açılır.
        private void AddExamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReviewForm reviewForm = new ReviewForm();
            reviewForm.k_adi = k_adi;
            reviewForm.Show();
        }
    }
}
