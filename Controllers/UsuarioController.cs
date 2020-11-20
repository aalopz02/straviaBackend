using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using models;
using straviaBackend.interfaces;
using straviaBackend.mist;
using straviaBackend.models;

namespace straviaBackend.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAccessInterface _dataAccessProvider;
        private readonly IActividadAccess _actividadAccess;

        public UsuarioController(IUsuarioAccessInterface dataAccessProvider,
                                    IActividadAccess actividadAccess)
        {
            _dataAccessProvider = dataAccessProvider;
            _actividadAccess = actividadAccess;
        }

        //https://localhost:44379/api/Usuario/aalopz01

        [HttpGet("{nombreusuario}")]
        public ModelUsuario GetUsuario(string nombreusuario)
        {
            return _dataAccessProvider.GetUsuario(nombreusuario);
        }

        [HttpGet]
        public IEnumerable<ModelSearchUserView> GetAll(String busqueda, String usuario)
        {
            return _dataAccessProvider.GetUsuarios(busqueda, usuario);
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

        [HttpPost]
        public void POSTUsuario(String nombreusuario, String password, String fname,
        String mname, String lname, String fechaNacimiento, String nacionalidad, [FromBody] FileModel img)
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
                nseguidores = 0,
                imagenperfil = ProcessSaveFiles.saveImg(img, nombreusuario)
        };
            _dataAccessProvider.AddUsuario(usuario);
        }

        [HttpPatch]
        public void ModUser(String nombreusuario, String password, String fname,
       String mname, String lname, String nacionalidad, [FromBody] FileModel img)
        {
            ModelUsuario usuario;
            String clave;
            ModelUsuario old = _dataAccessProvider.GetUsuario(nombreusuario);
            if (password.Equals("null"))
            {
                clave = old.contraseña;
            }
            else {
                clave = password;
            }
            if (!img.file.Equals("null"))
            {
                usuario = new ModelUsuario
                {
                    nombreusuario = old.nombreusuario,
                    contraseña = clave,
                    fname = fname,
                    mname = mname,
                    lname = lname,
                    nacionalidad = nacionalidad,
                    nsiguiendo = old.nsiguiendo,
                    nseguidores = old.nseguidores,
                    fechanacimiento = old.fechanacimiento,
                    imagenperfil = ProcessSaveFiles.saveImg(img, nombreusuario)
                };
            }
            else {
                usuario = new ModelUsuario
                {
                    nombreusuario = old.nombreusuario,
                    contraseña = clave,
                    fname = fname,
                    mname = mname,
                    lname = lname,
                    nacionalidad = nacionalidad,
                    nsiguiendo = old.nsiguiendo,
                    nseguidores = old.nseguidores,
                    imagenperfil = old.imagenperfil,
                    fechanacimiento = old.fechanacimiento,
                };
            }
            _dataAccessProvider.UpdateUsuario(usuario,old);
        }
    }
}
