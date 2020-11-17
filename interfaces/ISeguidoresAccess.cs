using models;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface ISeguidoresAccess
    {
        void AddSeguidor(ModelSiguiendo siguiendo);
        void DeleteSeguidor(string idelemento);
        ModelSiguiendo Getelemento(string idelemento);
        ModelUsuario GetSeguidor(string nombreusuario);
        List<ModelUsuario> GetSiguiendo(string nombreusuario);
    }
}
