using Microsoft.EntityFrameworkCore;
using RegistroEmpleados.Models;

namespace RegistroEmpleados.Data;

public class EmpleadoRepository : IEmpleadoRepository
{
    private readonly AppDbContext _db;
    public EmpleadoRepository(AppDbContext db) => _db = db;

    public async Task<Empleado> CrearAsync(Empleado emp)
    {
        _db.Empleados.Add(emp);
        await _db.SaveChangesAsync();
        return emp;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var e = await _db.Empleados.FindAsync(id);
        if (e == null) return false;
        _db.Empleados.Remove(e);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Empleado?> ObtenerPorIdAsync(int id)
    {
        return await _db.Empleados
            .Include(x => x.Puesto)
            .Include(x => x.Departamento)
            .FirstOrDefaultAsync(x => x.Id_Emp == id);
    }

    public async Task<List<Empleado>> ObtenerTodosAsync()
    {
        return await _db.Empleados
            .Include(x => x.Puesto)
            .Include(x => x.Departamento)
            .ToListAsync();
    }

    public async Task<bool> ActualizarAsync(Empleado emp)
    {
        var exist = await _db.Empleados.AnyAsync(x => x.Id_Emp == emp.Id_Emp);
        if (!exist) return false;
        _db.Empleados.Update(emp);
        await _db.SaveChangesAsync();
        return true;
    }
}
