using RegistroEmpleados.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistroEmpleados.DAL.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> ObtenerTodosAsync();
        Task<Departamento?> ObtenerPorIdAsync(int id);
        Task<Departamento> CrearAsync(Departamento departamento); // <- devuelve Departamento
        Task<bool> ActualizarAsync(Departamento departamento);
        Task<bool> EliminarAsync(int id);
    }
}
