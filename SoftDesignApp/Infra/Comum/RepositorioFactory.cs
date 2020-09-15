using Dominio.Infra;
using Dominio.Interface.Infra.Repositorio;

namespace Infra.Comum
{
    public class RepositorioFactory : IRepositorioFactory
    {
        private readonly IMongoDatabaseFactory _dbFactory;

        public RepositorioFactory(IMongoDatabaseFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public IRepositorio<TEntity> Create<TEntity>(RepositorioOptions options)
        {
            var db = _dbFactory.Connect(options.ConnectionString, options.DbName);
            return new Repositorio<TEntity>(db.GetCollection<TEntity>(options.CollectionName));
        }
    }
}
