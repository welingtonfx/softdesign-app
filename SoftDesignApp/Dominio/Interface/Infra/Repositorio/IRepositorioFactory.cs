using Dominio.Infra;

namespace Dominio.Interface.Infra.Repositorio
{
    public interface IRepositorioFactory
    {
        IRepositorio<TEntity> Create<TEntity>(RepositorioOptions options);
    }
}
