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

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a tabla inscripciones por reto</param>
        /// <param name="pats"> Acceso a tabla de patrocinadores por carrera </param>
        /// <param name="cats"> Acceso a tabla de categorias por carreras </param>
        /// <param name="retos"> Acceso a retos </param>
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
        
        /// <summary>
        /// Get para lista de retos para un usuario
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Lista de modelos segun vista de usuario </returns>
        [HttpGet]
        public IEnumerable<ModelRetoView> GET(string username) {
            return _retos.GetRetosForUser(username);
        }

        /// <summary>
        /// Post de inscripcion de reto
        /// </summary>
        /// <param name="nombreReto"></param>
        /// <param name="nombreUsuario"></param>
        [HttpPost]
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
