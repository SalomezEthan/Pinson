namespace Pinson.Core.Domain.Ports
{
    public interface IGenericRepository <T>
    {
        Task<T> GetByIdAsync(Guid id);
    }
}
