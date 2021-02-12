using Data.EntityFramework;
using Data.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private readonly ApplicationContext applicationContext;

        public DictionaryRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<IEnumerable<DictionaryDto>> GetGendersAsync()
        {
            var root = await applicationContext.Dictionaries
                .FirstOrDefaultAsync(d => d.Name == "Gender_Root");

            var result = await applicationContext.Dictionaries
                .Where(d => d.ParentId == root.Id)
                .ToListAsync();

            return result;
        }
    }
}
