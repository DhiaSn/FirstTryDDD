using FirstTryDDD.API.Models;
using FirstTryDDD.API.Services;
using FirstTryDDD.API.Services.AbstractServices;
using FirstTryDDD.SharedKernel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.Controllers.GenericControllers
{
    public class GlobalController : BaseController
    {
        #region Local Variable + Constructor 
        private readonly ILogger<GlobalController> _logger; 
        private readonly GlobalServices _services;
        public GlobalController(ILogger<GlobalController> logger, GlobalServices services) : base(logger, services)
        {
            _logger = logger;
            _services = services;
        }
        #endregion

        [HttpGet("Paginated")]
        public async Task<IActionResult> GetPaginated([FromQuery] PaginationFilter model)
        {
            if(model != null)
            {

                Response res = await _services.GetPaginatedList(model.PageNumber, model.PageSize);

                if (res.Result == SharedKernel.Enums.ResponseResult.Success)
                    return Ok(res);

                return StatusCode(500, res);
            }

            return NoContent(); 
        }

    }
}
