using Microsoft.AspNetCore.Mvc;
using RegistroEmpleados.BLL.Services;
using RegistroEmpleados.Models;

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
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var depto = await _service.GetByIdAsync(id);
            return depto == null ? NotFound() : Ok(depto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            await _service.AddAsync(departamento);
            return CreatedAtAction(nameof(GetById), new { id = departamento.Id_Depto }, departamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Departamento departamento)
        {
            if (id != departamento.Id_Depto) return BadRequest();
            await _service.UpdateAsync(departamento);
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
