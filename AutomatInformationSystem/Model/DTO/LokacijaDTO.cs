using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class LokacijaDTO
    {
        public int ID { get; set; }
        public string Grad { get; set; }    
        public string Adresa { get; set; }

        public LokacijaDTO()
        {

        }

        public LokacijaDTO(int id, string grad, string adresa)
        {
            ID = id;
            Grad = grad;
            Adresa = adresa;
        }

        public LokacijaDTO(string grad, string adresa)
        {
            Grad = grad;
            Adresa = adresa;
        }
    }
}
