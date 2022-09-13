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

namespace AutomatInformationSystem
{
    public class ProizvodiPageModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ProizvodItemCardViewModel> Items { get { return items; } set { items = value; NotifyPropertyChanged("Items"); } }
        private ObservableCollection<ProizvodItemCardViewModel> items;
        public ICommand AddProizvodCommand { get; set; }

        public ProizvodiPageModelView()
        {
            this.AddProizvodCommand = new RelayCommand(openAddingWindow);
            getProizvodi();
        }

        private void openAddingWindow()
        {
            AddProizvodWindow window = new AddProizvodWindow();
            AddingProizvodViewModel vm = (AddingProizvodViewModel)window.DataContext;
            vm.ReloadRequest += (sender, a) => {
                getProizvodi();
            };
            window.Show();
        }

        private void getProizvodi()
        {
            IProizvodDAO dao = new ProizvodiImplDAO();
            List<ProizvodDTO> listaProizvoda = null;
            ObservableCollection<ProizvodItemCardViewModel> obsListaProizvoda = new ObservableCollection<ProizvodItemCardViewModel>();
            try
            {
                listaProizvoda = dao.GetAllProizvod();
                listaProizvoda.ForEach(s =>
                {
                    ProizvodItemCardViewModel temp = new ProizvodItemCardViewModel(s.ID, s.Naziv, s.Tip);
                    temp.ReloadRequest += (sender, a) => getProizvodi();
                    obsListaProizvoda.Add(temp);
                });
            }
            catch (MySqlException)
            {
                MessageBox.Show("Greska prilikom ucitavanja proizvoda!");
            }

            Items = obsListaProizvoda;
        }

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
