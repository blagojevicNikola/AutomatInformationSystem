using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class AddingProizvodViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ClosingRequest;

        public AddingProizvodViewModel()
        {
            this.OkCommand = new RelayCommand(okExecute);
            SastojciList = new ObservableCollection<SastojciViewModel>();
        }

        public ICommand OkCommand { get; set; }

        public ICommand AddSastojciList { get; set; }

        private string naziv;
        private string tip;

        public ObservableCollection<SastojciViewModel> SastojciList { get; set; }

        public string Tip { get { return tip; } 
            set 
            {
                if(value=="Kafa")
                {
                    ISastojciDAO dao = new SastojciImplDAO();
                    List<SastojciDTO> listaSastojaka = dao.GetAllSastojci();
                    listaSastojaka.ForEach(s => SastojciList.Add(new SastojciViewModel(s.ID, s.Naziv)));
                    //SastojciList.Add(new SastojciViewModel(1, "mlijeko"));
                    //Console.WriteLine(value);
                }
                else
                {
                    SastojciList.Clear();
                }
                tip = value; 
                    //SastojciList = obs;
                NotifyPropertyChanged("Tip");
            } 
        }

        public string Naziv { get { return naziv; } set { naziv = value; NotifyPropertyChanged("Naziv"); } }

        private void okExecute()
        {
            IProizvodDAO dao = new ProizvodiImplDAO();
            List<SastojciDTO> tempList = new List<SastojciDTO>();
            if (Tip=="Kafa")
            {
                foreach (SastojciViewModel s in SastojciList)
                {
                    if(s.Izabrano)
                    {
                        tempList.Add(new SastojciDTO(s.ID, s.Naziv));
                    }
                }
            }
            dao.saveProizvod(Naziv, Tip, tempList);
            ClosingRequest(this, EventArgs.Empty);
        }

        private void addSastojciList()
        {
         
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
