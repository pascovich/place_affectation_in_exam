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
    public partial class session_frm : Form
    {
        public session_frm()
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
                    session_class a = new session_class();
                    a.Id = id;
                    a.Designation = txt_nom.Text;
                    principal_class.GetInstance().operation_session(a);
                    txt_nom.Text = "";
                    gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("t_session");
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

        private void session_frm_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("t_session");

        }
    }
}
