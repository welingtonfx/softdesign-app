using Aplicacao;
using AutoFixture;
using Dominio.Interface;
using Dominio.Interface.Infra.Repositorio;
using Dominio.Model;
using Dominio.ViewModel;
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
        private readonly Mock<IApplicationValidator> _applicationValidator;
        private readonly ServicoAplicacaoApplication _servicoAplicacaoApplication;

        public ServicoAplicacaoApplicationTest()
        {
            _fixture = new Fixture();
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
        public void Insert_ShouldReturnSavedObject()
        {
            var applicationViewModel = _fixture.Create<ApplicationViewModel>();
            var application = _fixture.Create<ApplicationModel>();

            var mockRepositorioApplication = new Mock<IRepositorioApplication>();
            var mockValidatorApplication = new Mock<IApplicationValidator>();

            mockRepositorioApplication.Setup(db => db.Insert(It.IsAny<ApplicationModel>())).Returns(application);

            var sut = new ServicoAplicacaoApplication(mockRepositorioApplication.Object, mockValidatorApplication.Object);
            var retorno = sut.Insert(applicationViewModel);

            Assert.IsType<ApplicationViewModel>(retorno);
            Assert.NotNull(retorno.Id);
            Assert.NotEmpty(retorno.Id);
        }

        [Fact]
        public void Updated_ShouldReturnSavedObject()
        {
            var id = _fixture.Create<string>().Substring(0, 24);
            var applicationViewModel = _fixture.Create<ApplicationViewModel>();
            var application = _fixture.Create<ApplicationModel>();

            var mockRepositorioApplication = new Mock<IRepositorioApplication>();
            var mockValidatorApplication = new Mock<IApplicationValidator>();

            mockRepositorioApplication.Setup(db => db.Update(It.IsAny<string>(), It.IsAny<ApplicationModel>())).Returns(application);

            var sut = new ServicoAplicacaoApplication(mockRepositorioApplication.Object, mockValidatorApplication.Object);
            var retorno = sut.Update(id, applicationViewModel);

            Assert.IsType<ApplicationViewModel>(retorno);
            Assert.NotNull(retorno.Id);
            Assert.NotEmpty(retorno.Id);
        }

        [Fact]
        public void RemoveModel_ShouldCallRemoveMethod()
        {
            var applicationViewModel = _fixture.Create<ApplicationViewModel>();
            var application = _fixture.Create<ApplicationModel>();

            var mockRepositorioApplication = new Mock<IRepositorioApplication>();
            var mockValidatorApplication = new Mock<IApplicationValidator>();

            mockRepositorioApplication.Setup(db => db.Remove(It.IsAny<ApplicationModel>()));

            var sut = new ServicoAplicacaoApplication(mockRepositorioApplication.Object, mockValidatorApplication.Object);
            sut.Remove(applicationViewModel);

            mockRepositorioApplication.Verify(m => m.Remove(It.IsAny<ApplicationModel>()), Times.Once());
        }

        [Fact]
        public void RemoveById_ShouldCallRemoveMethod()
        {
            var id = _fixture.Create<string>().Substring(0, 24);
            var applicationViewModel = _fixture.Create<ApplicationViewModel>();
            var application = _fixture.Create<ApplicationModel>();

            var mockRepositorioApplication = new Mock<IRepositorioApplication>();
            var mockValidatorApplication = new Mock<IApplicationValidator>();

            mockRepositorioApplication.Setup(db => db.Remove(id));

            var sut = new ServicoAplicacaoApplication(mockRepositorioApplication.Object, mockValidatorApplication.Object);
            sut.Remove(id);

            mockRepositorioApplication.Verify(m => m.Remove(id), Times.Once());
        }
    }
}
