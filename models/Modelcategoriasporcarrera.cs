using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class Modelcategoriasporcarrera
    {
        [Key]
        public string idelemento { get; set; }

        //[ForeignKey("idcat")]
        //public ModelCategoria categorias { get; set; }

        //[ForeignKey("nombrecarrera")]
        //public ModelCarrera carreras { get; set; }

        public int categoria { get; set; }

        //public string nombrecarrera { get; set; }

        //public int idcat { get; set; }

        public string nombrecarrerafk { get; set; }
    }
}
