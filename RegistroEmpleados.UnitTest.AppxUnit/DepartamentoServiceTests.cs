using Moq;
using RegistroEmpleados.DAL.Repositories;
using RegistroEmpleados.Models;
using RegistroEmpleados.Services;

namespace RegistroEmpleados.UnitTest.AppxUnit
{
    public class DepartamentoServiceTests
    {
        private readonly DepartamentoService _service;
        private readonly Mock<IDepartamentoRepository> _mockRepo;

        public DepartamentoServiceTests()
        {
            _mockRepo = new Mock<IDepartamentoRepository>();
            _service = new DepartamentoService(_mockRepo.Object);
        }

        [Fact]
        public async Task CrearDepartamento_DeberiaRetornarDepartamentoCreado()
        {
            // Arrange
            var depto = new Departamento
            {
                Nombre_Depto = "Recursos Humanos",
                Descripcion = "Departamento encargado de la gestión del personal",
                Ubicacion = "Edificio A",
                Estado = "Activo"
            };

            _mockRepo.Setup(r => r.CrearAsync(depto)).ReturnsAsync(depto);

            // Act
            var resultado = await _service.CrearAsync(depto);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Recursos Humanos", resultado.Nombre_Depto);
        }

        [Fact]
        public async Task ObtenerTodos_DeberiaRetornarLista()
        {
            // Arrange
            _mockRepo.Setup(r => r.ObtenerTodosAsync()).ReturnsAsync(new List<Departamento>());

            // Act
            var resultado = await _service.ObtenerTodosAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.IsType<List<Departamento>>(resultado);
        }

        [Fact]
        public async Task ActualizarDepartamento_DeberiaRetornarTrue()
        {
            // Arrange
            var depto = new Departamento
            {
                Id_Depto = 1,
                Nombre_Depto = "Finanzas",
                Descripcion = "Gestión financiera de la empresa",
                Ubicacion = "Edificio B",
                Estado = "Activo"
            };

            _mockRepo.Setup(r => r.ActualizarAsync(depto)).ReturnsAsync(true);

            // Act
            var resultado = await _service.ActualizarAsync(depto);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public async Task EliminarDepartamento_DeberiaRetornarTrue()
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
