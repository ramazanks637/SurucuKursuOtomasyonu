namespace benimsurucukursu
{
    partial class frmŞifre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.sorucmbox = new System.Windows.Forms.ComboBox();
            this.btnsifre = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sifretkrtxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sifretxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.kullanıcıaditxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cevaptxt = new System.Windows.Forms.TextBox();
            this.soyadtxt = new System.Windows.Forms.TextBox();
            this.adtxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 4;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(139, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Kapat";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sorucmbox
            // 
            this.sorucmbox.FormattingEnabled = true;
            this.sorucmbox.Items.AddRange(new object[] {
            "En Sevdiğiniz Renk ?",
            "En Sevdiğiniz Hayvan ?",
            "İlk Evcil Hayvanınız ?"});
            this.sorucmbox.Location = new System.Drawing.Point(126, 86);
            this.sorucmbox.Name = "sorucmbox";
            this.sorucmbox.Size = new System.Drawing.Size(200, 24);
            this.sorucmbox.TabIndex = 4;
            // 
            // btnsifre
            // 
            this.btnsifre.BackColor = System.Drawing.Color.Yellow;
            this.btnsifre.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnsifre.FlatAppearance.BorderSize = 4;
            this.btnsifre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsifre.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnsifre.ForeColor = System.Drawing.Color.Black;
            this.btnsifre.Location = new System.Drawing.Point(139, 298);
            this.btnsifre.Name = "btnsifre";
            this.btnsifre.Size = new System.Drawing.Size(158, 36);
            this.btnsifre.TabIndex = 3;
            this.btnsifre.Text = "Güncelle";
            this.btnsifre.UseVisualStyleBackColor = false;
            this.btnsifre.Click += new System.EventHandler(this.btnsifre_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(76, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Soru";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(90, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(64, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cevap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(64, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Soyad";
            // 
            // sifretkrtxt
            // 
            this.sifretkrtxt.Location = new System.Drawing.Point(126, 248);
            this.sifretkrtxt.Name = "sifretkrtxt";
            this.sifretkrtxt.PasswordChar = '•';
            this.sifretkrtxt.Size = new System.Drawing.Size(200, 22);
            this.sifretkrtxt.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(19, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kullanıcı Adı";
            // 
            // sifretxt
            // 
            this.sifretxt.Location = new System.Drawing.Point(126, 216);
            this.sifretxt.Name = "sifretxt";
            this.sifretxt.PasswordChar = '•';
            this.sifretxt.Size = new System.Drawing.Size(200, 22);
            this.sifretxt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(77, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Şifre";
            // 
            // kullanıcıaditxt
            // 
            this.kullanıcıaditxt.Location = new System.Drawing.Point(126, 54);
            this.kullanıcıaditxt.Name = "kullanıcıaditxt";
            this.kullanıcıaditxt.Size = new System.Drawing.Size(200, 22);
            this.kullanıcıaditxt.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(25, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Şifre Tekrar";
            // 
            // cevaptxt
            // 
            this.cevaptxt.Location = new System.Drawing.Point(126, 120);
            this.cevaptxt.Name = "cevaptxt";
            this.cevaptxt.Size = new System.Drawing.Size(200, 22);
            this.cevaptxt.TabIndex = 2;
            // 
            // soyadtxt
            // 
            this.soyadtxt.Location = new System.Drawing.Point(126, 184);
            this.soyadtxt.Name = "soyadtxt";
            this.soyadtxt.Size = new System.Drawing.Size(200, 22);
            this.soyadtxt.TabIndex = 2;
            // 
            // adtxt
            // 
            this.adtxt.Location = new System.Drawing.Point(126, 152);
            this.adtxt.Name = "adtxt";
            this.adtxt.Size = new System.Drawing.Size(200, 22);
            this.adtxt.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.sorucmbox);
            this.groupBox1.Controls.Add(this.sifretxt);
            this.groupBox1.Controls.Add(this.btnsifre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.sifretkrtxt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.kullanıcıaditxt);
            this.groupBox1.Controls.Add(this.adtxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.soyadtxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cevaptxt);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 476);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Şifremi Unuttum";
            // 
            // frmŞifre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmŞifre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmŞifre";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sifretkrtxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sifretxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox kullanıcıaditxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox soyadtxt;
        private System.Windows.Forms.TextBox adtxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cevaptxt;
        private System.Windows.Forms.ComboBox sorucmbox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}