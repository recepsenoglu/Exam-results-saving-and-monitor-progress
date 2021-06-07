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
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            // Program açıldığında giriş sayfasındaki logoyu yükleyen kod kısmı
            pictureBox1.Image = Image.FromFile(Exam.path + "//images//logo.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            // Giriş yapmadan önce tüm bilgiler girildi mi kontrolü
            if(txtK_Adi.Text == "" || txtParola.Text == "")
            {
                MessageBox.Show("Lütfen tüm bilgileri girin!", "Uyarı");
                return;
            }
            // Giriş yap metodundan false geldiyse hata mesajını bildir. (Kullanıcı adı veya parola hatalı ise false verir)
            if(!Exam.GirisYap(txtK_Adi.Text, txtParola.Text))
            {
                MessageBox.Show("Kullanıcı adı veya parola hatalı, ama hangisi söylemem.", "Hata");
                return;
            }

            // Eğer giriş yap metodundan true gelirse review form açılır. 
            ReviewForm reviewForm = new ReviewForm();
            reviewForm.k_adi = txtK_Adi.Text;
            reviewForm.Show();
            Hide();
        }

        private void lbl_forgot_the_password_Click(object sender, EventArgs e)
        {
            // Şifremi unuttum formunu açar
            ForgotThePasswordForm forgotThePasswordForm = new ForgotThePasswordForm();
            forgotThePasswordForm.txtK_Adi.Text = txtK_Adi.Text;
            forgotThePasswordForm.ShowDialog();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            // Kayıt formunu açar 
            RegisterForm registerForm = new RegisterForm();
            registerForm.txtK_Adi.Text = txtK_Adi.Text;
            registerForm.txtParola.Text = txtParola.Text;
            registerForm.Show();
            Hide();
        }

        // Şifremi unuttum yazısının üstüne mouse getirince yazı rengi değişmesini sağlar
        private void lbl_forgot_the_password_MouseEnter(object sender, EventArgs e)
        {
            lbl_forgot_the_password.ForeColor = Color.LightSeaGreen;
        }
        private void lbl_forgot_the_password_MouseLeave(object sender, EventArgs e)
        {
            lbl_forgot_the_password.ForeColor = Color.Black;
        }     
    }
}
