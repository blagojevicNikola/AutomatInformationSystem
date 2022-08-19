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
    class FillAutomatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ClosingRequest;

        public string kolicina;
        public string prihod;

        public string Sifra { get; set; }
        public string Kolicina { get { return kolicina; } set { kolicina = value; NotifyPropertyChanged("Kolicina"); } }
        public string Prihod { get { return prihod; } set { prihod = value; NotifyPropertyChanged("Prihod"); } }
        public ObservableCollection<DostupanProizvodViewModel> DostupniProizvodi { get; set; }
        public ObservableCollection<IzabranProizvodViewModel> IzabraniProizvodi { get; set; }
        public DostupanProizvodViewModel ToBeAdded { get; set; }
        public IzabranProizvodViewModel ToBeRemoved { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand CloseCommand { get; set; }



        public FillAutomatViewModel(int id, string tip)
        {
            IAutomatDAO autoDao = new AutomatiImplDAO();
            AutomatDTO existingAuto = autoDao.GetAutomatById(id, tip);
            Sifra = existingAuto.SerijskiBroj.ToString();
            IProizvodDAO proDao = new ProizvodiImplDAO();
            List<NudiProizvodDTO> proizvodiAutomata;
            if(tip=="Hrana")
            {
                proizvodiAutomata = proDao.GetAllHranaOfAutomat(id);
            }
            else
            {
                proizvodiAutomata = proDao.GetAllKafaOfAutomat(id);
            }
            ObservableCollection<DostupanProizvodViewModel> obsProizvodi = new ObservableCollection<DostupanProizvodViewModel>();
            proizvodiAutomata.ForEach(s => obsProizvodi.Add(new DostupanProizvodViewModel(s.ID, s.Naziv)));
            DostupniProizvodi = obsProizvodi;

        }

        public void addProizvod()
        {
            if (ToBeAdded != null && !IzabraniProizvodi.Any(s => s.ID == ToBeAdded.ID) && int.TryParse(Kolicina, out _))
            {
                
            }
        }

        public void removeProizvod()
        {

        }

        public void confirmFill()
        {

        }

        public void closeWindow()
        {
            ClosingRequest(this, EventArgs.Empty);
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
