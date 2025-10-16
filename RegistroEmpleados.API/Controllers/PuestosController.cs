using Microsoft.AspNetCore.Mvc;
using RegistroEmpleados.BLL.Services;
using RegistroEmpleados.Models;

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
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var puesto = await _service.GetByIdAsync(id);
            return puesto == null ? NotFound() : Ok(puesto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Puesto puesto)
        {
            await _service.AddAsync(puesto);
            return CreatedAtAction(nameof(GetById), new { id = puesto.Id_Puesto }, puesto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Puesto puesto)
        {
            if (id != puesto.Id_Puesto) return BadRequest();
            await _service.UpdateAsync(puesto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
