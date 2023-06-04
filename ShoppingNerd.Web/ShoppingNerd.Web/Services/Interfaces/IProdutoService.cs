using ShoppingNerd.Web.Models;

namespace ShoppingNerd.Web.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> BuscarTodos();
        Task<Produto> BuscaPorId(long pId);
        Task<Produto> BuscaPorNome(string pNome);
        Task<Produto> Criar(Produto pProduto);
        Task<Produto> Editar(Produto pProduto);
        Task<bool> Excluir(long pId);

    }
}
