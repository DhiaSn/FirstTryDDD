using FirstTryDDD.API.Controllers.GenericControllers;
using FirstTryDDD.API.DTOs.AuthorDTOs;
using FirstTryDDD.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstTryDDD.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    public class AuthorController : ParentController
    {
        #region Local Variables + Contructor
        private readonly AuthorServices _services;
        public AuthorController(AuthorServices services)
        {
            _services = services;
        }
        #endregion

        #region Main Methods

        #region Get
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Models.PaginationFilter model)
        {
            try
            {
                model.RecheckValues();

                return GetResult(await _services.GetAllAsync(model.PageNumber, model.PageSize));
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }
        }
        #endregion

        #region GetById
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (id == default)
                    return BadRequest("Incorrect Id value");

                return GetResult(await _services.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> Post(PostAuthorRequest model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Null or Empty!");

                return GetResult(await _services.PostAsync(model));
            }
            catch (Exception ex)
            {
                return GetException(ex);
            }
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PutAuthorRequest model)
        {
            try
            {
                if (id == default)
                    return BadRequest("Incorrect Id value");

                if (model.Id != id)
                    return BadRequest("Object id doesn't match...");

                return GetResult(await _services.PutAsync(model)); 
            }
            catch(Exception ex)
            {
                return GetException(ex); 
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == default)
                    return BadRequest("Incorrect Id value");

                return GetResult(await _services.DeleteAsync(id)); 
            }
            catch(Exception ex)
            {
                return GetException(ex); 
            }
        }
        #endregion

        #endregion

    }
}
