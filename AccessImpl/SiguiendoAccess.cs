using Microsoft.EntityFrameworkCore;
using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{   /// <summary>
/// Access para el manejo de seguidores
/// </summary>
    public class SiguiendoAccess : ISeguidoresAccess
    {
        private readonly StravaContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public SiguiendoAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para añadir un seguidor
        /// </summary>
        /// <param name="siguiendo">Model del seguidor</param>
        public void AddSeguidor(ModelSiguiendo siguiendo)
        {
            _context.seguidores.Add(siguiendo);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para eliminar un seguidor
        /// </summary>
        /// <param name="idelemento">Ide del seguidor</param>
        public void DeleteSeguidor(string idelemento)
        {
            var entity = _context.seguidores.FirstOrDefault(t => t.idelemento == idelemento);
            _context.seguidores.Remove(entity);
            _context.SaveChanges();
        }
        
        /// <summary>
        /// Método para obtener el elemento de un usuario
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <returns>Elemento del usuario</returns>
        public ModelSiguiendo Getelemento(string usuario)
        {
            return _context.seguidores.FirstOrDefault(t => t.nombreusuariosiguiendofk == usuario);
        }

        /// <summary>
        /// Método para obtener el seguidor de un usuario
        /// </summary>
        /// <param name="nombreusuario">Nombre del usuario para get</param>
        /// <returns>Seguidor del usuario</returns>
        public ModelUsuario GetSeguidor(string nombreusuario)
        {
           return _context.usuario.FirstOrDefault(t => t.nombreusuario == nombreusuario);
        }

        /// <summary>
        /// Método para obtener los seguidores
        /// </summary>
        /// <param name="nombreusuario">Nombre de usuario para get</param>
        /// <returns>Lista de seguidores</returns>
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
