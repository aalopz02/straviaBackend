using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class UsuarioAccess : IUsuarioAccessInterface
    {
        private readonly StravaContext _context;

        public UsuarioAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddUsuario(ModelUsuario usuario)
        {
            _context.usuario.Add(usuario);
            _context.SaveChanges();
        }

        public ModelUsuario GetUsuario(string NombreUsuario){

            return _context.usuario.FirstOrDefault(t => t.nombreusuario == NombreUsuario);
        }

        public List<ModelUsuario> GetUsuarios(string busqueda) {
            if (busqueda.Equals("all")) {
                return _context.usuario.ToList();
            }
            return _context.usuario.Where(p => p.fname.Contains(busqueda) || p.nombreusuario.Contains(busqueda)).ToList();
        }

        void IUsuarioAccessInterface.DeleteUsuario(string NombreUsuario)
        {
            throw new NotImplementedException();
        }

        void IUsuarioAccessInterface.UpdateUsuario(ModelUsuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
