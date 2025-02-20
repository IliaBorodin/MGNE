﻿using MGNE.Services;
using MGNE.Stores;
using MGNE.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MGNE
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly NetworkConfigurationViewModel _networkConfigurationViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _networkConfigurationViewModel = CreateNetworkConfigurationVM();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = _networkConfigurationViewModel;
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private NetworkConfigurationViewModel CreateNetworkConfigurationVM()
        {
            var navigationService = new NavigationService<NetworkDynamicsViewModel>(
                _navigationStore, CreateNetworkDynamicsVM);
            return new NetworkConfigurationViewModel(navigationService);
        }

        private NetworkDynamicsViewModel CreateNetworkDynamicsVM(object parameter)
        {
            // Убедитесь, что каждый раз создается новый экземпляр NetworkDynamicsViewModel
            return new NetworkDynamicsViewModel(_navigationStore, _networkConfigurationViewModel);
        }
    }
}
