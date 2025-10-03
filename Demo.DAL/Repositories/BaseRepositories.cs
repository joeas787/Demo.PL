

using Demo.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories;

public class BaseRepositories<T>(CompanyDbContext dbContext):IRepositories<T> where T : BaseEntities
{
    protected CompanyDbContext _DbContext = dbContext;
    protected DbSet<T> _T = dbContext.Set<T>();


    public void Add(T T)
    {
        _T.Add(T);
       
    }

    public void Delete(T T)
    {
        _T.Remove(T);
       
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(bool track)
    {
        return  track ? await _T.ToListAsync() :await _T.AsNoTracking().ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _T.FindAsync(id);
    }

    public void Update(T T)
    {
        _T.Update(T);
       
    }
}
