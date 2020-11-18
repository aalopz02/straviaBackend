using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models {     
    public class ModelInscripcionCarrera 
    {

        public String nombrecarrera { get; set; }

        public String nombreusuario { get; set; }

        public String recibo { get; set; }

        [Key]
        public String idinscar { get; set; }

    }
}