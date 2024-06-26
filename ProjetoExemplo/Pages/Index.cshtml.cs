using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoExemplo.Models;
using ProjetoExemplo.Models.dto;
using ProjetoExemplo.Models.Interfaces;
using ProjetoExemplo.Repositories;

namespace ProjetoExemplo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IProdutoService _produtoService;
        private readonly IProdutoRepository _produtoRepository;

        public IEnumerable<Produto> Produtos { get; set; }
        public ProdutoDto Filtro { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IProdutoService produtoService, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoService = produtoService;
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {

            Produtos = await _produtoRepository.BuscarTodos();

            return Page();

        }

        private async Task<IActionResult> OnPostAsync()
        {
            var lista = await _produtoRepository.BuscarTodos(Filtro.Valor.Value, Filtro.Nome);
            Produtos = lista;

            return Page();
        }
    }
}
