using FluentValidation;

namespace CKLabs.Business.Models.Validations
{
    /// <summary>
    /// Classe de validação para o modelo <see cref="Endereco"/>
    /// </summary>
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EnderecoValidation()
        {
            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage(ValidationMessages.RequiredMessage())
                .Length(2, 200).WithMessage(ValidationMessages.LengthMessage());

            RuleFor(e => e.Numero)
                .NotEmpty().WithMessage(ValidationMessages.RequiredMessage())
                .Length(1, 50).WithMessage(ValidationMessages.LengthMessage());

            RuleFor(e => e.CEP)
                .NotEmpty().WithMessage(ValidationMessages.RequiredMessage())
                .Length(8).WithMessage(ValidationMessages.FixedLengthMessage());

            RuleFor(e => e.Bairro)
                .NotEmpty().WithMessage(ValidationMessages.RequiredMessage())
                .Length(2, 100).WithMessage(ValidationMessages.LengthMessage());

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage(ValidationMessages.RequiredMessage())
                .Length(2, 100).WithMessage(ValidationMessages.LengthMessage());

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage(ValidationMessages.RequiredMessage())
                .Length(2, 50).WithMessage(ValidationMessages.LengthMessage());
        }
    }
}
