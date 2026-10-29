using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittlePlanete
{
    public partial class UserControlMessageErreur : UserControl
    {
        public UserControlMessageErreur()
        {
            InitializeComponent();
            // Génération du texte
            lblMessage.Text = "Aucun résultat ne correspond à votre recherche (x_x)\nVeuillez réessayer...";

            // Selection de l'image
            pbErreur.Image = Image.FromFile("../../Images/Erreurs/TechnicalDifficulties.jpg");
            pbErreur.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
    }
}
