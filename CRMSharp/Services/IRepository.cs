namespace CRMSharp.Services
{
    public interface ICRUD<T> where T : notnull
    {
        Task Create(T item);

        IAsyncEnumerable<T> GetAll();

        Task<T?> GetById(int id);

        Task<bool> TryRemove(int Id);
        Task Update(T item);

    }
}
