using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models {     
    public class ModelCarrera   
    {        
    
        //public List<String> Posiciones { get; set; }        
    
        public int costo { get; set; }

        [Key]
        public String nombrecarrera { get; set; }

        public byte[] ruta { get; set; }

        public String tipo { get; set; }

        public String fecha{ get; set; }

        public int cuentapago{ get; set; }

        public List<ModelCategoria> categorias { get; set; }

        public List<int> patrocinadores { get; set; }

    }
}