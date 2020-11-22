using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    /// <summary>
    /// Access para el manejo de union de usuario
    /// </summary>
    public class UnionUsuarioGrupoAccess : IUnionGrupoAccessInterface
    {
        private readonly StravaContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UnionUsuarioGrupoAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para añadir una unio
        /// </summary>
        /// <param name="union">Model de la union a añadir</param>
        public void AddUnion(ModelUnionUsuarioGrupo union)
        {
            _context.unionusuariogrupo.Add(union);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para eliminar una unión
        /// </summary>
        /// <param name="idelemento">Id de la unión a eliminar</param>
        public void DeleteUnion(string idelemento)
        {
            var entity = _context.unionusuariogrupo.FirstOrDefault(t => t.idunion == idelemento);
            _context.unionusuariogrupo.Remove(entity);
            _context.SaveChanges();
        }
    }
}
