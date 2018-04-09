using Clinica.Model.Common;
using Clinica.Repository.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Service
{
    public interface IPacienteService : IService<Paciente>
    {
        IEnumerable<Paciente> GetPacientes();
        Paciente GetPacienteByID(long pacienteId);
        void RegistrarPaciente(Paciente paciente);
        Paciente GetPacienteByDocumento(int documento);
    }

    public class PacienteService : Service<Paciente>, IPacienteService
    {
        readonly IRepository<Paciente> repository;

        public PacienteService(IRepository<Paciente> repository) : base(repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Paciente> GetPacientes()
        {
            return repository.Queryable();
        }

        public Paciente GetPacienteByID(long pacienteId)
        {
            return repository.Select(x => x.Id.Equals(pacienteId)).FirstOrDefault();
        }

        public Paciente GetPacienteByDocumento(int documento)
        {
            return repository.Select(x => x.Documento.Equals(documento)).FirstOrDefault();
        }

        public void RegistrarPaciente(Paciente paciente)
        {
            repository.Insert(paciente);
        }
    }
}
