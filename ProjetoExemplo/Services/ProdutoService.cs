using ProjetoExemplo.Models;
using ProjetoExemplo.Models.dto;
using ProjetoExemplo.Models.Interfaces;

namespace ProjetoExemplo.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Task Editar(ProdutoDto modelo)
        {
            throw new NotImplementedException();
        }

        public async Task Salvar(ProdutoDto model)
        {
            var form = new Produto { Id = new Guid(), Nome = model.Nome, Valor = model.Valor};
            await _produtoRepository.SalvarAsync(form);
        }
    }
}
