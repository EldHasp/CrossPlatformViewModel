using System;

namespace StandardModel
{
    public class NumberChangedArgs : EventArgs
    {
        public int NewNumber { get; }

        public NumberChangedArgs(int newNumber)
        {
            NewNumber = newNumber;
        }
    }
}
