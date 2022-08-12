using AutomatInformationSystem.Views;
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
    public class ProizvodiPageModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ProizvodItemCardViewModel> Items { get; set; }

        public ICommand AddProizvodCommand { get; set; }

        public ProizvodiPageModelView()
        {
            this.AddProizvodCommand = new RelayCommand(openAddingWindow);
        }

        private void openAddingWindow()
        {
            AddProizvodWindow window = new AddProizvodWindow();
            window.Show();
        }
    }
}
