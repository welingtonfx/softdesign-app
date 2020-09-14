using Dominio.Model;
using Dominio.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interface.Aplicacao
{
    public interface IServicoAplicacaoApplication
    {
        Task<IEnumerable<ApplicationViewModel>> Get();
        Task<ApplicationViewModel> GetById(string id);
        Task<ApplicationViewModel> Insert(ApplicationViewModel application);
        Task<ApplicationViewModel> Update(string id, ApplicationViewModel application);
        Task Remove(ApplicationViewModel application);
        Task Remove(string id);
    }
}
