using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models {     
    public class ModelGrupo   
    {

        public String nombregrupo { get; set; }

        public String nombreusuario { get; set; }

        [Key]
        public String idgrupo { get; set; }

    }
}