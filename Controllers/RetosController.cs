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
    public class RetosController : ControllerBase
    {
        private readonly IRetoAccessInterface _dataAccessProvider;
        private readonly IPatrociandorporRetoAccessInterface _pats;
       
        /// <summary>
        /// Cosntructor de la clase
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a retos</param>
        /// <param name="pats"> Acceso a patrocinadores </param>
        public RetosController(IRetoAccessInterface dataAccessProvider,
                                    IPatrociandorporRetoAccessInterface pats)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            
    }

        /// <summary>
        /// Obtener lista de retos
        /// </summary>
        /// <returns> Lista con modelos de retos </returns>
        [HttpGet]
        public IEnumerable<ModelReto> Get()
        {
            return _dataAccessProvider.GetRetos();
        }

        /// <summary>
        /// Lista de modelos segun vista usuario
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns> Lista con los modelos segun la vista de un usuario </returns>
        [HttpGet("busqueda/{nombreUsuario}")]
        public IEnumerable<ModelRetoView> Get(string nombreUsuario)
        {
            return _dataAccessProvider.GetRetosForUser(nombreUsuario);
        }

        /// <summary>
        /// Post de nuevo reto
        /// </summary>
        /// <param name="nombreReto"></param>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <param name="Tipoact"></param>
        /// <param name="tipo"></param>
        /// <param name="Privacidad"></param>
        /// <param name="patrocinadores"></param>
        [HttpPost]
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

        /// <summary>
        /// Get de modelo por reto
        /// </summary>
        /// <param name="nombreReto"></param>
        /// <returns> Modelo del reto  </returns>
        [HttpGet("{nombreReto}")]
        public ModelReto Details(string nombreReto)
        {
            return _dataAccessProvider.GetReto(nombreReto);
        }

        /// <summary>
        /// Update de reto
        /// </summary>
        /// <param name="nombreReto"></param>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <param name="Tipoact"></param>
        /// <param name="tipo"></param>
        /// <param name="Privacidad"></param>
        /// <param name="patrocinadores"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete de reto
        /// </summary>
        /// <param name="nombreReto"></param>
        /// <returns></returns>
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
