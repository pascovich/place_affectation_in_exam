using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class ranger_class
    {
        int id;
        string designation;
        int ref_salle;
        int nombre_place;

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

        public int Ref_salle
        {
            get
            {
                return ref_salle;
            }

            set
            {
                ref_salle = value;
            }
        }

        public int Nombre_place
        {
            get
            {
                return nombre_place;
            }

            set
            {
                nombre_place = value;
            }
        }
    }
}
