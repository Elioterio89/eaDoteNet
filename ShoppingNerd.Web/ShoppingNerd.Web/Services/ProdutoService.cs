using ShoppingNerd.Web.Models;
using ShoppingNerd.Web.Services.Interfaces;
using ShoppingNerd.Web.Utils;

namespace ShoppingNerd.Web.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly HttpClient _httpClient;
        public const string cBasePath = "api/v1/produto";

        public ProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Produto> BuscaPorId(long pId)
        {
            var lResponse = await _httpClient.GetAsync($"{cBasePath}/{pId}");
            return await lResponse.ReadContentAs<Produto>();
        }

        public async Task<Produto> BuscaPorNome(string pNome)
        {
            var lResponse = await _httpClient.GetAsync($"{cBasePath}/nome/{pNome}");
            return await lResponse.ReadContentAs<Produto>();
        }    

        public async Task<IEnumerable<Produto>> BuscarTodos()
        {
            var lResponse = await _httpClient.GetAsync(cBasePath);
            return await lResponse.ReadContentAs<List<Produto>>();
        }

        public async Task<Produto> Criar(Produto pProduto)
        {
            var lResponse = await _httpClient.PostAsJson($"{cBasePath}", pProduto);
            if (lResponse.IsSuccessStatusCode)
            {
                return await lResponse.ReadContentAs<Produto>();
            }
            else
            {
                throw new Exception("Algo deu errado na chamada da API");
            }
         
        }

        public async Task<Produto> Editar(Produto pProduto)
        {
            var lResponse = await _httpClient.PutAsJson($"{cBasePath}", pProduto);
            if (lResponse.IsSuccessStatusCode)
            {
                return await lResponse.ReadContentAs<Produto>();
            }
            else
            {
                throw new Exception("Algo deu errado na chamada da API");
            }
        }

        public async Task<bool> Excluir(long pId)
        {
            var lResponse = await _httpClient.DeleteAsync($"{cBasePath}/{pId}");
            if (lResponse.IsSuccessStatusCode)
            {
                return await lResponse.ReadContentAs<bool>();
            }
            else
            {
                throw new Exception("Algo deu errado na chamada da API");
            }
         
        }
    }
}
