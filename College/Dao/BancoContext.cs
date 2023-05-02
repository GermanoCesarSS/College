using College.Models;
using Microsoft.EntityFrameworkCore;

namespace College.DAO
{
    public class BancoContext : DbContext
    {
        public  BancoContext(DbContextOptions<BancoContext> options) : base(options) { 
        }

        public DbSet<CursosModel> Cursos { get; set; }
    }
}
