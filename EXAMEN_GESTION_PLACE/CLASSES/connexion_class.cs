using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_GESTION_PLACE.CLASSES
{
    class connexion_class
    {
        public string chemin;
        public void connect()
        {
            chemin = "Data Source=PASCOVICH\\SA;Initial Catalog=GESTION_PLACE_EXAMEN;Persist Security Info=True;User ID=SA;Password=ROOT";
        }
    }
}
