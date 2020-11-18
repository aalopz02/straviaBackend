using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class ModelSiguiendo
    {
        [Key]
        public string idelemento { get; set; }

        public string nombreusuariofk { get; set; }

        public string nombreusuariosiguiendofk { get; set; }
    }
}
