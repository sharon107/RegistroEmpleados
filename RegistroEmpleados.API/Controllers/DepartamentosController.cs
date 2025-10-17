using Microsoft.AspNetCore.Mvc;
using RegistroEmpleados.Services;
using RegistroEmpleados.Models;
using System.Threading.Tasks;

namespace RegistroEmpleados.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : ControllerBase
    {
        private readonly DepartamentoService _service;

        public DepartamentosController(DepartamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var deptos = await _service.ObtenerTodosAsync();
            return Ok(deptos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var depto = await _service.ObtenerPorIdAsync(id);
            return depto == null ? NotFound() : Ok(depto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            var creado = await _service.CrearAsync(departamento);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id_Depto }, creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Departamento departamento)
        {
            if (id != departamento.Id_Depto) return BadRequest();
            await _service.ActualizarAsync(departamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarAsync(id);
            return NoContent();
        }
    }
}
