using System;
using System.Data;
using Clinica.Repository.Infrastructure;
using Clinica.Repository.Repositories;
using Clinica.Model;

namespace Clinica.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        int SaveChanges(string username);
        void Dispose(bool disposing);
        Repositories.IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}