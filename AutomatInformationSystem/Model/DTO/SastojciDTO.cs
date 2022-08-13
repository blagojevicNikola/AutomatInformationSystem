using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class SastojciDTO
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public SastojciDTO()
        {

        }

        public SastojciDTO(int id, string naziv)
        {
            ID = id;
            Naziv = naziv;
        }

        public SastojciDTO(string naziv)
        {
            Naziv = naziv;
        }
    }
}
