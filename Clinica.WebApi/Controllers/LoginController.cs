using Clinica.Model.Common;
using Clinica.Repository;
using Clinica.Repository.Repositories;
using Clinica.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Clinica.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUsuarioService _usuarioService;


        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
;
        }

        [Route("api/Login/Login")]
        [HttpPost]
        public Usuario Login(JObject usuario)
        {

            Usuario usuarioValido = _usuarioService.GetUsuarioByUsuarioContrasena(usuario["correo"].ToString(), usuario["contrasena"].ToString());

            return usuarioValido;
        }


    }
}
