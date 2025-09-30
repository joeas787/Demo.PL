

namespace Demo.DAL.Repositories;

public interface IRepositories<T> where T : BaseEntities
{
    IEnumerable<T> GetAll(bool track = false);
    T? GetById(int id);
    void Add(T T);

    void Update(T T);
    void Delete(T T);
}
