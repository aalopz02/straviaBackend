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

        [HttpGet("{nombreusuario}")]
        public ModelUsuario GetUsuario(string nombreusuario)
        {
            return _dataAccessProvider.GetUsuario(nombreusuario);
        }

        [HttpPost("CheckUsuario")]
        
        public bool CheckUsuario([FromBody] UserLoginModel data)
        {
            
            if(data.nombreusuario != null){
                var usuario = _dataAccessProvider.GetUsuario(data.nombreusuario);
                
                if(usuario.contraseña == data.contraseña){
                    Console.WriteLine("Alooooooooo");
                    return true;
                }else{
                    return false;
                }
            }else{
                return false;
            }
        }
        /*
        [HttpGet]
        public IEnumerable<ModelUsuario> Get()
        {
            return _dataAccessProvider.GetUsuarios();
        }
        */
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
