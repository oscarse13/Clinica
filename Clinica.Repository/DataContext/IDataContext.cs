using System;
using Clinica.Model;

namespace Clinica.Repository.DataContext
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
    }
}