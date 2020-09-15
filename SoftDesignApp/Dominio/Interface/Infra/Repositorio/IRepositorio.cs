using MongoDB.Driver;
using System;
using System.Linq.Expressions;

namespace Dominio.Interface.Infra.Repositorio
{
    public interface IRepositorio<TEntity>
    {
        string CollectionName { get; }

        IFindFluent<TEntity, TEntity> Find(FilterDefinition<TEntity> filter);
        IFindFluent<TEntity, TEntity> Find(Expression<Func<TEntity, bool>> filter);
        void Insert(TEntity entity);
        TEntity FindOneAndReplaceAsync(FilterDefinition<TEntity> filter, TEntity entity);
        TEntity FindOneAndReplaceAsync(Expression<Func<TEntity, bool>> filter, TEntity entity);
        DeleteResult Remove(Expression<Func<TEntity, bool>> filter);
    }
}
