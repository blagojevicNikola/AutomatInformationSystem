using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutomatInformationSystem.Views
{
    /// <summary>
    /// Interaction logic for AddAutomatWindow.xaml
    /// </summary>
    public partial class AddAutomatWindow : Window
    {
        public AddAutomatWindow()
        {
            InitializeComponent();
            AddingAutomatViewModel vm = new AddingAutomatViewModel();
            this.DataContext = vm;
            vm.ClosingRequest += (sender, a) => this.Close();
        }
    }
}
