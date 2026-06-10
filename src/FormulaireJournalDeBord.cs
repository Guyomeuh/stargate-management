using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace LittlePlanete
{
    public partial class FormulaireMission : Form
    {
        DataRow missionActuelle;
        BindingSource bsMission;
        BindingSource bsJournalDeBord;
        DataTable depenseMissionActuelle;
        DataTable contactMissionActuelle;
        DataTable captureMissionActuelle;
        double solde = 0;

        public FormulaireMission()
        {
            InitializeComponent();
        }

        public FormulaireMission(string idMission)
        {
            InitializeComponent();
            missionActuelle = MesDatas.DsGlobal.Tables["Mission"].Select($"nomPlanete = '{idMission.Substring(0, idMission.Length - 1)}' AND numero = '{idMission.Substring(idMission.Length - 1, 1)}'")[0];
            pbPlanete.Image = System.Drawing.Image.FromFile($"../../Images/Planetes/{idMission.Substring(0, idMission.Length - 1)}.png");
            lblNomMission.Text = idMission;
            BackColor = Couleur.getBackground;
            ForeColor = Couleur.getText;
            foreach (Control c in Controls)
            {
                if (c.Name != "btnGeneratePdf")
                {
                    UpdateColorControls(c);
                }
            }
            QuestPDF.Settings.License = LicenseType.Community;
            solde = Convert.ToDouble(missionActuelle["budget"]);
        }

        private void RemplissageMembre()
        {
            DataRow[] membreMission = missionActuelle.GetChildRows("FK_Mission_Composer");

            foreach (DataRow membre in membreMission)
            {
                CreationMembre(membre);
            }
        }

        private void CreationMembre(DataRow r)
        {
            MembreEquipage m = new MembreEquipage();
            DataRow profil = r.GetParentRow("FK_Membre_Composer");
            if (profil["matricule"].ToString()[0] == 'C')
            {
                m.SetImage = "Civil";
            }
            else
            {
                m.SetImage = "Soldier";
            }
            m.setText = $"{profil["nom"].ToString()}\n{profil["prenom"].ToString()}";
            if (profil["matricule"].ToString() == missionActuelle["matriculeChef"].ToString())
            {
                m.BackColor = Couleur.getButton;
            }
            pnlMembre.Controls.Add(m);
        }

        private void RemplissageInfoMission()
        {
            lblDepart.Text = $"Date de départ : {missionActuelle["dateDepart"]}";
            lblArrivee.Text = $"Date de retour prévu : {missionActuelle["dateRetour"]}";

            lblBudget.Text = $"Budget : {missionActuelle["budget"]}";

            DataRow[] depense = missionActuelle.GetChildRows("FK_Mission_Depense");
            DataRow[] contact = missionActuelle.GetChildRows("FK_Mission_Contact");
            foreach (DataRow row in depense)
            {
                solde -= Convert.ToDouble(row["montant"]);
            }
            foreach (DataRow row in contact)
            {
                solde -= Convert.ToDouble(row["sommeVersee"]);
            }
            lblSolde.Text = $"Solde après dépenses : {solde.ToString()}";
            txtFeuilleRoute.Text = $"{missionActuelle["feuilleDeRoute"]}";
            txtFeuilleRoute.BackColor = SystemColors.Window;
        }

        private void RemplissageObjectif()
        {
            DataRow[] objectifs = missionActuelle.GetChildRows("FK_Mission_ObjectifCapture");


            foreach (DataRow r in objectifs)
            {
                DataRow espece = r.GetParentRow("FK_Espece_ObjectifCapture");
                txtCaptures.Text += $"{espece["nom"].ToString()} : {r["objectif"].ToString()}\r\n";
            }
            txtCaptures.BackColor = SystemColors.Window;
        }
        private void FormulaireMission_Load(object sender, EventArgs e)
        {
            RemplissageInfoMission();
            RemplissageMembre();
            RemplissageObjectif();
            creationDGVContacts();
            creationDGVDepense();
            creationListeEvent();
            creationDGVCapture();
            Text = $"Résumé de la mission {missionActuelle["nomPlanete"]}{missionActuelle["numero"]}";
        }

        private void creationDGVDepense()
        {
            //On créer une nouvelle table qui est constitué des informations que l'on souhaite
            //pour la mission actuelle.
            depenseMissionActuelle = new DataTable("DepenseMissionActuelle");
            depenseMissionActuelle.Columns.Add("N°", typeof(string));
            depenseMissionActuelle.Columns.Add("Date", typeof(string));
            depenseMissionActuelle.Columns.Add("Motif", typeof(string));
            depenseMissionActuelle.Columns.Add("Montant", typeof(string));
            depenseMissionActuelle.Columns.Add("Type de dépense", typeof(string));

            //Variable servant à compter les dépenses totales
            Double montantDepense = 0;

            //On récupère les dépenses qui sont liées à la mission
            DataRow[] depenses = missionActuelle.GetChildRows("FK_Mission_Depense");

            //Pour chaque dépense, on crée une nouvelle ligne qui ira dans notre DataGridView
            foreach (DataRow depense in depenses)
            {
                DataRow newDepense = depenseMissionActuelle.NewRow();
                newDepense[0] = depense["id"];
                newDepense[1] = depense["dateD"];
                newDepense[2] = depense["motif"];
                newDepense[3] = depense["montant"];

                //On récupère le libelle correspondant au type de dépense.
                DataRow typeDepense = depense.GetParentRow("FK_TypeDepense_Depense");
                newDepense[4] = typeDepense["libelle"];

                //On incrémente notre somme totale de dépense
                montantDepense += Convert.ToDouble(depense["montant"]);
                depenseMissionActuelle.Rows.Add(newDepense);
            }

            //On affiche la somme totale des dépenses et on les affiche dans le DataGridView
            dgvDepenses.DataSource = depenseMissionActuelle;
            lblDepense.Text = $"Depense totale : {montantDepense.ToString()}";
        }

        private void creationListeEvent()
        {
            // On initialise nos Binding Source pour la relation Maitre/Détail
            bsMission = new BindingSource();
            bsMission.DataSource = MesDatas.DsGlobal.Tables["mission"];

            //On met un filtre sur ce BindingSource pour que les évent de journal soit bien ceux de la mission actuelle
            bsMission.Filter = $"nomPlanete = '{missionActuelle["nomPlanete"]}' AND numero = '{missionActuelle["numero"]}'";

            bsJournalDeBord = new BindingSource();
            bsJournalDeBord.DataSource = bsMission;
            bsJournalDeBord.DataMember = MesDatas.DsGlobal.Relations["FK_Mission_JournalDeBord"].ToString();

            //On tri par date ascendante (Marche moyennement à cause du type String et du format des dates aléatoire de la DB)
            bsJournalDeBord.Sort = "dateJ";

            //On peut bind au label le texte à afficher
            lblDateEvent.DataBindings.Add("Text", bsJournalDeBord, "dateJ");
            lblEventDescription.DataBindings.Add("Text", bsJournalDeBord, "commentaires");
        }

        private void creationDGVContacts()
        {
            //On crée une table qui servira à donner les informations de Contact de la mission actuelle
            contactMissionActuelle = new DataTable("ContactMissionActuelle");
            contactMissionActuelle.Columns.Add("Date", typeof(string));
            contactMissionActuelle.Columns.Add("Somme", typeof(string));
            contactMissionActuelle.Columns.Add("Appreciation", typeof(string));
            contactMissionActuelle.Columns.Add("Informateur", typeof(string));


            DataRow[] contacts = missionActuelle.GetChildRows("FK_Mission_Contact");
            Double montantSommeVersee = 0;
            foreach (DataRow contact in contacts)
            {
                DataRow newContact = contactMissionActuelle.NewRow();
                newContact[0] = contact["dateC"];
                newContact[1] = contact["sommeVersee"];
                newContact[2] = contact["appreciation"];
                DataRow informateur = contact.GetParentRow("FK_Informateur_Contact");
                newContact[3] = informateur["nom"];
                montantSommeVersee += Convert.ToDouble(newContact[1]);
                contactMissionActuelle.Rows.Add(newContact);
            }
            dgvContact.DataSource = contactMissionActuelle;
            lblSommeVersees.Text = $"Somme totale versée : {montantSommeVersee.ToString()}";
        }

        private void creationDGVCapture()
        {
            //On crée une table qui servira à donner les informations de Contact de la mission actuelle
            captureMissionActuelle = new DataTable("CaptureMissionActuelle");
            captureMissionActuelle.Columns.Add("Nom de l'espèce", typeof(string));
            captureMissionActuelle.Columns.Add("Objectif initial", typeof(string));
            captureMissionActuelle.Columns.Add("Nombre de captures réalisées", typeof(string));
            captureMissionActuelle.Columns.Add("Taux de réussite (en %)", typeof(string));


            DataRow[] captures = missionActuelle.GetChildRows("FK_Mission_Capturer");
            foreach (DataRow capture in captures)
            {
                DataRow newCapture = captureMissionActuelle.NewRow();
                DataRow idEspece = capture.GetParentRow("FK_Espece_Capturer");
                DataRow[] objectifCapture = missionActuelle.GetChildRows("FK_Mission_ObjectifCapture");
                newCapture[0] = idEspece["nom"];
                Int32 objectif = 1;
                foreach (DataRow r in objectifCapture)
                {
                    if (r["idEspeceEnnemi"].ToString() == capture["idEspeceEnnemi"].ToString())
                    {
                        objectif = Convert.ToInt32(r["objectif"]);
                        newCapture[1] = r["objectif"].ToString();
                    }
                }
                DataRow[] capturé = missionActuelle.GetChildRows("FK_Mission_Capturer");
                Int32 nbCapture = 0;
                foreach (DataRow r in capturé)
                {
                    if (r["idEspeceEnnemi"].ToString() == capture["idEspeceEnnemi"].ToString())
                    {
                        nbCapture = Convert.ToInt32(r["nombre"]);
                    }
                }
                newCapture[2] = nbCapture.ToString();
                newCapture[3] = (nbCapture * 100 / objectif).ToString();
                captureMissionActuelle.Rows.Add(newCapture);
            }
            dgvCapture.DataSource = captureMissionActuelle;

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bsJournalDeBord.MoveFirst();
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            bsJournalDeBord.MovePrevious();
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            bsJournalDeBord.MoveNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bsJournalDeBord.MoveLast();
        }

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
            {
                switch (rdb.Tag)
                {
                    case "1":
                        AfficherFormContact();
                        break;
                    case "2":
                        AfficherFormDepense();
                        break;
                    case "3":
                        AfficherFormEvent();
                        break;
                    case "4":
                        AfficherFormCapture();
                        break;
                    default:
                        MessageBox.Show("Une erreur est survenue");
                        break;
                }
            }
        }

        private void AfficherFormDepense()
        {
            grpFormDepense.Visible = true;
            grpFormCapture.Visible = false;
            grpFormContact.Visible = false;
            grpFormEvent.Visible = false;

            dtpDateDepense.MinDate = Convert.ToDateTime(missionActuelle["dateDepart"]);
            dtpDateDepense.MaxDate = Convert.ToDateTime(missionActuelle["dateRetour"]);

            cboTypeDepense.DataSource = MesDatas.DsGlobal.Tables["TypeDepense"];
            cboTypeDepense.DisplayMember = "libelle";
            cboTypeDepense.ValueMember = "id";
        }

        private void AfficherFormContact()
        {
         
            grpFormCapture.Visible = false;
            grpFormDepense.Visible = false;
            grpFormDepense.Visible = false;
            grpFormContact.Visible = true;

            dtpDateContact.MinDate = Convert.ToDateTime(missionActuelle["dateDepart"]);
            dtpDateContact.MaxDate = Convert.ToDateTime(missionActuelle["dateRetour"]);

            cboInformateur.DataSource = MesDatas.DsGlobal.Tables["Informateur"];
            cboInformateur.DisplayMember = "nom";
            cboInformateur.ValueMember = "nomCode";
        }

        private void AfficherFormEvent()
        {
            grpFormEvent.Visible = true;
            grpFormCapture.Visible = false;
            grpFormContact.Visible = false;
            grpFormDepense.Visible = false;

            dtpDateEvent.MinDate = Convert.ToDateTime(missionActuelle["dateDepart"]);
            dtpDateEvent.MaxDate = Convert.ToDateTime(missionActuelle["dateRetour"]);
        }

        private void AfficherFormCapture()
        {
            grpFormCapture.Visible = true;
            grpFormContact.Visible = false;
            grpFormDepense.Visible = false;
            grpFormEvent.Visible = false;
            DataTable especeEnnemi = new DataTable("EspeceEnnemi");
            especeEnnemi.Columns.Add("id", typeof(string));
            especeEnnemi.Columns.Add("nom", typeof(string));

            foreach (DataRow r in MesDatas.DsGlobal.Tables["Ennemi"].Rows)
            {
                DataRow dr = r.GetParentRow("FK_Espece_Ennemi");
                DataRow e = especeEnnemi.NewRow();
                e[0] = dr[0];
                e[1] = dr[1];
                especeEnnemi.Rows.Add(e);
            }

            cboCapture.DataSource = especeEnnemi;
            cboCapture.DisplayMember = "nom";
            cboCapture.ValueMember = "id";
        }

        private void btnValidationAjout_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tag = "";
            foreach (RadioButton rdb in grpChoixAjout.Controls.OfType<RadioButton>())
            {
                if (rdb.Checked)
                {
                    tag = rdb.Tag.ToString();
                }
            }

            switch (tag)
            {
                case "1":
                    ajoutContact();
                    break;
                case "2":
                    AjoutDepense();
                    break;
                case "3":
                    AjoutEvent();
                    break;
                case "4":
                    AjoutCapture();
                    break;
                default:
                    MessageBox.Show("Une erreur est survenue");
                    break;
            }
        }
        
        public void AjoutEvent()
        {
            SQLiteConnection co = Connexion.Connec;

            try
            {
                string date = dtpDateEvent.Value.ToString("yyyy-MM-dd");
                string commentaire = rtxtCommentaire.Text.Replace("'", "''");
                string request = $"INSERT INTO JournalDeBord(nomPlanete, numero, dateJ, commentaires) VALUES ('{missionActuelle["nomPlanete"].ToString()}','{missionActuelle["numero"].ToString()}','{date}','{commentaire}')";
                SQLiteCommand cmd = new SQLiteCommand(request,co);
                int res = cmd.ExecuteNonQuery();


                DataRow eventRow = MesDatas.DsGlobal.Tables["JournalDeBord"].NewRow();
                eventRow[0] = missionActuelle["nomPlanete"];
                eventRow[1] = missionActuelle["numero"];
                eventRow[2] = date;
                eventRow[3] = commentaire;
                MesDatas.DsGlobal.Tables["JournalDeBord"].Rows.Add(eventRow);
                MessageBox.Show("Évènement ajouté");

            } catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Connexion.FermerConnexion(); }
        }

        public void AjoutCapture()
        {

            SQLiteConnection co = Connexion.Connec;

            try
            {
                string nomPlanete = missionActuelle[0].ToString();
                string numeroMission = missionActuelle[1].ToString();
                string id = cboCapture.SelectedValue.ToString();
                int nombre = Convert.ToInt32(txtNombre.Text.Replace("'","''"));

                string verifRequest = $"SELECT Count(idEspeceEnnemi) FROM Capturer WHERE idEspeceEnnemi = '{id}' AND nomPlanete = '{missionActuelle["nomPlanete"]}' AND numeroMission = '{missionActuelle["numero"]}'";
                SQLiteCommand verifCmd = new SQLiteCommand(verifRequest, co);
                int res = Convert.ToInt32(verifCmd.ExecuteScalar());

                if (res == 0)
                {
                    string insertRequest = $"INSERT INTO Capturer(nomPlanete, numeroMission, idEspeceEnnemi, nombre) VALUES ('{nomPlanete}','{numeroMission}','{id}',{nombre})";

                    SQLiteCommand cmd = new SQLiteCommand(insertRequest, co);
                    int resInsert = cmd.ExecuteNonQuery();

                    DataRow drNewCapture = captureMissionActuelle.NewRow();
                    drNewCapture[0] = cboCapture.Text;
                    if (MesDatas.DsGlobal.Tables["ObjectifCapture"].Select($"idEspeceEnnemi = {id}").Length == 0)
                    {
                        drNewCapture[1] = 1;
                    }
                    else
                    {
                        drNewCapture[1] = MesDatas.DsGlobal.Tables["ObjectifCapture"].Select($"idEspeceEnnemi = {id}")[0][3];
                    }
                    drNewCapture[2] = nombre;
                    drNewCapture[3] = Convert.ToInt32(nombre) * 100 / Convert.ToInt32(drNewCapture[1]);
                    captureMissionActuelle.Rows.Add(drNewCapture);

                    MessageBox.Show("Capture ajoutée");
                }
                else
                {
                    string request = $"UPDATE Capturer SET nombre = nombre + {nombre} WHERE nomPlanete = '{nomPlanete}' AND numeroMission = '{numeroMission}' AND idEspeceEnnemi = '{id}'";
                    SQLiteCommand cmd = new SQLiteCommand(request, co);
                    int resUpdate = cmd.ExecuteNonQuery();
                    DataRow drCapture = captureMissionActuelle.Select($"[Nom de l'espèce] = '{cboCapture.Text}'")[0];
                    if (drCapture[1].ToString().Length == 0)
                    {
                        drCapture[1] = 1;
                    }
                    drCapture[2] = (Convert.ToInt32(drCapture[2]) + nombre).ToString();
                    drCapture[3] = Convert.ToInt32(drCapture[2]) * 100 / Convert.ToInt32(drCapture[1]);

                    MessageBox.Show("Capture ajoutée");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Connexion.FermerConnexion(); }
        }


        public void AjoutDepense()
        {
            SQLiteConnection co = Connexion.Connec;

            try
            {
                string nomPlanete = missionActuelle[0].ToString();
                string numeroMission = missionActuelle[1].ToString();
                int id;
                if (depenseMissionActuelle.Rows.Count != 0)
                {
                    id = Convert.ToInt32(depenseMissionActuelle.Compute("max([N°])",string.Empty)) + 1;
                }
                else
                {
                    id = 1;
                }
                string date = dtpDateDepense.Value.ToString("yyyy-MM-dd");
                string montant = txtMontantDepense.Text.Replace("'","''");
                string motif = rtxtMotifDepense.Text.Replace("'","''");
                string idTypeDepense = cboTypeDepense.SelectedValue.ToString();

                if (Convert.ToInt32(lblSolde.Text.Split(' ')[4]) - Convert.ToInt32(montant) < 0)
                {
                    throw new Exception("Le montant indiqué ferait dépasser le budget total de la mission");
                }

                string request = $"INSERT INTO Depense(nomPlanete, numeroMission, id, dateD, montant, motif, idTypeDepense) VALUES ('{nomPlanete}','{numeroMission}','{id}','{date}','{montant}','{motif}','{idTypeDepense}')";

                SQLiteCommand cmd = new SQLiteCommand(request, co);
                int res = cmd.ExecuteNonQuery();
                DataRow dr = depenseMissionActuelle.NewRow();
                dr[0] = id;
                dr[1] = date;
                dr[2] = motif;
                dr[3] = montant;
                dr[4] = MesDatas.DsGlobal.Tables["TypeDepense"].Select($"id = {idTypeDepense}")[0][1];
                depenseMissionActuelle.Rows.Add(dr);

                solde -= Convert.ToDouble(montant);

                lblSolde.Text = $"Solde après dépenses : {solde.ToString()}";
                MessageBox.Show("Dépense ajoutée");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Connexion.FermerConnexion(); }
        }

        public void ajoutContact()
        {
            SQLiteConnection co = Connexion.Connec;

            try
            {
                string nomPlanete = missionActuelle[0].ToString();
                string numeroMission = missionActuelle[1].ToString();
                string date = dtpDateContact.Value.ToString("yyyy-MM-dd");
                string sommeVersee = txtSomme.Text.Replace("'", "''");
                string appreciation = rtxtAppreciation.Text.Replace("'", "''");
                string nomCodeInformateur = cboInformateur.SelectedValue.ToString();
                string request = $"INSERT INTO Contact(nomPlanete, numeroMission, dateC, sommeVersee, appreciation, nomCodeInformateur) VALUES ('{nomPlanete}','{numeroMission}','{date}','{sommeVersee}','{appreciation}','{nomCodeInformateur}')";

                if (Convert.ToInt32(lblSolde.Text.Split(' ')[4]) - Convert.ToInt32(sommeVersee) < 0)
                {
                    throw new Exception("Le montant indiqué ferait dépasser le budget total de la mission");
                }

                SQLiteCommand cmd = new SQLiteCommand(request, co);
                int res = cmd.ExecuteNonQuery();
                DataRow dr = contactMissionActuelle.NewRow();
                dr[0] = date;
                dr[1] = sommeVersee;
                dr[2] = appreciation;
                dr[3] = cboInformateur.Text;
                contactMissionActuelle.Rows.Add(dr);

                solde -= Convert.ToDouble(sommeVersee);

                lblSolde.Text = $"Solde après dépenses : {solde.ToString()}";
                MessageBox.Show("Contact ajouté");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connexion.FermerConnexion();
            }
        }

        private void UpdateColorControls(Control c)
        {

            if (c is Label)
            {
                c.ForeColor = Couleur.getText;
            }
            else if (c is DataGridView)
            {
                DataGridView dgv = (DataGridView)c;
                dgv.RowHeadersDefaultCellStyle.BackColor = Couleur.getButton;
                dgv.RowHeadersDefaultCellStyle.ForeColor = Couleur.getText;
                dgv.RowHeadersDefaultCellStyle.SelectionBackColor = Couleur.getButtonHover;
                dgv.RowHeadersDefaultCellStyle.SelectionForeColor = Couleur.getText;
                dgv.ForeColor = Couleur.getText;
                dgv.BackgroundColor = Couleur.getBackground;
                dgv.DefaultCellStyle.BackColor = Couleur.getButton;
                dgv.DefaultCellStyle.ForeColor = Couleur.getText;
                dgv.DefaultCellStyle.SelectionBackColor = Couleur.getButtonHover;
                dgv.DefaultCellStyle.SelectionForeColor = Couleur.getText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Couleur.getButtonHover;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Couleur.getText;
            }
            else if (c is Button)
            {
                c.BackColor = Couleur.getButton;
                c.ForeColor = Couleur.getText;
            }
            else
            {
                c.BackColor = Couleur.getBackground;
                c.ForeColor = Couleur.getText;
            }
            foreach (Control subControl in c.Controls)
            {
                UpdateColorControls(subControl);
            }
        }

        private void btnInfoGenerale_Click(object sender, EventArgs e)
        {
            pnlInfoGenerale.Visible = true;
            pnlHistorique.Visible = false;
            pnlAjout.Visible = false;
        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            pnlInfoGenerale.Visible = false;
            pnlHistorique.Visible = true;
            pnlAjout.Visible = false;
        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            pnlInfoGenerale.Visible = false;
            pnlHistorique.Visible = false;
            pnlAjout.Visible = true;
        }

        private void rtxtMotifDepense_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Regex.IsMatch(e.KeyChar.ToString(), "^[a-zA-Z0-9,.!'\\s)\"]*$"))
            {
                e.Handled = false;
            }
        }

        private void txtMontantDepense_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            e.Handled = true;
            if (Regex.IsMatch(e.KeyChar.ToString(), "^[0-9,\b]$") && !txt.Text.Contains(","))
            {
                e.Handled = false;
            }
            if (Regex.IsMatch(e.KeyChar.ToString(), "^[0-9\b]$") && !Regex.IsMatch(txt.Text, "^[0-9]+[,][0-9]{2}"))
            {
                e.Handled = false;
            }
            if (Regex.IsMatch(e.KeyChar.ToString(), "^\b$"))
            { 
                e.Handled = false; 
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Regex.IsMatch(e.KeyChar.ToString(), "^[\\d\\b]$"))
            {
                e.Handled = false;
            }
        }

        private void btnGeneratePdf_Click(object sender, EventArgs e)
        {
            string identiteChef = $"{missionActuelle.GetParentRow("FK_Militaire_Chef").GetParentRow("FK_Membre_Militaire")[1].ToString()} {missionActuelle.GetParentRow("FK_Militaire_Chef").GetParentRow("FK_Membre_Militaire")[2].ToString()}";
            DataRow[] membreMission = missionActuelle.GetChildRows("FK_Mission_Composer");
            DataRow[] journalDeBord = missionActuelle.GetChildRows("FK_Mission_JournalDeBord");

            // Enregistre dans le dossier Downloads de l'utilisateur sous le nom rapport-<nom_mission>.pdf
            string chemin = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads",
                $"rapport-{missionActuelle["nomPlanete"]}{missionActuelle["numero"]}.pdf");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));


                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(15);

                            x.Item().Text($"Rapport de la mission {missionActuelle["nomPlanete"]}{missionActuelle["numero"]}")
                                    .SemiBold().FontSize(25).FontColor(Colors.DeepPurple.Medium);

                            x.Item().Text($"Date de départ : {missionActuelle["dateDepart"]}");
                            x.Item().Text($"Date de retour : {missionActuelle["dateRetour"]}");

                            x.Item().Text($"Sous la supervision de {identiteChef}")
                                    .FontSize(16)
                                    .Bold();

                            x.Item().Text($"Budget initial de {missionActuelle["Budget"]}€")
                                    .FontSize(14)
                                    .Bold();

                            x.Item().Text($"Feuille de route :")
                                    .FontSize(14)
                                    .Underline()
                                    .Bold();

                            x.Item().Text($"{missionActuelle["feuilleDeRoute"]}")
                                    .FontSize(12);

                            x.Item().PageBreak();
                            x.Item().Text("Liste des membres :")
                                    .FontSize(14)
                                    .Bold();

                            foreach (DataRow r in membreMission)
                            {
                                DataRow profil = r.GetParentRow("FK_Membre_Composer");
                                DataRow[] militaire = profil.GetChildRows("FK_Membre_Militaire");

                                if (militaire.Length != 0)
                                {
                                    x.Item().Text($"-> {profil["nom"]} {profil["prenom"]} : {militaire[0][1]}");
                                }

                                DataRow[] civil = profil.GetChildRows("FK_Membre_Civil");

                                if (civil.Length != 0)
                                {
                                    x.Item().Text($"-> {profil["nom"]} {profil["prenom"]} : {civil[0][1]}");

                                }
                            }

                            x.Item().Text("Journal de Bord :")
                                    .FontSize(14)
                                    .Bold();

                            int i = 1;

                            if (journalDeBord.Length > 0)
                            {
                                foreach (DataRow r in journalDeBord)
                                {
                                    x.Item().Text($"{i}) le {r["dateJ"]} -> {r["commentaires"]}");
                                }
                            }
                            else
                            {
                                x.Item().Text("Aucune entrée dans le journal de bord.");
                            }


                            x.Item().Text("Dépenses effectuées :")
                                    .FontSize(14)
                                    .Bold();

                            if (depenseMissionActuelle.Rows.Count > 0)
                            {
                                foreach (DataRow r in depenseMissionActuelle.Rows)
                                {
                                    x.Item().Text($"{r["Date"]} : {r["Motif"]} -> {r["Montant"]}");
                                }
                            }
                            else
                            {
                                x.Item().Text("Aucune dépense pour cette mission.");
                            }


                            x.Item().Text("Contacts avec les informateurs :")
                                    .FontSize(14)
                                    .Bold();

                            if (contactMissionActuelle.Rows.Count > 0)
                            {
                                foreach (DataRow r in contactMissionActuelle.Rows)
                                {
                                    x.Item().Text($"Le {r["Date"]} : {r["Appreciation"]}");
                                }
                            }
                            else
                            {
                                x.Item().Text("Aucun contact pour cette mission.");
                            }

                            x.Item().Text("Captures effectuées :")
                                    .FontSize(14)
                                    .Bold();

                            if (captureMissionActuelle.Rows.Count > 0)
                            {
                                foreach (DataRow r in captureMissionActuelle.Rows)
                                {
                                    x.Item().Text($"{r["Nom de l'espèce"]} : {r["Nombre de captures réalisées"]} sur {r["Objectif initial"]} ({r["Taux de réussite (en %)"]}%)");
                                }
                            }
                            else
                            {
                                x.Item().Text("Aucune capture pour cette mission.");
                            }


                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.CurrentPageNumber();
                        });
                });
            })
            .GeneratePdf(chemin);


            MessageBox.Show("PDF Généré");
        }
    }
}
