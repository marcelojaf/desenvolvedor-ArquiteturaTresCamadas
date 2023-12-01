using CKLabs.Business.Enums;
using CKLabs.Business.Helpers;
using CKLabs.Business.Models.Validations.Documentos;
using FluentValidation;

namespace CKLabs.Business.Models.Validations
{
    /// <summary>
    /// Classe de validação para o modelo <see cref="Fornecedor"/>
    /// </summary>
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public FornecedorValidation()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage(ValidationMessages.CampoObrigatório())
                .Length(2, 200).WithMessage(ValidationMessages.CampoComTamanhoErrado());

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {

                RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage(ValidationMessages.CampoPrecisaTerTamanhoFixo());


                RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage(ValidationMessages.DocumentoInvalido());

            });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage(ValidationMessages.CampoPrecisaTerTamanhoFixo());
                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage(ValidationMessages.DocumentoInvalido());
            });
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
