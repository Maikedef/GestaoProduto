using GestaoProduto.Domain.Entities.Produtos;
using GestaoProduto.Domain.Repository.Produtos;
using Moq;

namespace GestaoProduto.Test.Utils.Repository
{
    public class ProdutoRepositoryBuilder
    {
        private static ProdutoRepositoryBuilder _instancia;

        private readonly Mock<IProdutoRepository> _produtoRepository;

        private ProdutoRepositoryBuilder()
        {
            _produtoRepository = new Mock<IProdutoRepository>();
        }

        public static ProdutoRepositoryBuilder Instancia()
        {
            _instancia = new ProdutoRepositoryBuilder();
            return _instancia;
        }

        public ProdutoRepositoryBuilder GetByID(int id)
        {
            if(id == 0)
            {
                _produtoRepository.Setup(i => i.GetByIDAsync(id)).ReturnsAsync((Produto)null);
            }
            else
            {
                _produtoRepository.Setup(i => i.GetByIDAsync(id)).ReturnsAsync(new Produto());
            }
           
            return this;
        }

        public IProdutoRepository Construir()
        {
            return _produtoRepository.Object;
        }
    }
}
