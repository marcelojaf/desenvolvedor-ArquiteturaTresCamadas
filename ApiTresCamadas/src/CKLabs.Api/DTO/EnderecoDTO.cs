using System.ComponentModel.DataAnnotations;

namespace CKLabs.Api.DTO
{
    /// <summary>
    /// Classe de transformação de dados de um Endereço
    /// </summary>
    public class EnderecoDTO
    {
        /// <summary>
        /// Id do Endereço
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Logradouro do Endereço
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Logradouro { get; set; }

        /// <summary>
        /// Número do Endereço
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string? Numero { get; set; }

        /// <summary>
        /// Complemento do Endereço
        /// </summary>
        public string? Complemento { get; set; }

        /// <summary>
        /// Bairro do Endereço
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Bairro { get; set; }

        /// <summary>
        /// CEP do Endereço
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string? CEP { get; set; }

        /// <summary>
        /// Cidade do Endereço
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Cidade { get; set; }

        /// <summary>
        /// Estado do Endereço
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Estado { get; set; }

        /// <summary>
        /// Id do Fornecedor
        /// </summary>
        public Guid FornecedorId { get; set; }
    }
}
