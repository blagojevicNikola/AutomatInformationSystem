using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    interface IPrihodDAO
    {
        List<PunjenjeDTO> GetAllPrihodByAutomatId(int id);
        long addPrihod(PunjenjeDTO prihod);

        PunjenjeDTO GetPunjenjeById(long id);
        void addHranaToPunjenje(long idPunjenje, long idHrana, int kolicina);
        void addSastojciToPunjenje(long idPunjenje, long idHrana, double kolicina);

        List<ProizvodPunjenjaDTO> GetAllHranaByPunjenje(long punjenjeId);
        List<ProizvodPunjenjaDTO> GetAllSastojciByPunjenje(long punjenjeId);

        bool HranaCanBeAdded(long idAutomat, long idProizvod, int kolicina, out string poruka);
        bool SastojakCanBeAdded(long idAutomat, long idSastojak, double kolicina, out string poruka);
    }
}
