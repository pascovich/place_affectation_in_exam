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
    public partial class cours_frm : Form
    {
        public cours_frm()
        {
            InitializeComponent();
        }

        private void cours_frm_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("affecter_view");
            gunaDataGridView2.DataSource = principal_class.GetInstance().GetTable("cours_view");


        }

        private void gunaDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                lbl_course.Text = gunaDataGridView1.CurrentRow.Cells["designation_affecter"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int id;
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if(lbl_course.Text!="" && txt_course_name.Text != "")
            {
                try
                {
                    cours_class a = new cours_class();
                    a.Id = id;
                    a.Ref_affecter = int.Parse(principal_class.GetInstance().GetID("id_affecter","t_affecter","designation_affecter",lbl_course.Text));
                    a.Designation = txt_course_name.Text;
                    principal_class.GetInstance().operation_cours(a);
                   
                    gunaDataGridView2.DataSource = principal_class.GetInstance().GetTable("cours_view");

                    txt_course_name.Text = "";
                    lbl_course.Text = "";
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
