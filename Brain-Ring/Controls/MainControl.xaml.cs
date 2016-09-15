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
using Brain_Ring.Views;
using DbBrainRing;

namespace Brain_Ring.Controls
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        private readonly MainWindow _mainWindow;
        //private readonly BrainRingContext _context;
        public MainControl()
        {
            InitializeComponent();
        }

        public MainControl(MainWindow mainWindow)
        {
            //_context = context;
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void NewGameButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainViewBox.Children.Clear();
            _mainWindow.MainViewBox.Children.Add(new CreateGameControl(/*_mainWindow*/));
        }

        private void StatisticsButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainViewBox.Children.Clear();
            _mainWindow.MainViewBox.Children.Add(new StatisticsControl(_mainWindow));
        }

        private void RuleButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainViewBox.Children.Clear();
            _mainWindow.MainViewBox.Children.Add(new RulesControl());
        }

        private void EditorButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainViewBox.Children.Clear();
            _mainWindow.MainViewBox.Children.Add(new EditorControl(/*_mainWindow*/));
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainViewBox.Children.Clear();
            _mainWindow.Close();
        }
    }
}
