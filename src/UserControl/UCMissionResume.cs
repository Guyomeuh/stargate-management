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
    public partial class MissionResume : UserControl
    {
        public delegate void AfficherResume(object sender, EventArgs e);
        public AfficherResume afficher;
        private void AfficherResume_Click(object sender, EventArgs e)
        {
            if (afficher != null)
            {
                afficher(this, e); 
            }
        }
        public MissionResume()
        {
            InitializeComponent();
        }

        public MissionResume(string nomMission, string dateDeb, string duree, string chef)
        {
            InitializeComponent();
            UpdateColors();
            lblNomMission.Text = nomMission;
            lblDateDeb.Text = dateDeb;
            lblDuree.Text = $"{duree} Jours";
            lblChef.Text = chef;
            lblNomMission.Visible = true;
            lblDateDeb.Visible = true;
            lblDuree.Visible = true;
            lblChef.Visible = true;
            string nomPlanete = nomMission.Substring(0, nomMission.Length - 1).Replace(" ","");
            pbPlanete.Image = Image.FromFile($"../../Images/Planetes/{nomPlanete}.png");
            if (DateTime.Parse(dateDeb).Add(new System.TimeSpan(Convert.ToInt32(duree), 0, 0, 0)) > DateTime.Now)
            {
                lblStatus.Text = "En Cours";
            } else if (DateTime.Parse(dateDeb).Add(new System.TimeSpan(Convert.ToInt32(duree), 0, 0, 0)) < DateTime.Now)
            {
                lblStatus.Text = "Achevée";
            }
        }

        public string GetMission{
            get
            {
                return lblNomMission.Text;
            }
        }

        private void MissionResume_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Couleur.getButtonHover;
            Cursor = Cursors.Hand;
            foreach (Control c in Controls.OfType<Label>())
            {
                c.BackColor = Couleur.getButtonHover;
            }
        }

        private void MissionResume_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            UpdateColors();
        }

        public void UpdateColors()
        {
            this.BackColor = Couleur.getButton;
            foreach (Control c in Controls)
            {
                c.ForeColor = Couleur.getText;
                c.BackColor = Couleur.getButton;
            }
        }
    }
}
