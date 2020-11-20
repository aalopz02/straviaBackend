using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// https://localhost:44379/api/Usuario?busqueda=all&usuario=aalopz02
        /// </summary>
        /// <param name="busqueda"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// 
        public List<ModelSearchUserView> GetUsuarios(string busqueda, string usuario) {
            List<ModelUsuario> lista;
            if (busqueda.Equals("all"))
            {
                lista = _context.usuario.Where(p => !p.nombreusuario.Equals(usuario)).ToList();
            }
            else { 
                lista = lista = _context.usuario.Where(p => (p.fname.Contains(busqueda) || p.nombreusuario.Contains(busqueda)) && (!p.nombreusuario.Equals(usuario))).ToList();
            }
            List<ModelSearchUserView> usersviewmodel = new List<ModelSearchUserView>();
            List<String> siguiendo = _context.seguidores.Where(t => t.nombreusuariofk == usuario).Select(t => t.nombreusuariosiguiendofk).ToList();
            foreach (ModelUsuario user in lista) {
                bool losigue = siguiendo.Contains(user.nombreusuario);
                ModelSearchUserView modelSearchUser = new ModelSearchUserView
                {
                    nombreusuario = user.nombreusuario,
                    imagenperfil = user.imagenperfil,
                    nacionalidad = user.nacionalidad,
                    fname = user.fname,
                    mname = user.mname,
                    lname = user.lname,
                    siguiendo = losigue
                };
                usersviewmodel.Add(modelSearchUser);
            }

            return usersviewmodel;

        }
        void IUsuarioAccessInterface.DeleteUsuario(string NombreUsuario)
        {
            throw new NotImplementedException();
        }

        void IUsuarioAccessInterface.UpdateUsuario(ModelUsuario usuario,ModelUsuario old)
        {
            _context.Entry(old).State = EntityState.Detached;
            _context.usuario.Update(usuario);
            _context.SaveChanges();
        }

        void IUsuarioAccessInterface.UpdateUsuario(ModelUsuario usuario)
        {
            _context.usuario.Update(usuario);
            _context.SaveChanges();
        }
    }
}
