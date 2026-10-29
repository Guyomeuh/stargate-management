namespace LittlePlanete
{
    partial class FormCreationMission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreationMission));
            this.labelPlanete = new System.Windows.Forms.Label();
            this.comboBoxPlanete = new System.Windows.Forms.ComboBox();
            this.labelNomMission = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePickerDepart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerRetour = new System.Windows.Forms.DateTimePicker();
            this.labelDateDepart = new System.Windows.Forms.Label();
            this.labelDateRetour = new System.Windows.Forms.Label();
            this.labelDuree = new System.Windows.Forms.Label();
            this.labelFeuilleRoute = new System.Windows.Forms.Label();
            this.richTextBoxFeuilleRoute = new System.Windows.Forms.RichTextBox();
            this.labelNbMembres = new System.Windows.Forms.Label();
            this.trackBarNbMembres = new System.Windows.Forms.TrackBar();
            this.labelMembres = new System.Windows.Forms.Label();
            this.labelDatabaz = new System.Windows.Forms.Label();
            this.textBoxDatabaz = new System.Windows.Forms.TextBox();
            this.labelTonnes = new System.Windows.Forms.Label();
            this.buttonValider = new System.Windows.Forms.Button();
            this.labelEuro = new System.Windows.Forms.Label();
            this.textBoxBudget = new System.Windows.Forms.TextBox();
            this.labelBudget = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBoxChef = new System.Windows.Forms.ComboBox();
            this.labelChef = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonValiderCapturesMembres = new System.Windows.Forms.Button();
            this.buttonAjouterCapture = new System.Windows.Forms.Button();
            this.textBoxNbCaptures = new System.Windows.Forms.TextBox();
            this.listBoxCaptures = new System.Windows.Forms.ListBox();
            this.comboBoxEnnemis = new System.Windows.Forms.ComboBox();
            this.labelObjectifCaptures = new System.Windows.Forms.Label();
            this.labelMembresRestants = new System.Windows.Forms.Label();
            this.checkedListBoxMembres = new System.Windows.Forms.CheckedListBox();
            this.labelAjoutMembres = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNbMembres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPlanete
            // 
            this.labelPlanete.AutoSize = true;
            this.labelPlanete.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelPlanete.Location = new System.Drawing.Point(12, 19);
            this.labelPlanete.Name = "labelPlanete";
            this.labelPlanete.Size = new System.Drawing.Size(263, 24);
            this.labelPlanete.TabIndex = 0;
            this.labelPlanete.Text = "1 - Choix de la planète";
            // 
            // comboBoxPlanete
            // 
            this.comboBoxPlanete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlanete.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxPlanete.FormattingEnabled = true;
            this.comboBoxPlanete.Location = new System.Drawing.Point(370, 16);
            this.comboBoxPlanete.Name = "comboBoxPlanete";
            this.comboBoxPlanete.Size = new System.Drawing.Size(366, 32);
            this.comboBoxPlanete.TabIndex = 1;
            this.comboBoxPlanete.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlanete_SelectedIndexChanged);
            // 
            // labelNomMission
            // 
            this.labelNomMission.AutoSize = true;
            this.labelNomMission.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelNomMission.Location = new System.Drawing.Point(366, 66);
            this.labelNomMission.Name = "labelNomMission";
            this.labelNomMission.Size = new System.Drawing.Size(186, 24);
            this.labelNomMission.TabIndex = 2;
            this.labelNomMission.Text = "Nom de mission: ";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDate.Location = new System.Drawing.Point(12, 122);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(241, 24);
            this.labelDate.TabIndex = 5;
            this.labelDate.Text = "2 - Choix de la date ";
            // 
            // dateTimePickerDepart
            // 
            this.dateTimePickerDepart.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerDepart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDepart.Location = new System.Drawing.Point(527, 122);
            this.dateTimePickerDepart.Name = "dateTimePickerDepart";
            this.dateTimePickerDepart.Size = new System.Drawing.Size(171, 28);
            this.dateTimePickerDepart.TabIndex = 6;
            this.dateTimePickerDepart.ValueChanged += new System.EventHandler(this.dateTimePickerDepart_ValueChanged);
            // 
            // dateTimePickerRetour
            // 
            this.dateTimePickerRetour.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerRetour.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerRetour.Location = new System.Drawing.Point(525, 171);
            this.dateTimePickerRetour.Name = "dateTimePickerRetour";
            this.dateTimePickerRetour.Size = new System.Drawing.Size(171, 28);
            this.dateTimePickerRetour.TabIndex = 7;
            this.dateTimePickerRetour.ValueChanged += new System.EventHandler(this.dateTimePickerRetour_ValueChanged);
            // 
            // labelDateDepart
            // 
            this.labelDateDepart.AutoSize = true;
            this.labelDateDepart.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDateDepart.Location = new System.Drawing.Point(365, 127);
            this.labelDateDepart.Name = "labelDateDepart";
            this.labelDateDepart.Size = new System.Drawing.Size(87, 24);
            this.labelDateDepart.TabIndex = 8;
            this.labelDateDepart.Text = "Départ:";
            // 
            // labelDateRetour
            // 
            this.labelDateRetour.AutoSize = true;
            this.labelDateRetour.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDateRetour.Location = new System.Drawing.Point(365, 176);
            this.labelDateRetour.Name = "labelDateRetour";
            this.labelDateRetour.Size = new System.Drawing.Size(87, 24);
            this.labelDateRetour.TabIndex = 9;
            this.labelDateRetour.Text = "Retour:";
            // 
            // labelDuree
            // 
            this.labelDuree.AutoSize = true;
            this.labelDuree.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDuree.Location = new System.Drawing.Point(365, 222);
            this.labelDuree.Name = "labelDuree";
            this.labelDuree.Size = new System.Drawing.Size(153, 24);
            this.labelDuree.TabIndex = 10;
            this.labelDuree.Text = "Durée: 0 jour";
            // 
            // labelFeuilleRoute
            // 
            this.labelFeuilleRoute.AutoSize = true;
            this.labelFeuilleRoute.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelFeuilleRoute.Location = new System.Drawing.Point(17, 335);
            this.labelFeuilleRoute.Name = "labelFeuilleRoute";
            this.labelFeuilleRoute.Size = new System.Drawing.Size(230, 24);
            this.labelFeuilleRoute.TabIndex = 11;
            this.labelFeuilleRoute.Text = "4 - Feuille de route";
            // 
            // richTextBoxFeuilleRoute
            // 
            this.richTextBoxFeuilleRoute.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richTextBoxFeuilleRoute.Location = new System.Drawing.Point(42, 367);
            this.richTextBoxFeuilleRoute.Name = "richTextBoxFeuilleRoute";
            this.richTextBoxFeuilleRoute.ShortcutsEnabled = false;
            this.richTextBoxFeuilleRoute.Size = new System.Drawing.Size(694, 168);
            this.richTextBoxFeuilleRoute.TabIndex = 12;
            this.richTextBoxFeuilleRoute.Text = "";
            this.richTextBoxFeuilleRoute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxFeuilleRoute_KeyPress);
            // 
            // labelNbMembres
            // 
            this.labelNbMembres.AutoSize = true;
            this.labelNbMembres.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelNbMembres.Location = new System.Drawing.Point(812, 16);
            this.labelNbMembres.Name = "labelNbMembres";
            this.labelNbMembres.Size = new System.Drawing.Size(318, 24);
            this.labelNbMembres.TabIndex = 13;
            this.labelNbMembres.Text = "5 - Nombre de membres requis";
            // 
            // trackBarNbMembres
            // 
            this.trackBarNbMembres.Location = new System.Drawing.Point(1153, 16);
            this.trackBarNbMembres.Minimum = 1;
            this.trackBarNbMembres.Name = "trackBarNbMembres";
            this.trackBarNbMembres.Size = new System.Drawing.Size(261, 45);
            this.trackBarNbMembres.TabIndex = 14;
            this.trackBarNbMembres.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarNbMembres.Value = 1;
            this.trackBarNbMembres.Scroll += new System.EventHandler(this.trackBarNbMembres_Scroll);
            // 
            // labelMembres
            // 
            this.labelMembres.AutoSize = true;
            this.labelMembres.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelMembres.Location = new System.Drawing.Point(1421, 30);
            this.labelMembres.Name = "labelMembres";
            this.labelMembres.Size = new System.Drawing.Size(21, 24);
            this.labelMembres.TabIndex = 15;
            this.labelMembres.Text = "1";
            // 
            // labelDatabaz
            // 
            this.labelDatabaz.AutoSize = true;
            this.labelDatabaz.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDatabaz.Location = new System.Drawing.Point(817, 91);
            this.labelDatabaz.Name = "labelDatabaz";
            this.labelDatabaz.Size = new System.Drawing.Size(263, 24);
            this.labelDatabaz.TabIndex = 16;
            this.labelDatabaz.Text = "6 - Objectif de databaz";
            // 
            // textBoxDatabaz
            // 
            this.textBoxDatabaz.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxDatabaz.Location = new System.Drawing.Point(1166, 88);
            this.textBoxDatabaz.Name = "textBoxDatabaz";
            this.textBoxDatabaz.ShortcutsEnabled = false;
            this.textBoxDatabaz.Size = new System.Drawing.Size(141, 28);
            this.textBoxDatabaz.TabIndex = 17;
            this.textBoxDatabaz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // labelTonnes
            // 
            this.labelTonnes.AutoSize = true;
            this.labelTonnes.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelTonnes.Location = new System.Drawing.Point(1317, 78);
            this.labelTonnes.Name = "labelTonnes";
            this.labelTonnes.Size = new System.Drawing.Size(76, 24);
            this.labelTonnes.TabIndex = 18;
            this.labelTonnes.Text = "tonnes";
            // 
            // buttonValider
            // 
            this.buttonValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValider.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonValider.Location = new System.Drawing.Point(1166, 202);
            this.buttonValider.Name = "buttonValider";
            this.buttonValider.Size = new System.Drawing.Size(143, 67);
            this.buttonValider.TabIndex = 19;
            this.buttonValider.Text = "Valider";
            this.buttonValider.UseVisualStyleBackColor = true;
            this.buttonValider.Click += new System.EventHandler(this.buttonValider_Click);
            // 
            // labelEuro
            // 
            this.labelEuro.AutoSize = true;
            this.labelEuro.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelEuro.Location = new System.Drawing.Point(1329, 142);
            this.labelEuro.Name = "labelEuro";
            this.labelEuro.Size = new System.Drawing.Size(21, 24);
            this.labelEuro.TabIndex = 22;
            this.labelEuro.Text = "€";
            // 
            // textBoxBudget
            // 
            this.textBoxBudget.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxBudget.Location = new System.Drawing.Point(1165, 139);
            this.textBoxBudget.Name = "textBoxBudget";
            this.textBoxBudget.ShortcutsEnabled = false;
            this.textBoxBudget.Size = new System.Drawing.Size(141, 28);
            this.textBoxBudget.TabIndex = 21;
            this.textBoxBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // labelBudget
            // 
            this.labelBudget.AutoSize = true;
            this.labelBudget.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelBudget.Location = new System.Drawing.Point(816, 142);
            this.labelBudget.Name = "labelBudget";
            this.labelBudget.Size = new System.Drawing.Size(120, 24);
            this.labelBudget.TabIndex = 20;
            this.labelBudget.Text = "7 - Budget";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // comboBoxChef
            // 
            this.comboBoxChef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChef.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxChef.FormattingEnabled = true;
            this.comboBoxChef.Location = new System.Drawing.Point(371, 268);
            this.comboBoxChef.Name = "comboBoxChef";
            this.comboBoxChef.Size = new System.Drawing.Size(365, 32);
            this.comboBoxChef.TabIndex = 24;
            // 
            // labelChef
            // 
            this.labelChef.AutoSize = true;
            this.labelChef.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelChef.Location = new System.Drawing.Point(13, 271);
            this.labelChef.Name = "labelChef";
            this.labelChef.Size = new System.Drawing.Size(318, 24);
            this.labelChef.TabIndex = 23;
            this.labelChef.Text = "3 - Choix du chef de mission";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonValiderCapturesMembres);
            this.groupBox.Controls.Add(this.buttonAjouterCapture);
            this.groupBox.Controls.Add(this.textBoxNbCaptures);
            this.groupBox.Controls.Add(this.listBoxCaptures);
            this.groupBox.Controls.Add(this.comboBoxEnnemis);
            this.groupBox.Controls.Add(this.labelObjectifCaptures);
            this.groupBox.Controls.Add(this.labelTonnes);
            this.groupBox.Controls.Add(this.labelMembresRestants);
            this.groupBox.Controls.Add(this.checkedListBoxMembres);
            this.groupBox.Controls.Add(this.labelAjoutMembres);
            this.groupBox.Controls.Add(this.btnCancel);
            this.groupBox.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox.Location = new System.Drawing.Point(12, 11);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(1462, 567);
            this.groupBox.TabIndex = 25;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Objectifs et Membres";
            // 
            // buttonValiderCapturesMembres
            // 
            this.buttonValiderCapturesMembres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonValiderCapturesMembres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValiderCapturesMembres.Location = new System.Drawing.Point(1248, 406);
            this.buttonValiderCapturesMembres.Name = "buttonValiderCapturesMembres";
            this.buttonValiderCapturesMembres.Size = new System.Drawing.Size(208, 62);
            this.buttonValiderCapturesMembres.TabIndex = 10;
            this.buttonValiderCapturesMembres.Text = "Valider";
            this.buttonValiderCapturesMembres.UseVisualStyleBackColor = true;
            this.buttonValiderCapturesMembres.Click += new System.EventHandler(this.buttonValiderCapturesMembres_Click);
            // 
            // buttonAjouterCapture
            // 
            this.buttonAjouterCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAjouterCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouterCapture.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAjouterCapture.Location = new System.Drawing.Point(1148, 76);
            this.buttonAjouterCapture.Name = "buttonAjouterCapture";
            this.buttonAjouterCapture.Size = new System.Drawing.Size(149, 37);
            this.buttonAjouterCapture.TabIndex = 9;
            this.buttonAjouterCapture.Text = "Ajouter";
            this.buttonAjouterCapture.UseVisualStyleBackColor = true;
            this.buttonAjouterCapture.Click += new System.EventHandler(this.buttonAjouterCapture_Click);
            // 
            // textBoxNbCaptures
            // 
            this.textBoxNbCaptures.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxNbCaptures.Location = new System.Drawing.Point(1037, 81);
            this.textBoxNbCaptures.Name = "textBoxNbCaptures";
            this.textBoxNbCaptures.ShortcutsEnabled = false;
            this.textBoxNbCaptures.Size = new System.Drawing.Size(77, 25);
            this.textBoxNbCaptures.TabIndex = 8;
            this.textBoxNbCaptures.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNbCaptures_KeyPress);
            // 
            // listBoxCaptures
            // 
            this.listBoxCaptures.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBoxCaptures.FormattingEnabled = true;
            this.listBoxCaptures.ItemHeight = 20;
            this.listBoxCaptures.Location = new System.Drawing.Point(723, 135);
            this.listBoxCaptures.Name = "listBoxCaptures";
            this.listBoxCaptures.Size = new System.Drawing.Size(574, 244);
            this.listBoxCaptures.TabIndex = 6;
            this.listBoxCaptures.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxCaptures_KeyDown);
            // 
            // comboBoxEnnemis
            // 
            this.comboBoxEnnemis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEnnemis.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxEnnemis.FormattingEnabled = true;
            this.comboBoxEnnemis.Location = new System.Drawing.Point(723, 79);
            this.comboBoxEnnemis.Name = "comboBoxEnnemis";
            this.comboBoxEnnemis.Size = new System.Drawing.Size(272, 28);
            this.comboBoxEnnemis.TabIndex = 4;
            this.comboBoxEnnemis.SelectedIndexChanged += new System.EventHandler(this.comboBoxEnnemis_SelectedIndexChanged);
            // 
            // labelObjectifCaptures
            // 
            this.labelObjectifCaptures.AutoSize = true;
            this.labelObjectifCaptures.Location = new System.Drawing.Point(718, 34);
            this.labelObjectifCaptures.Name = "labelObjectifCaptures";
            this.labelObjectifCaptures.Size = new System.Drawing.Size(230, 24);
            this.labelObjectifCaptures.TabIndex = 3;
            this.labelObjectifCaptures.Text = "Objectifs de capture";
            // 
            // labelMembresRestants
            // 
            this.labelMembresRestants.AutoSize = true;
            this.labelMembresRestants.ForeColor = System.Drawing.Color.Crimson;
            this.labelMembresRestants.Location = new System.Drawing.Point(497, 34);
            this.labelMembresRestants.Name = "labelMembresRestants";
            this.labelMembresRestants.Size = new System.Drawing.Size(153, 24);
            this.labelMembresRestants.TabIndex = 2;
            this.labelMembresRestants.Text = " 0 restant(s)";
            // 
            // checkedListBoxMembres
            // 
            this.checkedListBoxMembres.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkedListBoxMembres.FormattingEnabled = true;
            this.checkedListBoxMembres.Location = new System.Drawing.Point(31, 76);
            this.checkedListBoxMembres.Name = "checkedListBoxMembres";
            this.checkedListBoxMembres.Size = new System.Drawing.Size(619, 304);
            this.checkedListBoxMembres.TabIndex = 1;
            this.checkedListBoxMembres.ThreeDCheckBoxes = true;
            this.checkedListBoxMembres.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxMembres_ItemCheck);
            // 
            // labelAjoutMembres
            // 
            this.labelAjoutMembres.AutoSize = true;
            this.labelAjoutMembres.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAjoutMembres.Location = new System.Drawing.Point(31, 34);
            this.labelAjoutMembres.Name = "labelAjoutMembres";
            this.labelAjoutMembres.Size = new System.Drawing.Size(186, 24);
            this.labelAjoutMembres.TabIndex = 0;
            this.labelAjoutMembres.Text = "Ajout de membres";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(1248, 489);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(214, 59);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormCreationMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 590);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.comboBoxChef);
            this.Controls.Add(this.labelChef);
            this.Controls.Add(this.labelEuro);
            this.Controls.Add(this.textBoxBudget);
            this.Controls.Add(this.labelBudget);
            this.Controls.Add(this.buttonValider);
            this.Controls.Add(this.textBoxDatabaz);
            this.Controls.Add(this.labelDatabaz);
            this.Controls.Add(this.labelMembres);
            this.Controls.Add(this.trackBarNbMembres);
            this.Controls.Add(this.labelNbMembres);
            this.Controls.Add(this.labelFeuilleRoute);
            this.Controls.Add(this.labelDuree);
            this.Controls.Add(this.labelDateRetour);
            this.Controls.Add(this.labelDateDepart);
            this.Controls.Add(this.dateTimePickerRetour);
            this.Controls.Add(this.dateTimePickerDepart);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelNomMission);
            this.Controls.Add(this.comboBoxPlanete);
            this.Controls.Add(this.labelPlanete);
            this.Controls.Add(this.richTextBoxFeuilleRoute);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormCreationMission";
            this.Text = "Création d\'une nouvelle mission";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCreationMission_FormClosing);
            this.Load += new System.EventHandler(this.FormCreationMission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNbMembres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlanete;
        private System.Windows.Forms.ComboBox comboBoxPlanete;
        private System.Windows.Forms.Label labelNomMission;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDepart;
        private System.Windows.Forms.DateTimePicker dateTimePickerRetour;
        private System.Windows.Forms.Label labelDateDepart;
        private System.Windows.Forms.Label labelDateRetour;
        private System.Windows.Forms.Label labelDuree;
        private System.Windows.Forms.Label labelFeuilleRoute;
        private System.Windows.Forms.RichTextBox richTextBoxFeuilleRoute;
        private System.Windows.Forms.Label labelNbMembres;
        private System.Windows.Forms.TrackBar trackBarNbMembres;
        private System.Windows.Forms.Label labelMembres;
        private System.Windows.Forms.Label labelDatabaz;
        private System.Windows.Forms.TextBox textBoxDatabaz;
        private System.Windows.Forms.Label labelTonnes;
        private System.Windows.Forms.Button buttonValider;
        private System.Windows.Forms.Label labelEuro;
        private System.Windows.Forms.TextBox textBoxBudget;
        private System.Windows.Forms.Label labelBudget;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox comboBoxChef;
        private System.Windows.Forms.Label labelChef;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label labelAjoutMembres;
        private System.Windows.Forms.CheckedListBox checkedListBoxMembres;
        private System.Windows.Forms.Label labelMembresRestants;
        private System.Windows.Forms.ListBox listBoxCaptures;
        private System.Windows.Forms.ComboBox comboBoxEnnemis;
        private System.Windows.Forms.Label labelObjectifCaptures;
        private System.Windows.Forms.TextBox textBoxNbCaptures;
        private System.Windows.Forms.Button buttonAjouterCapture;
        private System.Windows.Forms.Button buttonValiderCapturesMembres;
        private System.Windows.Forms.Button btnCancel;
    }
}