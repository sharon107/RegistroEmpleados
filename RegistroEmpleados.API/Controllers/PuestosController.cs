using Microsoft.AspNetCore.Mvc;
using RegistroEmpleados.Services;
using RegistroEmpleados.Models;
using System.Threading.Tasks;

namespace RegistroEmpleados.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuestosController : ControllerBase
    {
        private readonly PuestoService _service;

        public PuestosController(PuestoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var puestos = await _service.ObtenerTodosAsync();
            return Ok(puestos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var puesto = await _service.ObtenerPorIdAsync(id);
            return puesto == null ? NotFound() : Ok(puesto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Puesto puesto)
        {
            var creado = await _service.CrearAsync(puesto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id_Puesto }, creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Puesto puesto)
        {
            if (id != puesto.Id_Puesto) return BadRequest();
            await _service.ActualizarAsync(puesto);
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
