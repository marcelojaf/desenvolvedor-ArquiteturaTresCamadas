using FluentValidation;

namespace CKLabs.Business.Models.Validations
{
    /// <summary>
    /// Classe de validação para o modelo <see cref="Produto"/>
    /// </summary>
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ProdutoValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage(ValidationMessages.RequiredMessage())
                .Length(2, 200).WithMessage(ValidationMessages.LengthMessage());

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage(ValidationMessages.RequiredMessage())
                .Length(2, 1000).WithMessage(ValidationMessages.LengthMessage());

            RuleFor(p => p.Valor)
                .GreaterThan(0).WithMessage(ValidationMessages.GreaterThanMessage());
        }
    }
}
