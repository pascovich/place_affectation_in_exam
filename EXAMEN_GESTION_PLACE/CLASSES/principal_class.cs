using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXAMEN_GESTION_PLACE.CLASSES;
using DevExpress.XtraEditors;
using Guna.UI.WinForms;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class principal_class
    {
        public static principal_class instance = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataAdapter dt = null;
        connexion_class cnx = null;
        DataSet ds = null;

        public static principal_class GetInstance()
        {
            if (instance == null)

                instance = new principal_class();
            return instance;

        }
        public void innitialiseConnect()
        {
            try
            {
                cnx = new connexion_class();
                cnx.connect();
                con = new SqlConnection(cnx.chemin);
                // MessageBox.Show("connexion okkkkkkk");
            }
            catch (Exception e)
            {
                MessageBox.Show("l'un de vos fichiers de configuration est incorrect" + e.Message);
            }

        }
        public void appel_pannel(Panel p, Control co)
        {
            p.Controls.Clear();
            p.Controls.Add(co);
            p.Show();

        }

        public void Supprimer(string nomTable, string nomChamp, int id)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("DELETE FROM " + nomTable + " WHERE  " + nomChamp + "=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("suppresion avec success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }
        public DataTable GetTable(string nomTable)
        {
            innitialiseConnect();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) ;
            con.Open();
            cmd = new SqlCommand("SELECT * FROM " + nomTable + "", con);
            dt = null;
            dt = new SqlDataAdapter(cmd);
            ds = new DataSet();

            dt.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }
        //public void GetTableGrid(string nomTable, GridControl grid)
        //{
        //    innitialiseConnect();
        //    if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();

        //    cmd = new SqlCommand("SELECT * FROM " + nomTable + "", con);
        //    dt = new SqlDataAdapter(cmd);
        //    ds = new DataSet();
        //    dt.Fill(ds, nomTable);
        //    con.Close();
        //    grid.DataSource = ds.Tables[nomTable];
        //}
        public void chargementComboBox(System.Windows.Forms.ComboBox cmb, string nomChamp, string nomTable)
        {
            innitialiseConnect();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            using (IDbCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = @"select distinct " + nomChamp + " from " + nomTable + "";

                IDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    string de = rd[nomChamp].ToString();
                    cmb.Items.Add(de);
                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
        }
        public void chargementComboBoxGuna(GunaComboBox cmb, string nomChamp, string nomTable)
        {
            innitialiseConnect();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            using (IDbCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = @"select distinct " + nomChamp + " from " + nomTable + "";

                IDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    string de = rd[nomChamp].ToString();
                    cmb.Items.Add(de);
                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
        }
        //public void AfficheComboBoxdevexpress(System.Windows.Forms.ComboBox cb, Bunifu.Framework.UI.BunifuMaterialTextbox client, Bunifu.Framework.UI.BunifuMaterialTextbox marchandise, TextEdit prix, string reference)
        public void AfficheComboBoxvente(System.Windows.Forms.ComboBox cb, Label qte, string reference)
        {
            innitialiseConnect();
            int a = int.Parse(GetID("id_medicament", "tmedicament", "designation", reference));
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            using (IDbCommand cmd = con.CreateCommand())
            {
                //cmd.CommandText = "SELECT montant_a_payer from tfacture where id_facture=" + a;
                cmd.CommandText = "SELECT qte_stock from tmedicament where id_medicament=" + a;

                IDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    qte.Text = rd[0].ToString();

                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
        }

        public void dash(Label x)
        {
            innitialiseConnect();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            using (IDbCommand cmd = con.CreateCommand())
            {
                //cmd.CommandText = "SELECT montant_a_payer from tfacture where id_facture=" + a;
                cmd.CommandText = "SELECT count(id) from entreprise";

                IDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    x.Text = rd[0].ToString();

                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
        }
        public void AfficheComboBoxOccupation(System.Windows.Forms.ComboBox cb, Label prix, string reference)
        {
            innitialiseConnect();
            //int a = int.Parse(GetID("id_medicament", "tmedicament", "designation", reference));
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            using (IDbCommand cmd = con.CreateCommand())
            {
                //cmd.CommandText = "SELECT montant_a_payer from tfacture where id_facture=" + a;
                cmd.CommandText = "SELECT tarif from view_occuper where id=" + reference;

                IDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    prix.Text = rd[0].ToString();

                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
        }

        public void AfficheComboBoxexamen(System.Windows.Forms.ComboBox cb, Label prix, string reference)
        {
            innitialiseConnect();
            //int a = int.Parse(GetID("id_medicament", "tmedicament", "designation", reference));
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            using (IDbCommand cmd = con.CreateCommand())
            {
                //cmd.CommandText = "SELECT montant_a_payer from tfacture where id_facture=" + a;
                cmd.CommandText = "SELECT tarif from texamen where id_examen=" + reference;

                IDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    prix.Text = rd[0].ToString();

                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
        }

        public void AfficheComboBoxconsommer(System.Windows.Forms.ComboBox cb, Label prix, string reference)
        {
            innitialiseConnect();
            //int a = int.Parse(GetID("id_medicament", "tmedicament", "designation", reference));
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            using (IDbCommand cmd = con.CreateCommand())
            {
                //cmd.CommandText = "SELECT montant_a_payer from tfacture where id_facture=" + a;
                cmd.CommandText = "SELECT total_prix from tconsommer where id_consommer=" + reference;

                IDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    prix.Text = rd[0].ToString();

                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
        }

        public void chargementDonneIdComboBox(System.Windows.Forms.ComboBox cmb, String Champafficherdanscomb2, string nomTable, System.Windows.Forms.ComboBox cmb_destination, String reference)
        {

            try
            {
                innitialiseConnect();
                int name = int.Parse(GetID("id_malade", "tmalade", "nom", reference));
                if (con.State.ToString().Trim().ToLower().Equals("open"))
                {
                    con.Close();
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("select distinct " + Champafficherdanscomb2 + " from " + nomTable + " where ref_malade=" + name + "", con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cmb_destination.Items.Add(dr[Champafficherdanscomb2].ToString());

                    }
                    con.Close();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        public string GetID(String champ, String table, String champcondition1, String valeur1)
        {
            string _id = string.Empty;

            innitialiseConnect();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT DISTINCT " + champ + " FROM " + table + " WHERE " + champcondition1 + " = @valeur1";
                cmd.Parameters.Add(new SqlParameter("@valeur1", SqlDbType.NVarChar)).Value = valeur1;
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                        _id = dr.GetFieldValue<object>(0).ToString();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return _id.ToString();
        }

        public string GetQllInfoQr(String champ, String table, String champcondition1, String valeur1)
        {
            string _id = string.Empty;

            innitialiseConnect();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT DISTINCT " + champ + " FROM " + table + " WHERE " + champcondition1 + " = @valeur1";
                cmd.Parameters.Add(new SqlParameter("@valeur1", SqlDbType.NVarChar)).Value = valeur1;
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                        _id = dr.GetFieldValue<object>(0).ToString();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return _id.ToString();
        }
        private static void setParameter(SqlCommand cmd, string name, DbType type, int length, object paramValue)
        {
            IDbDataParameter a = cmd.CreateParameter();
            a.ParameterName = name;
            a.Size = length;
            a.DbType = type;

            if (paramValue == null)
            {
                if (!a.IsNullable)
                {
                    a.DbType = DbType.String;
                }
                a.Value = DBNull.Value;
            }
            else
                a.Value = paramValue;
            cmd.Parameters.Add(a);
        }
        public void retreivePhoto(string champPhoto, string nomTable, string nomChampcode, string value, PictureBox pic)
        {
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();

                cmd = new SqlCommand("SELECT " + champPhoto + " from " + nomTable + " WHERE  " + nomChampcode + " = '" + value + "'", con);
                dt = new SqlDataAdapter(cmd);
                Object result = cmd.ExecuteScalar();

                if (DBNull.Value == (result))
                {
                }
                else
                {
                    Byte[] buffer = (Byte[])result;
                    MemoryStream ms = new MemoryStream(buffer);
                    Image image = Image.FromStream(ms);
                    pic.Image = image;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
        public DataTable ChargerTable(String table, String champcondition, String valeur)
        {
            DataTable dTable = new DataTable();

            try
            {
                innitialiseConnect();
                if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "SELECT * FROM " + table + " WHERE " + champcondition + " = @champcondition";

                cmd.Parameters.Add(new SqlParameter("@champcondition", SqlDbType.NVarChar)).Value = valeur;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dTable);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                con.Close();
            }
            return dTable;
        }
        public DataTable recherche_Infromation(string NomTable, string Nom, string Postnom, string Prenom, string recherche)
        {
            innitialiseConnect();
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            cmd = new SqlCommand("select * from " + NomTable + " WHERE " + Nom + " LIKE '%" + recherche + "%' or " + Postnom + " LIKE '%" + recherche + "%' or " + Prenom + " LIKE '%" + recherche + "%' ", con);
            dt = null;
            dt = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dt.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }
        public void rechercher(string nomTable, string nomCond, string champSearch, DataGridView datav)
        {
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open(); //ouvrons notre connection

                cmd = con.CreateCommand(); //pour executer la commande
                SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM " + nomTable + " WHERE " + nomCond + " like '%" + champSearch + "%' ", con); //crons une instance de la classe etudiant(pour remplir le dataset)
                DataSet ds = new DataSet(); //object qui gardera les donnees en memoire
                data.Fill(ds, nomTable); //chargeons les donnees dans le dataset(en memoire)
                con.Close(); //fermons la connexion
                //return ds.Tables[0];
                datav.DataSource = ds.Tables[0]; //chargeons dans un control appele dataGridView


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public DataSet get_Report_X(string nomTable, string nomchamp, int valchamp)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE " + nomchamp + "=@valchamp", con);
                cmd.Parameters.AddWithValue("@valchamp", valchamp);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }

        public DataSet get_Report_Trier(string nomTable, string nomchamp, DateTime val1, DateTime val2)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE " + nomchamp + " between @date1 and @date2 ", con);
                setParameter(cmd, "@date1", DbType.DateTime, 30, val1);
                setParameter(cmd, "@date2", DbType.DateTime, 30, val2);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }

        public DataSet search_data_depend_date(string nomTable, string nomchamp, DateTime val1)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE id_paiement=@date1", con);
                
                setParameter(cmd, "@date1", DbType.DateTime, 30, val1);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }
        public DataTable GetTabledependdate(string nomTable, DateTime val1)
        {
            innitialiseConnect();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) ;
            con.Open();
            cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE date_examen=@date1", con);

            setParameter(cmd, "@date1", DbType.DateTime, 30, val1);
            dt = null;
            dt = new SqlDataAdapter(cmd);
            ds = new DataSet();
            
            dt.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }
        public DataSet get_Report_S(string nomTable, string idTable)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + " ORDER BY " + idTable + "", con);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }

        public DataSet get_Report_Trier(string nomTable, string nomchamp, DateTime val1, DateTime val2, string champCondition1, string valeur1)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE (" + nomchamp + " between @date1 and @date2) AND " + champCondition1 + " =@valeur1 ", con);
                cmd.Parameters.Add(new SqlParameter("@date1", SqlDbType.DateTime)).Value = val1;
                cmd.Parameters.Add(new SqlParameter("@date2", SqlDbType.DateTime)).Value = val2;
                cmd.Parameters.Add(new SqlParameter("@valeur1", SqlDbType.NVarChar)).Value = valeur1;
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }

        public DataSet get_Report_Trier(string nomTable, string nomchamp, DateTime val1, DateTime val2, string champOrdre)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE " + nomchamp + " between @date1 and @date2 ORDER BY " + champOrdre + "", con);
                cmd.Parameters.Add(new SqlParameter("@date1", SqlDbType.DateTime)).Value = val1;
                cmd.Parameters.Add(new SqlParameter("@date2", SqlDbType.DateTime)).Value = val2;
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }

        public DataTable ChargerTable(String table)
        {
            DataTable dTable = new DataTable();

            try
            {
                innitialiseConnect();
                if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "SELECT * FROM " + table + "";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dTable);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                con.Close();
            }
            return dTable;
        }


        public void operation_entreprise(etudiant_class foc, PictureEdit pic)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_etudiant @code,@nom,@postnom,@prenom,@sexe,@telephone,@adresse,@photo,@lieu_naissance,@date_naissance,@etat_civil,''", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@nom", foc.Nom);
                cmd.Parameters.AddWithValue("@postnom", foc.Postnom);
                cmd.Parameters.AddWithValue("@prenom", foc.Prenom);
                cmd.Parameters.AddWithValue("@sexe", foc.Sexe);
                cmd.Parameters.AddWithValue("@telephone", foc.Phone);
                cmd.Parameters.AddWithValue("@adresse", foc.Adresse);

                MemoryStream m = new MemoryStream();
                pic.Image.Save(m, pic.Image.RawFormat);
                byte[] im = m.GetBuffer();
                SqlParameter sp = new SqlParameter("@photo", SqlDbType.Image);
                sp.Value = im;
                cmd.Parameters.Add(sp);

                cmd.Parameters.AddWithValue("@lieu_naissance", foc.Lieu);
                cmd.Parameters.AddWithValue("@date_naissance", foc.Datetime);
                cmd.Parameters.AddWithValue("@etat_civil", foc.Etat_civil);

               
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public void operation_exemple_test(exemple_class foc, PictureBox pic)
        public void operation_exemple_test(exemple_class foc, PictureEdit pic)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_exemple_qr @code,@champ,@image_qr", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@champ", foc.Champ);

                MemoryStream m = new MemoryStream();
                pic.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] im = m.ToArray();
                cmd.Parameters.AddWithValue("@image_qr", im);
                
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void operation_affectation_place(affectation_place_class foc)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_affectation_place @code,@ref_examen,@ref_ranger,@ref_inscription", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@ref_examen", foc.Ref_examen);
                cmd.Parameters.AddWithValue("@ref_ranger", foc.Ref_ranger);
                cmd.Parameters.AddWithValue("@ref_inscription", foc.Ref_inscription);
             
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void operation_affectation(affecter_class foc)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_affecter @code,@designation_affecter,@ref_faculte,@ref_promotion", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@designation_affecter", foc.Designation);
                cmd.Parameters.AddWithValue("@ref_faculte", foc.Ref_faculte);
                cmd.Parameters.AddWithValue("@ref_promotion", foc.Ref_promotion);

                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void operation_annee(annee_ac_class foc)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_annee_ac @code,@designation_annee_ac", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@designation_annee_ac", foc.Designation);
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void operation_cours(cours_class foc)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_cours @code,@designation_cours,@ref_affecter", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@designation_cours", foc.Designation);
                cmd.Parameters.AddWithValue("@ref_affecter", foc.Ref_affecter);
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void operation_examen(examen_class foc)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_examen @code,@date_examen,@ref_cours,@ref_session", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@date_examen", foc.Date_ex);
                cmd.Parameters.AddWithValue("@ref_cours", foc.Ref_cours);
                cmd.Parameters.AddWithValue("@ref_session", foc.Ref_session);
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void operation_faculte(faculte_class foc)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_faculte @code,@designation_faculte", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@designation_faculte", foc.Designation);
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void operation_inscription(inscription_class foc,PictureEdit pic)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_inscription @code,@ref_affecter,@ref_etudiant,@ref_annee,@date_inscription,@imager_qr", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@ref_affecter", foc.Ref_affecter);
                cmd.Parameters.AddWithValue("@ref_etudiant", foc.Ref_etudiant);
                cmd.Parameters.AddWithValue("@ref_annee", foc.Ref_annee);
                cmd.Parameters.AddWithValue("@date_inscription", foc.Date_inscr);

                MemoryStream m = new MemoryStream();
                pic.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] im = m.ToArray();
                cmd.Parameters.AddWithValue("@imager_qr", im);


                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void operation_promotion(promotion_class foc)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_promotion @code,@designation_promotion", con);
                cmd.Parameters.AddWithValue("@code", foc.Promotion);
                cmd.Parameters.AddWithValue("@designation_promotion", foc.Designation);
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void operation_ranger(ranger_class foc)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_ranger @code,@designation_ranger,@nombre_chaise_ranger,@ref_salle", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@designation_ranger", foc.Designation);
                cmd.Parameters.AddWithValue("@nombre_chaise_ranger", foc.Nombre_place);
                cmd.Parameters.AddWithValue("@ref_salle", foc.Ref_salle);
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void operation_salle(salle_class foc)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_salle @code,@designation_salle,@nombre_place,@place_dispo_restante", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@designation_salle", foc.Designatiom);
                cmd.Parameters.AddWithValue("@nombre_place", foc.Chaise_dispo);
                cmd.Parameters.AddWithValue("@place_dispo_restante", foc.Chaise_dispo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void operation_session(session_class foc)
        {
            try
            {
                innitialiseConnect();
                con.Open();
                cmd = new SqlCommand("execute pro_session @code,@designation_session", con);
                cmd.Parameters.AddWithValue("@code", foc.Id);
                cmd.Parameters.AddWithValue("@designation_session", foc.Designation);
                cmd.ExecuteNonQuery();
                MessageBox.Show("operation reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataSet get_Report_SS(string nomTable, int idTable)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE id_paiement = " + idTable + "", con);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }
        public void generaterandom()
        {
            Random rnd = new Random();
            MessageBox.Show(rnd.Next().ToString());
           
        }
    }
}
