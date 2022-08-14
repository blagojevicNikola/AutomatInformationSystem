using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    interface ILokacijeDAO
    {
        List<LokacijaDTO> GetAllLokacije();
        LokacijaDTO GetLokacijaById(int id);
        void saveLokacija(LokacijaDTO lokacija);
        void updateLokacija(LokacijaDTO lokacija);
        void deleteLokacija(LokacijaDTO lokacija);
    }
}
