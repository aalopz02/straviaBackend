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
    public class RetosController : ControllerBase
    {
        private readonly IRetoAccessInterface _dataAccessProvider;
        private readonly IPatrociandorporCarreraAccessInterface _pats;
        private readonly ICategoriasporCarreraAccessInterface _cats;

        public RetosController(IRetoAccessInterface dataAccessProvider,
                                    IPatrociandorporCarreraAccessInterface pats,
                                    ICategoriasporCarreraAccessInterface cats)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            _cats = cats;
    }

        [HttpGet]
        public IEnumerable<ModelReto> Get()
        {
            return _dataAccessProvider.GetRetos();
        }


        //https://localhost:44379/api/Retos?nombreReto=reto1&d1=03/12/1998&d2=05/10/2020&Tipo=Nadar&tipoR=fondo&Privacidad=publico
        [HttpPost] //String nombreReto, DateTime d1, DateTime d2, int Tipo, String Privacidad)
        public void AddReto(String nombreReto, DateTime d1, DateTime d2, int Tipo,int tipoR, String Privacidad)
        {
            ModelReto reto = new ModelReto
            {
                nombrereto = nombreReto,
                periodo_inicio = d1,
                periodo_final = d2,
                tiporeto = Tipo,
                tipo=tipoR,
                privacidad = Privacidad
        
            };
            _dataAccessProvider.AddReto(reto);
        }

        [HttpGet("{nombreReto}")]
        public ModelReto Details(string nombreReto)
        {
            return _dataAccessProvider.GetReto(nombreReto);
        }

        [HttpPut]
        public IActionResult Edit(String nombreReto, DateTime d1, DateTime d2, int Tipo, int tipoR, String Privacidad) 
        {
            if (ModelState.IsValid)
            {
                ModelReto reto = new ModelReto
                {
                    nombrereto = nombreReto,
                    periodo_inicio = d1,
                    periodo_final = d2,
                    tiporeto = Tipo,
                    tipo=tipoR,
                    privacidad = Privacidad
                };
                _dataAccessProvider.UpdateReto(reto);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{nombreReto}")]
        public IActionResult DeleteConfirmed(string nombreReto)
        {
            var data = _dataAccessProvider.GetReto(nombreReto);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteReto(nombreReto);
            return Ok();
        }
    }
}
