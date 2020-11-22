using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    /// <summary>
    /// Access para inscripcion aa carrera
    /// </summary>
    public class InscripcionCarreraAccess : IInscripcionCarreraAccessInterface
    {
        private readonly StravaContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public InscripcionCarreraAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para añadir inscripciones a carrera
        /// </summary>
        /// <param name="inscripcioncarrera">Inscripcion a realizar</param>
        public void AddInscripcionCarrera(ModelInscripcionCarrera inscripcioncarrera)
        {
            _context.inscripcioncarreras.Add(inscripcioncarrera);
            _context.SaveChanges();
        }

    }
}
