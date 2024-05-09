using ProjetoExemplo.Models.dto;
using System.Collections.Generic;

namespace ProjetoExemplo.Models.Interfaces
{
    public interface IProdutoService
    {
        Task Salvar(ProdutoDto modelo);
        Task Editar(ProdutoDto modelo);
    }
}
