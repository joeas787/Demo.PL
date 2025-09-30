
using Demo.BLL.DataTransferObject;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;

namespace Demo.BLL.Services;

public class DepartmentServices(IUnitOfWork unitofwork) : IDepartmentServices
{
    public int Add(DepartmentRequest request)
    {
        var dep = request.ToEntity();
         unitofwork.Department.Add(dep);
        return unitofwork.SaveChanges();
    }

    public bool Delete(int id)
    {
        var dep = unitofwork.Department.GetById(id);
        if (dep is null) 
            return false;
        unitofwork.Department.Delete(dep);
        return unitofwork.SaveChanges() > 0;
    }

    public IEnumerable<DepartmentResponse> GetAll()
    {
        return unitofwork.Department.GetAll().Select(x=>x.ToResponse());
    }


    public DepartmentDetailsResponse? GetById(int id)
    {
       return unitofwork.Department.GetById(id).ToDetails();
    }

    public int Update(DepartmentUpdateRequest request)
    {
         unitofwork.Department.Update(request.ToEntity());
        return unitofwork.SaveChanges();
    }
}
