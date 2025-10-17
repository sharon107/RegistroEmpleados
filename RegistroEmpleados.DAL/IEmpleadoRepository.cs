using RegistroEmpleados.Models;

namespace RegistroEmpleados.Data;

public interface IEmpleadoRepository
{
    Task<List<Empleado>> ObtenerTodosAsync();
    Task<Empleado?> ObtenerPorIdAsync(int id);
    Task<Empleado> CrearAsync(Empleado emp);
    Task<bool> ActualizarAsync(Empleado emp);
    Task<bool> EliminarAsync(int id);
}

