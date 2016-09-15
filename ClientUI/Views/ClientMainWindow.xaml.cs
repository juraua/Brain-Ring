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
using ClientUI.Controls;
using DbBrainRing;

namespace ClientUI
{
    /// <summary>
    /// Interaction logic for ClientMainWindow.xaml
    /// </summary>
    public partial class ClientMainWindow : Window
    {
        private readonly ClientMainWindow _mainClientMainWindow;
        private readonly BrainRingContext _context;
        public ClientMainWindow()
        {
            InitializeComponent();
        }

        private void ClientMainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var control = new ClientMainControl(this);
            var size = ((Control)this).RenderSize;
            control.RenderSize = size;
            ClientMainViewBox.Children.Clear();
            ClientMainViewBox.Children.Add(control);
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var size = ((Window)this).RenderSize;
            ClientMainViewBox.RenderSize = size;
        }
    }
}
