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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Brain_Ring.Controls;
using ClientUI;
using ClientUI.Views;
using DbBrainRing;

namespace ClientUI.Controls
{
    /// <summary>
    /// Interaction logic for ClientMainControl.xaml
    /// </summary>
    public partial class ClientMainControl : UserControl
    {
        private readonly ClientMainWindow _clientMainWindow;
        //private readonly BrainRingContext _context;
        public ClientMainControl()
        {
            InitializeComponent();
        }

        public ClientMainControl(ClientMainWindow clientMainWindow)
        {
            //_context = context;
            _clientMainWindow = clientMainWindow;
            InitializeComponent();
        }

        private void NewGameButton_OnClick(object sender, RoutedEventArgs e)
        {
            _clientMainWindow.ClientMainViewBox.Children.Clear();
            _clientMainWindow.ClientMainViewBox.Children.Add(new ClientConnectWindow(/*_clientMainWindow*/));
        }

        private void StatisticsButton_OnClick(object sender, RoutedEventArgs e)
        {
            _clientMainWindow.ClientMainViewBox.Children.Clear();
            _clientMainWindow.ClientMainViewBox.Children.Add(new StatisticsControl(/*_clientMainWindow*/));
        }

        private void RuleButton_OnClick(object sender, RoutedEventArgs e)
        {
            _clientMainWindow.ClientMainViewBox.Children.Clear();
            _clientMainWindow.ClientMainViewBox.Children.Add(new RulesControl());
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            _clientMainWindow.ClientMainViewBox.Children.Clear();
            _clientMainWindow.Close();
        }
    }
}
