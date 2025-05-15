using Company.MVC.BLL.Interfaces;
using Company.MVC.DAL.Data.Contexts;
using Company.MVC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MVC.BLL.Repos
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {

        public EmployeeRepo(AppDbContext context) : base(context)
        {
           
        }

        public async Task<IEnumerable<Employee>> SearchByNameAsync(string name)
        {
            return await context.Employees.Where(e => e.Name.ToLower().Contains(name.ToLower()))
            .Include(e => e.WorkFor).ToListAsync();
        }
    }
}
