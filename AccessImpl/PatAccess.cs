using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class PatAccess : IPatAccessInterface
    {
        private readonly StravaContext _context;

        public PatAccess(StravaContext context)
        {
            _context = context;
        }

        public ModelPatrocinador GetPat(int idpat)
        {
            return _context.patrocinadores.FirstOrDefault(t => t.idpat == idpat);
        }

        public List<ModelPatrocinador> GetPats()
        {
            return _context.patrocinadores.ToList();
        }
    }
}
