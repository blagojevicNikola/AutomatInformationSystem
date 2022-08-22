using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class PunjenjeDTO
    {
        public int PunjenjeID { get; set; }
        public int RadnikID { get; set; }
        public int AutomatID { get; set; }
        public DateTime DatumPunjenja { get; set; }
        public double Prihod { get; set; }

        public PunjenjeDTO(int automatId, int radnikId, DateTime datumPunjenja, double cijena)
        {
            AutomatID = automatId;
            RadnikID = radnikId;
            DatumPunjenja = datumPunjenja;
            Prihod = cijena;
        }

        public PunjenjeDTO(int punjenjeId, int automatId, int radnikId, DateTime datumPunjenja, double cijena)
        {
            PunjenjeID = punjenjeId;
            AutomatID = automatId;
            RadnikID = radnikId;
            DatumPunjenja = datumPunjenja;
            Prihod = cijena;
        }
    }
}
