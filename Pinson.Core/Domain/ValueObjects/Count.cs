using Pinson.Core.Domain.Exceptions;

namespace Pinson.Core.Domain.ValueObjects
{
    public class Count
    {
        private readonly int _value;

        public Count(int value)
        {
            if (value < 0)
            {
                throw new NegativeCountException();
            }

            _value = value;
        }

        public int ToInt()
        {
            return _value;
        }

        public Count Increment()
        {
            return new Count(_value + 1);
        }

        public Count Decrement()
        {
            int newValue = _value - 1;

            if (newValue < 0)
            {
                throw new NegativeCountException();
            }

            return new Count(newValue);
        }

        public override bool Equals(object? obj)
        {
            return obj is Count other && this._value == other._value;
        }
    }
}
