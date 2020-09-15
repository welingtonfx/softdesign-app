using Dominio.Interface;
using Dominio.Interface.Aplicacao;
using Dominio.Interface.Infra.Repositorio;
using Dominio.Model;
using Dominio.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public ApplicationViewModel Insert(ApplicationViewModel application)
        {
            _applicationValidator.ValidateAndThrow(application);

            var retorno = _repositorioApplication.Insert((ApplicationModel)application);
            return (ApplicationViewModel)retorno;
        }

        public ApplicationViewModel Update(string id, ApplicationViewModel application)
        {
            _applicationValidator.ValidateAndThrow(application);

            var retorno = _repositorioApplication.Update(id, (ApplicationModel)application);
            return (ApplicationViewModel)retorno;
        }

        public void Remove(ApplicationViewModel application)
        {
            _applicationValidator.ValidateAndThrow(application);

            _repositorioApplication.Remove((ApplicationModel)application);
        }

        public void Remove(string id)
        {
            _repositorioApplication.Remove(id);
        }
    }
}
