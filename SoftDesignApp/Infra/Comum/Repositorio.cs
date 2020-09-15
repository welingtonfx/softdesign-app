using Dominio.Interface.Infra.Repositorio;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Comum
{
    public class Repositorio<TEntity>: IRepositorio<TEntity>
    {
        private readonly IMongoCollection<TEntity> _collection;

        public Repositorio(IMongoCollection<TEntity> collection)
        {
            _collection = collection;

            this.CollectionName = collection.CollectionNamespace.CollectionName;
        }

        public string CollectionName { get; private set; }

        public IFindFluent<TEntity, TEntity> Find(FilterDefinition<TEntity> filter)
        {
            return _collection.Find(filter);
        }
        public IFindFluent<TEntity, TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return _collection.Find(filter);
        }

        public void Insert(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public TEntity FindOneAndReplaceAsync(FilterDefinition<TEntity> filter, TEntity entity)
        {
            return _collection.FindOneAndReplace(filter, entity);
        }
        public TEntity FindOneAndReplaceAsync(Expression<Func<TEntity, bool>> filter, TEntity entity)
        {
            return _collection.FindOneAndReplace(filter, entity);
        }

        public DeleteResult Remove(Expression<Func<TEntity, bool>> filter)
        {
            return _collection.DeleteOne(filter);
        }
    }
}
