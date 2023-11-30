namespace CKLabs.Business.Models
{
    /// <summary>
    /// Classe que representa a entidade 'Produto'
    /// </summary>
    public class Produto : BaseEntity
    {
        /// <summary>
        /// Nome do produto
        /// </summary>
        public string? Nome { get; set; }

        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Valor do produto
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Id do Fornecedor do produto
        /// </summary>
        public Guid FornecedorId { get; set; }



        /* EF Relations */

        /// <summary>
        /// Fornecedor do produto
        /// </summary>
        public Fornecedor Fornecedor { get; set; }
    }
}
