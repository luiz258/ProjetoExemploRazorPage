using ProjetoExemplo.Models.dto;

namespace ProjetoExemplo.Models.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> BuscaPorId(Guid id);
        Task<IEnumerable<Produto>> BuscarTodos(decimal Valor = 0, string Nome = null);
        Task SalvarAsync(Produto modelo);
        Task EditarAsync(Produto modelo);
        Task DeleteAsync(Produto modelo);
    }
}
