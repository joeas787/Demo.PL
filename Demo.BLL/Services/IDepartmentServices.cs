using Demo.BLL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services
{
    public interface IDepartmentServices
    {
       Task< DepartmentDetailsResponse?> GetByIdAsync(int id);
        Task< IEnumerable<DepartmentResponse>> GetAllAsync(); 
        
        Task<int> UpdateAsync(DepartmentUpdateRequest request);
        Task<bool> DeleteAsync(int id);
        Task<int> AddAsync(DepartmentRequest request);

        
    }
}
