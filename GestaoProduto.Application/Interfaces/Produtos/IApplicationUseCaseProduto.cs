using GestaoProduto.Application.Dtos.Produtos;
using System.Threading.Tasks;

namespace GestaoProduto.Application.Interfaces.Produtos
{
    public interface IApplicationUseCaseProduto
    {
        Task<string> DeleteAsync(int id);

        Task<RetornarListaProdutosPaginadoDto> GetAllAsync(int pular, int limite, string descricaoProduto = "");

        Task<RetornarProdutoDto> GetByIDAsync(int id);

        Task<string> InsertAsync(InserirProdutoDto inputProdutoDto);

        Task<string> UpdateAsync(AtualizarProdutoDto inputProdutoDto);
    }
}
