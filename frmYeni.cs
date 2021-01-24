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
    public partial class frmYeni : Form
    {
        public frmYeni()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            girisformu giris = new girisformu();
            giris.Show();
        }
        Kullanıcı_Formu k = new Kullanıcı_Formu();
        private void button1_Click(object sender, EventArgs e)
        {
            k.yenikullanıcı(adtxt,soyadtxt,kullanıcıaditxt,şifretxt,şifretkrtxt,sorucmbox,cevaptxt,groupBox1);
        }
    }
}
