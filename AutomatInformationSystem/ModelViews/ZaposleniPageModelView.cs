using AutomatInformationSystem.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem.ModelViews
{
    public class ZaposleniPageModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddZaposleniCommand { get; set; }

        public ObservableCollection<ZaposleniItemCardViewModel> Items { get; set; }

        public ZaposleniPageModelView()
        {
            this.AddZaposleniCommand = new RelayCommand(addZaposleniCommand);
            ZaposleniImplDAO dao = new ZaposleniImplDAO();
            List<ZaposleniDTO> listaZaposlenih = dao.GetAllZaposleni();
            ObservableCollection<ZaposleniItemCardViewModel> observableZaposleni = new ObservableCollection<ZaposleniItemCardViewModel>();
            listaZaposlenih.ForEach(s => observableZaposleni.Add(new ZaposleniItemCardViewModel(s.Sifra, s.Ime, s.Prezime, s.Telefon, s.DatumRodjenja, s.Tip)));
            Items = observableZaposleni;
        }

        public void addZaposleniCommand()
        {
            AddZaposleniWindow win = new AddZaposleniWindow();
            win.Show();
        }


    }
}
