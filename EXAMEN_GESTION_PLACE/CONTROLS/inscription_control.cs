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
using EXAMEN_GESTION_PLACE.REPORTS;
using DevExpress.XtraReports.UI;
//using System.Configuration

namespace EXAMEN_GESTION_PLACE.CONTROLS
{
    public partial class inscription_control : UserControl
    {
        public inscription_control()
        {
            InitializeComponent();
        }

        private void inscription_control_Load(object sender, EventArgs e)
        {
            try
            {
                principal_class.GetInstance().chargementComboBoxGuna(cb_annee_ac, "designation_annee", "t_annee_ac");
                gunaDataGridView1.DataSource = principal_class.GetInstance().GetTable("t_etudiant");
                gunaDataGridView2.DataSource = principal_class.GetInstance().GetTable("affecter_view");
                gunaDataGridView3.DataSource = principal_class.GetInstance().GetTable("inscription_view");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = gunaDataGridView1.CurrentRow.Cells["id_etudiant"].Value.ToString();
                txt_nom.Text = gunaDataGridView1.CurrentRow.Cells["nom"].Value.ToString();
                txt_postnom.Text = gunaDataGridView1.CurrentRow.Cells["postnom"].Value.ToString();
                txt_prenom.Text = gunaDataGridView1.CurrentRow.Cells["prenom"].Value.ToString();
                txt_adress.Text = gunaDataGridView1.CurrentRow.Cells["adresse"].Value.ToString();
                txt_phone.Text = gunaDataGridView1.CurrentRow.Cells["telephone"].Value.ToString();
                pictureEdit1.EditValue = gunaDataGridView1.CurrentRow.Cells["photo"].FormattedValue;
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
                textBox2.Text = gunaDataGridView2.CurrentRow.Cells["id_affecter"].Value.ToString();
                txt_affectation.Text = gunaDataGridView2.CurrentRow.Cells["designation_affecter"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int id;
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="" && cb_annee_ac.Text != "")
            {
                inscription_class j = new inscription_class();
                j.Date_inscr = DateTime.Now;
                j.Id = id;
                j.Ref_affecter = int.Parse(textBox2.Text);
                j.Ref_etudiant = int.Parse(textBox1.Text);
                j.Ref_annee = int.Parse(principal_class.GetInstance().GetID("id_annee","t_annee_ac","designation_annee",cb_annee_ac.Text));
                principal_class.GetInstance().operation_inscription(j,pictureEdit2);
                gunaDataGridView3.DataSource = principal_class.GetInstance().GetTable("inscription_view");
                init();
            }
            else
            {
                MessageBox.Show("renseignez tous les champs", "CHAMP VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void init()
        {
            txt_adress.Text = "adresse";
            txt_affectation.Text = "affectation";
            txt_nom.Text = "nom";
            txt_phone.Text = "phone";
            txt_postnom.Text = "postnom";
            txt_prenom.Text = "prenom";
            cb_annee_ac.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            pictureEdit2.Text = "";
            pictureEdit1.Text = "";
        }

        private void gunaDataGridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = gunaDataGridView3.CurrentRow.Cells["id_inscription"].Value.ToString();
                txt_nom.Text = gunaDataGridView3.CurrentRow.Cells["nom_complet"].Value.ToString();
                txt_adress.Text = gunaDataGridView3.CurrentRow.Cells["matricule"].Value.ToString();
                cb_annee_ac.Text = gunaDataGridView3.CurrentRow.Cells["designation_annee"].Value.ToString();
                pictureEdit2.EditValue = gunaDataGridView3.CurrentRow.Cells["imager_qr"].FormattedValue;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text!="" && textBox2.Text != "" && cb_annee_ac.Text != "")
            {
                inscription_class j = new inscription_class();
                j.Date_inscr = DateTime.Now;
                j.Id = int.Parse(textBox3.Text);
                j.Ref_affecter = int.Parse(textBox2.Text);
                j.Ref_etudiant = int.Parse(textBox1.Text);
                j.Ref_annee = int.Parse(principal_class.GetInstance().GetID("id_annee", "t_annee_ac", "designation_annee", cb_annee_ac.Text));
                principal_class.GetInstance().operation_inscription(j,pictureEdit2);
                gunaDataGridView3.DataSource = principal_class.GetInstance().GetTable("inscription_view");
                init();
            }
            else
            {
                MessageBox.Show("renseignez tous les champs ou double clique dans la table avant tout", "CHAMP VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                DialogResult réponse = MessageBox.Show("Voulez-vous vraiment supprimer cette inscription", "Suppression", MessageBoxButtons.YesNo,
MessageBoxIcon.Question);
                if (réponse == DialogResult.Yes)
                {
                    principal_class.GetInstance().Supprimer("t_inscripiton", "id_inscripiton", int.Parse(textBox3.Text));
                    init();
                    gunaDataGridView3.DataSource = principal_class.GetInstance().GetTable("inscription_view");

                }

            }
            else
            {
                MessageBox.Show("ID doit etre rensigne");
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            string d1 = textBox1.Text;

            var mydata = QG.CreateQrCode(d1, QRCoder.QRCodeGenerator.ECCLevel.H);

            var code = new QRCoder.QRCode(mydata);
            pictureEdit2.Image = code.GetGraphic(50);
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            try
            {

                rpt_carte rptt = new rpt_carte();
                rptt.DataSource = principal_class.GetInstance().get_Report_SS("carte_view", int.Parse(textBox3.Text));
                ReportPrintTool printTool = new ReportPrintTool(rptt);
                printTool.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
