using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    /// <summary>
    /// Access para el manejo de categorías
    /// </summary>
    public class CatAccess : ICatAccessInterface
    {
        private readonly StravaContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public CatAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método get de categoría por id
        /// </summary>
        /// <param name="idcat">Id de categoría a buscar</param>
        /// <returns>Categoría buscada por id</returns>
        public ModelCategoria GetCat(int idcat)
        {
            return _context.categorias.FirstOrDefault(t => t.idcat == idcat);
        }

        /// <summary>
        /// Método get de categorías
        /// </summary>
        /// <returns>Lista de categorías</returns>
        public List<ModelCategoria> GetCats()
        {
            return _context.categorias.ToList();
        }
    }
}
