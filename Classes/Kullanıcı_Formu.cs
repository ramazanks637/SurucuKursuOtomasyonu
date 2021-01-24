using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace benimsurucukursu
{
    class Kullanıcı_Formu
    {
       
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader read;


      

        public bool kullanıcı(TextBox kullanıcıadı, TextBox parola)
        {

            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select *from kullanici_girisi where kullanici_adi='" + kullanıcıadı.Text + "' and sifre='" + parola.Text + "'";
            read = komut.ExecuteReader();
            if (read.Read() == true)
            {
                baglanti.Close();
                MessageBox.Show("Giriş başarılı");
                return true;
              
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Hata");
                return false;

            }
           
        


        }

        public void yenikullanıcı(TextBox ad, TextBox soyad, TextBox kullanıcıadı, TextBox şifre, TextBox şifretekrar,ComboBox soru,TextBox cevap, GroupBox grup)
        {
            if (şifre.Text == şifretekrar.Text)
            {
                baglanti.Open();
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "insert into kullanici_girisi values('" + ad.Text + "','" + soyad.Text + "','" + kullanıcıadı.Text + "','" + şifre.Text + "','" + soru.Text + "','" + cevap.Text + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kullanıcı Eklendi ");
                foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
            }
            else
            {
                MessageBox.Show("Şifreler Uyuşmuyor !!!");
            }
        }




        public void sifre(TextBox ad,TextBox soyad,TextBox kullaniciadi,TextBox sifre,TextBox sifretekrar,ComboBox soru,TextBox cevap,GroupBox grup) 
        {
            if (sifre.Text == sifretekrar.Text)
            {
                baglanti.Open();
                komut = new SqlCommand("select *from kullanici_girisi where kullanici_adi='" + kullaniciadi.Text + "'", baglanti);
                read = komut.ExecuteReader();

                if (read.Read() == true)
                {
                    if (soru.Text == read["soru"].ToString() && cevap.Text == read["cevap"].ToString())
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut = new SqlCommand("update kullanici_girisi set ad='"+ad.Text+ "',soyad='" + soyad.Text + "',sifre='" + sifre.Text + "' where kullanici_adi='"+kullaniciadi.Text+"' ", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("İşlem Başarılı");
                        foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı hariç diğer bilgilerinizi kontrol ediniz.","Hata1");
                    }
                }
                else
                {
                    MessageBox.Show("Bilgilerinizi kontrol ediniz.", "Hata2");
                }
                baglanti.Close();

            }

            else
            {
                MessageBox.Show("Şifreler Uyuşmuyor !!!", "Hata3");
            }



        }

    }

    }

