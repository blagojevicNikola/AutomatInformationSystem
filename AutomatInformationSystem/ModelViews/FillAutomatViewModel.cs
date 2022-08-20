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

        private string kolicina;
        private string prihod;
        private AutomatDTO currentAutomat;
        private RadnikDTO currentRadnik;
        public string Sifra { get; set; }
        public string Kolicina { get { return kolicina; } set { kolicina = value; NotifyPropertyChanged("Kolicina"); } }
        public string Prihod { get { return prihod; } set { prihod = value; NotifyPropertyChanged("Prihod"); } }
        public ObservableCollection<DostupanProizvodViewModel> DostupniProizvodi { get; set; }
        public ObservableCollection<FillWithProizvodViewModel> IzabraniProizvodi { get; set; }
        public DostupanProizvodViewModel ToBeAdded { get; set; }
        public FillWithProizvodViewModel ToBeRemoved { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand CloseCommand { get; set; }



        public FillAutomatViewModel(int id, string tip, int radnikId)
        {
            IzabraniProizvodi = new ObservableCollection<FillWithProizvodViewModel>();
            IAutomatDAO autoDao = new AutomatiImplDAO();
            IZaposleniDAO zapDao = new ZaposleniImplDAO();
            RadnikDTO tempRadnik = zapDao.GetRadnikById(radnikId);
            radnikId = tempRadnik.Sifra;
            currentAutomat = autoDao.GetAutomatById(id, tip);
            Sifra = currentAutomat.SerijskiBroj.ToString();
            ObservableCollection<DostupanProizvodViewModel> obsProizvodi = new ObservableCollection<DostupanProizvodViewModel>();
            if (tip=="Hrana")
            {
                List<NudiProizvodDTO> proizvodiAutomata;
                IProizvodDAO proDao = new ProizvodiImplDAO();
                proizvodiAutomata = proDao.GetAllHranaOfAutomat(id);
                proizvodiAutomata.ForEach(s => obsProizvodi.Add(new DostupanProizvodViewModel(s.ID, s.Naziv)));

            }
            else
            {
                List<SastojciDTO> sastojciAutomata;
                ISastojciDAO sasDao = new SastojciImplDAO();
                sastojciAutomata = sasDao.GetAllSastojciForAutomat(id);
                sastojciAutomata.ForEach(s => obsProizvodi.Add(new DostupanProizvodViewModel(s.ID, s.Naziv)));
            }
            DostupniProizvodi = obsProizvodi;
            AddCommand = new RelayCommand(addProizvod);
            RemoveCommand = new RelayCommand(removeProizvod);
        }

        public void addProizvod()
        {
            if(currentAutomat.Tip=="Hrana")
            {
                if (ToBeAdded != null && !IzabraniProizvodi.Any(s => s.ID == ToBeAdded.ID) && int.TryParse(Kolicina, out _))
                {
                    IzabraniProizvodi.Add(new FillWithProizvodViewModel(ToBeAdded.ID, ToBeAdded.Naziv, Kolicina));
                }
            }
            else
            {
                if (ToBeAdded != null && !IzabraniProizvodi.Any(s => s.ID == ToBeAdded.ID) && double.TryParse(Kolicina, out _))
                {
                    IzabraniProizvodi.Add(new FillWithProizvodViewModel(ToBeAdded.ID, ToBeAdded.Naziv, Kolicina));
                }
            }
            
        }

        public void removeProizvod()
        {
            if(ToBeRemoved!=null)
            {
                IzabraniProizvodi.Remove(ToBeRemoved);
            }
        }

        public void confirmFill()
        {
            if(currentAutomat.Tip=="Hrana")
            {

            }
            else
            {

            }
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
