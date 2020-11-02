using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface IPatrociandorporCarreraAccessInterface
    {
        void AddPat(Modelpatrocinadoresporcarrera pat);
        void DeletePat(int patrocinador,string nombrecarrera);
        List<Modelpatrocinadoresporcarrera> GetPats();
        List<Modelpatrocinadoresporcarrera> GetModelpatrocinadoresporcarrera(string nombrecarrera);
    }
}
