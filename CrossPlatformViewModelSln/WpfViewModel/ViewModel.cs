using StandardModel;
using System;
using WpfBaseClasses;

namespace WpfViewModel
{
    public class ViewModel : ViewModelBase
    {
        public readonly AsyncModel model = new AsyncModel();
        private int _number;

        public int Number { get => _number; set => Set(ref _number, value); }

        public RelayCommand SomeCommand { get; }
        public ViewModel()
        {
            model.NumberChanged += OnValuesChanged;
            SomeCommand = new RelayCommand(() => { }, () => (Number & 1) == 0);
        }

        private void OnValuesChanged(object? sender, NumberChangedArgs e)
        {
            Number = e.NewNumber;
            SomeCommand.RaiseCanExecuteChanged();
        }
    }
}
