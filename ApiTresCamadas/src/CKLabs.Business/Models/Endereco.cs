namespace CKLabs.Business.Models
{
    /// <summary>
    /// Classe que representa a entidade 'Endereco'
    /// </summary>
    public class Endereco : BaseEntity
    {
        /// <summary>
        /// Id do fornecedor ao qual o endereço pertence
        /// </summary>
        public Guid FornecedorId { get; set; }

        /// <summary>
        /// Logradouro do endereço
        /// </summary>
        public string? Logradouro { get; set; }

        /// <summary>
        /// Número do endereço
        /// </summary>
        public string? Numero { get; set; }

        /// <summary>
        /// Complemento do endereço
        /// </summary>
        public string? Complemento { get; set; }

        /// <summary>
        /// CEP do endereço
        /// </summary>
        public string? CEP { get; set; }

        /// <summary>
        /// Bairro do endereço
        /// </summary>
        public string? Bairro { get; set; }

        /// <summary>
        /// Cidade do endereço
        /// </summary>
        public string? Cidade { get; set; }

        /// <summary>
        /// Estado do endereço
        /// </summary>
        public string? Estado { get; set; }

        /* EF Relations */

        /// <summary>
        /// Fornecedor ao qual o endereço pertence
        /// </summary>
        public Fornecedor Fornecedor { get; set; }
    }
}
