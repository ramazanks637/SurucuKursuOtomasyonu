using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace benimsurucukursu
{
    public partial class girisformu : Form
    {
        public girisformu()
        {
            InitializeComponent();
        }

     //   SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4 ;Initial Catalog=giris_ekrani;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnkücült_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      /*  private void button3_Click(object sender, EventArgs e)
        {

                baglanti.Open();
                String sql = "Select * from kullanici_girisi where kullanici_adi=@k_ad AND sifre=@prl";
                SqlParameter prm = new SqlParameter("k_ad", txtkullanıcı.Text.Trim());
                SqlParameter prm2 = new SqlParameter("prl", txtparola.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

            if (dt.Rows.Count > 0)
                {

                    anaform app = new anaform();
                    app.Show();

                }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            }

            baglanti.Close();
            this.Hide();
         // this.Close();
        }
      */
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {

                txtparola.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {

                txtparola.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";

            }
        }

        private void txtkullanıcı_Click(object sender, EventArgs e)
        {
            if (kullanıcıadı.Text == "Kullanıcı Adı")
            {
                kullanıcıadı.Text = "";
                kullanıcıadı.ForeColor = Color.White;

            }
            else if (kullanıcıadı.Text == "")
            {
                kullanıcıadı.Text = "Kullanıcı Adı";
            }
            if (txtparola.Text == "")
            {
                txtparola.Text = "Parola";
            }
        }

        private void txtparola_Click(object sender, EventArgs e)
        {
            if (kullanıcıadı.Text == "")
            {
                kullanıcıadı.Text = "Kullanıcı Adı";
            }
            
             txtparola.Text = "";
           
        }

        private void lblyenikayit_Click(object sender, EventArgs e)
        {
            frmYeni app = new frmYeni();
            app.Show();
            this.Hide();
        }

        private void lblşifremiunutum_Click(object sender, EventArgs e)
        {
            frmŞifre app = new frmŞifre();
            app.Show();
            this.Hide();


        }

        Kullanıcı_Formu k = new Kullanıcı_Formu();
        private void btngiris_Click(object sender, EventArgs e)
        {
            anaform app = new anaform();

            if (k.kullanıcı(kullanıcıadı, txtparola))
            {
                this.Hide();

                app.ShowDialog();
            }
            
        }
    }
}
