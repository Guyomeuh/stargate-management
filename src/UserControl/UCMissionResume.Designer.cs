namespace LittlePlanete
{
    partial class MissionResume
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
            this.lblNomMission = new System.Windows.Forms.Label();
            this.lblDateDeb = new System.Windows.Forms.Label();
            this.lblDuree = new System.Windows.Forms.Label();
            this.lblChef = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlanete
            // 
            this.pbPlanete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPlanete.Location = new System.Drawing.Point(4, 8);
            this.pbPlanete.Name = "pbPlanete";
            this.pbPlanete.Size = new System.Drawing.Size(250, 250);
            this.pbPlanete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlanete.TabIndex = 0;
            this.pbPlanete.TabStop = false;
            this.pbPlanete.Click += new System.EventHandler(this.AfficherResume_Click);
            this.pbPlanete.MouseEnter += new System.EventHandler(this.MissionResume_MouseEnter);
            this.pbPlanete.MouseLeave += new System.EventHandler(this.MissionResume_MouseLeave);
            // 
            // lblNomMission
            // 
            this.lblNomMission.AutoSize = true;
            this.lblNomMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNomMission.Font = new System.Drawing.Font("Cascadia Code", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNomMission.Location = new System.Drawing.Point(291, 29);
            this.lblNomMission.Name = "lblNomMission";
            this.lblNomMission.Size = new System.Drawing.Size(146, 46);
            this.lblNomMission.TabIndex = 1;
            this.lblNomMission.Text = "label1";
            this.lblNomMission.Visible = false;
            this.lblNomMission.Click += new System.EventHandler(this.AfficherResume_Click);
            this.lblNomMission.MouseEnter += new System.EventHandler(this.MissionResume_MouseEnter);
            this.lblNomMission.MouseLeave += new System.EventHandler(this.MissionResume_MouseLeave);
            // 
            // lblDateDeb
            // 
            this.lblDateDeb.AutoSize = true;
            this.lblDateDeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDateDeb.Font = new System.Drawing.Font("Cascadia Code", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDateDeb.Location = new System.Drawing.Point(293, 98);
            this.lblDateDeb.Name = "lblDateDeb";
            this.lblDateDeb.Size = new System.Drawing.Size(105, 33);
            this.lblDateDeb.TabIndex = 2;
            this.lblDateDeb.Text = "label1";
            this.lblDateDeb.Visible = false;
            this.lblDateDeb.Click += new System.EventHandler(this.AfficherResume_Click);
            this.lblDateDeb.MouseEnter += new System.EventHandler(this.MissionResume_MouseEnter);
            this.lblDateDeb.MouseLeave += new System.EventHandler(this.MissionResume_MouseLeave);
            // 
            // lblDuree
            // 
            this.lblDuree.AutoSize = true;
            this.lblDuree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDuree.Font = new System.Drawing.Font("Cascadia Code", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDuree.Location = new System.Drawing.Point(663, 98);
            this.lblDuree.Name = "lblDuree";
            this.lblDuree.Size = new System.Drawing.Size(105, 33);
            this.lblDuree.TabIndex = 3;
            this.lblDuree.Text = "label1";
            this.lblDuree.Visible = false;
            this.lblDuree.Click += new System.EventHandler(this.AfficherResume_Click);
            this.lblDuree.MouseEnter += new System.EventHandler(this.MissionResume_MouseEnter);
            this.lblDuree.MouseLeave += new System.EventHandler(this.MissionResume_MouseLeave);
            // 
            // lblChef
            // 
            this.lblChef.AutoSize = true;
            this.lblChef.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChef.Font = new System.Drawing.Font("Cascadia Code", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblChef.Location = new System.Drawing.Point(293, 156);
            this.lblChef.Name = "lblChef";
            this.lblChef.Size = new System.Drawing.Size(105, 33);
            this.lblChef.TabIndex = 4;
            this.lblChef.Text = "label1";
            this.lblChef.Visible = false;
            this.lblChef.Click += new System.EventHandler(this.AfficherResume_Click);
            this.lblChef.MouseEnter += new System.EventHandler(this.MissionResume_MouseEnter);
            this.lblChef.MouseLeave += new System.EventHandler(this.MissionResume_MouseLeave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStatus.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(1035, 59);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(63, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "label1";
            // 
            // MissionResume
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblChef);
            this.Controls.Add(this.lblDuree);
            this.Controls.Add(this.lblDateDeb);
            this.Controls.Add(this.lblNomMission);
            this.Controls.Add(this.pbPlanete);
            this.Name = "MissionResume";
            this.Size = new System.Drawing.Size(1376, 266);
            this.Click += new System.EventHandler(this.AfficherResume_Click);
            this.MouseEnter += new System.EventHandler(this.MissionResume_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MissionResume_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlanete;
        private System.Windows.Forms.Label lblNomMission;
        private System.Windows.Forms.Label lblDateDeb;
        private System.Windows.Forms.Label lblDuree;
        private System.Windows.Forms.Label lblChef;
        private System.Windows.Forms.Label lblStatus;
    }
}
