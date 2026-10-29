namespace UserControlPlanetes
{
    partial class UserControlPlanete
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbPlanete = new System.Windows.Forms.PictureBox();
            this.lblNomPlanete = new System.Windows.Forms.Label();
            this.pbTemp = new System.Windows.Forms.PictureBox();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblGraviteCommun = new System.Windows.Forms.Label();
            this.lblGraviteValue = new System.Windows.Forms.Label();
            this.lblPresenceDatabaz = new System.Windows.Forms.Label();
            this.lblEspecesCommun = new System.Windows.Forms.Label();
            this.lblEspecesValue = new System.Windows.Forms.Label();
            this.lblMissionsCommun = new System.Windows.Forms.Label();
            this.lblMissionsValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlanete
            // 
            this.pbPlanete.Location = new System.Drawing.Point(31, 34);
            this.pbPlanete.Margin = new System.Windows.Forms.Padding(4);
            this.pbPlanete.Name = "pbPlanete";
            this.pbPlanete.Size = new System.Drawing.Size(227, 227);
            this.pbPlanete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlanete.TabIndex = 0;
            this.pbPlanete.TabStop = false;
            // 
            // lblNomPlanete
            // 
            this.lblNomPlanete.AutoSize = true;
            this.lblNomPlanete.Font = new System.Drawing.Font("Cascadia Code", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNomPlanete.Location = new System.Drawing.Point(280, 34);
            this.lblNomPlanete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomPlanete.Name = "lblNomPlanete";
            this.lblNomPlanete.Size = new System.Drawing.Size(90, 33);
            this.lblNomPlanete.TabIndex = 1;
            this.lblNomPlanete.Text = "<nom>";
            // 
            // pbTemp
            // 
            this.pbTemp.Location = new System.Drawing.Point(278, 91);
            this.pbTemp.Margin = new System.Windows.Forms.Padding(4);
            this.pbTemp.Name = "pbTemp";
            this.pbTemp.Size = new System.Drawing.Size(56, 46);
            this.pbTemp.TabIndex = 2;
            this.pbTemp.TabStop = false;
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTemp.Location = new System.Drawing.Point(361, 91);
            this.lblTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(126, 20);
            this.lblTemp.TabIndex = 3;
            this.lblTemp.Text = "<température>";
            // 
            // lblGraviteCommun
            // 
            this.lblGraviteCommun.AutoSize = true;
            this.lblGraviteCommun.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblGraviteCommun.Location = new System.Drawing.Point(272, 172);
            this.lblGraviteCommun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGraviteCommun.Name = "lblGraviteCommun";
            this.lblGraviteCommun.Size = new System.Drawing.Size(90, 20);
            this.lblGraviteCommun.TabIndex = 4;
            this.lblGraviteCommun.Text = "Gravité :";
            // 
            // lblGraviteValue
            // 
            this.lblGraviteValue.AutoSize = true;
            this.lblGraviteValue.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblGraviteValue.Location = new System.Drawing.Point(351, 172);
            this.lblGraviteValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGraviteValue.Name = "lblGraviteValue";
            this.lblGraviteValue.Size = new System.Drawing.Size(90, 20);
            this.lblGraviteValue.TabIndex = 5;
            this.lblGraviteValue.Text = "<gravité>";
            // 
            // lblPresenceDatabaz
            // 
            this.lblPresenceDatabaz.AutoSize = true;
            this.lblPresenceDatabaz.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblPresenceDatabaz.Location = new System.Drawing.Point(271, 141);
            this.lblPresenceDatabaz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPresenceDatabaz.Name = "lblPresenceDatabaz";
            this.lblPresenceDatabaz.Size = new System.Drawing.Size(279, 20);
            this.lblPresenceDatabaz.TabIndex = 6;
            this.lblPresenceDatabaz.Text = "<Présence de Databaz (ou non)>";
            // 
            // lblEspecesCommun
            // 
            this.lblEspecesCommun.AutoSize = true;
            this.lblEspecesCommun.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblEspecesCommun.Location = new System.Drawing.Point(272, 221);
            this.lblEspecesCommun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspecesCommun.Name = "lblEspecesCommun";
            this.lblEspecesCommun.Size = new System.Drawing.Size(180, 20);
            this.lblEspecesCommun.TabIndex = 7;
            this.lblEspecesCommun.Text = "Espèces présentes :";
            // 
            // lblEspecesValue
            // 
            this.lblEspecesValue.AutoSize = true;
            this.lblEspecesValue.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblEspecesValue.Location = new System.Drawing.Point(275, 246);
            this.lblEspecesValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspecesValue.Name = "lblEspecesValue";
            this.lblEspecesValue.Size = new System.Drawing.Size(81, 20);
            this.lblEspecesValue.TabIndex = 8;
            this.lblEspecesValue.Text = "<nom(s)>";
            // 
            // lblMissionsCommun
            // 
            this.lblMissionsCommun.AutoSize = true;
            this.lblMissionsCommun.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblMissionsCommun.Location = new System.Drawing.Point(272, 199);
            this.lblMissionsCommun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMissionsCommun.Name = "lblMissionsCommun";
            this.lblMissionsCommun.Size = new System.Drawing.Size(189, 20);
            this.lblMissionsCommun.TabIndex = 9;
            this.lblMissionsCommun.Text = "Missions réalisées :";
            // 
            // lblMissionsValue
            // 
            this.lblMissionsValue.AutoSize = true;
            this.lblMissionsValue.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblMissionsValue.Location = new System.Drawing.Point(469, 199);
            this.lblMissionsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMissionsValue.Name = "lblMissionsValue";
            this.lblMissionsValue.Size = new System.Drawing.Size(81, 20);
            this.lblMissionsValue.TabIndex = 10;
            this.lblMissionsValue.Text = "<nom(s)>";
            // 
            // UserControlPlanete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblMissionsValue);
            this.Controls.Add(this.lblMissionsCommun);
            this.Controls.Add(this.lblEspecesValue);
            this.Controls.Add(this.lblEspecesCommun);
            this.Controls.Add(this.lblPresenceDatabaz);
            this.Controls.Add(this.lblGraviteValue);
            this.Controls.Add(this.lblGraviteCommun);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.pbTemp);
            this.Controls.Add(this.lblNomPlanete);
            this.Controls.Add(this.pbPlanete);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlPlanete";
            this.Size = new System.Drawing.Size(573, 296);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlanete;
        private System.Windows.Forms.Label lblNomPlanete;
        private System.Windows.Forms.PictureBox pbTemp;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblGraviteCommun;
        private System.Windows.Forms.Label lblGraviteValue;
        private System.Windows.Forms.Label lblPresenceDatabaz;
        private System.Windows.Forms.Label lblEspecesCommun;
        private System.Windows.Forms.Label lblEspecesValue;
        private System.Windows.Forms.Label lblMissionsCommun;
        private System.Windows.Forms.Label lblMissionsValue;
    }
}
