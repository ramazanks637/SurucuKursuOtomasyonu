using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace benimsurucukursu
{
     class odeme_bilgisi
    {
        
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
        SqlCommand komut;
        SqlCommand komutReader;
        SqlCommand komutReaderOdeme;
        SqlDataReader read;


        public bool yeniOdeme(TextBox tc, DateTimePicker odemetarihi, TextBox borc, TextBox odemeTutar, String odemeSekli, String cekimTipi, String taksit, GroupBox grup)
        {
                try
                {
                    baglanti.Open();
                    
                    komutReader = new SqlCommand();

                    komutReader.Connection = baglanti;

                    komutReader.CommandText= "select * from ogrenci_kayit where tc='" + tc.Text + "'";
                    read = komutReader.ExecuteReader();

                    if (read.Read() == true)
                    {
                        baglanti.Close();

                        baglanti.Open();

                        komut = new SqlCommand();

                        komutReaderOdeme = new SqlCommand();

                        komutReaderOdeme.Connection = baglanti;

                        komutReaderOdeme.CommandText= "select * from odeme_bilgisi where tc='" + tc.Text + "'";
                        read = komutReaderOdeme.ExecuteReader();

                        if (read.Read() == false)
                        {
                            baglanti.Close();
                            baglanti.Open();
                            komut.Connection = baglanti;
                            komut.CommandText = "insert into odeme_bilgisi values('" + tc.Text + "','" + odemetarihi.Value.ToString("yyyy-MM-dd") + "','" + borc.Text + "','" + odemeTutar.Text + "','" + odemeSekli.ToString() + "','" + cekimTipi.ToString() + "','" + taksit.ToString() +"')";
                            komut.ExecuteNonQuery();
                            baglanti.Close();
                            MessageBox.Show("Ödeme Eklendi ");
                            foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Öğrenci Ödeme Kaydı Mevcut");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Öğrenci Kaydı Mevcut Değil");
                        return false;
                    }
                }

               
                catch(Exception e)
                {

                    MessageBox.Show("Ödeme Eklenemedi Bir Hata Oluştu "+ e.Message.ToString());
                    return false;
                }
        }
    }
}
