using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using models;
using straviaBackend.interfaces;
using straviaBackend.models;

namespace straviaBackend.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class CarrerasController : ControllerBase
    {
        private readonly ICarreraAccessInterface _dataAccessProvider;
        private readonly IPatrociandorporCarreraAccessInterface _pats;
        private readonly ICategoriasporCarreraAccessInterface _cats;

        public CarrerasController(ICarreraAccessInterface dataAccessProvider,
                                    IPatrociandorporCarreraAccessInterface pats,
                                    ICategoriasporCarreraAccessInterface cats)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            _cats = cats;
        }

        [HttpGet]
        public IEnumerable<ModelCarreraView> Get(string username)
        {
            return _dataAccessProvider.GetCarrerasForUser(username);
        }

        //https://localhost:44379/api/Carreras?nombreCarrera=lacarrera&Costo=12345&Cuenta=1234567890&Fecha=fecha&privacidad=publico&idtipo=1&ruta=0&patrocinadores=1.2&categorias=1.2.3
        [HttpPost]//String nombreCarrera,int Costo,int Cuenta,String Fecha,String privacidad, int idtipo, byte[] ruta,String patrocinadores,String categorias
        public void AddCarrera(String nombreCarrera, int Costo, int Cuenta, String Fecha, String privacidad, int idtipo, string ruta, String patrocinadores, String categorias)
        {
            ModelCarrera carrera = new ModelCarrera
            {
                costo = Costo,
                cuentapago = Cuenta,
                fecha = Fecha,
                ruta = ruta,
                privacidad = privacidad,
                nombrecarrera = nombreCarrera,
                tipoactividad = idtipo
            };
            _dataAccessProvider.AddCarrera(carrera);
            foreach (string idpatrocinador in patrocinadores.Split("."))
            {
                _pats.AddPat(new models.Modelpatrocinadoresporcarrera
                {
                    idelemento = carrera.nombrecarrera + idpatrocinador,
                    patrocinador = int.Parse(idpatrocinador),
                    nombrecarrerafk = carrera.nombrecarrera
                });
            }
            foreach (string idcat in categorias.Split("."))
            {
                _cats.Addcat(new models.Modelcategoriasporcarrera
                {
                    idelemento = carrera.nombrecarrera + idcat,
                    categoria = int.Parse(idcat),
                    nombrecarrerafk = carrera.nombrecarrera
                });
            }
        }

        [HttpGet("{nombreCarrera}")]
        public ModelCarrera Details(string nombreCarrera)
        {
            return _dataAccessProvider.GetCarrera(nombreCarrera);
        }

        [HttpPut]
        public IActionResult Edit(String nombreCarrera, int Costo, int Cuenta, String Fecha, String privacidad, int idtipo, string ruta, String patrocinadores, String categorias) 
        {
            if (ModelState.IsValid)
            {
                ModelCarrera carrera = new ModelCarrera
                {
                    costo = Costo,
                    cuentapago = Cuenta,
                    fecha = Fecha,
                    ruta = ruta,
                    privacidad = privacidad,
                    nombrecarrera = nombreCarrera,
                    tipoactividad = idtipo
                };
                foreach (string idpatrocinador in patrocinadores.Split("."))
                {
                    _pats.Update(new models.Modelpatrocinadoresporcarrera
                    {
                        idelemento = carrera.nombrecarrera + idpatrocinador,
                        patrocinador = int.Parse(idpatrocinador),
                        nombrecarrerafk = carrera.nombrecarrera
                    });
                }
                foreach (string idcat in categorias.Split("."))
                {
                    _cats.Update(new models.Modelcategoriasporcarrera
                    {
                        idelemento = carrera.nombrecarrera + idcat,
                        categoria = int.Parse(idcat),
                        nombrecarrerafk = carrera.nombrecarrera
                    });
                }
                _dataAccessProvider.UpdateCarrera(carrera);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{nombreCarrera}")]
        public IActionResult DeleteConfirmed(string nombreCarrera)
        {
            var data = _dataAccessProvider.GetCarrera(nombreCarrera);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteCarrera(nombreCarrera);
            return Ok();
        }
    }
}
