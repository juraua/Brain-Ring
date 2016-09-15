using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using DbBrainRing;
using DbBrainRing.Models;
using LogicBrainRing.Server;
using LogicBrainRing.Server.HelperClasses;

namespace Brain_Ring.Controls
{
    /// <summary>
    /// Interaction logic for StatisticsControl.xaml
    /// </summary>
    public partial class StatisticsControl : UserControl
    {
        private readonly MainWindow _mainWindow;
        //private BrainRingContext _context;
        private StatisticsViewModel _dataContext;
        

        //public new StatisticsViewModel DataContext
        //{
        //    get { return _dataContext; }
        //    private set { _dataContext = value; }
        //}

        public StatisticsControl()
        {
            InitializeComponent();
            DataContext = ViewModelHelper.GetStatisticsViewModel(1);
        }


        public StatisticsControl(MainWindow mainWindow)
        {
            //_context = context;
            _mainWindow = mainWindow;
            InitializeComponent();
            this.DataContext = ViewModelHelper.GetStatisticsViewModel(2);
            
            
            //DataContext.LoadData();

            /*this.DataContext = new StatisticsViewModel
            {
                Games = new ObservableCollection<Game>(new List<Game> 
                                                                 })
            };
            //this.$*/

            /*using (var context = new BrainRingContext())
            {
                var model = new StatisticsViewModel();
                var games = context.Games.Select(x => new Game
                {
                    Id = x.Id,
                    Date = x.Date,
                    Teams = x.Teams
                });
                model.Games = new ObservableCollection<Game>(games.ToList());
                this.DataContext = model;
            }*/
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainViewBox.Children.Clear();
            _mainWindow.MainViewBox.Children.Add(new MainControl(_mainWindow));
        }

        private void UIElement_OnGotFocus(object sender, RoutedEventArgs e)
        {

            DataContext = ViewModelHelper.GetStatisticsViewModel(2);
        }

        private void UIElement1_OnGotFocus(object sender, RoutedEventArgs e)
        {
            DataContext = ViewModelHelper.GetStatisticsViewModel(2);
        }
        /*private void AddAutoIncrementColumn()
        {
            var column = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                AutoIncrement = true,
                AutoIncrementSeed = 1,//Начало нумерации
                AutoIncrementStep = 1//Шаг авто-инкремента
            };

            // Add the column to a new DataTable.
            var table = new DataTable("table");
            table.Columns.Add(column);
        }*/
    }
}
