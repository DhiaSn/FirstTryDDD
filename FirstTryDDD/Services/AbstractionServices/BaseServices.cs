using FirstTryDDD.SharedKarnel.Enums;
using FirstTryDDD.SharedKarnel.Interfaces;
using FirstTryDDD.SharedKarnel.Models;
using SCodes = FirstTryDDD.SharedKarnel.Models.StatusCodes; 

namespace FirstTryDDD.API.Services.AbstractionServices
{
    public class BaseServices : IAgreggateRoot
    {
        public Response GetException(Exception ex)
        {
            if(ex.InnerException != null)
            {
                return new DetailedErrorResponse
                {
                    Result = ResponseResult.Exception, 
                    Status = SCodes.Status500InternalServerError, 
                    Exception = new ResponseException
                    {
                        Message = ex.Message, 
                        AdditionalMessage = ex.InnerException.Message
                    }
                }; 
            }

            return new SimpleErrorResponse
            {
                Result = ResponseResult.Exception,
                Status = SCodes.Status500InternalServerError,
                MsgException = ex.Message,
            }; 
        }
    }
}
