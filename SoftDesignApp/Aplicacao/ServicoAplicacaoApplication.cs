using Dominio.Interface.Aplicacao;
using Dominio.Interface.Infra.Repositorio;
using Dominio.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Dominio.ViewModel;

namespace Aplicacao
{
    public class ServicoAplicacaoApplication : IServicoAplicacaoApplication
    {
        private readonly IRepositorioApplication _repositorioApplication;
        public ServicoAplicacaoApplication(IRepositorioApplication repositorioApplication)
        {
            _repositorioApplication = repositorioApplication;
        }

        public async Task<IList<ApplicationViewModel>> Get()
        {
            var retorno = await _repositorioApplication.Get();
            return retorno.Select(s => (ApplicationViewModel)s).ToList();
        }


        public async Task<ApplicationViewModel> GetById(string id)
        {
            var retorno = await _repositorioApplication.GetById(id);
            return (ApplicationViewModel)retorno;
        }

        public async Task<ApplicationViewModel> Insert(ApplicationModel application)
        {
            var retorno = await _repositorioApplication.Insert(application);
            return (ApplicationViewModel)retorno;
        }

        public async Task Update(string id, ApplicationModel application)
        {
            await _repositorioApplication.Update(id, application);
        }

        public async Task Remove(ApplicationModel application)
        {
            await _repositorioApplication.Remove(application);
        }

        public async Task Remove(string id)
        {
            await _repositorioApplication.Remove(id);
        }
    }
}
