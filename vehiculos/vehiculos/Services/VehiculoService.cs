using VehiculosSOAPB.Data;
using VehiculosSOAPB.Models;

namespace VehiculosSOAPB.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly VehiculosDBContext _context;

       
        public VehiculoService(VehiculosDBContext context)
        {
            _context = context;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return _context.Categorias.ToList();
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            return _context.Vehiculos.ToList();
        }

        public Vehiculo? ObtenerVehiculo(int id)
        {
            return _context.Vehiculos.FirstOrDefault(v => v.IdVehiculo == id);
        }

        public Vehiculo AgregarVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();
            return vehiculo;
        }

        public Vehiculo ActualizarVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Update(vehiculo);
            _context.SaveChanges();
            return vehiculo;
        }

        public bool EliminarVehiculo(int id)
        {
            var vehiculo = _context.Vehiculos.Find(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                _context.SaveChanges();
                return true; 
            }
            return false; 
        }

        
        public List<Vehiculo> ObtenerVehiculosPorMarca(string marca)
        {
            
            return _context.Vehiculos
                           .Where(v => v.Marca.ToLower() == marca.ToLower())
                           .ToList();
        }

        
        public List<Vehiculo> ObtenerVehiculosPorCategoria(int idCategoria)
        {
            return _context.Vehiculos
                           .Where(v => v.IdCategoria == idCategoria)
                           .ToList();
        }
    }
}