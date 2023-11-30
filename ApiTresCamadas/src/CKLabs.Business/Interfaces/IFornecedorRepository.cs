using CKLabs.Business.Models;

namespace CKLabs.Business.Interfaces
{
    /// <summary>
    /// Interface de repositório para Fornecedor
    /// </summary>
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        /// <summary>
        /// Obtem todos um fornecedor e seu endereço
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);

        /// <summary>
        /// Obtem todos um fornecedor, seus produtos e seu endereço
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);

        /// <summary>
        /// Obtem um endereço de um fornecedor
        /// </summary>
        /// <param name="fornecedorId"></param>
        /// <returns></returns>
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);

        /// <summary>
        /// Remove um endereço de um fornecedor
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        Task RemoverEnderecoFornecedor(Endereco endereco);
    }
}
