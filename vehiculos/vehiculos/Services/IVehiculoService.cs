using CoreWCF;
using VehiculosSOAPB.Models;

namespace VehiculosSOAPB.Services
{
    [ServiceContract]
    public interface IVehiculoService
    {
        [OperationContract]
        List<Categoria> ObtenerCategorias();

        [OperationContract]
        List<Vehiculo> ObtenerVehiculos();

        [OperationContract]
        Vehiculo? ObtenerVehiculo(int id);

        [OperationContract]
        Vehiculo AgregarVehiculo(Vehiculo vehiculo);

        [OperationContract]
        Vehiculo ActualizarVehiculo(Vehiculo vehiculo);

        [OperationContract]
        bool EliminarVehiculo(int id);

        [OperationContract]
        List<Vehiculo> ObtenerVehiculosPorMarca(string marca);

        [OperationContract]
        List<Vehiculo> ObtenerVehiculosPorCategoria(int idCategoria);
    }
}