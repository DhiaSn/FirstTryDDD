using FirstTryDDD.SharedKarnel.Enums;
using FirstTryDDD.SharedKarnel.Interfaces;
using FirstTryDDD.SharedKarnel.Models;
using Microsoft.AspNetCore.Mvc;
using SCodes = FirstTryDDD.SharedKarnel.Models.StatusCodes;

namespace FirstTryDDD.API.Controllers.GenericControllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase, IAgreggateRoot
    {
        #region Other Methods

        #region GetResult
        protected virtual IActionResult GetResult(Response res)
        {
            switch (res.Result)
            {
                case ResponseResult.Success:
                    return Ok(res);
                case ResponseResult.Error:
                    if (res.Status.Code.Equals(404))
                        return NotFound(res);
                    return BadRequest(res);
                case ResponseResult.Exception:
                    return StatusCode(500, res);
            }

            return Ok(res);
        }
        #endregion

        #region GetException
        protected virtual IActionResult GetException(Exception ex)
        {
            if (ex.InnerException != null)
                return BadRequest(new DetailedErrorResponse { Status = SCodes.Status400BadRequest, Result = ResponseResult.Exception, Exception = { Message = ex.Message, AdditionalMessage = ex.InnerException.Message } });
            return BadRequest(new SimpleErrorResponse { Status = SCodes.Status400BadRequest, Result = ResponseResult.Exception, MsgException = ex.Message });
        }
        #endregion

        #endregion
    }
}
