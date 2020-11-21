using Microsoft.EntityFrameworkCore;
using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class RetoAccess : IRetoAccessInterface
    {
        private readonly StravaContext _context;

        public RetoAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddReto(ModelReto reto)
        {
            _context.retos.Add(reto);
            _context.SaveChanges();
        }

        public void DeleteReto(string nombreReto)
        {
            var entity = _context.retos.FirstOrDefault(t => t.nombrereto == nombreReto);
            List<Modelpatrocinadoresporreto> patsr = _context.patrocinadoresporreto.Where(t => t.nombreretofk == nombreReto).ToList();
            foreach (Modelpatrocinadoresporreto pr in patsr) {
                _context.patrocinadoresporreto.Remove(pr);
                _context.SaveChanges();
            }
            _context.retos.Remove(entity);
            _context.SaveChanges();
        }

        public ModelReto GetReto(string nombreReto)
        {
            return _context.retos.FirstOrDefault(t => t.nombrereto == nombreReto);
        }

        public List<ModelReto> GetRetos()
        {
            return _context.retos.ToList();
        }

        public List<ModelRetoView> GetRetosForUser(string username)
        {
            List<String> listaRetosInscrito = _context.inscripcionesreto.Where(t => t.nombreusuario == username).Select(t => t.nombreusuario).ToList();
            List<ModelReto> allretos = _context.retos.ToList();
            List<ModelRetoView> listaend = new List<ModelRetoView>();
            foreach (ModelReto reto in allretos)
            {
                int idpat = _context.patrocinadoresporreto.FirstOrDefault(f => f.nombreretofk == reto.nombrereto).patrocinador;
                listaend.Add(new ModelRetoView
                {
                    nombrereto = reto.nombrereto,
                    periodo_inicio = reto.periodo_inicio,
                    periodo_final = reto.periodo_final,
                    tipoact = _context.tiposactividades.FirstOrDefault(t => t.idact == reto.tipoact).nombre,
                    tipo = reto.tipo,
                    logo = _context.patrocinadores.FirstOrDefault(t => t.idpat == _context.patrocinadoresporreto.FirstOrDefault(f => f.nombreretofk == reto.nombrereto).patrocinador).logo,
                    privacidad = reto.privacidad,
                    patrocinador = _context.patrocinadores.FirstOrDefault(t => t.idpat == idpat).nombre,
                    suscrito = _context.inscripcionesreto.Where(t => t.nombrereto == reto.nombrereto).ToList().Count() != 0

                });

            }
            return listaend;
        }


        public void UpdateReto(ModelReto reto,ModelReto old)
        {
            _context.Entry(old).State = EntityState.Detached;
            _context.retos.Update(reto);
            _context.SaveChanges();
        }
    }
}
