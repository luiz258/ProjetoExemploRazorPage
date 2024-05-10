using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoExemplo.Models;
using ProjetoExemplo.Models.Interfaces;

namespace ProjetoExemplo.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Produto produto { get; set; }

        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;

        public EditModel(IProdutoRepository produtoRepository, IProdutoService produtoService)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;   
        }
        public async Task<IActionResult> OnGetAsync(Guid itemid)
        {

            if(itemid == Guid.Empty) return NotFound();

            var itemProduto = await _produtoRepository.BuscaPorId(itemid);

            if (itemProduto == null) return NotFound();

            produto = itemProduto;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {

            if(!ModelState.IsValid) return Page();

            await _produtoService.Editar(produto);

            return RedirectToPage(nameof(Index));
        }
    }
}
