using Dominio.Interface.Aplicacao;
using Dominio.ViewModel;
using FluentValidation;
using Infra.Comum;
using Infra.Extension;
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

        [HttpGet("get/{id:length(24)}")]
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
            catch (ValidationException ex)
            {
                return Conflict(ex.GetErrorMessages());
            }
        }

        [HttpPatch("update/{id:length(24)}")]
        public async Task<ActionResult<ApplicationViewModel>> Update(string id, ApplicationViewModel model)
        {
            try
            {
                var result = await _servicoAplicacaoApplication.Update(id, model);

                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return Conflict(ex.GetErrorMessages());
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
            catch (ValidationException ex)
            {
                return Conflict(ex.GetErrorMessages());
            }
        }

        [HttpDelete("delete/{id:length(24)}")]
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