namespace RegistroEmpleados.Models;

public class Departamento
{
    public int Id_Depto { get; set; }
    public string Nombre_Depto { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string? Ubicacion { get; set; }
    public string Estado { get; set; } = "Activo";

    // Navegation
    public ICollection<Empleado>? Empleados { get; set; }
}
