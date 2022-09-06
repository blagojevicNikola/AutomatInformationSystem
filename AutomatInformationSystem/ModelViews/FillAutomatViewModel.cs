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
        public string UkupanPrihod { get; set; }
        public ObservableCollection<DostupanProizvodViewModel> DostupniProizvodi { get; set; }
        public ObservableCollection<FillWithProizvodViewModel> IzabraniProizvodi { get; set; }
        public ObservableCollection<PrihodViewModel> PrihodiAutomata { get; set; }
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
            currentRadnik = tempRadnik;
            currentAutomat = autoDao.GetAutomatById(id, tip);
            UkupanPrihod = currentAutomat.UkupanPrihod.ToString();
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
            IPrihodDAO prihDao = new PrihodImplDAO();
            List<PunjenjeDTO> listaPrihoda = prihDao.GetAllPrihodByAutomatId(currentAutomat.ID);
            ObservableCollection<PrihodViewModel> obsPrihod = new ObservableCollection<PrihodViewModel>();
            listaPrihoda.ForEach(s => obsPrihod.Add(new PrihodViewModel(s.PunjenjeID, currentAutomat.ID, currentRadnik.Sifra, s.DatumPunjenja.ToString("dd/MM/yyyy"), s.Prihod.ToString(), currentAutomat.Tip)));
            DostupniProizvodi = obsProizvodi;
            PrihodiAutomata = obsPrihod;

            AddCommand = new RelayCommand(addProizvod);
            RemoveCommand = new RelayCommand(removeProizvod);
            ConfirmCommand = new RelayCommand(confirmFill);
            CloseCommand = new RelayCommand(closeWindow);
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
            if(double.TryParse(Prihod, out _))
            {
                double prihodAutomata = double.Parse(Prihod);
                if (prihodAutomata < 0)
                    return;
                IPrihodDAO prihDao = new PrihodImplDAO();
                PunjenjeDTO newPrihod = new PunjenjeDTO(currentAutomat.ID, currentRadnik.Sifra, DateTime.Now, prihodAutomata);
                long idPunjenja = prihDao.addPrihod(newPrihod);
                PunjenjeDTO recievedPunjenje = prihDao.GetPunjenjeById(idPunjenja);
                Console.WriteLine(recievedPunjenje.PunjenjeID);
                PrihodiAutomata.Add(new PrihodViewModel(recievedPunjenje.PunjenjeID, recievedPunjenje.AutomatID, recievedPunjenje.RadnikID, recievedPunjenje.DatumPunjenja.ToString("dd/MM/yyyy"), recievedPunjenje.Prihod.ToString(),currentAutomat.Tip));
                if(currentAutomat.Tip=="Hrana")
                {
                    foreach (FillWithProizvodViewModel f in IzabraniProizvodi)
                    {
                        prihDao.addHranaToPunjenje(idPunjenja, f.ID, int.Parse(f.Kolicina));
                    }
                }
                else
                {
                    foreach (FillWithProizvodViewModel f in IzabraniProizvodi)
                    {
                        prihDao.addSastojciToPunjenje(idPunjenja, f.ID, double.Parse(f.Kolicina));
                    }
                }
                
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
