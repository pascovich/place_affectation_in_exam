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
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;

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
          //  QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
          //  string d1 = txt_qr.Text;
           
          //  //List<string> array_data = new List<string>();
          //  //array_data.Add(d1);
          // // array_data.Add(d2);

          //  var mydata = QG.CreateQrCode(d1, QRCoder.QRCodeGenerator.ECCLevel.H);
          
          //  var code = new QRCoder.QRCode(mydata);
          //// pictureBox1.Image = code.GetGraphic(50);
          // pictureEdit1.Image = code.GetGraphic(50);
        }
        int id;
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    exemple_class s = new exemple_class();
            //    s.Id = id;
            //    s.Champ = txt_qr.Text;
            //    principal_class.GetInstance().operation_exemple_test(s, pictureEdit1);
            //}catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevise; 
        private void affectation_place_control_Load(object sender, EventArgs e)
        {
            try
            {
                //filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                //foreach (FilterInfo filterInfo in filterInfoCollection)
                //    cboDevice.Items.Add(filterInfo.Name);
                //cboDevice.SelectedIndex = 0;
                txt_id_ranger.Text =  principal_class.GetInstance().GetNextNumPlace();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    txt_qr.Text = dataGridView1.CurrentRow.Cells["champ"].Value.ToString();
            //    pictureEdit1.EditValue = dataGridView1.CurrentRow.Cells["image_qr"].FormattedValue;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            try
            {
                gunaDataGridView1.DataSource =  principal_class.GetInstance().GetTabledependdate("exam_program", DateTime.Parse(gunaDateTimePicker1.Text));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            //captureDevise = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);

            //captureDevise.NewFrame += CaptureDevice_NewFrame;
            // captureDevise.NewFrame +=
            //captureDevise.Start();

        }

        private void txt_result_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_result.Text.Length==5)
                
            {
                var ref_qr = txt_result.Text;

                principal_class.GetInstance().getAllBYID(txt_id_etudiant,txt_id_examen,gunaLabel1, gunaLabel2, gunaLabel3,gunaLabel4,gunaLabel6,gunaLabel8,gunaLabel5,gunaLabel7, "show_program_to_affect_place_view", "id_inscription",txt_result.Text,DateTime.Parse(gunaDateTimePicker1.Text));
                principal_class.GetInstance().retreivePhoto("photo", "t_etudiant", "id_etudiant", ref_qr, pictureEdit1);

                txt_result.Text = "";
            }
            else
            {

            }

        }
        public void retrieve_place_to_affect()
        {

        }
        int ida;
        private void gunaButton1_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_etudiant.Text!="*" && txt_id_examen.Text!="*" && txt_id_ranger.Text!="*")
                {
                    affectation_place_class f = new affectation_place_class();
                    f.Id = ida;
                    f.Ref_examen = int.Parse(txt_id_examen.Text);
                    f.Ref_inscription = int.Parse(txt_id_etudiant.Text);
                    f.Ref_ranger = int.Parse(txt_id_ranger.Text);

                    principal_class.GetInstance().operation_affectation_place(f);

                    txt_id_ranger.Text = "";
                    txt_id_etudiant.Text = "";
                    txt_id_examen.Text = "";
                    gunaLabel1.Text = "*****";
                    gunaLabel2.Text = "*****";
                    gunaLabel3.Text = "*****";
                    gunaLabel4.Text = "*****";
                    gunaLabel5.Text = "*****";
                    gunaLabel6.Text = "*****";
                    gunaLabel7.Text = "*****";
                    gunaLabel8.Text = "*****";
                }
                else
                {
                    MessageBox.Show("scan your badge please");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        //{
        //    //throw new NotImplementedException();
        //    pictureEdit1.Image = (Bitmap)eventArgs.
        //}


    }
}
