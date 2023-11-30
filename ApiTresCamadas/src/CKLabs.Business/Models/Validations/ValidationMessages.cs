
namespace CKLabs.Business.Models.Validations
{
    /// <summary>
    /// Classe de mensagens de validação
    /// </summary>
    public static class ValidationMessages
    {
        /// <summary>
        /// Mensagem de campo obrigatório
        /// </summary>
        /// <returns></returns>
        public static string RequiredMessage() => "O campo {PropertyName} precisa ser fornecido";

        /// <summary>
        /// Mensagem de campo com tamanho mínimo e máximo
        /// </summary>
        /// <returns></returns>
        public static string LengthMessage() => "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres";

        /// <summary>
        /// Mensagem de campo com tamanho inválido
        /// </summary>
        /// <returns></returns>
        public static string FixedLengthMessage() => "O campo {PropertyName} precisa ter {MaxLength} caracteres";

        /// <summary>
        /// Mensagem de campo com valor inválido
        /// </summary>
        /// <returns></returns>
        public static string GreaterThanMessage() => "O campo {PropertyName} precisa ser maior que {ComparisonValue}";

        /// <summary>
        /// Mensagem de documento inválido
        /// </summary>
        /// <returns></returns>
        public static string InvalidDocumentMessage() => "O documento fornecido é inválido";
    }
}
