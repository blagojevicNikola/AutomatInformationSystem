using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    interface IAutomatDAO
    {
        List<AutomatDTO> GetAllAutomati();

        List<AutomatFullInfoDTO> GetAllAutomatiFullInfo();
        AutomatDTO GetAutomatById(int id, string tip);
        void saveAutomat(AutomatDTO automat);

        void updateAutomat(AutomatDTO automat);

        void deleteAutomat(int id, string tip);
    }
}
