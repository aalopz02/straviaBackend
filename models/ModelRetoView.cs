using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class ModelRetoView
    {

        public String nombrereto { get; set; }

        [Column(TypeName = "Date")]
        public DateTime periodo_inicio { get; set; }
        [Column(TypeName = "Date")]
        public DateTime periodo_final { get; set; }

        public String tipoact { get; set; }

        public String tipo { get; set; }

        public String privacidad { get; set; }
     
        public String patrocinador { get; set; }
        public String logo { get; set; }
        public bool suscrito { get; set; }
    
    }

}
