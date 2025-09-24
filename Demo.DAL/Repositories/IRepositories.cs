

namespace Demo.DAL.Repositories;

public interface IRepositories<T> where T : BaseEntities
{
    IEnumerable<T> GetAll(bool track = false);
    T? GetById(int id);
    int Add(T T);

    int Update(T T);
    int Delete(T T);
}
