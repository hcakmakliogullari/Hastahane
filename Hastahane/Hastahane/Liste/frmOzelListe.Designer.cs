namespace Hastahane.Liste
{
    partial class frmOzelListe
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
            this.Liste = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.cbPat = new System.Windows.Forms.ComboBox();
            this.cbPks = new System.Windows.Forms.ComboBox();
            this.txtTmrMax = new System.Windows.Forms.TextBox();
            this.txtKanMax = new System.Windows.Forms.TextBox();
            this.txtTmrMin = new System.Windows.Forms.TextBox();
            this.txtKanMin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Liste
            // 
            this.Liste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Liste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liste.Location = new System.Drawing.Point(0, 0);
            this.Liste.Name = "Liste";
            this.Liste.Size = new System.Drawing.Size(619, 385);
            this.Liste.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "HastaID";
            this.Column1.Name = "Column1";
            this.Column1.Width = 71;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "ProtNo";
            this.Column2.Name = "Column2";
            this.Column2.Width = 65;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Adı";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Soyadı";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.HeaderText = "Operasyon Tarihi";
            this.Column5.Name = "Column5";
            this.Column5.Width = 103;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Liste);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnFiltrele);
            this.splitContainer1.Panel2.Controls.Add(this.cbPat);
            this.splitContainer1.Panel2.Controls.Add(this.cbPks);
            this.splitContainer1.Panel2.Controls.Add(this.txtTmrMax);
            this.splitContainer1.Panel2.Controls.Add(this.txtKanMax);
            this.splitContainer1.Panel2.Controls.Add(this.txtTmrMin);
            this.splitContainer1.Panel2.Controls.Add(this.txtKanMin);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(791, 385);
            this.splitContainer1.SplitterDistance = 619;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFiltrele.Location = new System.Drawing.Point(0, 345);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(168, 40);
            this.btnFiltrele.TabIndex = 7;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = true;
            this.btnFiltrele.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbPat
            // 
            this.cbPat.FormattingEnabled = true;
            this.cbPat.Location = new System.Drawing.Point(9, 221);
            this.cbPat.Name = "cbPat";
            this.cbPat.Size = new System.Drawing.Size(147, 21);
            this.cbPat.TabIndex = 6;
            // 
            // cbPks
            // 
            this.cbPks.FormattingEnabled = true;
            this.cbPks.Items.AddRange(new object[] {
            "Evet",
            "Hayır"});
            this.cbPks.Location = new System.Drawing.Point(9, 262);
            this.cbPks.Name = "cbPks";
            this.cbPks.Size = new System.Drawing.Size(147, 21);
            this.cbPks.TabIndex = 5;
            // 
            // txtTmrMax
            // 
            this.txtTmrMax.Location = new System.Drawing.Point(60, 87);
            this.txtTmrMax.Name = "txtTmrMax";
            this.txtTmrMax.Size = new System.Drawing.Size(49, 20);
            this.txtTmrMax.TabIndex = 4;
            // 
            // txtKanMax
            // 
            this.txtKanMax.Location = new System.Drawing.Point(60, 155);
            this.txtKanMax.Name = "txtKanMax";
            this.txtKanMax.Size = new System.Drawing.Size(49, 20);
            this.txtKanMax.TabIndex = 4;
//            this.txtKanMax.TextChanged += new System.EventHandler(this.txtKanMax_TextChanged);
            // 
            // txtTmrMin
            // 
            this.txtTmrMin.Location = new System.Drawing.Point(5, 86);
            this.txtTmrMin.Name = "txtTmrMin";
            this.txtTmrMin.Size = new System.Drawing.Size(49, 20);
            this.txtTmrMin.TabIndex = 4;
//            this.txtTmrMin.TextChanged += new System.EventHandler(this.txtTmrMin_TextChanged);
            // 
            // txtKanMin
            // 
            this.txtKanMin.Location = new System.Drawing.Point(6, 155);
            this.txtKanMin.Name = "txtKanMin";
            this.txtKanMin.Size = new System.Drawing.Size(49, 20);
            this.txtKanMin.TabIndex = 4;
//            this.txtKanMin.TextChanged += new System.EventHandler(this.txtKanMin_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(52, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(53, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "-";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "PKS";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Patoloji";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tümör Boyutu";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kanama Miktarı";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "KAPAT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOzelListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 385);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmOzelListe";
            this.Text = "frmOzelListe";
            this.Load += new System.EventHandler(this.frmOzelListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Liste;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.ComboBox cbPat;
        private System.Windows.Forms.ComboBox cbPks;
        private System.Windows.Forms.TextBox txtTmrMax;
        private System.Windows.Forms.TextBox txtKanMax;
        private System.Windows.Forms.TextBox txtTmrMin;
        private System.Windows.Forms.TextBox txtKanMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}