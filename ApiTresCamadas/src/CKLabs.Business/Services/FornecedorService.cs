using CKLabs.Business.Interfaces;
using CKLabs.Business.Models;

namespace CKLabs.Business.Services
{
    /// <summary>
    /// Classe para os serviços de fornecedor
    /// </summary>
    public class FornecedorService : BaseService, IFornecedorService
    {
        /// <summary>
        /// Repositório de fornecedor
        /// </summary>
        private readonly IFornecedorRepository _fornecedorRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        /// <summary>
        /// Método para adicionar um fornecedor
        /// </summary>
        /// <param name="fornecedor"></param>
        /// <returns></returns>
        public async Task Adicionar(Fornecedor fornecedor)
        {
            // Validar se a entidade é consistente...
            // Validar se já existe um fornecedor com o mesmo documento cadastrado...

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        /// <summary>
        /// Método para atualizar um fornecedor
        /// </summary>
        /// <param name="fornecedor"></param>
        /// <returns></returns>
        public async Task Atualizar(Fornecedor fornecedor)
        {
            await _fornecedorRepository.Atualizar(fornecedor);
        }

        /// <summary>
        /// Método para remover um fornecedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Remover(Guid id)
        {
            await _fornecedorRepository.Remover(id);
        }

        /// <summary>
        /// Método para aplicar o Dispose no repositório e liberar recursos
        /// </summary>
        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }
    }
}
