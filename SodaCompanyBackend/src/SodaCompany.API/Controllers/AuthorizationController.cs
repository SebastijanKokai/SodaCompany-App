using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SodaCompany.Application.Dtos;
using SodaCompany.Application.Services.Interfaces;
using System;

namespace SodaCompany.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        [HttpPost("GetToken")]
        public IActionResult GetJwtToken(EmployeeLoginDto credentials)
        {
            var token = _authorizationService.AuthorizeEmployee(credentials);
            Response.Cookies.Append("Token", token, new CookieOptions()
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.Unspecified,
                Expires = DateTime.Now.AddDays(10)
            });
            return Ok(token);
        }
    }
}
