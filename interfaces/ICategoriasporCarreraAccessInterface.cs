using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface ICategoriasporCarreraAccessInterface
    {
        void Addcat(Modelcategoriasporcarrera cat);
        void DeleteCat(int categoria, string nombrecarrera);
        List<Modelcategoriasporcarrera> GetAll();
        List<Modelcategoriasporcarrera> GetCats(string nombrecarrera);
    }
}
