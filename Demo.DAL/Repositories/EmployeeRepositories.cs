

using Demo.DAL.Context;
using System.Linq.Expressions;

namespace Demo.DAL.Repositories;

public class EmployeeRepositories(CompanyDbContext dbContext) : BaseRepositories<Employee>(dbContext), IEmployeeRepositories
{
    public IEnumerable<Employee> GetAll(string name)
    {
       return _T.Where(x => x.Name == name).ToList();
    }

    public IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> Result)
    {
        return  _T.Select(Result).ToList();
    }
}
