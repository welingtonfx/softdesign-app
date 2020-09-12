using Dominio.Interface.Infra;

namespace Infra.Comum
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ApplicationCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
