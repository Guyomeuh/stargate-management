namespace LittlePlanete
{
    partial class MembreEquipage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MembreEquipage));
            this.pbMembre = new System.Windows.Forms.PictureBox();
            this.lblMembre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMembre)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMembre
            // 
            this.pbMembre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbMembre.Image = ((System.Drawing.Image)(resources.GetObject("pbMembre.Image")));
            this.pbMembre.Location = new System.Drawing.Point(15, 0);
            this.pbMembre.Margin = new System.Windows.Forms.Padding(0);
            this.pbMembre.Name = "pbMembre";
            this.pbMembre.Size = new System.Drawing.Size(142, 142);
            this.pbMembre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMembre.TabIndex = 0;
            this.pbMembre.TabStop = false;
            // 
            // lblMembre
            // 
            this.lblMembre.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblMembre.Location = new System.Drawing.Point(3, 170);
            this.lblMembre.Name = "lblMembre";
            this.lblMembre.Size = new System.Drawing.Size(165, 56);
            this.lblMembre.TabIndex = 1;
            this.lblMembre.Text = "<Nom>";
            this.lblMembre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MembreEquipage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblMembre);
            this.Controls.Add(this.pbMembre);
            this.Name = "MembreEquipage";
            this.Size = new System.Drawing.Size(173, 232);
            ((System.ComponentModel.ISupportInitialize)(this.pbMembre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMembre;
        private System.Windows.Forms.Label lblMembre;
    }
}
