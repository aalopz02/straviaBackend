using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public ModelUsuario GetUsuario(string nombreusuario) {
            return _context.usuario.FirstOrDefault(t => t.nombreusuario == nombreusuario);
        }

        public List<ModelUsuario> GetUsuarios()
        {
            return _context.usuario.ToList();
        }
            
        public List<ModelUsuario> GetUsuarios(string busqueda, string usuario) {
            //aca quitar a los que ya sigue
            if (busqueda.Equals("all")) {
                return _context.usuario.Where(p => !p.nombreusuario.Equals(usuario)).ToList();
            }
            List<ModelUsuario> lista = _context.usuario.Where(p => (p.fname.Contains(busqueda) || p.nombreusuario.Contains(busqueda)) && (!p.nombreusuario.Equals(usuario))).ToList();
            return _context.usuario.Where(p => (p.fname.Contains(busqueda) || p.nombreusuario.Contains(busqueda)) && (!p.nombreusuario.Equals(usuario))).ToList();
        }

        void IUsuarioAccessInterface.DeleteUsuario(string NombreUsuario)
        {
            throw new NotImplementedException();
        }

        void IUsuarioAccessInterface.UpdateUsuario(ModelUsuario usuario)
        {
            _context.usuario.Update(usuario);
            _context.SaveChanges();
        }
    }
}
