using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class SelectionWorkerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool izabran;
        public bool Izabran { get { return izabran; } set { izabran = value; NotifyPropertyChanged("Izabran"); } }
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public SelectionWorkerViewModel(int id, string ime, string prezime)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            Izabran = false;
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
