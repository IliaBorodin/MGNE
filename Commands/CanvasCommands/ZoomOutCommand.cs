using MGNE.ViewModels;

namespace MGNE.Commands.CanvasCommands
{
    public class ZoomOutCommand : CommandBase
    {
        private readonly NetworkConfigurationViewModel _networkConfigViewModel;

        public ZoomOutCommand(NetworkConfigurationViewModel networkConfigViewModel)
        {
            _networkConfigViewModel = networkConfigViewModel;
        }
        public override void Execute(object parameter)
        {
            _networkConfigViewModel.CurrentCanvasScale -= 0.1;
            _networkConfigViewModel.ScaleTransform.ScaleX = _networkConfigViewModel.CurrentCanvasScale;
            _networkConfigViewModel.ScaleTransform.ScaleY = _networkConfigViewModel.CurrentCanvasScale;
        }
    }
}
