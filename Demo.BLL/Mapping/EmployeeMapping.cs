

using Demo.BLL.DataTransferObject;
using Demo.DAL.Entities;

namespace Demo.BLL.Mapping;

public class EmployeeMapping :Profile
{
    public EmployeeMapping()
    {
        CreateMap<EmployeeRequest, Employee>();
        CreateMap<EmployeeUpdateRequest, Employee>();
        CreateMap<Employee,EmployeeDetailsResponse>();
        CreateMap<Employee, EmployeeResponse>();




    }

}
