using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class CarreraAccess : ICarreraAccessInterface
    {
        private readonly StravaContext _context;

        public CarreraAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddCarrera(ModelCarrera carrera)
        {
            _context.carreras.Add(carrera);
            _context.SaveChanges();
        }

        public void DeleteCarrera(string nombreCarrera)
        {
            var entity = _context.carreras.FirstOrDefault(t => t.nombrecarrera == nombreCarrera);
            _context.carreras.Remove(entity);
            _context.SaveChanges();
        }

        public ModelCarrera GetCarrera(string nombreCarrera)
        {
            return _context.carreras.FirstOrDefault(t => t.nombrecarrera == nombreCarrera);
        }

        public List<ModelCarreraView> GetCarreras(string username)
        {
            List<ModelCarreraView> viewmodels = new List<ModelCarreraView>();
            List<ModelCarrera> carreras = _context.carreras.ToList();
            List<String> nombrecarrerasinscrito = _context.inscripcioncarreras.Where(t => t.nombreusuario==username).Select(e => e.nombrecarrera).ToList();
            foreach (ModelCarrera carrera in carreras) {
                viewmodels.Add(new ModelCarreraView { 
                    nombrecarrera = carrera.nombrecarrera,
                    costo = carrera.costo,
                    fecha = carrera.fecha,
                    cuentapago = carrera.cuentapago,
                    tipoactividad = _context.tiposactividades.FirstOrDefault(t => t.idact == carrera.tipoactividad).nombre,
                    patrocinador = _context.patrocinadores.FirstOrDefault(t => t.idpat == _context.patrocinadoresporcarrera.FirstOrDefault(f => f.nombrecarrerafk == carrera.nombrecarrera).patrocinador).nombre,
                    logo = _context.patrocinadores.FirstOrDefault(t => t.idpat == _context.patrocinadoresporcarrera.FirstOrDefault(f => f.nombrecarrerafk == carrera.nombrecarrera).patrocinador).logo,
                    categoria = _context.categorias.FirstOrDefault(t => t.idcat == _context.categoriasporcarrera.FirstOrDefault(f => f.nombrecarrerafk==carrera.nombrecarrera).categoria).nombre,
                    suscrito = _context.inscripcioncarreras.Where(t => t.nombrecarrera == carrera.nombrecarrera).Select(f => f.nombreusuario).ToList().Contains(username)
                });
            }
            return viewmodels;
        }

        public List<ModelCarreraView> GetCarrerasForUser(string username)
        {
            List<String> listaCarrerasInscrito = _context.inscripcioncarreras.Where(t => t.nombreusuario == username).Select(t => t.nombreusuario).ToList();
            List<ModelCarrera> allcarreras = _context.carreras.ToList();
            List<ModelCarreraView> listaend = new List<ModelCarreraView>();
            foreach (ModelCarrera carrera in allcarreras)
            {
                int idpat = _context.patrocinadoresporcarrera.FirstOrDefault(f => f.nombrecarrerafk == carrera.nombrecarrera).patrocinador;
                int idcat = _context.categoriasporcarrera.FirstOrDefault(f => f.nombrecarrerafk == carrera.nombrecarrera).categoria;
                listaend.Add(new ModelCarreraView
                {
                    nombrecarrera = carrera.nombrecarrera,
                    costo = carrera.costo,
                    fecha = carrera.fecha,
                    tipoactividad = _context.tiposactividades.FirstOrDefault(t => t.idact == carrera.tipoactividad).nombre,
                    patrocinador = _context.patrocinadores.FirstOrDefault(t => t.idpat == idpat).nombre,
                    categoria = _context.categorias.FirstOrDefault(t => t.idcat == idcat).nombre,
                    suscrito = _context.inscripcioncarreras.Where(t => t.nombrecarrera == carrera.nombrecarrera).ToList().Count() != 0

                });
               
            }
            return listaend;
        }

        public void UpdateCarrera(ModelCarrera carrera)
        {
            _context.carreras.Update(carrera);
            _context.SaveChanges();
        }
    }
}
