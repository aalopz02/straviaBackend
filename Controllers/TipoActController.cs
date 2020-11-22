using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using straviaBackend.interfaces;
using straviaBackend.models;

namespace straviaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoActController : ControllerBase
    {
        private readonly ITipoActAccessInterface _dataAccessProvider;

        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a tipos de tipos de actividades </param>
        public TipoActController(ITipoActAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        /// <summary>
        /// Get de actividad por id
        /// </summary>
        /// <param name="idact"></param>
        /// <returns> Modelo de la actividad </returns>
        [HttpGet("{idact}")]
        public ModelTipoActividad Get(int idact)
        {
            return _dataAccessProvider.GetActividad(idact);
        }

        /// <summary>
        /// Get de todas las actividades
        /// </summary>
        /// <returns> Lista de las actividades </returns>
        [HttpGet]
        public IEnumerable<ModelTipoActividad> GetAll()
        {
            return _dataAccessProvider.GetActs();
        }
    }
}
