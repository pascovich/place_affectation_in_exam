using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXAMEN_GESTION_PLACE.CLASSES;

namespace EXAMEN_GESTION_PLACE.CONTROLS
{
    public partial class examen_control : UserControl
    {
        public examen_control()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void examen_control_Load(object sender, EventArgs e)
        {
            try
            {
                gunaDataGridView2.DataSource = principal_class.GetInstance().GetTable("t_session");

                gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("cours_view");
                
                gunaDataGridView3.DataSource = principal_class.GetInstance().GetTable("examen_view");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = gunaDataGridView1.CurrentRow.Cells["id_cours"].Value.ToString();
                txt_nom_cours.Text = gunaDataGridView1.CurrentRow.Cells["designation_cours"].Value.ToString();
                txt_nom_fac.Text = gunaDataGridView1.CurrentRow.Cells["designation_affecter"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaDataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                
                textBox2.Text = gunaDataGridView2.CurrentRow.Cells[0].Value.ToString();
                txt_nom_session.Text = gunaDataGridView2.CurrentRow.Cells[1].Value.ToString();
                //ex_txt.Text = gunaDataGridView1.CurrentRow.Cells["designation_session"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int id;
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nom_session.Text!="" && txt_nom_fac.Text!="" && txt_nom_session.Text!="" & dateEdit1.Text!="")
                {
                    examen_class ec = new examen_class();
                    ec.Date_ex = DateTime.Parse(dateEdit1.Text);
                    ec.Id = id;
                    ec.Ref_cours = int.Parse(textBox1.Text);
                    ec.Ref_session = int.Parse(textBox2.Text);
                    principal_class.GetInstance().operation_examen(ec);
                    gunaDataGridView3.DataSource = principal_class.GetInstance().GetTable("examen_view");
                    init();
                    
                }
                else
                {
                    MessageBox.Show("renseignez tous les champs", "CHAMP VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void init()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            txt_nom_cours.Text = "";
            txt_nom_fac.Text = "";
            txt_nom_session.Text = "";
            dateEdit1.Text = "";
        }

        private void gunaDataGridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                textBox3.Text = gunaDataGridView1.CurrentRow.Cells["id_examen"].Value.ToString();
                txt_nom_cours.Text = gunaDataGridView1.CurrentRow.Cells["designation_cours"].Value.ToString();
                txt_nom_fac.Text = gunaDataGridView1.CurrentRow.Cells["designation_affecter"].Value.ToString();
                txt_nom_session.Text = gunaDataGridView1.CurrentRow.Cells["designation_session"].Value.ToString();
                dateEdit1.Text = gunaDataGridView1.CurrentRow.Cells["date_examen"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nom_session.Text != "" && textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && txt_nom_fac.Text != "" && txt_nom_session.Text != "" & dateEdit1.Text != "")
                {
                    examen_class ec = new examen_class();
                    ec.Date_ex = DateTime.Parse(dateEdit1.Text);
                    ec.Id = int.Parse(textBox3.Text);
                    ec.Ref_cours = int.Parse(textBox1.Text);
                    ec.Ref_session = int.Parse(textBox2.Text);
                    principal_class.GetInstance().operation_examen(ec);
                    gunaDataGridView3.DataSource = principal_class.GetInstance().GetTable("examen_view");
                    init();

                }
                else
                {
                    MessageBox.Show("renseignez tous les champs", "CHAMP VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
