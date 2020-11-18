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
        //https://localhost:44379/api/Usuario/aalopz01
        [HttpGet("{NombreUsuario}")]
        public ModelUsuario Get(String NombreUsuario)
        {
            return _dataAccessProvider.GetUsuario(NombreUsuario);
        }

        [HttpGet]
        public IEnumerable<ModelUsuario> GetAll(String busqueda)
        {
            return _dataAccessProvider.GetUsuarios(busqueda);
        }

        [HttpPost]
        public void POSTUsuario(String nombreusuario, String password, String fname,
        String mname, String lname, String fechaNacimiento, String nacionalidad)
        {
            ModelUsuario usuario = new ModelUsuario
            {
                nombreusuario = nombreusuario,
                contraseña = password,
                fname = fname,
                mname = mname,
                lname = lname,
                fechanacimiento = fechaNacimiento,
                nacionalidad = nacionalidad,
                nsiguiendo = 0,
                nseguidores = 0
            };

            _dataAccessProvider.AddUsuario(usuario);
        }

    }
}
