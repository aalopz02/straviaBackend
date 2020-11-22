using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    /// <summary>
    /// Access para el manejo de patrocinadores
    /// </summary>
    public class PatAccess : IPatAccessInterface
    {
        private readonly StravaContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PatAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método get de patrocinadores por id
        /// </summary>
        /// <param name="idpat">Id de partocinador</param>
        /// <returns>Patrocinador buscado por id</returns>
        public ModelPatrocinador GetPat(int idpat)
        {
            return _context.patrocinadores.FirstOrDefault(t => t.idpat == idpat);
        }

        /// <summary>
        /// Método get de patrocinadores
        /// </summary>
        /// <returns>Lista de patrocinadores</returns>
        public List<ModelPatrocinador> GetPats()
        {
            return _context.patrocinadores.ToList();
        }
    }
}
