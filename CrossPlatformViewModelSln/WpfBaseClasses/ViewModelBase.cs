using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfBaseClasses
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? string.Empty));
        }

        protected bool Set<T>(ref T propertyField, T newValue, [CallerMemberName] string? propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            bool notEquals = !Equals(propertyField, newValue);
            if (notEquals)
            {
                propertyField = newValue;
                RaisePropertyChanged(propertyName);
            }
            return notEquals;
        }
    }
}