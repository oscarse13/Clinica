using Clinica.Model.Common;
using Clinica.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Service
{
    public interface IUsuarioService : IService<Usuario>
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioByID(long UsuarioId);
        Usuario GetUsuarioByUsuarioContrasena(string correo, string contrasena);
    }

    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        readonly IRepository<Usuario> repository;

        public UsuarioService(IRepository<Usuario> repository) : base(repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return repository.Queryable();
        }

        public Usuario GetUsuarioByID(long UsuarioId)
        {
            return repository.Select(x => x.Id.Equals(UsuarioId)).FirstOrDefault();
        }

        public Usuario GetUsuarioByUsuarioContrasena(string correo, string contrasena)
        {
            return repository.Select(x => x.Correo == correo && x.Contrasena == contrasena).FirstOrDefault();
        }

    }
}
