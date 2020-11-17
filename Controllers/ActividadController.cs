using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using Utf8Json.Formatters;

namespace straviaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly IActividadAccess _dataAccessProvider;
        private readonly IUsuarioAccessInterface _usuarioAccess;

        public ActividadController(IActividadAccess dataAccessProvider,
                                    IUsuarioAccessInterface usuarioAccess)
        {
            _dataAccessProvider = dataAccessProvider;
            _usuarioAccess = usuarioAccess;
        }

        [HttpGet]
        public ModelActividad Get(string idactividad)
        {
            return _dataAccessProvider.GetActividad(idactividad);
        }

        [HttpGet("{seguidor}")]
        public IEnumerable<ModelActividadView> GetAll(string seguidor)
        {
            return _dataAccessProvider.GetActividades(seguidor);
        }

        //https://localhost:44379/api/Actividad?nombreusuario=aalopz02&date=2006-01-01&duracion=60&idact=2&distancia=10&tipo=reto
        [HttpPost]
        public void AddActividad(string nombreusuario,string date,int duracion,int idact,int distancia,string tipo) {
            _dataAccessProvider.AddActividad(new ModelActividad
            {
                nombreusuariofk = nombreusuario,
                idactividad = nombreusuario + date,
                fecha = DateTime.Parse(date),
                duracionmin = duracion,
                tipoactividad = idact,
                distanciakm = distancia,
                carreraoreto = tipo
            }) ; 
        }
    }
}
