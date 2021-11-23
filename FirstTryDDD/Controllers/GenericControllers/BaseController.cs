using FirstTryDDD.API.DTOs.User;
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
using SCodes = FirstTryDDD.SharedKernel.Models.StatusCodes;

namespace FirstTryDDD.API.Controllers.GenericControllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseController : ControllerBase
    {
        #region Local Variable + Constructor
        private readonly ILogger<BaseController> _logger;
        private readonly BaseServices _services;
        public BaseController(ILogger<BaseController> logger, BaseServices services)
        {
            _logger = logger;
            _services = services;
        }
        #endregion

        #region Main Methods

        #region Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Response res = await _services.GetAllAsync();

            switch(res.Result)
            {
                case SharedKernel.Enums.ResponseResult.Success:
                    return Ok(res);
                case SharedKernel.Enums.ResponseResult.Error:
                    return BadRequest(res); 
            }

            return StatusCode(500, res);
        }
        #endregion

        #region GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id != default)
            {
                try
                {
                    Response res = await _services.GetByIdAsync(id);

                    if (res.Result == SharedKernel.Enums.ResponseResult.Success)
                        return Ok(res);
                    else if (res.Status.Code == 404)
                        NotFound(res);
                    else
                        return StatusCode(500, res);
                }
                catch (Exception ex)
                {
                    return BadRequest(new SimpleErrorResponse { Status = SCodes.Status400BadRequest, Result = SharedKernel.Enums.ResponseResult.Exception, MsgException = ex.Message });
                }
            }

            return BadRequest("Incorrect Id Value");
        }

        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != default)
            {
                try
                {
                    Response res = await _services.DeleteAsync(id);

                    if (res.Result == SharedKernel.Enums.ResponseResult.Success)
                        return Ok(res);
                    else
                        return StatusCode(500, res);
                }
                catch (Exception ex)
                {
                    return BadRequest(new SimpleErrorResponse { Status = SCodes.Status400BadRequest, Result = SharedKernel.Enums.ResponseResult.Exception, MsgException = ex.Message });
                }

            }

            return BadRequest("Incorrect Id Value");
        }
        #endregion

        #region PostBaseAsync
        protected async Task<IActionResult> PostBaseAsync(dynamic model)
        {
            if (model != null)
            {
                try
                {
                    Response res = await _services.PostAsync(model);

                    if (res.Result == SharedKernel.Enums.ResponseResult.Success)
                        return Ok(res);
                    else
                        return StatusCode(500, res);
                }
                catch (Exception ex)
                {
                    return BadRequest(new SimpleErrorResponse { Status = SCodes.Status400BadRequest, Result = SharedKernel.Enums.ResponseResult.Exception, MsgException = ex.Message });
                }
            }

            return BadRequest("Null or Empty!");
        }
        #endregion

        #region PutBaseAsync
        protected async Task<IActionResult> PutBaseAsync(Guid id, dynamic model)
        {
            if(model != null)
            {
                if (id == default)
                    return BadRequest("Incorrect Id Value");

                if (model.Id != id)
                    return BadRequest("Object id doesn't match...");

                try
                {
                    Response res = await _services.PutAsync(model);

                    switch (res.Result)
                    {
                        case SharedKernel.Enums.ResponseResult.Success:
                            return Ok(res);
                        case SharedKernel.Enums.ResponseResult.Error:
                            return BadRequest(res);
                        case SharedKernel.Enums.ResponseResult.Exception:
                            return StatusCode(500, res);
                    }

                    return StatusCode(500, res);
                }
                catch (Exception ex)
                {
                    return BadRequest(new SimpleErrorResponse { Status = SCodes.Status400BadRequest, Result = SharedKernel.Enums.ResponseResult.Exception, MsgException = ex.Message });
                }
            }
            return BadRequest("Null or Empty Entity!");
        }

        #endregion

        #endregion

    }
}
