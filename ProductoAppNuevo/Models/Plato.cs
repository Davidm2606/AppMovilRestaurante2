using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.Models
{
   public class Plato
    {
        public int IdPlato { get; set; }
        public string Nombre { get; set; }

        public string Ingredientes{ get; set; }

        public int Cantidad { get; set; }
        public int Precio { get; set; }

        public string urlImage { get; set; }
    }
}
