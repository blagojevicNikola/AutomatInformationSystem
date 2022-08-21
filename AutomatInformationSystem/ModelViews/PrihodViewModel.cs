using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class PrihodViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int AutomatID { get; set; }
        public int RadnikID { get; set; }
        public string DatumPunjenja { get; set; }
        public string Prihod { get; set; }
        public ICommand InfoCommand { get; set; }

        public PrihodViewModel(int automatId, int radnikId, string datumPunjenja, string prihod)
        {
            AutomatID = automatId;
            RadnikID = radnikId;
            DatumPunjenja = datumPunjenja;
            Prihod = prihod;
        }
    }
}
