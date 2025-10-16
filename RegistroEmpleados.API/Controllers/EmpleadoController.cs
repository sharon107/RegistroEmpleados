using Microsoft.AspNetCore.Mvc;
using RegistroEmpleados.Models;
using RegistroEmpleados.Services;

namespace RegistroEmpleados.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadoController : ControllerBase
{
    private readonly EmpleadoService _service;
    public EmpleadoController(EmpleadoService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await _service.ObtenerTodosAsync();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var e = await _service.ObtenerPorIdAsync(id);
        if (e == null) return NotFound(new { mensaje = "Empleado no encontrado" });
        return Ok(e);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Empleado emp)
    {
        try
        {
            var creado = await _service.CrearAsync(emp);
            return CreatedAtAction(nameof(Get), new { id = creado.Id_Emp }, creado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] Empleado emp)
    {
        try
        {
            emp.Id_Emp = id;
            var ok = await _service.ActualizarAsync(emp);
            return ok ? Ok(new { mensaje = "Actualizado" }) : NotFound(new { mensaje = "No encontrado" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var ok = await _service.EliminarAsync(id);
            return ok ? Ok(new { mensaje = "Eliminado" }) : NotFound(new { mensaje = "No encontrado" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
