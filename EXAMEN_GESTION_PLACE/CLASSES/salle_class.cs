using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class salle_class
    {
        int id;
        string designatiom;
        int chaise_dispo;

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

        public string Designatiom
        {
            get
            {
                return designatiom;
            }

            set
            {
                designatiom = value;
            }
        }

        public int Chaise_dispo
        {
            get
            {
                return chaise_dispo;
            }

            set
            {
                chaise_dispo = value;
            }
        }
    }
}
