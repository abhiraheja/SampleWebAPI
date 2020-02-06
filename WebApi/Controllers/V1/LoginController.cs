using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbLayer.DbServices;
using Microsoft.AspNetCore.Mvc;
using Models.Authentication;
using WebApi.Contracts.V1;

namespace WebApi.Controllers.V1
{
    public class LoginController : Controller
    {
        IIdentityService _identityService;
        public LoginController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register(UserRegistrationRequest user)
        {
            var authResponse = await _identityService.RegisterAsync(user.Username, user.Password);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new LoginSuccessResponse
            {
                Token = authResponse.Token
            });
        }
    }
}