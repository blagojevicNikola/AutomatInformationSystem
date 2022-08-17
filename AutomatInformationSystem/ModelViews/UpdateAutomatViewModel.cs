using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class UpdateAutomatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OkCommand { get; set; }
        public ICommand ClearSelectionCommand { get; set; }

        private string serijskiBroj;
        private string datumPostavljanja;
        private string potrosnja;
        private string tip;
        private string kapacitet;

        public string SerijskiBroj { get { return serijskiBroj; } set { serijskiBroj = value; NotifyPropertyChanged("SerijskiBroj"); } }

        public string DatumPostavljanja { get { return datumPostavljanja; } set { datumPostavljanja = value; NotifyPropertyChanged("DatumPostavljanja"); } }

        public string Potrosnja { get { return potrosnja; } set { potrosnja = value; NotifyPropertyChanged("Potrosnja"); } }

        public string Tip { get { return tip; } set { tip = value; NotifyPropertyChanged("Tip"); } }

        public string Kapacitet { get { return kapacitet; } set { kapacitet = value; NotifyPropertyChanged("Kapacitet"); } }

        public ObservableCollection<ObjektiItemViewModel> ListaObjekata { get; set; }

        public UpdateAutomatViewModel(int id, string datumPostavljanja, string potrosnja, string tip, string kapacitet)
        {
            SerijskiBroj = id.ToString();
            DatumPostavljanja = datumPostavljanja;
            Potrosnja = potrosnja;
            Tip = tip;
            Kapacitet = kapacitet;
        }

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
