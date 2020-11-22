using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using straviaBackend.interfaces;
using straviaBackend.models;

namespace straviaBackend.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class GruposUserController : ControllerBase
    {
        private readonly IGrupoAccessInterface _dataAccessProvider;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a tabla grupos </param>
        public GruposUserController(IGrupoAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        /// <summary>
        /// Get de modelos para un usuario
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Lista de grupos segun vista de un usuarios</returns>
        [HttpGet]
        public IEnumerable<ModelGrupoView> Get(string username)
        {
            return _dataAccessProvider.GetGruposForUser(username);
        }

    }
}
