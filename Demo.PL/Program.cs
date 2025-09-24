using Demo.BLL.Services;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDepartmentServices,DepartmentServices>();
            builder.Services.AddScoped<IDepartmentRepositories,DepartmentRepositories>();
            builder.Services.AddScoped<IEmployeeRepositories,EmployeeRepositories>();
            builder.Services.AddAutoMapper(typeof(BLL.Assembly).Assembly);
            builder.Services.AddDbContext<CompanyDbContext>(options =>
            {
                var cs = builder.Configuration.GetConnectionString("CS");

                options.UseSqlServer(cs);


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
          //  app.UseRouting();

           // app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
