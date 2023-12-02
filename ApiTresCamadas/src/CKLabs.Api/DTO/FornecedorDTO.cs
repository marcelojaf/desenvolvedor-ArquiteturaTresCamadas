namespace CKLabs.Api.DTO
{
    /// <summary>
    /// Classe de transformação de dados de um Fornecedor
    /// </summary>
    public class FornecedorDTO
    {
        /// <summary>
        /// Id do Fornecedor
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do Fornecedor
        /// </summary>
        public string? Nome { get; set; }

        /// <summary>
        /// Documento do Fornecedor
        /// </summary>
        public string? Documento { get; set; }

        /// <summary>
        /// Tipo de documento do Fornecedor
        /// </summary>
        public int TipoFornecedor { get; set; }

        /// <summary>
        /// Indica se o Fornecedor está ativo
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Endereço do Fornecedor
        /// </summary>
        public EnderecoDTO? Endereco { get; set; }

        /// <summary>
        /// Produtos do Fornecedor
        /// </summary>
        public IEnumerable<ProdutoDTO>? Produtos { get; set; }
    }
}
