using Dep.App.Security.Api.Filters;
using Dep.App.Security.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dep.App.Security.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [TypeFilter(typeof(SecurityFilterErrors))]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[ProducesResponseType(typeof(DtoLoginResponse), 200)]
        //[ProducesResponseType(typeof(DtoLoginResponse), 403)]
        //public async Task<IActionResult> Login(DtoLogin request)
        //{
        //    var response = await _service.LoginAsync(request);

        //    return response.Success ? Ok(response) : Unauthorized(response);
        //}
    }
}
