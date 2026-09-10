using Microsoft.EntityFrameworkCore;
using VehiculosSOAPB.Models;

namespace VehiculosSOAPB.Data
{
    public class VehiculosDBContext : DbContext
    {
        public VehiculosDBContext(DbContextOptions<VehiculosDBContext> options) : base(options)
        {
        }

        // la 2 tablas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}