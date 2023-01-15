using GestaoProduto.Domain.Entities.Produtos;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProduto.Domain.Repository.Produtos
{
    public interface IProdutoRepository
    {
        Task<Produto> GetByIDAsync(int id);

        Task<IQueryable<Produto>> GetAllAsync(int pagina, int limite, string descricaoProduto = "");

        Task InsertAsync(Produto produto);

        Task UpdateAsync(Produto produto);

        Task DeleteAsync(int id);
        Task<int> GetCountAll(string descricaoProduto = "");
    }
}
