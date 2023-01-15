using AutoMapper;
using GestaoProduto.Application.Mapper.Produtos;

namespace GestaoProduto.Test.Utils.Mapper
{
    public class MapperBuilder
    {
        public static IMapper Instancia()
        {
            var configuracao = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProdutoMapper>();
            });

            return configuracao.CreateMapper();
        }
    }
}
