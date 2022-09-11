using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXAMEN_GESTION_PLACE.CLASSES;

namespace EXAMEN_GESTION_PLACE.FORMULAIRES
{
    public partial class promotion_frm : Form
    {
        public promotion_frm()
        {
            InitializeComponent();
        }
        int id;
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (txt_nom.Text != "")
            {
                try
                {
                    promotion_class a = new promotion_class();
                    a.Promotion = id;
                    a.Designation = txt_nom.Text;
                    principal_class.GetInstance().operation_promotion(a);
                    txt_nom.Text = "";
                    gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("t_promotion");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("renseignez tous les champs", "CHAMP VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void promotion_frm_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("t_promotion");

        }
    }
}
