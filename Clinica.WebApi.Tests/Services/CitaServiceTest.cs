using Clinica.Model.Common;
using Clinica.Repository.Repositories;
using Clinica.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica.Repository.Repositories.Fakes;

namespace Clinica.WebApi.Tests.Services
{
    [TestClass]
    public class CitaServiceTest
    {
        private IRepository<Cita> citaRepository;
        private ICitaService citaService;
        private IPacienteService pacienteService;
        private ITipoCitaService tipoCitaService;

        [TestCategory("Unit")]
        [TestMethod]
        public void CitaService_RegistrarCita_NuevaCita_RetornaOk()
        {
            /// Arrange
            Cita cita = new Cita { Id = 0, Fecha = DateTime.Now, PacienteId = 1, TipoCitaId = 1, Paciente = new Paciente { Id = 1, Documento = 123456 } };


            citaRepository = new StubIRepository<Cita> {
                SelectExpressionOfFuncOfT0Boolean = (query) => new List<Cita> { },
                InsertT0 = (entidad) => { }
            };
            
            citaService = new CitaService(citaRepository);

            /// Act
            var result = citaService.RegistrarCita(cita);

            /// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, string.Empty, "La cita se registro correctamente");
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void CitaService_RegistrarCita_CitaExistente_RetornaOk()
        {
            /// Arrange
            Cita cita = new Cita { Id = 1, Fecha = DateTime.Now, PacienteId = 1, TipoCitaId = 1, Paciente = new Paciente { Id = 1, Documento = 123456 } };


            citaRepository = new StubIRepository<Cita>
            {
                UpdateT0 = (entidad) => { }
            };

            citaService = new CitaService(citaRepository);

            /// Act
            var result = citaService.RegistrarCita(cita);

            /// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, string.Empty, "La cita se actualizo correctamente");
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void CitaService_RegistrarCita_ValidacionCitaMismoDia_RetornaValidacion()
        {
            /// Arrange
            Cita cita = new Cita { Id = 0, Fecha = DateTime.Now, PacienteId = 1, TipoCitaId = 1, Paciente = new Paciente { Id = 1, Documento = 123456 } };


            citaRepository = new StubIRepository<Cita>
            {
                SelectExpressionOfFuncOfT0Boolean = (query) => new List<Cita> { new Cita { Id = 1, Fecha = DateTime.Now, PacienteId = 1, TipoCitaId = 1, Paciente = new Paciente { Id = 1, Documento = 123456 } } },
                InsertT0 = (entidad) => { }
            };

            citaService = new CitaService(citaRepository);

            /// Act
            var result = citaService.RegistrarCita(cita);

            /// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, "No se puede crear otra cita para el paciente en el mismo día.", "Se recibe la correcta validación");
        }
    }
}
