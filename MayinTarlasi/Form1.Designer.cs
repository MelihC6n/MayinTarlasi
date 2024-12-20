namespace MayinTarlasi
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lblSure = new System.Windows.Forms.Label();
            this.lblBayrak = new System.Windows.Forms.Label();
            this.btnOyna = new System.Windows.Forms.Button();
            this.grpMayinAlani = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nbrSatır = new System.Windows.Forms.NumericUpDown();
            this.nbrBomba = new System.Windows.Forms.NumericUpDown();
            this.nbrSutun = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdOzel = new System.Windows.Forms.RadioButton();
            this.rdZor = new System.Windows.Forms.RadioButton();
            this.rdOrta = new System.Windows.Forms.RadioButton();
            this.rdKolay = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSatır)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrBomba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSutun)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSure
            // 
            this.lblSure.BackColor = System.Drawing.Color.Tomato;
            this.lblSure.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSure.ForeColor = System.Drawing.Color.White;
            this.lblSure.Location = new System.Drawing.Point(1222, 25);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(98, 75);
            this.lblSure.TabIndex = 11;
            this.lblSure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBayrak
            // 
            this.lblBayrak.BackColor = System.Drawing.Color.PaleGreen;
            this.lblBayrak.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBayrak.Location = new System.Drawing.Point(1127, 25);
            this.lblBayrak.Name = "lblBayrak";
            this.lblBayrak.Size = new System.Drawing.Size(89, 75);
            this.lblBayrak.TabIndex = 12;
            this.lblBayrak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOyna
            // 
            this.btnOyna.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOyna.Location = new System.Drawing.Point(882, 24);
            this.btnOyna.Name = "btnOyna";
            this.btnOyna.Size = new System.Drawing.Size(238, 76);
            this.btnOyna.TabIndex = 10;
            this.btnOyna.Text = "Mayin Alani Üret";
            this.btnOyna.UseVisualStyleBackColor = true;
            this.btnOyna.Click += new System.EventHandler(this.btnOyna_Click);
            // 
            // grpMayinAlani
            // 
            this.grpMayinAlani.AutoSize = true;
            this.grpMayinAlani.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpMayinAlani.BackColor = System.Drawing.SystemColors.Control;
            this.grpMayinAlani.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpMayinAlani.Location = new System.Drawing.Point(12, 116);
            this.grpMayinAlani.Name = "grpMayinAlani";
            this.grpMayinAlani.Size = new System.Drawing.Size(6, 5);
            this.grpMayinAlani.TabIndex = 9;
            this.grpMayinAlani.TabStop = false;
            this.grpMayinAlani.Text = "Mayın Alanı!!!";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nbrSatır);
            this.groupBox1.Controls.Add(this.nbrBomba);
            this.groupBox1.Controls.Add(this.nbrSutun);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdOzel);
            this.groupBox1.Controls.Add(this.rdZor);
            this.groupBox1.Controls.Add(this.rdOrta);
            this.groupBox1.Controls.Add(this.rdKolay);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 98);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zorluk Seçimi";
            // 
            // nbrSatır
            // 
            this.nbrSatır.Enabled = false;
            this.nbrSatır.Location = new System.Drawing.Point(560, 52);
            this.nbrSatır.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nbrSatır.Name = "nbrSatır";
            this.nbrSatır.Size = new System.Drawing.Size(100, 27);
            this.nbrSatır.TabIndex = 0;
            // 
            // nbrBomba
            // 
            this.nbrBomba.Enabled = false;
            this.nbrBomba.Location = new System.Drawing.Point(758, 35);
            this.nbrBomba.Maximum = new decimal(new int[] {
            314,
            0,
            0,
            0});
            this.nbrBomba.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nbrBomba.Name = "nbrBomba";
            this.nbrBomba.Size = new System.Drawing.Size(100, 27);
            this.nbrBomba.TabIndex = 0;
            this.nbrBomba.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nbrSutun
            // 
            this.nbrSutun.Enabled = false;
            this.nbrSutun.Location = new System.Drawing.Point(560, 16);
            this.nbrSutun.Maximum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.nbrSutun.Name = "nbrSutun";
            this.nbrSutun.Size = new System.Drawing.Size(100, 27);
            this.nbrSutun.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(670, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bomba = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Satır = ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(482, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sütun = ";
            // 
            // rdOzel
            // 
            this.rdOzel.AutoSize = true;
            this.rdOzel.Location = new System.Drawing.Point(386, 38);
            this.rdOzel.Name = "rdOzel";
            this.rdOzel.Size = new System.Drawing.Size(75, 24);
            this.rdOzel.TabIndex = 1;
            this.rdOzel.TabStop = true;
            this.rdOzel.Text = "Özel :";
            this.rdOzel.UseVisualStyleBackColor = true;
            this.rdOzel.CheckedChanged += new System.EventHandler(this.rdOzel_CheckedChanged);
            // 
            // rdZor
            // 
            this.rdZor.AutoSize = true;
            this.rdZor.Location = new System.Drawing.Point(269, 38);
            this.rdZor.Name = "rdZor";
            this.rdZor.Size = new System.Drawing.Size(54, 24);
            this.rdZor.TabIndex = 0;
            this.rdZor.TabStop = true;
            this.rdZor.Text = "Zor";
            this.rdZor.UseVisualStyleBackColor = true;
            // 
            // rdOrta
            // 
            this.rdOrta.AutoSize = true;
            this.rdOrta.Location = new System.Drawing.Point(138, 38);
            this.rdOrta.Name = "rdOrta";
            this.rdOrta.Size = new System.Drawing.Size(63, 24);
            this.rdOrta.TabIndex = 0;
            this.rdOrta.TabStop = true;
            this.rdOrta.Text = "Orta";
            this.rdOrta.UseVisualStyleBackColor = true;
            // 
            // rdKolay
            // 
            this.rdKolay.AutoSize = true;
            this.rdKolay.Location = new System.Drawing.Point(7, 38);
            this.rdKolay.Name = "rdKolay";
            this.rdKolay.Size = new System.Drawing.Size(71, 24);
            this.rdKolay.TabIndex = 0;
            this.rdKolay.TabStop = true;
            this.rdKolay.Text = "Kolay";
            this.rdKolay.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1332, 630);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSure);
            this.Controls.Add(this.lblBayrak);
            this.Controls.Add(this.btnOyna);
            this.Controls.Add(this.grpMayinAlani);
            this.Name = "Form1";
            this.Text = "MAYIN TARLASI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSatır)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrBomba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSutun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.Label lblBayrak;
        private System.Windows.Forms.Button btnOyna;
        private System.Windows.Forms.GroupBox grpMayinAlani;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdZor;
        private System.Windows.Forms.RadioButton rdOrta;
        private System.Windows.Forms.RadioButton rdKolay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdOzel;
        private System.Windows.Forms.NumericUpDown nbrSatır;
        private System.Windows.Forms.NumericUpDown nbrBomba;
        private System.Windows.Forms.NumericUpDown nbrSutun;
    }
}

