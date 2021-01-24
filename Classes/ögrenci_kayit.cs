using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace benimsurucukursu
{
    class ögrenci_kayit
    {

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
        SqlCommand komut;
        SqlCommand komutReader;
        SqlDataReader read;


        public bool yeniögrenci(TextBox tc, TextBox ad, TextBox soyad, TextBox yas, ComboBox ögrenimdurumu, TextBox telefon, String varyoksaglik, String varyokadli,DateTimePicker kayittarihi,ComboBox sinifadi,ComboBox ehliyetsinifi, GroupBox grup)
        {
                try
                {
                    baglanti.Open();
                    komut = new SqlCommand();
                    
                   

                komutReader = new SqlCommand();

                komutReader.Connection = baglanti;

                komutReader.CommandText= "select *from ogrenci_kayit where tc='" + tc.Text + "'";
                    read = komutReader.ExecuteReader();

                    if (read.Read() == false)
                    {
                    baglanti.Close();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "insert into ogrenci_kayit values('" + tc.Text + "','" + ad.Text + "','" + soyad.Text + "','" + yas.Text + "','" + ögrenimdurumu.Text + "','" + telefon.Text + "','" + varyoksaglik.ToString() + "','" + varyokadli.ToString() + "','" + kayittarihi.Value.ToString("yyyy-MM-dd") + "','" + sinifadi.Text + "','" + ehliyetsinifi.Text + "')";
                 // komut.CommandText = "insert into ogrenci_kayit values('sa','sa','sa','sa','sa','sa','sa','sa','sa','sa','sa')";

                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Kullanıcı Eklendi ");
                        foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Mevcut ");
                        return false;
                    }
                }

               
                catch(Exception e)
                {

                    MessageBox.Show("Kullanıcı Eklenemedi Bir Hata Oluştu "+ e.Message.ToString());
                    return false;
                }
        }

        

    }
}
