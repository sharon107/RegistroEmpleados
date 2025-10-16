using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroEmpleados.Models;

public class Empleado
{
    public int Id_Emp { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public int Id_Puesto { get; set; }
    public int Id_Depto { get; set; }
    public DateTime Fecha_Cont { get; set; }
    public string Estado { get; set; } = "Activo";

    // Relaciones
    [ForeignKey("Id_Puesto")]
    public Puesto? Puesto { get; set; }

    [ForeignKey("Id_Depto")]
    public Departamento? Departamento { get; set; }
}
