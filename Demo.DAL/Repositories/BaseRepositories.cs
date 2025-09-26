

using Demo.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Repositories;

public class BaseRepositories<T>(CompanyDbContext dbContext):IRepositories<T> where T : BaseEntities
{
    protected CompanyDbContext _DbContext = dbContext;
    protected DbSet<T> _T = dbContext.Set<T>();


    public int Add(T T)
    {
        _T.Add(T);
        return _DbContext.SaveChanges();
    }

    public int Delete(T T)
    {
        _T.Remove(T);
        return _DbContext.SaveChanges();
    }

    public virtual IEnumerable<T> GetAll(bool track)
    {
        return track ? _T.ToList() : _T.AsNoTracking().ToList();
    }

    public T? GetById(int id)
    {
        return _T.Find(id);
    }

    public int Update(T T)
    {
        _T.Update(T);
        return _DbContext.SaveChanges();
    }
}
