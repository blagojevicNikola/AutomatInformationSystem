using AutomatInformationSystem.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutomatInformationSystem.ModelViews
{
    public class ZaposleniPageModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddZaposleniCommand { get; set; }

        public ObservableCollection<ZaposleniItemCardViewModel> Items { get { return items; } set { items = value; NotifyPropertyChanged("Items"); } }
        private ObservableCollection<ZaposleniItemCardViewModel> items;
        public ZaposleniPageModelView()
        {
            this.AddZaposleniCommand = new RelayCommand(addZaposleniCommand);
            getZaposleni();
        }

        private void addZaposleniCommand()
        {
            AddZaposleniWindow win = new AddZaposleniWindow();
            AddingZaposleniViewModel vm = (AddingZaposleniViewModel)win.DataContext;
            vm.ReloadRequest += (sender, a) => {
                getZaposleni();
            };
            win.Show();
        }

        private void getZaposleni()
        {
            ZaposleniImplDAO dao = new ZaposleniImplDAO();
            List<ZaposleniDTO> listaZaposlenih = null;
            ObservableCollection<ZaposleniItemCardViewModel> observableZaposleni = new ObservableCollection<ZaposleniItemCardViewModel>();
            try
            {
                listaZaposlenih = dao.GetAllZaposleni();
                listaZaposlenih.ForEach(s =>
                {
                    ZaposleniItemCardViewModel temp = new ZaposleniItemCardViewModel(s.Sifra, s.Ime, s.Prezime, s.Telefon, s.DatumRodjenja, s.Tip);
                    temp.ReloadRequest += (sender, a) => getZaposleni();
                    observableZaposleni.Add(temp);
                });
            }
            catch (MySqlException)
            {
                MessageBox.Show("Greska prilikom ucitavanja zaposlenih!");
            }

            Items = observableZaposleni;
        }

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

    }
}
