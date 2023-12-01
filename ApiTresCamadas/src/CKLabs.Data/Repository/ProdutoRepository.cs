using CKLabs.Business.Interfaces;
using CKLabs.Business.Models;
using CKLabs.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CKLabs.Data.Repository
{
    /// <summary>
    /// Classe de repositório para Produto
    /// </summary>
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        public ProdutoRepository(MeuDbContext db) : base(db)
        {

        }


        /// <summary>
        /// Obtem um Produto e seu Fornecedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Db.Produtos.AsNoTracking()
                                    .Include(f => f.Fornecedor)
                                    .FirstOrDefaultAsync(p => p.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Obtem todos os Produtos e seus Fornecedores
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(f => f.Fornecedor)
                                    .OrderBy(p => p.Nome)
                                    .ToListAsync();
        }

        /// <summary>
        /// Obtem todos os Produtos de um Fornecedor
        /// </summary>
        /// <param name="fornecedorId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
