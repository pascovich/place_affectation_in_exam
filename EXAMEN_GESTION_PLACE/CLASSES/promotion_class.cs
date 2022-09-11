using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class promotion_class
    {
        int promotion;
        string designation;

        public int Promotion
        {
            get
            {
                return promotion;
            }

            set
            {
                promotion = value;
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
