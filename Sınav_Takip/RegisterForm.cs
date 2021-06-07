using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;

namespace Sınav_Takip
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        // Gerekli değişken tanımlamaları
        string secilen_resim;
        Button[] buttons = new Button[6];

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Buton dizisine butonlarımızı ekliyoruz
            buttons[0] = img0;
            buttons[1] = img1;
            buttons[2] = img2;
            buttons[3] = img3;
            buttons[4] = img4;
            buttons[5] = img5;

            // Avatar seçim butonlarına resimleri yükledik
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].BackgroundImage = Image.FromFile(Exam.path + "//images//" + buttons[i].Name + ".png");
            }
        }

        // Avatar butonlarının hepsi bu evente bağlı. 
        private void imgButtonClick(object sender, EventArgs e)
        {
            // Hangi butonun bu eventi çağırdığını buluyoruz
            Button button = (Button)sender;

            // Hangi butona tıklandıysa o butonun ismini seçilen resim değişkenine atıyoruz
            secilen_resim = button.Name;

            // Bir resme tıklandığında diğer tüm resim tuşlarının kenar renkleri eski haline dönüyor
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].FlatAppearance.BorderColor = Color.Black;
                buttons[i].FlatAppearance.BorderSize = 1;
            }

            // Ama tıkladığımız resim(avatar) butonunun kenar rengi ve kalınlığı değişiyor. Bu sayede kullanıcı
            // hangi resmi seçtiğini görebiliyor.
            button.FlatAppearance.BorderColor = Color.Red;
            button.FlatAppearance.BorderSize = 2;
        }

        private void btnKayit_Click(object sender, EventArgs e)
        { 
            // Gereken bilgilerin girilip girilmediği kotrolü
            if (txtAd.Text == "" || txtK_Adi.Text == "" || txtMail.Text == "" || 
                txtParola.Text == "" || txtParola2.Text == "")
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurunuz.", "Uyarı");
                return;
            }
            if (secilen_resim == null)
            {
                MessageBox.Show("Lütfen avatar seçiniz!", "Avatar");
                return;
            }
            if (txtParola.Text != txtParola2.Text)
            {
                MessageBox.Show("Parolalar uyuşmuyor!", "Uyarı");
                return;
            }

            // Girilen mail adresi mail adresi formatına uyuyor mu kontrolü
            try
            {
                MailAddress m = new MailAddress(txtMail.Text);
            }
            catch
            {
                MessageBox.Show("Lütfen geçerli bir e posta adresi girin!","Hata");
                return;
            }

            // Eğer tüm şartlar sağlandıysa Kayıt ol metodu çalışıyor, true dönerse kayıt ekleniyor
            if(!Exam.KayitOl(txtK_Adi.Text,txtAd.Text,txtParola.Text,txtMail.Text,secilen_resim))
            {
                MessageBox.Show("Bu kullanıcı adı alınmış!", "Hata");
                return;
            }

            MessageBox.Show("Başarıyla kayıt oldunuz. ", "Bilgi");          
            Close();
        }

        // Kayıt formu kapanınca giriş yapma formu açılıyor
        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SignInForm signIn = new SignInForm();         
            signIn.txtK_Adi.Text = txtK_Adi.Text;
            signIn.Show();
        }
    }
}
