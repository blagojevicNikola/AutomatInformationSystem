using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem.Model.DTO
{
    public class ObjekatDTO
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public int VlasnikID { get; set; }

        public int LokacijaID { get; set; }

        public int? UgovorID { get; set; }

        public ObjekatDTO()
        {

        }

        public ObjekatDTO(int id, string naziv, int vlasnikId, int lokacijaId, int? ugovorId)
        {
            ID = id;
            Naziv = naziv;
            VlasnikID = vlasnikId;
            LokacijaID = lokacijaId;
            UgovorID = ugovorId;
        }

        public ObjekatDTO(string naziv, int vlasnikId, int lokacijaId, int? ugovorId)
        {
            Naziv = naziv;
            VlasnikID = vlasnikId;
            LokacijaID = lokacijaId;
            UgovorID = ugovorId;
        }
    }
}
