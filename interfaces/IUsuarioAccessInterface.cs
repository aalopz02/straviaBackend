using models;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface IUsuarioAccessInterface
    {
        void AddUsuario(ModelUsuario usuario);
        void UpdateUsuario(ModelUsuario usuario);
        void DeleteUsuario(string NombreUsuario);
        List<ModelSearchUserView> GetUsuarios(string busqueda, string usuario);
        ModelUsuario GetUsuario(string NombreUsuario);
        
    }
}
