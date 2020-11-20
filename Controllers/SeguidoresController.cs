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
            try{
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
            } catch (DbUpdateException e) {
                _dataAccessProvider.DeleteSeguidor(usuarioaseguir + usuario);
                int x = 0;
                ModelUsuario siguiendo = _userAccess.GetUsuario(usuarioaseguir);
                siguiendo.nseguidores -= 1;
                _userAccess.UpdateUsuario(siguiendo);
                ModelUsuario seguidor = _userAccess.GetUsuario(usuario);
                seguidor.nsiguiendo -= 1;
                _userAccess.UpdateUsuario(seguidor);
            }
    
        }

        [HttpDelete("{idelemento}")]
        public IActionResult DeleteConfirmed(string usuario)
        {
            var data = _dataAccessProvider.Getelemento(usuario);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteSeguidor(data.idelemento);
            return Ok();
            //aca tambien tiene que decrementar el conteo para ambos
        }

        [HttpGet("{usuario}")]
        public List<ModelUsuario> Details(string usuario)
        {
            return _dataAccessProvider.GetSiguiendo(usuario);
        }

    }
}
