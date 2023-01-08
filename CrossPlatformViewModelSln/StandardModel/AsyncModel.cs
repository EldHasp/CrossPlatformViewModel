using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StandardModel
{
    public class AsyncModel
    {
        private int number;

        public AsyncModel()
        {
            Task.Run(RefreshAsync);
        }

        public event EventHandler<NumberChangedArgs> NumberChanged;

        private async void RefreshAsync()
        {
            while (true)
            {
                await Task.Delay(1_000);

                number++;
                NumberChangedArgs args = new NumberChangedArgs(number);


                if (args != null)
                {
                    try
                    {
                        NumberChanged?.Invoke(this, args);
                    }
                    catch (Exception exp)
                    {
                        Debug.WriteLine(exp.Message);
                    }
                }
            }
        }
    }
}
