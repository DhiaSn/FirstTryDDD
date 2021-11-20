using FirstTryDDD.API.Controllers.GenericControllers;
using FirstTryDDD.API.DTOs.User;
using FirstTryDDD.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FirstTryDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class UserController : BaseController
    {
        #region Local Variable + Constructor
        private readonly ILogger<UserController> _logger;
        private readonly UserServices _services;
        public UserController(ILogger<UserController> logger, UserServices services) : base(logger, services)
        {
            _logger = logger;
            _services = services;
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> Post(PostUserRequest model) => await PostBaseAsync(model);
        #endregion

        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PutUserRequest model) => await PutBaseAsync(id, model);

        #endregion

    }
}
