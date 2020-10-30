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

        [HttpGet]
        public IEnumerable<ModelUsuario> Get()
        {
            return _dataAccessProvider.GetUsuarios();
        }

        [HttpPost]
        public void POSTUsuario(String nombreusuario, String password, String fname,
        String mname, String lname, String fechaNacimiento, String nacionalidad)
        {
            ModelUsuario usuario = new ModelUsuario
            {
                NombreUsuario = nombreusuario,
                Contraseña = password,
                Fname = fname,
                Mname = mname,
                Lname = lname,
                FechaNacimiento = fechaNacimiento,
                Nacionalidad = nacionalidad,
                Nsiguiendo = 0,
                Nseguidores = 0
            };

            _dataAccessProvider.AddUsuario(usuario);
        }

    }
}
