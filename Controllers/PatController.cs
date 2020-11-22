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
    public class PatController : ControllerBase
    {
        private readonly IPatAccessInterface _dataAccessProvider;

        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a tabla de patrocinadores</param>
        public PatController(IPatAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        /// <summary>
        /// Get de patrocinadores
        /// </summary>
        /// <param name="idpat"></param>
        /// <returns> Modelo de patrocinador por id </returns>
        [HttpGet("{idpat}")]
        public ModelPatrocinador Get(int idpat)
        {
            return _dataAccessProvider.GetPat(idpat);
        }

        /// <summary>
        /// Get de lista patrocinadores 
        /// </summary>
        /// <returns> Modelos de patrocinadores </returns>
        [HttpGet]
        public IEnumerable<ModelPatrocinador> GetAll()
        {
            return _dataAccessProvider.GetPats();
        }
    }
}
