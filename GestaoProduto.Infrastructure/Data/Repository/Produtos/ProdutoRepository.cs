using GestaoProduto.Domain.Entities.Produtos;
using GestaoProduto.Domain.Repository.Produtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProduto.Infrastructure.Data.Repository.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly GestaoProdutoDbContext _context;

        public ProdutoRepository(GestaoProdutoDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            var produto = await GetByIDAsync(id);
            produto.Delete();
            await _context.SaveChangesAsync();
        }

        public Task<IQueryable<Produto>> GetAllAsync(int pular, int limite, string descricaoProduto = "")
        {
            return Task.FromResult(_context.Produtos.AsNoTracking().Where(x => x.DescricaoProduto.Contains(descricaoProduto)).Skip(pular).Take(limite));
        }

        public async Task<Produto> GetByIDAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<int> GetCountAll(string descricaoProduto = "")
        {
            return await _context.Produtos.AsNoTracking().Where(x => x.DescricaoProduto.Contains(descricaoProduto)).CountAsync();
        }

        public async Task InsertAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            var produtoAtual = await GetByIDAsync(produto.Id);
            produtoAtual.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
