
namespace Sınav_Takip
{
    partial class ReviewForm
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
            this.lblK_adi = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.dtgrdviewDenemeler = new System.Windows.Forms.DataGridView();
            this.cntxmnstripSil = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuitemSil = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDenemeler = new System.Windows.Forms.Label();
            this.btnDenemeEkle = new System.Windows.Forms.Button();
            this.pctrboxAvatar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdviewDenemeler)).BeginInit();
            this.cntxmnstripSil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrboxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblK_adi
            // 
            this.lblK_adi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblK_adi.AutoSize = true;
            this.lblK_adi.BackColor = System.Drawing.Color.Transparent;
            this.lblK_adi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblK_adi.Location = new System.Drawing.Point(14, 240);
            this.lblK_adi.Name = "lblK_adi";
            this.lblK_adi.Size = new System.Drawing.Size(118, 23);
            this.lblK_adi.TabIndex = 1;
            this.lblK_adi.Text = "Kullanıcı adı";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.BackColor = System.Drawing.Color.Transparent;
            this.lblAd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAd.Location = new System.Drawing.Point(12, 174);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(46, 23);
            this.lblAd.TabIndex = 0;
            this.lblAd.Text = "İsim";
            // 
            // dtgrdviewDenemeler
            // 
            this.dtgrdviewDenemeler.AllowUserToAddRows = false;
            this.dtgrdviewDenemeler.AllowUserToResizeColumns = false;
            this.dtgrdviewDenemeler.AllowUserToResizeRows = false;
            this.dtgrdviewDenemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrdviewDenemeler.BackgroundColor = System.Drawing.Color.White;
            this.dtgrdviewDenemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdviewDenemeler.ContextMenuStrip = this.cntxmnstripSil;
            this.dtgrdviewDenemeler.Location = new System.Drawing.Point(195, 35);
            this.dtgrdviewDenemeler.Name = "dtgrdviewDenemeler";
            this.dtgrdviewDenemeler.ReadOnly = true;
            this.dtgrdviewDenemeler.RowHeadersVisible = false;
            this.dtgrdviewDenemeler.RowHeadersWidth = 51;
            this.dtgrdviewDenemeler.RowTemplate.Height = 24;
            this.dtgrdviewDenemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrdviewDenemeler.Size = new System.Drawing.Size(759, 325);
            this.dtgrdviewDenemeler.TabIndex = 1;
            this.dtgrdviewDenemeler.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dtgrdviewDenemeler_MouseDoubleClick);
            // 
            // cntxmnstripSil
            // 
            this.cntxmnstripSil.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxmnstripSil.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemSil});
            this.cntxmnstripSil.Name = "cntxmnstripSil";
            this.cntxmnstripSil.Size = new System.Drawing.Size(166, 28);
            // 
            // menuitemSil
            // 
            this.menuitemSil.Name = "menuitemSil";
            this.menuitemSil.Size = new System.Drawing.Size(165, 24);
            this.menuitemSil.Text = "Denemeyi Sil";
            this.menuitemSil.Click += new System.EventHandler(this.menuitemSil_Click);
            // 
            // lblDenemeler
            // 
            this.lblDenemeler.AutoSize = true;
            this.lblDenemeler.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDenemeler.Location = new System.Drawing.Point(191, 8);
            this.lblDenemeler.Name = "lblDenemeler";
            this.lblDenemeler.Size = new System.Drawing.Size(104, 24);
            this.lblDenemeler.TabIndex = 2;
            this.lblDenemeler.Text = "Denemeler";
            // 
            // btnDenemeEkle
            // 
            this.btnDenemeEkle.BackColor = System.Drawing.Color.White;
            this.btnDenemeEkle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDenemeEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenemeEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDenemeEkle.Location = new System.Drawing.Point(16, 278);
            this.btnDenemeEkle.Name = "btnDenemeEkle";
            this.btnDenemeEkle.Size = new System.Drawing.Size(160, 71);
            this.btnDenemeEkle.TabIndex = 3;
            this.btnDenemeEkle.Text = "Deneme Ekle";
            this.btnDenemeEkle.UseVisualStyleBackColor = false;
            this.btnDenemeEkle.Click += new System.EventHandler(this.btnDenemeEkle_Click);
            // 
            // pctrboxAvatar
            // 
            this.pctrboxAvatar.Location = new System.Drawing.Point(16, 12);
            this.pctrboxAvatar.Name = "pctrboxAvatar";
            this.pctrboxAvatar.Size = new System.Drawing.Size(133, 119);
            this.pctrboxAvatar.TabIndex = 2;
            this.pctrboxAvatar.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ad Soyad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(965, 371);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pctrboxAvatar);
            this.Controls.Add(this.lblK_adi);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.btnDenemeEkle);
            this.Controls.Add(this.lblDenemeler);
            this.Controls.Add(this.dtgrdviewDenemeler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sınav Takip - Denemeler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReviewForm_FormClosed);
            this.Load += new System.EventHandler(this.ReviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdviewDenemeler)).EndInit();
            this.cntxmnstripSil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctrboxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblK_adi;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblDenemeler;
        private System.Windows.Forms.Button btnDenemeEkle;
        public System.Windows.Forms.DataGridView dtgrdviewDenemeler;
        private System.Windows.Forms.ContextMenuStrip cntxmnstripSil;
        private System.Windows.Forms.ToolStripMenuItem menuitemSil;
        private System.Windows.Forms.PictureBox pctrboxAvatar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}