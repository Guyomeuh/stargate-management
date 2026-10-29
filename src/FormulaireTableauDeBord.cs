using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlPlanetes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Text.RegularExpressions;

namespace LittlePlanete
{
    public partial class FrmTableauDeBord : Form
    {
        int triEtat = 0;
        bool triAlpha = true;
        SQLiteConnection co;

        // initialisation d'un booleen qui vérifie si on est bien sur le bouton de rechrche d'espèce avant de filtrer directement par combobox pour éviter un affichage directement au chragement du form
        // on le met à faux pour tous les boutons, sauf celui de la recherche d'espèces pour permettre la recherche directement en sélectionnant la valeur dans la combobox
        bool estSurEspece = false;

        // vérification pour le filtre des statistiques afin de voir si on peut filtrer par nom ou pas
        bool filtrePossible = false;
        public FrmTableauDeBord()
        {
            InitializeComponent();
        }
        private void FrmTableauDeBord_Load(object sender, EventArgs e)
        {
            // Lors du chargement du formulaire, on remplit le DataSet local à partir de la base de donnée,
            // on ajoute les relations entre les différentes tables du DataSet pour pouvoir faire des liens entre les différentes données,
            // on affiche les différentes planètes et espèces dans le tableau de bord et on prépare les éléments pour la recherche d'espèces
            RemplissageDS();
            AjoutRelation();
            InfosPlanetes();
            InfosEspeces();
            ChargementElementsGrpEspeces();
            ChargementLogo();
        
            ModifDate();
            ActualisationTDB(cboFiltrePlanete.Text,cboFiltreEtat.Text);


            //Mettre en place la couleur de base du thème sur le formulaire
            BackColor = Couleur.getBackground;
            ForeColor = Couleur.getText;
            foreach (Control c in Controls)
            {
                UpdateColorControls(c);
            }

            cboFiltrePlanete.Items.Add("");
            foreach (DataRow r in MesDatas.DsGlobal.Tables["Planete"].Rows)
            {
                cboFiltrePlanete.Items.Add(r[0]);
            }
            cboFiltrePlanete.SelectedIndex = 0;
        }

        private void UpdateDataSet()
        {
            // Sert à mettre à jour le DataSet quand il y a un ajout de mission
            MesDatas.DsGlobal.Reset();
            RemplissageDS();
        }

        private void RemplissageDS()
        {
            // Remplit le DataSet Local à partir de la base de donnée
            co = Connexion.Connec;
            try
            {
                DataTable mesDT = co.GetSchema("Tables");

                foreach (DataRow r in mesDT.Rows)
                {
                    string request = $"SELECT * FROM {r[2].ToString()}";
                    SQLiteCommand cmd = new SQLiteCommand(request, co);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(MesDatas.DsGlobal, r[2].ToString());
                }   
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Connexion.FermerConnexion(); }
        }

        private void ModifDate()
        {
            // Sert à modifier le format de toute les dates dans le DataSet pour avoir le même format partout
            foreach (DataRow r in MesDatas.DsGlobal.Tables["Depense"].Rows)
            {
                r[3] = Convert.ToDateTime(r[3]).ToString("yyyy-MM-dd");

            }
            foreach (DataRow r in MesDatas.DsGlobal.Tables["Allie"].Rows)
            {
                r[1] = Convert.ToDateTime(r[1]).ToString("yyyy-MM-dd"); 
            }
            foreach (DataRow r in MesDatas.DsGlobal.Tables["Mission"].Rows)
            {
                r[3] = Convert.ToDateTime(r[3]).ToString("yyyy-MM-dd");
                r[4] = Convert.ToDateTime(r[4]).ToString("yyyy-MM-dd");

            }
            foreach (DataRow r in MesDatas.DsGlobal.Tables["Contact"].Rows)
            {
                r[2] = Convert.ToDateTime(r[2]).ToString("yyyy-MM-dd");
            }
            foreach (DataRow r in MesDatas.DsGlobal.Tables["JournalDeBord"].Rows)
            {
                r[2] = Convert.ToDateTime(r[2]).ToString("yyyy-MM-dd");
            }
            foreach (DataRow r in MesDatas.DsGlobal.Tables["Membre"].Rows)
            {
                r[3] = Convert.ToDateTime(r[3]).ToString("yyyy-MM-dd");
            }
        }

        private void AjoutRelation()
        {
            try
            {
                // Relations Tableau de bord
                MesDatas.DsGlobal.Relations.Add("FK_Militaire_Chef", MesDatas.DsGlobal.Tables["Militaire"].Columns["matriculeMembre"], MesDatas.DsGlobal.Tables["Mission"].Columns["matriculeChef"]);
                MesDatas.DsGlobal.Relations.Add("FK_Membre_Militaire", MesDatas.DsGlobal.Tables["Membre"].Columns["matricule"], MesDatas.DsGlobal.Tables["Militaire"].Columns["matriculeMembre"]);
                MesDatas.DsGlobal.Relations.Add("FK_Membre_Civil", MesDatas.DsGlobal.Tables["Membre"].Columns["matricule"], MesDatas.DsGlobal.Tables["Civil"].Columns["matriculeMembre"]);
                MesDatas.DsGlobal.Relations.Add("FK_Membre_Composer", MesDatas.DsGlobal.Tables["Membre"].Columns["matricule"], MesDatas.DsGlobal.Tables["Composer"].Columns["matriculeMembre"]);
                DataColumn[] missionPK = new DataColumn[] { MesDatas.DsGlobal.Tables["Mission"].Columns["nomPlanete"], MesDatas.DsGlobal.Tables["Mission"].Columns["numero"] };
                DataColumn[] depensePK = new DataColumn[] { MesDatas.DsGlobal.Tables["Depense"].Columns["nomPlanete"], MesDatas.DsGlobal.Tables["Depense"].Columns["numeroMission"] };
                MesDatas.DsGlobal.Relations.Add("FK_Mission_Depense", missionPK, depensePK);
                DataColumn[] composer = new DataColumn[] { MesDatas.DsGlobal.Tables["Composer"].Columns["nomPlanete"], MesDatas.DsGlobal.Tables["Composer"].Columns["numeroMission"] };
                MesDatas.DsGlobal.Relations.Add("FK_Mission_Composer", missionPK, composer);
                DataColumn[] objectifCapture = new DataColumn[] { MesDatas.DsGlobal.Tables["ObjectifCapture"].Columns["nomPlanete"], MesDatas.DsGlobal.Tables["ObjectifCapture"].Columns["numeroMission"] };
                MesDatas.DsGlobal.Relations.Add("FK_Mission_ObjectifCapture", missionPK, objectifCapture);
                MesDatas.DsGlobal.Relations.Add("FK_Espece_ObjectifCapture", MesDatas.DsGlobal.Tables["Espece"].Columns["id"] , MesDatas.DsGlobal.Tables["ObjectifCapture"].Columns["idEspeceEnnemi"]);

                // Relations Planètes
                
                // nom (Planete) <-> nomPlanete (Habiter)
                MesDatas.DsGlobal.Relations.Add("FK_Planete_Habiter", MesDatas.DsGlobal.Tables["Planete"].Columns["nom"], MesDatas.DsGlobal.Tables["Habiter"].Columns["nomPlanete"]);
                // id (Espece) <-> idEspece (Habiter)
                MesDatas.DsGlobal.Relations.Add("FK_Espece_Habiter", MesDatas.DsGlobal.Tables["Espece"].Columns["id"], MesDatas.DsGlobal.Tables["Habiter"].Columns["idEspece"]);

                // id (Espece) <-> idEspece (Allie)
                MesDatas.DsGlobal.Relations.Add("FK_Espece_Allie", MesDatas.DsGlobal.Tables["Espece"].Columns["id"], MesDatas.DsGlobal.Tables["Allie"].Columns["idEspece"]);

                // nom (Planete) <-> nomPlanete (Mission)
                MesDatas.DsGlobal.Relations.Add("FK_Planete_Mission", MesDatas.DsGlobal.Tables["Planete"].Columns["nom"], MesDatas.DsGlobal.Tables["Mission"].Columns["nomPlanete"]);

                // Journal De Bord > Mission
                DataColumn[] journalDeBord = new DataColumn[] { MesDatas.DsGlobal.Tables["JournalDeBord"].Columns["nomPlanete"], MesDatas.DsGlobal.Tables["JournalDeBord"].Columns["numero"] };
                MesDatas.DsGlobal.Relations.Add("FK_Mission_JournalDeBord", missionPK, journalDeBord);

                // Contact > Mission
                DataColumn[] contact = new DataColumn[] { MesDatas.DsGlobal.Tables["Contact"].Columns["nomPlanete"], MesDatas.DsGlobal.Tables["Contact"].Columns["numeroMission"] };
                MesDatas.DsGlobal.Relations.Add("FK_Mission_Contact", missionPK, contact);

                // Contact > Informateur
                MesDatas.DsGlobal.Relations.Add("FK_Informateur_Contact", MesDatas.DsGlobal.Tables["Informateur"].Columns["nomCode"], MesDatas.DsGlobal.Tables["Contact"].Columns["nomCodeInformateur"]);

                // Depense > Type Depense
                MesDatas.DsGlobal.Relations.Add("FK_TypeDepense_Depense", MesDatas.DsGlobal.Tables["TypeDepense"].Columns["id"], MesDatas.DsGlobal.Tables["Depense"].Columns["idTypeDepense"]);
                
                // Capture > Mission
                DataColumn[] capture = new DataColumn[] { MesDatas.DsGlobal.Tables["Capturer"].Columns["nomPlanete"], MesDatas.DsGlobal.Tables["Capturer"].Columns["numeroMission"] };
                MesDatas.DsGlobal.Relations.Add("FK_Mission_Capturer", missionPK, capture);
                
                // Capturer > Espece
                MesDatas.DsGlobal.Relations.Add("FK_Espece_Capturer", MesDatas.DsGlobal.Tables["Espece"].Columns["id"], MesDatas.DsGlobal.Tables["Capturer"].Columns["idEspeceEnnemi"]);

                // Ennemi > Espece
                MesDatas.DsGlobal.Relations.Add("FK_Espece_Ennemi", MesDatas.DsGlobal.Tables["Espece"].Columns["id"], MesDatas.DsGlobal.Tables["Ennemi"].Columns["idEspece"]);


            } 
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }
        }
        private void ActualisationTDB(String filtrePlanète, String filtreEtat)
        {
            // Permet d'actualiser le tableau de bord en fonction des filtres choisis
            grpFiltreMission.Visible = true;
            grpTableauDeBord.Visible = true;

            // On compte le nombre de mission trouvée
            int missionTrouvee = 0;

            // Création du filtre final en fonction des choix de l'utilisateur dans les combobox
            string filtreFinal = "";
            if (filtrePlanète.Length != 0)
            {
                filtreFinal = $"nomPlanete = '{filtrePlanète}'";
                if (filtreEtat == "En cours")
                {
                    filtreFinal += $" AND dateRetour > #{DateTime.Today.ToString("yyyy-MM-dd")}#";
                }
                else if (filtreEtat == "Terminée")
                {
                    filtreFinal += $" AND dateRetour <= #{DateTime.Today.ToString("yyyy - MM - dd")}#";
                }
            }
            else if (filtrePlanète.Length == 0 && filtreEtat.Length != 0) 
            {
                if (filtreEtat == "En cours")
                {
                    filtreFinal = $"dateRetour > #{DateTime.Today.ToString("yyyy-MM-dd")}#";
                }
                else if (filtreEtat == "Terminée")
                {
                    filtreFinal = $"dateRetour <= #{DateTime.Today.ToString("yyyy - MM - dd")}#";
                }
            }

            string triFinal = (triAlpha) ? "nomPlanete ASC" : "nomPlanete DESC";

            // On vide le Flow Layout Pannel pour ne pas avoir d'affichage en double à chaque actualisation
            pnlTDB.Controls.Clear();
            try
            {
                List<String[]> buffer = new List<String[]>();
                // Remplis le Flow Layout Pannel avec les UserControl MissionResume
                foreach (DataRow r in MesDatas.DsGlobal.Tables["Mission"].Select($"{filtreFinal}",$"{triFinal}"))
                {

                    // On façonne le résumé de la mission pour l'affichage dans le tableau de bord
                    missionTrouvee++;
                    string nomMission = r["NomPlanete"].ToString() + r["numero"].ToString();
                    string strDateDepart = r["dateDepart"].ToString();
                    DateTime dateRetour = DateTime.Parse(r["dateRetour"].ToString());
                    DateTime dateDepart = DateTime.Parse(r["dateDepart"].ToString());
                    TimeSpan duree = dateRetour.Subtract(dateDepart);
                    string strDuree = duree.ToString("dd");
                    string grade = r.GetParentRow("FK_Militaire_Chef")[1].ToString();
                    string identite = $"{r.GetParentRow("FK_Militaire_Chef").GetParentRow("FK_Membre_Militaire")[1].ToString()}" +
                        $" {r.GetParentRow("FK_Militaire_Chef").GetParentRow("FK_Membre_Militaire")[2].ToString()}";
                    string chef = $"{identite} : {grade}";


                    // En fonction du tri choisi, on affiche les missions qui correspondent au tri d'état dans le Flow Layout Pannel
                    // Et les autres dans un buffer pour les afficher à la fin (afin d'avoir les missions qui ne correspondent pas au filtre d'état à la fin du tableau de bord)
                    if (triEtat == -1)
                    {
                        if (dateRetour <= DateTime.Today)
                        {
                            buffer.Add(new String[] {nomMission, strDateDepart, strDuree, chef});
                        }
                        else
                        {
                            MissionResume mr = new MissionResume(nomMission, strDateDepart, strDuree, chef);
                            mr.afficher += AfficherResume;
                            pnlTDB.Controls.Add(mr);
                        }
                    }
                    else if (triEtat == 1)
                    {
                        if (dateRetour > DateTime.Today)
                        {
                            buffer.Add(new String[] { nomMission, strDateDepart, strDuree, chef });
                        }
                        else
                        {
                            MissionResume mr = new MissionResume(nomMission, strDateDepart, strDuree, chef);
                            mr.afficher += AfficherResume;
                            pnlTDB.Controls.Add(mr);
                        }
                    }
                    else if (triEtat == 0)
                    {
                        MissionResume mr = new MissionResume(nomMission, strDateDepart, strDuree, chef);
                        mr.afficher += AfficherResume;
                        pnlTDB.Controls.Add(mr);
                    }
                    
                }

                foreach (String[] str in buffer)
                {
                    MissionResume etatMr = new MissionResume(str[0], str[1], str[2], str[3]);
                    etatMr.afficher += AfficherResume;
                    pnlTDB.Controls.Add(etatMr);
                }
                grpTableauDeBord.Text = "Nombre de mission trouvée : " + missionTrouvee;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AfficherResume(object sender, EventArgs e)
        {
            // Permet d'afficher la fiche de mission en cliquant sur une mission

            MissionResume mr = (MissionResume)sender;
            FormulaireMission frm = new FormulaireMission(mr.GetMission);
            frm.ShowDialog();
        }
        private void btnTDB_Click(object sender, EventArgs e)
        {
            
            pnlTDB.Visible = true;
            grpFiltreMission.Visible = true;
            grpTableauDeBord.Visible = true;
            pnlPlanetes.Visible = false;
            pnlEspeces.Visible = false;
            pnlAllies.Visible = false;
            pnlEnnemis.Visible = false;
            grpEspeces.Visible = false;
            pnlStats.Visible = false;
            estSurEspece = false;
            ActualisationTDB(cboFiltrePlanete.Text, cboFiltreEtat.Text);
        }

        private void btnNouvelleMission_Click(object sender, EventArgs e)
        {

            // Permet d'ajouter une mission en cliquant sur le bouton "Nouvelle Mission" et de mettre à jour le tableau de bord en conséquence
            FormConnexion connexion = new FormConnexion();
            FormCreationMission formCreationMission = new FormCreationMission();
            connexion.ShowDialog();
            if (connexion.DialogResult == DialogResult.OK)
            {
                formCreationMission.ShowDialog();
            }
            if (formCreationMission.DialogResult == DialogResult.OK)
            {
                UpdateDataSet();
                AjoutRelation();
                ActualisationTDB(cboFiltrePlanete.Text, cboFiltreEtat.Text);
            }
            else if (formCreationMission.DialogResult == DialogResult.Cancel) { return; }
            estSurEspece = false;
        }

        private void btnRaces_Click(object sender, EventArgs e)
        {
            pnlTDB.Visible = false;
            grpFiltreMission.Visible = false;
            grpTableauDeBord.Visible = false;
            pnlPlanetes.Visible = false;
            pnlEspeces.Visible = true;
            pnlAllies.Visible = false;
            pnlEnnemis.Visible = false;
            grpEspeces.Visible = true;
            pnlStats.Visible = false;
            // On peut mettre ce vérificateur à true pour checker l'état des combobox dès qu'il change
            estSurEspece = true;
        }

        private void btnPlanetes_Click(object sender, EventArgs e)
        {
            pnlTDB.Visible = false;
            grpFiltreMission.Visible = false;
            grpTableauDeBord.Visible = false;
            pnlPlanetes.Visible = true;
            pnlEspeces.Visible = false;
            pnlAllies.Visible = false;
            pnlEnnemis.Visible = false;
            grpEspeces.Visible = false;
            pnlStats.Visible = false;

            estSurEspece = false;
        }

        private void InfosEspeces()
        {
            // Préparation du panel pour la recherche des espèces
            
            pnlEspeces.Controls.Clear();
            grpFiltreMission.Visible = false;
            grpTableauDeBord.Visible = false;
            pnlEspeces.Visible = false;
            grpEspeces.Visible = false;
            pnlAllies.Visible = false;
            pnlStats.Visible = false;
            pnlEnnemis.Visible = false;
            rdbAllies.Checked = false;
            rdbEnnemis.Checked = false;

            // Initialisation des éléments pour la recherche (avec ou sans filtre)
            DataRow[] tab;
            DataTable dt = new DataTable();
            bool filtreEstPresent = false;
            bool resultatExiste = true;

            // S'il y a un filtre à appliquer, on prend ce qui est indiqué dans les combobox et/ou dans la Textbox pour créer un filtre
            if (cboCouleur.SelectedIndex > 0 || txtNomEspece.Text != string.Empty || cboPlanete.SelectedIndex > 0)
            {
                // On ajuste le filtre en fonction des indications de recherche
                string filtre = "";
                // Pour la couleur
                if (cboCouleur.SelectedIndex != 0)
                {
                    filtre += "couleur = '" + cboCouleur.SelectedValue + "'";
                }
                // Si deux filtres sont choisis, on rajoute un 'and' dans le filtre pour relié les deux conditions
                if ((cboCouleur.SelectedIndex != 0 && txtNomEspece.Text != string.Empty) || (cboCouleur.SelectedIndex > 0 && cboPlanete.SelectedIndex != 0))
                {
                    filtre += " and ";
                }
                // Pour le nom
                if (txtNomEspece.Text != string.Empty)
                {
                    filtre += "nom like '" + txtNomEspece.Text + "%'";
                }

                // Si les trois filtres sont choisis ou si UNIQUEMENT les deux filtres Nom et Planete sont choisi
                if ((cboCouleur.SelectedIndex != 0 && txtNomEspece.Text != string.Empty && cboPlanete.SelectedIndex != 0) || (cboPlanete.SelectedIndex != 0 && txtNomEspece.Text != string.Empty))
                {
                    filtre += " and ";
                }
                // pour la planète
                if (cboPlanete.SelectedIndex != 0)
                {
                    
                    string temp = filtre + "(";
                    foreach (DataRow dr in MesDatas.DsGlobal.Tables["Habiter"].Rows)
                    {
                        if (cboPlanete.SelectedValue != null && cboPlanete.SelectedValue.ToString() == dr[0].ToString())
                        {
                            temp += "id = " + dr[1] + " or ";
                        }
                    }
                    // on enlève le and de trop
                    
                    if (temp != (filtre + "("))
                    {
                        filtre = temp.Remove(temp.Length - 3);
                        filtre += ")";
                    }
                    else
                    {
                        resultatExiste = false;
                    }

                }
                if (cboCouleur.SelectedIndex > 0 && cboCouleur.SelectedIndex != 0 && !resultatExiste) 
                {
                    string texte = filtre;
                    filtre = texte.Remove(texte.Length - 5);
                }

                tab = MesDatas.DsGlobal.Tables["Espece"].Select(filtre);

                // Si la recherche spécifiée ne marche pas, on l'indique
                if (tab.Length == 0)
                {
                    resultatExiste = false;
                }             
                // Sinon on continue
                else
                {
                    // on copie la table filtrée dans une DataTable
                    dt = tab.CopyToDataTable();
                    dt.TableName = "Filtre";
                }
                filtreEstPresent = true;
            }
            // Sinon on récupère simplement les données directements depuis le DataSet local
            else
            {
                dt = MesDatas.DsGlobal.Tables["Espece"];
            }

            // Si la recherche spécifiée ne marche pas, on l'indique
            if (!resultatExiste)
            {
                UserControlMessageErreur error = new UserControlMessageErreur();
                pnlEspeces.Controls.Add(error);
            }
            else
            {
                foreach (DataRow r in dt.Rows)
                {

                    // Ajout des informations pour toutes les espèces (générales)
                    // Ajout du lien de l'image correspondant à l'espèce
                    string nomImageEspece = $"../../Images/Especes/{r["nom"]}.png";

                    // Ajout du nom de l'espèce
                    string nomEspece = r["nom"].ToString();

                    // Ajout de sa couleur
                    string couleur = r["couleur"].ToString();

                    // Liste de la (des) planète(s) sur laquelle (lesquelles) l'espèce vit
                    List<string> listePlanetes = new List<string>();

                    // Si un filtre est présent, on traite la sélection des planètes différemment comme on n'a pas de relations avec la table filtrée
                    if (filtreEstPresent)
                    {
                        // On parcourt la table Habiter
                        DataTable planete = MesDatas.DsGlobal.Tables["Habiter"];

                        foreach (DataRow dr in planete.Rows)
                        {
                            // Si cela correspond à l'élément présent dans le filtre, on le rajoute
                            if (dr[1].ToString() == r["id"].ToString())
                            {
                                listePlanetes.Add(dr[0].ToString());
                            }
                        }
                    }
                    // Sinon, on traite l'affichage des planètes normalement :
                    else
                    {
                        // On parcourt les planètes et on les affiche toutes en les reliant aux bonnes espèces
                        DataRow[] planete = r.GetChildRows("FK_Espece_Habiter");

                        foreach (DataRow dr in planete)
                        {
                            if (dr.GetParentRow("FK_Planete_Habiter")[0] != null)
                            {
                                listePlanetes.Add(dr.GetParentRow("FK_Planete_Habiter")[0].ToString());
                            }

                        }
                    }

                    // Sélection du camp de l'espèce
                    // Par défaut, il est neutre (ni allié, ni ennemi)
                    string camp = "Neutre";

                    // Si c'est un allié...
                    foreach(DataRow allie in MesDatas.DsGlobal.Tables["Allie"].Rows)
                    {
                        // ...on parcourt la table concernée et on le précise dans camp
                        if (r["id"].ToString() == allie[0].ToString())
                        {
                            camp = "Allié";
                        }
                    }

                    // Si c'est un ennemi...
                    foreach (DataRow ennemi in MesDatas.DsGlobal.Tables["Ennemi"].Rows)
                    {
                        // ...on parcourt la table concernée et on le précise dans camp
                        if (r["id"].ToString() == ennemi[0].ToString())
                        {
                            camp = "Ennemi";
                        }
                    }

                    // Création de l'UserControl en le surchargeant 
                    UserControlEspeces u = new UserControlEspeces(nomImageEspece, nomEspece, couleur, listePlanetes, camp);


                    // Ajout de l'UserControl dans le panel du tableau de bord
                    pnlEspeces.Controls.Add(u);
                }
            }
        }

        private void InfosPlanetes()
        {
            pnlPlanetes.Visible = false;
            grpFiltreMission.Visible = false;

            // Parcours de la table pour récupérer toutes les infos nécessaires
            foreach (DataRow r in MesDatas.DsGlobal.Tables["Planete"].Rows)
            {
                // Récupération des chaînes de caractères
                string nomPlanete = r["nom"].ToString();
                string temp = r["temperature"].ToString();
                string gravite = r["gravite"].ToString();
                string presenceDatabaz = r["dataBazON"].ToString();


                // Récupération du chemin des images

                // Pour les planètes
                // La fonction replace permete de remplacer les espaces présents dans 'la 9e planete' pour quon' puisse afficher la bonne image correspondante
                string nomImageP = nomPlanete.Replace(" ", "");
                string nomImagePlanete = $"../../Images/Planetes/{nomImageP}.png";

                // Pour la température
                string nomImageTemp = "";
                Int32 valueTemp = 0;
                int xOut;
                bool tempImageInconnue = false;

                // Si la valeur est positive, on reprend simplement la valeur obtenue en la castant
                if (!r["temperature"].ToString().Contains("-"))
                {
                    // On vérifie qu'on puisse bien la convertir
                    if (Int32.TryParse(r["temperature"].ToString(), out xOut))
                    {
                        // Si oui, on affecte la valeur dans valueTemp
                        valueTemp = xOut;
                    }
                    else
                    {
                        // Sinon, on renvoie un string vide indiquant que la température est inconnue
                        nomImageTemp = "";
                        tempImageInconnue = true;
                    }
                }
                // Si la température est négative
                else if (r["temperature"].ToString().Contains("-"))
                {
                    string valuePositive = "";
                    // On parcourt la chaîne de caractères APRES le signe moins ('-')
                    for (int i = 1; i < r["temperature"].ToString().Length; i++)
                    {
                        // On affecte ces valeurs dans la variable temporaire
                        valuePositive += r["temperature"].ToString()[i];
                    }
                    // On les convertit en entier pour obtenir la valeur absolue
                    valueTemp = Int32.Parse(valuePositive);

                    // Comme le nombre original est négatif, on le multiplie par -1 pour inverser son signe
                    valueTemp *= -1;

                }

                // Affichage en conséquence d'une image pour la température
                // Température froide

                if (valueTemp <= 5)
                {
                    nomImageTemp = $"../../Images/Temperature/Froid.png";
                }
                // Température medium
                else if (valueTemp > 5 && valueTemp < 100)
                {
                    nomImageTemp = $"../../Images/Temperature/Medium.png";
                }
                // Température chaude
                else if (valueTemp > 100)
                {
                    nomImageTemp = $"../../Images/Temperature/Chaud.png";
                }

                // Température inconnue
                if (tempImageInconnue)
                {
                    nomImageTemp = $"../../Images/Temperature/Inconnue.png";
                }

                // Initialisation des listes

                // Pour les espèces :
                List<string> listeEspeces = new List<string>();
                List<string> listePourcentageEspece = new List<string>();

                DataRow[] espece = r.GetChildRows("FK_Planete_Habiter");

                foreach (DataRow dr in espece)
                {
                    // Initialisation du texte pour les espèces
                    string texte = dr.GetParentRow("FK_Espece_Habiter")[1].ToString();

                    // Vérification du camp de chaque espèce
                    foreach (DataRow allie in MesDatas.DsGlobal.Tables["Allie"].Rows)
                    {
                        // Si les espèces indiquées sur les planètes sont alliées, on l'indique
                        if (allie[0].ToString() == dr[1].ToString())
                        {
                            texte += "  |  Alliés";
                        }
                    }

                    foreach (DataRow ennemi in MesDatas.DsGlobal.Tables["Ennemi"].Rows)
                    {
                        // Si les espèces indiquées sur les planètes sont ennemies, on l'indique
                        if (ennemi[0].ToString() == dr[1].ToString())
                        {
                            texte += "  |  Ennemis";
                        }
                    }

                    // Ajout dans la liste Espèces
                    listeEspeces.Add(texte);
                    //MessageBox.Show(dr.GetParentRow("FK_Espece_Habiter")[1].ToString() + " : " + listeEspeces.Contains(dr.GetParentRow("FK_Espece_Habiter")[1].ToString()).ToString());
                    listePourcentageEspece.Add(dr[2].ToString());
                }


                // Pour les missions :
                List<string> listeMissions = new List<string>();

                DataRow[] mission = r.GetChildRows("FK_Planete_Mission");
                foreach (DataRow dr in mission)
                {
                    if (dr[0] != null)
                    {
                        listeMissions.Add(dr[0].ToString() + dr[1]);
                    }
                }

                // Création de l'UserControl en le surchargeant
                UserControlPlanete u = new UserControlPlanete(nomImagePlanete, nomImageTemp, nomPlanete, temp, gravite, presenceDatabaz, listeEspeces, listeMissions, listePourcentageEspece);

                // Ajout de l'UserControl dans le panel du tableau de bord
                pnlPlanetes.Controls.Add(u);
            }
        }

        private void btnSwitchTheme_Click(object sender, EventArgs e)
        {
            Couleur.SwitchTheme();
            btnSwitchTheme.Text = (btnSwitchTheme.Text == "🌒︎") ? "☉︎" : "🌒︎";
            BackColor = Couleur.getBackground;
            ForeColor = Couleur.getText;
            foreach (Control c in Controls)
            {
                UpdateColorControls(c);
            }

        }

        private void UpdateColorControls(Control c)
        {
            c.ForeColor = Couleur.getText;
            if(c is Label)
            {
                c.ForeColor = Couleur.getText;
            }
            if(c is System.Windows.Forms.Button)
            {
                c.BackColor = Couleur.getButton;
                c.ForeColor = Couleur.getText;
            }
            
            if(c is MissionResume)
            {
                MissionResume mr = (MissionResume)c;
                mr.UpdateColors();
            }
            foreach(Control subControl in c.Controls)
            {
                UpdateColorControls(subControl);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            /*
                Permet de réinitialiser tous les éléments de recherche dans grpEspeces
            */

            // Vide le textBox de recherche en fonction du nom
            txtNomEspece.Clear();

            // Décoche les RadioButtons précisant si l'espèce est alliée ou ennemie
            rdbAllies.Checked = false;
            rdbEnnemis.Checked = false;

            // Réinitialise les comboboxes
            cboCouleur.SelectedIndex = 0;
            cboPlanete.SelectedIndex = 0;

        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            // Vérifie si un filtre par allié ou ennemi est réalisée ou non et agis en conséquence
            afficherFiltre();
        }

        private void afficherFiltre()
        {
            if (rdbAllies.Checked)
            {
                InfoEspecesAlliees();
                pnlAllies.Visible = true;
                pnlEnnemis.Visible = false;
                pnlEspeces.Visible = false;
                grpEspeces.Visible = true;
            }
            else if (rdbEnnemis.Checked)
            {
                InfoEspecesEnnemies();
                pnlAllies.Visible = false;
                pnlEnnemis.Visible = true;
                pnlEspeces.Visible = false;
                grpEspeces.Visible = true;

            }
            else
            {
                InfosEspeces();
                pnlAllies.Visible = false;
                pnlEnnemis.Visible = false;
                pnlEspeces.Visible = true;
                grpEspeces.Visible = true;

            }
        }

        private void InfoEspecesAlliees()
        {
            
            // Initialisation des éléments de départ et affichage propre des bons éléments
            pnlAllies.Controls.Clear();
            pnlEspeces.Visible = false;
            grpEspeces.Visible = false;
            pnlAllies.Visible = false;
            pnlEnnemis.Visible = false;
            pnlStats.Visible = false;
            DataRow[] tabTemp;
            DataRow[] clone;
            DataTable dt = new DataTable();
            DataTable dtTemp;
            bool filtreEstPresent = false;
            bool resultatExiste = true;

            if (cboCouleur.SelectedIndex != 0 || txtNomEspece.Text != string.Empty || cboPlanete.SelectedIndex != 0)
            {
                // On ajuste le filtre en fonction des indications de recherche
                string filtre = "";
                // Pour la couleur
                if (cboCouleur.SelectedIndex > 0)
                {
                    filtre += "couleur = '" + cboCouleur.SelectedValue + "'";
                }
                // Si deux filtres sont choisis, on rajoute un 'and' dans le filtre pour relié les deux conditions
                if ((cboCouleur.SelectedIndex != 0 && txtNomEspece.Text != string.Empty) || (cboCouleur.SelectedIndex > 0 && cboPlanete.SelectedIndex != 0))
                {
                    filtre += " and ";
                }
                // Pour le nom
                if (txtNomEspece.Text != string.Empty)
                {
                    filtre += "nom like '" + txtNomEspece.Text + "%'";
                }

                // Si les trois filtres sont choisis ou si UNIQUEMENT les deux filtres Nom et Planete sont choisi
                if ((cboCouleur.SelectedIndex != 0 && txtNomEspece.Text != string.Empty && cboPlanete.SelectedIndex != 0) || (cboPlanete.SelectedIndex != 0 && txtNomEspece.Text != string.Empty))
                {
                    filtre += " and ";
                }
                // pour la planète
                if (cboPlanete.SelectedIndex != 0)
                {
                    string temp = filtre + "(";
                    foreach (DataRow dr in MesDatas.DsGlobal.Tables["Habiter"].Rows)
                    {
                        if (cboPlanete.SelectedValue != null && cboPlanete.SelectedValue.ToString() == dr[0].ToString())
                        {
                            temp += "id = " + dr[1] + " or ";
                        }
                    }
                    // on enlève le and de trop

                    if (temp != (filtre + "("))
                    {
                        filtre = temp.Remove(temp.Length - 3);
                        filtre += ")";
                    }
                    else
                    {
                        resultatExiste = false;
                    }

                }
                if (cboCouleur.SelectedIndex > 0 && cboCouleur.SelectedIndex != 0 && !resultatExiste)
                {
                    string texte = filtre;
                    filtre = texte.Remove(texte.Length - 5);
                }
                
                tabTemp = MesDatas.DsGlobal.Tables["Espece"].Select(filtre);
                // Si le filtre ne correspond à aucune espèce
                if (tabTemp.Length == 0)
                {
                    resultatExiste = false;
                }
                else
                {
                    dtTemp = tabTemp.CopyToDataTable();
                    dtTemp.TableName = "Filtre";

                    // Parcours des espèces alliées : on vérifie si les espèces filtrées sont des alliés ou pas
                    string filtre2 = "";
                    int nbEspeces = 0;
                    foreach (DataRow dr in MesDatas.DsGlobal.Tables["Allie"].Rows)
                    {
                        foreach (DataRow d in dtTemp.Rows)
                        {
                            // Si les espèces alliées sont de la bonne couleur, on les rajoute dans le filtre
                            if (dr[0].ToString() == d[0].ToString())
                            {
                                // Faire un filtre ne contenant que cette espèce
                                // Il peut y avoir plusieurs espèces ayant cette couleur, d'où l'utilisatino du 'OR' pour le filtre
                                filtre2 += "idEspece = " + d[0] + " OR ";
                                nbEspeces++;
                            }
                        }


                    }
                    // Si aucune espèce ne correspond à la recherche spécifiée, on l'indique
                    if (nbEspeces == 0)
                    {
                        resultatExiste = false;
                    }
                    else
                    {
                        // On enlève le dernier 'Or' de trop pour avoir un filtre fonctionnel
                        string filtreFinal = filtre2.Remove(filtre2.Length - 4);
                        // On place ce filtre final dans une table 'clone' qui va être copiée dans la DataTable
                        clone = MesDatas.DsGlobal.Tables["Allie"].Select(filtreFinal);
                        dt = clone.CopyToDataTable();
                        filtreEstPresent = true;
                    }
                }
                
                
            }
            else
            {
                // S'il n'y a pas de filtre, on parcourt simplement les éléments de la table Allie
                dt = MesDatas.DsGlobal.Tables["Allie"];
            }

            // Si aucune espèce ne correspond à la recherche spécifiée, on l'indique
            if (!resultatExiste)
            {
                UserControlMessageErreur error = new UserControlMessageErreur();
                pnlAllies.Controls.Add(error);
            }
            // Sinon le reste se passe comme sur des roulettes ^_^
            else
            {
                foreach (DataRow r in dt.Rows)
                {
                    // Affichage des premiers éléments de base présents directement dans la table Allie
                    string degreBienveillance = r["degreBienveillance"].ToString();
                    string instrument = r["instrumentMusique"].ToString();
                    string datePremierContact = r["datePremierContact"].ToString();
                    List<string> listePlanetes = new List<string>();

                    // Initialisation de l'image
                    // Affiche le nom de l'image en fonction de l'id définissant chaque espèce
                    string nomImageEspece = "";

                    foreach (DataRow dr in MesDatas.DsGlobal.Tables["Espece"].Rows)
                    {
                        if (dr[0].ToString() == r[0].ToString())
                        {
                            nomImageEspece = $"../../Images/Especes/{dr[1]}.png";
                        }
                    }
                    

                    string nomEspece = "";
                    string couleur = "";

                    // Pour les éléments qui ne sont pas dans la table Allie, on vérifie si on utilise un filtre ou pas
                    // En effet, on ne parcourt pas les données de la même façon :
                    // par comparaison des tables Allie et Espece en parcourant cette dernière...
                    if (filtreEstPresent)
                    {
                        // Recherche du nom et de la couleur de l'espèce pour les afficher
                        foreach (DataRow dr in MesDatas.DsGlobal.Tables["Espece"].Rows)
                        {
                            if (dr[0].ToString() == r[0].ToString())
                            {
                                nomEspece = dr[1].ToString();
                                couleur = dr[2].ToString();
                            }
                        }

                        // Liste de la (des) planète(s) sur laquelle (lesquelles) l'espèce vit
                        DataTable planete = MesDatas.DsGlobal.Tables["Habiter"];

                        foreach (DataRow dr in planete.Rows)
                        {

                            if (dr[1].ToString() == r["idEspece"].ToString())
                            {
                                listePlanetes.Add(dr[0].ToString());
                            }
                        }
                    }
                    // ...ou par relation de clé étrangère définie dans AjoutRelation()
                    else
                    {
                        // Ajout du nom de l'espèce
                        nomEspece = r.GetParentRow("FK_Espece_Allie")[1].ToString();

                        // Ajout de sa couleur
                        couleur = r.GetParentRow("FK_Espece_Allie")[2].ToString();

                        // Liste de la (des) planète(s) sur laquelle (lesquelles) l'espèce vit

                        DataRow[] planetes = r.GetParentRow("FK_Espece_Allie").GetChildRows("FK_Espece_Habiter");

                        foreach (DataRow dr in planetes)
                        {
                            if (dr.GetParentRow("FK_Planete_Habiter")[0] != null)
                            {
                                listePlanetes.Add(dr.GetParentRow("FK_Planete_Habiter")[0].ToString());
                            }

                        }
                    }

                    // test du UserControl
                    // Création de l'UserControl en le surchargeant); 
                    UserControlEspecesAlliees u = new UserControlEspecesAlliees(nomImageEspece, couleur, nomEspece, degreBienveillance, listePlanetes, datePremierContact, instrument);
                

                    // Ajout de l'UserControl dans le panel du tableau de bord
                    pnlAllies.Controls.Add(u);

                }
            }
        }

        private void InfoEspecesEnnemies()
        {
            // Initialisation des éléments de départ et affichage propre des bons éléments
            pnlEnnemis.Controls.Clear();
            pnlEspeces.Visible = false;
            grpEspeces.Visible = false;
            pnlAllies.Visible = false;
            pnlEnnemis.Visible = false;
            pnlStats.Visible = false;
            DataRow[] tabTemp;
            DataRow[] clone;
            DataTable dt = new DataTable();
            DataTable dtTemp;
            bool filtreEstPresent = false;
            bool resultatExiste = true;

            if (cboCouleur.SelectedIndex != 0 || txtNomEspece.Text != string.Empty || cboPlanete.SelectedIndex != 0)
            {
                // On ajuste le filtre en fonction des indications de recherche
                string filtre = "";
                // Pour la couleur
                if (cboCouleur.SelectedIndex > 0)
                {
                    filtre += "couleur = '" + cboCouleur.SelectedValue + "'";
                }
                // Si deux filtres sont choisis, on rajoute un 'and' dans le filtre pour relié les deux conditions
                if ((cboCouleur.SelectedIndex != 0 && txtNomEspece.Text != string.Empty) || (cboCouleur.SelectedIndex > 0 && cboPlanete.SelectedIndex != 0))
                {
                    filtre += " and ";
                }
                // Pour le nom
                if (txtNomEspece.Text != string.Empty)
                {
                    filtre += "nom like '" + txtNomEspece.Text + "%'";
                }

                // Si les trois filtres sont choisis ou si UNIQUEMENT les deux filtres Nom et Planete sont choisi
                if ((cboCouleur.SelectedIndex != 0 && txtNomEspece.Text != string.Empty && cboPlanete.SelectedIndex != 0) || (cboPlanete.SelectedIndex != 0 && txtNomEspece.Text != string.Empty))
                {
                    filtre += " and ";
                }
                // pour la planète
                if (cboPlanete.SelectedIndex != 0)
                {
                    string temp = filtre + "(";
                    foreach (DataRow dr in MesDatas.DsGlobal.Tables["Habiter"].Rows)
                    {
                        if (cboPlanete.SelectedValue != null && cboPlanete.SelectedValue.ToString() == dr[0].ToString())
                        {
                            temp += "id = " + dr[1] + " or ";
                        }
                    }
                    // on enlève le and de trop

                    if (temp != (filtre + "("))
                    {
                        filtre = temp.Remove(temp.Length - 3);
                        filtre += ")";
                    }
                    else
                    {
                        resultatExiste = false;
                    }

                }
                if (cboCouleur.SelectedIndex > 0 && cboCouleur.SelectedIndex != 0 && !resultatExiste)
                {
                    string texte = filtre;
                    filtre = texte.Remove(texte.Length - 5);
                }

                tabTemp = MesDatas.DsGlobal.Tables["Espece"].Select(filtre);
                // Si le filtre ne correspond à aucune espèce
                if (tabTemp.Length == 0)
                {
                    resultatExiste = false;
                }
                else
                {
                    // Sinon on continue

                    dtTemp = tabTemp.CopyToDataTable();
                    dtTemp.TableName = "Filtre";

                    // Parcours des espèces alliées : on vérifie si les espèces filtrées par couleur sont des alliés ou pas
                    string filtre2 = "";
                    int nbEspeces = 0;

                    foreach (DataRow dr in MesDatas.DsGlobal.Tables["Ennemi"].Rows)
                    {
                        foreach (DataRow d in dtTemp.Rows)
                        {
                            // Si les espèces alliées sont de la bonne couleur, on les rajoute dans le filtre
                            if (dr[0].ToString() == d[0].ToString())
                            {
                                // Faire un filtre ne contenant que cette espèce
                                // Il peut y avoir plusieurs espèces ayant cette couleur, d'où l'utilisatino du 'OR' pour le filtre
                                filtre2 += "idEspece = " + d[0] + " OR ";
                                nbEspeces++;
                            }
                        }


                    }
                    // Si aucune espèce correspondant au critère(s) de recherche n'a été trouvé, on l'indique
                    if (nbEspeces == 0)
                    {
                        resultatExiste = false;
                    }
                    else
                    {
                        // On enlève le dernier 'Or' de trop pour avoir un filtre fonctionnel
                        string filtreFinal = filtre2.Remove(filtre2.Length - 4);
                        // On place ce filtre final dans une table 'clone' qui va être copiée dans la DataTable
                        clone = MesDatas.DsGlobal.Tables["Ennemi"].Select(filtreFinal);
                        dt = clone.CopyToDataTable();
                        filtreEstPresent = true;
                    }
                }
                
            }
            else
            {
                // S'il n'y a pas de filtre, on parcourt simplement les éléments de la table Allie
                dt = MesDatas.DsGlobal.Tables["Ennemi"];
            }

            if (!resultatExiste)
            {
                UserControlMessageErreur error = new UserControlMessageErreur();
                pnlEnnemis.Controls.Add(error);
            }
            else
            {


                foreach (DataRow r in dt.Rows)
                {
                    // Affichage des premiers éléments de base présents directement dans la table Allie
                    string degreAgressivite = r["degreAgressivite"].ToString();
                    string arme = r["typeArme"].ToString();


                    // Initialisation de l'image
                    // Affiche le nom de l'image en fonction de l'id définissant chaque espèce
                    string nomImageEspece = "";

                    foreach (DataRow dr in MesDatas.DsGlobal.Tables["Espece"].Rows)
                    {
                        if (dr[0].ToString() == r[0].ToString())
                        {
                            nomImageEspece = $"../../Images/Especes/{dr[1]}.png";
                        }
                    }

                    string nomEspece = "";
                    string couleur = "";

                    List<string> listePlanetes = new List<string>();

                    // Pour les éléments qui ne sont pas dans la table Allie, on vérifie si on utilise un filtre ou pas
                    // En effet, on ne parcourt pas les données de la même façon :
                    // par comparaison des tables Ennemi et Espece en parcourant cette dernière...
                    if (filtreEstPresent)
                    {
                        // Recherche du nom et de la couleur de l'espèce pour les afficher
                        foreach (DataRow dr in MesDatas.DsGlobal.Tables["Espece"].Rows)
                        {
                            if (dr[0].ToString() == r[0].ToString())
                            {
                                nomEspece = dr[1].ToString();
                                couleur = dr[2].ToString();
                            }
                        }

                        // Liste de la (des) planète(s) sur laquelle (lesquelles) l'espèce vit
                        DataTable planete = MesDatas.DsGlobal.Tables["Habiter"];

                        foreach (DataRow dr in planete.Rows)
                        {

                            if (dr[1].ToString() == r["idEspece"].ToString())
                            {
                                listePlanetes.Add(dr[0].ToString());
                            }
                        }
                    }
                    // ...ou par relation de clé étrangère définie dans AjoutRelation()
                    else
                    {
                        // Ajout du nom de l'espèce
                        nomEspece = r.GetParentRow("FK_Espece_Ennemi")[1].ToString();

                        // Ajout de sa couleur
                        couleur = r.GetParentRow("FK_Espece_Ennemi")[2].ToString();

                        // Liste de la (des) planète(s) sur laquelle (lesquelles) l'espèce vit

                        DataRow[] planetes = r.GetParentRow("FK_Espece_Ennemi").GetChildRows("FK_Espece_Habiter");

                        foreach (DataRow dr in planetes)
                        {
                            if (dr.GetParentRow("FK_Planete_Habiter")[0] != null)
                            {
                                listePlanetes.Add(dr.GetParentRow("FK_Planete_Habiter")[0].ToString());
                            }

                        }
                    }

                    // Création de l'UserControl en le surchargeant); 
                    UserControlEspecesEnnemies u = new UserControlEspecesEnnemies(nomImageEspece, couleur, nomEspece, listePlanetes, degreAgressivite, arme);

                    // Ajout de l'UserControl dans le panel du tableau de bord
                    pnlEnnemis.Controls.Add(u);
                }
            }
        }


        private void ChargementElementsGrpEspeces()
        {
            // ComboBox Couleur
            co = Connexion.Connec;
            try
            {
                // ComboBox couleur
                string request = @"select distinct couleur from Espece";
                SQLiteCommand cmd = new SQLiteCommand(request, co);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(MesDatas.DsGlobal, "Couleur");

                // ComboBox Planete
                string request2 = @"select nom from Planete";
                SQLiteCommand cmd2 = new SQLiteCommand(request2, co);
                SQLiteDataAdapter da2 = new SQLiteDataAdapter(cmd2);
                da2.Fill(MesDatas.DsGlobal, "RecherchePlanete");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connexion.FermerConnexion();
            }
            // Rajout d'une valeur Toutes pour les espèces
            DataRow row = MesDatas.DsGlobal.Tables["Couleur"].NewRow();
            row["couleur"] = "Toutes";

            MesDatas.DsGlobal.Tables["Couleur"].Rows.InsertAt(row, 0);

            // Rajout d'une valeur Toutes pour les planètes
            DataRow row2 = MesDatas.DsGlobal.Tables["RecherchePlanete"].NewRow();
            row2["nom"] = "Toutes";

            MesDatas.DsGlobal.Tables["RecherchePlanete"].Rows.InsertAt(row2, 0);

            // Remplissage des Comboboxes
            cboCouleur.DataSource = MesDatas.DsGlobal.Tables["Couleur"];
            cboCouleur.DisplayMember = "couleur";
            cboCouleur.ValueMember = "couleur";

            cboPlanete.DataSource = MesDatas.DsGlobal.Tables["RecherchePlanete"];
            cboPlanete.DisplayMember = "nom";
            cboPlanete.ValueMember = "nom";

            rdbAllies.Checked = false;
            rdbEnnemis.Checked = false;

        }

        private void cboCouleur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estSurEspece)
            {
                afficherFiltre();
            }
        }

        private void txtNomEspece_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Interdire l'entrée de caractères autres que des lettres
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

            // Autoriser certaines touches particulières :

            // Entrée ou Tab : Focus sur le bouton de recherche
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                e.Handled = false;
                btnRecherche.Focus();
            }

            // Back/Delete : Pour supprimer des caractères
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == '-') 
            {
                e.Handled = false;
            }
        }


        private void cboPlanete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estSurEspece)
            {
                afficherFiltre();
            }
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            foreach (DataGridView dgv in pnlStats.Controls.OfType<DataGridView>())
            {
                dgv.DataSource = null;
                dgv.Refresh();
            }
            ChargementStats();

            grpFiltreMission.Visible = false;
            grpTableauDeBord.Visible = false;
            pnlTDB.Visible = false;
            pnlEspeces.Visible = false;
            grpEspeces.Visible = false;
            pnlAllies.Visible = false;
            pnlEnnemis.Visible = false;
            pnlStats.Visible = true;

            estSurEspece = false;


            FiltrerListesMembresMemeMission();
            FiltrerInformateursMoinsSous();
        }

        private void ChargementStats()
        {
            // Chargement de la ComboBox Stats pour l'affichage des premières données statistiques
            co = Connexion.Connec;
            try
            {
                // ComboBox Stats Membres
                string request = @"select nom, matricule from Membre";
                SQLiteCommand cmd = new SQLiteCommand(request, co);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(MesDatas.DsGlobal, "ListeMembres");

                // Combobox Stats Informateurs
                string requestInfos = @"select concat(nomPlanete, numero) as Mission from Mission";
                SQLiteCommand cmdInfos = new SQLiteCommand(requestInfos, co);
                SQLiteDataAdapter daInfos = new SQLiteDataAdapter(cmdInfos);
                daInfos.Fill(MesDatas.DsGlobal, "ListeMissions");

                // 2e requete
                // Pour les missions comportant un équipage de plus de 10 personnes, indiquer la liste des dépenses effectuées, ainsi que les budgets initiaux et actuels
                string req2 = @"SELECT m.nomPlanete || '-' || m.numero as 'Mission', sum(d.montant) as 'Dépenses', m.budget as 'Budget initial', m.budget - sum(d.montant) as 'Budget restant'
                FROM Depense d JOIN Mission m ON d.nomPlanete = m.nomPlanete AND d.numeroMission = m.numero
                WHERE m.nbMembreRequis > 10 
                GROUP BY m.nomPlanete, m.numero";
                SQLiteCommand cmd2 = new SQLiteCommand(req2, co);
                SQLiteDataAdapter da2 = new SQLiteDataAdapter(cmd2);
                DataTable depenseDix = new DataTable();
                da2.Fill(depenseDix);

                dgvStatsMissionBudget.DataSource = depenseDix;

                //dgvStats2.DataSource = MesDatas.DsGlobal.Tables["ListePlaneteMissions"];

                // 3e requete
                // Pour chaque planète, indiquer le nombre de missions qui y ont déjà eu lieu. Certaines planètes n’ont jamais fait l’objet de mission, elles devront néanmoins apparaître
                string req3 = @"SELECT p.nom as [Nom de la planète], count(m.nomPlanete) as [Nombre de mission]
                FROM Planete p LEFT JOIN Mission m ON p.nom = m.nomPlanete
                GROUP BY p.nom;";
                SQLiteCommand cmd3 = new SQLiteCommand(req3, co);
                SQLiteDataAdapter da3 = new SQLiteDataAdapter(cmd3);
                DataTable ListePlaneteMission = new DataTable();
                da3.Fill(ListePlaneteMission);

                dgvMissionParPlanete.DataSource = ListePlaneteMission;



                // 4e requete
                // Liste des dépenses (date, motif et montant concaténés dans une seule colonne intitulée « Dépenses les plus importantes »),
                // nom de la mission et nom et prénom du chef de la mission, pour les dépenses les plus élevées de chaque mission. 

                string req4 = @"SELECT d.dateD || ' - ' || d.motif || ': ' || d.montant || '€' AS [Plus grande dépense], 
                d.nomPlanete || '-' || d.numeroMission AS [Nom de la mission],
                me.nom || ' ' || me.prenom AS [Chef de mission]
                FROM Depense d 
                JOIN Mission m ON d.nomPlanete = m.nomPlanete AND d.numeroMission = m.numero
                JOIN Membre me ON me.matricule = m.matriculeChef
                GROUP BY d.nomPlanete, d.numeroMission";
                SQLiteCommand cmd4 = new SQLiteCommand(req4, co);
                SQLiteDataAdapter da4 = new SQLiteDataAdapter(cmd4);
                da4.Fill(MesDatas.DsGlobal, "ListeDepenses");

                dgvDepenseParMission.DataSource = MesDatas.DsGlobal.Tables["ListeDepenses"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connexion.FermerConnexion();
            }

            cboStatsMembre.DataSource = MesDatas.DsGlobal.Tables["ListeMembres"];
            cboStatsMembre.DisplayMember = "nom";
            cboStatsMembre.ValueMember = "matricule";

            cboStatsInformateurMission.DataSource = MesDatas.DsGlobal.Tables["ListeMissions"];
            cboStatsInformateurMission.DisplayMember = "Mission";
            cboStatsInformateurMission.ValueMember = "Mission";

        }

        private void FiltrerListesMembresMemeMission()
        {
            if (cboStatsMembre.SelectedValue == null) return;
            string matricule = cboStatsMembre.SelectedValue.ToString();

            co = Connexion.Connec;
            DataTable table = new DataTable();

            try
            {
                string req = $@"SELECT DISTINCT m.matricule as [Matricule], m.nom as [Nom], m.prenom as [Prénom], case when m.matricule like 'M%' then 'Militaire' else 'Civil' end as 'Type'
                                FROM Composer c
                                JOIN Membre m ON c.matriculeMembre = m.matricule
                                WHERE c.matriculeMembre != '{matricule}'
                                AND EXISTS (
                                    SELECT 1 FROM Composer c1
                                    WHERE c1.matriculeMembre = '{matricule}'
                                    AND c1.nomPlanete = c.nomPlanete
                                    AND c1.numeroMission = c.numeroMission
                                )
                                ORDER BY m.matricule";

                SQLiteCommand cmd = new SQLiteCommand(req, co);
                SQLiteDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }

            dgvStatsMembrePartage.DataSource = table;

            filtrePossible = true;
        }

        private void FiltrerInformateursMoinsSous()
        {
            // 5e requete
            // Quels sont les informateurs (nom de code, espèce d’origine, somme totale reçue) qui ont perçu le moins d’argent pendant une mission donnée ? 


            // Récupération du nom de la planète
            if (cboStatsInformateurMission.SelectedIndex == -1)
            {
                return;
            }
            string nomPlanete = cboStatsInformateurMission.SelectedValue.ToString().Substring(0, cboStatsInformateurMission.SelectedValue.ToString().Length - 1);

            // Récupération du numéro de la mission sur ladite planète
            string numeroMission = Regex.Match(cboStatsInformateurMission.SelectedValue.ToString(), @"\d+").Value;

            // Supprimer uniquement l'ancien dgv et label de la stat1 s'ils 

            co = Connexion.Connec;
            DataTable table = new DataTable();
            try
            {
                string req5 = $@"SELECT t.nomCode AS [Nom de code], t.nomEspece AS [Nom de l'espèce], t.totalVersee [Total versé]
                    FROM (
                        SELECT i.nomCode, e.nom AS nomEspece, SUM(c.sommeVersee) AS totalVersee
                        FROM Contact c
                        JOIN Informateur i ON c.nomCodeInformateur = i.nomCode
                        JOIN Espece e ON i.idEspeceEnnemi = e.id
                        WHERE c.nomPlanete = '{nomPlanete}'
                        AND c.numeroMission = {numeroMission}
                        GROUP BY i.nomCode, e.nom
                    ) t
                    WHERE t.totalVersee = (
                        SELECT MIN(totalVersee)
                        FROM (
                            SELECT SUM(c.sommeVersee) AS totalVersee
                            FROM Contact c
                            WHERE c.nomPlanete = '{nomPlanete}'
                              AND c.numeroMission = {numeroMission}
                            GROUP BY c.nomCodeInformateur
                        )
                    )";
                SQLiteCommand cmd5 = new SQLiteCommand(req5, co);
                SQLiteDataReader reader = cmd5.ExecuteReader();
                table.Load(reader);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
                return;
            }
            finally
            {
                Connexion.FermerConnexion();
            }

            if (table.Rows.Count != 0)
            {
                lblStatsInformateurResultat.Text = "L'Informateur qui a perçu le moins d'argent pendant cette mission est ";
                lblStatsInformateurResultat.Text += $"{table.Rows[0][0]} {table.Rows[0][1]} avec {table.Rows[0][2]}€";

            }
            else
            {
                lblStatsInformateurResultat.Text = "Aucune information sur cette mission";
            }

            filtrePossible = true;
        }
        private void cboStats1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filtrePossible)
            {
                FiltrerListesMembresMemeMission();
            }
            
        }

        private void ChargementLogo()
        {
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.Image = Image.FromFile("../../Images/Logo/STARGATE.jpg");
        }
        private void cboFiltrePlanete_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualisationTDB(cboFiltrePlanete.Text, cboFiltreEtat.Text);
        }

        private void btntriAlpha_Click(object sender, EventArgs e)
        {
            triAlpha = !triAlpha;
            btntriAlpha.Text = (triAlpha) ? "A → Z" : "Z → A";
            ActualisationTDB(cboFiltrePlanete.Text, cboFiltreEtat.Text);

        }

        private void cboStats2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filtrePossible)
            {
                FiltrerInformateursMoinsSous();
            }
        }
        private void btntriEtat_Click(object sender, EventArgs e)
        {
            if (triEtat == 0)
            {
                btntriEtat.Text = "Etat ↑↓";
                triEtat = 1;
            } else if (triEtat == 1)
            {
                triEtat = -1;
            } else if (triEtat == -1)
            {
                triEtat = 0;
                btntriEtat.Text = "Etat ✖";
            }
            ActualisationTDB(cboFiltrePlanete.Text, cboFiltreEtat.Text);
        }
    }
}
