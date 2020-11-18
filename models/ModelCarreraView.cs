using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.models
{
    public class ModelCarreraView
    {
		public String nombrecarrera { get; set; }
		public int costo { get; set; }
		public String fecha { get; set; }
		public int cuentapago { get; set; }
		public String tipoactividad { get; set; }
		public String patrocinador { get; set; }
		public String categoria { get; set; }
		public bool suscrito { get; set; }
	}
}
