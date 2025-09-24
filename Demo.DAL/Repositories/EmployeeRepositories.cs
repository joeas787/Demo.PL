

using Demo.DAL.Context;

namespace Demo.DAL.Repositories;

public class EmployeeRepositories(CompanyDbContext dbContext) :BaseRepositories<Employee>(dbContext),IEmployeeRepositories
{
    
}
