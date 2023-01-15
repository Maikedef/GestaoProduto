using Bogus;
using Bogus.Extensions.Brazil;
using GestaoProduto.Application.Dtos.Produtos;

namespace Validators.Test.Utils.Produtos
{
    public static class InserirProdutoBuilder
    {
        public static  InserirProdutoDto Construir()
        {
            return new Faker<InserirProdutoDto>()
             .RuleFor(p => p.DescricaoProduto, f => f.Commerce.ProductName())
             .RuleFor(p => p.DataFabricacao, f => f.Date.Recent())
             .RuleFor(p => p.DataValidade, f => f.Date.Future())
             .RuleFor(p => p.IdFornecedor, f => f.Random.Int())
             .RuleFor(p => p.DescricaoFornecedor, f => f.Company.CompanyName())
             .RuleFor(p => p.CnpjFornecedor, f => f.Company.Cnpj());
        }
    }
}
