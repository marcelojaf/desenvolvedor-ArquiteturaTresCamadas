using CKLabs.Business.Models;

namespace CKLabs.Business.Interfaces
{
    /// <summary>
    /// Interface de repositório para Produto
    /// </summary>
    public interface IProdutoRepository : IRepository<Produto>
    {
        /// <summary>
        /// Obtem todos os produtos de um fornecedor
        /// </summary>
        /// <param name="fornecedorId"></param>
        /// <returns></returns>
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);

        /// <summary>
        /// Obtem todos os produtos e seus fornecedores
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();

        /// <summary>
        /// Obtem um produto e seu fornecedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
