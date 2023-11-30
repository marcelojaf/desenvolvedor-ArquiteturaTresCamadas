using CKLabs.Business.Enums;

namespace CKLabs.Business.Models
{
    /// <summary>
    /// Classe que representa a entidade 'Fornecedor'
    /// </summary>
    public class Fornecedor : BaseEntity
    {
        /// <summary>
        /// Nome do Fornecedor
        /// </summary>
        public string? Nome { get; set; }

        /// <summary>
        /// Documento do Fornecedor
        /// </summary>
        public string? Documento { get; set; }

        /// <summary>
        /// Tipo do Fornecedor
        /// </summary>
        public TipoFornecedor TipoFornecedor { get; set; }

        /// <summary>
        /// Endereço do Fornecedor
        /// </summary>
        public Endereco? Endereco { get; set; }



        /* EF Relations */

        /// <summary>
        /// Lista de Produtos do Fornecedor
        /// </summary>
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
