

global using AutoMapper;
using Demo.BLL.DataTransferObject;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;

namespace Demo.BLL.Services
{
    public class EmployeeServices(IUnitOfWork employee,IMapper mapper) : IEmployeeServices
    {
        public int Add(EmployeeRequest request)
        {
            var emp = mapper.Map<EmployeeRequest, Employee>(request);
             employee.Employee.Add(emp);
            return employee.SaveChanges();
        }

        public bool Delete(int id)
        {
            var emp = employee.Employee.GetById(id);
            if (emp is null)
                return false;
             employee.Employee.Delete(emp);
            return employee.SaveChanges() > 0;
        }

        public IEnumerable<EmployeeResponse> GetAll()
        {
            var emp= employee.Employee.GetAll(e=> new EmployeeResponse
            {
                Name = e.Name,
                Age =(int)e.Age,
                Salary=e.Salary,
                Email=e.Email,
                IsActive=e.IsActive,
                Gender=e.Gender.ToString(),
                EmployeeType=e.EmployeeType.ToString(),
                Id=e.Id,
                Department=e.Department.Name
                




            });
           return emp;
            

        }

        public IEnumerable<EmployeeResponse> GetAll(string? Value)
        {
            var emp = employee.Employee.GetAll(e => new EmployeeResponse
            {
                Name = e.Name,
                Age = (int)e.Age,
                Salary = e.Salary,
                Email = e.Email,
                IsActive = e.IsActive,
                Gender = e.Gender.ToString(),
                EmployeeType = e.EmployeeType.ToString(),
                Id = e.Id,
                Department = e.Department.Name





            }).Where(e=>e.Name.Contains(Value));
            return emp;
        }

        public EmployeeDetailsResponse? GetById(int id)
        {
            var emp= employee.Employee.GetById(id);
         return  mapper.Map<EmployeeDetailsResponse>(emp);
        }

        public int Update(EmployeeUpdateRequest request)
        {
             employee.Employee.Update(mapper.Map<Employee>(request));
            return employee.SaveChanges();
        }

    }
}
