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
    public class CatController : ControllerBase
    {
        private readonly ICatAccessInterface _dataAccessProvider;

        public CatController(ICatAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        
        /// <summary>
        /// Get para una categoria
        /// </summary>
        /// <param name="idcat"></param>
        /// <returns>Modelo de la categoria</returns>
        [HttpGet("{idcat}")]
        public ModelCategoria Get(int idcat)
        {
            return _dataAccessProvider.GetCat(idcat);
        }

        /// <summary>
        /// Lista de dategorias
        /// </summary>
        /// <returns>Lista con todos lo modelos de las categorias</returns>
        [HttpGet]
        public IEnumerable<ModelCategoria> GetAll()
        {
            return _dataAccessProvider.GetCats();
        }
    }
}
