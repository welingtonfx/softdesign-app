using Dominio.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interface.Aplicacao
{
    public interface IServicoAplicacaoApplication
    {
        Task<IEnumerable<ApplicationViewModel>> Get();
        Task<ApplicationViewModel> GetById(string id);
        ApplicationViewModel Insert(ApplicationViewModel application);
        ApplicationViewModel Update(string id, ApplicationViewModel application);
        void Remove(ApplicationViewModel application);
        void Remove(string id);
    }
}
