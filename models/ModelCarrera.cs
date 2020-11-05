using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models {     
    public class ModelCarrera   
    {

        [Key]
        public String nombrecarrera { get; set; }

        public int costo { get; set; }

        public byte[] ruta { get; set; }

        public int tipoactividad { get; set; }

        public String privacidad { get; set; }

        public String fecha { get; set; }

        public int cuentapago{ get; set; }

    }
}