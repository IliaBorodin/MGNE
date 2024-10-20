using MGNE.ViewModels;

namespace MGNE.Commands
{
    public class CreateWeightCommand : CommandBase
    {

        private readonly NetworkConfigurationViewModel _networkConfigViewModel;

        public CreateWeightCommand(NetworkConfigurationViewModel networkConfigViewModel)
        {
            _networkConfigViewModel = networkConfigViewModel;
        }

        public override void Execute(object parameter)
        {
            _networkConfigViewModel.Flag++;
            if (_networkConfigViewModel.Flag == 2)
            {
                WeightViewModel weight = new WeightViewModel(_networkConfigViewModel.SelectedNeuronSecond, _networkConfigViewModel.SelectedNeuron);
                if (!_networkConfigViewModel.Weights.Contains(weight) && _networkConfigViewModel.SelectedNeuron != _networkConfigViewModel.SelectedNeuronSecond)
                {
                    _networkConfigViewModel.Weights.Add(weight);
                    //Инициализация веса
                    weight.ValueFirstToSecond = _networkConfigViewModel.SetInitialWeight();
                    weight.ValueSecondToFirst = _networkConfigViewModel.SetInitialWeight();

                    if (_networkConfigViewModel.WeightMatrix != null)
                    {
                        _networkConfigViewModel.WeightMatrix.addSubscriptionWeight(weight);
                    }
                    // MessageBox.Show($"{_networkConfigViewModel.Weights.Count}");                   
                }
                _networkConfigViewModel.SelectedNeuronSecond.ReadyForCreateWeight = false;
                _networkConfigViewModel.SelectedNeuron.ReadyForCreateWeight = false;
                _networkConfigViewModel.Flag = 0;
            }
            if (_networkConfigViewModel.Flag == 1)
            {
                _networkConfigViewModel.SelectedNeuron.ReadyForCreateWeight = true;
                _networkConfigViewModel.SelectedNeuronSecond = _networkConfigViewModel.SelectedNeuron;
            }
        }
       
    }
}
