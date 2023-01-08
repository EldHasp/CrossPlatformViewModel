using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace UwpBaseClasses
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public CoreDispatcher Dispatcher { get; } = CoreApplication.MainView.CoreWindow.Dispatcher;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (Dispatcher.HasThreadAccess)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? string.Empty));
            }
            else
            {
                Dispatcher
                    .RunAsync
                    (
                        CoreDispatcherPriority.Normal,
                        () => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? string.Empty))
                    )
                    .AsTask().Wait();
            }
        }

        protected bool Set<T>(ref T propertyField, T newValue, [CallerMemberName] string propertyName = null)
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
