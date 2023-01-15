using FluentValidation;
using GestaoProduto.Application.Dtos.Produtos;

namespace GestaoProduto.Application.Validations.Produtos
{
    public class InserirProdutoValidation : AbstractValidator<InserirProdutoDto>
    {
        public InserirProdutoValidation()
        {
            RuleFor(prod => prod.DescricaoProduto).NotEmpty().WithMessage("A descrição do produto é obrigatório.");
            RuleFor(prod => prod.DataValidade).GreaterThan(prod => prod.DataFabricacao).WithMessage("Data de fabricação não pode ser maior ou igual a data de validade!");
        }
    }
}
