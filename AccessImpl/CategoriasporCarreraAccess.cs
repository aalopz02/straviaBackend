using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class CategoriasporCarreraAccess : ICategoriasporCarreraAccessInterface
    {
        private readonly StravaContext _context;

        public CategoriasporCarreraAccess(StravaContext context)
        {
            _context = context;
        }

        public void Addcat(Modelcategoriasporcarrera cat)
        {
            _context.categoriasporcarrera.Add(cat);
            _context.SaveChanges();
        }

        public void DeleteCat(int categoria, string nombrecarrera)
        {
            var entity = _context.categoriasporcarrera.FirstOrDefault(t => (t.idelemento == nombrecarrera + categoria.ToString()));
            _context.categoriasporcarrera.Remove(entity);
            _context.SaveChanges();
        }

        public List<Modelcategoriasporcarrera> GetAll()
        {
            return _context.categoriasporcarrera.ToList();
        }

        public List<Modelcategoriasporcarrera> GetCats(string nombrecarrera)
        {
            List<Modelcategoriasporcarrera> result = new List<Modelcategoriasporcarrera>();
            foreach (Modelcategoriasporcarrera entiy in GetAll())
            {
                if (entiy.nombrecarrerafk  == nombrecarrera)
                {
                    result.Add(entiy);
                }
            }
            return result;
        }
    }
}
