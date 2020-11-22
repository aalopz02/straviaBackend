using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    /// <summary>
    /// Access para el manejo de patrocinadores por carrera
    /// </summary>
    public class PatrocinadoresporCarreraAccess : IPatrociandorporCarreraAccessInterface
    {
        private readonly StravaContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PatrocinadoresporCarreraAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para añadir un patrocinador
        /// </summary>
        /// <param name="pat">Model del patrocinador a añadir</param>
        public void AddPat(Modelpatrocinadoresporcarrera pat)
        {
            _context.patrocinadoresporcarrera.Add(pat);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para eliminar un patrocinador
        /// </summary>
        /// <param name="patrocinador">Patrocinador a eliminar</param>
        /// <param name="nombrecarrera">Nombre de la carrera con patrocinador</param>
        public void DeletePat(int patrocinador, string nombrecarrera)
        {
            var entity = _context.patrocinadoresporcarrera.FirstOrDefault(t => (t.idelemento == nombrecarrera + patrocinador.ToString()));
            _context.patrocinadoresporcarrera.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para obtener patrocinadores
        /// </summary>
        /// <returns>Lista de patrocinadores</returns>
        public List<Modelpatrocinadoresporcarrera> GetPats()
        {
            return _context.patrocinadoresporcarrera.ToList();
        }

        /// <summary>
        /// Método get de patrocinadores para carrera
        /// </summary>
        /// <param name="nombrecarrera">Carrera con patrocinadores</param>
        /// <returns>Lista de patrocinadores para carrera</returns>
        public List<Modelpatrocinadoresporcarrera> GetModelpatrocinadoresporcarrera(string nombrecarrera)
        {
            List < Modelpatrocinadoresporcarrera > result = new List<Modelpatrocinadoresporcarrera>();
            foreach (Modelpatrocinadoresporcarrera entiy in GetPats()) {
                if (entiy.nombrecarrerafk == nombrecarrera) {
                    result.Add(entiy);
                }
            }
            return result;
        }
        /// <summary>
        /// Método para actualizar un patrocinador por carrera
        /// </summary>
        /// <param name="pat">Model del patrocinador a actualizar</param>
        public void Update(Modelpatrocinadoresporcarrera pat)
        {
            _context.patrocinadoresporcarrera.Update(pat);
            _context.SaveChanges();
        }
    }
}
