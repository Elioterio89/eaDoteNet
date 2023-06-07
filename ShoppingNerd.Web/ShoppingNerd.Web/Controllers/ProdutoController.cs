using Microsoft.AspNetCore.Mvc;
using ShoppingNerd.Web.Services.Interfaces;

namespace ShoppingNerd.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService pProdutoService)
        {
            _produtoService = pProdutoService ?? throw new ArgumentNullException(nameof(_produtoService));
        }

        public async Task<IActionResult> Index()
        {
            var lProdutos = await _produtoService.BuscarTodos();
            return View(lProdutos);
        }
    }
}
