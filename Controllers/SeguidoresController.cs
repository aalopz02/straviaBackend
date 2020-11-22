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

        public SeguidoresController(ISeguidoresAccess dataAccessProvider, IUsuarioAccessInterface userAccess)
        {
            _dataAccessProvider = dataAccessProvider;
            _userAccess = userAccess;
        }

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

        [HttpGet("{usuario}")]
        public List<ModelUsuario> Details(string usuario)
        {
            return _dataAccessProvider.GetSiguiendo(usuario);
        }

    }
}
