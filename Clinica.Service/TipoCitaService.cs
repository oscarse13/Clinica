using Clinica.Model.Common;
using Clinica.Repository.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Service
{
    public interface ITipoCitaService : IService<TipoCita>
    {
        IEnumerable<TipoCita> GetTipoCitas();
        TipoCita GetTipoCitaByID(long tipoCitaId);
    }

    public class TipoCitaService : Service<TipoCita>, ITipoCitaService
    {
        readonly IRepository<TipoCita> repository;

        public TipoCitaService(IRepository<TipoCita> repository) : base(repository)
        {
            this.repository = repository;
        }

        public IEnumerable<TipoCita> GetTipoCitas()
        {
            return repository.Queryable();
        }

        public TipoCita GetTipoCitaByID(long tipoCitaId)
        {
            return repository.Select(x => x.Id.Equals(tipoCitaId)).FirstOrDefault();
        }

    }
}
