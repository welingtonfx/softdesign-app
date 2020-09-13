using Dominio.Model;
using Dominio.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interface.Aplicacao
{
    public interface IServicoAplicacaoApplication
    {
        Task<IList<ApplicationViewModel>> Get();
        Task<ApplicationViewModel> GetById(string id);
        Task<ApplicationViewModel> Insert(ApplicationModel application);
        Task Update(string id, ApplicationModel application);
        Task Remove(ApplicationModel application);
        Task Remove(string id);
    }
}
