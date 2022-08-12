using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class UgovorDTO
    {
        public int ID { get; set; }
        public DateTime DatumPotpisa { get; set; }
        public int VlasnikID { get; set; }
        public DateTime DatumPrestankaVazenja { get; set; }

        public UgovorDTO()
        {

        }

        public UgovorDTO(int id, DateTime datumPotpisa, int vlasnikId, DateTime datumPrestankaVazenja)
        {
            ID = id;
            DatumPotpisa = datumPotpisa;
            VlasnikID = vlasnikId;
            DatumPrestankaVazenja = datumPrestankaVazenja;
        }
        public UgovorDTO(DateTime datumPotpisa, int vlasnikId, DateTime datumPrestankaVazenja)
        {
            DatumPotpisa = datumPotpisa;
            VlasnikID = vlasnikId;
            DatumPrestankaVazenja = datumPrestankaVazenja;
        }

    }
}
