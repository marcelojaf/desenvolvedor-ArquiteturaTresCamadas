using CKLabs.Business.Models;

namespace CKLabs.Business.Interfaces
{
    /// <summary>
    /// Interface de serviço para Produto
    /// </summary>
    public interface IProdutoService : IDisposable
    {
        /// <summary>
        /// Método para adicionar um novo produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        Task Adicionar(Produto produto);

        /// <summary>
        /// Método para atualizar um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        Task Atualizar(Produto produto);

        /// <summary>
        /// Método para remover um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Remover(Guid id);
    }
}
