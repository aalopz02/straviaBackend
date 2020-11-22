using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using models;
using straviaBackend.interfaces;
using straviaBackend.models;

namespace straviaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguidoresController : ControllerBase
    {
        private readonly ISeguidoresAccess _dataAccessProvider;
        private readonly IUsuarioAccessInterface _userAccess;

        /// <summary>
        /// Contructor de clase
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a tabla de seguidores </param>
        /// <param name="userAccess"> Acceso a tabla de usuarios </param>
        public SeguidoresController(ISeguidoresAccess dataAccessProvider, IUsuarioAccessInterface userAccess)
        {
            _dataAccessProvider = dataAccessProvider;
            _userAccess = userAccess;
        }

        /// <summary>
        /// Post para generar un nuevo seguidor
        /// </summary>
        /// <param name="usuarioaseguir"> Usuario al que se va a seguir </param>
        /// <param name="usuario"> Usuario que va a seguir </param>
        [HttpPost]
        public void Post(string usuarioaseguir, string usuario)
        {
            _dataAccessProvider.AddSeguidor(new ModelSiguiendo()
               {
                   idelemento = usuarioaseguir + usuario,
                    nombreusuariofk = usuario,
                    nombreusuariosiguiendofk = usuarioaseguir
                });
            ModelUsuario siguiendo = _userAccess.GetUsuario(usuarioaseguir);
            siguiendo.nseguidores += 1;
            _userAccess.UpdateUsuario(siguiendo);
            ModelUsuario seguidor = _userAccess.GetUsuario(usuario);
            seguidor.nsiguiendo += 1;
            _userAccess.UpdateUsuario(seguidor);
    
        }

        /// <summary>
        /// Funcion de delete
        /// </summary>
        /// <param name="usuarioaseguir"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteConfirmed(string usuarioaseguir, string usuario)
        {
            try {
                _dataAccessProvider.DeleteSeguidor(usuarioaseguir + usuario);
                ModelUsuario siguiendo = _userAccess.GetUsuario(usuarioaseguir);
                siguiendo.nseguidores -= 1;
                _userAccess.UpdateUsuario(siguiendo);
                ModelUsuario seguidor = _userAccess.GetUsuario(usuario);
                seguidor.nsiguiendo -= 1;
                _userAccess.UpdateUsuario(seguidor);
            } catch (DbUpdateException) { 
            
            }
            
            
            return Ok();
        }

        /// <summary>
        /// Delete de un seguidor
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpGet("{usuario}")]
        public List<ModelUsuario> Details(string usuario)
        {
            return _dataAccessProvider.GetSiguiendo(usuario);
        }

    }
}
