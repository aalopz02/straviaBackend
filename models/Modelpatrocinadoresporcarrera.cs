﻿using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class Modelpatrocinadoresporcarrera
    {
        [Key]
        public string idelemento { get; set; }

        //[ForeignKey("idpat")]
        //public ModelPatrocinador patrocinadores { get; set; }

        //[ForeignKey("nombrecarrera")]
        //public ModelCarrera carreras { get; set; }

        //public int idpat { get; set; }

        public string nombrecarrerafk { get; set; }

        public int patrocinador { get; set; }

        //public string nombrecarrera { get; set; }
    
    }
}
