using RegistroEmpleados.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistroEmpleados.DAL.Repositories
{
    public interface IPuestoRepository
    {
        Task<IEnumerable<Puesto>> ObtenerTodosAsync();
        Task<Puesto?> ObtenerPorIdAsync(int id);
        Task<Puesto> CrearAsync(Puesto puesto); // <- devuelve Puesto
        Task<bool> ActualizarAsync(Puesto puesto);
        Task<bool> EliminarAsync(int id);
    }
}
