using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using models;
using straviaBackend.interfaces;
using straviaBackend.models;

namespace straviaBackend.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class InscripcionesRetoController : ControllerBase
    {
        private readonly IInscripcionRetoAccessInterface _dataAccessProvider;
        private readonly IPatrociandorporCarreraAccessInterface _pats;
        private readonly ICategoriasporCarreraAccessInterface _cats;
        private readonly IRetoAccessInterface _retos;

        public InscripcionesRetoController(IInscripcionRetoAccessInterface dataAccessProvider,
                                    IPatrociandorporCarreraAccessInterface pats,
                                    ICategoriasporCarreraAccessInterface cats,
                                    IRetoAccessInterface retos)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            _cats = cats;
            _retos = retos;
        }
        //https://localhost:44379/api/InscripcionesReto?username=aalopz02
        [HttpGet]
        public IEnumerable<ModelRetoView> GET(string username) {
            return _retos.GetRetosForUser(username);
        }

        //https://localhost:44379/api/InscripcionesReto?nombreCarrera=lacarrera&nombreUsuario=nombre
        [HttpPost]//String nombreReto,String nombreUsuario
        public void AddInscripcionReto(String nombreReto, String nombreUsuario)
        {
            ModelInscripcionReto inscripcionreto = new ModelInscripcionReto
            {
               nombreusuario=nombreUsuario,
               nombrereto=nombreReto,
               idinsret=nombreReto+nombreUsuario
            };
            _dataAccessProvider.AddInscripcionReto(inscripcionreto);

        }

      
    }
}
