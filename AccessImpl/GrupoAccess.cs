using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    /// <summary>
    /// Access para el manejo de grupos
    /// </summary>
    public class GrupoAccess : IGrupoAccessInterface
    {
        private readonly StravaContext _context;
        /// <summary>
        /// COnstructor
        /// </summary>
        /// <param name="context"></param>
        public GrupoAccess(StravaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Método para añadir grupos
        /// </summary>
        /// <param name="grupo">Model del grupo a añadir</param>
        public void AddGrupo(ModelGrupo grupo)
        {
            _context.grupos.Add(grupo);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para eliminar grupo
        /// </summary>
        /// <param name="idGrupo">id del grupo a eliminar</param>
        public void DeleteGrupo(string idGrupo)
        {
            var entity = _context.grupos.FirstOrDefault(t => t.idgrupo == idGrupo);
            _context.grupos.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo get para grupo por nombre
        /// </summary>
        /// <param name="nombreGrupo">Nombre del grupo a obtener</param>
        /// <returns>Lista de grupos con el nombre</returns>
        public List<ModelGrupo> GetGrupo(string nombreGrupo)
        {
            return _context.grupos.Where(t => t.nombregrupo== nombreGrupo).OrderBy(t => t.nombregrupo).ToList();
        }

        public List<ModelGrupo> GetGrupos()
        {
            return _context.grupos.ToList();
        }
        /// <summary>
        /// Método para obtener grupos para el usuarop
        /// </summary>
        /// <param name="username">Usuario a obtener grupos</param>
        /// <returns>Lista de grupos para usuario</returns>
        public List<ModelGrupoView> GetGruposForUser(string username)
        {
            List<ModelGrupo> allgroups = _context.grupos.ToList();
            List<ModelGrupoView> models = new List<ModelGrupoView>();

            foreach (ModelGrupo grupo in allgroups) {
                bool estasuscrito = false;
                if (_context.unionusuariogrupo.Where(t => t.idunion == username + grupo.idgrupo).ToList().Count() != 0) {
                    estasuscrito = true;
                }
                if (grupo.nombreusuario.Equals(username)) {
                    estasuscrito = true;
                }
                models.Add(new ModelGrupoView
                {
                    nombregrupo = grupo.nombregrupo,
                    admin = grupo.nombreusuario,
                    key = grupo.idgrupo,
                    suscrito = estasuscrito
                }) ;
            }
            return models;
        }

        /// <summary>
        /// Método para actualizar un grupo
        /// </summary>
        /// <param name="grupo">Model del grupo a actualizar</param>
        public void UpdateGrupo(ModelGrupo grupo)
        {
            _context.grupos.Update(grupo);
            _context.SaveChanges();
        }

    
    }
}
