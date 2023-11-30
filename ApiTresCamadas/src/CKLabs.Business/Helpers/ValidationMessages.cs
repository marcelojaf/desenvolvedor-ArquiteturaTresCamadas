namespace CKLabs.Business.Helpers
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
        public static string CampoObrigatório() => "O campo {PropertyName} precisa ser fornecido";

        /// <summary>
        /// Mensagem de campo com tamanho mínimo e máximo
        /// </summary>
        /// <returns></returns>
        public static string CampoComTamanhoErrado() => "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres";

        /// <summary>
        /// Mensagem de campo com tamanho inválido
        /// </summary>
        /// <returns></returns>
        public static string CampoPrecisaTerTamanhoFixo() => "O campo {PropertyName} precisa ter {MaxLength} caracteres";

        /// <summary>
        /// Mensagem de campo com valor inválido
        /// </summary>
        /// <returns></returns>
        public static string CampoPrecisaSerMaior() => "O campo {PropertyName} precisa ser maior que {ComparisonValue}";

        /// <summary>
        /// Mensagem de documento inválido
        /// </summary>
        /// <returns></returns>
        public static string DocumentoInvalido() => "O documento fornecido é inválido";

        /// <summary>
        /// Mensagem de fornecedor com documento já existente
        /// </summary>
        /// <returns></returns>
        public static string JaExisteFornecedorComDocumentoInformado() => "Já existe um fornecedor com este documento informado.";
    }
}
