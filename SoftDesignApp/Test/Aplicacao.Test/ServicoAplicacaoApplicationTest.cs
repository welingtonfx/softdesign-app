using Aplicacao;
using AutoFixture;
using Dominio.Interface;
using Dominio.Interface.Infra;
using Dominio.Interface.Infra.Repositorio;
using Dominio.Model;
using Dominio.ViewModel;
using MongoDB.Bson;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Test.Aplicacao.Test
{
    public class ServicoAplicacaoApplicationTest
    {
        private readonly Fixture _fixture;
        private readonly Mock<IRepositorioApplication> _repositorioApplicationMock;

        private readonly Mock<IDatabaseSettings> _databaseSettingsMock;

        private readonly Mock<IApplicationValidator> _applicationValidator;
        private readonly ServicoAplicacaoApplication _servicoAplicacaoApplication;

        public ServicoAplicacaoApplicationTest()
        {
            _fixture = new Fixture();
            _databaseSettingsMock = new Mock<IDatabaseSettings>();

            _repositorioApplicationMock = new Mock<IRepositorioApplication>();

            _applicationValidator = new Mock<IApplicationValidator>();
            _servicoAplicacaoApplication = new ServicoAplicacaoApplication(_repositorioApplicationMock.Object, _applicationValidator.Object);
        }

        [Fact]
        public async Task Get_ShouldReturnListWithApplications()
        {
            var applications = _fixture.CreateMany<ApplicationModel>();

            _repositorioApplicationMock.Setup(p => p.Get()).ReturnsAsync(applications);

            var retorno = await _servicoAplicacaoApplication.Get();

            Assert.IsAssignableFrom<IEnumerable<ApplicationViewModel>>(retorno);
            Assert.NotEmpty(retorno);
        }

        // get vazio

        [Fact]
        public async Task GetById_ShouldReturnOneApplication()
        {
            var application = _fixture.Create<ApplicationModel>();
            var id = _fixture.Create<string>().Substring(0, 24);

            _repositorioApplicationMock.Setup(p => p.GetById(id)).ReturnsAsync(application);

            var retorno = await _servicoAplicacaoApplication.GetById(id);

            Assert.IsType<ApplicationViewModel>(retorno);
            Assert.NotNull(retorno);
            Assert.NotNull(retorno.Id);
            Assert.NotEmpty(retorno.Id);
        }

        [Fact]
        public async Task Insert_ShouldReturnSavedObject()
        {
            var applicationViewModel = _fixture.Create<ApplicationViewModel>();
            var application = (ApplicationModel)applicationViewModel;

            _repositorioApplicationMock.Setup(p => p.Insert(application)).ReturnsAsync(application);

            var retorno = await _servicoAplicacaoApplication.Insert(applicationViewModel);

            Assert.IsType<ApplicationViewModel>(retorno);
            Assert.NotNull(retorno);
            Assert.NotNull(retorno.Id);
            Assert.NotEmpty(retorno.Id);
            Assert.Equal(24, retorno.Id.Length);
        }
    }
}
