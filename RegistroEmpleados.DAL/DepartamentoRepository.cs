using Microsoft.EntityFrameworkCore;
using RegistroEmpleados.Data;
using RegistroEmpleados.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistroEmpleados.DAL.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly AppDbContext _contexto;

        public DepartamentoRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Departamento>> ObtenerTodosAsync()
        {
            return await _contexto.Departamentos.ToListAsync();
        }

        public async Task<Departamento?> ObtenerPorIdAsync(int id)
        {
            return await _contexto.Departamentos.FindAsync(id);
        }

        public async Task<Departamento> CrearAsync(Departamento departamento)
        {
            await _contexto.Departamentos.AddAsync(departamento);
            await _contexto.SaveChangesAsync();
            return departamento; // <- ahora devuelve el objeto creado
        }

        public async Task<bool> ActualizarAsync(Departamento departamento)
        {
            _contexto.Departamentos.Update(departamento);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var departamento = await _contexto.Departamentos.FindAsync(id);
            if (departamento == null) return false;
            _contexto.Departamentos.Remove(departamento);
            return await _contexto.SaveChangesAsync() > 0;
        }
    }
}
