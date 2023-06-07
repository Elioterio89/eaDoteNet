using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingNerdAPI.Data.ValueObjects;
using ShoppingNerdAPI.Model.Base;
using ShoppingNerdAPI.Repository.Interfaces;

namespace ShoppingNerdAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository pProdutoRepository)
        {
            _produtoRepository = pProdutoRepository ?? throw new ArgumentNullException(nameof(pProdutoRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoVO>>> BuscaProdutos()
        {
            var lProduto = await _produtoRepository.BuscaTodos();
            if (lProduto == null)
            {
                return NotFound();
            }
            return Ok(lProduto);
        }

        [HttpGet("{pId}")]
        public async Task<ActionResult<ProdutoVO>> BuscaProdutoPorId(long pId)
        {
            var oProduto = await _produtoRepository.BuscaPorId(pId);
            if (oProduto.Id <= null)
            {
                return NotFound();
            }
            return Ok(oProduto);
        }

        [HttpGet("nome/{pNome}")]
        public async Task<ActionResult<ProdutoVO>> BuscaProdutoPorNome(string pNome)
        {
            var oProduto = await _produtoRepository.BuscaPorNome(pNome);
            if (oProduto == null)
            {
                return NotFound();
            }
            return Ok(oProduto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoVO>> CriarProduto([FromBody] ProdutoVO pProdutoVO)
        {
            if (pProdutoVO == null)
            {
                return BadRequest();
            }
            var oProduto = await _produtoRepository.Criar(pProdutoVO);
            return Ok(oProduto);
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoVO>> EditarProduto([FromBody] ProdutoVO pProdutoVO)
        {
            if (pProdutoVO == null)
            {
                return BadRequest();
            }
            var oProduto = await _produtoRepository.Editar(pProdutoVO);
            return Ok(oProduto);
        }

        [HttpDelete("{pId}")]
        public async Task<ActionResult<ProdutoVO>> ExcluirProduto(long pId)
        {
            var vStatus = await _produtoRepository.Excluir(pId);
            if (!vStatus)
            {
                return BadRequest();
            }
            return Ok(vStatus);
        }
    }
}