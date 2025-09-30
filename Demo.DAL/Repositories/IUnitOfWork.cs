using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    public interface IUnitOfWork
    {
        IDepartmentRepositories Department{ get; }
        IEmployeeRepositories Employee{ get; }
        int SaveChanges();
    }
}
