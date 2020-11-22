using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class UnionUsuarioGrupoAccess : IUnionGrupoAccessInterface
    {
        private readonly StravaContext _context;

        public UnionUsuarioGrupoAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddUnion(ModelUnionUsuarioGrupo union)
        {
            _context.unionusuariogrupo.Add(union);
            _context.SaveChanges();
        }

        public void DeleteUnion(string idelemento)
        {
            var entity = _context.unionusuariogrupo.FirstOrDefault(t => t.idunion == idelemento);
            _context.unionusuariogrupo.Remove(entity);
            _context.SaveChanges();
        }
    }
}
