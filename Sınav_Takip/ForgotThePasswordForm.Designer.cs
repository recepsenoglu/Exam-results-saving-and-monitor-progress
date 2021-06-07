
namespace Sınav_Takip
{
    partial class ForgotThePasswordForm
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
            this.txtK_Adi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendMyPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtK_Adi
            // 
            this.txtK_Adi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtK_Adi.Location = new System.Drawing.Point(24, 48);
            this.txtK_Adi.Name = "txtK_Adi";
            this.txtK_Adi.Size = new System.Drawing.Size(149, 30);
            this.txtK_Adi.TabIndex = 0;
            this.txtK_Adi.TextChanged += new System.EventHandler(this.txtK_Adi_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı adınızı girin";
            // 
            // btnSendMyPassword
            // 
            this.btnSendMyPassword.BackColor = System.Drawing.Color.White;
            this.btnSendMyPassword.Enabled = false;
            this.btnSendMyPassword.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSendMyPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMyPassword.Location = new System.Drawing.Point(204, 46);
            this.btnSendMyPassword.Name = "btnSendMyPassword";
            this.btnSendMyPassword.Size = new System.Drawing.Size(146, 34);
            this.btnSendMyPassword.TabIndex = 2;
            this.btnSendMyPassword.Text = "Şifremi Gönder";
            this.btnSendMyPassword.UseVisualStyleBackColor = false;
            this.btnSendMyPassword.Click += new System.EventHandler(this.btnSendMyPassword_Click);
            // 
            // ForgotThePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(370, 101);
            this.Controls.Add(this.btnSendMyPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtK_Adi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ForgotThePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifremi unuttum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendMyPassword;
        public System.Windows.Forms.TextBox txtK_Adi;
    }
}