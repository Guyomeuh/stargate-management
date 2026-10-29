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
    public partial class MembreEquipage : UserControl
    {
        public MembreEquipage()
        {
            InitializeComponent();
        }

        public string SetImage
        {
            set
            {
                pbMembre.Image = Image.FromFile($"../../Images/Membres/{value}.png");
                pbMembre.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public string setText
        {
            set
            {
                lblMembre.Text = value; 
            }
        }
    }
}
