using FluentAssertions;
using GestaoProduto.Application.Validations.Produtos;
using Validators.Test.Utils.Produtos;
using Xunit;

namespace Validators.Test.Produtos
{
    public class InserirProdutoTest
    {
        [Fact]
        public void Validar_Erro_Descricao_Produto_vazio()
        {
            var validator = new InserirProdutoValidation();

            var produto = InserirProdutoBuilder.Construir();
            produto.DescricaoProduto = "";

            var resultado = validator.Validate(produto);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage.Equals("A descrição do produto é obrigatório."));
        }

        [Fact]
        public void Validar_Erro_DataFabricacao_Igual_DataValidade()
        {
            var validator = new InserirProdutoValidation();

            var produto = InserirProdutoBuilder.Construir();
            produto.DataValidade = produto.DataFabricacao;

            var resultado = validator.Validate(produto);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage.Equals("Data de fabricação não pode ser maior ou igual a data de validade!"));
        }

        [Fact]
        public void Validar_Erro_DataFabricacao_Maior_DataValidade()
        {
            var validator = new InserirProdutoValidation();

            var produto = InserirProdutoBuilder.Construir();
            produto.DataFabricacao = produto.DataValidade.AddDays(5);

            var resultado = validator.Validate(produto);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage.Equals("Data de fabricação não pode ser maior ou igual a data de validade!"));
        }
    }
}
