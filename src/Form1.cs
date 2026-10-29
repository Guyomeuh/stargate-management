using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SAE24
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            FormConnexion formConnexion = new FormConnexion();
            DialogResult result = formConnexion.ShowDialog();

            if (result == DialogResult.OK)
            {
                FormCreationMission formCreation = new FormCreationMission();

                if (formCreation.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Mission créée");
                }
            }

            /*
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Access Denied");
            }
            */
        }
    }
}
