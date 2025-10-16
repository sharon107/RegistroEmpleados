using RegistroEmpleados.DAL.Repositories;
using RegistroEmpleados.Models;

namespace RegistroEmpleados.BLL.Services
{
    public class PuestoService
    {
        private readonly PuestoRepository _repo;

        public PuestoService(PuestoRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Puesto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Puesto?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Puesto puesto) => _repo.AddAsync(puesto);
        public Task UpdateAsync(Puesto puesto) => _repo.UpdateAsync(puesto);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
