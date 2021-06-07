using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;

namespace Sınav_Takip
{
    public partial class ForgotThePasswordForm : Form
    {
        public ForgotThePasswordForm()
        {
            InitializeComponent();
        }

        private void btnSendMyPassword_Click(object sender, EventArgs e)
        {
            btnSendMyPassword.Enabled = false;

            // Exam class'ındaki MailveParolaAl metoduna kullanıcı adını gönderiyoruz. Ve bu metod da bize 
            // bu kullanıcı adına sahip kullanıcının bazı gerekli değişkenlerini gönderiyor (mail adresi, parola vb)
            string[] parametreler = Exam.MailveParolaAl(txtK_Adi.Text);

            // Eğer hiçbir şey dönmemişse kullanıcı yok demektir
            if(parametreler == null)
            {
                MessageBox.Show("Böyle bir kullanıcı kayıtlı değil!", "Kullanıcı bulunamadı");
                btnSendMyPassword.Enabled = true;
                return;
            }

            // MailGonder metoduna kullanıcının adı, kullanıcı adı, parola ve e-mail adresi gönderiliyor
            mailGonder(parametreler[0], parametreler[1], parametreler[2], parametreler[3]);
            if(DialogResult.OK == MessageBox.Show("Parolan mail adresine gönderildi. Kontrol edip giriş yapabilirsin.", "Gönderildi",MessageBoxButtons.OK))
            {
                Close();
            }
        }

        // Mail gönderme işlemini yapan metod
        private void mailGonder(string isim, string kullanici_adi, string parola, string mail_adresi)
        {
            // smtp nesnesi oluşturma
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            // Mail gönderen hesap (proje için bir mail adresi açtım)
            smtp.Credentials = new NetworkCredential("yazilimprojesimailhesabi@gmail.com", "yasasinbilim");

            // Mail nesnesi
            MailMessage mail = new MailMessage(); 

            // Gönderen hesap
            mail.From = new MailAddress("yazilimprojesimailhesabi@gmail.com", "SınavTakip");

            // Alıcı hesap (parametrelerden gelen kullanıcı hesabı)
            mail.To.Add(mail_adresi);

            // Mail konu kısmı
            mail.Subject = "Sınav Takip Parola Hatırlatma";
            mail.IsBodyHtml = true;

            // Mail gövdesi
            mail.Body = "Merhabalar dostum " + isim.ToUpper() + ".\nGörünüşe göre parolanı unutmuşsun. Senin için parolanı tozlu veritabanından çekip çıkardım." +
                "\nİşte " + kullanici_adi + " kullanıcı adlı hesabının parolası, tekrar unutayım deme :)\nPAROLAN: " + parola;

            smtp.Send(mail);
        }

        private void txtK_Adi_TextChanged(object sender, EventArgs e)
        {
            if (txtK_Adi.Text == "") btnSendMyPassword.Enabled = false;
            else btnSendMyPassword.Enabled = true;
        }
    }
}
