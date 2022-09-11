using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class examen_class
    {
        int id;
        DateTime date_ex;
        int ref_cours;
        int ref_session;

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

        public DateTime Date_ex
        {
            get
            {
                return date_ex;
            }

            set
            {
                date_ex = value;
            }
        }

        public int Ref_cours
        {
            get
            {
                return ref_cours;
            }

            set
            {
                ref_cours = value;
            }
        }

        public int Ref_session
        {
            get
            {
                return ref_session;
            }

            set
            {
                ref_session = value;
            }
        }
    }
}
