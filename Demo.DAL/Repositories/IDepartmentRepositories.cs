

namespace Demo.DAL.Repositories;

public interface IDepartmentRepositories
{
    IEnumerable<Department> GetAll(bool track=false);
    Department? GetById(int id);
     int Add (Department department);
    
    int Update (Department department);
    int Delete (Department department);
}
