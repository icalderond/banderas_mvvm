using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banderas.Model
{
    public class Pais
    {
        public string PaisAbreviado { get; set; }
        public string UrlFoto { get; set; }
        public string NombrePais { get; set; }
        public Geo Geolocalizacion { get; set; }
    }
}
