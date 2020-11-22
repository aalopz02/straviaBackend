using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    /// <summary>
    /// Access para el manejo de las actividades
    /// </summary>
    public class ActividadAccess : IActividadAccess
    {
        private readonly StravaContext _context;

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="context"></param>
        public ActividadAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para añadir una actividad
        /// </summary>
        /// <param name="actividad">Model con los datos de la actividad</param>
        public void AddActividad(ModelActividad actividad)
        {
            _context.actividad.Add(actividad);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método get para una actividad por el id
        /// </summary>
        /// <param name="idactividad">Id de la actividad a buscar</param>
        /// <returns>Actividad a buscar por id</returns>
        public ModelActividad GetActividad(string idactividad)
        {
            return _context.actividad.FirstOrDefault(t => t.idactividad == idactividad);
        }

        /// <summary>
        /// Método get de las actividades de un seguidor 
        /// </summary>
        /// <param name="seguidor">Seguidor al que se desea buscar las actividades</param>
        /// <returns>Lista de actividades del seguidor</returns>
        public List<ModelActividadView> GetActividades(string seguidor)
        {
            List<string> siguiendos = _context.seguidores.Where(t => t.nombreusuariofk == seguidor).Select(t => t.nombreusuariosiguiendofk).ToList();
            List<ModelActividad> modelActividades = _context.actividad.Where(t => siguiendos.Contains(t.nombreusuariofk)).OrderBy(t => t.fecha).ToList();
            List<ModelActividadView> modelsviews = new List<ModelActividadView>();

            foreach (ModelActividad actividad in modelActividades) {
                modelsviews.Add(new ModelActividadView
                {
                    nombreusuario = actividad.nombreusuariofk,
                    distancia = actividad.distanciakm,
                    tipoactividad = _context.tiposactividades.FirstOrDefault(t  => t.idact == actividad.tipoactividad).nombre,
                    rutagpx = actividad.dirrecorrido,
                    imagenperfil = _context.usuario.FirstOrDefault(t => t.nombreusuario == actividad.nombreusuariofk).imagenperfil
                }) ;
            }

            return modelsviews;
        }
    }
}
