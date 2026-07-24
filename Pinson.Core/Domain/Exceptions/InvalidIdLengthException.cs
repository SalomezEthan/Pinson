using Pinson.Core.Domain.Constants;

namespace Pinson.Core.Domain.Exceptions
{
    public class InvalidIdLengthException() : Exception($"L'id doit faire {Limits.ID_LENGTH} caractères.")
    {
    }
}
