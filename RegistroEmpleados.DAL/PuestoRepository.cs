using Microsoft.EntityFrameworkCore;
using RegistroEmpleados.Data;
using RegistroEmpleados.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistroEmpleados.DAL.Repositories
{
    public class PuestoRepository : IPuestoRepository
    {
        private readonly AppDbContext _contexto;

        public PuestoRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Puesto>> ObtenerTodosAsync()
        {
            return await _contexto.Puestos.ToListAsync();
        }

        public async Task<Puesto?> ObtenerPorIdAsync(int id)
        {
            return await _contexto.Puestos.FindAsync(id);
        }

        public async Task<Puesto> CrearAsync(Puesto puesto)
        {
            await _contexto.Puestos.AddAsync(puesto);
            await _contexto.SaveChangesAsync();
            return puesto; // <- ahora devuelve el objeto creado
        }

        public async Task<bool> ActualizarAsync(Puesto puesto)
        {
            _contexto.Puestos.Update(puesto);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var puesto = await _contexto.Puestos.FindAsync(id);
            if (puesto == null) return false;
            _contexto.Puestos.Remove(puesto);
            return await _contexto.SaveChangesAsync() > 0;
        }
    }
}
