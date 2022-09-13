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
    public class AutomatiPageModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddAutomatCommand { get; set; }

        public ObservableCollection<AutomatItemCardViewModel> Items { get { return items; } set { items = value; NotifyPropertyChanged("Items"); } }

        private ObservableCollection<AutomatItemCardViewModel> items;

        public AutomatiPageModelView()
        {
            AddAutomatCommand = new RelayCommand(addAutomatCommand);
            //IAutomatDAO dao = new AutomatiImplDAO();
            //List<AutomatFullInfoDTO> listaAutomata = null;
            //try
            //{
            //    listaAutomata = dao.GetAllAutomatiFullInfo(); 
            //}catch(MySqlException)
            //{
            //    _ = MessageBox.Show("Greska prilikom ucitavanja automata!");
            //}
            //ObservableCollection<AutomatItemCardViewModel> obsAutomati = new ObservableCollection<AutomatItemCardViewModel>();
            ////foreach(AutomatDTO a in listaAutomata)
            ////{

            ////}
            //if(listaAutomata!=null)
            //{
            //    listaAutomata.ForEach(s => obsAutomati.Add(new AutomatItemCardViewModel(s.ID, s.SerijskiBroj, s.ObjekatInfo, s.Tip, s.Potrosnja.ToString())));
            //    Items = obsAutomati;
            //}
            getAutomati();
            
        }

        private void addAutomatCommand()
        {
            AddAutomatWindow win = new AddAutomatWindow();
            AddingAutomatViewModel vm = (AddingAutomatViewModel)win.DataContext;
            vm.ReloadRequest += (sender, a) => {
                getAutomati();
            };
            win.Show();
        }

        private void getAutomati()
        {
            ObservableCollection<AutomatItemCardViewModel> obsAutomati = new ObservableCollection<AutomatItemCardViewModel>();
            IAutomatDAO dao = new AutomatiImplDAO();
            List<AutomatFullInfoDTO> listaAutomata = null;
            try
            {
                listaAutomata = dao.GetAllAutomatiFullInfo();
            }
            catch (MySqlException)
            {
                _ = MessageBox.Show("Greska prilikom ucitavanja automata!");
            }
            if (listaAutomata != null)
            {
                listaAutomata.ForEach(s => {
                    AutomatItemCardViewModel temp = new AutomatItemCardViewModel(s.ID, s.SerijskiBroj, s.ObjekatInfo, s.Tip, s.Potrosnja.ToString());
                    temp.ReloadRequest += (sender, a) => getAutomati();
                    obsAutomati.Add(temp);
                });
                Items = obsAutomati;
            }
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
