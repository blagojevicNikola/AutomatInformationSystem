using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{ 
    interface IObjektiDAO
    {
        List<ObjekatDTO> GetAllObjekti();
        ObjekatDTO GetObjekatById(int id);
        void saveObjekat(ObjekatDTO objekat);
        void updateObjekat(ObjekatDTO objekat);
        void deleteObjekat(int id);
    }
}
