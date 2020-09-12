namespace Dominio.Interface.Infra
{
    public interface IDatabaseSettings
    {
        string ApplicationCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
