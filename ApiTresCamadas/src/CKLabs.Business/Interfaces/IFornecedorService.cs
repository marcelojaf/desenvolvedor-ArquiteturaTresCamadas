using CKLabs.Business.Models;

namespace CKLabs.Business.Interfaces
{
    /// <summary>
    /// Interface de serviço para Fornecedor
    /// </summary>
    public interface IFornecedorService : IDisposable
    {
        /// <summary>
        /// Método para adicionar um novo fornecedor
        /// </summary>
        /// <param name="fornecedor"></param>
        /// <returns></returns>
        Task Adicionar(Fornecedor fornecedor);

        /// <summary>
        /// Método para atualizar um fornecedor
        /// </summary>
        /// <param name="fornecedor"></param>
        /// <returns></returns>
        Task Atualizar(Fornecedor fornecedor);

        /// <summary>
        /// Método para remover um fornecedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Remover(Guid id);
    }
}
