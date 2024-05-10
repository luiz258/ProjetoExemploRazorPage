using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoExemplo.Models;
using ProjetoExemplo.Models.dto;
using ProjetoExemplo.Models.Interfaces;
using System.Threading.Tasks;

namespace ProjetoExemplo.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Produto produto { get; set; }

        private readonly IProdutoService _produtoService;
        public CreateModel(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid || produto == null)
            {
                return Page();
            }

            await _produtoService.Salvar(produto);
            return RedirectToPage(nameof(Index));
        }
    }
}
