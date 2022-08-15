using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class AutomatItemCardDesignView : AutomatItemCardViewModel
    {
        public static AutomatItemCardDesignView Instance => new AutomatItemCardDesignView();

        private AutomatItemCardDesignView()
        {
            ID = 1;
            Sifra = 12345678;
            Lokacija = "ETF - Banja Luka (Srpskih rudara 9, Banja Luka)";
            Tip = "Hrana";
            Potrosnja = "1231";
        }
    }
}
