using Common.Models.Students;
using Data.EntityFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync(StudentsQueryOptions queryOptions);

        Task<long> AddStudentAsync(AddOrUpdateStudentModel model);

        Task UpdateStudentAsync(UpdateStudentModel model);

        Task DeleteStudentAsync(long id);
    }
}
