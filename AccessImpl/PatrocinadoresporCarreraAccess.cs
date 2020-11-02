using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class PatrocinadoresporCarreraAccess : IPatrociandorporCarreraAccessInterface
    {
        private readonly StravaContext _context;

        public PatrocinadoresporCarreraAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddPat(Modelpatrocinadoresporcarrera pat)
        {
            _context.patrocinadoresporcarrera.Add(pat);
            _context.SaveChanges();
        }

        public void DeletePat(int patrocinador, string nombrecarrera)
        {
            var entity = _context.patrocinadoresporcarrera.FirstOrDefault(t => (t.idelemento == nombrecarrera + patrocinador.ToString()));
            _context.patrocinadoresporcarrera.Remove(entity);
            _context.SaveChanges();
        }

        public List<Modelpatrocinadoresporcarrera> GetPats()
        {
            return _context.patrocinadoresporcarrera.ToList();
        }

        public List<Modelpatrocinadoresporcarrera> GetModelpatrocinadoresporcarrera(string nombrecarrera)
        {
            List < Modelpatrocinadoresporcarrera > result = new List<Modelpatrocinadoresporcarrera>();
            foreach (Modelpatrocinadoresporcarrera entiy in GetPats()) {
                if (entiy.nombrecarrerafk == nombrecarrera) {
                    result.Add(entiy);
                }
            }
            return result;
        }
    }
}
