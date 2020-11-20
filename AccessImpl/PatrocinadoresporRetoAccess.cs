using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class PatrocinadoresporRetoAccess : IPatrociandorporRetoAccessInterface
    {
        private readonly StravaContext _context;

        public PatrocinadoresporRetoAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddPatReto(Modelpatrocinadoresporreto patreto)
        {
            _context.patrocinadoresporreto.Add(patreto);
            _context.SaveChanges();
        }

        public void DeletePatReto(int patrocinador, string nombrereto)
        {
            var entity = _context.patrocinadoresporreto.FirstOrDefault(t => (t.idelementoreto == nombrereto + patrocinador.ToString()));
            _context.patrocinadoresporreto.Remove(entity);
            _context.SaveChanges();
        }

        public List<Modelpatrocinadoresporreto> GetPatsReto()
        {
            return _context.patrocinadoresporreto.ToList();
        }

        public List<Modelpatrocinadoresporreto> GetModelpatrocinadoresporreto(string nombrereto)
        {
            List < Modelpatrocinadoresporreto > result = new List<Modelpatrocinadoresporreto>();
            foreach (Modelpatrocinadoresporreto entiy in GetPatsReto()) {
                if (entiy.nombreretofk == nombrereto) {
                    result.Add(entiy);
                }
            }
            return result;
        }

        public void UpdateReto(Modelpatrocinadoresporreto patreto)
        {
            _context.patrocinadoresporreto.Update(patreto);
            _context.SaveChanges();
        }
    }
}
