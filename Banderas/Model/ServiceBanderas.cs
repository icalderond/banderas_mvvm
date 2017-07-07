using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Banderas.Model
{
    public class ServiceBanderas
    {
        const string URLBanderas = @"http://www.geognos.com/api/en/countries/info/all.json";
        const string URLImagen = @"http://www.geognos.com/api/en/countries/flag/{FLAG}.png";

        public event EventHandler<GenericEventArgs<Pais>> ObtenerBanderas_Completed;
        public void ObtenerBanderas(string _busqueda="")
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString(URLBanderas);

            JObject rss = JObject.Parse(reply);
            var resultView = rss.Values().ToList();

            List<string> listaPaisAbreviado = new List<string>();
            var listaElementos = resultView[1].ToArray();

            for (int i = 0; i < listaElementos.Count(); i++)
            {
                var item = listaElementos[i].ToString();
                var auxiliar = item.Substring(item.IndexOf("\"") + 1);
                var paisAbreviado = auxiliar.Substring(0, auxiliar.IndexOf("\""));
                listaPaisAbreviado.Add(paisAbreviado);
            }

            List<Pais> listaPaises = new List<Pais>();
            foreach (var item in listaPaisAbreviado)
            {
                var resultPais = resultView[1].SelectTokens(item);

                Pais pais = new Pais();
                pais.PaisAbreviado = item;
                pais.NombrePais = resultPais.Values("Name").Values().First().ToString();
                pais.UrlFoto = URLImagen.Replace("{FLAG}", item);

                var geolocal = resultPais.Values("GeoRectangle");
                pais.Geolocalizacion = new Geo()
                {
                    North = geolocal.Values("North").First().ToString(),
                    South = geolocal.Values("South").First().ToString(),
                    West = geolocal.Values("West").First().ToString(),
                    East = geolocal.Values("East").First().ToString()
                };
                listaPaises.Add(pais);
            }
            listaPaises = listaPaises
                .Where(item =>
                    item.NombrePais.ToLower().Contains(_busqueda.ToLower())
                ).ToList();
            ObtenerBanderas_Completed?.Invoke(this, new GenericEventArgs<Pais>(listaPaises));
        }
    }
}
