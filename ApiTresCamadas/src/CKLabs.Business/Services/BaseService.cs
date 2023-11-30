using CKLabs.Business.Interfaces;
using CKLabs.Business.Models;
using CKLabs.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace CKLabs.Business.Services
{
    /// <summary>
    /// Classe base para os serviços
    /// </summary>
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="notificador"></param>
        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        /// <summary>
        /// Inclui uma ou mais notificações de um <see cref="ValidationResult"/>
        /// </summary>
        /// <param name="validationResult"></param>
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        /// <summary>
        /// Inclui uma nova notificação
        /// </summary>
        /// <param name="mensagem"></param>
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        /// <summary>
        /// Executar uma validação de forma genérica
        /// </summary>
        /// <typeparam name="TV">AbstractValidator</typeparam>
        /// <typeparam name="TE">BaseEntity</typeparam>
        /// <param name="validacao"></param>
        /// <param name="entidade"></param>
        /// <returns></returns>
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE>
            where TE : BaseEntity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
