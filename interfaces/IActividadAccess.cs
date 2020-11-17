using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface IActividadAccess
    {
        void AddActividad(ModelActividad actividad);
        ModelActividad GetActividad(string idactividad);
        List<ModelActividad> GetActividades(string nombreusuario);

    }
}
