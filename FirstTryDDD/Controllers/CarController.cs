using FirstTryDDD.API.Controllers.GenericControllers;
using FirstTryDDD.API.DTOs.Car;
using FirstTryDDD.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class CarController : GlobalController
    {
        #region Local Variable + Constructor
        private readonly ILogger<CarController> _logger;
        private readonly CarServices _services;
        public CarController(ILogger<CarController> logger, CarServices services) : base(logger, services)
        {
            _logger = logger;
            _services = services;
        }
        #endregion


        #region Post
        [HttpPost]
        public async Task<IActionResult> Post(PostCarRequest model) => await PostBaseAsync(model);
        #endregion

        #region PostRange
        [HttpPost("Range")]
        public async Task<IActionResult> PostRange(IEnumerable<PostCarRequest> entities) => await PostRangeAsync(entities); 
        #endregion

        #region Put 
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PutCarRequest model) => await PutBaseAsync(id, model);
        #endregion

        #region DeleteRange
        [HttpDelete("Range")]
        public async Task<IActionResult> DeleteRange(IEnumerable<DeleteCar> entities) => await DeleteRangeAsync(entities);
        #endregion
    }
}
