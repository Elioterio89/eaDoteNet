using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ShoppingNerd.Web.Utils
{
    public static class HttpClienteExtensions
    {

        private static MediaTypeHeaderValue gContentType = new MediaTypeHeaderValue("application/json");
        public static async Task<T> ReadContentAs<T>(
            this HttpResponseMessage pResponse)
        {
            if (!pResponse.IsSuccessStatusCode) throw
                    new ApplicationException($"Algo deu errado na chamada da API: " +
                    $"{pResponse.ReasonPhrase}");
            var vDataAsString = await pResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(vDataAsString,new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient pHttpClient , string pUrl, T pData)
        {

            var vDataAsString = JsonSerializer.Serialize(pData);
            var vContent = new StringContent(vDataAsString);
            vContent.Headers.ContentType = gContentType;
            return pHttpClient.PostAsync(pUrl, vContent);

        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient pHttpClient, string pUrl, T pData)
        {

            var vDataAsString = JsonSerializer.Serialize(pData);
            var vContent = new StringContent(vDataAsString);
            vContent.Headers.ContentType = gContentType;
            return pHttpClient.PutAsync(pUrl, vContent);

        }
    }
}
