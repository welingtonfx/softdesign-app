using Dominio.Interface.Aplicacao;
using Dominio.Model;
using Dominio.ViewModel;
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
                var result = await this._servicoAplicacaoApplication.Get();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IList<ApplicationViewModel>>> GetById(string id)
        {
            try
            {
                var result = await this._servicoAplicacaoApplication.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPost("insert")]
        public async Task<ActionResult<ApplicationViewModel>> Insert(ApplicationModel model)
        {
            try
            {
                var result = await this._servicoAplicacaoApplication.Insert(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPatch("update/{id}")]
        public async Task<ActionResult<ApplicationViewModel>> Update(string id, ApplicationModel model)
        {
            try
            {
                await this._servicoAplicacaoApplication.Update(id, model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<ApplicationViewModel>> Delete(ApplicationModel model)
        {
            try
            {
                await this._servicoAplicacaoApplication.Remove(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ApplicationViewModel>> Delete(string id)
        {
            try
            {
                await this._servicoAplicacaoApplication.Remove(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }
    }
}