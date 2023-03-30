using FirstTryDDD.API.Controllers.GenericControllers;
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
        public async Task<IActionResult> Get([FromQuery]Models.PaginationFilter model)
        {
            try
            {
                model.RecheckValues();

                return GetResult(await _services.GetAllAsync(model.PageNumber, model.PageSize)); 
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
