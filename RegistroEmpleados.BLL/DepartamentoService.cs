using RegistroEmpleados.DAL.Repositories;
using RegistroEmpleados.Models;

namespace RegistroEmpleados.BLL.Services
{
    public class DepartamentoService
    {
        private readonly DepartamentoRepository _repo;

        public DepartamentoService(DepartamentoRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Departamento>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Departamento?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Departamento depto) => _repo.AddAsync(depto);
        public Task UpdateAsync(Departamento depto) => _repo.UpdateAsync(depto);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
