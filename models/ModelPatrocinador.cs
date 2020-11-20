using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class ModelPatrocinador
    {
        [Key]
        public int idpat { get; set; }

        public String nombre { get; set; }

        public String representante { get; set; }

        public int telefono { get; set; }

        public String logo { get; set; }

    }
}
