namespace RegistroEmpleados.Models;

public class Puesto
{
    public int Id_Puesto { get; set; }
    public string Nombre_Puesto { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Salario { get; set; }
    public string? Horario { get; set; }
    public string Estado { get; set; } = "Activo";

    // Navigation
    public ICollection<Empleado>? Empleados { get; set; }
}
