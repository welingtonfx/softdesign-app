using Dominio.Model;

namespace Dominio.Interface.Infra.Repositorio
{
    public interface IDbContext
    {
        IRepositorio<ApplicationModel> Applications { get; set; }
    }
}
