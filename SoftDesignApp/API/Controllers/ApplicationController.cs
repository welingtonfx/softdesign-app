using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ApplicationController : ControllerBase
    {
        [HttpGet("teste")]
        public async Task<ActionResult<string>> Teste(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = "teste";

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }
    }
}