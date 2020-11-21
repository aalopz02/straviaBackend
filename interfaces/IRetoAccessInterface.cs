using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using straviaBackend.models;


namespace straviaBackend.interfaces
{
    public interface IRetoAccessInterface
    {
        void AddReto(ModelReto reto);
        void UpdateReto(ModelReto reto, ModelReto old);
        void DeleteReto(string nombreReto);
        ModelReto GetReto(string nombreReto);
        List<ModelReto> GetRetos();
        List<ModelRetoView> GetRetosForUser(string username);


    }
}
