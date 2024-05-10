using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoExemplo.Models.Interfaces;
using ProjetoExemplo.Models;

namespace ProjetoExemplo.Pages
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public Produto produto { get; set; }

        private readonly IProdutoRepository _produtoRepository;

        public DetailsModel(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository; 
        }
        public async Task<IActionResult> OnGetAsync(Guid? itemid)
        {

            if (itemid == Guid.Empty) return NotFound();

            var itemProduto = await _produtoRepository.BuscaPorId(itemid.Value);

            if (itemProduto == null) return NotFound();

            produto = itemProduto;
            return Page();
        }
    }
}
