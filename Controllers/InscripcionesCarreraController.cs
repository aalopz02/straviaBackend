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
using straviaBackend.mist;

namespace straviaBackend.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class InscripcionesCarreraController : ControllerBase
    {
        private readonly IInscripcionCarreraAccessInterface _dataAccessProvider;
        private readonly IPatrociandorporCarreraAccessInterface _pats;
        private readonly ICategoriasporCarreraAccessInterface _cats;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a inscripciones por carrera</param>
        /// <param name="pats"> Acceso a patrocinadores por carrera </param>
        /// <param name="cats"> Acceso a categorias por carrera</param>
        public InscripcionesCarreraController(IInscripcionCarreraAccessInterface dataAccessProvider,
                                    IPatrociandorporCarreraAccessInterface pats,
                                    ICategoriasporCarreraAccessInterface cats)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            _cats = cats;
        }

        /// <summary>
        /// Post para una nueva inscripcion
        /// </summary>
        /// <param name="nombreCarrera"></param>
        /// <param name="nombreUsuario"></param>
        /// <param name="img"> Json con la imagen en h64</param>
        [HttpPost]
        public void AddInscripcionCarrera(String nombreCarrera, String nombreUsuario, [FromBody] FileModel img)
        {
            ModelInscripcionCarrera inscripcioncarrera = new ModelInscripcionCarrera
            {
                nombrecarrera = nombreCarrera,
                nombreusuario =nombreUsuario,
                idinscar= nombreCarrera+nombreUsuario,
                recibo = mist.ProcessSaveFiles.SaveRecibo(img, nombreCarrera + nombreUsuario + "recibo")
            };
            _dataAccessProvider.AddInscripcionCarrera(inscripcioncarrera);
  
        }

    }
}
