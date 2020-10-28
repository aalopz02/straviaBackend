using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models {     
    public class ModelCarrera   
    {        
    
        //public List<String> Posiciones { get; set; }        
    
        public int Costo { get; set; }

        [Key]
        public String NombreCarrera { get; set; }

        public String Ruta { get; set; }

        public String Tipo { get; set; }

        public String Fecha{ get; set; }

        public int CuentaPago{ get; set; }

        //public List<Categorias> Categorias { get; set; }

        //public List<Usuarios> Usuarios { get; set; }

    }
}