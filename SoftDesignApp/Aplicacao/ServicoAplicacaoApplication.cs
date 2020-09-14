using Dominio.Interface.Aplicacao;
using Dominio.Interface.Infra.Repositorio;
using Dominio.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Dominio.ViewModel;
using Dominio.Interface;

namespace Aplicacao
{
    public class ServicoAplicacaoApplication : IServicoAplicacaoApplication
    {
        private readonly IRepositorioApplication _repositorioApplication;
        private readonly IApplicationValidator _applicationValidator;

        public ServicoAplicacaoApplication(IRepositorioApplication repositorioApplication,
            IApplicationValidator applicationValidator)
        {
            _repositorioApplication = repositorioApplication;
            _applicationValidator = applicationValidator;
        }

        public async Task<IEnumerable<ApplicationViewModel>> Get()
        {
            var retorno = await _repositorioApplication.Get();
            return retorno.Select(s => (ApplicationViewModel)s);
        }


        public async Task<ApplicationViewModel> GetById(string id)
        {
            var retorno = await _repositorioApplication.GetById(id);
            return (ApplicationViewModel)retorno;
        }

        public async Task<ApplicationViewModel> Insert(ApplicationViewModel application)
        {
            _applicationValidator.ValidateAndThrow(application);

            var aplicationModel = (ApplicationModel)application;
            var retorno = await _repositorioApplication.Insert(aplicationModel);
            return (ApplicationViewModel)retorno;
        }

        public async Task<ApplicationViewModel> Update(string id, ApplicationViewModel application)
        {
            _applicationValidator.ValidateAndThrow(application);

            var retorno = await _repositorioApplication.Update(id, (ApplicationModel)application);
            return (ApplicationViewModel)retorno;
        }

        public async Task Remove(ApplicationViewModel application)
        {
            _applicationValidator.ValidateAndThrow(application);

            await _repositorioApplication.Remove((ApplicationModel)application);
        }

        public async Task Remove(string id)
        {
            await _repositorioApplication.Remove(id);
        }
    }
}
