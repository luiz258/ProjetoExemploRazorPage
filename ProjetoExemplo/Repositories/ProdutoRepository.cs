using Microsoft.EntityFrameworkCore;
using ProjetoExemplo.Data;
using ProjetoExemplo.Models;
using ProjetoExemplo.Models.Interfaces;

namespace ProjetoExemplo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;
        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Produto>> BuscarTodos(decimal Valor = 0, string Nome = null)
        {
            IQueryable<Produto> query = _context.Set<Produto>();

            if (!string.IsNullOrEmpty(Nome))
            {
                query = query.Where(p => p.Nome.Contains(Nome));
            }

            if (Valor > 0)
            {
                query = query.Where(p => p.Valor == Valor);
            }

            return await query.Take(10).ToListAsync();
        }

        public async Task SalvarAsync(Produto model)
        {
            await _context.Produtos.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task EditarAsync(Produto model)
        {
            _context.Set<Produto>().Update(model);
            await _context.SaveChangesAsync();
        }

        public Task<Produto> BuscaPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
