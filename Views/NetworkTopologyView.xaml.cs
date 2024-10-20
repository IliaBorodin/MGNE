using MGNE.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MGNE.Views
{
    /// <summary>
    /// Логика взаимодействия для NetworkTopologyView.xaml
    /// </summary>
    public partial class NetworkTopologyView : UserControl
    {
        private NetworkConfigurationViewModel mvvm;

        public static readonly DependencyProperty CurrentScaleProperty =
           DependencyProperty.Register("CurrentScale", typeof(double), typeof(NetworkTopologyView),
               new PropertyMetadata(null));
        public double CurrentScale
        {
            get { return (double)GetValue(CurrentScaleProperty); }
            set { SetValue(CurrentScaleProperty, value); }
        }

        public static readonly DependencyProperty ZoomInCommandProperty =
            DependencyProperty.Register("ZoomInCommand", typeof(ICommand), typeof(NetworkTopologyView),
                new PropertyMetadata(null));

        public ICommand ZoomInCommand
        {
            get { return (ICommand)GetValue(ZoomInCommandProperty); }
            set { SetValue(ZoomInCommandProperty, value); }
        }

        public static readonly DependencyProperty ZoomOutCommandProperty =
           DependencyProperty.Register("ZoomOutCommand", typeof(ICommand), typeof(NetworkTopologyView),
               new PropertyMetadata(null));

        public ICommand ZoomOutCommand
        {
            get { return (ICommand)GetValue(ZoomOutCommandProperty); }
            set { SetValue(ZoomOutCommandProperty, value); }
        }

        public static readonly DependencyProperty ScaleTransformProperty =
            DependencyProperty.Register("ScaleTransform", typeof(ScaleTransform), typeof(NetworkTopologyView),
                new PropertyMetadata(null));
        public ScaleTransform ScaleTransform
        {
            get { return (ScaleTransform)GetValue(ScaleTransformProperty);}
            set { SetValue(ScaleTransformProperty, value); }
        }
       



        void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;

            NeuronViewModel neuronViewModel = (sender as FrameworkElement).DataContext as NeuronViewModel;
            mvvm.IsTab1Visible = true;
            mvvm.IsTab2Visible = false;
            mvvm.ChangeColor();
            if (mvvm.SelectedNeuron != null)
                mvvm.SelectedNeuron.MembranePotential = -5;
            mvvm.SelectedNeuron = neuronViewModel;
            (sender as Ellipse).CaptureMouse();
            mvvm.UpdateWeightsLine();
        }

        void line_MouseDowm(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            WeightViewModel weightViewModel = (sender as FrameworkElement).DataContext as WeightViewModel;
            mvvm.IsTab1Visible = false;
            mvvm.IsTab2Visible = true;
            mvvm.ChangeColor();
            mvvm.SelectedWeight = weightViewModel;
        }

        void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed || !(sender as Ellipse).IsMouseCaptured)
                return;

            var pos = e.GetPosition(myCanvas);
            double left = Math.Max(0, Math.Min(myCanvas.ActualWidth - ((Ellipse)sender).ActualWidth, pos.X - ((Ellipse)sender).ActualWidth / 2));
            double top = Math.Max(0, Math.Min(myCanvas.ActualHeight - ((Ellipse)sender).ActualHeight, pos.Y - ((Ellipse)sender).ActualHeight / 2));

            Canvas.SetLeft((Ellipse)sender, left);
            Canvas.SetTop((Ellipse)sender, top);

            mvvm.SelectedNeuron.PointObj = new Point(left, top);
            mvvm.UpdateWeightsLine();
        }

        void ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!(sender as Ellipse).IsMouseCaptured)
                return;
            (sender as Ellipse).ReleaseMouseCapture();
        }

        private void NetworkTopologyView_Loaded(object sender, RoutedEventArgs e)
        {
            mvvm = DataContext as NetworkConfigurationViewModel;
            CurrentScale = mvvm.CurrentCanvasScale;
            Loaded -= NetworkTopologyView_Loaded;
        }

        public NetworkTopologyView()
        {
            InitializeComponent();
            Loaded += NetworkTopologyView_Loaded;
        }

      

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            ApplyScaleTransform(0.1);
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            ApplyScaleTransform(-0.1);
        }

        private void ApplyScaleTransform(double scale)
        {
            CurrentScale += scale;
            ScaleTransform scaleTransform = myCanvas.LayoutTransform as ScaleTransform;
            if (scaleTransform == null)
            {
                scaleTransform = new ScaleTransform();
                myCanvas.LayoutTransform = scaleTransform;
            }
            scaleTransform.ScaleX = CurrentScale;
            scaleTransform.ScaleY = CurrentScale;
        }
       
    }
}
