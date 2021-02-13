using Common.Models.Students;
using Data.EntityFramework;
using Data.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext applicationContext;

        public StudentRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<int> GetStudentsCountAsync()
        {
            return await applicationContext.Students
                .CountAsync();
        }

        public async Task<IEnumerable<StudentDto>> GetPagedStudentsAsync(int skip, int take)
        {
            return await applicationContext.Students
                .OrderBy(s => s.Id)
                .Skip(skip).Take(take)
                .ToListAsync();
        }

        public async Task AddStudentAsync(AddStudentModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateStudentAsync(UpdateStudentModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteStudentAsync(long id)
        {
            var student = applicationContext.Students
                .FirstOrDefaultAsync(s => s.Id == id);

            applicationContext.Remove(student);

            await applicationContext.SaveChangesAsync();
        }
    }
}
