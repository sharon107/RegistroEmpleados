using Moq;
using RegistroEmpleados.DAL.Repositories;
using RegistroEmpleados.Models;
using RegistroEmpleados.Services;

namespace SR.RegistroEmpleados.UnitTestMSTest
{
    [TestClass]
    public class PuestoServiceTests
    {
        private PuestoService _service;
        private Mock<IPuestoRepository> _mockRepo;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IPuestoRepository>();
            _service = new PuestoService(_mockRepo.Object);
        }

        [TestMethod]
        public async Task CrearPuesto_DeberiaRetornarPuestoCreado()
        {
            var puesto = new Puesto
            {
                Nombre_Puesto = "Analista de Sistemas",
                Descripcion = "Encargado de analizar y optimizar sistemas informáticos.",
                Salario = 1200.50m,
                Horario = "Lunes a Viernes, 8:00 a 17:00",
                Estado = "Activo"
            };

            _mockRepo.Setup(r => r.CrearAsync(puesto)).ReturnsAsync(puesto);

            var resultado = await _service.CrearAsync(puesto);

            Assert.IsNotNull(resultado);
            Assert.AreEqual("Analista de Sistemas", resultado.Nombre_Puesto);
        }

        [TestMethod]
        public async Task ObtenerTodos_DeberiaRetornarLista()
        {
            _mockRepo.Setup(r => r.ObtenerTodosAsync()).ReturnsAsync(new List<Puesto>());

            var resultado = await _service.ObtenerTodosAsync();

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task ActualizarPuesto_DeberiaRetornarTrue()
        {
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

            var resultado = await _service.ActualizarAsync(puesto);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task EliminarPuesto_DeberiaRetornarTrue()
        {
            _mockRepo.Setup(r => r.EliminarAsync(1)).ReturnsAsync(true);

            var resultado = await _service.EliminarAsync(1);

            Assert.IsTrue(resultado);
        }
    }
}
