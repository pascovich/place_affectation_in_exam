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
    public partial class affectation_frm : Form
    {
        public affectation_frm()
        {
            InitializeComponent();
        }

        private void affectation_frm_Load(object sender, EventArgs e)
        {
            principal_class.GetInstance().chargementComboBoxGuna(cb_faculte, "designation_faculte", "t_faculte");
            principal_class.GetInstance().chargementComboBoxGuna(cb_promotion, "designation_promotion", "t_promotion");
            gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("affecter_view");
        }
        int id;
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (cb_promotion.Text != "" && cb_faculte.Text!="")
            {
                try
                {
                    string pro = cb_promotion.Text;
                    string fac = cb_faculte.Text;
                    affecter_class a = new affecter_class();
                    a.Id = id;
                    a.Designation = pro+"-"+fac;
                    a.Ref_faculte = int.Parse(principal_class.GetInstance().GetID("id_faculte", "t_faculte", "designation_faculte", cb_faculte.Text));
                    a.Ref_promotion = int.Parse(principal_class.GetInstance().GetID("id_promotion", "t_promotion", "designation_promotion", cb_promotion.Text));
                    principal_class.GetInstance().operation_affectation(a);
                    
                    gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("affecter_view");
                    cb_promotion.Text = "";
                    cb_faculte.Text = "";
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
    }
}
