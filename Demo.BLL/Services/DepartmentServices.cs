
using Demo.BLL.DataTransferObject;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;
using System.Threading.Tasks;

namespace Demo.BLL.Services;

public class DepartmentServices(IUnitOfWork unitofwork) : IDepartmentServices
{
    public async Task<int> AddAsync(DepartmentRequest request)
    {
        var dep = request.ToEntity();
         unitofwork.Department.Add(dep);
        return await unitofwork.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var dep =await unitofwork.Department.GetByIdAsync(id);
        if (dep is null) 
            return false;
        unitofwork.Department.Delete(dep);
        return await unitofwork.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<DepartmentResponse>> GetAllAsync()
    {
        return (await unitofwork.Department.GetAllAsync()).Select(x=>x.ToResponse());
    }


    public async Task<DepartmentDetailsResponse?> GetByIdAsync(int id)
    {
       return (await unitofwork.Department.GetByIdAsync(id)).ToDetails();
    }

    public async Task<int> UpdateAsync(DepartmentUpdateRequest request)
    {
         unitofwork.Department.Update(request.ToEntity());
        return  await unitofwork.SaveChangesAsync();
    }
}
