using Clinica.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Clinica.Repository.Repositories
{
    public class RepositoryTipoCita : IRepository<TipoCita>
    {
        private ClinicaDB ctx = new ClinicaDB();
        public void Delete(TipoCita entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public TipoCita Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public void Insert(TipoCita entity)
        {
            throw new NotImplementedException();
        }

        public void InsertGraphRange(IEnumerable<TipoCita> entities)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdateGraph(TipoCita entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<TipoCita> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<TipoCita> Query()
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<TipoCita> Query(Expression<Func<TipoCita, bool>> query)
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<TipoCita> Query(IQueryObject<TipoCita> queryObject)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TipoCita> Queryable()
        {
            return ctx.TipoCita;
        }

        public IEnumerable<TipoCita> Select(Expression<Func<TipoCita, bool>> query)
        {
            return ctx.TipoCita.Where(query);
        }

        public IQueryable<TipoCita> SelectQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoCita entity)
        {
            throw new NotImplementedException();
        }

        IRepository<T> IRepository<TipoCita>.GetRepository<T>()
        {
            throw new NotImplementedException();
        }
    }
}
