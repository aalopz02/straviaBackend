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

        public TipoActController(ITipoActAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        //https://localhost:44379/api/TipoAct/1
        [HttpGet("{idact}")]
        public ModelTipoActividad Get(int idact)
        {
            return _dataAccessProvider.GetActividad(idact);
        }

        [HttpGet]
        public IEnumerable<ModelTipoActividad> GetAll()
        {
            return _dataAccessProvider.GetActs();
        }
    }
}
