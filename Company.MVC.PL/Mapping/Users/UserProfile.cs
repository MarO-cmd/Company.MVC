using AutoMapper;
using Company.MVC.DAL.Models;
using Company.MVC.PL.ViewModels.Users;

namespace Company.MVC.PL.Mapping.Users
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }

    }
}
