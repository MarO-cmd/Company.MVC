using AutoMapper;
using Company.MVC.DAL.Models;
using Company.MVC.PL.ViewModels.Employees;

namespace Company.MVC.PL.Mapping.Employees
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            //CreateMap<Employee, EmployeeViewModel>();
            //CreateMap<EmployeeViewModel, Employee>();
            // instead of doing this you can write this line only

            CreateMap<EmployeeViewModel, Employee>().ReverseMap(); // can convert from Employee to ViewModel and vice verse

        }
    }
}
