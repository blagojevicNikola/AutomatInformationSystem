using AutomatInformationSystem.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class ProizvodItemCardViewModel
    {
        public int ID { get; set; }

        public string Naziv { get; set; }

        public string Tip { get; set; }

        public EventHandler ReloadRequest;

        public ICommand DeleteCommand { get; set; }

        public ICommand UpdateCommand { get; set; }

        public ProizvodItemCardViewModel()
        {
            DeleteCommand = new RelayCommand(deleteProizvod);
        }

        public ProizvodItemCardViewModel(int id, string naziv, string tip)
        {
            ID = id;
            Naziv = naziv;
            Tip = tip;
            DeleteCommand = new RelayCommand(deleteProizvod);
            UpdateCommand = new RelayCommand(updateProizvod);
        }

        public ProizvodItemCardViewModel(string naziv, string tip)
        {
            Naziv = naziv;
            Tip = tip;
            DeleteCommand = new RelayCommand(deleteProizvod);
            UpdateCommand = new RelayCommand(updateProizvod);
        }

        private void deleteProizvod()
        {
            IProizvodDAO dao = new ProizvodiImplDAO();
            try
            {
                dao.deleteProizvod(ID, Tip);
            }
            catch(MySqlException)
            {
                MessageBox.Show("Greska prilikom brisanja proizvoda!");
            }
            ReloadRequest(this, EventArgs.Empty);
        }

        private void updateProizvod()
        {
            UpdateProizvodWindow win = new UpdateProizvodWindow();
            UpdateProizvodViewModel vm = new UpdateProizvodViewModel(ID, Naziv, Tip);
            win.DataContext = vm;
            vm.ClosingRequest += (sender, a) => win.Close();
            win.Show();
        }

    }
}
