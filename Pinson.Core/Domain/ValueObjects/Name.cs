using Pinson.Core.Domain.Exceptions;

namespace Pinson.Core.Domain.ValueObjects
{
    public class Name
    {
        public Name(string value, int limit)
        {
            value = value.Trim();

            if (value.Length == 0)
            {
                throw new IsEmptyException();
            }

            if (value.Length > limit)
            {
                throw new TooLongException();
            }

            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Name other && this.Value == other.Value;
        }
    }
}
