using models;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface ICarreraAccessInterface
    {
        void AddCarrera(ModelCarrera carrera);
        void UpdateCarrera(ModelCarrera carrera);
        void DeleteCarrera(string nombreCarrera);
        ModelCarrera GetCarrera(string nombreCarrera);
        List<ModelCarreraView> GetCarreras(string username);
    }
}
