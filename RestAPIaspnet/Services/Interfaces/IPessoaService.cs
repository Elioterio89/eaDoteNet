using RestAPIaspnet.Model;

namespace RestAPIaspnet.Services.Interfaces
{
    public interface IPessoaService
    {
        Pessoa Criar(Pessoa pPessoa);
        Pessoa BuscarPorId(long pId);
        Pessoa BuscarPorNome(string pNome);
        List<Pessoa> BuscarTodos();
        Pessoa Editar(Pessoa pPessoa);
        bool Excluir(long pId);

    }
}
