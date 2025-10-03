

using Demo.BLL.DataTransferObject;

namespace Demo.BLL.Services;

public interface IEmployeeServices
{

    Task <EmployeeDetailsResponse?> GetByIdAsync(int id);
   Task< IEnumerable<EmployeeResponse>> GetAllAsync();
   Task<IEnumerable<EmployeeResponse>> GetAllAsync(string? Value);

   Task< int> UpdateAsync(EmployeeUpdateRequest request);
    Task<bool> DeleteAsync(int id);
    Task<int> AddAsync(EmployeeRequest request);
}
