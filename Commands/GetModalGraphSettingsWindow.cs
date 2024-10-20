using MGNE.Models;
using MGNE.ViewModels;
using MGNE.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MGNE.Commands
{
    public class GetModalGraphSettingsWindow : CommandBase
    {
        private readonly NetworkDynamicsViewModel vm;

        public GetModalGraphSettingsWindow(NetworkDynamicsViewModel networkDynamicsViewModel)
        {
            vm = networkDynamicsViewModel;
        }
        public override void Execute(object parameter)
        {
            GraphSettingsModalView modalWindow = new GraphSettingsModalView(vm.Neurons);

            if (modalWindow.ShowDialog() == true)
            {
                vm.GraphNeuronFirst = modalWindow.FirstNeuron;
                vm.GraphNeuronSecond = modalWindow.SecondNeuron;
                int modeFirst = modalWindow.IsImpulseFirstI == true ? 0 : 1; // i --> 0, i+1 --> 1
                int modeSecond = modalWindow.IsImpulseSecondI == true ? 0 : 1; // i --> 0, i+1 --> 1
                int count = Math.Min(vm.GraphNeuronFirst.ImpulseGenerationList.Count, vm.GraphNeuronSecond.ImpulseGenerationList.Count);
                var data_points = new List<PointData>();
                for (int i = 0; i < count - 1; i++)
                {
                    var y = vm.GraphNeuronFirst.ImpulseGenerationList[i + modeFirst] - vm.GraphNeuronSecond.ImpulseGenerationList[i + modeSecond];
                    data_points.Add(new PointData { XValue = i, YValue = (double)y });


                }
                vm.ListOfPoints = new ObservableCollection<PointData>(data_points);
            }           
        }
    }
}
