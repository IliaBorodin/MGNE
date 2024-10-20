using MGNE.Services;
using MGNE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MGNE.Commands
{
    public class NavigateCommand<TViewModel> : ICommand
    where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> _navigationService;
        private NetworkConfigurationViewModel _vm;

        public NavigateCommand(NavigationService<TViewModel> navigationService, NetworkConfigurationViewModel vm)
        {
            _navigationService = navigationService;
            _vm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _vm.Neurons.Count > 0;
        }

        public void Execute(object parameter)
        {
            _navigationService.Navigate(parameter);
        }
    }
}
