using RegistroEmpleados.Data;
using RegistroEmpleados.Models;

namespace RegistroEmpleados.Services;

public class EmpleadoService
{
    private readonly IEmpleadoRepository _repo;
    public EmpleadoService(IEmpleadoRepository repo) => _repo = repo;

    public Task<List<Empleado>> ObtenerTodosAsync() => _repo.ObtenerTodosAsync();

    public Task<Empleado?> ObtenerPorIdAsync(int id) => _repo.ObtenerPorIdAsync(id);

    public async Task<Empleado> CrearAsync(Empleado emp)
    {
        Validar(emp);
        // Reglas de negocio: por ejemplo comprobar existencia de puesto/depto se podría agregar
        emp.Fecha_Cont = emp.Fecha_Cont == default ? DateTime.Now.Date : emp.Fecha_Cont;
        emp.Estado ??= "Activo";
        return await _repo.CrearAsync(emp);
    }

    public async Task<bool> ActualizarAsync(Empleado emp)
    {
        if (emp.Id_Emp <= 0) throw new ArgumentException("Id inválido.");
        Validar(emp);
        return await _repo.ActualizarAsync(emp);
    }

    public async Task<bool> EliminarAsync(int id)
    {
        if (id <= 0) throw new ArgumentException("Id inválido.");
        return await _repo.EliminarAsync(id);
    }

    private void Validar(Empleado emp)
    {
        if (emp == null) throw new ArgumentNullException(nameof(emp));
        if (string.IsNullOrWhiteSpace(emp.Nombre)) throw new ArgumentException("Nombre requerido.");
        if (string.IsNullOrWhiteSpace(emp.Apellido)) throw new ArgumentException("Apellido requerido.");
        if (string.IsNullOrWhiteSpace(emp.Correo) || !emp.Correo.Contains("@")) throw new ArgumentException("Correo inválido.");
        if (emp.Id_Puesto <= 0) throw new ArgumentException("Puesto inválido.");
        if (emp.Id_Depto <= 0) throw new ArgumentException("Departamento inválido.");
    }
}
