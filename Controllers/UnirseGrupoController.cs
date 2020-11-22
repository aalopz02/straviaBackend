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

        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a tabla de uniones a grupos </param>
        public UnirseGrupoController(IUnionGrupoAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        /// <summary>
        /// Post de nuevo miembro a un grupo
        /// </summary>
        /// <param name="username"></param>
        /// <param name="namegrupo"></param>
        [HttpPost]
        public void Post(string username, string namegrupo) {
            _dataAccessProvider.AddUnion(new models.ModelUnionUsuarioGrupo { 
                idunion = username + namegrupo,
                nombreusuario = username,
                idgrupo = namegrupo
            });
        }

        /// <summary>
        /// delete de la inscripcion al grupo
        /// </summary>
        /// <param name="username"></param>
        /// <param name="namegrupo"></param>
        [HttpDelete]
        public void Delete(string username, string namegrupo)
        {
            _dataAccessProvider.DeleteUnion(username + namegrupo);
        }

    }
}
