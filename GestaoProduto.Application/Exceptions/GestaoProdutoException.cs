using System;

namespace GestaoProduto.Application.Exceptions
{
    public class GestaoProdutoException : Exception
    {
        public GestaoProdutoException() { }
        public GestaoProdutoException(string message) : base(message) { }
    }
}
