using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

// Bu program Recep Oğuzhan ŞENOĞLU'ya aittir.

namespace Sınav_Takip
{
    class Exam
    {
        // Derslerin tanımlanması
        public static string[] LGS = { "Türkçe", "T.C. İnk. Tarihi", "Din Kültürü A.B.", "Yabancı Dil", "Matematik", "Fen Bilimleri" };
        public static string[] TYT = { "Türkçe", "Sosyal Bilimler", "Temel Matematik", "Fen Bİlimleri" };
        public static string[] AYTsözel = { "TÜRK DİLİ Ve EDEBİYATI", "TARİH-1", "COĞRAFYA-1", "TARİH-2", "COĞRAFYA-2", "FELSEFE GRUBU", "DİN KÜLTÜRÜ" };
        public static string[] AYTesit_agirlik = { "TÜRK DİLİ Ve EDEBİYATI", "TARİH-1", "COĞRAFYA-1", "MATEMATİK" };
        public static string[] AYTsayisal = { "MATEMATİK", "FİZİK", "KİMYA", "BİYOLOJİ" };
        public static string[] KPSSonlisans = { "Genel Yetenek", "Genel Kültür" };
        public static string[] KPSSlisans = { "Genel Yetenek", "Genel Kültür", "Lisans Dersi" };

        // Programın çalıştığı dizin
        public static string path = Application.StartupPath;

        // Masaüstü dizini
        static string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // Veritabanı bağlantı nesnesi 
        // Data Source'da desktop dizinini verdim. Yani veritabanı bağlantısı yapılabilmesi için
        // veritabanı.accdb dosyasının masaüstünde olması gerekiyor!
        static OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + desktop + "\\Veritabanı.accdb");

        // Sınav ismi parametresi alarak O sınavın derslerinin string dizisi gönderilir
        public static string[] DersleriAl(string sinav)
        {
            switch (sinav)
            {
                case "LGS":
                    return LGS;
                case "TYT":
                    return TYT;
                case "AYT-Sözel":
                    return AYTsözel;
                case "AYT-Eşit Ağırlık":
                    return AYTesit_agirlik;
                case "AYT-Sayısal":
                    return AYTsayisal;
                case "KPSS-Ön Lisans":
                    return KPSSonlisans;
                case "KPSS-Lisans":
                    return KPSSlisans;
                case "KPSS-Orta Öğretim":
                    return KPSSonlisans;
            }
            return new string[0];
        }

        // Giriş yapma metodu. Parametre olarak kullanıcı adı ve parola alır. Eğer ikisi de doğruysa true döner.
        public static bool GirisYap(string k_adi, string parola)
        {
            connection.Open();
            string CommandText = "SELECT * FROM Kullanici WHERE k_adi='" + k_adi.ToLower() + "' AND parola='" +
                parola + "'";
            OleDbCommand command = new OleDbCommand(CommandText, connection);
            OleDbDataReader dr;
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        // Veritabanına kullanıcı ekleyen metod. Kullanıcı adı özelliği birincil anahtar olduğu için eğer zaten 
        // var olan bir kullanıcı adı ile kayıt olmaya çalışılırsa false döner. Aksi durumda kayıt başarılı olur ve true döner
        public static bool KayitOl(string k_adi,string adi, string parola, string mail, string resim)
        {
            connection.Open();
            string CommandText = "SELECT * FROM Kullanici WHERE k_adi='" + k_adi.ToLower() + "'";
            OleDbCommand command = new OleDbCommand(CommandText, connection);
            OleDbDataReader dr;
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                connection.Close();
                return false;
            }
            CommandText = "insert into Kullanici(adi,k_adi,parola,mail,resim) values('" + adi + "','" + k_adi.ToLower() +
                "','" + parola + "','" + mail + "','" + resim + "')";
            command = new OleDbCommand(CommandText, connection);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        // Reviewform (anasayfa)'da gösterilen kullanıcının adı ve avatarını vertabanından getirir
        public static string[] BilgileriGetir(string k_adi)
        {
            string[] return_string = new string[2];
            connection.Open();
            string CommandText = "SELECT adi,resim FROM Kullanici WHERE k_adi='" + k_adi + "'";
            OleDbCommand command = new OleDbCommand(CommandText, connection);
            OleDbDataReader dr;
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                return_string[0] =  dr["adi"].ToString();
                return_string[1] = dr["resim"].ToString();
            }
            connection.Close();
            return return_string;
        }

        // Şifremi unuttum formunda girilen kullanıcı adına sahip kaydın ad, parola ve mail bilgilerini getirir
        public static string[] MailveParolaAl(string k_adi)
        {
            string[] return_string = new string[4];
            connection.Open();
            string CommandText = "SELECT adi,k_adi,parola,mail FROM Kullanici WHERE k_adi='" + k_adi + "'";
            OleDbCommand command = new OleDbCommand(CommandText, connection);
            OleDbDataReader dr;
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    return_string[0] = dr["adi"].ToString();
                    return_string[1] = dr["k_adi"].ToString();
                    return_string[2] = dr["parola"].ToString();
                    return_string[3] = dr["mail"].ToString();
                }
                connection.Close();
                return return_string;
            }
            connection.Close();
            return null;
        }

        // Verilen kullanıcı adına ve sınav adına sahip denemelerin puanlarını getirir. Puan ortalaması almak için kullandım
        public static DataTable GenelOrtalamaGetir(string k_adi,string sinav_adi)
        {
            connection.Open();
            string commandText = "select puan from Denemeler where k_adi='" + k_adi + "' and sinav_adi = '" + sinav_adi + "'";
            OleDbCommand command = new OleDbCommand(commandText, connection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        // Verilen id'ye ait denemenin bilgilerini getirir. SInav id birincil anahtar olduğu için tek bir deneme getirir
        public static DataTable DenemeGetir(string id)
        {
            connection.Open();
            string commandText = "select sinav_adi,sure,puan,netler from Denemeler where id=" + int.Parse(id);
            OleDbCommand command = new OleDbCommand(commandText, connection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        // Id'si verilen denemeyi veritabanından siler
        public static void DenemeSil(string sinav_id)
        {
            connection.Open();
            string CommandText = "delete from Denemeler where id=" + sinav_id;
            OleDbCommand command = new OleDbCommand(CommandText, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        // Reviewform'daki datagridview için kullanıcı adı verilen kaydın tüm denemelerini getirir
        public static DataTable VerileriGetir(string k_adi)
        {
            connection.Open();
            string commandText = "select id,tarih,sinav_adi,sure,dogru,yanlis,net,puan from Denemeler where k_adi='" + k_adi + "'";
            OleDbCommand command = new OleDbCommand(commandText, connection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;         
        }

        // Verilen parametrelere göre veritabanına deneme ekler
        public static bool VerileriYükle(string k_adi, string sinav_adi, string tarih, string sure, string puan,
            string dogru, string yanlis, string net, string netler)
        {
            try
            {
                connection.Open();
                string CommandText = "insert into Denemeler(k_adi,sinav_adi,tarih,sure,puan,dogru,yanlis,net,netler) " +
                    "values('" + k_adi + "','" + sinav_adi + "','" + tarih + "','" +
                    sure + "','" + puan + "','" + dogru + "','" + yanlis + "','" +
                    net + "','" + netler + "')";
                OleDbCommand command = new OleDbCommand(CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
