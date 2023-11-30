using CKLabs.Business.Helpers;
using CKLabs.Business.Interfaces;
using CKLabs.Business.Models;
using CKLabs.Business.Models.Validations;

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
        public FornecedorService(IFornecedorRepository fornecedorRepository, INotificador notificador) : base(notificador)
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
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar(ValidationMessages.JaExisteFornecedorComDocumentoInformado());
                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        /// <summary>
        /// Método para atualizar um fornecedor
        /// </summary>
        /// <param name="fornecedor"></param>
        /// <returns></returns>
        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar(ValidationMessages.JaExisteFornecedorComDocumentoInformado());
                return;
            }

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        /// <summary>
        /// Método para remover um fornecedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Remover(Guid id)
        {
            var fornecedor = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);

            if (fornecedor == null)
            {
                Notificar("Fornecedor não encontrado");
                return;
            }

            if (fornecedor.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados");
                return;
            }

            var endereco = await _fornecedorRepository.ObterEnderecoPorFornecedor(id);

            if (endereco != null)
            {
                await _fornecedorRepository.RemoverEnderecoFornecedor(endereco);
            }

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
