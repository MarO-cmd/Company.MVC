using Company.MVC.BLL.Interfaces;
using Company.MVC.BLL.Repos;
using Company.MVC.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MVC.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IEmployeeRepo _employeeRepo;
        private IDepartmentRepo _departmentRepo;
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            _employeeRepo = new EmployeeRepo(context);
            _departmentRepo = new DepartmentRepo(context);
            this.context = context;
        }
        public IEmployeeRepo EmployeeRepo => _employeeRepo;

        public IDepartmentRepo DepartmentRepo => _departmentRepo;
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
