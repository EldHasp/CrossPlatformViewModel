# CrossPlatformViewModel

Для темы [Платформо-Независимая ViewModel](https://www.cyberforum.ru/csharp-net/thread3068063.html)

Пример реализации одинаковой ViewModel для WPF и UWP.
Код VM одинаоквый, но из-за разных особенностей платформ WPF и UWP, приходится использовать разные базовые классы для INotifyPropertyChanged и ICommand.