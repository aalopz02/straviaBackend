using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface ITipoActAccessInterface
    {
        List<ModelTipoActividad> GetActs();
        ModelTipoActividad GetActividad(int idact);
    }
}
