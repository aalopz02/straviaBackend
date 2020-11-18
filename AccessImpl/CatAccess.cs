using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class CatAccess : ICatAccessInterface
    {
        private readonly StravaContext _context;

        public CatAccess(StravaContext context)
        {
            _context = context;
        }

        public ModelCategoria GetCat(int idcat)
        {
            return _context.categorias.FirstOrDefault(t => t.idcat == idcat);
        }

        public List<ModelCategoria> GetCats()
        {
            return _context.categorias.ToList();
        }
    }
}
