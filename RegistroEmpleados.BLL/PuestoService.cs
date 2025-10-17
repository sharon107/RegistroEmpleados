using RegistroEmpleados.Models;
using RegistroEmpleados.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroEmpleados.Services
{
    public class PuestoService
    {
        private readonly IPuestoRepository _repo;

        public PuestoService(IPuestoRepository repo) => _repo = repo;

        public async Task<List<Puesto>> ObtenerTodosAsync()
        {
            var puestos = await _repo.ObtenerTodosAsync();
            return puestos.ToList();
        }

        public Task<Puesto?> ObtenerPorIdAsync(int id) => _repo.ObtenerPorIdAsync(id);

        public async Task<Puesto> CrearAsync(Puesto puesto)
        {
            Validar(puesto);
            puesto.Estado ??= "Activo";
            return await _repo.CrearAsync(puesto);
        }

        public async Task<bool> ActualizarAsync(Puesto puesto)
        {
            if (puesto.Id_Puesto <= 0) throw new ArgumentException("Id inválido.");
            Validar(puesto);
            return await _repo.ActualizarAsync(puesto);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.");
            return await _repo.EliminarAsync(id);
        }

        private void Validar(Puesto puesto)
        {
            if (puesto == null) throw new ArgumentNullException(nameof(puesto));
            if (string.IsNullOrWhiteSpace(puesto.Nombre_Puesto)) throw new ArgumentException("Nombre del puesto requerido.");
            if (puesto.Salario <= 0) throw new ArgumentException("Salario debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(puesto.Horario)) throw new ArgumentException("Horario requerido.");
        }
    }
}
