using FirstTryDDD.API.DTOs.User;
using FirstTryDDD.API.Extentions;
using FirstTryDDD.API.Services.AbstractServices;
using FirstTryDDD.Core.AggregateModels.UserAggregate;
using FirstTryDDD.SharedKernel.Enums;
using FirstTryDDD.SharedKernel.Models;
using FirstTryDDD.SharedKernel.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.Services
{
    public class UserServices : BaseServices
    {
        #region Local Variable + Constructor
        private readonly IUserRepository _repo;

        public UserServices(IUserRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Main Methods 
        #region GetAllAsync
        public override async Task<Response> GetAllAsync()
        {
            try
            {
                return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status200OK, Object = (await _repo.GetAllAsync()).ToCastedList(u => new GetUsersResponse(u.Id, u.Name, u.Age)) };
            }
            catch (Exception ex)
            {
                return new SimpleErrorResponse { Result = ResponseResult.Exception, Status = StatusCodes.Status500InternalServerError, MsgException = ex.Message };
            }
        }
        #endregion

        #region GetByIdAsync
        public override async Task<Response> GetByIdAsync(Guid id)
        {
            try
            {
                User user = await _repo.GetByIdAsync(id); 
                if(user != null)
                    return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status200OK, Object = new GetUserByIdResponse(user) };

                return new SimpleErrorResponse { Result = ResponseResult.Error, Status = StatusCodes.Status404NotFound, MsgException = "Cannot find this user..." }; 
            }
            catch (Exception ex)
            {
                return new SimpleErrorResponse { Result = ResponseResult.Exception, Status = StatusCodes.Status500InternalServerError, MsgException = ex.Message };
            }
        }
        #endregion

        #region PostAsync
        public override async Task<Response> PostAsync(dynamic model)
        {
            try
            {
                PostUserRequest user = (PostUserRequest)model; 
                return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status201Created, Object = new PostUserResponse(await _repo.PostAsync(new User { Name = user.Name, Age = user.Age, PhoneNumber = user.PhoneNumber })) };
            }
            catch (Exception ex)
            {
                return new SimpleErrorResponse { Result = ResponseResult.Exception, Status = StatusCodes.Status500InternalServerError, MsgException = ex.Message };
            }
        }
        #endregion

        #region PutAsync
        public override async Task<Response> PutAsync(dynamic newModel)
        {
            try
            {
                PutUserRequest newUser = (PutUserRequest)newModel; 
                User user = await _repo.GetByIdAsync(newUser.Id);

                if(user != null)
                {
                    user.Name = GenericServices<string>.IsDefaultValue(newUser.Name) ? user.Name : newUser.Name;
                    user.PhoneNumber = GenericServices<string>.IsDefaultValue(newUser.PhoneNumber) ? user.PhoneNumber : newUser.PhoneNumber;
                    user.Age = GenericServices<int>.IsDefaultValue(newUser.Age) ? user.Age : newUser.Age;

                    return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status200OK, Object = new PutUserResponse(await _repo.PutAsync(user)) };
                }
                return new Response { Result = ResponseResult.Error, Status = new StatusCode { Code = StatusCodes.Status400BadRequest.Code, Message = "Cannot find the target user..." } }; 
            }
            catch (Exception ex)
            {
                return new SimpleErrorResponse { Result = ResponseResult.Exception, Status = StatusCodes.Status500InternalServerError, MsgException = ex.Message };
            }
        }
        #endregion

        #region Delete
        public override async Task<Response> DeleteAsync(Guid id)
        {
            try
            {
                await _repo.DeleteAsync(id); 

                return new Response { Result = ResponseResult.Success, Status = { Code = StatusCodes.Status200OK.Code, Message = "Removed successfully" } };
            }
            catch (Exception ex)
            {
                return new SimpleErrorResponse { Result = ResponseResult.Exception, Status = StatusCodes.Status500InternalServerError, MsgException = ex.Message };
            }
        }
        #endregion
        #endregion

    }
}
