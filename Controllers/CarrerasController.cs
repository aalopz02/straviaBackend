using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using models;
using straviaBackend.interfaces;


namespace straviaBackend.Controllers
{
    [Route("api/[controller]")]
    public class CarrerasController : ControllerBase
    {
        private readonly ICarreraAccessInterface _dataAccessProvider;

        public CarrerasController(ICarreraAccessInterface dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<ModelCarrera> Get()
        {
            return _dataAccessProvider.GetCarreras();
        }

        [HttpPost("{ruta,patrocinadores}")]
        public void AddCarrera(String nombreCarrera,int Costo,int Cuenta,String Fecha,String tipo,byte[] ruta,String patrocinadores)
        {
            List<int> listaIds = new List<int>();
            foreach (string idpatrocinador in patrocinadores.Split(".")) listaIds.Add(int.Parse(idpatrocinador));

            ModelCarrera carrera = new ModelCarrera
            {
                costo = Costo,
                cuentapago = Cuenta,
                fecha = Fecha,
                ruta = ruta,
                tipo = tipo,
                nombrecarrera = nombreCarrera,
                patrocinadores = listaIds
            };
            _dataAccessProvider.AddCarrera(carrera);
        }

        [HttpGet("{nombreCarrera}")]
        public ModelCarrera Details(string nombreCarrera)
        {
            return _dataAccessProvider.GetCarrera(nombreCarrera);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] ModelCarrera carrera) 
        {
            if (ModelState.IsValid)
            {
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
