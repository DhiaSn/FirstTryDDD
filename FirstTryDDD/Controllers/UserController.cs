using FirstTryDDD.API.DTOs.User;
using FirstTryDDD.API.Services;
using FirstTryDDD.SharedKernel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCodes = FirstTryDDD.SharedKernel.Models.StatusCodes;

namespace FirstTryDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Local Variable + Constructor
        private readonly ILogger<UserController> _logger;
        private readonly UserServices _services;
        public UserController(ILogger<UserController> logger, UserServices services)
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

            if (res.Result == SharedKernel.Enums.ResponseResult.Success)
                return Ok(res);

            return StatusCode(500, res);  
        }
        #endregion

        #region GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            if(id != default)
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
                catch(Exception ex)
                {
                    return BadRequest(new SimpleErrorResponse { Status = SCodes.Status400BadRequest, Result = SharedKernel.Enums.ResponseResult.Exception, MsgException = ex.Message }); 
                }
            }

            return NotFound(); 

        }

        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> Post(PostUserRequest user)
        {
            if(user != null)
            {
                try
                {
                    Response res = await _services.PostAsync(user);

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

            return NoContent(); 
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PutUserRequest user)
        {
            if(id == default)
                return NotFound();

            if (user.Id != id)
                return BadRequest();

            try
            {
                Response res = await _services.PutAsync(user);

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

        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(id != default)
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

            return NotFound(); 
        }
        #endregion

        #endregion

    }
}
