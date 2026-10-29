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
    public partial class UserControlEspeces : UserControl
    {
        public UserControlEspeces()
        {
            InitializeComponent();
        }

        public UserControlEspeces(string nomImageEspece, string nomEspece, string couleur, List<string> planeteOrigine, string camp)
        {
            InitializeComponent();

            // Initialisation des différents labels composants la fiche de présentation générale des espèces
            lblNomEspece.Text = nomEspece;
            lblCouleur.Text = "Couleur : " + couleur;
            lblCamp.Text = camp;

            // Mettre le nom de l'espèce de la même couleur que la sienne
            Color afficher = Color.FromName("Black");
            if (couleur == "Orange")
            {
                afficher = Color.FromName(couleur);
            }

            if (couleur == "Violet")
            {
                afficher = Color.FromName("Purple");
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
            lblNomEspece.ForeColor = afficher;

            // Vérification spéciale pour l'affichage de la/des planète(s) d'origine
            // Si cette(ces) dernière(s) existe(nt), on l'(les) affiche(nt)
            if (planeteOrigine.Count == 0)
            {
                // Sinon, on affiche "Origine inconnue" et on change la couleur du texte
                lblOrigine.Text = "Origine inconnue";
                lblOrigine.ForeColor = Color.Red;
                lblNbPlanete.Visible = false;
            }

            // S'il n'y a qu'une seule planète, on n'affiche que celle-là
            else if (planeteOrigine.Count == 1)
            {
                lblOrigine.Text = planeteOrigine[0];
            }
            // Sinon, on les affiche toutes les unes après les autres
            else
            {
                lblNbPlanete.Text = "Planètes d'origine : ";

                string texte = "";
                foreach(string planete in planeteOrigine)
                {
                    texte += planete + "/";
                }
                lblOrigine.Text = texte.Remove(texte.Length-1);
            }

            // Ajout de l'image pour l'espèce
            if (nomImageEspece != string.Empty)
            {
                pbEspece.Image = Image.FromFile(nomImageEspece);
                pbEspece.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }

        private void UserControlEspeces_Load(object sender, EventArgs e)
        {

        }

        private void lblNomEspece_Click(object sender, EventArgs e)
        {

        }
    }
}
