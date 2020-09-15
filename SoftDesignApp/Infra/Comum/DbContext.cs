using Dominio.Infra;
using Dominio.Interface.Infra;
using Dominio.Interface.Infra.Repositorio;
using Dominio.Model;

namespace Infra.Comum
{
    public class DbContext : IDbContext
    {
        public IRepositorio<ApplicationModel> Applications { get; set; }

        public DbContext(IRepositorioFactory factory, IDatabaseSettings settings)
        {
            this.Applications = factory.Create<ApplicationModel>(new RepositorioOptions(settings.ConnectionString, settings.DatabaseName, "Application"));
        }
    }
}
