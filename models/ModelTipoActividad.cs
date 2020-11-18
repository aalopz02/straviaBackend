using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class ModelTipoActividad
    {
        [Key]
        public int idact { get; set; }

        public String nombre { get; set; }
    }
}
