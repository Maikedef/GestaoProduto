using FluentAssertions;
using GestaoProduto.Application.Exceptions;
using GestaoProduto.Application.UseCase.Produtos;
using GestaoProduto.Test.Utils.Mapper;
using GestaoProduto.Test.Utils.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GestaoProduto.Test.UseCase.Produtos
{
    public class ApplicationUseCaseProdutoTest
    {

        [Fact]
        public async Task Testar_Retorno_Sucesso_GetByID()
        {
            var applicationUseCaseProduto = CriarUseCase(1);
            var result = await applicationUseCaseProduto.GetByIDAsync(1);
            result.Should().NotBeNull();
        }

        [Fact]
        public async void Testar_Retorno_Excessao_NotFound_GetByID()
        {
            var applicationUseCaseProduto = CriarUseCase(0);

            Func<Task> action = async () =>
            {
                await applicationUseCaseProduto.GetByIDAsync(0);
            };

            await action.Should().ThrowAsync<ErroNaoEncontradoException>();
        }

        private ApplicationUseCaseProduto CriarUseCase(int id = 0)
        {
            var mapper = MapperBuilder.Instancia();
            var produtoRepository = ProdutoRepositoryBuilder.Instancia().GetByID(id).Construir();

            return new ApplicationUseCaseProduto(mapper, produtoRepository);
        }
    }
}
