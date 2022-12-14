using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public interface IZaposleniDAO
    {
        List<ZaposleniDTO> GetAllZaposleni();
        ZaposleniDTO GetZaposleniById(int id);

        void saveZaposleni(string ime, string prezime, string telefon, DateTime datumRodjenja, string tip);

        void deleteZaposleni(int id, string tip);

        void updateZaposleni(ZaposleniDTO zaposleni);

        List<RadnikDTO> GetAllRadnici();
        RadnikDTO GetRadnikById(int id);
    }
}
