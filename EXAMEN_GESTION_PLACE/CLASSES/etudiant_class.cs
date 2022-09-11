using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class etudiant_class
    {
        int id;
        string nom;
        string postnom;
        string prenom;
        string sexe;
        string phone;
        string adresse;
        string lieu;
        DateTime datetime;
        string matricule;
        string etat_civil;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Postnom
        {
            get
            {
                return postnom;
            }

            set
            {
                postnom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public string Sexe
        {
            get
            {
                return sexe;
            }

            set
            {
                sexe = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Adresse
        {
            get
            {
                return adresse;
            }

            set
            {
                adresse = value;
            }
        }

        public string Lieu
        {
            get
            {
                return lieu;
            }

            set
            {
                lieu = value;
            }
        }

        public DateTime Datetime
        {
            get
            {
                return datetime;
            }

            set
            {
                datetime = value;
            }
        }

        public string Matricule
        {
            get
            {
                return matricule;
            }

            set
            {
                matricule = value;
            }
        }

        public string Etat_civil
        {
            get
            {
                return etat_civil;
            }

            set
            {
                etat_civil = value;
            }
        }
    }
}
