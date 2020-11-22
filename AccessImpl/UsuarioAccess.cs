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
{   /// <summary>
/// Access para el manejo de usuario
/// </summary>
    public class UsuarioAccess : IUsuarioAccessInterface
    {
        private readonly StravaContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UsuarioAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para añadir usuario
        /// </summary>
        /// <param name="usuario">Model del usuario a añadir</param>
        public void AddUsuario(ModelUsuario usuario)
        {
            _context.usuario.Add(usuario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método get de usuario por nombre
        /// </summary>
        /// <param name="nombreusuario">Nombre de usuario a buscar</param>
        /// <returns>Usuario a buscar</returns>
        public ModelUsuario GetUsuario(string nombreusuario) {
            return _context.usuario.FirstOrDefault(t => t.nombreusuario == nombreusuario);
        }

        /// <summary>
        /// Método get para la lista de usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public List<ModelUsuario> GetUsuarios()
        {
            return _context.usuario.ToList();
        }

        /// <summary>
        /// https://localhost:44379/api/Usuario?busqueda=all&usuario=aalopz02
        /// Método get de usuarios para realizar la busqueda de usuarios
        /// </summary>
        /// <param name="busqueda">Valor a buscar</param>
        /// <param name="usuario">Usuario que realiza la busqueda</param>
        /// <returns>Lista de usuarios obtenidos de la busqueda</returns>
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
        /// <summary>
        /// Método para eliminar un usuario por nombre
        /// </summary>
        /// <param name="NombreUsuario">Nombre de usuario a eliminar</param>
        void IUsuarioAccessInterface.DeleteUsuario(string NombreUsuario)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para actualizar un usario
        /// </summary>
        /// <param name="usuario">Model de usuario a actualizar</param>
        /// <param name="old">Model del usuario viejo</param>
        void IUsuarioAccessInterface.UpdateUsuario(ModelUsuario usuario,ModelUsuario old)
        {
            _context.Entry(old).State = EntityState.Detached;
            _context.usuario.Update(usuario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para actualizar un usario
        /// </summary>
        /// <param name="usuario">Model de usuario a actualizar</param>
        void IUsuarioAccessInterface.UpdateUsuario(ModelUsuario usuario)
        {
            _context.usuario.Update(usuario);
            _context.SaveChanges();
        }
    }
}
