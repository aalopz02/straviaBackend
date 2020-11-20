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

        public GruposUserController(IGrupoAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<ModelGrupoView> Get(string username)
        {
            return _dataAccessProvider.GetGruposForUser(username);
        }

    }
}
