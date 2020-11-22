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
    /// Access para el manejo de inscripciones a retos
    /// </summary>
    public class InscripcionRetoAccess : IInscripcionRetoAccessInterface
    {
        private readonly StravaContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public InscripcionRetoAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para añadir inscripciones a retos
        /// </summary>
        /// <param name="inscripcionreto">Nombre de inscripción a reto</param>
        public void AddInscripcionReto(ModelInscripcionReto inscripcionreto)
        {
            _context.inscripcionesreto.Add(inscripcionreto);
            _context.SaveChanges();
        }

 
    }
}
