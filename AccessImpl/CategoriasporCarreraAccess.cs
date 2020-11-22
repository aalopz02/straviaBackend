using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    /// <summary>
    /// Access para el manejo de categorías de carrera
    /// </summary>
    public class CategoriasporCarreraAccess : ICategoriasporCarreraAccessInterface
    {
        private readonly StravaContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public CategoriasporCarreraAccess(StravaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para añadir categoríaas
        /// </summary>
        /// <param name="cat">Model de la categoría a añadir</param>
        public void Addcat(Modelcategoriasporcarrera cat)
        {
            _context.categoriasporcarrera.Add(cat);
            _context.SaveChanges();
        }
        /// <summary>
        /// Método para eliminar una categoría 
        /// </summary>
        /// <param name="categoria">Id de la categoría a eliminar</param>
        /// <param name="nombrecarrera">Nombre de la carrera con categoría</param>
        public void DeleteCat(int categoria, string nombrecarrera)
        {
            var entity = _context.categoriasporcarrera.FirstOrDefault(t => (t.idelemento == nombrecarrera + categoria.ToString()));
            _context.categoriasporcarrera.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método get de las categorias por carrera
        /// </summary>
        /// <returns>Lista de categorías por carrera</returns>
        public List<Modelcategoriasporcarrera> GetAll()
        {
            return _context.categoriasporcarrera.ToList();
        }

        /// <summary>
        /// Método get de categoría por nombre de carrera
        /// </summary>
        /// <param name="nombrecarrera">Nombre de carrera a la que se desea obtener categorías</param>
        /// <returns>Lista de categorías para la carrera</returns>
        public List<Modelcategoriasporcarrera> GetCats(string nombrecarrera)
        {
            List<Modelcategoriasporcarrera> result = new List<Modelcategoriasporcarrera>();
            foreach (Modelcategoriasporcarrera entiy in GetAll())
            {
                if (entiy.nombrecarrerafk  == nombrecarrera)
                {
                    result.Add(entiy);
                }
            }
            return result;
        }
        /// <summary>
        /// Método para actualizar categorías por carrera
        /// </summary>
        /// <param name="cat">Model categoría por carrera a actualizar</param>
        public void Update(Modelcategoriasporcarrera cat)
        {
            _context.categoriasporcarrera.Update(cat);
            _context.SaveChanges();
        }
    }
}
