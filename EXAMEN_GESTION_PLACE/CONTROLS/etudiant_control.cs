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
    public partial class etudiant_control : UserControl
    {
        public etudiant_control()
        {
            InitializeComponent();
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox7_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dl = new OpenFileDialog();
                dl.InitialDirectory = "e:\\"; //chemin par defaut
                dl.FilterIndex = 2;
                //dl.Filter = "JPEG | *.jpeg";
                dl.RestoreDirectory = true;
                if (dl.ShowDialog() == DialogResult.OK)
                {
                    pictureEdit1.Image = Image.FromFile(dl.FileName);
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int id;
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (txt_adresse.Text != "" && txt_lieu.Text != "" && txt_nom.Text!="" && txt_phone.Text!="" && txt_postnom.Text!="" && txt_prenom.Text!="" && cb_etat.Text!="" && cb_sexe.Text !="" && dateEdit1.Text !="" && pictureEdit1.Text !="")
            {
                try
                {
                    etudiant_class a = new etudiant_class();
                    a.Id = id;
                    a.Adresse = txt_adresse.Text;
                    a.Datetime = DateTime.Parse(dateEdit1.Text);
                    a.Etat_civil = cb_etat.Text;
                    a.Lieu = txt_lieu.Text;
                    a.Nom = txt_nom.Text;
                    a.Phone = txt_phone.Text;
                    a.Postnom = txt_postnom.Text;
                    a.Prenom = txt_prenom.Text;
                    a.Sexe = cb_sexe.Text;

                    principal_class.GetInstance().operation_entreprise(a, pictureEdit1);

                    dataGridView2.DataSource = principal_class.GetInstance().GetTable("t_etudiant");

                    init();
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
        private void init()
        {
            txt_adresse.Text = "";
            txt_lieu.Text = "";
            txt_nom.Text = "";
            txt_phone.Text = "";
            txt_postnom.Text = "";
            txt_prenom.Text = "";
            cb_etat.Text = "";
            cb_sexe.Text = "";
            dateEdit1.Text = "";
            pictureEdit1.Text = "";
        }

        private void etudiant_control_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = principal_class.GetInstance().GetTable("t_etudiant");
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                label1.Text = dataGridView2.CurrentRow.Cells["id_etudiant"].Value.ToString();
                txt_adresse.Text = dataGridView2.CurrentRow.Cells["adresse"].Value.ToString();
                txt_lieu.Text = dataGridView2.CurrentRow.Cells["lieu_naissance"].Value.ToString();
                txt_nom.Text = dataGridView2.CurrentRow.Cells["nom"].Value.ToString();
                txt_phone.Text = dataGridView2.CurrentRow.Cells["telephone"].Value.ToString();
                txt_postnom.Text = dataGridView2.CurrentRow.Cells["postnom"].Value.ToString();
                txt_prenom.Text = dataGridView2.CurrentRow.Cells["prenom"].Value.ToString();
                cb_etat.Text = dataGridView2.CurrentRow.Cells["etat_civil"].Value.ToString();
                cb_sexe.Text = dataGridView2.CurrentRow.Cells["sexe"].Value.ToString();
                dateEdit1.Text = dataGridView2.CurrentRow.Cells["date_naissance"].Value.ToString();
                pictureEdit1.EditValue = dataGridView2.CurrentRow.Cells["photo"].FormattedValue;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            if (txt_adresse.Text != "" && label1.Text!="" && txt_lieu.Text != "" && txt_nom.Text != "" && txt_phone.Text != "" && txt_postnom.Text != "" && txt_prenom.Text != "" && cb_etat.Text != "" && cb_sexe.Text != "" && dateEdit1.Text != "" && pictureEdit1.Text != "")
            {
                try
                {
                    etudiant_class a = new etudiant_class();
                    a.Id = int.Parse(label1.Text);
                    a.Adresse = txt_adresse.Text;
                    a.Datetime = DateTime.Parse(dateEdit1.Text);
                    a.Etat_civil = cb_etat.Text;
                    a.Lieu = txt_lieu.Text;
                    a.Nom = txt_nom.Text;
                    a.Phone = txt_phone.Text;
                    a.Postnom = txt_postnom.Text;
                    a.Prenom = txt_prenom.Text;
                    a.Sexe = cb_sexe.Text;

                    principal_class.GetInstance().operation_entreprise(a, pictureEdit1);

                    dataGridView2.DataSource = principal_class.GetInstance().GetTable("t_etudiant");

                    init();
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

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
            {
                DialogResult réponse = MessageBox.Show("Voulez-vous vraiment supprimer cet etudiant", "Suppression", MessageBoxButtons.YesNo,
MessageBoxIcon.Question);
                if (réponse == DialogResult.Yes)
                {
                    principal_class.GetInstance().Supprimer("t_etudiant", "id_etudiant", int.Parse(label1.Text));
                    init();
                    dataGridView2.DataSource = principal_class.GetInstance().GetTable("t_etudiant");

                }

            }
            else
            {
                MessageBox.Show("ID doit etre rensigne");
            }
        }
    }
}
