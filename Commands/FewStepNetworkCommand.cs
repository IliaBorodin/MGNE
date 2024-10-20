using MGNE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGNE.Commands
{
    public class FewStepNetworkCommand : CommandBase
    {

        private readonly NetworkDynamicsViewModel _networkDynamicsViewModel;

        public FewStepNetworkCommand(NetworkDynamicsViewModel networkDynamicsViewModel)
        {
            _networkDynamicsViewModel = networkDynamicsViewModel;
        }
        public override void Execute(object parameter)
        {
            _networkDynamicsViewModel.DoFewIterations();
        }
    }
}
