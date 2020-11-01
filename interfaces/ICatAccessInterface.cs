using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface ICatAccessInterface
    {
        public ModelCategoria GetCat(int idcat);

        public List<ModelCategoria> GetCats();
    }
}
