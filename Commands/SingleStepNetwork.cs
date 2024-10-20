using MGNE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGNE.Commands
{
    public class SingleStepNetwork : CommandBase
    {
        private readonly NetworkDynamicsViewModel _networkDynamicsViewModel;

        public SingleStepNetwork(NetworkDynamicsViewModel networkDynamicsViewModel)
        {
            _networkDynamicsViewModel = networkDynamicsViewModel;
        }

        public override void Execute(object parameter)
        {
            _networkDynamicsViewModel.StartDynamics(true);
        }
    }
}
