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

namespace Brain_Ring.Controls.Components
{
    /// <summary>
    /// Interaction logic for RoundSetControl.xaml
    /// </summary>
    public partial class RoundSetControl : UserControl
    {
        private CreateGameControl _createGameControl;
        private GameViewModel _dataContext;
        public RoundSetControl()
        {
            InitializeComponent();
            QuestionUpDownControl.ScrollBar.Maximum = 50;
            QuestionUpDownControl.ScrollBar.Value = 20;
            //----------------Пример привязки-------------------------------
//            CommandBinding bind = new CommandBinding(ApplicationCommands.New);
//            bind.Executed +=
//                delegate(object sender, ExecutedRoutedEventArgs args)
//                {
//                    _dataContext.Round = (int) QuestionUpDownControl.ScrollBar.Value;
//                };
//            CommandBindings.Add(bind);
        }

        private void RoundSetControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void SaveRoundSettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            _createGameControl.RoundOneButton.Background = Brushes.SteelBlue;
        }

        private void cmbRoundType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var controls = new List<Control>
            {
                new CommonTypeSetControl(),
                new SprintTypeSetControl(),
                new BrainstormTypeSetControl(),
                new CathegoriesTypeSetControl(),
                new CaptainBattleTypeSetControl()

            };
            var i = cmbRoundType.SelectedIndex;
            var control = controls[i];
            TypeSetControlViewBox.Children.Clear();
            TypeSetControlViewBox.Children.Add(control);
        }

        private void cmbTimerSet_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cmbQuestionNumber_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
