using AutoMapper;
using GestaoProduto.Application.Dtos.Produtos;
using GestaoProduto.Application.Exceptions;
using GestaoProduto.Application.Interfaces.Produtos;
using GestaoProduto.Domain.Entities.Produtos;
using GestaoProduto.Domain.Repository.Produtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProduto.Application.UseCase.Produtos
{
    public class ApplicationUseCaseProduto : IApplicationUseCaseProduto
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ApplicationUseCaseProduto(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var produto = await GetByIDAsync(id);

            if(produto is null)
            {
                throw new ErroNaoEncontradoException("Produto não encontrado!");
            }

            await _produtoRepository.DeleteAsync(id);
            return "Produto excluido com êxito";
        }

        public async Task<RetornarListaProdutosPaginadoDto> GetAllAsync(int pagina, int limite, string descricaoProduto = "")
        {
            if(limite > 25)
            {
                limite = 25;
            }

            var totalRegistro = await _produtoRepository.GetCountAll(descricaoProduto);
            var produtos = await _produtoRepository.GetAllAsync(pagina, limite, descricaoProduto);
            var retornoProdutoDto = _mapper.Map<List<RetornarProdutoDto>>(produtos.ToList());

            return new RetornarListaProdutosPaginadoDto
            {
                TotalRegistros = totalRegistro,
                Produtos = retornoProdutoDto
            };
        }

        public async Task<RetornarProdutoDto> GetByIDAsync(int id)
        {
            var produto = await _produtoRepository.GetByIDAsync(id);

            if(produto is null)
            {
                throw new ErroNaoEncontradoException("Produto não encontrado!");
            }

            return _mapper.Map<RetornarProdutoDto>(produto);
        }

        public async Task<string> InsertAsync(InserirProdutoDto inputProdutoDto)
        {
            var produto = _mapper.Map<Produto>(inputProdutoDto);
            await _produtoRepository.InsertAsync(produto);
            return "Produto cadastrado com êxito";
        }

        public async Task<string> UpdateAsync(AtualizarProdutoDto inputProdutoDto)
        {
            var produto = await _produtoRepository.GetByIDAsync(inputProdutoDto.Id);

            if (produto is null)
            {
                throw new ErroNaoEncontradoException("Produto não encontrado!");
            }

            var prod = _mapper.Map<Produto>(inputProdutoDto);
            await _produtoRepository.UpdateAsync(prod);
            return "Produto atualizado com êxito";
        }
    }
}
