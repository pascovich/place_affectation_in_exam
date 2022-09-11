using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class affectation_place_class
    {
        int id;
        int ref_inscription;
        int ref_ranger;
        int ref_examen;

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

        public int Ref_inscription
        {
            get
            {
                return ref_inscription;
            }

            set
            {
                ref_inscription = value;
            }
        }

        public int Ref_ranger
        {
            get
            {
                return ref_ranger;
            }

            set
            {
                ref_ranger = value;
            }
        }

        public int Ref_examen
        {
            get
            {
                return ref_examen;
            }

            set
            {
                ref_examen = value;
            }
        }
    }
}
