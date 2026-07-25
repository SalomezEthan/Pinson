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

        public int Value { get; }

        public int ToInt()
        {
            return Value;
        }

        public Count Increment()
        {
            return new Count(Value + 1);
        }

        public Count Decrement()
        {
            int newValue = Value - 1;

            if (newValue < 0)
            {
                throw new NegativeCountException();
            }

            return new Count(newValue);
        }

        public override bool Equals(object? obj)
        {
            return obj is Count other && this.Value == other.Value;
        }
    }
}
