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
using LogicBrainRing.Server;
using LogicBrainRing.Server.HelperClasses;

namespace Brain_Ring.Controls
{
    /// <summary>
    /// Interaction logic for RulesControl.xaml
    /// </summary>
    public partial class RulesControl : UserControl
    {
        private readonly MainWindow _mainWindow;
        private StatisticsViewModel _dataContext;
        public RulesControl()
        {
            InitializeComponent();
        }
        
        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainViewBox.Children.Clear();
            _mainWindow.MainViewBox.Children.Add(new MainControl(_mainWindow));
        }
    }
}
