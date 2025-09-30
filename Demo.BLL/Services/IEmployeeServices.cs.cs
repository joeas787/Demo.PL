

using Demo.BLL.DataTransferObject;

namespace Demo.BLL.Services;

public interface IEmployeeServices
{

    EmployeeDetailsResponse? GetById(int id);
    IEnumerable<EmployeeResponse> GetAll();
    IEnumerable<EmployeeResponse> GetAll(string? Value);

    int Update(EmployeeUpdateRequest request);
    bool Delete(int id);
    int Add(EmployeeRequest request);
}
