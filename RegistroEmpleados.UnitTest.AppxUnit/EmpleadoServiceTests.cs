using Moq;
using RegistroEmpleados.Data;
using RegistroEmpleados.Models;
using RegistroEmpleados.Services;

namespace RegistroEmpleados.UnitTest.AppxUnit
{
    public class EmpleadoServiceTests
    {
        private readonly EmpleadoService _service;
        private readonly Mock<IEmpleadoRepository> _mockRepo;

        public EmpleadoServiceTests()
        {
            _mockRepo = new Mock<IEmpleadoRepository>();
            _service = new EmpleadoService(_mockRepo.Object);
        }

        [Fact]
        public async Task CrearEmpleado_DeberiaRetornarEmpleadoCreado()
        {
            // Arrange
            var emp = new Empleado
            {
                Nombre = "Ana",
                Apellido = "López",
                Correo = "ana@test.com",
                Id_Puesto = 1,
                Id_Depto = 1
            };

            _mockRepo.Setup(r => r.CrearAsync(emp)).ReturnsAsync(emp);

            // Act
            var resultado = await _service.CrearAsync(emp);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Ana", resultado.Nombre);
        }

        [Fact]
        public async Task ObtenerTodos_DeberiaRetornarLista()
        {
            // Arrange
            _mockRepo.Setup(r => r.ObtenerTodosAsync()).ReturnsAsync(new List<Empleado>());

            // Act
            var resultado = await _service.ObtenerTodosAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.IsType<List<Empleado>>(resultado);
        }

        [Fact]
        public async Task ActualizarEmpleado_DeberiaRetornarTrue()
        {
            // Arrange
            var emp = new Empleado
            {
                Id_Emp = 1,
                Nombre = "Pedro",
                Apellido = "Rivas",
                Correo = "pedro@test.com",
                Id_Puesto = 1,
                Id_Depto = 1
            };

            _mockRepo.Setup(r => r.ActualizarAsync(emp)).ReturnsAsync(true);

            // Act
            var resultado = await _service.ActualizarAsync(emp);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public async Task EliminarEmpleado_DeberiaRetornarTrue()
        {
            // Arrange
            _mockRepo.Setup(r => r.EliminarAsync(1)).ReturnsAsync(true);

            // Act
            var resultado = await _service.EliminarAsync(1);

            // Assert
            Assert.True(resultado);
        }
    }
}
