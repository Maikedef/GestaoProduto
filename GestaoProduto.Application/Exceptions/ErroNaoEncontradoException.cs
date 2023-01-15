namespace GestaoProduto.Application.Exceptions
{
    public  class ErroNaoEncontradoException : GestaoProdutoException
    {
        public ErroNaoEncontradoException() { }
        public ErroNaoEncontradoException(string mensagem) : base(mensagem)
        {
        }
    }
}
