using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class TipoActAccess : ITipoActAccessInterface
    {
        private readonly StravaContext _context;

        public TipoActAccess(StravaContext context)
        {
            _context = context;
        }

        public ModelTipoActividad GetActividad(int idact)
        {
            return _context.tiposactividades.FirstOrDefault(t => t.idact == idact);
        }

        public List<ModelTipoActividad> GetActs()
        {
            return _context.tiposactividades.ToList();
        }
    }
}
