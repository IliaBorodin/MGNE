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

namespace MGNE.Views
{
    /// <summary>
    /// Логика взаимодействия для WeightConfigView.xaml
    /// </summary>
    public partial class WeightConfigView : UserControl
    {
        public WeightConfigView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty WeightRemoveCommandProperty =
           DependencyProperty.Register("WeightDeleteCommand", typeof(ICommand), typeof(WeightConfigView),
               new PropertyMetadata(null));

        public ICommand WeightDeleteCommand
        {
            get { return (ICommand)GetValue(WeightRemoveCommandProperty); }
            set { SetValue(WeightRemoveCommandProperty, value); }
        }
        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            // Действия при входе курсора в область UserControl (если необходимо)
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            // Перемещение фокуса с TextBox при выходе курсора из области UserControl
            deleteBtn.Focus();
            invisibleButton.Focus();
        }

    }
}
