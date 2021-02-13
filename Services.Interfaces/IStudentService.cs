using Common.Models;
using Common.Models.Students;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStudentService
    {
        Task<ResultContainer<PagedContainer<IEnumerable<StudentViewModel>>>> GetPagedStudentsAsync(int? skip, int? take);
    }
}
