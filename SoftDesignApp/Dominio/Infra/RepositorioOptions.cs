namespace Dominio.Infra
{
    public class RepositorioOptions
    {
        public RepositorioOptions(string connectionString, string dbName, string collectionName)
        {
            ConnectionString = connectionString;
            DbName = dbName;
            CollectionName = collectionName;
        }

        public string ConnectionString { get; }
        public string DbName { get; }
        public string CollectionName { get; }
    }
}
