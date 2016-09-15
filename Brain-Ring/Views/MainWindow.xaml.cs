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
using Brain_Ring.Views;
using DbBrainRing;
using LogicBrainRing;

namespace Brain_Ring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindow _mainMainWindow;
        private readonly BrainRingContext _context;
        public MainWindow()
        {
            InitializeComponent();
            //this.ResizeMode = ResizeMode.NoResize;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var control = new MainControl(/*_context, */this);
            var size = ((Control) this).RenderSize;
            control.RenderSize = size;//Унаследовать размеры от родительского окна
            MainViewBox.Children.Clear();
            MainViewBox.Children.Add(control);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var size = ((Window)this).RenderSize;
            MainViewBox.RenderSize = size;
        }
    }
}
