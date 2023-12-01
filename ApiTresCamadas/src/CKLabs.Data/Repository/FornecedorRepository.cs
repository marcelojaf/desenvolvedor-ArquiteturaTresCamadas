using CKLabs.Business.Interfaces;
using CKLabs.Business.Models;
using CKLabs.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CKLabs.Data.Repository
{
    /// <summary>
    /// Classe de repositório para Fornecedor
    /// </summary>
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        public FornecedorRepository(MeuDbContext db) : base(db)
        {
        }

        /// <summary>
        /// Obtem um Fornecedor e seu Endereço
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Db.Fornecedores.AsNoTracking()
                                        .Include(f => f.Endereco)
                                        .FirstOrDefaultAsync(f => f.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Obtem um Fornecedor, seus Produtos e seu Endereço
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Db.Fornecedores.AsNoTracking()
                                        .Include(f => f.Endereco)
                                        .Include(f => f.Produtos)
                                        .FirstOrDefaultAsync(f => f.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Obtem um Endereço de um Fornecedor
        /// </summary>
        /// <param name="fornecedorId"></param>
        /// <returns></returns>
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Db.Enderecos.AsNoTracking()
                                     .FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Remove um Endereço de um Fornecedor
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public async Task RemoverEnderecoFornecedor(Endereco endereco)
        {
            Db.Enderecos.Remove(endereco);
            await SaveChanges();
        }
    }
}
