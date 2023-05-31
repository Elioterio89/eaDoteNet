using RestAPIaspnet.Model;
using RestAPIaspnet.Services.Interfaces;

namespace RestAPIaspnet.Services
{
    public class PessoaService : IPessoaService
    {
        private volatile int gCount;

        public Pessoa BuscarPorId(long pId)
        {
            Pessoa oPessoa = new Pessoa();
            oPessoa.Id = IncrementarGet();
            oPessoa.Nome = "Eslei";
            oPessoa.Sobrenome = "Elioterio";
            oPessoa.Endereco ="Barra";
            oPessoa.Sexo = oPessoa.Id % 2 == 0 ? "Masculono" : "Feminino";

            return oPessoa;
        }

        public Pessoa BuscarPorNome(string pNome)
        {
            Pessoa oPessoa = new Pessoa();
            oPessoa.Id = IncrementarGet();
            oPessoa.Nome = "Eslei";
            oPessoa.Sobrenome = "Elioterio";
            oPessoa.Endereco = "Barra";
            oPessoa.Sexo = oPessoa.Id % 2 == 0 ? "Masculono" : "Feminino";

            return oPessoa;
        }

        public List<Pessoa> BuscarTodos()
        {
            List<Pessoa> lPessoas = new List<Pessoa>();

            for (int i = 0; i < 5; i++)
            {
                Pessoa oPessoa =MockPessoa(i);
                lPessoas.Add(oPessoa);

            }

            return lPessoas;
        }

        public Pessoa Criar(Pessoa pPessoa)
        {
            return pPessoa;
        }

        public Pessoa Editar(Pessoa pPessoa)
        {
            return pPessoa;
        }

        public bool Excluir(long pId)
        {
            Pessoa oPessoa = BuscarPorId(pId);
            if (oPessoa == null)
            {
                return false;
            }
            return true;
        }

        private Pessoa MockPessoa(int pI)
        {
            Pessoa oPessoa = new Pessoa();
            oPessoa.Id = IncrementarGet();
            oPessoa.Nome = "Eslei"+pI;
            oPessoa.Sobrenome = "Elioterio" + pI;
            oPessoa.Endereco = "Barra" + pI;
            oPessoa.Sexo = pI % 2 == 0 ? "Masculono" : "Feminino";

            return oPessoa;
        }

        private long IncrementarGet()
        {
            return Interlocked.Increment(ref gCount);
        }
    }
}
