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
    public partial class salle_ranger_control : UserControl
    {
        public salle_ranger_control()
        {
            InitializeComponent();
        }
        int id;
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if(txt_nom_salle.Text!="" && txt_number.Text != "")
            {
                salle_class s = new salle_class();
                s.Id = id;
                s.Designatiom = txt_nom_salle.Text;
                s.Chaise_dispo = int.Parse(txt_number.Text);
                principal_class.GetInstance().operation_salle(s);
                gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("t_salle");
                txt_number.Text = "";
                txt_nom.Text = "";
                txt_nom.Text = "txt_room";
                txt_reste_place.Text = "txt_room";
                txt_place_dispo.Text = "0";
            }
            else
            {
                MessageBox.Show("renseignez tous les champs", "CHAMP VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void salle_ranger_control_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("t_salle");
            gunaDataGridView3.DataSource = principal_class.GetInstance().GetTable("ranger_view");

        }

        private void gunaDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //test_etat_salle();
                textBox1.Text = gunaDataGridView1.CurrentRow.Cells["id_salle"].Value.ToString();
                txt_nom.Text = gunaDataGridView1.CurrentRow.Cells["designation_salle"].Value.ToString();
                txt_place_dispo.Text = gunaDataGridView1.CurrentRow.Cells["nombre_place"].Value.ToString();
                txt_reste_place.Text = gunaDataGridView1.CurrentRow.Cells["place_dispo_restante"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_number_ranger_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    calcul_reste_place();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }
        public void calcul_reste_place()
        {
            int place_dispo = int.Parse(txt_place_dispo.Text);
            int reste_place_dispo = int.Parse(txt_reste_place.Text);
            int reste = int.Parse(txt_number_ranger.Text);
            if (txt_reste_place.Text != "reste")
            {
                if (reste <= reste_place_dispo)
                {
                    int r = reste_place_dispo - reste;
                    txt_new_reste.Text = r.ToString();
                }
                else
                {
                    MessageBox.Show("Le nombre de place doit etre inferieur au place disponible restante", "ERREUR PLACE DISPONIBLE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                MessageBox.Show("renseignez tous les champs", "CHAMP VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void txt_number_ranger_OnValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    calcul_reste_place();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_number_ranger.Text!="" && txt_nom_ranger.Text!="" && textBox1.Text!="")
                {
                    ranger_class re = new ranger_class();
                    re.Designation = txt_nom_ranger.Text;
                    re.Nombre_place = int.Parse(txt_number_ranger.Text);
                    re.Ref_salle = int.Parse(textBox1.Text);

                    principal_class.GetInstance().operation_ranger(re);
                    gunaDataGridView3.DataSource = principal_class.GetInstance().GetTable("ranger_view");
                    txt_nom_ranger.Text = "";
                    txt_number_ranger.Text = "";
                    txt_nom.Text = "txt_room";
                    txt_reste_place.Text = "txt_room";
                    txt_place_dispo.Text = "0";
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

        private void txt_number_ranger_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                calcul_reste_place();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void test_etat_salle()
        {
            if (txt_reste_place.Text == "0")
            {
                txt_reste_place.ForeColor.Equals("red");
                MessageBox.Show("desole il y a plus de place a affecter pour cette salle", "No Place", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {

            }
        }
    }
}
