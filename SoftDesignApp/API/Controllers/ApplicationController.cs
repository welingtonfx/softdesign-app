using Dominio.Interface.Aplicacao;
using Dominio.Model;
using Dominio.ViewModel;
using Infra.Comum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ApplicationController : ControllerBase
    {
        private readonly IServicoAplicacaoApplication _servicoAplicacaoApplication;
        public ApplicationController(IServicoAplicacaoApplication servicoAplicacaoApplication)
        {
            _servicoAplicacaoApplication = servicoAplicacaoApplication;
        }

        [HttpGet("get")]
        public async Task<ActionResult<IList<ApplicationViewModel>>> Get()
        {
            try
            {
                var result = await _servicoAplicacaoApplication.Get();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<IList<ApplicationViewModel>>> GetById(string id)
        {
            try
            {
                var result = await _servicoAplicacaoApplication.GetById(id);

                return Ok(result);
            }
            catch (SoftDesignException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
        }

        [HttpPost("insert")]
        public async Task<ActionResult<ApplicationViewModel>> Insert(ApplicationViewModel model)
        {
            try
            {
                var result = await _servicoAplicacaoApplication.Insert(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPatch("{id:length(24)}")]
        public async Task<ActionResult<ApplicationViewModel>> Update(string id, ApplicationViewModel model)
        {
            try
            {
                var result = await _servicoAplicacaoApplication.Update(id, model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<ApplicationViewModel>> Delete(ApplicationViewModel model)
        {
            try
            {
                await _servicoAplicacaoApplication.Remove(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult<ApplicationViewModel>> Delete(string id)
        {
            try
            {
                await _servicoAplicacaoApplication.Remove(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }
    }
}