using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Server.API.Controllers
{
    /// <summary>
    /// Работа с группами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        /// <summary>
        /// Конструктор DI
        /// </summary>
        /// <param name="groupService"></param>
        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }
    }
}
