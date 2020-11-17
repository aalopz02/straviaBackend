using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class ModelSearchUserView
    {
        public String nombreusuario { get; set; }

        public String fname { get; set; }

        public String mname { get; set; }

        public String lname { get; set; }

        public String nacionalidad { get; set; }

        public String imagenperfil { get; set; }

        public bool siguiendo { get; set; }
    }
}
