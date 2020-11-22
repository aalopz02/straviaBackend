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

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="dataAccessProvider"> Acceso a carreras </param>
        /// <param name="pats"> Acceso a patrocinadores por carrera</param>
        /// <param name="cats"> Acceso a categorias por carrera</param>
        public CarrerasController(ICarreraAccessInterface dataAccessProvider,
                                    IPatrociandorporCarreraAccessInterface pats,
                                    ICategoriasporCarreraAccessInterface cats)
        {
            _dataAccessProvider = dataAccessProvider;
            _pats = pats;
            _cats = cats;
        }

        /// <summary>
        /// Get de las carreras para un usuario
        /// </summary>
        /// <param name="username">Usuario a consultar</param>
        /// <returns>Modelo con los datos de la carrera</returns>
        [HttpGet]
        public IEnumerable<ModelCarreraView> Get(string username)
        {
            return _dataAccessProvider.GetCarreras(username);
        }

        /// <summary>
        /// post de carrera nueva
        /// </summary>
        /// <param name="nombreCarrera"></param>
        /// <param name="Costo"></param>
        /// <param name="Cuenta"></param>
        /// <param name="Fecha"></param>
        /// <param name="privacidad"></param>
        /// <param name="idtipo"></param>
        /// <param name="patrocinadores"></param>
        /// <param name="categorias"></param>
        /// <param name="rutacarrera"> Json con la ruta en string de la carrera</param>
        [HttpPost]//String nombreCarrera,int Costo,int Cuenta,String Fecha,String privacidad, int idtipo, String patrocinadores,String categorias
        public void AddCarrera(String nombreCarrera, int Costo, int Cuenta, DateTime Fecha, String privacidad, int idtipo, String patrocinadores, String categorias,[FromBody] FileModel rutacarrera)
        {
            ModelCarrera carrera = new ModelCarrera
            {
                costo = Costo,
                cuentapago = Cuenta,
                fecha = Fecha,
                ruta = mist.ProcessSaveFiles.saveRutaCarrera(rutacarrera,nombreCarrera),
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

        /// <summary>
        /// Get para una carrera
        /// </summary>
        /// <param name="nombreCarrera"></param>
        /// <returns>Carrera obtenido por nombre</returns>
        [HttpGet("{nombreCarrera}")]
        public ModelCarrera Details(string nombreCarrera)
        {
            return _dataAccessProvider.GetCarrera(nombreCarrera);
        }

        /// <summary>
        /// Modificar carrera
        /// </summary>
        /// <param name="nombreCarrera"></param>
        /// <param name="Costo"></param>
        /// <param name="Cuenta"></param>
        /// <param name="Fecha"></param>
        /// <param name="privacidad"></param>
        /// <param name="idtipo"></param>
        /// <param name="patrocinadores"></param>
        /// <param name="categorias"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit(String nombreCarrera, int Costo, int Cuenta, DateTime Fecha, String privacidad, int idtipo, String patrocinadores, String categorias, [FromBody] FileModel file)
        {
            ModelCarrera old = _dataAccessProvider.GetCarrera(nombreCarrera);
            int idtipoact;
            if (idtipo == 0)
            {
                idtipoact = old.tipoactividad;
            }
            else {
                idtipoact = idtipo;
            }
            string rutanueva;
            if (file.file != null)
            {
                rutanueva = mist.ProcessSaveFiles.saveRutaCarrera(file, nombreCarrera);
            }
            else
            {
                rutanueva = old.ruta;
            }

                ModelCarrera carrera = new ModelCarrera
                {
                    costo = Costo,
                    cuentapago = Cuenta,
                    fecha = Fecha,
                    privacidad = privacidad,
                    nombrecarrera = nombreCarrera,
                    tipoactividad = idtipoact,
                    ruta = rutanueva
                };
                if (patrocinadores != null)
                {
                    foreach (string idpatrocinador in patrocinadores.Split("."))
                    {
                        _pats.Update(new models.Modelpatrocinadoresporcarrera
                        {
                            idelemento = carrera.nombrecarrera + idpatrocinador,
                            patrocinador = int.Parse(idpatrocinador),
                            nombrecarrerafk = carrera.nombrecarrera
                        });
                    }
                }

                if (categorias != null) {
                    foreach (string idcat in categorias.Split("."))
                    {
                        _cats.Update(new models.Modelcategoriasporcarrera
                        {
                            idelemento = carrera.nombrecarrera + idcat,
                            categoria = int.Parse(idcat),
                            nombrecarrerafk = carrera.nombrecarrera
                        });
                    }
                    
                }
            _dataAccessProvider.UpdateCarrera(carrera, old);
            return Ok();
        }

        /// <summary>
        /// Borrar carrera
        /// </summary>
        /// <param name="nombreCarrera"></param>
        [HttpDelete]
        public void Delete(string nombreCarrera)
        {
            var data = _dataAccessProvider.GetCarrera(nombreCarrera);
            try
            {
                _dataAccessProvider.DeleteCarrera(nombreCarrera);
            }
            catch (InvalidOperationException) {
                
            }
            
        }
    }
}
