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
using LogicBrainRing.Server;

namespace Brain_Ring.Controls
{
    /// <summary>
    /// Interaction logic for ConnectControl.xaml
    /// </summary>
    public partial class ConnectWindow : Window
    {
        private readonly MainWindow _mainWindow;
        private readonly BrainRingContext _context;
        private GameViewModel _dataContext;
        public ConnectWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }
        public ConnectWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();

        }

        private void GameBeginButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainViewBox.Children.Clear();
            _mainWindow.MainViewBox.Children.Add(new GameWindow());
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainViewBox.Children.Clear();
            _mainWindow.MainViewBox.Children.Add(new CreateGameControl());
        }
    }
}
