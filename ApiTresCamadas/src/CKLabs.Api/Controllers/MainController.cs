using CKLabs.Business.Interfaces;
using CKLabs.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace CKLabs.Api.Controllers
{
    /// <summary>
    /// Classe base para as controllers
    /// </summary>
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        /// <summary>
        /// Verifica se a operação teve sucesso na camada de negócio
        /// </summary>
        /// <returns></returns>
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        /// <summary>
        /// Retorna uma resposta customizada
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected ActionResult CustomResponse(HttpStatusCode httpStatusCode = HttpStatusCode.OK, object? result = null)
        {
            if (OperacaoValida())
            {
                return new ObjectResult(result)
                {
                    StatusCode = (int)httpStatusCode
                };
            }

            return BadRequest(new
            {
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        /// <summary>
        /// Retorna uma resposta customizada
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                NotificarErroModelInvalida(modelState);
            }

            return CustomResponse();
        }

        /// <summary>
        /// Insere uma notificação de erro de Model Invalida na coleção de notificações
        /// </summary>
        /// <param name="modelState"></param>
        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;

                NotificarErro(erroMsg);
            }
        }

        /// <summary>
        /// Insere uma notificação de erro na coleção de notificações
        /// </summary>
        /// <param name="mensagem"></param>
        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
