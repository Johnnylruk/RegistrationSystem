using Microsoft.EntityFrameworkCore;
using RegistrationSystem.Application.Repository;
using RegistrationSystem.Infrastructure.Data;
using RegistrationSystem.UI.Helper;

namespace RegistrationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<DataBaseContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
                );
            
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped<IContactsRepository, ContactRepository>();
            builder.Services.AddScoped<IUsersRepository, UserRepository>();
            builder.Services.AddScoped<ILogged, Logged>();
            builder.Services.AddScoped<IEmail, Email>();

            builder.Services.AddSession(o => 
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
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

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}