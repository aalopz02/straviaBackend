using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class ActividadAccess : IActividadAccess
    {
        private readonly StravaContext _context;

        public ActividadAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddActividad(ModelActividad actividad)
        {
            _context.actividad.Add(actividad);
            _context.SaveChanges();
        }

        public ModelActividad GetActividad(string idactividad)
        {
            return _context.actividad.FirstOrDefault(t => t.idactividad == idactividad);
        }

        public List<ModelActividad> GetActividades(string seguidor)
        {
            List<List<ModelActividad>> matrizActividades = new List<List<ModelActividad>>();
            List<String> siguiendo = _context.seguidores.Where(t => t.nombreusuariofk == seguidor).Select(t => t.nombreusuariosiguiendofk).ToList();
            foreach (String user in siguiendo) {
                matrizActividades.Add(_context.actividad.Where(t => t.nombreusuariofk == user).OrderBy(t=> t.fecha).ToList());
            }
            List<ModelActividad> actividades = new List<ModelActividad>();

            for (int i = 0; i < matrizActividades.Count; i++) {
                actividades.Add(matrizActividades.ElementAt(i).First());
            }

            return actividades;
        }
    }
}
