using MGNE.Stores;
using MGNE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGNE.Commands
{
    public class NavigateBackCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ViewModelBase _viewModel;

        public NavigateBackCommand(NavigationStore navigationStore, ViewModelBase viewModel)
        {
            _navigationStore = navigationStore;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _viewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
