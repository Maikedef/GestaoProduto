using GestaoProduto.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GestaoProduto.API.Filtro
{
    public class FiltroException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ErroNaoEncontradoException)
            {
                TratarExceptionNaoEncontrado(context);
            }
            else
            {
                LancarExceptionDesconhecido(context);
            }
        }

        private void TratarExceptionNaoEncontrado(ExceptionContext context)
        {
            var erroNaoEncontradoException = context.Exception as ErroNaoEncontradoException;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Result = new ObjectResult(new { Mensagem = erroNaoEncontradoException.Message });
        }
        private void LancarExceptionDesconhecido(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new {Mensagem="Erro desconhecido"});
        }
    }
}
