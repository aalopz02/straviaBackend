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
    public class InscripcionesRetoController : ControllerBase
    {
        private readonly IInscripcionRetoAccessInterface _dataAccessProvider;
        private readonly IPatrociandorporCarreraAccessInterface _pats;
        private readonly ICategoriasporCarreraAccessInterface _cats;

        public InscripcionesRetoController(IInscripcionRetoAccessInterface dataAccessProvider,
                                    IPatrociandorporCarreraAccessInterface pats,
                                    ICategoriasporCarreraAccessInterface cats)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            _cats = cats;
    }


        //https://localhost:44379/api/InscripcionReto?nombreCarrera=lacarrera&nombreUsuario=nombre
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
