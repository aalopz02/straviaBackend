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

namespace straviaBackend.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class InscripcionesCarreraController : ControllerBase
    {
        private readonly IInscripcionCarreraAccessInterface _dataAccessProvider;
        private readonly IPatrociandorporCarreraAccessInterface _pats;
        private readonly ICategoriasporCarreraAccessInterface _cats;

        public InscripcionesCarreraController(IInscripcionCarreraAccessInterface dataAccessProvider,
                                    IPatrociandorporCarreraAccessInterface pats,
                                    ICategoriasporCarreraAccessInterface cats)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            _cats = cats;
        }

        //https://localhost:44379/api/InscripcionCarrera?nombreCarrera=lacarrera&nombreUsuario=nombre
        [HttpPost]//String nombreCarrera,String nombreUsuario
        public void AddInscripcionCarrera(String nombreCarrera, String nombreUsuario)
        {
            ModelInscripcionCarrera inscripcioncarrera = new ModelInscripcionCarrera
            {
                nombrecarrera = nombreCarrera,
                nombreusuario =nombreUsuario,
                idinscar= nombreCarrera+nombreUsuario
            };
            _dataAccessProvider.AddInscripcionCarrera(inscripcioncarrera);
  
        }

    }
}
