using MGNE.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MGNE.Views
{
    /// <summary>
    /// Логика взаимодействия для NetworkVisualView.xaml
    /// </summary>
    public partial class NetworkVisualView : UserControl
    {

        

        private NetworkDynamicsViewModel mvvm;
        public NetworkVisualView()
        {
            InitializeComponent();
            Loaded += NetworkVisualView_Loaded;
        }

        void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;

            NeuronViewModel neuronViewModel = (sender as FrameworkElement).DataContext as NeuronViewModel;
            // mvvm.IsTab1Visible = true;
            // mvvm.IsTab2Visible = false;
            // mvvm.ChangeColor();
            //change SelectedPhone
            //mvvm.SelectedNeuron = neuronViewModel;

            //move mouse
            // (sender as Ellipse).CaptureMouse();
            // offsetInEllipse = e.GetPosition((sender as Ellipse));
            // mvvm.UpdateWeightsLine();
            mvvm.getSelectedNeuron(neuronViewModel);
            mvvm.IsSelectedNeuronVisible = true;

        }

        void line_MouseDowm(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            WeightViewModel weightViewModel = (sender as FrameworkElement).DataContext as WeightViewModel;
            // mvvm.IsTab1Visible = false;
            // mvvm.IsTab2Visible = true;
            // mvvm.ChangeColor();
            // mvvm.SelectedWeight = weightViewModel;

        }

        private void NetworkVisualView_Loaded(object sender, RoutedEventArgs e)
        {
            // Получаем доступ к DataContext после загрузки элемента
            mvvm = DataContext as NetworkDynamicsViewModel;
           

            // Отключаем обработчик события Loaded после его выполнения
            Loaded -= NetworkVisualView_Loaded;
        }

        
        public static readonly DependencyProperty ScaleTransformProperty =
            DependencyProperty.Register("ScaleTransform", typeof(ScaleTransform), typeof(NetworkVisualView),
                new PropertyMetadata(null));
        public ScaleTransform ScaleTransform
        {
            get { return (ScaleTransform)GetValue(ScaleTransformProperty); }
            set { SetValue(ScaleTransformProperty, value); }
        }

    }
}
