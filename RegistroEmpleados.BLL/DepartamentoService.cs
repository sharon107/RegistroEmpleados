using RegistroEmpleados.Models;
using RegistroEmpleados.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroEmpleados.Services
{
    public class DepartamentoService
    {
        private readonly IDepartamentoRepository _repo;

        public DepartamentoService(IDepartamentoRepository repo) => _repo = repo;

        public async Task<List<Departamento>> ObtenerTodosAsync()
        {
            var deptos = await _repo.ObtenerTodosAsync();
            return deptos.ToList();
        }

        public Task<Departamento?> ObtenerPorIdAsync(int id) => _repo.ObtenerPorIdAsync(id);

        public async Task<Departamento> CrearAsync(Departamento depto)
        {
            Validar(depto);
            depto.Estado ??= "Activo";
            return await _repo.CrearAsync(depto); // <- ya funciona porque el repo devuelve Departamento
        }

        public async Task<bool> ActualizarAsync(Departamento depto)
        {
            if (depto.Id_Depto <= 0) throw new ArgumentException("Id inválido.");
            Validar(depto);
            return await _repo.ActualizarAsync(depto);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.");
            return await _repo.EliminarAsync(id);
        }

        private void Validar(Departamento depto)
        {
            if (depto == null) throw new ArgumentNullException(nameof(depto));
            if (string.IsNullOrWhiteSpace(depto.Nombre_Depto)) throw new ArgumentException("Nombre del departamento requerido.");
            if (string.IsNullOrWhiteSpace(depto.Ubicacion)) throw new ArgumentException("Ubicación requerida.");
        }
    }
}
