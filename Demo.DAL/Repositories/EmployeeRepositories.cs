

using Demo.DAL.Context;
using System.Linq.Expressions;

namespace Demo.DAL.Repositories;

public class EmployeeRepositories(CompanyDbContext dbContext) : BaseRepositories<Employee>(dbContext), IEmployeeRepositories
{
    public IEnumerable<Employee> GetAll(string name)
    {
       return _T.Where(x => x.Name == name).ToList();
    }

    public IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> Result,Expression<Func<Employee,bool>>? expression=null)
    {
        if(expression == null)
        return  _T.Select(Result).ToList();

        return _T.Where(expression).Select(Result).ToList();
    }
    public override Employee? GetById(int id)
    {
        return _T.Include(x => x.Department).FirstOrDefault(e => e.Id == id);
    }
}
