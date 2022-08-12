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

        void saveProizvod(string naziv, string tip);

        void deleteProizvod(ProizvodDTO proizvod);

        void updateProizvod(ProizvodDTO proizvod);
    }
}
