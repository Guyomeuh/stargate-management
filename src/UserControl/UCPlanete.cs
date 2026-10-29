using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlPlanetes
{
    public partial class UserControlPlanete: UserControl
    {
        public UserControlPlanete()
        {
            InitializeComponent();
        }

        public UserControlPlanete(string nomImagePlanete, string nomImageTemp, string nomPlanete, string temp, string gravite, string presenceDatabaz, List<string> especesPresentes, List<string> missionsRealisees, List<string> pourcentageEspece)
        {
            InitializeComponent();
            // Ajout des éléments textuels
            // Image/Nom des planètes
            lblNomPlanete.Text = nomPlanete;
            if (temp == "")
            {
                lblTemp.Text = "Température inconnue";
                lblTemp.ForeColor = Color.FromName("Red");
            }
            else
            {
                lblTemp.Text = temp + "°";
            }

            if (gravite == "")
            {
                lblGraviteValue.Text = "Inconnue";
                lblGraviteValue.ForeColor = Color.FromName("Red");
            }
            else
            {
                lblGraviteValue.Text = gravite;
            }

            

            

            // Dire s'il y a du Databz ou pas
            if (presenceDatabaz == "1")
            {
                lblPresenceDatabaz.Text = "Présence de Databaz";
                // Mettre en gras
                lblPresenceDatabaz.Font = new Font(this.Font, FontStyle.Bold);
                lblPresenceDatabaz.ForeColor = Color.FromName("GoldenRod");
            }
            else
            {
                lblPresenceDatabaz.Text = "Absence de Databaz";
            }


            // Parcours de la liste des espèces pour afficher toutes les espèces proprement
            // S'il n'y a qu'une espèce, on n'affiche que celle-là
            if (especesPresentes.Count() == 1)
            {
                lblEspecesValue.Text = pourcentageEspece[0] + "% des " + especesPresentes[0];
                lblEspecesCommun.Text = "Espèce présente : ";
            }
            // S'il n'y en a aucune, on le dit
            else if (especesPresentes.Count() == 0)
            {
                lblEspecesCommun.Text = "Absence d'espèces connues";
                lblEspecesCommun.ForeColor = Color.FromName("Red");
                lblEspecesValue.Visible = false;
            }
            // Sinon, on parcourt et on affiche toutes les espèces
            else
            {
                string texte = "";
                for (int i = 0; i < especesPresentes.Count(); i++)
                {
                    texte += pourcentageEspece[i] + "% des " + especesPresentes[i] + "\n";
                }

                lblEspecesValue.Text = texte;
            }

            // Parcours de la liste des missions pour afficher toutes les missions proprement
            // S'il n'y a qu'une mission, on n'affiche que celle-là
            if (missionsRealisees.Count() == 1)
            {
                lblMissionsValue.Text = missionsRealisees[0];
            }
            // S'il n'y en a aucune, on le dit
            else if (missionsRealisees.Count() == 0)
            {
                lblMissionsCommun.Text = "Aucune mission réalisée";
                lblMissionsCommun.ForeColor = Color.FromName("Red");
                lblMissionsValue.Visible = false;
            }
            // Sinon, on parcourt et on affiche toutes les espèces
            else
            {
                string texte = "";
                for (int i = 0; i < missionsRealisees.Count(); i++)
                {
                    texte += missionsRealisees[i] + ", ";
                }
                texte += "et " + missionsRealisees[missionsRealisees.Count()-1];

                lblMissionsValue.Text = texte;
            }

            // Ajout des images pour la planète et le thermomètre (température)
            if (nomImagePlanete != string.Empty)
            {
                pbPlanete.Image = Image.FromFile(nomImagePlanete);
                pbPlanete.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (nomImageTemp != string.Empty)
            {
                pbTemp.Image = Image.FromFile(nomImageTemp);
                pbTemp.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
