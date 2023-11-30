using CKLabs.Business.Interfaces;
using CKLabs.Business.Models;

namespace CKLabs.Business.Services
{
    /// <summary>
    /// Classe para os serviços de produto
    /// </summary>
    public class ProdutoService : BaseService, IProdutoService
    {
        /// <summary>
        /// Repositório de produto
        /// </summary>
        private readonly IProdutoRepository _produtoRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Método para adicionar um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Adicionar(Produto produto)
        {
            await _produtoRepository.Adicionar(produto);
        }

        /// <summary>
        /// Método para atualizar um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Atualizar(Produto produto)
        {
            await _produtoRepository.Atualizar(produto);
        }

        /// <summary>
        /// Método para remover um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }

        /// <summary>
        /// Método para aplicar o Dispose no repositório e liberar recursos
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
