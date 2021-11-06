using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrdenesCosmeticos.Client.Servicios
{
    public class Httpservice : IHttpservice
    {
        private readonly HttpClient http;

        public Httpservice(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var respuestaHttp = await http.GetAsync(url);
            if (respuestaHttp.IsSuccessStatusCode)
            {
                var respuesta = await DeserializarRespuesta<T>(respuestaHttp);
                return new HttpRespuesta<T>(respuesta,
                                            false,
                                            respuestaHttp);
            }
            else
            {
                return new HttpRespuesta<T>(default,
                                            true,
                                            respuestaHttp);
            }


            

        }

        public async Task<HttpRespuesta<object>> Post<T>(string url, T enviar)
        {
            try
            {
                var enviarJSON = JsonSerializer.Serialize(enviar);
                var enviarContent = new StringContent(enviarJSON,
                                                      Encoding.UTF8,
                                                      "application/json");
                var respuestaHTTP = await http.PostAsync(url, enviarContent);

                return new HttpRespuesta<object>(null,
                                                 !respuestaHTTP.IsSuccessStatusCode,
                                                 respuestaHTTP);
            }
            catch (System.Exception) { throw; }
        }
        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpRespuesta)
        {
                var RepuestaString = await httpRespuesta.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(RepuestaString,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
