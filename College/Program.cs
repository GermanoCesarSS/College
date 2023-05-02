using Microsoft.EntityFrameworkCore;
using College.DAO;
using Microsoft.EntityFrameworkCore.Infrastructure;
using College.Repositorio;

namespace College
{
    public class Program
    {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("BancoDeDados");
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o => o.UseSqlServer(connectionString));

            builder.Services.AddScoped<ICursoRepositorio, CursosRepositorio>();
           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
            }
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