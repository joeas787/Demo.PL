

using Demo.DAL.Context;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories;

public class EmployeeRepositories(CompanyDbContext dbContext) : BaseRepositories<Employee>(dbContext), IEmployeeRepositories
{
    public IEnumerable<Employee> GetAll(string name)
    {
       return _T.Where(x => x.Name == name).ToList();
    }

    public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<Employee, TResult>> Result,Expression<Func<Employee,bool>>? expression=null)
    {
        if(expression == null)
        return await _T.Select(Result).ToListAsync();

        return await _T.Where(expression).Select(Result).ToListAsync();
    }
    public override async Task<Employee?> GetByIdAsync(int id)
    {
        return await _T.Include(x => x.Department).FirstOrDefaultAsync(e => e.Id == id);
    }
}
