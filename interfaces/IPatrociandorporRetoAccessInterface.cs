using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface IPatrociandorporRetoAccessInterface
    {
        void AddPatReto(Modelpatrocinadoresporreto patreto);
        void DeletePatReto(int patrocinador,string nombrereto);
        List<Modelpatrocinadoresporreto> GetPatsReto();
        List<Modelpatrocinadoresporreto> GetModelpatrocinadoresporreto(string nombrereto);
        public void UpdateReto(Modelpatrocinadoresporreto patreto);
    }
}
