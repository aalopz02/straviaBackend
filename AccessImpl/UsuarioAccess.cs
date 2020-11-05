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

        public ModelUsuario GetUsuario(string nombreusuario){
            return _context.Usuario.FirstOrDefault(t => t.nombreusuario == nombreusuario);

        
        public List<ModelUsuario> GetUsuarios() {
            return _context.usuario.ToList();
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
