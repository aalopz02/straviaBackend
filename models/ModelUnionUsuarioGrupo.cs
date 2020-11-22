using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class ModelUnionUsuarioGrupo
    {
        public String idgrupo { get; set; }

        public String nombreusuario { get; set; }

        [Key]
        public String idunion { get; set; }
    }
}
