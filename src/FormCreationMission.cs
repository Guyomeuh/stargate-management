using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace LittlePlanete
{
    public partial class FormCreationMission : Form
    {
        private int nbMembres, membresRestants;
        private string planete;
        private int numeroMission;
        private bool fermetureAutorisee;
        private bool ajoutEffectué = false;
        SQLiteTransaction transaction;

        public FormCreationMission()
        {
            InitializeComponent();
        }

        private void FormCreationMission_Load(object sender, EventArgs e)
        {
            //Mettre en place la couleur de base du thème sur le formulaire
            BackColor = Couleur.getBackground;
            ForeColor = Couleur.getText;
            foreach (Control c in Controls)
            {
                UpdateColorControls(c);
            }

            load();
        }

        private void UpdateColorControls(Control c)
        {
            if (c is Label)
            {
                c.ForeColor = Couleur.getText;
            }
            if (c is System.Windows.Forms.Button)
            {
                c.BackColor = Couleur.getButton;
                c.ForeColor = Couleur.getText;
            }
        }

        private void load()
        {
            fermetureAutorisee = true;
            groupBox.Visible = false;
            SQLiteCommand cmd = new SQLiteCommand(Connexion.Connec);
            cmd.CommandText = @"select nom from planete";

            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBoxPlanete.Items.Add(reader.GetString(0));
            }

            reloadComboBoxChef();

            cmd = new SQLiteCommand(Connexion.Connec);
            cmd.CommandText = @"select count(*) from Membre";
            trackBarNbMembres.Maximum = Convert.ToInt32(cmd.ExecuteScalar());

            Connexion.FermerConnexion();

            // permet de rafraîchir le nom de la mission: trigger selectedIdexChanged sans que l'index déborde
            comboBoxPlanete.SelectedIndex = (comboBoxPlanete.SelectedIndex + 1) % comboBoxPlanete.Items.Count; 
            richTextBoxFeuilleRoute.Text = String.Empty;
            textBoxBudget.Text = String.Empty;
            textBoxDatabaz.Text = String.Empty;
            textBoxNbCaptures.Text = String.Empty;
            trackBarNbMembres.Value = 1;
            dateTimePickerDepart.MaxDate = DateTime.Today; // Pour éviter le crash lorsque la date de retour est avant aujourd'hui
            dateTimePickerDepart.Value = DateTime.Today;
            dateTimePickerRetour.Value = DateTime.Today;

            for (int i = 0; i < checkedListBoxMembres.Items.Count; i++)
            {
                checkedListBoxMembres.SetItemChecked(i, false);
            }

            listBoxCaptures.Items.Clear();
        }

        private void reloadComboBoxChef()
        {
            string depart = dateTimePickerDepart.Value.ToString("yyyy-MM-dd");
            string retour = dateTimePickerRetour.Value.ToString("yyyy-MM-dd");

            SQLiteCommand cmd = new SQLiteCommand(Connexion.Connec);
            cmd.CommandText = $@"SELECT DISTINCT m.grade || ' · ' || me.nom || ' ' || me.prenom, me.matricule
            FROM Militaire m
            JOIN Membre me ON m.matriculeMembre = me.matricule
            WHERE me.matricule NOT IN(
                SELECT c.matriculeMembre
                FROM Composer c
                JOIN Mission mi ON c.nomPlanete = mi.nomPlanete AND c.numeroMission = mi.numero
                WHERE mi.dateDepart <= '{retour}' AND mi.dateRetour >= '{depart}')
            ORDER BY m.grade";

            SQLiteDataReader reader = cmd.ExecuteReader();
            Dictionary<string, string> result = new Dictionary<string, string>();

            while (reader.Read())
            {
                result.Add(reader.GetString(0), reader.GetString(1));
            }

            comboBoxChef.DataSource = new BindingSource(result, null);
            comboBoxChef.DisplayMember = "Key";
            comboBoxChef.ValueMember = "Value";
        }

        private void nbMembreDispoTrackBar()
        {
            // pour éviter les problèmes de valeur supérieure au maximum après le recalcul du maximum
            trackBarNbMembres.Value = 1; 
            string depart = dateTimePickerDepart.Value.ToString("yyyy-MM-dd");
            string retour = dateTimePickerRetour.Value.ToString("yyyy-MM-dd");

            SQLiteCommand cmd = new SQLiteCommand(Connexion.Connec);
            cmd.CommandText = $@"SELECT count(DISTINCT me.matricule)
                                FROM Membre me
                                WHERE me.matricule NOT IN (
                                    SELECT c.matriculeMembre
                                    FROM Composer c
                                    JOIN Mission mi ON c.nomPlanete = mi.nomPlanete AND c.numeroMission = mi.numero
                                    WHERE mi.dateDepart <= '{retour}' AND mi.dateRetour >= '{depart}')";

            object res = cmd.ExecuteScalar();

            trackBarNbMembres.Maximum = Convert.ToInt32(res) -1;
        }

        private int nbMissionsPlanete(String planete)
        {
            SQLiteCommand cmd = new SQLiteCommand(Connexion.Connec);
            cmd.CommandText = $@"select count(*) 
            from Mission 
            where lower(nomPlanete) = lower('{comboBoxPlanete.SelectedItem}')";

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void comboBoxPlanete_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(comboBoxPlanete, "");
            int nbMissions = nbMissionsPlanete(comboBoxPlanete.SelectedItem.ToString());
            labelNomMission.Text = $"Nom de mission: {comboBoxPlanete.SelectedItem}{nbMissions + 1}";
        }

        private void dateTimePickerDepart_ValueChanged(object sender, EventArgs e)
        {
            reloadComboBoxChef();
            nbMembreDispoTrackBar();
            dateTimePickerRetour.MinDate = dateTimePickerDepart.Value;
            int nbJours = calculerTempsMission().Days;

            labelDuree.Text = $"Durée: {nbJours} jour";

            if (nbJours > 1)
            {
                labelDuree.Text += "s";
            }
        }

        private void dateTimePickerRetour_ValueChanged(object sender, EventArgs e)
        {
            reloadComboBoxChef();
            nbMembreDispoTrackBar();
            dateTimePickerDepart.MaxDate = dateTimePickerRetour.Value;
            int nbJours = calculerTempsMission().Days;

            labelDuree.Text = $"Durée: {nbJours} jour";

            if (nbJours > 1)
            {
                labelDuree.Text += "s";
            }
        }

        private TimeSpan calculerTempsMission()
        {
            DateTime depart = dateTimePickerDepart.Value;
            DateTime retour = dateTimePickerRetour.Value;

            return retour.Subtract(depart);
        }

        private void trackBarNbMembres_Scroll(object sender, EventArgs e)
        {
            labelMembres.Text = trackBarNbMembres.Value.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider.SetError((TextBox)sender, "");
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            bool erreur = false;
            if (comboBoxPlanete.SelectedIndex < 0) // si rien n'est sélectionné
            {
                errorProvider.SetError(comboBoxPlanete, "Le nom de planète doit être sélectionné");
                erreur = true;
            }
            if (richTextBoxFeuilleRoute.Text == String.Empty)
            {
                errorProvider.SetError(richTextBoxFeuilleRoute, "La feuille de route doit être saisie");
                erreur = true;
            }
            if (textBoxDatabaz.Text == String.Empty)
            {
                errorProvider.SetError(textBoxDatabaz, "L'objectif de databaz doit être saisi");
                erreur = true;
            }
            if (textBoxBudget.Text == String.Empty)
            {
                errorProvider.SetError(textBoxBudget, "Le budget doit être saisi");
                erreur = true;
            }
            if (erreur)
            {
                return;
            }

            transaction = Connexion.Connec.BeginTransaction();
            try
            {

                planete = comboBoxPlanete.SelectedItem.ToString();
                numeroMission = nbMissionsPlanete(planete) + 1;
                this.nbMembres = trackBarNbMembres.Value;
                this.membresRestants = this.nbMembres - 1; // pour compter le chef de mission avec
                string depart = dateTimePickerDepart.Value.ToString("yyyy-MM-dd");
                string retour = dateTimePickerRetour.Value.ToString("yyyy-MM-dd");
                string matriculeChef = comboBoxChef.SelectedValue.ToString();
                string feuille = richTextBoxFeuilleRoute.Text;
                feuille = feuille.Replace("'", "''");
                int databaz = int.Parse(this.textBoxDatabaz.Text);
                int budget = int.Parse(textBoxBudget.Text);

                SQLiteCommand cmd = new SQLiteCommand(Connexion.Connec);
                cmd.CommandText = $@"insert into Mission (nomPlanete, numero, nbMembreRequis, dateDepart, dateRetour, matriculeChef, feuilleDeRoute, objectifDatabaz, budget) 
                values ('{planete}', {numeroMission}, {nbMembres}, '{depart}', '{retour}', '{matriculeChef}', '{feuille}', {databaz}, {budget})";

                cmd.ExecuteNonQuery();

                cmd = new SQLiteCommand(Connexion.Connec);
                cmd.CommandText = $@"INSERT INTO Composer (nomPlanete, numeroMission, matriculeMembre) 
                                SELECT '{planete}', {numeroMission}, '{matriculeChef}'
                                WHERE NOT EXISTS (
                                    SELECT 1 FROM Composer WHERE nomPlanete = '{planete}'
                                    AND numeroMission = {numeroMission}
                                    AND matriculeMembre = '{matriculeChef}')";

                if (cmd.ExecuteNonQuery() == 1)
                {
                    groupBox.Visible = true;
                    fermetureAutorisee = false;
                    part2();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show($"Erreur lors de l'insertion : {ex.Message}");
            }
        }

        private void richTextBoxFeuilleRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider.SetError(richTextBoxFeuilleRoute, "");
        }

        private void part2()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string depart = dateTimePickerDepart.Value.ToString("yyyy-MM-dd");
            string retour = dateTimePickerRetour.Value.ToString("yyyy-MM-dd");
            string chef = comboBoxChef.SelectedValue.ToString();

            SQLiteCommand cmd = new SQLiteCommand(Connexion.Connec);
            cmd.CommandText = $@"SELECT DISTINCT me.nom || ' ' || me.prenom, me.matricule
FROM Membre me
WHERE me.matricule NOT IN (
    SELECT c.matriculeMembre
    FROM Composer c
    JOIN Mission mi ON c.nomPlanete = mi.nomPlanete AND c.numeroMission = mi.numero
    WHERE mi.dateDepart <= '{retour}' AND mi.dateRetour >= '{depart}')
AND me.matricule != '{chef}'
ORDER BY me.nom, me.prenom;";

            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(reader.GetString(0), reader.GetString(1));
            }

            checkedListBoxMembres.DataSource = new BindingSource(result, null);
            checkedListBoxMembres.DisplayMember = "Key";
            checkedListBoxMembres.ValueMember = "Value";

            labelMembresRestants.Text = membresRestants + " restant(s)";

            cmd = new SQLiteCommand(Connexion.Connec);
            cmd.CommandText = $@"SELECT DISTINCT es.nom
FROM ennemi e JOIN Espece es ON e.idEspece = es.id";

            List<string> r = new List<string>();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                r.Add(reader.GetString(0));
            }

            comboBoxEnnemis.DataSource = new BindingSource(r, null);
            comboBoxEnnemis.DisplayMember = "Key";
        }

        private void checkedListBoxMembres_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            errorProvider.SetError(checkedListBoxMembres, "");

            // Nombre actuellement cochés
            int checkedCount = checkedListBoxMembres.CheckedItems.Count;

            // ItemCheck est déclenché avant la modification, on simule donc l'état futur.
            if (e.NewValue == CheckState.Checked)
                checkedCount++;
            else if (e.NewValue == CheckState.Unchecked)
                checkedCount--;

            // Si on dépasse la limite, on annule le cochage
            if (checkedCount > this.nbMembres)
            {
                e.NewValue = CheckState.Unchecked;
                return;
            }

            // Mise à jour du label après la modification
            BeginInvoke(new Action(() =>
            {
                membresRestants = this.nbMembres - checkedListBoxMembres.CheckedItems.Count;
                labelMembresRestants.Text = $"{membresRestants} restant(s)";
            }));
        }

        private void textBoxNbCaptures_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider.SetError(textBoxNbCaptures, "");
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void buttonAjouterCapture_Click(object sender, EventArgs e)
        {
            bool erreur = false;
            if (comboBoxEnnemis.SelectedIndex == -1)
            {
                errorProvider.SetError(comboBoxEnnemis, "Une espèce ennemie doit être sélectionnée");
                erreur = true;
            }
            if (textBoxNbCaptures.Text == "" || Convert.ToInt32(textBoxNbCaptures.Text) == 0)
            {
                errorProvider.SetError(textBoxNbCaptures, "Un nombre d'ennemis supérieur à 0 doit être saisi");
                erreur = true;
            }
            if (erreur) return;

            bool trouve = false;
            string espece = comboBoxEnnemis.SelectedItem.ToString();
            int nbCaptures = int.Parse(textBoxNbCaptures.Text);

            for (int i = 0; i < listBoxCaptures.Items.Count; i++)
            {
                string ligne = listBoxCaptures.Items[i].ToString();

                string[] parties = ligne.Split('\t');

                if (parties.Length >= 2 && parties[0] == espece)
                {
                    int ancienNb = int.Parse(parties[1]);
                    int nouveauNb = ancienNb + nbCaptures;

                    listBoxCaptures.Items[i] = $"{espece}\t{nouveauNb}";
                    trouve = true;
                    break;
                }
            }

            if (!trouve)
            {
                listBoxCaptures.Items.Add($"{espece}\t{nbCaptures}");
            }
        }

        private void comboBoxEnnemis_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(comboBoxEnnemis, "");
        }

        private void listBoxCaptures_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listBoxCaptures.SelectedIndex != -1)
            {
                listBoxCaptures.Items.RemoveAt(listBoxCaptures.SelectedIndex);
            }
        }

        private void FormCreationMission_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!fermetureAutorisee && !ajoutEffectué)
            {
                e.Cancel = true;
                MessageBox.Show("Les membres ainsi que les objectifs de captures doivent être renseignés");
            }
            else if (ajoutEffectué)
            {
                this.DialogResult = DialogResult.OK;
            }
            else if (!ajoutEffectué)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            fermetureAutorisee = true;
            DialogResult = DialogResult.Cancel;
        }

        private void buttonValiderCapturesMembres_Click(object sender, EventArgs e)
        {
            if (membresRestants != 0) {
                MessageBox.Show(membresRestants.ToString());
                errorProvider.SetError(checkedListBoxMembres, "Le nombre de membres requis doit être sélectionné");
                return;
            }

            foreach (KeyValuePair<string, string> item in checkedListBoxMembres.CheckedItems)
            {
                string matricule = item.Value.ToString();

                SQLiteCommand cmd = new SQLiteCommand(Connexion.Connec);
                cmd.CommandText = $@"INSERT INTO Composer (nomPlanete, numeroMission, matriculeMembre) 
                                    SELECT '{planete}', {numeroMission}, '{matricule}'
                                    WHERE NOT EXISTS (
                                        SELECT 1 FROM Composer WHERE nomPlanete = '{planete}'
                                        AND numeroMission = {numeroMission}
                                        AND matriculeMembre = '{matricule}')";

                cmd.ExecuteNonQuery();
            }

            try
            {
                foreach (string item in listBoxCaptures.Items)
                {
                    string[] parties = item.Split('\t');

                    SQLiteCommand cmdSelect = new SQLiteCommand(Connexion.Connec);
                    cmdSelect.Transaction = transaction;
                    cmdSelect.CommandText = $"SELECT id FROM Espece WHERE lower(nom) = lower('{parties[0]}')";
                    int idEspece = Convert.ToInt32(cmdSelect.ExecuteScalar());

                    int nombre = int.Parse(parties[1]);

                    SQLiteCommand cmdInsert = new SQLiteCommand(Connexion.Connec);
                    cmdInsert.Transaction = transaction;
                    cmdInsert.CommandText = $@"
                        INSERT OR IGNORE INTO Capturer
                        (nomPlanete, numeroMission, idEspeceEnnemi, nombre)
                        VALUES
                        ('{planete}', {numeroMission}, {idEspece}, {nombre})";

                    cmdInsert.ExecuteNonQuery();
                }

                ajoutEffectué = true;
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show($"Erreur lors de l'insertion : {ex.Message}");
            }
            finally
            {
                transaction.Dispose();
            }

            MessageBox.Show("Membre(s) et objectif(s) de capture(s) ajoutés");

            load(); // recommence l'ajout de mission (pour pouvoir en ajouter plusieurs sans se reconnecter)
        }
    }
}
