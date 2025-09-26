using Demo.DAL.Context;
using System.Linq.Expressions;

namespace Demo.DAL.Repositories;

public interface IEmployeeRepositories : IRepositories<Employee>
{
    IEnumerable<Employee> GetAll(string name);
    IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> Result);
}
