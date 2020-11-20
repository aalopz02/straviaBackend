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


        public GruposController(IGrupoAccessInterface dataAccessProvider,
                                    IPatrociandorporCarreraAccessInterface pats,
                                    ICategoriasporCarreraAccessInterface cats)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            _cats = cats;
          
        }

        [HttpGet]
        public IEnumerable<ModelGrupo> Get()
        {
            return _dataAccessProvider.GetGrupos();
        }


        //https://localhost:44379/api/Grupos?nombreGrupo=grupo&UsuarioAdmin=hola
        [HttpPost]//String nombreGrupo, UsuarioAdmin
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

        [HttpGet("{nombreGrupo}")]
        public IEnumerable<ModelGrupo> GetAll(string nombreGrupo)
        {
            return _dataAccessProvider.GetGrupo(nombreGrupo);
        }

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
