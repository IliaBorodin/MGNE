using MGNE.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace MGNE.Views
{
    public partial class GraphSettingsModalView : Window
    {
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public GraphSettingsModalView(ObservableCollection<Neuron> _neurons)
        {
            InitializeComponent();
            Neurons = _neurons;
            IsImpulseFirstI = true;
            IsImpulseSecondI = true;
            FirstNeuron = Neurons[0];
            SecondNeuron = Neurons[0];
            DataContext = this;
            
        }
        public Neuron FirstNeuron { get; set; }
        public Neuron SecondNeuron { get; set;}

        public ObservableCollection<Neuron> Neurons { get; set; }
        
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("При построении графика 1 элемент - уменьшаемое, 2 элемент - вычитаемое");
        }

        public bool IsImpulseFirstI { get; set; }
        public bool IsImpulseFirstIPlus1 { get; set; }
        public bool IsImpulseSecondI { get; set; }
        public bool IsImpulseSecondIPlus1 { get; set; }

    }
}
