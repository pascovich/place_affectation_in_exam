using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class cours_class
    {
        int id;
        string designation;
        int ref_affecter;

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
    }
}
