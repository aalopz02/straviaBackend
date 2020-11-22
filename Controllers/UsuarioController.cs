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

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a la tabla de usuarios </param>
        /// <param name="actividadAccess"> Acceso a tabla de actividades </param>
        public UsuarioController(IUsuarioAccessInterface dataAccessProvider,
                                    IActividadAccess actividadAccess)
        {
            _dataAccessProvider = dataAccessProvider;
            _actividadAccess = actividadAccess;
        }

        /// <summary>
        /// Obtener un usuario por nombre de usuario
        /// </summary>
        /// <param name="nombreusuario"></param>
        /// <returns> Modelo del usuario </returns>
        [HttpGet("{nombreusuario}")]
        public ModelUsuario GetUsuario(string nombreusuario)
        {
            return _dataAccessProvider.GetUsuario(nombreusuario);
        }

        /// <summary>
        /// List de modelos para la busqueda de usuarios 
        /// </summary>
        /// <param name="busqueda"> String dobre el cual se va a buscar </param>
        /// <param name="usuario"> Usuario que busca </param>
        /// <returns> Lista con los usuarios con la perspectiva de un usuario </returns>
        [HttpGet]
        public IEnumerable<ModelSearchUserView> GetAll(String busqueda, String usuario)
        {
            return _dataAccessProvider.GetUsuarios(busqueda, usuario);
        }


        /// <summary>
        /// Verificar el login de un usuario
        /// </summary>
        /// <param name="data"></param>
        /// <returns> Bool si cumple el login </returns>
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

        /// <summary>
        /// Post de un nuevo usuario
        /// </summary>
        /// <param name="nombreusuario"></param>
        /// <param name="password"></param>
        /// <param name="fname"></param>
        /// <param name="mname"></param>
        /// <param name="lname"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="img"> Json con la imagen en string h64 </param>
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

        /// <summary>
        /// Modificar un usuario
        /// </summary>
        /// <param name="nombreusuario"></param>
        /// <param name="password"></param>
        /// <param name="fname"></param>
        /// <param name="mname"></param>
        /// <param name="lname"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="img"> Json con la imagen en string h64 </param>
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
