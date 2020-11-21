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
        private readonly IPatrociandorporRetoAccessInterface _pats;
       

        public RetosController(IRetoAccessInterface dataAccessProvider,
                                    IPatrociandorporRetoAccessInterface pats)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            
    }

        [HttpGet]
        public IEnumerable<ModelReto> Get()
        {
            return _dataAccessProvider.GetRetos();
        }


        //https://localhost:44379/api/Retos?nombreReto=reto1&d1=03/12/1998&d2=05/10/2020&Tipoact=1&tipo=fondo&Privacidad=publico&patrocinadores=1.2
        [HttpPost] //String nombreReto, DateTime d1, DateTime d2, int Tipo, String Privacidad)
        public void AddReto(String nombreReto, DateTime d1, DateTime d2, int Tipoact,String tipo, String Privacidad, String patrocinadores)
        {
            ModelReto reto = new ModelReto
            {
                nombrereto = nombreReto,
                periodo_inicio = d1,
                periodo_final = d2,
                tipoact = Tipoact,
                tipo=tipo,
                privacidad = Privacidad
        
            };
            
            _dataAccessProvider.AddReto(reto);


            foreach (string idpatrocinador in patrocinadores.Split("."))
            {
                _pats.AddPatReto(new models.Modelpatrocinadoresporreto
                {
                    idelementoreto = reto.nombrereto + idpatrocinador,
                    patrocinador = int.Parse(idpatrocinador),
                    nombreretofk = reto.nombrereto
                });
            }
        }

        [HttpGet("{nombreReto}")]
        public ModelReto Details(string nombreReto)
        {
            return _dataAccessProvider.GetReto(nombreReto);
        }

        [HttpPut]
        public IActionResult Edit(String nombreReto, DateTime d1, DateTime d2, int Tipoact, String tipo, String Privacidad, String patrocinadores) 
        {
            ModelReto old = _dataAccessProvider.GetReto(nombreReto);
            int tipoactnew = 0;
                if (Tipoact == 0)
                {
                    tipoactnew = old.tipoact;
                }
                else {
                    tipoactnew = Tipoact;
                }
                ModelReto reto = new ModelReto
                {
                    nombrereto = nombreReto,
                    periodo_inicio = d1,
                    periodo_final = d2,
                    tipoact = tipoactnew,
                    tipo= tipo,
                    privacidad = Privacidad
                };
                if (patrocinadores != null) {
                    foreach (string idpatrocinador in patrocinadores.Split("."))
                    {
                        _pats.UpdateReto(new models.Modelpatrocinadoresporreto
                        {
                            idelementoreto = reto.nombrereto + idpatrocinador,
                            patrocinador = int.Parse(idpatrocinador),
                            nombreretofk = reto.nombrereto
                        });
                    }
                }
                
                _dataAccessProvider.UpdateReto(reto,old);
                return Ok();

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
