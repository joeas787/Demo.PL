

global using AutoMapper;
using Demo.BLL.DataTransferObject;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;
using System.Threading.Tasks;

namespace Demo.BLL.Services
{
    public class EmployeeServices(IUnitOfWork employee,IMapper mapper,IDocument document) : IEmployeeServices
    {
        public async Task<int> AddAsync(EmployeeRequest request)
        {
            var emp = mapper.Map<EmployeeRequest, Employee>(request);
            if (request.Image != null && request.Image.Length > 0) {


                var image =await document.UploadAsync(request.Image, "Images");

                emp.Image = image;


            
            }
             employee.Employee.Add(emp);
            return await employee.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var emp = await employee.Employee.GetByIdAsync(id);
            if (emp is null)
                return false;
             employee.Employee.Delete(emp);
            var r=await employee.SaveChangesAsync();
            if (r > 0&& emp.Image!=null)
            {

                document.Delete(emp.Image, "Images");
                return true;

            }

            return false;

        }

        public async Task<IEnumerable<EmployeeResponse>> GetAllAsync()
        {
            var emp= employee.Employee.GetAllAsync(e=> new EmployeeResponse
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
           return await emp;
            

        }

        public async Task<IEnumerable<EmployeeResponse>> GetAllAsync(string? Value)
        {
            var emp  =  employee.Employee.GetAllAsync(e => new EmployeeResponse
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





            }).Result.Where(e=>e.Name.Contains(Value));
            return  emp;
        }

        public async Task<EmployeeDetailsResponse?> GetByIdAsync(int id)
        {
            var emp=await employee.Employee.GetByIdAsync(id);
         return  mapper.Map<EmployeeDetailsResponse>(emp);
        }

        public async Task<int> UpdateAsync(EmployeeUpdateRequest request)
        {
             employee.Employee.Update(mapper.Map<Employee>(request));
            return await employee.SaveChangesAsync();
        }

    }
}
