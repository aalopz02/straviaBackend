using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class SiguiendoAccess : ISeguidoresAccess
    {
        private readonly StravaContext _context;

        public SiguiendoAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddSeguidor(ModelSiguiendo siguiendo)
        {
            _context.seguidores.Add(siguiendo);
            _context.SaveChanges();
        }

        public void DeleteSeguidor(string idelemento)
        {
            var entity = _context.seguidores.FirstOrDefault(t => t.idelemento == idelemento);
            _context.seguidores.Remove(entity);
            _context.SaveChanges();
        }

        public ModelSiguiendo Getelemento(string usuario)
        {
            return _context.seguidores.FirstOrDefault(t => t.nombreusuariosiguiendofk == usuario);
        }

        public ModelUsuario GetSeguidor(string nombreusuario)
        {
           return _context.usuario.FirstOrDefault(t => t.nombreusuario == nombreusuario);
        }

        public List<ModelUsuario> GetSiguiendo(string nombreusuario)
        {
            List<String> siguiendo = _context.seguidores.Where(t => t.nombreusuariofk == nombreusuario).Select(t => t.nombreusuariosiguiendofk).ToList();
            List<ModelUsuario> siguiendoList = new List<ModelUsuario>();
            List<ModelUsuario> users = _context.usuario.ToList();
            foreach (ModelUsuario usuario in users) {
                if (siguiendo.Contains(usuario.nombreusuario)) {
                    siguiendoList.Add(usuario);
                }
            }
            return siguiendoList;
        }
    }
}
