using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VP_Proekt
{
    public partial class StartingScreen : Form
    {
        public StartingScreen()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form gameSc = new GameScreen();
            gameSc.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Овој проект го изработија Габриел Бурагев, Давид Стојановски, Симон Стојановски", "AboutUs");
        }
    }
}
