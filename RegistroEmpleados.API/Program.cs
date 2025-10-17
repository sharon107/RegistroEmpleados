using Microsoft.EntityFrameworkCore;
using RegistroEmpleados.DAL.Repositories;
using RegistroEmpleados.Services;
using RegistroEmpleados.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DepartamentoRepository>();
builder.Services.AddScoped<DepartamentoService>();
builder.Services.AddScoped<PuestoRepository>();
builder.Services.AddScoped<PuestoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
