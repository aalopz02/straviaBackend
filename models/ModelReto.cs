using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models {     
    public class ModelReto   
    {

        [Key]
        public String nombrereto { get; set; }

        [Column(TypeName = "Date")]
        public DateTime periodo_inicio { get; set; }
        [Column(TypeName = "Date")]
        public DateTime periodo_final { get; set; }

        public int tipoact { get; set; }

        public String tipo { get; set; }

        public String privacidad { get; set; }


    }
}