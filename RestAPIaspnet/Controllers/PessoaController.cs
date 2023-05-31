using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestAPIaspnet.Model;
using RestAPIaspnet.Services.Interfaces;
using System.Security.Cryptography;

namespace RestAPIaspnet.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {

        private readonly ILogger<PessoaController> _logger;
        private IPessoaService _pessoaService;

        public PessoaController(ILogger<PessoaController> pLogger , IPessoaService pPessoaService)
        {
            _logger = pLogger;
            _pessoaService = pPessoaService;
        }

        [HttpGet]
        public IActionResult BuscarTodos() 
        {
            return Ok(_pessoaService.BuscarTodos());
        }

        [HttpGet("{pId}")]
        public IActionResult BuscarPorId(long pId)
        {
            Pessoa oPessoa = _pessoaService.BuscarPorId(pId);
            if (oPessoa == null)
            {
                return NotFound();
            }
            return Ok(oPessoa);
        }

        [HttpGet("{pNome}")]
        public IActionResult BuscarPorNome(string pNome)
        {
            Pessoa oPessoa = _pessoaService.BuscarPorNome(pNome);
            if (oPessoa == null)
            {
                return NotFound();
            }
            return Ok(oPessoa);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Pessoa pPessoa)
        {
            if (pPessoa == null)
            {
                return BadRequest();
            }
            return Ok(_pessoaService.Criar(pPessoa));
        }

        [HttpPut]
        public IActionResult Editar([FromBody] Pessoa pPessoa)
        {
            if (pPessoa == null)
            {
                return BadRequest();
            }
            return Ok(_pessoaService.Editar(pPessoa));
        }


        [HttpDelete("{pId}")]
        public IActionResult Excluir(long pId)
        {
            
            return Ok(_pessoaService.Excluir(pId));
        }
    }
}
