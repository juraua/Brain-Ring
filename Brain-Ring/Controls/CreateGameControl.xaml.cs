using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Brain_Ring.Controls.Components;
using Brain_Ring.Views;
using DbBrainRing;
using DbBrainRing.Models;
using LogicBrainRing.Server;
using LogicBrainRing.Server.Classes;
using LogicBrainRing.Server.HelperClasses;
using NLog;

namespace Brain_Ring.Controls
{
    /// <summary>
    /// Interaction logic for CreateGameControl.xaml
    /// </summary>
    public partial class CreateGameControl : UserControl
    {
        private readonly MainWindow _mainWindow;
        private GameViewModel _dataContext;
        //private readonly BrainRingContext _context;

       /* public new GameViewModel DataContext
        {
            get { return _dataContext; }
            private set { _dataContext = value; }
        }*/
        public CreateGameControl()
        {
            InitializeComponent();
            _dataContext = ViewModelHelper.GetGameViewModel();
            DataContext = _dataContext;
        }
        public CreateGameControl(/*BrainRingContext context,*/MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            //_context = context;
            InitializeComponent();
            _dataContext = ViewModelHelper.GetGameViewModel();
            DataContext = _dataContext;
        }
        
        private void cmbGameTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox) sender;
            //_dataContext.Rounds = new ObservableCollection<RoundGame>(new List<RoundGame>((int)cmbGameTheme.SelectedItem));
            //cmbGameTheme.SelectedItem
        }
       
        private void cmbTeamsNumber_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void cmbRoundsNumber_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var buttons = new List<Button>
            {
                RoundOneButton,
                RoundTwoButton,
                RoundThreeButton,
                RoundFourButton,
                RoundFiveButton
            };

            try
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[j].Visibility = Visibility.Hidden;
                }
                for (int i = 0; i <= cmbRoundsNumber.SelectedIndex+1; i++)
                {
                    buttons[i].Visibility = Visibility.Visible;
                }
            }
            catch (NullReferenceException exception)
            {
                CheckNullReferenceException(exception);
            }
        }


        private void RoundOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            RoundSettingsViewbox.Children.Clear();
            var round = new RoundSetControl();
            if (_dataContext.Rounds.Any()) round.DataContext = _dataContext.Rounds[0];
            RoundSettingsViewbox.Children.Add(round);
            RaundNameLable.Content = "Раунд 1";
        }
        private void RoundTwoButton_OnClick(object sender, RoutedEventArgs e)
        {
            RoundSettingsViewbox.Children.Clear();
            var round = new RoundSetControl();
            if (_dataContext.Rounds.Count() > 1) round.DataContext = _dataContext.Rounds[1];
            RoundSettingsViewbox.Children.Add(round);
            RaundNameLable.Content = "Раунд 2";
        }
        private void RoundThreeButton_OnClick(object sender, RoutedEventArgs e)
        {
            RoundSettingsViewbox.Children.Clear();
            var round = new RoundSetControl();
            if (_dataContext.Rounds.Count() > 2) round.DataContext = _dataContext.Rounds[2];
            RoundSettingsViewbox.Children.Add(round);
            RaundNameLable.Content = "Раунд 3";
        }
        private void RoundFourButton_OnClick(object sender, RoutedEventArgs e)
        {
            RoundSettingsViewbox.Children.Clear();
            var round = new RoundSetControl();
            if (_dataContext.Rounds.Count() > 3) round.DataContext = _dataContext.Rounds[3];
            RoundSettingsViewbox.Children.Add(round);
            RaundNameLable.Content = "Раунд 4";
        }
        private void RoundFiveButton_OnClick(object sender, RoutedEventArgs e)
        {
            RoundSettingsViewbox.Children.Clear();
            var round = new RoundSetControl();
            if (_dataContext.Rounds.Count() > 4) round.DataContext = _dataContext.Rounds[4];
            RoundSettingsViewbox.Children.Add(round);
            RaundNameLable.Content = "Раунд 5";
        }

        private void CreateGameButton_OnClick(object sender, RoutedEventArgs e)
        {
            var connectWindow = new ConnectWindow();
            connectWindow.ShowDialog();
        }
        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Возвращает в главное окно программы MainControl, которое пренадлежит MainWindow
            _mainWindow.MainViewBox.Children.Clear();
            _mainWindow.MainViewBox.Children.Add(new MainControl());
        }
        
    #region Logger massages
            private void CheckNullReferenceException(Exception exception)
            {
                MessageBox.Show("Не вказано кількість раундів");
                var logger = LogManager.GetCurrentClassLogger();
                logger.Log(LogLevel.Fatal, exception, string.Format("Exaption in main window: {0}", exception));
            }
    #endregion

    }
}
