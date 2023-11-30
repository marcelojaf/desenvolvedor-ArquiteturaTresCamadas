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
        }
    }
}
