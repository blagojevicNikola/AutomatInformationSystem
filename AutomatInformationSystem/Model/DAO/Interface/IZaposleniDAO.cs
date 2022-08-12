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

        void deleteZaposleni(ZaposleniDTO zaposleni);

        void updateZaposleni(ZaposleniDTO zaposleni);
    }
}
