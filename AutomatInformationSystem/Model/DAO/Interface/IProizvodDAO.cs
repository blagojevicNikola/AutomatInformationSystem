using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    interface IProizvodDAO
    {
        List<ProizvodDTO> GetAllProizvod();
        ProizvodDTO GetProizvodById(int id);

        long saveProizvod(string naziv, string tip, List<SastojciDTO> sastojci);

        void deleteProizvod(int id, string tip);

        void updateProizvod(int id, string naziv,string tip, List<int> addSastojci, List<int> removeSastojci);
    }
}
