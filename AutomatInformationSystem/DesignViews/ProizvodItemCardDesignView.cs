using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class ProizvodItemCardDesignView:ProizvodItemCardViewModel
    {
        public static ProizvodItemCardDesignView Instance => new ProizvodItemCardDesignView();

        private ProizvodItemCardDesignView()
        {
            ID = 1;
            Naziv = "Smoki";
            Tip = "Hrana";
        }
    }
}
