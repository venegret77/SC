using Common.Models;
using Common.Models.Dictionaries;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class DictionaryService : IDictionaryService
    {
        private readonly IDictionaryRepository dictionaryRepository;

        public DictionaryService(IDictionaryRepository dictionaryRepository)
        {
            this.dictionaryRepository = dictionaryRepository;
        }

        public async Task<ResultContainer<IEnumerable<DictionaryViewModel>>> GetGendersAsync()
        {
            var result = new ResultContainer<IEnumerable<DictionaryViewModel>>();

            try
            {
                var genders = await dictionaryRepository.GetGendersAsync();

                var content = genders.Select(g => new DictionaryViewModel
                {
                    Id = g.Id,
                    Value = g.Value,
                    MUIIconName = g.MUIIconName
                });

                result.Success = true;
                result.Content = content;
            }
            catch(Exception exception)
            {
                result.Message = exception.Message;
            }

            return result;
        }
    }
}
