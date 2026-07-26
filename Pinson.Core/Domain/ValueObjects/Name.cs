using Pinson.Core.Domain.Exceptions;

namespace Pinson.Core.Domain.ValueObjects
{
    public class Name
    {
        private readonly string _value;

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

            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Name other && this._value == other._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
