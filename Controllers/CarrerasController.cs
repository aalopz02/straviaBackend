using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using models;
using straviaBackend.interfaces;

/*
 * 
 * {
"NombreCarrera":"testcar",
"Costo":1234,
"Ruta":"cerrodelamuerte",
"Tipo":"Competencia",
"CuentaPago":0987654321
}
 */

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

        [HttpPost]
        public void AddCarrera(String nombreCarrera,int Costo,String ruta,int Cuenta,String Fecha,String tipo)
        {
            ModelCarrera carrera = new ModelCarrera();
            carrera.Costo = Costo;
            carrera.CuentaPago = Cuenta;
            carrera.Fecha = Fecha;
            carrera.Ruta = ruta;
            carrera.Tipo = tipo;
            carrera.NombreCarrera = nombreCarrera;
            _dataAccessProvider.AddCarrera(carrera);
        }
        /*
        [HttpPost]
        public IActionResult Create([FromBody] ModelCarrera carrera)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                carrera.NombreCarrera = obj.ToString();
                _dataAccessProvider.AddCarrera(carrera);
                return Ok();
            }
            return BadRequest();
        }
        */
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
