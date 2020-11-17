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

        public List<ModelActividadView> GetActividades(string seguidor)
        {
            List<string> siguiendos = _context.seguidores.Where(t => t.nombreusuariofk == seguidor).Select(t => t.nombreusuariosiguiendofk).ToList();
            List<ModelActividad> modelActividades = _context.actividad.Where(t => siguiendos.Contains(t.nombreusuariofk)).OrderBy(t => t.fecha).ToList();
            List<ModelActividadView> modelsviews = new List<ModelActividadView>();

            foreach (ModelActividad actividad in modelActividades) {
                modelsviews.Add(new ModelActividadView
                {
                    nombreusuario = actividad.nombreusuariofk,
                    distancia = actividad.distanciakm,
                    tipoactividad = _context.tiposactividades.FirstOrDefault(t  => t.idact == actividad.tipoactividad).nombre,
                    rutagpx = actividad.dirrecorrido
                }) ;
            }

            return modelsviews;
        }
    }
}
