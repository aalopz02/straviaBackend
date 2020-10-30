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
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
    }
}
