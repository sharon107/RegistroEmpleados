using Moq;
using RegistroEmpleados.DAL.Repositories;
using RegistroEmpleados.Models;
using RegistroEmpleados.Services;

namespace RegistroEmpleados.UnitTest.AppxUnit
{
    public class PuestoServiceTests
    {
        private readonly PuestoService _service;
        private readonly Mock<IPuestoRepository> _mockRepo;

        public PuestoServiceTests()
        {
            _mockRepo = new Mock<IPuestoRepository>();
            _service = new PuestoService(_mockRepo.Object);
        }

        [Fact]
        public async Task CrearPuesto_DeberiaRetornarPuestoCreado()
        {
            // Arrange
            var puesto = new Puesto
            {
                Nombre_Puesto = "Analista de Sistemas",
                Descripcion = "Encargado de analizar y optimizar sistemas informáticos.",
                Salario = 1200.50m,
                Horario = "Lunes a Viernes, 8:00 a 17:00",
                Estado = "Activo"
            };

            _mockRepo.Setup(r => r.CrearAsync(puesto)).ReturnsAsync(puesto);

            // Act
            var resultado = await _service.CrearAsync(puesto);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Analista de Sistemas", resultado.Nombre_Puesto);
        }

        [Fact]
        public async Task ObtenerTodos_DeberiaRetornarLista()
        {
            // Arrange
            _mockRepo.Setup(r => r.ObtenerTodosAsync()).ReturnsAsync(new List<Puesto>());

            // Act
            var resultado = await _service.ObtenerTodosAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.IsType<List<Puesto>>(resultado);
        }

        [Fact]
        public async Task ActualizarPuesto_DeberiaRetornarTrue()
        {
            // Arrange
            var puesto = new Puesto
            {
                Id_Puesto = 1,
                Nombre_Puesto = "Desarrollador Backend",
                Descripcion = "Encargado del desarrollo del lado del servidor.",
                Salario = 1500.00m,
                Horario = "Lunes a Viernes, 9:00 a 18:00",
                Estado = "Activo"
            };

            _mockRepo.Setup(r => r.ActualizarAsync(puesto)).ReturnsAsync(true);

            // Act
            var resultado = await _service.ActualizarAsync(puesto);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public async Task EliminarPuesto_DeberiaRetornarTrue()
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
