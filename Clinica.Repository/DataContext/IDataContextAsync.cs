using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.Repository.DataContext
{
    public interface IDataContextAsync : IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(string username);
        int SaveChanges(string username);
    }
}