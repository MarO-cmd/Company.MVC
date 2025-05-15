using Company.MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MVC.DAL.Specifications.Departments
{
    public class DepartmentSpecifications : BaseSpecifications<Department>
    {
        public DepartmentSpecifications()
        {
            Includes.Add(d => d.Employees);
        }
        public DepartmentSpecifications(int id):base(d => d.Id == id)
        {
            Includes.Add(d => d.Employees);
        }
    }
}
