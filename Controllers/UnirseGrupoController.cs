using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using straviaBackend.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class UnirseGrupoController : ControllerBase
    {
        private readonly IUnionGrupoAccessInterface _dataAccessProvider;

        public UnirseGrupoController(IUnionGrupoAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpPost]
        public void Post(string username, string namegrupo) {
            _dataAccessProvider.AddUnion(new models.ModelUnionUsuarioGrupo { 
                idunion = username + namegrupo,
                nombreusuario = username,
                idgrupo = namegrupo
            });
        }

        [HttpDelete]
        public void Delete(string username, string namegrupo)
        {
            _dataAccessProvider.DeleteUnion(username + namegrupo);
        }

    }
}
