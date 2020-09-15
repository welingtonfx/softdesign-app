using Dominio.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interface.Infra.Repositorio
{
    public interface IRepositorioApplication
    {
        Task<IEnumerable<ApplicationModel>> Get();
        Task<ApplicationModel> GetById(string id);
        ApplicationModel Insert(ApplicationModel application);
        void Remove(ApplicationModel application);
        void Remove(string id);
        ApplicationModel Update(string id, ApplicationModel application);
    }
}
