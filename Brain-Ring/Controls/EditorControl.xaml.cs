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
using DbBrainRing;
using LogicBrainRing.Server;

namespace Brain_Ring.Controls
{
    /// <summary>
    /// Interaction logic for EditorControl.xaml
    /// </summary>
    public partial class EditorControl : UserControl
    {
        private readonly MainWindow _parentWindow;
        private readonly BrainRingContext _context;
        private GameViewModel _dataContext;
        public new GameViewModel DataContext
        {
            get { return _dataContext; }
            private set { _dataContext = value; }
        }
        public EditorControl()
        {
            InitializeComponent();
        }
        public EditorControl(BrainRingContext context, MainWindow parentWindow)
        {
            _parentWindow = parentWindow;
            _context = context;
            InitializeComponent();
        }
        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            _parentWindow.MainViewBox.Children.Clear();
            _parentWindow.MainViewBox.Children.Add(new MainControl());
        }
    }
}
