using Moq;
using RegistroEmpleados.Data;
using RegistroEmpleados.Models;
using RegistroEmpleados.Services;

namespace SR.RegistroEmpleados.UnitTestMSTest
{
    [TestClass]
    public class EmpleadoServiceTests
    {
        private EmpleadoService _service;
        private Mock<IEmpleadoRepository> _mockRepo;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IEmpleadoRepository>();
            _service = new EmpleadoService(_mockRepo.Object);
        }

        [TestMethod]
        public async Task CrearEmpleado_DeberiaRetornarEmpleadoCreado()
        {
           var emp = new Empleado { Nombre = "Ana", Apellido = "López", Correo = "ana@test.com", Id_Puesto = 1, Id_Depto = 1 };
           _mockRepo.Setup(r => r.CrearAsync(emp)).ReturnsAsync(emp);

            var resultado = await _service.CrearAsync(emp);

            Assert.IsNotNull(resultado);
            Assert.AreEqual("Ana", resultado.Nombre);
        }

        [TestMethod]
        public async Task ObtenerTodos_DeberiaRetornarLista()
        {
            _mockRepo.Setup(r => r.ObtenerTodosAsync()).ReturnsAsync(new List<Empleado>());

            var resultado = await _service.ObtenerTodosAsync();

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task ActualizarEmpleado_DeberiaRetornarTrue()
        {
            var emp = new Empleado { Id_Emp = 1, Nombre = "Pedro", Apellido = "Rivas", Correo = "pedro@test.com",
                Id_Puesto = 1, Id_Depto = 1 };
            _mockRepo.Setup(r => r.ActualizarAsync(emp)).ReturnsAsync(true);

            var resultado = await _service.ActualizarAsync(emp);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task EliminarEmpleado_DeberiaRetornarTrue()
        {
            _mockRepo.Setup(r => r.EliminarAsync(1)).ReturnsAsync(true);

            var resultado = await _service.EliminarAsync(1);

            Assert.IsTrue(resultado);
        }
    }
}
