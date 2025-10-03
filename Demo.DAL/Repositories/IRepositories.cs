

namespace Demo.DAL.Repositories;

public interface IRepositories<T> where T : BaseEntities
{
   Task<IEnumerable<T>> GetAllAsync(bool track = false);
    Task<T?> GetByIdAsync(int id);
    void Add(T T);

    void Update(T T);
    void Delete(T T);
}
