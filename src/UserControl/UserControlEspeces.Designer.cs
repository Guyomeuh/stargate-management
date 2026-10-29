namespace UserControlPlanetes
{
    partial class UserControlEspeces
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
            this.pbEspece = new System.Windows.Forms.PictureBox();
            this.lblNomEspece = new System.Windows.Forms.Label();
            this.lblOrigine = new System.Windows.Forms.Label();
            this.lblCouleur = new System.Windows.Forms.Label();
            this.lblNbPlanete = new System.Windows.Forms.Label();
            this.lblCamp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbEspece)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEspece
            // 
            this.pbEspece.Location = new System.Drawing.Point(78, 13);
            this.pbEspece.Margin = new System.Windows.Forms.Padding(4);
            this.pbEspece.Name = "pbEspece";
            this.pbEspece.Size = new System.Drawing.Size(183, 183);
            this.pbEspece.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEspece.TabIndex = 0;
            this.pbEspece.TabStop = false;
            // 
            // lblNomEspece
            // 
            this.lblNomEspece.Font = new System.Drawing.Font("Cascadia Code", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNomEspece.Location = new System.Drawing.Point(53, 198);
            this.lblNomEspece.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomEspece.Name = "lblNomEspece";
            this.lblNomEspece.Size = new System.Drawing.Size(233, 48);
            this.lblNomEspece.TabIndex = 1;
            this.lblNomEspece.Text = "<nom>";
            this.lblNomEspece.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNomEspece.Click += new System.EventHandler(this.lblNomEspece_Click);
            // 
            // lblOrigine
            // 
            this.lblOrigine.AutoSize = true;
            this.lblOrigine.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblOrigine.Location = new System.Drawing.Point(21, 322);
            this.lblOrigine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrigine.Name = "lblOrigine";
            this.lblOrigine.Size = new System.Drawing.Size(329, 24);
            this.lblOrigine.TabIndex = 2;
            this.lblOrigine.Text = "<nom de la planète d\'origine>";
            // 
            // lblCouleur
            // 
            this.lblCouleur.AutoSize = true;
            this.lblCouleur.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblCouleur.Location = new System.Drawing.Point(21, 352);
            this.lblCouleur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCouleur.Name = "lblCouleur";
            this.lblCouleur.Size = new System.Drawing.Size(109, 24);
            this.lblCouleur.TabIndex = 3;
            this.lblCouleur.Text = "<couleur>";
            // 
            // lblNbPlanete
            // 
            this.lblNbPlanete.AutoSize = true;
            this.lblNbPlanete.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNbPlanete.Location = new System.Drawing.Point(21, 292);
            this.lblNbPlanete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNbPlanete.Name = "lblNbPlanete";
            this.lblNbPlanete.Size = new System.Drawing.Size(219, 24);
            this.lblNbPlanete.TabIndex = 4;
            this.lblNbPlanete.Text = "Planète d\'origine :";
            // 
            // lblCamp
            // 
            this.lblCamp.AutoSize = true;
            this.lblCamp.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblCamp.Location = new System.Drawing.Point(21, 262);
            this.lblCamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCamp.Name = "lblCamp";
            this.lblCamp.Size = new System.Drawing.Size(76, 24);
            this.lblCamp.TabIndex = 5;
            this.lblCamp.Text = "<camp>";
            // 
            // UserControlEspeces
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lblCamp);
            this.Controls.Add(this.lblNbPlanete);
            this.Controls.Add(this.lblCouleur);
            this.Controls.Add(this.lblOrigine);
            this.Controls.Add(this.lblNomEspece);
            this.Controls.Add(this.pbEspece);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlEspeces";
            this.Size = new System.Drawing.Size(339, 398);
            this.Load += new System.EventHandler(this.UserControlEspeces_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEspece)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbEspece;
        private System.Windows.Forms.Label lblNomEspece;
        private System.Windows.Forms.Label lblOrigine;
        private System.Windows.Forms.Label lblCouleur;
        private System.Windows.Forms.Label lblNbPlanete;
        private System.Windows.Forms.Label lblCamp;
    }
}
