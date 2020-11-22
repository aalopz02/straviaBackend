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

        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="dataAccessProvider">Acceso a la tabla de actividad</param>
        /// <param name="usuarioAccess">Acceso a la tabla de usuario</param>
        public ActividadController(IActividadAccess dataAccessProvider,
                                    IUsuarioAccessInterface usuarioAccess)
        {
            _dataAccessProvider = dataAccessProvider;
            _usuarioAccess = usuarioAccess;
        }

        /// <summary>
        /// Get para una actividad por id
        /// </summary>
        /// <param name="idactividad"> id de la actividad</param>
        /// <returns>Modelo de la actividad</returns>
        [HttpGet]
        public ModelActividad Get(string idactividad)
        {
            return _dataAccessProvider.GetActividad(idactividad);
        }

        /// <summary>
        /// Obtiene todas las actividades de los usuarios a los que un usuario sigue
        /// </summary>
        /// <param name="seguidor">Usuario que sigue</param>
        /// <returns>Lista con los modelos de las actividades</returns>
        [HttpGet("{seguidor}")]
        public IEnumerable<ModelActividadView> GetAll(string seguidor)
        {
            return _dataAccessProvider.GetActividades(seguidor);
        }

        /// <summary>
        /// Post para agregar una actividad a un usuario especifico
        /// </summary>
        /// <param name="nombreusuario"></param>
        /// <param name="date"></param>
        /// <param name="duracion"></param>
        /// <param name="idact"></param>
        /// <param name="distancia"></param>
        /// <param name="tipo"></param>
        /// <param name="ruta"></param>
        [HttpPost]
        public void AddActividad(string nombreusuario, string date, int duracion, int idact, int distancia, string tipo, [FromBody] FileModel ruta)
        {
            string dirruta = mist.ProcessSaveFiles.saveRuta(ruta, nombreusuario, date);
            _dataAccessProvider.AddActividad(new ModelActividad
            {
                nombreusuariofk = nombreusuario,
                idactividad = nombreusuario + date,
                fecha = DateTime.Parse(date),
                duracionmin = duracion,
                tipoactividad = idact,
                distanciakm = distancia,
                carreraoreto = tipo,
                dirrecorrido = dirruta
            }) ; 
            
        }
    }
}
