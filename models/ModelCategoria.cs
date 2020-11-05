using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class ModelCategoria
    {
        [Key]
        public int idcat { get; set; }

        public String nombre { get; set; }

        public String rango { get; set; }
    }
}
