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

        public PatController(IPatAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        //https://localhost:44379/api/Pat/1
        [HttpGet("{idpat}")]
        public ModelPatrocinador Get(int idpat)
        {
            return _dataAccessProvider.GetPat(idpat);
        }

        [HttpGet]
        public IEnumerable<ModelPatrocinador> GetAll()
        {
            return _dataAccessProvider.GetPats();
        }
    }
}
