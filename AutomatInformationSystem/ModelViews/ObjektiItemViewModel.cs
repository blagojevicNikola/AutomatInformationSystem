using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class ObjektiItemViewModel:INotifyPropertyChanged
    {
        private bool izabran = false;
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }


        public bool Izabran { get { return izabran; } set { izabran = value; NotifyPropertyChanged("Izabran"); } }

        public ObjektiItemViewModel(int id, string naziv, string adresa)
        {
            ID = id;
            Naziv = naziv;
            Adresa = adresa;

        }

        public ObjektiItemViewModel(int id, string naziv, string adresa, bool izabran)
        {
            Izabran = izabran;
            ID = id;
            Naziv = naziv;
            Adresa = adresa;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
