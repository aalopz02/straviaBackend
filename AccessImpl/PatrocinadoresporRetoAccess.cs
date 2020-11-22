using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    /// <summary>
    /// Access para manejo de patrocinadores por carrera
    /// </summary>
    public class PatrocinadoresporRetoAccess : IPatrociandorporRetoAccessInterface
    {
        private readonly StravaContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PatrocinadoresporRetoAccess(StravaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Método para añadir patrocinadores para reto
        /// </summary>
        /// <param name="patreto">Patrocinador para reto</param>
        public void AddPatReto(Modelpatrocinadoresporreto patreto)
        {
            _context.patrocinadoresporreto.Add(patreto);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para elimar un patrocinador por reto
        /// </summary>
        /// <param name="patrocinador">Nombre del patrocinador a eliminar</param>
        /// <param name="nombrereto">Nombre del reto</param>
        public void DeletePatReto(int patrocinador, string nombrereto)
        {
            var entity = _context.patrocinadoresporreto.FirstOrDefault(t => (t.idelementoreto == nombrereto + patrocinador.ToString()));
            _context.patrocinadoresporreto.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método get para patrocinadores por reto
        /// </summary>
        /// <returns>Lista de patrocinadores por reto</returns>
        public List<Modelpatrocinadoresporreto> GetPatsReto()
        {
            return _context.patrocinadoresporreto.ToList();
        }

        /// <summary>
        /// Método get para patrocinadores para reto
        /// </summary>
        /// <param name="nombrereto">Nombre del reto a get</param>
        /// <returns>Lista de patrocinadores para reto</returns>
        public List<Modelpatrocinadoresporreto> GetModelpatrocinadoresporreto(string nombrereto)
        {
            List < Modelpatrocinadoresporreto > result = new List<Modelpatrocinadoresporreto>();
            foreach (Modelpatrocinadoresporreto entiy in GetPatsReto()) {
                if (entiy.nombreretofk == nombrereto) {
                    result.Add(entiy);
                }
            }
            return result;
        }

        /// <summary>
        /// Método para actualizar patrocinadores por retp
        /// </summary>
        /// <param name="patreto">Model de patrocinadores por reto</param>
        public void UpdateReto(Modelpatrocinadoresporreto patreto)
        {
            _context.patrocinadoresporreto.Update(patreto);
            _context.SaveChanges();
        }
    }
}
