using MongoDB.Driver;

namespace Dominio.Interface.Infra.Repositorio
{
    public interface IMongoDatabaseFactory
    {
        IMongoDatabase Connect(string connectionString, string dbName);
    }
}
