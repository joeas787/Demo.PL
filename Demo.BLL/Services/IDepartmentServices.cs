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
        DepartmentDetailsResponse? GetById(int id);
        IEnumerable<DepartmentResponse> GetAll(); 
        
        int Update(DepartmentUpdateRequest request);
        bool Delete(int id);
        int Add(DepartmentRequest request);

        
    }
}
