using FirstTryDDD.API.DTOs.Car;
using FirstTryDDD.API.Extentions;
using FirstTryDDD.API.Services.AbstractServices;
using FirstTryDDD.Core.AggregateModels.CarAggregate;
using FirstTryDDD.SharedKernel.Enums;
using FirstTryDDD.SharedKernel.Models;
using FirstTryDDD.SharedKernel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.Services
{
    public class CarServices : GlobalServices
    {

        #region Local Variable + Constructor
        private readonly ICarRepository _repo;

        public CarServices(ICarRepository repo)
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
                return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status200OK, Object = (await _repo.GetAllAsync()).ToCastedList(c => new GetCarsResponse(c.Id, c.Brand, c.Ref)) }; 
            }
            catch (Exception ex)
            {
                return new SimpleErrorResponse { Result = ResponseResult.Exception, Status = StatusCodes.Status500InternalServerError, MsgException = ex.Message };
            }
        }
        #endregion

        #region GetPaginatedList
        public override async Task<Response> GetPaginatedList(int pageNumber, int pageSize)
        {
            try
            {
                return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status200OK, Object = (await _repo.GetPaginatedList(pageNumber, pageSize))}; 
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
                Car car = await _repo.GetByIdAsync(id);
                if (car != null)
                    return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status200OK, Object = new GetCarByIdResponse(car) };

                return new SimpleErrorResponse { Result = ResponseResult.Error, Status = StatusCodes.Status404NotFound, MsgException = "Cannot find this car..." };
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
                PostCarRequest car = (PostCarRequest)model;
                return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status201Created, Object = new PostCarResponse(await _repo.PostAsync(new Car { Brand = car.Brand, Ref = car.Ref }))}; 
            }
            catch (Exception ex)
            {
                return new SimpleErrorResponse { Result = ResponseResult.Exception, Status = StatusCodes.Status500InternalServerError, MsgException = ex.Message };
            }
        }
        #endregion

        #region PostRangeAsync
        public override async Task<Response> PostRangeAsync(IEnumerable<object> entities)
        {
            try
            {
                PostRangeCarsResponse carsRes = new PostRangeCarsResponse();

                foreach (var item in (IEnumerable<PostCarRequest>)entities)
                {
                    Response res = await PostAsync(item);

                    switch (res.Result)
                    {
                        case ResponseResult.Success:
                            carsRes.CreatedCars.Add(((GlobalResponse)res).Object);
                            break;
                        case ResponseResult.Exception:
                            carsRes.UncreatedCars.Add(new UncreatedCarsResponse(item, (SimpleErrorResponse)res));
                            break;
                    }
                }

                return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status201Created, Object = carsRes };
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
                PutCarRequest newCar = (PutCarRequest)newModel;
                Car car = await _repo.GetByIdAsync(newCar.Id);

                car.Brand = GenericServices<string>.IsDefaultValue(newCar.Brand) ? car.Brand : newCar.Brand;
                car.Ref = GenericServices<string>.IsDefaultValue(newCar.Ref) ? car.Ref : newCar.Ref;

                return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status200OK, Object = new PutCarResponse(await _repo.PutAsync(car)) };
            }
            catch (Exception ex)
            {
                return new SimpleErrorResponse { Result = ResponseResult.Exception, Status = StatusCodes.Status500InternalServerError, MsgException = ex.Message };
            }
        }
        #endregion

        #region DeleteAsync
        public override async Task<Response> DeleteAsync(Guid id)
        {
            try
            {
                await _repo.DeleteAsync(id);


                return new Response { Result = ResponseResult.Success, Status = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return new SimpleErrorResponse { Result = ResponseResult.Exception, Status = StatusCodes.Status500InternalServerError, MsgException = ex.Message };
            }
        }
        #endregion

        #region DeleteRangeAsync
        public override async Task<Response> DeleteRangeAsync(IEnumerable<object> entities)
        {

            try
            {
                DeleteRangeCarsResponse carsRes = new DeleteRangeCarsResponse(); 

                foreach (var item in (IEnumerable<DeleteCar>)entities)
                {
                    Response res = await DeleteAsync(item.Id);

                    switch (res.Result)
                    { 
                        case ResponseResult.Exception: 
                            carsRes.UnDeletedCars.Add(new UnDeletedCarsResponse(item, (SimpleErrorResponse)res));
                            break;
                    }
                }

                return new GlobalResponse { Result = ResponseResult.Success, Status = StatusCodes.Status201Created, Object = carsRes };
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
