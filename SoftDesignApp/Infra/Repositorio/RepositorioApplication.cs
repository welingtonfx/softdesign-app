using Dominio.Interface.Infra;
using Dominio.Interface.Infra.Repositorio;
using Dominio.Model;
using Infra.Comum;

namespace Infra.Repositorio
{
    public class RepositorioApplication : RepositorioBase<ApplicationModel>, IRepositorioApplication
    {
        public RepositorioApplication(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}
