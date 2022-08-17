using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    interface ISastojciDAO
    {
        List<SastojciDTO> GetAllSastojci();
        SastojciDTO GetSastojakById(int id);

        void saveSastojak(string naziv);

        void deleteSastojak(SastojciDTO sastojak);

        void updateSastojak(SastojciDTO sastojak);

        List<SastojciDTO> GetSelectedSastojci(int id);
        List<SastojciDTO> GetAvailableSastojci(int id);
        
    }
}
