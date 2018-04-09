using Clinica.Model.Common;
using Clinica.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Service
{
    public interface ICitaService : IService<Cita>
    {
        IEnumerable<Cita> GetCitas();
        Cita GetCitaByID(long citaId);
        Cita GetCitaByUsuarioId(long pacienteId);
        string RegistrarCita(Cita cita);
        void EliminarCita(long id);
    }

    public class CitaService : Service<Cita>, ICitaService
    {
        readonly IRepository<Cita> repository;
        const string validacionCita = "No se puede crear otra cita para el paciente en el mismo día.";


        public CitaService(IRepository<Cita> repository) : base(repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Cita> GetCitas()
        {
            return repository.Queryable();
        }

        public IEnumerable<Cita> GetCitasByUsuarioDocumento(int documento)
        {
            return repository.Select(x => x.Paciente.Documento.Equals(documento));
        }

        //public IEnumerable<Cita> GetCitasByFecha(DateTime fecha)
        //{
        //    return repository.Query(x => x.Fecha.Equals(fecha)).Select();
        //}

        public Cita GetCitaByID(long citaId)
        {
            return repository.Select(x => x.Id.Equals(citaId)).FirstOrDefault();
        }

        public Cita GetCitaByUsuarioId(long pacienteId)
        {
            return repository.Select(x => x.PacienteId.Equals(pacienteId)).FirstOrDefault();
        }

        public string RegistrarCita(Cita cita)
        {
            string respuesta = string.Empty;
            if (cita.Id > 0)
            {
                if (cita.Paciente.Id > 0)
                {
                    cita.Paciente = null;
                }

                cita.TipoCita = null;
                repository.Update(cita);
            }
            else
            {
                var citasUsuario = GetCitasByUsuarioDocumento(cita.Paciente.Documento);
                if (!citasUsuario.Where(x => x.Fecha.ToShortDateString() == cita.Fecha.ToShortDateString()).Any())
                {
                    if (cita.Paciente.Id > 0)
                    {
                        cita.Paciente = null;
                    }

                    cita.TipoCita = null;
                    repository.Insert(cita);
                }
                else
                    respuesta = validacionCita;
            }

            return respuesta;
        }

        public void EliminarCita(long id)
        {
            var citaUsuario = GetCitaByID(id);
            if (citaUsuario != null)
            {
                repository.Delete(citaUsuario);
            }
        }
    }
}
