using Common.Models;
using Common.Models.Students;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStudentService
    {
        Task<ResultContainer<PagedContainer<IEnumerable<StudentViewModel>>>> GetPagedStudentsAsync(int? skip, int? take);

        Task<ResultContainer<long>> AddStudentAsync(AddOrUpdateStudentModel model);

        Task<ResultContainer> UpdateStudentAsync(UpdateStudentModel model);

        Task<ResultContainer> DeleteStudentAsync(long id);
    }
}
