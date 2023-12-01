using CKLabs.Business.Interfaces;
using CKLabs.Business.Models;
using CKLabs.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CKLabs.Data.Repository
{
    /// <summary>
    /// Classe genérica para repositório
    /// </summary>
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        /// <summary>
        /// DbContext
        /// </summary>
        protected readonly MeuDbContext Db;

        /// <summary>
        /// DbSet da entidade
        /// </summary>
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        /// <summary>
        /// Adiciona uma entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        /// <summary>
        /// Atualiza uma entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        /// <summary>
        /// Obtem uma entidade por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            var result = await DbSet.FindAsync(id);

            if (result == null)
            {
                throw new Exception("Registro não encontrado");
            }

            return result;
        }

        /// <summary>
        /// Obtem todas as entidades
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        /// <summary>
        /// Obtém uma lista de entidades por um predicado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await DbSet.AsNoTracking().Where(predicate).ToListAsync();

            if (result == null)
            {
                throw new Exception("Registro não encontrado");
            }

            return result;
        }

        /// <summary>
        /// Remove uma entidade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });

            await SaveChanges();
        }

        /// <summary>
        /// Salva as alterações
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        /// <summary>
        /// Libera os recursos da memória para o garbage collector
        /// </summary>
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
