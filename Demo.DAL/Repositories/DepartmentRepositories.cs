

using Demo.DAL.Context;

namespace Demo.DAL.Repositories;

public class DepartmentRepositories(CompanyDbContext dbContext): BaseRepositories<Department>(dbContext),IDepartmentRepositories
{
   
}
