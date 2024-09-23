using Microsoft.EntityFrameworkCore;
using tarea1.Models;

namespace tarea1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options)
        {

        }
        public DbSet<Producto> tbl_Producto { get; set; }
        public DbSet<Casa> tbl_Casa { get; set; }
        public DbSet<Categoria> tbl_Categoria { get; set; }
    }
}
