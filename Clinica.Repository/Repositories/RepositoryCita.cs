using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Clinica.Model.Common;

namespace Clinica.Repository.Repositories
{
    public class RepositoryCita : IRepository<Cita>
    {
        private ClinicaDB ctx = new ClinicaDB();
        public void Delete(Cita entity)
        {
            ctx.Cita.Remove(entity);
            ctx.SaveChanges();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Cita Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cita entity)
        {
            ctx.Cita.Add(entity);
            ctx.SaveChanges();
        }

        public void InsertGraphRange(IEnumerable<Cita> entities)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdateGraph(Cita entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<Cita> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<Cita> Query()
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<Cita> Query(Expression<Func<Cita, bool>> query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cita> Select(Expression<Func<Cita, bool>> query)
        {
            return ctx.Cita.Include("Paciente").Include("TipoCita").Where(query);
        }

        public IQueryFluent<Cita> Query(IQueryObject<Cita> queryObject)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Cita> Queryable()
        {
            return ctx.Cita.Include("Paciente").Include("TipoCita");
        }

        public IQueryable<Cita> SelectQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Cita entity)
        {
            var cita = ctx.Cita.Find(entity.Id);
            if (cita != null)
            {
                cita.PacienteId = entity.PacienteId;
                cita.Fecha = entity.Fecha;
                cita.TipoCitaId = entity.TipoCitaId;
                ctx.SaveChanges();
            }
            
        }

        IRepository<T> IRepository<Cita>.GetRepository<T>()
        {
            throw new NotImplementedException();
        }
    }
}
