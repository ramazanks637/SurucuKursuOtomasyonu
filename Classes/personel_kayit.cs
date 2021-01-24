using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace benimsurucukursu
{
    class personel_kayit
    {

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
        SqlCommand komut;
        SqlCommand komutReader;
        SqlDataReader read;


        public bool personelkayit(TextBox tc, TextBox ad, TextBox soyad, TextBox telefon, TextBox adres, TextBox eposta, TextBox görevi, GroupBox grup)
        {

                baglanti.Open();
                

                komut = new SqlCommand();

                komutReader = new SqlCommand();

                komutReader.Connection = baglanti;

                komutReader.CommandText = "select * from ogrenci_kayit where tc='" + tc.Text + "'";
                read = komutReader.ExecuteReader();

                if (read.Read() == false)
                {
                    baglanti.Close();
                    
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "insert into personel_kayit values('" + tc.Text + "','" + ad.Text + "','" + soyad.Text + "','" + telefon.Text + "','" + adres.Text + "','" + eposta.Text + "','" + görevi.Text + "')";
                    // komut.CommandText = "insert into ogrenci_kayit values('sa','sa','sa','sa','sa','sa','sa','sa','sa','sa','sa')";

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Personel Eklendi ");
                    foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
                    baglanti.Close();

                    return true;
                }
                else
                {
                    MessageBox.Show("Bu Kişi Öğrencidir. ");
                    baglanti.Close();

                    return false;
                }

           
        }



    }
}
