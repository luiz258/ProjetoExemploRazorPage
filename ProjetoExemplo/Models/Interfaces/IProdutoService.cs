using ProjetoExemplo.Models.dto;
using System.Collections.Generic;

namespace ProjetoExemplo.Models.Interfaces
{
    public interface IProdutoService
    {
        Task Salvar(Produto modelo);
        Task Editar(Produto modelo);
        Task Deletar(Produto modelo);
    }
}
