using Clinica.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Repository.Repositories
{
    public class RepositoryUsuario : IRepository<Usuario>
    {
        private ClinicaDB ctx = new ClinicaDB();

        public void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Usuario Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public void Insert(Usuario entity)
        {
            ctx.Usuario.Add(entity);
            ctx.SaveChanges();
        }

        public void InsertGraphRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdateGraph(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<Usuario> Query()
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<Usuario> Query(Expression<Func<Usuario, bool>> query)
        {
            throw new NotImplementedException();
        }

        public IQueryFluent<Usuario> Query(IQueryObject<Usuario> queryObject)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Usuario> Queryable()
        {
            return ctx.Usuario;
        }

        public IEnumerable<Usuario> Select(Expression<Func<Usuario, bool>> query)
        {
            return ctx.Usuario.Where(query);
        }

        public IQueryable<Usuario> SelectQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario entity)
        {
            ctx.Usuario.Add(entity);
            ctx.SaveChanges();
        }

        IRepository<T> IRepository<Usuario>.GetRepository<T>()
        {
            throw new NotImplementedException();
        }
    }
}
