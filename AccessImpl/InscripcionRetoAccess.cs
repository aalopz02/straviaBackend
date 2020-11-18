using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class InscripcionRetoAccess : IInscripcionRetoAccessInterface
    {
        private readonly StravaContext _context;

        public InscripcionRetoAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddInscripcionReto(ModelInscripcionReto inscripcionreto)
        {
            _context.inscripcionretos.Add(inscripcionreto);
            _context.SaveChanges();
        }

 
    }
}
