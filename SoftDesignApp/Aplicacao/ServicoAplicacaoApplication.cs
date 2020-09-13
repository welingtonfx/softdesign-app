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

        public async Task<ApplicationViewModel> Insert(ApplicationViewModel application)
        {
            var retorno = await _repositorioApplication.Insert((ApplicationModel)application);
            return (ApplicationViewModel)retorno;
        }

        public async Task<ApplicationViewModel> Update(string id, ApplicationViewModel application)
        {
            var retorno = await _repositorioApplication.Update(id, (ApplicationModel)application);
            return (ApplicationViewModel)retorno;
        }

        public async Task Remove(ApplicationViewModel application)
        {
            await _repositorioApplication.Remove((ApplicationModel)application);
        }

        public async Task Remove(string id)
        {
            await _repositorioApplication.Remove(id);
        }
    }
}
