using Pinson.Core.Domain.Constants;
using Pinson.Core.Domain.Exceptions;

namespace Pinson.Core.Domain.ValueObjects
{
    public class Id
    {
        public Id(string key)
        {
            key = key.Trim();

            if (key.Length == 0)
            {
                throw new IsEmptyException();
            }

            if (key.Length != Limits.ID_LENGTH)
            {
                throw new InvalidIdLengthException();
            }

            Value = key;
        }

        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }
    }
}
