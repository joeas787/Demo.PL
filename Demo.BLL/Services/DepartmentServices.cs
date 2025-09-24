
using Demo.BLL.DataTransferObject;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;

namespace Demo.BLL.Services;

public class DepartmentServices(IDepartmentRepositories departmentRepositories) : IDepartmentServices
{
    public int Add(DepartmentRequest request)
    {
        var dep = request.ToEntity();
        return departmentRepositories.Add(dep);
    }

    public bool Delete(int id)
    {
        var dep = departmentRepositories.GetById(id);
        if (dep is null) 
            return false;
        var r=departmentRepositories.Delete(dep);
        return r > 0;
    }

    public IEnumerable<DepartmentResponse> GetAll()
    {
        return departmentRepositories.GetAll().Select(x=>x.ToResponse());
    }


    public DepartmentDetailsResponse? GetById(int id)
    {
       return departmentRepositories.GetById(id).ToDetails();
    }

    public int Update(DepartmentUpdateRequest request)
    {
        return departmentRepositories.Update(request.ToEntity());
    }
}
