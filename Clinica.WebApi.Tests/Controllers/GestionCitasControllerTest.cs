using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clinica.WebApi.Controllers;
using Clinica.Service;
using Clinica.Service.Fakes;
using Clinica.Model.Common;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Clinica.WebApi.Tests.Controllers
{
    [TestClass]
    public class GestionCitasControllerTest
    {
        ICitaService citaService;
        IPacienteService pacienteService;
        ITipoCitaService tipoCitaService;

        GestionCitasController controller;

        [TestCategory("Unit")]
        [TestMethod]
        public void GestionCitasController_GetCitas_RetornaListaOk()
        {
            /// Arrange

            List<Cita> listaCitas = new List<Cita>();
            listaCitas.Add(new Cita { Id = 1, Fecha = DateTime.Now, PacienteId = 1, TipoCitaId = 1 });
            listaCitas.Add(new Cita { Id = 2, Fecha = DateTime.Now, PacienteId = 1, TipoCitaId = 1 });
            citaService = new StubICitaService
            {
                GetCitas = () => listaCitas
            };

            controller = new GestionCitasController(citaService, pacienteService, tipoCitaService);

            /// Act
            List<Cita> result = (List<Cita>)controller.GetCitas();

            /// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2, "La cantidad de citas obtenidas deben ser 2");
        }

        [TestCategory("Unit")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GestionCitasController_GetCitas_RetornaExcepcion()
        {
            /// Arrange

            citaService = new StubICitaService
            {
                GetCitas = () => { throw new ArgumentNullException(); }
            };

            controller = new GestionCitasController(citaService, pacienteService, tipoCitaService);

            /// Act
            List<Cita> result = (List<Cita>)controller.GetCitas();

            /// Assert
            Assert.IsInstanceOfType(result, typeof(ExceptionResult), "Se debe retornar una excepción");
        }

        [TestCategory("Unit")]
        [TestMethod]        
        public void GestionCitasController_GetPaciente_RetornaPacienteOk()
        {
            /// Arrange

            Paciente paciente = new Paciente { Id = 1, Documento = 123456, Nombre = "Otro Nombre" };
            pacienteService = new StubIPacienteService
            {
                GetPacienteByDocumentoInt32 = (documento) => paciente
            };

            controller = new GestionCitasController(citaService, pacienteService, tipoCitaService);

            /// Act
            Paciente result = controller.GetPaciente(123456);

            /// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Documento, 123456, "El documento del paciente debe ser 123456");
            Assert.AreEqual(result.Nombre, "Otro Nombre", "El nombre del paciente debe ser Otro Nombre");
        }

        [TestCategory("Unit")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GestionCitasController_GetPaciente_RetornaExcepcion()
        {
            /// Arrange

            pacienteService = new StubIPacienteService
            {
                GetPacienteByDocumentoInt32 = (documento) => { throw new ArgumentNullException(); }
            };

            controller = new GestionCitasController(citaService, pacienteService, tipoCitaService);

            /// Act
            Paciente result = controller.GetPaciente(123456);

            /// Assert
            Assert.IsInstanceOfType(result, typeof(ExceptionResult), "Se debe retornar una excepción");
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void GestionCitasController_RegistrarCita_RetornaOk()
        {
            /// Arrange

            Cita cita = new Cita { Id = 1, Fecha = DateTime.Now, PacienteId = 1, TipoCitaId = 1 };
           
            citaService = new StubICitaService
            {
                RegistrarCitaCita = (citaObj) => string.Empty
            };

            controller = new GestionCitasController(citaService, pacienteService, tipoCitaService);

            /// Act
            var result = controller.RegistrarCita(cita) as OkNegotiatedContentResult<string>;

            /// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, string.Empty, "La cita se registro correctamente");
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void GestionCitasController_RegistrarCita_RetornaValidacion()
        {
            /// Arrange

            Cita cita = new Cita { Id = 1, Fecha = DateTime.Now, PacienteId = 1, TipoCitaId = 1 };
            string mensaje = "No se puede registrar la cita";
            citaService = new StubICitaService
            {
                RegistrarCitaCita = (citaObj) => mensaje
            };

            controller = new GestionCitasController(citaService, pacienteService, tipoCitaService);

            /// Act
            var result = controller.RegistrarCita(cita) as OkNegotiatedContentResult<string>;

            /// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, mensaje, "Se debe recibir un mensaje de validación");
        }
    }
}
