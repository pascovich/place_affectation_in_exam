using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class inscription_class
    {
        int id;
        DateTime date_inscr;
        int ref_etudiant;
        int ref_affecter;
        int ref_annee;

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

        public DateTime Date_inscr
        {
            get
            {
                return date_inscr;
            }

            set
            {
                date_inscr = value;
            }
        }

        public int Ref_etudiant
        {
            get
            {
                return ref_etudiant;
            }

            set
            {
                ref_etudiant = value;
            }
        }

        public int Ref_affecter
        {
            get
            {
                return ref_affecter;
            }

            set
            {
                ref_affecter = value;
            }
        }

        public int Ref_annee
        {
            get
            {
                return ref_annee;
            }

            set
            {
                ref_annee = value;
            }
        }
    }
}
