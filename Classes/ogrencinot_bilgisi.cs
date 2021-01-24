using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace benimsurucukursu
{
    class ogrencinot_bilgisi
    {


        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
        SqlCommand komut;
        SqlCommand komut2;
        SqlDataReader read;
        SqlDataReader read2;




        public void notbilgisi(TextBox tc, DateTimePicker sinavtarihi, TextBox trafiksinavinotu, TextBox motorsinavinotu, TextBox ilkyardimsinavinotu, GroupBox grupnotgirisi)
        {
           
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from ogrenci_kayit where tc='" + tc.Text + "'";
            read = komut.ExecuteReader();

            if (read.Read() == true)
            {
                baglanti.Close();
                baglanti.Open();
                komut2 = new SqlCommand();
                komut2.Connection = baglanti;
                komut2.CommandText = "select * from ogrencinot_bilgisi where tc='" + tc.Text + "'";
                read2 = komut2.ExecuteReader();

                if (read2.Read() == false)
                {
                    baglanti.Close();
                    baglanti.Open();
                    komut = new SqlCommand();
                    komut.Connection = baglanti;
                    komut.CommandText = "insert into ogrencinot_bilgisi values('" + tc.Text + "','" + sinavtarihi.Value.ToString("dd-MM-yyyy") + "','" + trafiksinavinotu.Text + "','" + motorsinavinotu.Text + "','" + ilkyardimsinavinotu.Text + "')";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Not Başarıyla Eklendi");
                    foreach (Control item in grupnotgirisi.Controls) if (item is TextBox) item.Text = "";
                }
                else
                {
                    MessageBox.Show("Bu öğrenci not bilgisi daha önce girilmiş !!!");
                }
            }
            else
            {
                MessageBox.Show("Bu öğrenci bulunamadı !!!");
            }
        }





    }
}
