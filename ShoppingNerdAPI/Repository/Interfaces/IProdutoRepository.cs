using ShoppingNerdAPI.Data.ValueObjects;

namespace ShoppingNerdAPI.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoVO>> BuscaTodos();
        Task<ProdutoVO> BuscaPorId(long pId);
        Task<ProdutoVO> BuscaPorNome(string pNome);
        Task<ProdutoVO> Criar(ProdutoVO pProduto);
        Task<ProdutoVO> Editar(ProdutoVO pProduto);
        Task<bool> Excluir(long pId);
    }
}
