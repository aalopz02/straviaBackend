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
    /// <summary>
    ///  Access para el manejo de las carreras
    /// </summary>
    public class CarreraAccess : ICarreraAccessInterface
    {
        private readonly StravaContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public CarreraAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para añadir una carrera
        /// </summary>
        /// <param name="carrera">Model con los datos de la carrera</param>
        public void AddCarrera(ModelCarrera carrera)
        {
            _context.carreras.Add(carrera);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para eliminar una carrera
        /// </summary>
        /// <param name="nombreCarrera">Nombre de la carrera a eliminar</param>
        public void DeleteCarrera(string nombreCarrera)
        {
            var entity = _context.carreras.FirstOrDefault(t => t.nombrecarrera == nombreCarrera);
            foreach (Modelpatrocinadoresporcarrera patcarr in _context.patrocinadoresporcarrera.Where(t => t.nombrecarrerafk == entity.nombrecarrera).ToList()) {
                _context.patrocinadoresporcarrera.Remove(patcarr);
                _context.SaveChanges();
            }
            foreach (Modelcategoriasporcarrera catcarr in _context.categoriasporcarrera.Where(t => t.nombrecarrerafk == entity.nombrecarrera).ToList())
            {
                _context.categoriasporcarrera.Remove(catcarr);
                _context.SaveChanges();
            }
            foreach (ModelInscripcionCarrera inscar in _context.inscripcioncarreras.Where(t => t.nombrecarrera == entity.nombrecarrera).ToList())
            {
                _context.inscripcioncarreras.Remove(inscar);
                _context.SaveChanges();
            }
            _context.carreras.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método get para una carrera por el nombre
        /// </summary>
        /// <param name="nombreCarrera">Nombre de la carrera para get</param>
        /// <returns>Carrera obtenida con el get</returns>
        public ModelCarrera GetCarrera(string nombreCarrera)
        {
            return _context.carreras.FirstOrDefault(t => t.nombrecarrera == nombreCarrera);
        }

        /// <summary>
        /// Método get para carreras por nombre de usuario
        /// </summary>
        /// <param name="username">Nombre de usuario para get de carreras</param>
        /// <returns>Lista de carreras del usuario</returns>
        public List<ModelCarreraView> GetCarreras(string username)
        {
            List<ModelCarreraView> viewmodels = new List<ModelCarreraView>();
            List<ModelCarrera> carreras = _context.carreras.ToList();
            List<String> nombrecarrerasinscrito = _context.inscripcioncarreras.Where(t => t.nombreusuario==username).Select(e => e.nombrecarrera).ToList();
            try {
                foreach (ModelCarrera carrera in carreras)
                {
                    viewmodels.Add(new ModelCarreraView
                    {
                        nombrecarrera = carrera.nombrecarrera,
                        costo = carrera.costo,
                        fecha = carrera.fecha,
                        cuentapago = carrera.cuentapago,
                        tipoactividad = _context.tiposactividades.FirstOrDefault(t => t.idact == carrera.tipoactividad).nombre,
                        patrocinador = _context.patrocinadores.FirstOrDefault(t => t.idpat == _context.patrocinadoresporcarrera.FirstOrDefault(f => f.nombrecarrerafk == carrera.nombrecarrera).patrocinador).nombre,
                        logo = _context.patrocinadores.FirstOrDefault(t => t.idpat == _context.patrocinadoresporcarrera.FirstOrDefault(f => f.nombrecarrerafk == carrera.nombrecarrera).patrocinador).logo,
                        categoria = _context.categorias.FirstOrDefault(t => t.idcat == _context.categoriasporcarrera.FirstOrDefault(f => f.nombrecarrerafk == carrera.nombrecarrera).categoria).nombre,
                        suscrito = _context.inscripcioncarreras.Where(t => t.nombrecarrera == carrera.nombrecarrera).Select(f => f.nombreusuario).ToList().Contains(username),
                        privacidad = carrera.privacidad,
                        ruta = carrera.ruta
                    });
                }
            } catch (NullReferenceException) {
                return null;
            }
            

            return viewmodels;
        }

        /// <summary>
        /// Método get de carreras para usuario 
        /// </summary>
        /// <param name="username">Usuario a obtener carreras</param>
        /// <returns>Lista de carreras a las que esta y no esta inscrito el usuario</returns>
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
                    ,ruta = carrera.ruta
                });
               
            }
            return listaend;
        }
        /// <summary>
        /// Método para actualizar una caarrea
        /// </summary>
        /// <param name="carrera">Model con los datos de la carrera a actualizar</param>
        /// <param name="old">Model de la carrera vieja</param>
        public void UpdateCarrera(ModelCarrera carrera, ModelCarrera old)
        {
            _context.Entry(old).State = EntityState.Detached;
            _context.carreras.Update(carrera);
            _context.SaveChanges();
        }
    }
}
