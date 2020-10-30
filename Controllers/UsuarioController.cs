using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using models;
using straviaBackend.interfaces;


namespace straviaBackend.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAccessInterface _dataAccessProvider;

        public UsuarioController(IUsuarioAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        /*[HttpGet]
        public IEnumerable<ModelUsuario> Get()
        {
            return _dataAccessProvider.A;
        }*/

        [HttpPost]
        public void POSTUsuario(String nombreusuario, String password, String fname,
        String mname, String lname, String fechaNacimiento, String nacionalidad, int nsiguiendo, int nseguidores)
        {
            ModelUsuario usuario = new ModelUsuario();
            usuario.NombreUsuario = nombreusuario;
            usuario.Contraseña = password;
            usuario.Fname = fname;
            usuario.Mname = mname;
            usuario.Lname = lname;
            usuario.FechaNacimiento = fechaNacimiento;
            usuario.Nacionalidad = nacionalidad;
            usuario.Nsiguiendo = nsiguiendo;
            usuario.Nseguidores = nseguidores;

            _dataAccessProvider.AddUsuario(usuario);
        }

    }
}
