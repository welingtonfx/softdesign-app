using API.Controllers;
using AutoFixture;
using Dominio.Interface.Aplicacao;
using Dominio.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Test.API.Test
{
    public class ApplicationControllerTest
    {
        private ApplicationController applicationController;
        private readonly Mock<IServicoAplicacaoApplication> servicoAplicacaoApplication;
        private readonly Fixture _fixture;

        public ApplicationControllerTest()
        {
            _fixture = new Fixture();
            servicoAplicacaoApplication = new Mock<IServicoAplicacaoApplication>();
            applicationController = new ApplicationController(servicoAplicacaoApplication.Object);
        }

        [Fact]
        public async Task RouteGet_ShouldReturnCorrectTypes()
        {
            var applications = _fixture.CreateMany<ApplicationViewModel>();

            servicoAplicacaoApplication.Setup(s => s.Get()).ReturnsAsync(applications);

            var retorno = await applicationController.Get();

            Assert.IsType<ActionResult<IEnumerable<ApplicationViewModel>>>(retorno);
            Assert.IsType<OkObjectResult>(retorno.Result);
        }

        [Fact]
        public async Task RouteGetById_ShouldReturnCorrectTypes()
        {
            var application = _fixture.Create<ApplicationViewModel>();
            var id = _fixture.Create<string>().Substring(0, 24);

            servicoAplicacaoApplication.Setup(s => s.GetById(id)).ReturnsAsync(application);

            var retorno = await applicationController.GetById(id);

            Assert.IsType<ActionResult<ApplicationViewModel>>(retorno);
            Assert.IsType<OkObjectResult>(retorno.Result);
        }

        [Fact]
        public void RouteInsert_ShouldReturnCorrectTypes()
        {
            var application = _fixture.Create<ApplicationViewModel>();

            servicoAplicacaoApplication.Setup(s => s.Insert(application));

            var retorno = applicationController.Insert(application);

            Assert.IsType<ActionResult<ApplicationViewModel>>(retorno);
            Assert.IsType<OkObjectResult>(retorno.Result);
        }

        [Fact]
        public void RouteUpdate_ShouldReturnCorrectTypes()
        {
            var application = _fixture.Create<ApplicationViewModel>();
            var id = _fixture.Create<string>().Substring(0, 24);

            servicoAplicacaoApplication.Setup(s => s.Update(id, application));

            var retorno = applicationController.Update(id, application);

            Assert.IsType<ActionResult<ApplicationViewModel>>(retorno);
            Assert.IsType<OkObjectResult>(retorno.Result);
        }

        [Fact]
        public void RouteDeleteModel_ShouldReturnCorrectTypes()
        {
            var application = _fixture.Create<ApplicationViewModel>();

            servicoAplicacaoApplication.Setup(s => s.Remove(application));

            var retorno = applicationController.Delete(application);

            Assert.IsType<OkResult>(retorno);
        }

        [Fact]
        public void RouteDeleteById_ShouldReturnCorrectTypes()
        {
            var id = _fixture.Create<string>().Substring(0, 24);

            servicoAplicacaoApplication.Setup(s => s.Remove(id));

            var retorno = applicationController.Delete(id);

            Assert.IsType<OkResult>(retorno);
        }
    }
}
