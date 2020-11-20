using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class InscripcionCarreraAccess : IInscripcionCarreraAccessInterface
    {
        private readonly StravaContext _context;

        public InscripcionCarreraAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddInscripcionCarrera(ModelInscripcionCarrera inscripcioncarrera)
        {
            _context.inscripcionescarrera.Add(inscripcioncarrera);
            _context.SaveChanges();
        }

    }
}
