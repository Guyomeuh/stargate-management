using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlPlanetes
{
    public partial class UserControlEspecesEnnemies : UserControl
    {
        public UserControlEspecesEnnemies()
        {
            InitializeComponent();
        }

        public UserControlEspecesEnnemies(string nomImageEnnemi, string couleur, string nomEspeceEnnemie, List<string> planeteOrigine, string degreAggressivite, string typeArme)
        {
            InitializeComponent();
            // Initialisation des labels pour l'affichage
            lblNomEspeceEnnemie.Text = nomEspeceEnnemie;
            lblArme.Text = typeArme;
            lblAgressivite.Text = degreAggressivite;
            lblCouleur.Text = couleur;

            // Mettre le nom de l'espèce de la même couleur que la sienne
            Color afficher = Color.FromName("Black");
            if (couleur == "Orange" || couleur == "Violet")
            {
                afficher = Color.FromName(couleur);
            }

            if (couleur == "Rose")
            {
                afficher = Color.FromName("HotPink");
            }

            if (couleur == "Pourpre")
            {
                afficher = Color.FromName("Maroon");
            }

            if (couleur == "Bleu")
            {
                afficher = Color.FromName("DarkBlue");
            }

            if (couleur == "Gris")
            {
                afficher = Color.FromName("Gray");
            }

            if (couleur == "Vert")
            {
                afficher = Color.FromName("Green");
            }

            if (couleur == "Marron")
            {
                afficher = Color.FromName("SaddleBrown");
            }

            // Mettre
            lblNomEspeceEnnemie.ForeColor = afficher;

            // Vérification spéciale pour l'affichage de la/des planète(s) d'origine
            // Si cette(ces) dernière(s) existe(nt), on l'(les) affiche(nt)
            if (planeteOrigine.Count != 0)
            {
                // S'il n'y a qu'une seule planète, on n'affiche que celle-là
                if (planeteOrigine.Count == 1)
                {
                    lblOrigine.Text = planeteOrigine[0];
                }
                // Sinon, on les affiche toutes les unes après les autres
                else
                {
                    lblNbPlanete.Text = "Planètes d'origine : ";

                    string texte = "";
                    foreach (string planete in planeteOrigine)
                    {
                        texte += planete + "/";
                    }
                    lblOrigine.Text = texte.Remove(texte.Length - 1);
                }
            }
            // Sinon, on affiche "Origine inconnue" et on change la couleur du texte
            else
            {
                lblOrigine.Text = "Origine inconnue";
                lblOrigine.ForeColor = Color.Red;
                lblNbPlanete.Visible = false;
            }

            // Ajout de l'image pour l'espèce ennemie
            if (nomImageEnnemi != string.Empty)
            {
                pbEspeceEnnemie.Image = Image.FromFile(nomImageEnnemi);

            }
        }
    }
}
