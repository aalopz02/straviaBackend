using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models {     
    public class ModelUsuario   
    {        

        [Key]
        public String NombreUsuario { get; set; }

        public String Contraseña { get; set; }

        public String Fname { get; set; }

        public String Mname { get; set; }

        public String Lname { get; set; }

        public String FechaNacimiento { get; set; }

        public String Nacionalidad { get; set; }

        public int Nsiguiendo{ get; set; }

        public int Nseguidores { get; set; }


    }
}