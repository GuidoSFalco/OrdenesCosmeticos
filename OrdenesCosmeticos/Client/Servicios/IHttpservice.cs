using System.Threading.Tasks;

namespace OrdenesCosmeticos.Client.Servicios
{
    public interface IHttpservice
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
        Task<HttpRespuesta<object>> Post<T>(string url, T enviar);
    }
}