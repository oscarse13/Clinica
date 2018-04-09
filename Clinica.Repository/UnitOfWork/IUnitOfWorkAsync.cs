using System.Threading;
using System.Threading.Tasks;
using Clinica.Repository.Infrastructure;
using Clinica.Repository.Repositories;
using Clinica.Model;

namespace Clinica.Repository.UnitOfWork
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(string username);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
   
    }
}