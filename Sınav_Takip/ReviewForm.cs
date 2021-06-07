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
    public partial class ReviewForm : Form
    {
        public ReviewForm()
        {
            InitializeComponent();
        }
        
        // Gerekli değişken tanımlamaları
        public string k_adi;
        public string sinav;

        // Gözden geçirme (anasayfa) formu
        private void ReviewForm_Load(object sender, EventArgs e)
        {   
            // Anasayfa açıldığında gerekli bilgileri ve avatarı getirip ekranda gösteren kısım
            lblAd.Text = Exam.BilgileriGetir(k_adi)[0];
            lblK_adi.Text = k_adi;
            pctrboxAvatar.Image = Image.FromFile(Exam.path + "//images//" + Exam.BilgileriGetir(k_adi)[1] + ".png");
            pctrboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;

            if(lblAd.Text.Length > 14) lblAd.Font = new Font("Arial",8);

            // Öğrencinin daha önce yüklediği denemeler getirilir
            VerileriGetir();
        }
 
        private void VerileriGetir()
        {   
            // Verilen kullanıcı adı ile kaydedilen denemeleri çekip datagridview'de gösterir
            dtgrdviewDenemeler.DataSource = Exam.VerileriGetir(k_adi);
            dtgrdviewDenemeler.Columns[0].Width = 0;
            dtgrdviewDenemeler.Columns[1].Width = 95;
            dtgrdviewDenemeler.Columns[1].HeaderText = "Tarih";
            dtgrdviewDenemeler.Columns[2].HeaderText = "Sınav Adı";
            dtgrdviewDenemeler.Columns[3].HeaderText = "Süre(dk)";
            dtgrdviewDenemeler.Columns[4].HeaderText = "Doğru Cevap";
            dtgrdviewDenemeler.Columns[5].HeaderText = "Yanlış Cevap";
            dtgrdviewDenemeler.Columns[6].HeaderText = "Net Sayısı";
            dtgrdviewDenemeler.Columns[7].HeaderText = "Sınav Puanı";   
        }

        private void btnDenemeEkle_Click(object sender, EventArgs e)
        {
            // Deneme ekleme formu açılır
            AddExamForm addExamForm = new AddExamForm();
            addExamForm.k_adi = k_adi;
            Hide();
            addExamForm.Show();
        }

        private void dtgrdviewDenemeler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Denemelerde herhangi bir denemenin üstüne mouse ile çift tıklandığında o denemenin ayrıntıları formu açılır
            DetailsForm detailsForm = new DetailsForm();
            detailsForm.sinav_id = dtgrdviewDenemeler.CurrentRow.Cells["id"].Value.ToString();
            detailsForm.k_adi = k_adi;
            detailsForm.ShowDialog();
        }

        private void menuitemSil_Click(object sender, EventArgs e)
        {
            // Datagridview'de bir denemeye sağ tıklayıp denemeyi sil dendiğinde Exam.DenemeSil metodu çalışır
            if(DialogResult.OK == MessageBox.Show("Denemeyi silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop))
            {
                // Exam sınıfında bulunan static deneme silme metodu. Parametre olarak deneme id'si alır
                Exam.DenemeSil(dtgrdviewDenemeler.CurrentRow.Cells["id"].Value.ToString());
                VerileriGetir();
                MessageBox.Show("Deneme başarıyla silindi.");
            }
        }

        private void ReviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
