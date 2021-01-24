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
    public partial class anaform : Form
    {

        public anaform()
        {

            InitializeComponent();
        }

        int ıd=0;
        ögrenci_kayit ög = new ögrenci_kayit();
        odeme_bilgisi ob = new odeme_bilgisi();
        ayarlar ayarlar = new ayarlar();
        

        String adlıkayıt, saglıkbelgesı;
        bool kimlikTipi = false;
        //false eskı ,true1 yenı
        private void buttonkaydet_Click(object sender, EventArgs e)
        {

             foreach (Control item in grup.Controls)
            {
                if (item is TextBox) {
                    if(item.Text.Trim() == "") {
                        MessageBox.Show("Boş Alan Bırakmayın!");
                        return;
                    }
                }
            };
          
                buttonyenikayit.Enabled = false;


                if (ıd == 0)
                {
                    ög.yeniögrenci(tctxt, adtxt, soyadtxt, yastxt, cmbboxögrenimdurumu, telefontxt, saglıkbelgesı, adlıkayıt, KayitTarihidateTimePicker, SinifAdicomboBox, EhliyetSinificomboBox, grup);
                    fillTable();
                }
                else
                {
                    //TODO:: GUncelleme
                    updateStudent(saglıkbelgesı, adlıkayıt);

                }
                saglıkbelgesı = "Yok";
                adlıkayıt = "Yok";
                VaradliRadioButton.Checked = false;
                YokadliRadioButton.Checked = false;
                VarsaglikRadioButton.Checked = false;
                YoksaglikRadioButton.Checked = false;
            
          
            
       
        }


        private void updateStudent(String saglık, String adlı)
        {
            SqlConnection baglanti;
            SqlCommand komut;


            baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            baglanti.Open();
            komut = new SqlCommand("update ogrenci_kayit set ad='" + adtxt.Text + "',soyad='" + soyadtxt.Text + "',tc='" + tctxt.Text + "',yas='" + yastxt.Text + "',ogrenimdurumu='" + cmbboxögrenimdurumu.Text + "',telefon='" + telefontxt.Text + "',saglikdurumu='" + saglık.ToString() + "',adlibelge='" + adlı.ToString() + "',kayittarihi='" + KayitTarihidateTimePicker.Value.ToString("yyyy-MM-dd") + "',sinifadi='" + SinifAdicomboBox.Text + "',ehliyetsinifi='" + EhliyetSinificomboBox.Text + "' where ID='" + ıd + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");
            ıd = 0;
            foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
            fillTable();
        }

        private void anaform_Load(object sender, EventArgs e)
        {
            buttonyenikayit.Enabled = false;
            buttonkaydet.Enabled = true;

            fillTable();
        }
       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch(tabControl1.SelectedIndex){
                case 0:
                    Tab0Func(e);
                    break;
                case 1:
                    Tab1Func(e);
                    break;
                case 2:
                    Tab2Func(e);
                    break;
                case 3:
                    Tab3Func(e);
                    break;
                case 4:
                    Tab4Func(e);
                    break;
                default:
                    break;
            }
        }

        private void Tab4Func(DataGridViewCellEventArgs e){
            
            if (e.RowIndex >= 0)
            {
                button15.Enabled = true;
                button14.Enabled = true;
                button2.Enabled = true;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ıd = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                personeltc.Text = row.Cells["tc"].Value.ToString();
                personelad.Text = row.Cells["ad"].Value.ToString();
                personelsoyad.Text = row.Cells["soyad"].Value.ToString();
                personeltelefon.Text = row.Cells["telefon"].Value.ToString();
                personeladres.Text = row.Cells["adres"].Value.ToString();
                personelposta.Text = row.Cells["eposta"].Value.ToString();
                personelgörevi.Text = row.Cells["gorevi"].Value.ToString();
            }
        }
        private void Tab3Func(DataGridViewCellEventArgs e){
            
            if (e.RowIndex >= 0)
            {
                button15.Enabled = true;
                button14.Enabled = true;
                button2.Enabled = true;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ıd = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                tcnottxt.Text = row.Cells["tc"].Value.ToString();
                sinavtarihidateTimePicker.Text = row.Cells["sinavtarihi"].Value.ToString();
                trafiksinavinotu_txt.Text = row.Cells["trafiksinavnotu"].Value.ToString();
                motorsinavinotu_txt.Text = row.Cells["motorsinavinotu"].Value.ToString();
                ilkyardimsinavinotu_txt.Text = row.Cells["ilkyardimsinavinotu"].Value.ToString();
            }
        }
        private void Tab2Func(DataGridViewCellEventArgs e){
            
            if (e.RowIndex >= 0)
            {
                kayitgüncelleödemebtn.Enabled = true;
                yenikayitödemebtn.Enabled = true;
                silödemebtn.Enabled = true;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ıd = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                tcödemetxt.Text = row.Cells["tc"].Value.ToString();
                tarihödemedatepicker.Text = row.Cells["odemetarihi"].Value.ToString();
                toplamborcödemetxt.Text = row.Cells["toplamborc"].Value.ToString();
                odemetutariödemetxt.Text = row.Cells["odemetutari"].Value.ToString();


                bool odemesekli = stringCompareToBoolForPaymentType(row.Cells["odemesekli"].Value.ToString());
                bool cekimtipi = stringCompareToBoolForType(row.Cells["cekimtipi"].Value.ToString());

                taksitsayisicmbox.Text = row.Cells["taksitsayisi"].Value.ToString();

                //nakit true
                //kredi kartı false

                if (odemesekli)
                {
                    nakitodemeradio.Checked = true;
                    kredikartiodemeradio.Checked = false;
                    label42.Visible = false;
                    groupBox5.Visible = false;
                    label43.Visible = false;
                    taksitsayisicmbox.Visible = false;
                }
                else
                {
                  
                    nakitodemeradio.Checked = false;
                    kredikartiodemeradio.Checked = true;

                    label42.Visible = true;
                    groupBox5.Visible = true;
                    if (cekimtipi)
                    {
                        taksitodemeradio.Checked = false;
                        tekcekimodemeradio.Checked = true;
                        label43.Visible = false;
                        taksitsayisicmbox.Visible = false;
                    }
                    else
                    {
                        taksitodemeradio.Checked = true;
                        tekcekimodemeradio.Checked = false;
                        label43.Visible = true;
                        taksitsayisicmbox.Visible = true;
                    }
                }

                // tek çekim true
                //taksit false

             


            }
        }
         
        private void Tab0Func(DataGridViewCellEventArgs e){
            
            if (e.RowIndex >= 0)
            {
                buttonkaydet.Enabled = true;
                buttonyenikayit.Enabled = true;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ıd = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                tctxt.Text = row.Cells["tc"].Value.ToString();
                adtxt.Text = row.Cells["ad"].Value.ToString();
                soyadtxt.Text = row.Cells["soyad"].Value.ToString();
                yastxt.Text = row.Cells["yas"].Value.ToString();
                cmbboxögrenimdurumu.Text = row.Cells["ogrenimdurumu"].Value.ToString();
                telefontxt.Text = row.Cells["telefon"].Value.ToString();
                KayitTarihidateTimePicker.Text = row.Cells["kayittarihi"].Value.ToString();
                SinifAdicomboBox.Text = row.Cells["sinifadi"].Value.ToString();
                EhliyetSinificomboBox.Text = row.Cells["ehliyetsinifi"].Value.ToString();
                bool adli = stringCompareToBool(row.Cells["adlibelge"].Value.ToString());
                if (adli)
                {
                    YokadliRadioButton.Checked = false;
                    VaradliRadioButton.Checked = true;
                    adlıkayıt = "Var";
                }
                else
                {
                    YokadliRadioButton.Checked = true;
                    VaradliRadioButton.Checked = false;
                    adlıkayıt = "Yok";
                }

                bool saglık = stringCompareToBool(row.Cells["saglikdurumu"].Value.ToString());
                if (saglık)
                {
                    saglıkbelgesı = "Var";
                    YoksaglikRadioButton.Checked = false;
                    VarsaglikRadioButton.Checked = true;
                }
                else
                {
                    saglıkbelgesı = "Yok";
                    YoksaglikRadioButton.Checked = true;
                    VarsaglikRadioButton.Checked = false;
                }


            }
        }

        public bool stringCompareToBoolForPaymentType(String data)
        {
            switch (data.ToLower())
            {
                case "nakit":
                    return true;
                case "kredi kartı":
                    return false;
                default:
                    return false;
            }
        }

        public bool stringCompareToBoolForType(String data)
        {
            switch (data.ToLower())
            {
                case "tek çekim":
                    return true;
                case "taksit":
                    return false;
                default:
                    return false;
            }
        }

        public bool stringCompareToBool(String data)
        {
            switch (data.ToLower())
            {
                case "var":
                    return true;
                case "yok":
                    return false;
                default:
                    return false;
            }
        }

        private void YoksaglikRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (YoksaglikRadioButton.Checked)
            {
                saglıkbelgesı = "Yok";
            }
        }

        private void VarsaglikRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (VarsaglikRadioButton.Checked)
            {
                saglıkbelgesı = "Var";
            }
        }

        private void VaradliRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (VaradliRadioButton.Checked)
            {
                adlıkayıt = "Var";
            }
        }

        private void YokadliRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (YokadliRadioButton.Checked)
            {
                adlıkayıt = "Yok";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Eski Kimlik Kartı")
            {
                kimlikTipi = false;
                eskikimlikgrbbox.Visible = true;
                yenikimlikgrbbox.Visible = false;
            }
            else
            {
                kimlikTipi = true;
                eskikimlikgrbbox.Visible = false;
                yenikimlikgrbbox.Visible = true;
            }
        }

      

        ogrencinot_bilgisi o = new ogrencinot_bilgisi();

        private void button15_Click(object sender, EventArgs e)
        {
             foreach (Control item in grupnotgirisi.Controls){
                if (item is TextBox) {
                    if(item.Text.Trim() == "") {
                        MessageBox.Show("Boş Alan Bırakmayın!");
                        return;
                    }
                }
            };
            if(ıd == 0){
                o.notbilgisi(tcnottxt,sinavtarihidateTimePicker, trafiksinavinotu_txt, motorsinavinotu_txt, ilkyardimsinavinotu_txt,grupnotgirisi);
                loadNotes();
            }else {
                updateNote();
            }
        }

        private void updateNote(){

            SqlConnection baglanti;
            SqlCommand komut;

            baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            baglanti.Open();
            komut = new SqlCommand("update ogrencinot_bilgisi set tc='" + tcnottxt.Text + "', sinavtarihi='" +sinavtarihidateTimePicker.Value.ToString("yyyy-MM-dd") + "', trafiksinavnotu='" + trafiksinavinotu_txt.Text + "', motorsinavinotu='" + motorsinavinotu_txt.Text + "', ilkyardimsinavinotu='" + ilkyardimsinavinotu_txt.Text+ "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");
            ıd = 0;

            foreach (Control item in grupnotgirisi.Controls) if (item is TextBox) item.Text = "";
            loadNotes();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
                    ıd=0;
                    fillTable();
                    break;
                case 1:
                    foreach (Control item in eskikimlikgrbbox.Controls) if (item is TextBox) item.Text = "";
                    foreach (Control item in yenikimlikgrbbox.Controls) if (item is TextBox) item.Text = "";
                    ıd=0;
                    loadIdentify();
                    break;
                case 2:
                    foreach (Control item in groupBox7.Controls) if (item is TextBox) item.Text = "";
                    ıd=0;
                    loadPayment();
                    break;
                case 3:
                    ıd=0;
                    foreach (Control item in grupnotgirisi.Controls) if (item is TextBox) item.Text = "";
                    loadNotes();
                    break;
                case 4:
                    ıd=0;
                    foreach (Control item in personelkayitgrbbox.Controls) if (item is TextBox) item.Text = "";
                    loadPersonel();
                    break;
                default:
                    break;
            }
        }
        
        private void Tab1Func(DataGridViewCellEventArgs e){
           
            if (e.RowIndex >= 0)
            {   
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ıd = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                
                if(!kimlikTipi){
                    if(row.Cells["serino"].Value.ToString().Trim()!=""){
                        MessageBox.Show("Yeni Kimlik Seçmelisiniz");
                        return;
                    }
                    yenikayitbtn.Enabled = true;
                    kaydetbtn.Enabled = true;
                    silbtn.Enabled = true;
                    textBox6.Text = row.Cells["tc"].Value.ToString();
                    textBox7.Text = row.Cells["ad"].Value.ToString();
                    textBox8.Text = row.Cells["soyad"].Value.ToString();
                    textBox9.Text = row.Cells["babaadi"].Value.ToString();
                    textBox10.Text = row.Cells["anneadi"].Value.ToString();
                    textBox11.Text = row.Cells["dogumyeri"].Value.ToString();
                    dateTimePicker2.Text = row.Cells["dogumtarihi"].Value.ToString();
                    comboBox2.Text = row.Cells["medenihali"].Value.ToString();
                    comboBox5.Text = row.Cells["dini"].Value.ToString();
                    comboBox3.Text = row.Cells["kangrubu"].Value.ToString();
                    textBox14.Text = row.Cells["il"].Value.ToString();
                    textBox15.Text = row.Cells["ilçe"].Value.ToString();
                    textBox16.Text = row.Cells["mahalle_köy"].Value.ToString();
                    textBox17.Text = row.Cells["ciltno"].Value.ToString();
                    textBox18.Text = row.Cells["ailesirano"].Value.ToString();
                    textBox19.Text = row.Cells["sirano"].Value.ToString();
                    textBox20.Text = row.Cells["verildigiyer"].Value.ToString();
                    comboBox6.Text = row.Cells["verilisnedeni"].Value.ToString();
                    textBox21.Text = row.Cells["kayitno"].Value.ToString();
                    dateTimePicker3.Text = row.Cells["verilistarihi"].Value.ToString();
                }else{
                     if(row.Cells["serino"].Value.ToString().Trim()==""){
                        MessageBox.Show("Eski Kimlik Seçmelisiniz");
                        return;
                    }
                    yenikayitbtn.Enabled = true;
                    kaydetbtn.Enabled = true;
                    silbtn.Enabled = true;
                    textBox1.Text = row.Cells["tc"].Value.ToString();
                    textBox2.Text = row.Cells["ad"].Value.ToString();
                    textBox3.Text = row.Cells["soyad"].Value.ToString();
                    textBox43.Text = row.Cells["babaadi"].Value.ToString();
                    textBox42.Text = row.Cells["anneadi"].Value.ToString();
                    textBox5.Text = row.Cells["serino"].Value.ToString();
                    dateTimePicker5.Text = row.Cells["songecerliliktarihi"].Value.ToString();
                    dateTimePicker1.Text = row.Cells["dogumtarihi"].Value.ToString();
                }
            }
        }

           private void loadIdentify()
        {
            SqlConnection con;
            SqlDataAdapter da;
            DataSet ds;


            con = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            da = new SqlDataAdapter("Select * From kimlik_bilgileri", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "kimlik_bilgileri");
            dataGridView1.DataSource = ds.Tables["kimlik_bilgileri"];
            //  dataGridView1.Columns.Remove("ID");
            con.Close();

        }

        private void loadPersonel()
        {
            SqlConnection con;
            SqlDataAdapter da;
            DataSet ds;


            con = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            da = new SqlDataAdapter("Select * From personel_kayit", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "personel_kayit");
            dataGridView1.DataSource = ds.Tables["personel_kayit"];
            //  dataGridView1.Columns.Remove("ID");
            con.Close();

        }

        
        private void yenitcguncelle()
        {
            foreach (Control item in yenikimlikgrbbox.Controls){
                if (item is TextBox) {
                    if(item.Text.Trim() == "") {
                        MessageBox.Show("Boş Alan Bırakmayın!");
                        return;
                    }
                }
            };
            SqlConnection baglanti;
            SqlCommand komut;

            baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            baglanti.Open();
            komut = new SqlCommand("update kimlik_bilgileri set tc='" + textBox1.Text + "', ad='" + textBox2.Text + "', soyad='" + textBox3.Text + "', babaadi='" + textBox43.Text + "', anneadi='" + textBox42.Text + "', serino='" + textBox5.Text + "', songecerliliktarihi='" + dateTimePicker5.Value.ToString("yyyy-MM-dd") + "', dogumtarihi='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' where ID='" + ıd + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");
            ıd = 0;
            foreach (Control item in yenikimlikgrbbox.Controls) if (item is TextBox) item.Text = "";
            loadIdentify();
        }

         private void eskitcguncelle(){
            foreach (Control item in eskikimlikgrbbox.Controls){
                if (item is TextBox) {
                    if(item.Text.Trim() == "") {
                        MessageBox.Show("Boş Alan Bırakmayın!");
                        return;
                    }
                }
            };
            SqlConnection baglanti;
            SqlCommand komut;

            baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            baglanti.Open();
            komut = new SqlCommand("update kimlik_bilgileri set tc='" + textBox6.Text + "', ad='" + textBox7.Text + "', soyad='" + textBox8.Text + "', babaadi='" + textBox9.Text + "', anneadi='" + textBox10.Text + "', dogumyeri='" + textBox11.Text + "', dogumtarihi='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', medenihali='" + comboBox2.Text + "', dini='" + comboBox5.Text + "', kangrubu='" + comboBox3.Text + "', il='" + textBox14.Text + "', ilçe='" + textBox15.Text + "', mahalle_köy='" + textBox16.Text + "', ciltno='" + textBox17.Text + "', ailesirano='" + textBox18.Text + "', sirano='" + textBox19.Text + "', verildigiyer='" + textBox20.Text + "', verilisnedeni='" + comboBox6.Text + "', kayitno='" + textBox21.Text + "', verilistarihi='" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "' where ID='" + ıd + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");
            ıd = 0;
            foreach (Control item in eskikimlikgrbbox.Controls) if (item is TextBox) item.Text = "";
            loadIdentify();
        }

        private void yenitckaydet()
        {
            foreach (Control item in yenikimlikgrbbox.Controls){
                if (item is TextBox) {
                    if(item.Text.Trim() == "") {
                        MessageBox.Show("Boş Alan Bırakmayın!");
                        return;
                    }
                }
            };

            try{
                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
                SqlCommand komut;
                SqlCommand komutReader;
                SqlCommand komutReaderKimlik;
                SqlDataReader read;

                baglanti.Open();
                komutReader = new SqlCommand();

                komutReader.Connection = baglanti;

                komutReader.CommandText= "select * from ogrenci_kayit where tc='" + textBox1.Text + "'";
                read = komutReader.ExecuteReader();

                if (read.Read() == true)
                {
                    baglanti.Close();
                    baglanti.Open();
                    komutReaderKimlik = new SqlCommand();

                    komutReaderKimlik.Connection = baglanti;

                    komutReaderKimlik.CommandText= "select * from kimlik_bilgileri where tc='" + textBox1.Text + "'";
                    read = komutReaderKimlik.ExecuteReader();

                    if (read.Read() == false)
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut = new SqlCommand();
                        komut.Connection = baglanti;
                        komut.CommandText = "insert into kimlik_bilgileri values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox43.Text + "', '" + textBox42.Text + "', '" + textBox5.Text + "', '" + dateTimePicker5.Value.ToString("yyyy-MM-dd") + "', '', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '', '', '', '', '', '', '', '', '', '', '', '', '')";
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Bilgiler Eklendi ");
                        loadIdentify();
                        foreach (Control item in yenikimlikgrbbox.Controls) if (item is TextBox) item.Text = "";
                        }
                    else
                    {
                        MessageBox.Show("Kimlik Kaydı Mevcut");
                    }
                }
                else
                {
                    MessageBox.Show("Öğrenci Kaydı Mevcut Değil");
                }
            }catch(Exception e){
                MessageBox.Show("Kimlik Kaydı Eklenemedi Bir Hata Oluştu "+ e.Message.ToString());
            }
        }

        private void eskitckaydet(){
              foreach (Control item in eskikimlikgrbbox.Controls){
                if (item is TextBox) {
                    if(item.Text.Trim() == "") {
                        MessageBox.Show("Boş Alan Bırakmayın!");
                        return;
                    }
                }
            };
            try{
                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
                SqlCommand komut;
                SqlCommand komutReader;
                SqlCommand komutReaderKimlik;
                SqlDataReader read;

                baglanti.Open();
                komutReader = new SqlCommand();

                komutReader.Connection = baglanti;

                komutReader.CommandText= "select * from ogrenci_kayit where tc='" + textBox6.Text + "'";
                read = komutReader.ExecuteReader();

                if (read.Read() == true)
                {
                    baglanti.Close();
                    baglanti.Open();
                    komutReaderKimlik = new SqlCommand();

                    komutReaderKimlik.Connection = baglanti;

                    komutReaderKimlik.CommandText= "select * from kimlik_bilgileri where tc='" + textBox6.Text + "'";
                    read = komutReaderKimlik.ExecuteReader();

                    if (read.Read() == false)
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut = new SqlCommand();
                        komut.Connection = baglanti;
                        komut.CommandText = "insert into kimlik_bilgileri values('" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '', '', '" + textBox11.Text + "', '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', '" + comboBox2.Text + "', '" + comboBox5.Text + "', '" + comboBox3.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "', '" + textBox18.Text + "', '" + textBox19.Text + "', '" + textBox20.Text + "', '" + comboBox6.Text + "', '" + textBox21.Text + "', '" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "')";
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Bilgiler Eklendi ");
                        loadIdentify();
                        foreach (Control item in eskikimlikgrbbox.Controls) if (item is TextBox) item.Text = "";
                    }else{
                        MessageBox.Show("Kimlik Kaydı Mevcut ");
                    }
                }else{
                    MessageBox.Show("Öğrenci Kaydı Mevcut Değil");
                }
            }catch(Exception e){
                MessageBox.Show("Kimlik Kaydı Eklenemedi Bir Hata Oluştu "+ e.Message.ToString());
            }
        }

        private void yenikayitbtn_Click(object sender, EventArgs e)
        {
            ıd=0;
            if(!kimlikTipi){
                foreach (Control item in eskikimlikgrbbox.Controls) if (item is TextBox) item.Text = "";
            }else{
                foreach (Control item in yenikimlikgrbbox.Controls) if (item is TextBox) item.Text = "";
            }
            yenikayitbtn.Enabled=false;
        }

        private void silbtn_Click(object sender, EventArgs e)
        {  
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            SqlCommand komut;
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "delete from kimlik_bilgileri where ID='" + ıd + "' ";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi başarılı!");
            loadIdentify();
        }

        private void loadNotes()
        {
            SqlConnection con;
            SqlDataAdapter da;
            DataSet ds;


            con = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            da = new SqlDataAdapter("Select * From ogrencinot_bilgisi", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ogrencinot_bilgisi");
            dataGridView1.DataSource = ds.Tables["ogrencinot_bilgisi"];
            //  dataGridView1.Columns.Remove("ID");
            con.Close();

        }

        private void loadPayment()
        {
            SqlConnection con;
            SqlDataAdapter da;
            DataSet ds;


            con = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            da = new SqlDataAdapter("Select * From odeme_bilgisi", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "odeme_bilgisi");
            dataGridView1.DataSource = ds.Tables["odeme_bilgisi"];
            //  dataGridView1.Columns.Remove("ID");
            con.Close();

        }

      

        private void fillTable()
        {
            SqlConnection con;
            SqlDataAdapter da;
            DataSet ds;


            con = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            da = new SqlDataAdapter("Select * From ogrenci_kayit", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ogrenci_kayit");
            dataGridView1.DataSource = ds.Tables["ogrenci_kayit"];
            //  dataGridView1.Columns.Remove("ID");

            con.Close();

        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kaydetbtn_Click(object sender, EventArgs e)
        {
            silbtn.Enabled = false;
            if(ıd==0){

                if(kimlikTipi){
                    yenitckaydet();
                }else{
                    eskitckaydet();
                }
            }else{
                //Güncelleme Yapılacak
                if(kimlikTipi){
                    yenitcguncelle();
                }else{
                    eskitcguncelle();
                }
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            SqlCommand komut;
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "delete from ogrenci_kayit where ID='" + ıd + "' ";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi başarılı!");
            fillTable();
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            //Changed
            //radioButton9 tc 10 isim
            SqlConnection con;
            con = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
         //   String query;
            if(textBox36.Text.Trim()!=""){
               
                
                if(radioButton9.Checked == true){
                    SqlDataAdapter da;
                    DataSet ds;
                    da = new SqlDataAdapter("Select * From ogrenci_kayit Where tc Like '"+textBox36.Text+"%' ", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "ogrenci_kayit");
                    dataGridView1.DataSource = ds.Tables["ogrenci_kayit"];
                    con.Close();
                } 
                else if(radioButton10.Checked == true){
                    SqlDataAdapter da;
                    DataSet ds;
                    da = new SqlDataAdapter("Select * From ogrenci_kayit Where ad Like '"+textBox36.Text+"%' ", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "ogrenci_kayit");
                    dataGridView1.DataSource = ds.Tables["ogrenci_kayit"];
                    con.Close();
                }
                
               
            }
        }

        private void btnkücült_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void telefontxt_Click(object sender, EventArgs e)
        {
            telefontxt.Text = "";
        }

        personel_kayit p = new personel_kayit();
        private void button17_Click(object sender, EventArgs e)
        {   
            if(ıd==0){
                bool res = p.personelkayit(personeltc, personelad, personelsoyad, personeltelefon, personeladres, personelposta, personelgörevi, personelkayitgrbbox);
            }else{
                updatePersonel();
            }
            loadPersonel();

        }

        private void updatePersonel() {
            foreach (Control item in personelkayitgrbbox.Controls){
                if (item is TextBox) {
                    if(item.Text.Trim() == "") {
                        MessageBox.Show("Boş Alan Bırakmayın!");
                        return;
                    }
                }
            };
           

            SqlConnection baglanti;
            SqlCommand komut;

            baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            baglanti.Open();
            komut = new SqlCommand("update personel_kayit set tc='" + personeltc.Text + "', ad='" + personelad.Text + "', soyad='" + personelsoyad.Text + "', telefon='" + personeltelefon.Text + "', adres='" + personeladres.Text + "', eposta='" + personelposta.Text + "',gorevi='" + personelgörevi.Text + "' where ID='" + ıd + "'  ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");
            ıd = 0;

            foreach (Control item in personelkayitgrbbox.Controls) if (item is TextBox) item.Text = "";
            loadPersonel();
        }

        private void kayitgüncelleödemebtn_Click(object sender, EventArgs e)
        {

            if(ıd==0){
                newPayment();
            }else{
               //Güncelleme
               updatePayment();
            }
         
        }

        private void updatePayment() {
            foreach (Control item in groupBox7.Controls){
                if (item is TextBox) {
                    if(item.Text.Trim() == "") {
                        MessageBox.Show("Boş Alan Bırakmayın!");
                        return;
                    }
                }
            };
             String odemesekli2="Nakit";
            String cekimtipi2="Tek Çekim";
            String taksit2="";
            if(nakitodemeradio.Checked){
                odemesekli2 = "Nakit";
                cekimtipi2 = "";
                taksit2 = "";
            }else if(kredikartiodemeradio.Checked){
                odemesekli2 = "Kredi Kartı";
                taksit2 = "";
                cekimtipi2 = "Tek Çekim";
                if(tekcekimodemeradio.Checked){
                    cekimtipi2 = "Tek Çekim";
                }else if(taksitodemeradio.Checked){
                    cekimtipi2 = "Taksit";
                    taksit2 = taksitsayisicmbox.Text;
                }
            }

 
            SqlConnection baglanti;
            SqlCommand komut;

            baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            baglanti.Open();
            komut = new SqlCommand("update odeme_bilgisi set tc='" + tcödemetxt.Text + "', odemetarihi='" +tarihödemedatepicker.Value.ToString("yyyy-MM-dd") + "', toplamborc='" + toplamborcödemetxt.Text + "', odemetutari='" + odemetutariödemetxt.Text + "', odemesekli='" + odemesekli2.ToString()+ "', cekimtipi='" + cekimtipi2.ToString() + "', taksitsayisi='" + taksitsayisicmbox.Text + "' where ID='" + ıd + "'  ", baglanti);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");
            ıd = 0;

            foreach (Control item in groupBox7.Controls) if (item is TextBox) item.Text = "";
            loadPayment();
            tekcekimodemeradio.Checked = false;
            taksitodemeradio.Checked = false;
            nakitodemeradio.Checked = false;
            kredikartiodemeradio.Checked = false;
        }
        private void newPayment () {
              foreach (Control item in groupBox7.Controls){
                if (item is TextBox) {
                    if(item.Text.Trim() == "") {
                        MessageBox.Show("Boş Alan Bırakmayın!");
                        return;
                    }
                }
            };
            String odemesekli2="Nakit";
            String cekimtipi2="Tek Çekim";
            String taksit2="";
            if(nakitodemeradio.Checked){
                odemesekli2 = "Nakit";
                cekimtipi2 = "";
                taksit2 = "";
            }else if(kredikartiodemeradio.Checked){
                odemesekli2 = "Kredi Kartı";
                taksit2 = "";
                cekimtipi2 = "Tek Çekim";
                if(tekcekimodemeradio.Checked){
                    cekimtipi2 = "Tek Çekim";
                }else if(taksitodemeradio.Checked){
                    cekimtipi2 = "Taksit";
                    taksit2 = taksitsayisicmbox.Text;
                }
            }
            bool sonuc = ob.yeniOdeme(tcödemetxt, tarihödemedatepicker, toplamborcödemetxt, odemetutariödemetxt, odemesekli2, cekimtipi2, taksit2, groupBox7);
            loadPayment();
            tekcekimodemeradio.Checked = false;
            taksitodemeradio.Checked = false;
            nakitodemeradio.Checked = false;
            kredikartiodemeradio.Checked = false;
            foreach (Control item in groupBox7.Controls) if (item is TextBox) item.Text = "";
        }

        private void yenikayitödemebtn_Click(object sender, EventArgs e)
        {
            ıd=0;
            
            foreach (Control item in groupBox7.Controls) if (item is TextBox) item.Text = "";

            tekcekimodemeradio.Checked = false;
            taksitodemeradio.Checked = false;
            nakitodemeradio.Checked = false;
            kredikartiodemeradio.Checked = false;

            yenikayitödemebtn.Enabled=false;
            silödemebtn.Enabled = false;
        }

        private void kredikartiodemeradio_CheckedChanged(object sender, EventArgs e)
        {
            if(!kredikartiodemeradio.Checked){
                label42.Visible = false;
                groupBox5.Visible = false;
                label43.Visible = false;
                taksitsayisicmbox.Visible = false;
            }else{
                label42.Visible = true;
                groupBox5.Visible = true;
                if(!taksitodemeradio.Checked){
                    label43.Visible = false;
                    taksitsayisicmbox.Visible = false;
                }else{
                    label43.Visible = true;
                    taksitsayisicmbox.Visible = true;
                }
            }
        }


        private void taksitodemeradio_CheckedChanged(object sender, EventArgs e)
        {
            if(!taksitodemeradio.Checked){
                label43.Visible = false;
                taksitsayisicmbox.Visible = false;
            }else{
                label43.Visible = true;
                taksitsayisicmbox.Visible = true;
            }
        }

        private void silödemebtn_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            SqlCommand komut;
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "delete from odeme_bilgisi where ID='" + ıd + "' ";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi başarılı!");
            loadPayment();
            foreach (Control item in groupBox7.Controls) if (item is TextBox) item.Text = "";
            ıd=0;

            tekcekimodemeradio.Checked = false;
            taksitodemeradio.Checked = false;
            nakitodemeradio.Checked = false;
            kredikartiodemeradio.Checked = false;

            yenikayitödemebtn.Enabled = false;
            silödemebtn.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            SqlCommand komut;
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "delete from ogrencinot_bilgisi where ID='" + ıd + "' ";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi başarılı!");
            loadNotes();
            foreach (Control item in groupBox7.Controls) if (item is TextBox) item.Text = "";
            ıd=0;


            button14.Enabled = false;
            button15.Enabled = true;
            button2.Enabled = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            foreach (Control item in grupnotgirisi.Controls) if (item is TextBox) item.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J2EUUU4;Initial Catalog=sürücü_kursu;Integrated Security=True");
            SqlCommand komut;
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "delete from personel_kayit where ID='" + ıd + "' ";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi başarılı!");
            loadPersonel();
            foreach (Control item in personelkayitgrbbox.Controls) if (item is TextBox) item.Text = "";
            ıd=0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ıd = 0;
            foreach (Control item in personelkayitgrbbox.Controls) if (item is TextBox) item.Text = "";
        }

      

        private void buttonyenikayit_Click(object sender, EventArgs e)
        {
            
            ıd = 0;
            saglıkbelgesı = "Yok";
            adlıkayıt = "Yok";
            VaradliRadioButton.Checked = false;
            YokadliRadioButton.Checked = false;
            VarsaglikRadioButton.Checked = false;
            YoksaglikRadioButton.Checked = false;
            foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
        }




        //  kısıtlamalar


        private void sadeceharf(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void sadecesayi(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ayarlar.passwordUpdate(kullanici_ayar, mevcutsifre_ayar, yenisifre_ayar, yenisifretkr_ayar);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        




    }
}

//Tap 5