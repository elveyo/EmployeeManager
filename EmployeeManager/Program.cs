using EmployeeManager.BusinessLogic;
using EmployeeManager.BusinessLogic.Services.Departments;
using EmployeeManager.BusinessLogic.Services.Employees;
using EmployeeManager.Web.Services;
using EmployeeManager.Web.Validators;
using EmployeeManager.Web.ViewModals;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder
                .Services
                .AddDbContext<ApplicationDBContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
                });

            builder.
                Services
                .AddScoped<ISelectListService, SelectListService>();
            //validator dependency

            builder
                .Services
                .AddScoped<IValidator<EmployeeAddVM>, EmployeeAddVMValidator>();
            //adding entity services
            builder
                .Services
                .AddScoped<IEmployeeService, EmployeeService>();
            builder
                .Services
                .AddScoped<IDepartmentService, DepartmentService>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}