using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models {     
    public class ModelUsuario   
    {        

        [Key]
        public String nombreusuario { get; set; }

        public String contraseña { get; set; }

        public String fname { get; set; }

        public String mname { get; set; }

        public String lname { get; set; }

        public String fechanacimiento { get; set; }

        public String nacionalidad { get; set; }

        public int nsiguiendo{ get; set; }

        public int nseguidores { get; set; }


    }
}