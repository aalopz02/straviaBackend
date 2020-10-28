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
            _context.Carreras.Add(carrera);
            _context.SaveChanges();
        }

        public void DeleteCarrera(string nombreCarrera)
        {
            var entity = _context.Carreras.FirstOrDefault(t => t.NombreCarrera == nombreCarrera);
            _context.Carreras.Remove(entity);
            _context.SaveChanges();
        }

        public ModelCarrera GetCarrera(string nombreCarrera)
        {
            return _context.Carreras.FirstOrDefault(t => t.NombreCarrera == nombreCarrera);
        }

        public List<ModelCarrera> GetCarreras()
        {
            return _context.Carreras.ToList();
        }

        public void UpdateCarrera(ModelCarrera carrera)
        {
            _context.Carreras.Update(carrera);
            _context.SaveChanges();
        }
    }
}
