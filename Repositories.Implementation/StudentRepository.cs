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

        public async Task<long> AddStudentAsync(AddOrUpdateStudentModel model)
        {
            var student = new StudentDto
            {
                GenderId = model.GenderId,
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                Identifer = model.Identifer
            };

            await applicationContext.Students
                .AddAsync(student);

            await applicationContext.SaveChangesAsync();

            return student.Id;
        }

        public async Task UpdateStudentAsync(UpdateStudentModel model)
        {
            var student = await applicationContext.Students
                .FirstOrDefaultAsync(s => s.Id == model.StudentId);

            if (student != default)
            {
                student.GenderId = model.GenderId;
                student.LastName = model.LastName;
                student.FirstName = model.FirstName;
                student.MiddleName = model.MiddleName;
                student.Identifer = model.Identifer;

                await applicationContext.SaveChangesAsync();
            }
            else
            {
                throw new System.Exception($"Student not found; ID = {model.StudentId}");
            }
        }

        public async Task DeleteStudentAsync(long id)
        {
            var student = applicationContext.Students
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student != default)
            {
                applicationContext.Remove(student);

                await applicationContext.SaveChangesAsync();
            }
            else
            {
                throw new System.Exception($"Student not found; ID = {id}");
            }
        }
    }
}
