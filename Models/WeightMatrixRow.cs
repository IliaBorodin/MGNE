using MGNE.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGNE.Models
{
    public class WeightMatrixRow : ViewModelBase
    {
        public string NeuronName { get; set; }
        public ObservableCollection<double> Weights { get; set; } = new ObservableCollection<double>();
    }
}
