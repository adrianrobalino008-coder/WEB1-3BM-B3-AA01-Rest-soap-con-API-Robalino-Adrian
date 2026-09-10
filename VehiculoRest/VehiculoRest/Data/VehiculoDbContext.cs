using Microsoft.EntityFrameworkCore;
using VehiculoRest.Models;

namespace VehiculoRest.Data
{
    public class VehiculoDbContext : DbContext
    {
        public VehiculoDbContext(DbContextOptions<VehiculoDbContext> options) : base(options)
        {
        }

        public DbSet<Mantenimiento> Mantenimientos { get; set; }
    }
}