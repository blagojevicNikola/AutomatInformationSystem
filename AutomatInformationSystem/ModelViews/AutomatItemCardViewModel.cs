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

        public AutomatItemCardViewModel()
        {
            DeleteCommand = new RelayCommand(deleteAutomat);
        }

        public AutomatItemCardViewModel(int id, long sifra, string lokacija, string tip, string potrosnja )
        {
            ID = id;
            Sifra = sifra;
            Lokacija = lokacija;
            Tip = tip;
            Potrosnja = potrosnja;
            DeleteCommand = new RelayCommand(deleteAutomat);
        }

        private void deleteAutomat()
        {
            IAutomatDAO dao = new AutomatiImplDAO();
            dao.deleteAutomat(ID, Tip);
        }
    }
}
