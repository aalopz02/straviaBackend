using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class RetoAccess : IRetoAccessInterface
    {
        private readonly StravaContext _context;

        public RetoAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddReto(ModelReto reto)
        {
            _context.retos.Add(reto);
            _context.SaveChanges();
        }

        public void DeleteReto(string nombreReto)
        {
            var entity = _context.retos.FirstOrDefault(t => t.nombrereto == nombreReto);
            _context.retos.Remove(entity);
            _context.SaveChanges();
        }

        public ModelReto GetReto(string nombreReto)
        {
            return _context.retos.FirstOrDefault(t => t.nombrereto == nombreReto);
        }

        public List<ModelReto> GetRetos()
        {
            return _context.retos.ToList();
        }

        public void UpdateReto(ModelReto reto)
        {
            _context.retos.Update(reto);
            _context.SaveChanges();
        }
    }
}
