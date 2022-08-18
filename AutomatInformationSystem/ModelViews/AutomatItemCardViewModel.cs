using AutomatInformationSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class AutomatItemCardViewModel
    {

        private string _potrosnja;
        private string _lokacija;
        public int ID { get; set; }

        public long Sifra { get; set; }

        public string Lokacija { get { return _lokacija; } set { if (value.Length <= 0) { _lokacija = "Empty"; } else { _lokacija = value; } } }

        public string Tip { get; set; }

        public string Potrosnja { get { return _potrosnja; } set { _potrosnja = value + "W"; } }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand ManageCommand { get; set; }
        public AutomatItemCardViewModel()
        {
            DeleteCommand = new RelayCommand(deleteAutomat);
            UpdateCommand = new RelayCommand(updateAutomat);
            ManageCommand = new RelayCommand(manageAutomat);
        }

        public AutomatItemCardViewModel(int id, long sifra, string lokacija, string tip, string potrosnja )
        {
            ID = id;
            Sifra = sifra;
            Lokacija = lokacija;
            Tip = tip;
            Potrosnja = potrosnja;
            DeleteCommand = new RelayCommand(deleteAutomat);
            UpdateCommand = new RelayCommand(updateAutomat);
            ManageCommand = new RelayCommand(manageAutomat);
        }

        private void deleteAutomat()
        {
            IAutomatDAO dao = new AutomatiImplDAO();
            dao.deleteAutomat(ID, Tip);
        }

        private void updateAutomat()
        {
            UpdateAutomatWindow win = new UpdateAutomatWindow();
            UpdateAutomatViewModel vm = new UpdateAutomatViewModel(ID, Tip);
            win.DataContext = vm;
            vm.ClosingRequest += (sender, a) => win.Close();
            win.Show();
        }

        private void manageAutomat()
        {
            ManageAutomatWindow win = new ManageAutomatWindow();
            ManageAutomatViewModel vm = new ManageAutomatViewModel(ID, Tip);
            win.DataContext = vm;
            vm.ClosingRequest += (sender, a) => win.Close();
            win.Show();
        }
    }
}
