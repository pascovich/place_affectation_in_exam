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
    public partial class affectation_place_control : UserControl
    {
        public affectation_place_control()
        {
            InitializeComponent();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            string d1 = txt_qr.Text;
           
            //List<string> array_data = new List<string>();
            //array_data.Add(d1);
           // array_data.Add(d2);

            var mydata = QG.CreateQrCode(d1, QRCoder.QRCodeGenerator.ECCLevel.H);
          
            var code = new QRCoder.QRCode(mydata);
          // pictureBox1.Image = code.GetGraphic(50);
           pictureEdit1.Image = code.GetGraphic(50);
        }
        int id;
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                exemple_class s = new exemple_class();
                s.Id = id;
                s.Champ = txt_qr.Text;
                principal_class.GetInstance().operation_exemple_test(s, pictureEdit1);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void affectation_place_control_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource =  principal_class.GetInstance().GetTable("exemple_qr");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txt_qr.Text = dataGridView1.CurrentRow.Cells["champ"].Value.ToString();
                pictureEdit1.EditValue = dataGridView1.CurrentRow.Cells["image_qr"].FormattedValue;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
