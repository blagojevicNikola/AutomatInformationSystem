using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class KafaDTO : ProizvodDTO
    {
        public KafaDTO() : base()
        {

        }

        public KafaDTO(int id, string naziv, string tip):base(id, naziv, tip)
        {

        }

        public KafaDTO(string naziv, string tip):base(naziv, tip)
        {

        }
    }
}
