using Data.EntityFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IDictionaryRepository
    {
        Task<IEnumerable<DictionaryDto>> GetGendersAsync();
    }
}
