using AutomatInformationSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class ZaposleniItemCardViewModel
    {

        private string _brojTelefona;

        public int ID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Tip { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public string BrojTelefona { get { return _brojTelefona; }  set { if (string.IsNullOrEmpty(value)) { _brojTelefona = "empty"; }
                else { _brojTelefona = value; }
            } }


        public ZaposleniItemCardViewModel()
        {
            DeleteCommand = new RelayCommand(deleteZaposleni);
            UpdateCommand = new RelayCommand(updateZaposleni);
        }

        public ZaposleniItemCardViewModel(int id, string ime, string prezime, string brojTelefona, DateTime datumRodjenja, string tip)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            BrojTelefona = brojTelefona;
            DatumRodjenja = datumRodjenja;
            Tip = tip;
            DeleteCommand = new RelayCommand(deleteZaposleni);
            UpdateCommand = new RelayCommand(updateZaposleni);
        }

        public ZaposleniItemCardViewModel(string ime, string prezime, string brojTelefona, DateTime datumRodjenja, string tip)
        {
            Ime = ime;
            Prezime = prezime;
            BrojTelefona = brojTelefona;
            DatumRodjenja = datumRodjenja;
            Tip = tip;
            DeleteCommand = new RelayCommand(deleteZaposleni);
            UpdateCommand = new RelayCommand(updateZaposleni);
        }


        private void deleteZaposleni()
        {
            IZaposleniDAO dao = new ZaposleniImplDAO();
            dao.deleteZaposleni(ID, Tip);
        }

        private void updateZaposleni()
        {
            UpdateZaposleniWindow win = new UpdateZaposleniWindow();
            UpdateZaposleniViewModel vm = new UpdateZaposleniViewModel(ID, Ime, Prezime, BrojTelefona, DatumRodjenja.ToString("dd/MM/yyyy"), Tip);
            win.DataContext = vm;
            vm.ClosingRequest += (sender, a) => win.Close();
            win.Show();
        }
    }
}
