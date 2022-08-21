using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    interface IPrihodDAO
    {
        List<PrihodDTO> GetAllPrihodByAutomatId(int id);
        void addPrihod(PrihodDTO prihod);
    }
}
