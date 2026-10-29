namespace LittlePlanete
{
    partial class FormConnexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnexion));
            this.buttonConnexion = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelMdp = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxMdp = new System.Windows.Forms.TextBox();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxAfficherMdp = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnexion
            // 
            this.buttonConnexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnexion.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonConnexion.Location = new System.Drawing.Point(232, 200);
            this.buttonConnexion.Name = "buttonConnexion";
            this.buttonConnexion.Size = new System.Drawing.Size(183, 46);
            this.buttonConnexion.TabIndex = 0;
            this.buttonConnexion.Text = "Se Connecter";
            this.buttonConnexion.UseVisualStyleBackColor = true;
            this.buttonConnexion.Click += new System.EventHandler(this.buttonConnexion_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelLogin.Location = new System.Drawing.Point(24, 55);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(54, 20);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Login";
            // 
            // labelMdp
            // 
            this.labelMdp.AutoSize = true;
            this.labelMdp.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelMdp.Location = new System.Drawing.Point(24, 118);
            this.labelMdp.Name = "labelMdp";
            this.labelMdp.Size = new System.Drawing.Size(117, 20);
            this.labelMdp.TabIndex = 2;
            this.labelMdp.Text = "Mot de passe";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxLogin.Location = new System.Drawing.Point(232, 52);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.ShortcutsEnabled = false;
            this.textBoxLogin.Size = new System.Drawing.Size(183, 25);
            this.textBoxLogin.TabIndex = 3;
            this.textBoxLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLogin_KeyPress);
            // 
            // textBoxMdp
            // 
            this.textBoxMdp.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxMdp.Location = new System.Drawing.Point(232, 115);
            this.textBoxMdp.Name = "textBoxMdp";
            this.textBoxMdp.ShortcutsEnabled = false;
            this.textBoxMdp.Size = new System.Drawing.Size(183, 25);
            this.textBoxMdp.TabIndex = 4;
            this.textBoxMdp.UseSystemPasswordChar = true;
            this.textBoxMdp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMdp_KeyPress);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnuler.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAnnuler.Location = new System.Drawing.Point(27, 200);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(137, 46);
            this.buttonAnnuler.TabIndex = 5;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // checkBoxAfficherMdp
            // 
            this.checkBoxAfficherMdp.AutoSize = true;
            this.checkBoxAfficherMdp.Font = new System.Drawing.Font("Cascadia Code", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxAfficherMdp.Location = new System.Drawing.Point(232, 154);
            this.checkBoxAfficherMdp.Name = "checkBoxAfficherMdp";
            this.checkBoxAfficherMdp.Size = new System.Drawing.Size(83, 21);
            this.checkBoxAfficherMdp.TabIndex = 6;
            this.checkBoxAfficherMdp.Text = "Visible";
            this.checkBoxAfficherMdp.UseVisualStyleBackColor = true;
            this.checkBoxAfficherMdp.CheckedChanged += new System.EventHandler(this.checkBoxAfficherMdp_CheckedChanged);
            // 
            // FormConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 279);
            this.Controls.Add(this.checkBoxAfficherMdp);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.textBoxMdp);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelMdp);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.buttonConnexion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion administrateur";
            this.Load += new System.EventHandler(this.FormConnexion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnexion;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelMdp;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxMdp;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox checkBoxAfficherMdp;
    }
}