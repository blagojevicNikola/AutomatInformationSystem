using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class SastojciViewModel : INotifyPropertyChanged
    {

        private bool izabrano = false;
        public int ID { get; set; }

        public string Naziv { get; set; }
        public bool Izabrano { get { return izabrano; } set { izabrano = value; NotifyPropertyChanged("Izabrano"); } }

        public SastojciViewModel(int id, string naziv)
        {
            ID = id;
            Naziv = naziv;
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
