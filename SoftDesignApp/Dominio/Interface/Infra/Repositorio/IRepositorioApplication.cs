using Dominio.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interface.Infra.Repositorio
{
    public interface IRepositorioApplication
    {
        Task<IList<ApplicationModel>> Get();

        Task<ApplicationModel> GetById(string id);

        Task<ApplicationModel> Insert(ApplicationModel application);

        Task Update(string id, ApplicationModel application);

        Task Remove(ApplicationModel application);

        Task Remove(string id);
    }
}
