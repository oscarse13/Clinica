using Clinica.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Clinica.Repository.Repositories
{
    public class RepositoryPaciente : IRepository<Paciente>
    {
        private ClinicaDB ctx = new ClinicaDB();

        public void Delete(Paciente entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Paciente Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public void Insert(Paciente entity)
        {
            ctx.Paciente.Add(entity);
            ctx.SaveChanges();
        }

        public void InsertGraphRange(IEnumerable<Paciente> entities)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdateGraph(Paciente entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<Paciente> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<Paciente> Query()
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<Paciente> Query(Expression<Func<Paciente, bool>> query)
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<Paciente> Query(IQueryObject<Paciente> queryObject)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Paciente> Queryable()
        {
            return ctx.Paciente;
        }

        public IEnumerable<Paciente> Select(Expression<Func<Paciente, bool>> query)
        {
            return ctx.Paciente.Where(query);
        }

        public IQueryable<Paciente> SelectQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Paciente entity)
        {
            ctx.Paciente.Add(entity);
            ctx.SaveChanges();
        }

        IRepository<T> IRepository<Paciente>.GetRepository<T>()
        {
            throw new NotImplementedException();
        }
    }
}
