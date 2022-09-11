using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXAMEN_GESTION_PLACE.CONTROLS;
using EXAMEN_GESTION_PLACE.CLASSES;
using EXAMEN_GESTION_PLACE.FORMULAIRES;

namespace EXAMEN_GESTION_PLACE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            principal_class.GetInstance().appel_pannel(panel_principal, new etudiant_control());
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            principal_class.GetInstance().appel_pannel(panel_principal, new inscription_control());
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            principal_class.GetInstance().appel_pannel(panel_principal, new salle_ranger_control());
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            principal_class.GetInstance().appel_pannel(panel_principal, new examen_control());
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            principal_class.GetInstance().appel_pannel(panel_principal, new affectation_place_control());
        }

        private void sALLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            session_frm f = new session_frm();
            f.Show();
        }

        private void cOURSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cours_frm f = new cours_frm();
            f.Show();
        }

        private void aNNEEACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annee_frm f = new annee_frm();
            f.Show();
        }

        private void pRONOTIONFACULTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            promotion_frm f = new promotion_frm();
            f.Show();
        }

        private void fACULTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            faculte_frm f = new faculte_frm();
            f.Show();
        }

        private void aFFECTATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            affectation_frm f = new affectation_frm();
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //principal_class.GetInstance().generaterandom();
        }
    }
}
