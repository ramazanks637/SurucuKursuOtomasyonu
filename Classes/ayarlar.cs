using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace benimsurucukursu
{
    class ayarlar
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
        SqlCommand komut;
        SqlCommand komutSecond;
        SqlDataReader read;
        public bool passwordUpdate(TextBox kullanici_ayar, TextBox mevcutsifre_ayar, TextBox yenisifre_ayar, TextBox yenisifretkr_ayar) {
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from kullanici_girisi where kullanici_adi='" + kullanici_ayar.Text + "' and sifre='" + mevcutsifre_ayar.Text + "'";
            read = komut.ExecuteReader();
            if (read.Read() == true)
            {
                if(yenisifre_ayar.Text.ToString().Trim() != yenisifretkr_ayar.Text.ToString().Trim()) {
                    MessageBox.Show("Yeni Şifreler Uyuşmuyor!");
                    return false;
                }
                baglanti.Close();
                baglanti.Open();
                komutSecond = new SqlCommand("update kullanici_girisi set sifre='" + yenisifre_ayar.Text + "' where kullanici_adi='"+kullanici_ayar.Text+"' ", baglanti);
                komutSecond.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("İşlem Başarılı");
                return true;
              
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Hata");
                return false;

            }

        } 
    }
}
