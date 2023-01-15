using AutoMapper;
using GestaoProduto.Application.Dtos.Produtos;
using GestaoProduto.Domain.Entities.Produtos;

namespace GestaoProduto.Application.Mapper.Produtos
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<InserirProdutoDto, Produto>();
            CreateMap<Produto, RetornarProdutoDto>()
                .ForMember(opp => opp.SituacaoProduto, option => option.MapFrom(x => x.SituacaoProduto.ToString()));

            CreateMap<AtualizarProdutoDto, Produto>();
        }
    }
}
