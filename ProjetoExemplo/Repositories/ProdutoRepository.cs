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

        public async Task SalvarAsync(Produto modelo)
        {
            await _context.Produtos.AddAsync(modelo);
            await _context.SaveChangesAsync();
        }

        public async Task EditarAsync(Produto modelo)
        {
            _context.Set<Produto>().Update(modelo);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> BuscaPorId(Guid id)
        {
           return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteAsync(Produto modelo)
        {
            _context.Remove(modelo);
            await _context.SaveChangesAsync();
        }
    }
}
