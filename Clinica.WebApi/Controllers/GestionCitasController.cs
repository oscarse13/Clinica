using Clinica.Model.Common;
using Clinica.Repository;
using Clinica.Repository.Repositories;
using Clinica.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Clinica.WebApi.Controllers
{
    //[EnableCors(origins: "http://localhost:9092/#/Gestioncitas", headers: "*", methods: "*")]
    public class GestionCitasController : ApiController
    {
        private readonly ICitaService _citaService;
        private readonly IPacienteService _pacienteService;
        private readonly ITipoCitaService _tipoCitaService;


        public GestionCitasController(ICitaService citaService, IPacienteService pacienteService, ITipoCitaService tipoCitaService)
        {
            _citaService = citaService;
            _pacienteService = pacienteService;
            _tipoCitaService = tipoCitaService;
        }

        [HttpGet]
        [Route("api/GestionCitas/GetCitas")]
        // GET: api/GestionCitas
        public IEnumerable<Cita> GetCitas()
        {
            try
            {
                IEnumerable<Cita> listadoCitas = null;

                listadoCitas = _citaService.GetCitas();
                return listadoCitas;
            }
            catch (Exception ex)
            {
                throw;
            }           
        }

        [HttpGet]
        [Route("api/GestionCitas/GetPaciente/{documento}")]
        // GET: api/GestionCitas/5
        public Paciente GetPaciente(int documento)
        {
            try
            {
                Paciente paciente = null;
                paciente = _pacienteService.GetPacienteByDocumento(documento);
                return paciente;
            }
            catch (Exception ex)
            {
                throw;
            }           
        }


        [HttpPost, HttpPut]
        [Route("api/GestionCitas/RegistrarCita")]
        // POST: api/GestionCitas
        public IHttpActionResult RegistrarCita([FromBody] Cita cita)
        {
            try
            {
                var respuesta = _citaService.RegistrarCita(cita);
                return Ok(respuesta);
            }
            catch (Exception ex )
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/GestionCitas/GetTipoCitas")]
        // GET: api/GestionCitas
        public IEnumerable<TipoCita> GetTipoCitas()
        {
            try
            {
                IEnumerable<TipoCita> listadoTipoCitas = null;

                listadoTipoCitas = _tipoCitaService.GetTipoCitas();
                return listadoTipoCitas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // PUT: api/GestionCitas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("api/GestionCitas/EliminarCita/{id}")]
        // DELETE: api/GestionCitas/5
        public IHttpActionResult Delete(long id)
        {
            try
            {
                _citaService.EliminarCita(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
