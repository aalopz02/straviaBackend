using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class ModelActividad
    {
		[Key]
		public String idactividad { get; set; }
		public String nombreusuariofk { get; set; }

		[Column(TypeName = "Date")]
		public DateTime fecha { get; set; }
		public int duracionmin { get; set; }
		public int tipoactividad { get; set; }
		public int distanciakm { get; set; }
		public string dirrecorrido { get; set; }
		public String carreraoreto { get; set; }

	}
}
