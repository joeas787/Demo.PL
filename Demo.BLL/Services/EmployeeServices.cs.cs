

global using AutoMapper;
using Demo.BLL.DataTransferObject;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;

namespace Demo.BLL.Services
{
    public class EmployeeServices(IEmployeeRepositories employeeRepositories,IMapper mapper) : IEmployeeServices
    {
        public int Add(EmployeeRequest request)
        {
            var emp = mapper.Map<EmployeeRequest, Employee>(request);
            return employeeRepositories.Add(emp);
        }

        public bool Delete(int id)
        {
            var emp = employeeRepositories.GetById(id);
            if (emp is null)
                return false;
            var r = employeeRepositories.Delete(emp);
            return r > 0;
        }

        public IEnumerable<EmployeeResponse> GetAll()
        {
            var emp= employeeRepositories.GetAll();
           return mapper.Map<IEnumerable<EmployeeResponse>>(emp);
            

        }


        public EmployeeDetailsResponse? GetById(int id)
        {
            var emp= employeeRepositories.GetById(id);
         return  mapper.Map<EmployeeDetailsResponse>(emp);
        }

        public int Update(EmployeeUpdateRequest request)
        {
            return employeeRepositories.Update(mapper.Map<Employee>(request));
        }

    }
}
