

using Demo.DAL.Context;

namespace Demo.DAL.Repositories;

public class DepartmentRepositories(CompanyDbContext dbContext): IDepartmentRepositories
{
    private CompanyDbContext _DbContext=dbContext;
    private DbSet<Department> _Departments =dbContext.Departments;
  

    public int Add(Department department)
    {
       _Departments.Add(department);
        return _DbContext.SaveChanges();
    }

    public int Delete(Department department)
    {
        _Departments.Remove(department);
        return _DbContext.SaveChanges();
    }

    public IEnumerable<Department> GetAll(bool track)
    {
       return track? _Departments.ToList():_Departments.AsNoTracking().ToList();
    }

    public Department? GetById(int id)
    {
        return _Departments.Find(id);
    }

    public int Update(Department department)
    {
        _Departments.Update(department);
        return _DbContext.SaveChanges();
    }
}
