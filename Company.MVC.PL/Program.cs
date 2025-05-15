using AutoMapper;
using Company.MVC.BLL;
using Company.MVC.BLL.Interfaces;
using Company.MVC.BLL.Repos;
using Company.MVC.DAL.Data.Contexts;
using Company.MVC.DAL.Models;
using Company.MVC.PL.Mapping.Employees;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace Company.MVC.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });

            //builder.Services.AddDbContext<AppDbContext>(options =>
            //      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
            //          ServiceLifetime.Scoped);

            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            //builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(EmployeeProfile));

            // Allow DI for Identity packadge
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            // builder.Services.AddScoped<UserManager<ApplicationUser>>();

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/SignIn"; // redirect to this action if current action is Authorize
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            // after routing decide middlewares 

            app.UseAuthentication(); // to ask if you are allowed to join or not

            app.UseAuthorization(); // if this route is allowed to go?

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=SignIn}/{id?}");

            app.Run();
        }
    }
}
