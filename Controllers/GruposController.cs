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

namespace straviaBackend.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class GruposController : ControllerBase
    {
        private readonly IGrupoAccessInterface _dataAccessProvider;
        private readonly IPatrociandorporCarreraAccessInterface _pats;
        private readonly ICategoriasporCarreraAccessInterface _cats;

        /// <summary>
        /// Constructor del controller
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a tabla grupos</param>
        /// <param name="pats"> Acceso a tabla patrocinadores por carrera</param>
        /// <param name="cats"> Acceso a categorias por carrera</param>
        public GruposController(IGrupoAccessInterface dataAccessProvider,
                                    IPatrociandorporCarreraAccessInterface pats,
                                    ICategoriasporCarreraAccessInterface cats)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            _cats = cats;
          
        }

        /// <summary>
        /// Get de grupos
        /// </summary>
        /// <returns>Lista de grupos</returns>
        [HttpGet]
        public IEnumerable<ModelGrupo> Get()
        {
            return _dataAccessProvider.GetGrupos();
        }


        /// <summary>
        /// Post de grupo
        /// </summary>
        /// <param name="nombreGrupo"></param>
        /// <param name="UsuarioAdmin"></param>
        [HttpPost]
        public void AddGrupo(String nombreGrupo, String UsuarioAdmin )
        {
            ModelGrupo grupo = new ModelGrupo
            {
                nombregrupo = nombreGrupo,
                nombreusuario=UsuarioAdmin,
                idgrupo = nombreGrupo + UsuarioAdmin
            };
            _dataAccessProvider.AddGrupo(grupo);
        
        }

        /// <summary>
        /// Get de los grupos desde la vista de un usuario
        /// </summary>
        /// <param name="nombreGrupo"> Usuario a verificar </param>
        /// <returns> Lista de modelos con los grupos</returns>
        [HttpGet("{nombreGrupo}")]
        public IEnumerable<ModelGrupo> GetAll(string nombreGrupo)
        {
            return _dataAccessProvider.GetGrupo(nombreGrupo);
        }

        /// <summary>
        /// Modificar un grupo
        /// </summary>
        /// <param name="nombreGrupo"> nombre del grupo</param>
        /// <param name="UsuarioAdmin"> nombre del administrador</param>
        /// <param name="key"> valor llave del grupo</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit(String nombreGrupo,String UsuarioAdmin, String key) 
        {
            if (ModelState.IsValid)
            {
                ModelGrupo grupo = new ModelGrupo
                {
                    nombregrupo = nombreGrupo,
                    nombreusuario = UsuarioAdmin,
                    idgrupo = key
                };
               
                  
                
                _dataAccessProvider.UpdateGrupo(grupo);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete de grupo
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        [HttpDelete("{idGrupo}")]
        public IActionResult DeleteConfirmed(string idGrupo)
        {
            var data = _dataAccessProvider.GetGrupo(idGrupo);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteGrupo(idGrupo);
            return Ok();
        }
    }
}
