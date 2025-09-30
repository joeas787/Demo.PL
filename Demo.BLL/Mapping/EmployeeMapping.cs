

using Demo.BLL.DataTransferObject;
using Demo.DAL.Entities;

namespace Demo.BLL.Mapping;

public class EmployeeMapping :Profile
{
    public EmployeeMapping()
    {
        CreateMap<EmployeeRequest, Employee>();
        CreateMap<EmployeeUpdateRequest, Employee>();
        CreateMap<Employee,EmployeeDetailsResponse>().ForMember(d=>d.Department,
            o=>o.MapFrom(x=>x.Department.Name));
        CreateMap<Employee, EmployeeResponse>();
        CreateMap<EmployeeDetailsResponse, EmployeeUpdateRequest>();
        CreateMap<EmployeeUpdateRequest, EmployeeRequest>();




    }

}
