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

        public async Task Deletar(Produto modelo)
        {
           await _produtoRepository.DeleteAsync(modelo);
        }

        public async Task Editar(Produto modelo)
        {
            await _produtoRepository.EditarAsync(modelo); ;
        }

        public async Task Salvar(Produto model)
        {
            var form = new Produto { Id = new Guid(), Nome = model.Nome, Valor = model.Valor};
            await _produtoRepository.SalvarAsync(form);
        }
    }
}
