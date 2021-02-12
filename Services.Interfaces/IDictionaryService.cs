using Common.Models;
using Common.Models.Dictionaries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDictionaryService
    {
        Task<ResultContainer<IEnumerable<DictionaryViewModel>>> GetGendersAsync();
    }
}
