using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    /// <summary>
    /// Access para el manejo de los tipos de actividades
    /// </summary>
    public class TipoActAccess : ITipoActAccessInterface
    {
        private readonly StravaContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public TipoActAccess(StravaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Método para obtener actividade
        /// </summary>
        /// <param name="idact">Id de la actividad a buscar</param>
        /// <returns>Actividad a buscar</returns>
        public ModelTipoActividad GetActividad(int idact)
        {
            return _context.tiposactividades.FirstOrDefault(t => t.idact == idact);
        }

        /// <summary>
        /// Método para obtener la lista de actividades
        /// </summary>
        /// <returns>Lista de actividades</returns>
        public List<ModelTipoActividad> GetActs()
        {
            return _context.tiposactividades.ToList();
        }
    }
}
