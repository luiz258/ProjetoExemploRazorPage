using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoExemplo.Models.Interfaces;
using ProjetoExemplo.Models;

namespace ProjetoExemplo.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Produto produto { get; set; }

        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;

        public DeleteModel(IProdutoRepository produtoRepository, IProdutoService produtoService)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
        }
        public async Task<IActionResult> OnGetAsync(Guid? itemid)
        {

            if (itemid == Guid.Empty) return NotFound();

            var itemProduto = await _produtoRepository.BuscaPorId(itemid.Value);

            if (itemProduto == null) return NotFound();

            produto = itemProduto;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid itemid)
        {
            if (itemid == null) return NotFound();

            var item = await _produtoRepository.BuscaPorId(itemid);

            if(item == null) return NotFound();

            produto = item;

            await _produtoService.Deletar(item);

            return RedirectToPage(nameof(Index));
        }
    }
}
