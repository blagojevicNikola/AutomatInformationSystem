using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class HranaDTO : ProizvodDTO
    {
        public HranaDTO():base()
        {

        }

        public HranaDTO(int id, string naziv, string tip):base(id, naziv, tip)
        {

        }

        public HranaDTO(string naziv, string tip):base(naziv, tip)
        {

        }
    }
}
