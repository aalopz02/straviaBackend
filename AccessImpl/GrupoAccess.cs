using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class GrupoAccess : IGrupoAccessInterface
    {
        private readonly StravaContext _context;

        public GrupoAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddGrupo(ModelGrupo grupo)
        {
            _context.grupos.Add(grupo);
            _context.SaveChanges();
        }

        public void DeleteGrupo(string idGrupo)
        {
            var entity = _context.grupos.FirstOrDefault(t => t.idgrupo == idGrupo);
            _context.grupos.Remove(entity);
            _context.SaveChanges();
        }

        public List<ModelGrupo> GetGrupo(string nombreGrupo)
        {
            return _context.grupos.Where(t => t.nombregrupo== nombreGrupo).OrderBy(t => t.nombregrupo).ToList();
        }

        public List<ModelGrupo> GetGrupos()
        {
            return _context.grupos.ToList();
        }

        public void UpdateGrupo(ModelGrupo grupo)
        {
            _context.grupos.Update(grupo);
            _context.SaveChanges();
        }

    
    }
}
