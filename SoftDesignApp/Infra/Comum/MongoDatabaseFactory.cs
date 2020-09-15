using Dominio.Interface.Infra.Repositorio;
using MongoDB.Driver;

namespace Infra.Comum
{
    public class MongoDatabaseFactory : IMongoDatabaseFactory
    {
        public IMongoDatabase Connect(string connectionString, string dbName)
        {
            var dbClient = new MongoClient(connectionString);
            return dbClient.GetDatabase(dbName);
        }
    }
}
