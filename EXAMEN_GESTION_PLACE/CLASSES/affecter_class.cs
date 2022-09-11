using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class affecter_class
    {
        int id;
        int ref_faculte;
        int ref_promotion;
        string designation;

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

        public int Ref_faculte
        {
            get
            {
                return ref_faculte;
            }

            set
            {
                ref_faculte = value;
            }
        }

        public int Ref_promotion
        {
            get
            {
                return ref_promotion;
            }

            set
            {
                ref_promotion = value;
            }
        }

        public string Designation
        {
            get
            {
                return designation;
            }

            set
            {
                designation = value;
            }
        }
    }
}
