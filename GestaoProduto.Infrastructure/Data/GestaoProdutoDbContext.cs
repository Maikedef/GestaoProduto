using GestaoProduto.Domain.Entities.Produtos;
using GestaoProduto.Infrastructure.Data.Mapping.Produtos;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Infrastructure.Data
{
    public class GestaoProdutoDbContext: DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public GestaoProdutoDbContext(DbContextOptions<GestaoProdutoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
        }
    }
}
