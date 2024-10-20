using MGNE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MGNE.Commands.CanvasCommands
{
    public class ZoomInCommand : CommandBase
    {
        private readonly NetworkConfigurationViewModel _networkConfigViewModel;

        public ZoomInCommand(NetworkConfigurationViewModel networkConfigViewModel)
        {
            _networkConfigViewModel = networkConfigViewModel;
        }
        public override void Execute(object parameter)
        {
            _networkConfigViewModel.CurrentCanvasScale += 0.1;
            _networkConfigViewModel.ScaleTransform.ScaleX = _networkConfigViewModel.CurrentCanvasScale;
            _networkConfigViewModel.ScaleTransform.ScaleY = _networkConfigViewModel.CurrentCanvasScale;
        }
    }
}
