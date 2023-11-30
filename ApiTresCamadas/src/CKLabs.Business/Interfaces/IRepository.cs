using CKLabs.Business.Models;
using System.Linq.Expressions;

namespace CKLabs.Business.Interfaces
{
    /// <summary>
    /// Interface de repositório genérico
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        /// <summary>
        /// Adiciona uma entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Adicionar(TEntity entity);

        /// <summary>
        /// Atualiza uma entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Atualizar(TEntity entity);

        /// <summary>
        /// Remove uma entidade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Remover(Guid id);

        /// <summary>
        /// Obtem uma entidade por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> ObterPorId(Guid id);

        /// <summary>
        /// Obtem todas as entidades
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> ObterTodos();

        /// <summary>
        /// Obtem todas as entidades com filtro
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Salva as alterações
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChanges();
    }
}
