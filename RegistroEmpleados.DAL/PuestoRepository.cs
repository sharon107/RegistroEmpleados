using Microsoft.EntityFrameworkCore;
using RegistroEmpleados.Models;
using RegistroEmpleados.DAL;
using RegistroEmpleados.Data;

namespace RegistroEmpleados.DAL.Repositories
{
    public class PuestoRepository
    {
        private readonly AppDbContext _context;

        public PuestoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Puesto>> GetAllAsync()
        {
            return await _context.Puestos.ToListAsync();
        }

        public async Task<Puesto?> GetByIdAsync(int id)
        {
            return await _context.Puestos.FindAsync(id);
        }

        public async Task AddAsync(Puesto puesto)
        {
            _context.Puestos.Add(puesto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Puesto puesto)
        {
            _context.Puestos.Update(puesto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto != null)
            {
                _context.Puestos.Remove(puesto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
