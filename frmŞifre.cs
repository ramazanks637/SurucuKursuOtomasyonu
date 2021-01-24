using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace benimsurucukursu
{
    public partial class frmŞifre : Form
    {
        public frmŞifre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            girisformu giris = new girisformu();
            giris.Show();
        }

        Kullanıcı_Formu k = new Kullanıcı_Formu();
        private void btnsifre_Click(object sender, EventArgs e)
        {
            k.sifre(adtxt, soyadtxt, kullanıcıaditxt, sifretxt, sifretkrtxt, sorucmbox, cevaptxt, groupBox1);
        }
    }
}
