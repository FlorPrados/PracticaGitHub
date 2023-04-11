using EmpresaAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Sede>().Property(g => g.)
        //}
        public DbSet<Sede> Sedes => Set<Sede>();
        public DbSet<Sector> Sectores => Set<Sector>();
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Empleado> Empleados => Set<Empleado>();


    }
}
