using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Server.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService authorizationService;

        /// <summary>
        /// Конструктор DI
        /// </summary>
        /// <param name="authorizationService"></param>
        public AuthorizationController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }
    }
}
