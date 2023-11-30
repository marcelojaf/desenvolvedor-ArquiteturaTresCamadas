using CKLabs.Business.Helpers;
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
                .NotEmpty().WithMessage(ValidationMessages.CampoObrigatório())
                .Length(2, 200).WithMessage(ValidationMessages.CampoComTamanhoErrado());

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage(ValidationMessages.CampoObrigatório())
                .Length(2, 1000).WithMessage(ValidationMessages.CampoComTamanhoErrado());

            RuleFor(p => p.Valor)
                .GreaterThan(0).WithMessage(ValidationMessages.CampoPrecisaSerMaior());
        }
    }
}
