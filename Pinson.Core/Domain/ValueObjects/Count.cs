using Pinson.Core.Domain.Exceptions;

namespace Pinson.Core.Domain.ValueObjects
{
    public class Count
    {
        public Count(int value)
        {
            if (value < 0)
            {
                throw new NegativeCountException();
            }

            Value = value;
        }

        public int Value { get; private set; }

        public int ToInt()
        {
            return Value;
        }

        public void Increment()
        {
            ++Value;
        }

        public void Decrement()
        {
            int newValue = Value - 1;

            if (newValue < 0)
            {
                throw new NegativeCountException();
            }

            --Value;
        }
    }
}
