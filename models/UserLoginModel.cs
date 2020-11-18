using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models {     
    public class UserLoginModel   
    {        
   
        public String nombreusuario { get; set; }

        public String contraseña { get; set; }
    }
}