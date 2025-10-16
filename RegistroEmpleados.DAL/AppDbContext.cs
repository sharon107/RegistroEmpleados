using Microsoft.EntityFrameworkCore;
using RegistroEmpleados.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RegistroEmpleados.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Departamento> Departamentos { get; set; } = null!;
    public DbSet<Puesto> Puestos { get; set; } = null!;
    public DbSet<Empleado> Empleados { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Departamento>(b =>
        {
            b.ToTable("Departamentos");
            b.HasKey(x => x.Id_Depto);
            b.Property(x => x.Nombre_Depto).HasMaxLength(50).IsRequired();
            b.Property(x => x.Descripcion).HasMaxLength(150);
            b.Property(x => x.Ubicacion).HasMaxLength(100);
            b.Property(x => x.Estado).HasMaxLength(20);
        });

        modelBuilder.Entity<Puesto>(b =>
        {
            b.ToTable("Puestos");
            b.HasKey(x => x.Id_Puesto);
            b.Property(x => x.Nombre_Puesto).HasMaxLength(50).IsRequired();
            b.Property(x => x.Descripcion).HasMaxLength(150);
            b.Property(x => x.Salario).HasColumnType("decimal(10,2)");
            b.Property(x => x.Horario).HasMaxLength(50);
            b.Property(x => x.Estado).HasMaxLength(20);
        });

        modelBuilder.Entity<Empleado>(b =>
        {
            b.ToTable("Empleados");
            b.HasKey(x => x.Id_Emp);
            b.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
            b.Property(x => x.Apellido).HasMaxLength(50).IsRequired();
            b.Property(x => x.Correo).HasMaxLength(100).IsRequired();
            b.Property(x => x.Telefono).HasMaxLength(20);
            b.Property(x => x.Estado).HasMaxLength(20);
            b.Property(x => x.Fecha_Cont).HasColumnType("date");

            b.HasOne(e => e.Puesto)
             .WithMany(p => p.Empleados)
             .HasForeignKey(e => e.Id_Puesto)
             .HasConstraintName("fk_emp_puesto")
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(e => e.Departamento)
             .WithMany(d => d.Empleados)
             .HasForeignKey(e => e.Id_Depto)
             .HasConstraintName("fk_emp_depto")
             .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
