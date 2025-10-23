using Moq;
using RegistroEmpleados.DAL.Repositories;
using RegistroEmpleados.Models;
using RegistroEmpleados.Services;

namespace SR.RegistroEmpleados.UnitTestMSTest
{
    [TestClass]
    public class DepartamentoServiceTests
    {
        private DepartamentoService _service;
        private Mock<IDepartamentoRepository> _mockRepo;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IDepartamentoRepository>();
            _service = new DepartamentoService(_mockRepo.Object);
        }

        [TestMethod]
        public async Task CrearDepartamento_DeberiaRetornarDepartamentoCreado()
        {
            var depto = new Departamento
            {
                Nombre_Depto = "Recursos Humanos",
                Descripcion = "Departamento encargado de la gestión del personal",
                Ubicacion = "Edificio A",
                Estado = "Activo"
            };

            _mockRepo.Setup(r => r.CrearAsync(depto)).ReturnsAsync(depto);

            var resultado = await _service.CrearAsync(depto);

            Assert.IsNotNull(resultado);
            Assert.AreEqual("Recursos Humanos", resultado.Nombre_Depto);
        }

        [TestMethod]
        public async Task ObtenerTodos_DeberiaRetornarLista()
        {
            _mockRepo.Setup(r => r.ObtenerTodosAsync()).ReturnsAsync(new List<Departamento>());

            var resultado = await _service.ObtenerTodosAsync();

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task ActualizarDepartamento_DeberiaRetornarTrue()
        {
            var depto = new Departamento
            {
                Id_Depto = 1,
                Nombre_Depto = "Finanzas",
                Descripcion = "Gestión financiera de la empresa",
                Ubicacion = "Edificio B",
                Estado = "Activo"
            };

            _mockRepo.Setup(r => r.ActualizarAsync(depto)).ReturnsAsync(true);

            var resultado = await _service.ActualizarAsync(depto);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task EliminarDepartamento_DeberiaRetornarTrue()
        {
            _mockRepo.Setup(r => r.EliminarAsync(1)).ReturnsAsync(true);

            var resultado = await _service.EliminarAsync(1);

            Assert.IsTrue(resultado);
        }
    }
}
