using Demo.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    public class UnitOfWork(CompanyDbContext dbContext,IEmployeeRepositories employee,IDepartmentRepositories department) : IUnitOfWork
    {
        public IDepartmentRepositories Department => department;

        public IEmployeeRepositories Employee => employee;

        public int SaveChanges()
        {
         return  dbContext.SaveChanges();
        }
    }
}
