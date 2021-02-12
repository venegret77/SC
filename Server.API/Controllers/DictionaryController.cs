using Common.Models;
using Common.Models.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.API.Controllers
{
    /// <summary>
    /// Справочники
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly IDictionaryService dictionaryService;

        /// <summary>
        /// Конструктор DI
        /// </summary>
        /// <param name="dictionaryService"></param>
        public DictionaryController(IDictionaryService dictionaryService)
        {
            this.dictionaryService = dictionaryService;
        }

        /// <summary>
        /// Получение гендеров
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetGenders")]
        public async Task<ResultContainer<IEnumerable<DictionaryViewModel>>> GetGendersAsync() => await dictionaryService.GetGendersAsync();
    }
}
