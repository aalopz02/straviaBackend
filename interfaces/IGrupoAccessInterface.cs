using models;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface IGrupoAccessInterface
    {
        void AddGrupo(ModelGrupo grupo);
        void UpdateGrupo(ModelGrupo grupo);
        void DeleteGrupo(string idGrupo);
        List<ModelGrupo> GetGrupo(string nombreGrupo);
        List<ModelGrupo> GetGrupos();
        List<ModelGrupoView> GetGruposForUser(string username);
    }
}
