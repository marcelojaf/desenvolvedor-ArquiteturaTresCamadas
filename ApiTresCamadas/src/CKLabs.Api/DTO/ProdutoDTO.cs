using System.ComponentModel.DataAnnotations;

namespace CKLabs.Api.DTO
{
    /// <summary>
    /// Classe de transformação de dados de um Produto
    /// </summary>
    public class ProdutoDTO
    {
        /// <summary>
        /// Id do Produto
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do Produto
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Nome { get; set; }

        /// <summary>
        /// Descrição do Produto
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Descricao { get; set; }

        /// <summary>
        /// Valor do Produto
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        /// <summary>
        /// Data de Cadastro do Produto
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Indica se o Produto está ativo
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Id do Fornecedor
        /// </summary>
        public Guid FornecedorId { get; set; }

        /// <summary>
        /// Nome do Fornecedor
        /// </summary>
        public string? NomeFornecedor { get; set; }
    }
}
